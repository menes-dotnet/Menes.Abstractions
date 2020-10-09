﻿// <copyright file="ObjectTypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.TypeGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;

    using SF = Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

    /// <summary>
    /// Type declaration for a complex object.
    /// </summary>
    public class ObjectTypeDeclaration : TypeDeclaration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectTypeDeclaration"/> class.
        /// </summary>
        /// <param name="parent">The parent scope.</param>
        /// <param name="name">The name of the type.</param>
        /// <param name="additionalPropertiesType">The type of any additional properties.</param>
        public ObjectTypeDeclaration(IDeclaration parent, string name, ITypeDeclaration? additionalPropertiesType = null)
            : base(parent, name)
        {
            this.AdditionalPropertiesType = additionalPropertiesType;
        }

        /// <summary>
        /// Gets the type of any additional properties.
        /// </summary>
        public ITypeDeclaration? AdditionalPropertiesType { get; }

        /// <summary>
        /// Gets or sets the type of the not validation.
        /// </summary>
        public ITypeDeclaration? NotTypeValidation { get; set; }

        /// <summary>
        /// Gets or sets the max properties validation.
        /// </summary>
        public int? MaxPropertiesValidation { get; set; }

        /// <summary>
        /// Gets or sets the min properties validation.
        /// </summary>
        public int? MinPropertiesValidation { get; set; }

        /// <summary>
        /// Gets or sets the JSON array of objects for the enum validation.
        /// </summary>
        public string? EnumValidation { get; set; }

        /// <summary>
        /// Gets or sets the JSON object for the const validation.
        /// </summary>
        public string? ConstValidation { get; set; }

        /// <inheritdoc/>
        public override TypeDeclarationSyntax GenerateType()
        {
            return
                SF.StructDeclaration(this.Name)
                    .AddModifiers(SF.Token(SyntaxKind.PublicKeyword), SF.Token(SyntaxKind.ReadOnlyKeyword))
                    .AddBaseListTypes(this.BuildBaseListTypes())
                    .AddMembers(this.BuildMembers());
        }

        /// <inheritdoc/>
        public override bool IsSpecializedBy(ITypeDeclaration type)
        {
            return false;
        }

        private static string GetPropertyNameFieldName(PropertyDeclaration property)
        {
            return $"{NameFormatter.ToPascalCase(property.JsonPropertyName)}PropertyName";
        }

        private BaseTypeSyntax[] BuildBaseListTypes()
        {
            var bases = new List<BaseTypeSyntax> { SF.SimpleBaseType(SF.ParseTypeName(typeof(IJsonObject).FullName)), SF.SimpleBaseType(SF.ParseTypeName($"System.IEquatable<{this.GetFullyQualifiedName()}>")) };

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                bases.Add(SF.SimpleBaseType(SF.ParseTypeName(typeof(IJsonAdditionalProperties).FullName)));
            }

            return bases.ToArray();
        }

        private MemberDeclarationSyntax[] BuildMembers()
        {
            var members = new List<MemberDeclarationSyntax>();

            //// Public static readonly fields

            this.BuildNullAccessor(members);
            this.BuildJsonElementFactory(members);

            //// private const, private static, private readonly (we may need to split these up)

            this.BuildPropertyBackings(members);
            this.BuildAdditionalPropertiesBacking(members);

            //// Constructors (public then private)

            this.BuildConstructors(members);

            //// Public properties
            this.BuildIsNullAccessor(members);
            this.BuildAsOptionalAccessor(members);
            this.BuildPropertyAccessors(members);
            this.BuildPropertyCountAccessors(members);
            this.BuildJsonElementAccessors(members);
            this.BuildAdditionalPropertiesAccessor(members);

            //// Public static methods

            this.BuildIsConvertibleFrom(members);
            this.BuildFromOptionalFactories(members);

            //// Public methods
            this.BuildWithPropertyFactories(members);
            this.BuildWriteTo(members);
            this.BuildEquals(members);
            this.BuildValidate(members);

            //// Private methods
            this.BuildJsonReferenceAccessors(members);
            this.BuildJsonPropertiesAccessor(members);

            return members.ToArray();
        }

        private void BuildValidate(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder();
            builder.AppendLine("public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)");
            builder.AppendLine("{");
            builder.AppendLine("    Menes.ValidationContext context = validationContext;");
            foreach (PropertyDeclaration property in this.Properties)
            {
                string propertyName = NameFormatter.ToPascalCase(property.JsonPropertyName);

                if (property.Type is OptionalTypeDeclaration)
                {
                    string fieldName = NameFormatter.ToCamelCase(property.JsonPropertyName);
                    builder.AppendLine($"    if (this.{propertyName} is {property.Type.GetFullyQualifiedName()} {fieldName})");
                    builder.AppendLine("    {");
                    builder.AppendLine($"        context = Menes.Validation.ValidateProperty(context, {fieldName}, {propertyName}PropertyNamePath);");
                    builder.AppendLine("    }");
                }
                else
                {
                    builder.AppendLine($"    context = Validation.ValidateRequiredProperty(context, this.{propertyName}, {propertyName}PropertyNamePath);");
                }
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalProperties)
            {
                builder.AppendLine("foreach (JsonPropertyReference property in this.AdditionalProperties)");
                builder.AppendLine("{");
                builder.AppendLine($"    context = Validation.ValidateProperty(context, property.AsValue<{additionalProperties.GetFullyQualifiedName()}>(), \".\" + property.Name);");
                builder.AppendLine("}");
            }

            builder.AppendLine("    return context;");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildEquals(List<MemberDeclarationSyntax> members)
        {
            string declaration =
            $"public bool Equals({this.GetFullyQualifiedName()} other)" + Environment.NewLine +
            "{" + Environment.NewLine +
            "    if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))" + Environment.NewLine +
            "    {" + Environment.NewLine +
            "        return false;" + Environment.NewLine +
            "    }" + Environment.NewLine +
            Environment.NewLine +
            "    if (this.HasJsonElement && other.HasJsonElement)" + Environment.NewLine +
            "    {" + Environment.NewLine +
            "        return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));" + Environment.NewLine +
            "    }" + Environment.NewLine +
            Environment.NewLine +
            $"    return {this.BuildEqualsForProperties()};" + Environment.NewLine +
            "}" + Environment.NewLine;

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildEqualsForProperties()
        {
            var builder = new StringBuilder();

            foreach (PropertyDeclaration property in this.Properties)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" && ");
                }

                string name = NameFormatter.ToPascalCase(property.JsonPropertyName);
                builder.Append($"this.{name}.Equals(other.{name})");
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" && ");
                }

                builder.Append("System.Linq.Enumerable.SequenceEqual(this.AdditionalProperties, other.AdditionalProperties)");
            }

            return builder.ToString();
        }

        private void BuildWriteTo(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder("public void WriteTo(System.Text.Json.Utf8JsonWriter writer)");
            builder.AppendLine("{");
            builder.AppendLine("if (this.HasJsonElement)");
            builder.AppendLine("{");
            builder.AppendLine("this.JsonElement.WriteTo(writer);");
            builder.AppendLine("}");
            builder.AppendLine("else");
            builder.AppendLine("{");
            builder.AppendLine("writer.WriteStartObject();");

            foreach (PropertyDeclaration property in this.Properties)
            {
                string fieldName = NameFormatter.ToCamelCase(property.JsonPropertyName);

                string typename = property.Type.IsCompoundType ? "JsonReference" : property.Type.GetFullyQualifiedName();

                string declaration =
                $"if (this.{fieldName} is {typename} {fieldName})" + Environment.NewLine +
                "{" + Environment.NewLine +
                $"    writer.WritePropertyName(Encoded{NameFormatter.ToPascalCase(property.JsonPropertyName)}PropertyName);" + Environment.NewLine +
                $"    {fieldName}.WriteTo(writer);" + Environment.NewLine +
                "}" + Environment.NewLine;

                builder.Append(declaration);
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                builder.AppendLine("Menes.JsonPropertyEnumerator enumerator = this.AdditionalProperties;");
                builder.AppendLine("while (enumerator.MoveNext())");
                builder.AppendLine("{");
                builder.AppendLine("enumerator.Current.Write(writer);");
                builder.AppendLine("}");
            }

            builder.AppendLine("writer.WriteEndObject();");
            builder.AppendLine("}");
            builder.AppendLine("}");
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildFromOptionalFactories(List<MemberDeclarationSyntax> members)
        {
            string fullyQualifiedTypeName = this.GetFullyQualifiedName();

            string declaration1 =
            $"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>" + Environment.NewLine +
            "    parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)" + Environment.NewLine +
            $"        ? new {fullyQualifiedTypeName}(property)" + Environment.NewLine +
            "        : Null;" + Environment.NewLine;

            string declaration2 =
                $"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>" + Environment.NewLine +
                "    parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)" + Environment.NewLine +
                $"        ? new {fullyQualifiedTypeName}(property)" + Environment.NewLine +
                "        : Null;" + Environment.NewLine;

            string declaration3 =
                $"public static {fullyQualifiedTypeName} FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>" + Environment.NewLine +
                "    parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)" + Environment.NewLine +
                $"        ? new {fullyQualifiedTypeName}(property)" + Environment.NewLine +
                "        : Null;" + Environment.NewLine;

            members.Add(SF.ParseMemberDeclaration(declaration1));
            members.Add(SF.ParseMemberDeclaration(declaration2));
            members.Add(SF.ParseMemberDeclaration(declaration3));
        }

        private void BuildIsConvertibleFrom(List<MemberDeclarationSyntax> members)
        {
            string declaration =
                "public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)" + Environment.NewLine +
                "{" + Environment.NewLine +
                "    return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;" + Environment.NewLine +
                "}" + Environment.NewLine;

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildAdditionalPropertiesAccessor(List<MemberDeclarationSyntax> members)
        {
            if (!(this.AdditionalPropertiesType is ITypeDeclaration))
            {
                return;
            }

            string declaration =
                "public Menes.JsonPropertyEnumerator AdditionalProperties" + Environment.NewLine +
                "{" + Environment.NewLine +
                "    get" + Environment.NewLine +
                "    {" + Environment.NewLine +
                "        if (this.additionalProperties is Menes.JsonProperties ap)" + Environment.NewLine +
                "        {" + Environment.NewLine +
                "            return new Menes.JsonPropertyEnumerator(ap, KnownProperties);" + Environment.NewLine +
                "        }" + Environment.NewLine +
                Environment.NewLine +
                "        if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)" + Environment.NewLine +
                "        {" + Environment.NewLine +
                "            return new Menes.JsonPropertyEnumerator(this.JsonElement, KnownProperties);" + Environment.NewLine +
                "        }" + Environment.NewLine +
                Environment.NewLine +
                "        return new Menes.JsonPropertyEnumerator(Menes.JsonProperties.Empty, KnownProperties);" + Environment.NewLine +
                "    }" + Environment.NewLine +
                "}" + Environment.NewLine;

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildJsonElementAccessors(List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration("public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;" + Environment.NewLine));
            members.Add(SF.ParseMemberDeclaration("public System.Text.Json.JsonElement JsonElement { get; }" + Environment.NewLine));
        }

        private void BuildPropertyCountAccessors(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                members.Add(SF.ParseMemberDeclaration("public int PropertiesCount => KnownProperties.Length + this.AdditionalPropertiesCount;"));

                string declaration =
                    "public int AdditionalPropertiesCount" + Environment.NewLine +
                    "{" + Environment.NewLine +
                    "    get" + Environment.NewLine +
                    "    {" + Environment.NewLine +
                    "        JsonPropertyEnumerator enumerator = this.AdditionalProperties;" + Environment.NewLine +
                    "        int count = 0;" + Environment.NewLine +
                    Environment.NewLine +
                    "        while (enumerator.MoveNext())" + Environment.NewLine +
                    "        {" + Environment.NewLine +
                    "            count++;" + Environment.NewLine +
                    "        }" + Environment.NewLine +
                    Environment.NewLine +
                    "        return count;" + Environment.NewLine +
                    "    }" + Environment.NewLine +
                    "}" + Environment.NewLine;

                members.Add(SF.ParseMemberDeclaration(declaration));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration("public int PropertiesCount => KnownProperties.Length;" + Environment.NewLine));
            }
        }

        private void BuildAsOptionalAccessor(List<MemberDeclarationSyntax> members)
        {
            string? typeName = this.GetFullyQualifiedName();
            members.Add(SF.ParseMemberDeclaration($"public {typeName}? AsOptional => this.IsNull ? default({typeName}?) : this;" + Environment.NewLine));
        }

        private void BuildIsNullAccessor(List<MemberDeclarationSyntax> members)
        {
            var builder = new StringBuilder("public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null)");
            foreach (PropertyDeclaration property in this.Properties)
            {
                builder.Append(" && ");
                string propertyName = NameFormatter.ToCamelCase(property.JsonPropertyName);
                builder.Append($"(this.{propertyName} is null || this.{propertyName}.Value.IsNull)");
            }

            builder.Append(";" + Environment.NewLine);
            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildAdditionalPropertiesBacking(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is null)
            {
                return;
            }

            members.Add(SF.ParseMemberDeclaration($"private readonly Menes.JsonProperties? additionalProperties;" + Environment.NewLine));
        }

        private void BuildConstructors(List<MemberDeclarationSyntax> members)
        {
            // public
            this.BuildJsonElementConstructor(members);

            this.BuildPropertiesConstruct(members);

            // private
            this.BuildCloningConstructor(members);
        }

        private void BuildPropertiesConstruct(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is null)
            {
                this.BuildPropertiesConstructor(members, null);
            }
            else
            {
                // Build all the variants.
                this.BuildPropertiesConstructor(members, null);
                this.BuildPropertiesConstructor(members, -1);
                this.BuildPropertiesConstructor(members, 0);
                this.BuildPropertiesConstructor(members, 1);
                this.BuildPropertiesConstructor(members, 2);
                this.BuildPropertiesConstructor(members, 3);
                this.BuildPropertiesConstructor(members, 4);
            }
        }

        private void BuildCloningConstructor(List<MemberDeclarationSyntax> members)
        {
            string declaration =
            $"private {this.Name}({this.BuildCloningConstructorParameterList()})" + Environment.NewLine +
            "{" + Environment.NewLine +
            this.BuildCloningConstructorParameterSetters() +
            " }" + Environment.NewLine;

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildCloningConstructorParameterSetters()
        {
            var builder = new StringBuilder();
            int index = 1;
            foreach (PropertyDeclaration property in this.Properties)
            {
                string parameterAndFieldName = NameFormatter.ToCamelCase(property.JsonPropertyName);

                if (property.Type.IsCompoundType)
                {
                    builder.AppendLine($"if ({parameterAndFieldName} is Menes.JsonReference item{index})");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{parameterAndFieldName} = item{index};");
                    builder.AppendLine("}");
                    builder.AppendLine("else");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{parameterAndFieldName} = null;");
                    builder.AppendLine("}");
                    index++;
                }
                else
                {
                    builder.AppendLine($"this.{parameterAndFieldName} = {parameterAndFieldName};");
                }
            }

            builder.AppendLine("this.JsonElement = default;");

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                builder.AppendLine("this.additionalProperties = additionalProperties;");
            }

            return builder.ToString();
        }

        private string BuildCloningConstructorParameterList()
        {
            var builder = new StringBuilder();

            var optionalProperties = new List<PropertyDeclaration>();
            var requiredProperties = new List<PropertyDeclaration>();
            foreach (PropertyDeclaration property in this.Properties)
            {
                if (property.Type is OptionalTypeDeclaration)
                {
                    optionalProperties.Add(property);
                }
                else
                {
                    requiredProperties.Add(property);
                }
            }

            foreach (PropertyDeclaration property in requiredProperties)
            {
                this.BuildCloningConstructorParameter(property, builder, false);
            }

            foreach (PropertyDeclaration property in optionalProperties)
            {
                this.BuildCloningConstructorParameter(property, builder, true);
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"Menes.JsonProperties? additionalProperties");
            }

            return builder.ToString();
        }

        private void BuildPropertiesConstructor(List<MemberDeclarationSyntax> members, int? additionalPropertiesCount)
        {
            string declaration =
            $"public {this.Name}({this.BuildPropertiesConstructorParameterList(additionalPropertiesCount)})" + Environment.NewLine +
            "{" + Environment.NewLine +
            this.BuildPropertiesConstructorParameterSetters(additionalPropertiesCount) +
            "}";

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildPropertiesConstructorParameterSetters(int? additionalPropertiesCount)
        {
            var builder = new StringBuilder();
            int index = 1;
            foreach (PropertyDeclaration property in this.Properties)
            {
                string parameterAndFieldName = NameFormatter.ToCamelCase(property.JsonPropertyName);

                if (property.Type.IsCompoundType)
                {
                    string fullyQualifiedTypeName = property.Type.GetFullyQualifiedName();
                    builder.AppendLine($"if ({parameterAndFieldName} is {fullyQualifiedTypeName} item{index})");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{parameterAndFieldName} = Menes.JsonReference.FromValue(item{index});");
                    builder.AppendLine("}");
                    builder.AppendLine("else");
                    builder.AppendLine("{");
                    builder.AppendLine($"this.{parameterAndFieldName} = null;");
                    builder.AppendLine("}");
                    index++;
                }
                else
                {
                    builder.AppendLine($"this.{parameterAndFieldName} = {parameterAndFieldName};");
                }
            }

            builder.AppendLine("this.JsonElement = default;");

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (additionalPropertiesCount is null)
                {
                    builder.AppendLine("this.additionalProperties = additionalProperties;");
                }
                else if (additionalPropertiesCount == -1)
                {
                    builder.AppendLine("this.additionalProperties = Menes.JsonProperties.FromValues(additionalProperties);");
                }
                else if (additionalPropertiesCount == 0)
                {
                    builder.AppendLine("this.additionalProperties = null;");
                }
                else
                {
                    builder.Append("this.additionalProperties = Menes.JsonProperties.FromValues(");
                    for (int i = 0; i < additionalPropertiesCount; ++i)
                    {
                        if (i > 0)
                        {
                            builder.Append(", ");
                        }

                        builder.Append($"additionalProperty{i + 1}");
                    }

                    builder.AppendLine(");");
                }
            }

            return builder.ToString();
        }

        private string BuildPropertiesConstructorParameterList(int? additionalPropertiesCount)
        {
            var builder = new StringBuilder();

            var optionalProperties = new List<PropertyDeclaration>();
            var requiredProperties = new List<PropertyDeclaration>();
            foreach (PropertyDeclaration property in this.Properties)
            {
                if (property.Type is OptionalTypeDeclaration)
                {
                    optionalProperties.Add(property);
                }
                else
                {
                    requiredProperties.Add(property);
                }
            }

            foreach (PropertyDeclaration property in requiredProperties)
            {
                this.BuildPropertiesConstructorParameter(property, builder, false);
            }

            foreach (PropertyDeclaration property in optionalProperties)
            {
                this.BuildPropertiesConstructorParameter(property, builder, true);
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                this.BuildPropertiesConstructorAdditionalPropertiesParameter(additionalPropertiesType, builder, additionalPropertiesCount);
            }

            return builder.ToString();
        }

        private void BuildPropertiesConstructorAdditionalPropertiesParameter(ITypeDeclaration additionalPropertiesType, StringBuilder builder, int? additionalPropertiesCount)
        {
            if (additionalPropertiesCount is null)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"Menes.JsonProperties additionalProperties");
            }
            else if (additionalPropertiesCount == -1)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append($"params (string, {additionalPropertiesType.GetFullyQualifiedName()})[] additionalProperties");
            }
            else
            {
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (builder.Length > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"(string, {additionalPropertiesType.GetFullyQualifiedName()}) additionalProperty{i + 1}");
                }
            }
        }

        private void BuildPropertiesConstructorParameter(PropertyDeclaration property, StringBuilder builder, bool isOptional)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            builder.Append(property.Type.GetFullyQualifiedName());

            if (isOptional)
            {
                builder.Append("?");
            }

            builder.Append(" ");
            builder.Append(NameFormatter.ToCamelCase(property.JsonPropertyName));
        }

        private void BuildCloningConstructorParameter(PropertyDeclaration property, StringBuilder builder, bool isOptional)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            if (property.Type.IsCompoundType)
            {
                builder.Append("Menes.JsonReference");
            }
            else
            {
                builder.Append(property.Type.GetFullyQualifiedName());
            }

            if (isOptional)
            {
                builder.Append("?");
            }

            builder.Append(" ");
            builder.Append(NameFormatter.ToCamelCase(property.JsonPropertyName));
        }

        private void BuildJsonElementConstructor(List<MemberDeclarationSyntax> members)
        {
            string declaration =
            $"public {this.Name}(System.Text.Json.JsonElement jsonElement)" + Environment.NewLine +
            "{" + Environment.NewLine +
            "    this.JsonElement = jsonElement;" + Environment.NewLine +
            this.BuildNullFieldAssignments() +
            "}" + Environment.NewLine;

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildNullFieldAssignments()
        {
            var builder = new StringBuilder();

            foreach (PropertyDeclaration property in this.Properties)
            {
                builder.AppendLine($"this.{NameFormatter.ToCamelCase(property.JsonPropertyName)} = null;");
            }

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                builder.AppendLine("this.additionalProperties = null;");
            }

            return builder.ToString();
        }

        private void BuildJsonReferenceAccessors(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                this.BuildJsonReferenceAccessor(property, members);
            }
        }

        private void BuildWithPropertyFactories(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                this.BuildWithPropertyFactory(property, members);
            }

            this.BuildWithAdditionalPropertiesFactories(members);
        }

        private void BuildWithAdditionalPropertiesFactories(List<MemberDeclarationSyntax> members)
        {
            if (this.AdditionalPropertiesType is ITypeDeclaration additionalPropertiesType)
            {
                string fullyQualifiedAdditionalPropertiesName = additionalPropertiesType.GetFullyQualifiedName();
                string fullyQualifiedName = this.GetFullyQualifiedName();
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, null);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, -1);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 1);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 2);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 3);
                this.BuildWithAdditionalPropertiesFactory(fullyQualifiedName, fullyQualifiedAdditionalPropertiesName, members, 4);
            }
        }

        private void BuildWithAdditionalPropertiesFactory(string fullyQualifiedName, string fullyQualifiedAdditionalPropertiesName, List<MemberDeclarationSyntax> members, int? additionalPropertiesCount)
        {
            var builder = new StringBuilder($"public {fullyQualifiedName} WithAdditionalProperties(");
            if (additionalPropertiesCount is null)
            {
                builder.AppendLine($"JsonProperties newAdditional)");
                builder.AppendLine("{");
                builder.Append($"return new {fullyQualifiedName}( ");
                builder.Append(this.BuildWithParametersCore(null));
                builder.AppendLine(", newAdditional);");
                builder.AppendLine("}");
            }
            else if (additionalPropertiesCount == -1)
            {
                builder.AppendLine($"params (string, {fullyQualifiedAdditionalPropertiesName})[] newAdditional)");
                builder.AppendLine("{");
                builder.Append($"return new {fullyQualifiedName}( ");
                builder.Append(this.BuildWithParametersCore(null));
                builder.AppendLine(", Menes.JsonProperties.FromValues(newAdditional));");
                builder.AppendLine("}");
            }
            else
            {
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (i > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"(string, {fullyQualifiedAdditionalPropertiesName}) newAdditional{i + 1}");
                }

                builder.AppendLine($")");
                builder.AppendLine("{");
                builder.Append($"return new {fullyQualifiedName}( ");
                builder.Append(this.BuildWithParametersCore(null));
                builder.Append(", Menes.JsonProperties.FromValues(");
                for (int i = 0; i < additionalPropertiesCount; ++i)
                {
                    if (i > 0)
                    {
                        builder.Append(", ");
                    }

                    builder.Append($"newAdditional{i + 1}");
                }

                builder.AppendLine("));");
                builder.AppendLine("}");
            }

            members.Add(SF.ParseMemberDeclaration(builder.ToString()));
        }

        private void BuildPropertyAccessors(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                this.BuildPropertyAccessor(property, members);
            }
        }

        private void BuildJsonElementFactory(List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"public static readonly System.Func<System.Text.Json.JsonElement, {this.GetFullyQualifiedName()}> FromJsonElement = e => new {this.GetFullyQualifiedName()}(e);" + Environment.NewLine));
        }

        private void BuildNullAccessor(List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"public static readonly {this.GetFullyQualifiedName()} Null = new {this.GetFullyQualifiedName()}(default);" + Environment.NewLine));
        }

        private void BuildPropertyBackings(List<MemberDeclarationSyntax> members)
        {
            var propertyNames = new List<(string, string)>();

            this.BuildPropertyNameDeclarations(members, propertyNames);
            this.BuildPropertyNamePathDeclarations(propertyNames, members);
            this.BuildEncodedPropertyNameDeclarations(propertyNames, members);
            this.BuildPropertyNameBytesDeclarations(propertyNames, members);

            this.AddKnownProperties(propertyNames, members);

            this.BuildPropertyBackingDeclarations(members);
        }

        private void BuildPropertyBackingDeclarations(List<MemberDeclarationSyntax> members)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                this.BuildPropertyBackingDeclaration(property, members);
            }
        }

        private void BuildPropertyNameDeclarations(List<MemberDeclarationSyntax> members, List<(string fieldName, string jsonPropertyName)> propertyNames)
        {
            foreach (PropertyDeclaration property in this.Properties)
            {
                string propertyNameFieldName = GetPropertyNameFieldName(property);
                this.BuildPropertyNameDeclaration(propertyNameFieldName, property.JsonPropertyName, members);
                propertyNames.Add((propertyNameFieldName, property.JsonPropertyName));
            }
        }

        private void BuildPropertyNamePathDeclarations(List<(string, string)> propertyNameFieldNames, List<MemberDeclarationSyntax> members)
        {
            foreach ((string fieldName, string jsonPropertyName) in propertyNameFieldNames)
            {
                this.BuildPropertyNamePathDeclaration(fieldName, jsonPropertyName, members);
            }
        }

        private void BuildEncodedPropertyNameDeclarations(List<(string, string)> propertyNameFieldNames, List<MemberDeclarationSyntax> members)
        {
            foreach ((string, string) propertyNameFieldName in propertyNameFieldNames)
            {
                this.BuildEncodedPropertyNameDeclaration(propertyNameFieldName.Item1, members);
            }
        }

        private void BuildPropertyNameBytesDeclarations(List<(string, string)> propertyNameFieldNames, List<MemberDeclarationSyntax> members)
        {
            foreach ((string, string) propertyNameFieldName in propertyNameFieldNames)
            {
                this.BuildPropertyNameBytesDeclaration(propertyNameFieldName.Item1, members);
            }
        }

        private void AddKnownProperties(List<(string, string)> propertyNames, List<MemberDeclarationSyntax> members)
        {
            string knownPropertiesList = string.Join(", ", propertyNames.Select(n => $"{n.Item1}Bytes"));
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create({knownPropertiesList});" + Environment.NewLine));
        }

        private void BuildJsonReferenceAccessor(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (!property.Type.IsCompoundType)
            {
                return;
            }

            string camelCasePropertyName = NameFormatter.ToCamelCase(property.JsonPropertyName);

            string declaration =
            $"private Menes.JsonReference? Get{NameFormatter.ToPascalCase(property.JsonPropertyName)}()" + Environment.NewLine +
            "{" + Environment.NewLine +
            $"    if (this.{camelCasePropertyName} is Menes.JsonReference)" + Environment.NewLine +
            "    {" + Environment.NewLine +
            $"        return this.{camelCasePropertyName};" + Environment.NewLine +
            "    }" + Environment.NewLine +
            Environment.NewLine +
            $"    if (this.HasJsonElement && this.JsonElement.TryGetProperty({GetPropertyNameFieldName(property)}Bytes.Span, out System.Text.Json.JsonElement value))" + Environment.NewLine +
            "    {" + Environment.NewLine +
            "        return new Menes.JsonReference(value);" + Environment.NewLine +
            "    }" + Environment.NewLine +
            Environment.NewLine +
            "    return default;" + Environment.NewLine +
            "}" + Environment.NewLine;

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildJsonPropertiesAccessor(List<MemberDeclarationSyntax> members)
        {
            if (!(this.AdditionalPropertiesType is ITypeDeclaration))
            {
                return;
            }

            string declaration =
            "private Menes.JsonProperties GetJsonProperties()" + Environment.NewLine +
            "{" + Environment.NewLine +
            "    if (this.additionalProperties is Menes.JsonProperties props)" + Environment.NewLine +
            "    {" + Environment.NewLine +
            "        return props;" + Environment.NewLine +
            "    }" + Environment.NewLine +
            Environment.NewLine +
            "    return new Menes.JsonProperties(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.AdditionalProperties));" + Environment.NewLine +
            "} " + Environment.NewLine;

            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private void BuildWithPropertyFactory(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            string optionalQualifier = property.Type is OptionalTypeDeclaration ? "?" : string.Empty;
            string fullyQualifiedName = this.GetFullyQualifiedName();
            string declaration =
$" public {fullyQualifiedName} With{NameFormatter.ToPascalCase(property.JsonPropertyName)}({property.Type.GetFullyQualifiedName()}{optionalQualifier} value)" + Environment.NewLine +
" {" + Environment.NewLine +
$"    return new {fullyQualifiedName}(" + this.BuildWithParameters(property) + ");" + Environment.NewLine +
" }";
            members.Add(SF.ParseMemberDeclaration(declaration));
        }

        private string BuildWithParameters(PropertyDeclaration property)
        {
            var builder = new StringBuilder();

            builder.Append(this.BuildWithParametersCore(property));

            if (this.AdditionalPropertiesType is ITypeDeclaration)
            {
                if (builder.Length > 0)
                {
                    builder.Append(", ");
                }

                builder.Append("this.GetJsonProperties()");
            }

            return builder.ToString();
        }

        private string BuildWithParametersCore(PropertyDeclaration? property)
        {
            var builder = new StringBuilder();

            var requiredProperties = new List<PropertyDeclaration>();
            var optionalProperties = new List<PropertyDeclaration>();

            foreach (PropertyDeclaration current in this.Properties)
            {
                if (current.Type is OptionalTypeDeclaration)
                {
                    optionalProperties.Add(current);
                }
                else
                {
                    requiredProperties.Add(current);
                }
            }

            foreach (PropertyDeclaration current in requiredProperties)
            {
                this.BuildWithParameter(property, builder, current);
            }

            foreach (PropertyDeclaration current in optionalProperties)
            {
                this.BuildWithParameter(property, builder, current);
            }

            return builder.ToString();
        }

        private void BuildWithParameter(PropertyDeclaration? property, StringBuilder builder, PropertyDeclaration current)
        {
            if (builder.Length > 0)
            {
                builder.Append(", ");
            }

            if (property is PropertyDeclaration prop && prop == current)
            {
                builder.Append("value");
            }
            else if (current.Type.IsCompoundType)
            {
                builder.Append($"this.Get{NameFormatter.ToPascalCase(current.JsonPropertyName)}()");
            }
            else
            {
                builder.Append($"this.{NameFormatter.ToPascalCase(current.JsonPropertyName)}");
            }
        }

        private void BuildPropertyAccessor(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            string typeName = property.Type.GetFullyQualifiedName();
            string propertyName = NameFormatter.ToPascalCase(property.JsonPropertyName);
            string fieldNameAccessor = property.Type.IsCompoundType ? $"this.{NameFormatter.ToCamelCase(property.JsonPropertyName)}?.AsValue<{typeName}>()" : $"this.{NameFormatter.ToCamelCase(property.JsonPropertyName)}";

            if (property.Type is OptionalTypeDeclaration)
            {
                members.Add(SF.ParseMemberDeclaration($"public {typeName}? {propertyName} => {fieldNameAccessor} ?? {typeName}.FromOptionalProperty(this.JsonElement, {propertyName}PropertyNameBytes.Span).AsOptional;" + Environment.NewLine));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"public {typeName} {propertyName} => {fieldNameAccessor} ?? {typeName}.FromOptionalProperty(this.JsonElement, {propertyName}PropertyNameBytes.Span);" + Environment.NewLine));
            }
        }

        private void BuildPropertyBackingDeclaration(PropertyDeclaration property, List<MemberDeclarationSyntax> members)
        {
            if (property.Type.IsCompoundType)
            {
                members.Add(SF.ParseMemberDeclaration($"private readonly Menes.JsonReference? {NameFormatter.ToCamelCase(property.JsonPropertyName)};" + Environment.NewLine));
            }
            else
            {
                members.Add(SF.ParseMemberDeclaration($"private readonly {property.Type.GetFullyQualifiedName()}? {NameFormatter.ToCamelCase(property.JsonPropertyName)};" + Environment.NewLine));
            }
        }

        private void BuildPropertyNameDeclaration(string propertyNameFieldName, string jsonPropertyName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private const string {propertyNameFieldName} = \"{jsonPropertyName}\";" + Environment.NewLine));
        }

        private void BuildPropertyNamePathDeclaration(string propertyNameFieldName, string jsonPropertyName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private const string {propertyNameFieldName}Path = \".{jsonPropertyName}\";" + Environment.NewLine));
        }

        private void BuildEncodedPropertyNameDeclaration(string propertyNameFieldName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.Text.Json.JsonEncodedText Encoded{propertyNameFieldName} = System.Text.Json.JsonEncodedText.Encode({propertyNameFieldName});" + Environment.NewLine));
        }

        private void BuildPropertyNameBytesDeclaration(string propertyNameFieldName, List<MemberDeclarationSyntax> members)
        {
            members.Add(SF.ParseMemberDeclaration($"private static readonly System.ReadOnlyMemory<byte> {propertyNameFieldName}Bytes = System.Text.Encoding.UTF8.GetBytes({propertyNameFieldName});" + Environment.NewLine));
        }
    }
}
