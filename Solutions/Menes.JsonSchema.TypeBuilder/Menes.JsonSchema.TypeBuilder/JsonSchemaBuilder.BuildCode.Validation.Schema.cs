﻿// <copyright file="JsonSchemaBuilder.BuildCode.Validation.Schema.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using Menes.JsonSchema.TypeBuilder.Model;

    /// <summary>
    /// Builds types from a Json Schema document.
    /// </summary>
    public partial class JsonSchemaBuilder
    {
        /// <summary>
        /// Build the validation code for schema validation and add it to the body of the validation member.
        /// </summary>
        private void BuildSchemaValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            memberBuilder.AppendLine("Menes.ValidationResult result = validationResult ?? Menes.ValidationResult.ValidResult;");

            this.BuildTypeValidations(typeDeclaration, memberBuilder);
            this.BuildFormatValidations(typeDeclaration, memberBuilder);

            this.BuildConstValidation(typeDeclaration, memberBuilder);
            this.BuildEnumValidation(typeDeclaration, memberBuilder);

            this.BuildNumericValidations(typeDeclaration, memberBuilder);

            this.BuildStringValidations(typeDeclaration, memberBuilder);

            if (typeDeclaration.AllOf is not null || typeDeclaration.AnyOf is not null || typeDeclaration.OneOf is not null)
            {
                this.BuildAllOfValidation(typeDeclaration, memberBuilder);
                this.BuildOneOfValidation(typeDeclaration, memberBuilder);
                this.BuildAnyOfValidation(typeDeclaration, memberBuilder);
            }

            this.BuildPropertyValidations(typeDeclaration, memberBuilder);
            this.BuildEnumeratedPropertyValidations(typeDeclaration, memberBuilder);

            this.BuildArrayValidation(typeDeclaration, memberBuilder);

            memberBuilder.AppendLine("return result;");

            this.BuildValidationLocalFunctions(typeDeclaration, memberBuilder);
        }

        private void BuildFormatValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Format is null)
            {
                return;
            }

            if (TypeDeclarations.IsNumericFormat(typeDeclaration.Format))
            {
                memberBuilder.AppendLine($"if (this.IsNumber)");
                memberBuilder.AppendLine("{");
            }
            else if (TypeDeclarations.IsStringFormat(typeDeclaration.Format))
            {
                memberBuilder.AppendLine($"if (this.IsString)");
                memberBuilder.AppendLine("{");
            }
            else
            {
                return;
            }

            TypeDeclaration type = TypeDeclarations.GetTypeFor(null, typeDeclaration.Format);
            memberBuilder.AppendLine($"result = this.As<{type.FullyQualifiedDotNetTypeName}>().Validate(result);");
            memberBuilder.AppendLine("if (level == Menes.ValidationLevel.Flag && !result.Valid)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return result;");
            memberBuilder.AppendLine("}");

            memberBuilder.AppendLine("}");
        }

        private void BuildConstValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Const is not JsonElement value)
            {
                return;
            }

            if (value.ValueKind == JsonValueKind.Number)
            {
                memberBuilder.AppendLine("if (!this.IsNumber)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if ((double)this != (double)_MenesConstValue)");
                memberBuilder.AppendLine("    {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    else");
                memberBuilder.AppendLine("    {");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
            }
            else if (value.ValueKind == JsonValueKind.Null)
            {
                memberBuilder.AppendLine("if (!this.IsNull)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match null value", memberBuilder);
                memberBuilder.AppendLine("    if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine("        return result;");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("}");
            }
            else if (value.ValueKind == JsonValueKind.False || value.ValueKind == JsonValueKind.True)
            {
                memberBuilder.AppendLine("if (!this.IsBoolean)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if ((bool)this != (bool)_MenesConstValue)");
                memberBuilder.AppendLine("    {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    else");
                memberBuilder.AppendLine("    {");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
            }
            else if (value.ValueKind == JsonValueKind.String)
            {
                memberBuilder.AppendLine("if (!this.IsString)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if (!System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), _MenesConstValue.AsSpan()))");
                memberBuilder.AppendLine("    {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    else");
                memberBuilder.AppendLine("    {");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
            }
            else if (value.ValueKind == JsonValueKind.Array)
            {
                memberBuilder.AppendLine("if (!this.IsArray)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    var firstEnumerator = _MenesConstValue.EnumerateArray();");
                memberBuilder.AppendLine("    var secondEnumerator = this.EnumerateArray();");
                memberBuilder.AppendLine("    bool failed = false;");
                memberBuilder.AppendLine("   while(firstEnumerator.MoveNext())");
                memberBuilder.AppendLine("   {");

                // If we can't move the second enumerator on, we've run out of items.
                memberBuilder.AppendLine("       if (!secondEnumerator.MoveNext())");
                memberBuilder.AppendLine("       {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("           if (level == Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("           {");
                memberBuilder.AppendLine("               return result;");
                memberBuilder.AppendLine("           }");
                memberBuilder.AppendLine("           else");
                memberBuilder.AppendLine("           {");
                memberBuilder.AppendLine("                failed = true;");
                memberBuilder.AppendLine("           }");
                memberBuilder.AppendLine("       }");
                memberBuilder.AppendLine("       if (!firstEnumerator.Current.Equals(secondEnumerator.Current))");
                memberBuilder.AppendLine("       {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("           if (level == Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("           {");
                memberBuilder.AppendLine("               return result;");
                memberBuilder.AppendLine("           }");
                memberBuilder.AppendLine("           else");
                memberBuilder.AppendLine("           {");
                memberBuilder.AppendLine("                failed = true;");
                memberBuilder.AppendLine("           }");
                memberBuilder.AppendLine("       }");

                memberBuilder.AppendLine("   }");

                memberBuilder.AppendLine("if (!failed)");
                memberBuilder.AppendLine("{");

                // we can still move the second enumerator on, having got to the end of the first, so we've failed.
                memberBuilder.AppendLine("    if (secondEnumerator.MoveNext())");
                memberBuilder.AppendLine("    {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("           if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("           {");
                memberBuilder.AppendLine("               return result;");
                memberBuilder.AppendLine("           }");
                memberBuilder.AppendLine("           else");
                memberBuilder.AppendLine("           {");
                memberBuilder.AppendLine("                failed = true;");
                memberBuilder.AppendLine("           }");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");

                memberBuilder.AppendLine("}");
            }
            else if (value.ValueKind == JsonValueKind.Object)
            {
                memberBuilder.AppendLine("if (!this.IsObject)");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
                memberBuilder.AppendLine("else");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    if (!this.Equals(_MenesConstValue))");
                memberBuilder.AppendLine("    {");
                this.WriteError($"6.1.3. const - does not match const value {value.GetRawText()}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("    else");
                memberBuilder.AppendLine("    {");
                this.WriteSuccess(memberBuilder);
                memberBuilder.AppendLine("    }");
                memberBuilder.AppendLine("}");
            }
        }

        private void BuildEnumValidation(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Enum is not List<JsonElement> values)
            {
                return;
            }

            ////this.WriteError($"6.1.2. enum - does not match enum values {string.Join(", ", value.Select(v => v.GetRawText()))}", memberBuilder);

            memberBuilder.AppendLine("bool foundMatch = false;");

            int enumIndex = 0;
            foreach (JsonElement value in values)
            {
                if (value.ValueKind == JsonValueKind.Number)
                {
                    memberBuilder.AppendLine("if (!foundMatch)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    if (this.IsNumber)");
                    memberBuilder.AppendLine("    {");
                    if (typeDeclaration.IsNumericType)
                    {
                        memberBuilder.AppendLine($"        if ((double)this != (double){typeDeclaration.DotnetTypeName}.EnumValues.Item{enumIndex})");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"        if ((double)this.As<Menes.JsonNumber>() != (double){typeDeclaration.DotnetTypeName}.EnumValues.Item{enumIndex})");
                    }

                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            foundMatch = false;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("        else");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            foundMatch = true;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("}");
                }
                else if (value.ValueKind == JsonValueKind.Null)
                {
                    memberBuilder.AppendLine("if (!foundMatch)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    if (this.IsNull)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        foundMatch = true;");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("}");
                }
                else if (value.ValueKind == JsonValueKind.False || value.ValueKind == JsonValueKind.True)
                {
                    memberBuilder.AppendLine("if (!foundMatch)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    if (this.IsBoolean)");
                    memberBuilder.AppendLine("    {");

                    if (typeDeclaration.IsBooleanType)
                    {
                        memberBuilder.AppendLine($"        if ((bool)this == (bool){typeDeclaration.DotnetTypeName}.EnumValues.Item{enumIndex})");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"        if ((bool)this.As<Menes.JsonBoolean>() == (bool){typeDeclaration.DotnetTypeName}.EnumValues.Item{enumIndex})");
                    }

                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            foundMatch = true;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("}");
                }
                else if (value.ValueKind == JsonValueKind.String)
                {
                    memberBuilder.AppendLine("if (!foundMatch)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    if (this.IsString)");
                    memberBuilder.AppendLine("    {");

                    memberBuilder.AppendLine($"       if (System.MemoryExtensions.SequenceEqual(this.As<Menes.JsonString>().AsSpan(), {typeDeclaration.DotnetTypeName}.EnumValues.Item{enumIndex}.AsSpan()))");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            foundMatch = true;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("}");
                }
                else if (value.ValueKind == JsonValueKind.Array)
                {
                    memberBuilder.AppendLine("if (!foundMatch)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    if (this.IsArray)");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        var firstEnumerator = {typeDeclaration.DotnetTypeName}.EnumValues.Item{enumIndex}.EnumerateArray();");

                    if (typeDeclaration.IsArrayType)
                    {
                        memberBuilder.AppendLine("        var secondEnumerator = this.EnumerateArray();");
                    }
                    else
                    {
                        memberBuilder.AppendLine("        var secondEnumerator = this.As<Menes.JsonAny>().EnumerateArray();");
                    }

                    memberBuilder.AppendLine("        bool failed = false;");
                    memberBuilder.AppendLine("        while(firstEnumerator.MoveNext())");
                    memberBuilder.AppendLine("        {");

                    // If we can't move the second enumerator on, we've run out of items.
                    memberBuilder.AppendLine("            if (!secondEnumerator.MoveNext())");
                    memberBuilder.AppendLine("            {");
                    memberBuilder.AppendLine("                 failed = true;");
                    memberBuilder.AppendLine("                 break;");
                    memberBuilder.AppendLine("            }");
                    memberBuilder.AppendLine("            else if (!firstEnumerator.Current.Equals(secondEnumerator.Current))");
                    memberBuilder.AppendLine("            {");
                    memberBuilder.AppendLine("                 failed = true;");
                    memberBuilder.AppendLine("                 break;");
                    memberBuilder.AppendLine("            }");
                    memberBuilder.AppendLine("        }");

                    memberBuilder.AppendLine("       if (!failed && !secondEnumerator.MoveNext())");
                    memberBuilder.AppendLine("       {");
                    memberBuilder.AppendLine("           foundMatch = true;");
                    memberBuilder.AppendLine("       }");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("}");
                }
                else if (value.ValueKind == JsonValueKind.Object)
                {
                    memberBuilder.AppendLine("if (!foundMatch)");
                    memberBuilder.AppendLine("{");
                    memberBuilder.AppendLine("    if (this.IsObject)");
                    memberBuilder.AppendLine("    {");

                    if (typeDeclaration.IsObjectType)
                    {
                        memberBuilder.AppendLine($"        if (this.Equals({typeDeclaration.DotnetTypeName}.EnumValues.Item{enumIndex}))");
                    }
                    else
                    {
                        memberBuilder.AppendLine($"        if (this.As<Menes.JsonAny>().Equals({typeDeclaration.DotnetTypeName}.EnumValues.Item{enumIndex}))");
                    }

                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("               foundMatch = true;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("}");
                }

                enumIndex++;
            }

            memberBuilder.AppendLine("if (!foundMatch)");
            memberBuilder.AppendLine("{");
            this.WriteError($"6.1.2. enum - does not match enum values {string.Join(", ", values.Select(v => v.GetRawText()))}", memberBuilder);
            memberBuilder.AppendLine("if (level == Menes.ValidationLevel.Flag && !result.Valid)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    return result;");
            memberBuilder.AppendLine("}");
            memberBuilder.AppendLine("}");
            memberBuilder.AppendLine("else");
            memberBuilder.AppendLine("{");
            this.WriteSuccess(memberBuilder);
            memberBuilder.AppendLine("}");
        }

        private void BuildTypeValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.Type is not null)
            {
                bool isFirst = true;
                memberBuilder.Append($"if (");
                foreach (string type in typeDeclaration.Type)
                {
                    switch (type)
                    {
                        case "array":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsArray");
                            break;
                        case "object":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsObject");
                            break;
                        case "number":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsNumber");
                            break;
                        case "string":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsString");
                            break;
                        case "integer":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsInteger");
                            break;
                        case "null":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsNull");
                            break;
                        case "boolean":
                            isFirst = AppendOperator(memberBuilder, isFirst);
                            memberBuilder.Append("!this.IsBoolean");
                            break;
                    }
                }

                memberBuilder.AppendLine(")");
                memberBuilder.AppendLine("{");
                this.WriteError($"6.1.1.  type - item must be one of {string.Join(",", typeDeclaration.Type)}", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("}");
            }

            static bool AppendOperator(StringBuilder memberBuilder, bool isFirst)
            {
                if (isFirst)
                {
                    isFirst = false;
                }
                else
                {
                    memberBuilder.Append(" && ");
                }

                return isFirst;
            }
        }

        private void BuildNumericValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsNumericType)
            {
                memberBuilder.AppendLine("if (this.IsNumber)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    var number = (double)this.As<Menes.JsonNumber>();");
                if (typeDeclaration.MultipleOf is double mo)
                {
                    memberBuilder.AppendLine($"    if (System.Math.Abs(System.Math.IEEERemainder((double)number, (double){mo})) > 1.0E-18)");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.1.  multipleOf - item must be a multiple of {mo}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.Maximum is double ma)
                {
                    memberBuilder.AppendLine($"    if (number > (double){ma})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.2.  maximum - item must be less than or equal to {ma}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.ExclusiveMaximum is double ema)
                {
                    memberBuilder.AppendLine($"    if (number >= (double){ema})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.3.  exclusiveMaximum - item must be less then {ema}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.Minimum is double mi)
                {
                    memberBuilder.AppendLine($"    if (number < (double){mi})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.4.  minimum - item must be greater than or equal to {mi}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.ExclusiveMinimum is double emi)
                {
                    memberBuilder.AppendLine($"    if (number <= (double){emi})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.2.3.  exclusiveMinimum - item must be greater then {emi}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                memberBuilder.AppendLine("}");
            }
        }

        private void BuildStringValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (typeDeclaration.IsStringType)
            {
                memberBuilder.AppendLine("if (this.IsString)");
                memberBuilder.AppendLine("{");
                memberBuilder.AppendLine("    var value = (string)this.As<Menes.JsonString>();");

                if (typeDeclaration.MaxLength is int maxl)
                {
                    memberBuilder.AppendLine($"    if (value.Length > {maxl})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.3.1.  maxLength - value must have length less than or equal to {maxl}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.MinLength is int minl)
                {
                    memberBuilder.AppendLine($"    if (value.Length < {minl})");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.3.2.  minimum - value must have length greater than or equal to {minl}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                if (typeDeclaration.Pattern is string pattern)
                {
                    memberBuilder.AppendLine($"    if (!_MenesPatternExpression.IsMatch(value))");
                    memberBuilder.AppendLine("    {");
                    this.WriteError($"6.3.3.  pattern - value must match the regular expression {pattern}", memberBuilder);
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                }

                memberBuilder.AppendLine("}");
            }
        }

        private void BuildEnumeratedPropertyValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectType)
            {
                return;
            }

            memberBuilder.AppendLine("if (this.IsObject)");
            memberBuilder.AppendLine("{");
            memberBuilder.AppendLine("    foreach (var property in this.EnumerateObject())");
            memberBuilder.AppendLine("    {");

            if (typeDeclaration.PatternProperties is not null)
            {
                int patternIndex = 0;

                foreach (PatternProperty patternProperty in typeDeclaration.PatternProperties)
                {
                    memberBuilder.AppendLine($"    if (_MenesPatternExpression{patternIndex}.IsMatch(property.Name))");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine("        evaluatedProperties?.Add(property.Name);");
                    memberBuilder.AppendLine($"        result = property.Value<{patternProperty.Schema.FullyQualifiedDotNetTypeName}>().Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                    patternIndex++;
                }
            }

            if (typeDeclaration.AllowsAdditionalProperties && typeDeclaration.AdditionalProperties is not null)
            {
                memberBuilder.AppendLine($"    if (!evaluatedProperties?.Contains(property.Name) ?? true)");
                memberBuilder.AppendLine("    {");
                memberBuilder.AppendLine($"        result = property.Value<{typeDeclaration.AdditionalProperties.FullyQualifiedDotNetTypeName}>().Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
            }
            else if (!typeDeclaration.AllowsAdditionalProperties)
            {
                memberBuilder.AppendLine($"    if (!evaluatedProperties?.Contains(property.Name) ?? true)");
                memberBuilder.AppendLine("    {");
                this.WriteError("9.3.2.3. additionalProperties - additional properties are not permitted.", memberBuilder);
                memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag)");
                memberBuilder.AppendLine("        {");
                memberBuilder.AppendLine("            return result;");
                memberBuilder.AppendLine("        }");
                memberBuilder.AppendLine("    }");
            }

            memberBuilder.AppendLine("    }");
            memberBuilder.AppendLine("}");
        }

        private void BuildPropertyValidations(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            if (!typeDeclaration.IsObjectType)
            {
                return;
            }

            if (typeDeclaration.Properties is not null)
            {
                int index = 0;
                memberBuilder.AppendLine("if (this.IsObject)");
                memberBuilder.AppendLine("{");

                foreach (PropertyDeclaration property in typeDeclaration.Properties)
                {
                    // Don't evaluate non-local properties here (e.g. those that are merged in from allOf)
                    if (!property.IsLocal)
                    {
                        index++;
                        continue;
                    }

                    this.PushPropertyToAbsoluteKeywordLocationStack(property.JsonPropertyName!);
                    this.BuildPushAbsoluteKeywordLocation(memberBuilder, index);
                    memberBuilder.AppendLine($"    evaluatedProperties?.Add({Formatting.FormatLiteralOrNull(property.JsonPropertyName, true)});");
                    memberBuilder.AppendLine($"    if (this.TryGetProperty<{property.TypeDeclaration!.FullyQualifiedDotNetTypeName}>(_Menes{property.DotnetPropertyName}JsonPropertyName.Span, out {property.TypeDeclaration!.FullyQualifiedDotNetTypeName} value{index}))");
                    memberBuilder.AppendLine("    {");
                    memberBuilder.AppendLine($"        result = value{index}.Validate(result, level, evaluatedProperties, absoluteKeywordLocation, instanceLocation);");
                    memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag && !result.Valid)");
                    memberBuilder.AppendLine("        {");
                    memberBuilder.AppendLine("            return result;");
                    memberBuilder.AppendLine("        }");
                    memberBuilder.AppendLine("    }");
                    memberBuilder.AppendLine("    else");
                    memberBuilder.AppendLine("    {");

                    if (property.IsRequired)
                    {
                        this.WriteError("6.5.3. required - required property not present.", memberBuilder);
                        memberBuilder.AppendLine("        if (level == Menes.ValidationLevel.Flag)");
                        memberBuilder.AppendLine("        {");
                        memberBuilder.AppendLine("            return result;");
                        memberBuilder.AppendLine("        }");
                    }
                    else
                    {
                        this.WriteSuccess(memberBuilder);
                    }

                    memberBuilder.AppendLine("    }");

                    this.BuildPopAbsoluteKeywordLocation(memberBuilder, index);
                    this.absoluteKeywordLocationStack.Pop();
                    index++;
                }

                memberBuilder.AppendLine("}");
            }
        }

        private void BuildValidationLocalFunctions(TypeDeclaration typeDeclaration, StringBuilder memberBuilder)
        {
            this.BuildAllOfValidationLocalFunction(typeDeclaration, memberBuilder);
            this.BuildAnyOfValidationLocalFunction(typeDeclaration, memberBuilder);
            this.BuildOneOfValidationLocalFunction(typeDeclaration, memberBuilder);
        }
    }
}
