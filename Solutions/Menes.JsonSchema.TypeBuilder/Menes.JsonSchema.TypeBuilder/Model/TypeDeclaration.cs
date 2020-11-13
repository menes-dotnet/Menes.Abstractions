﻿// <copyright file="TypeDeclaration.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>

namespace Menes.JsonSchema.TypeBuilder.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;

    /// <summary>
    /// A declaration of a type built from schema.
    /// </summary>
    public class TypeDeclaration
    {
        private readonly List<string> memberNames = new List<string>();
        private readonly HashSet<string> jsonPropertyNames = new HashSet<string>();
        private TypeDeclaration? lowered;

        /// <summary>
        /// Initializes a new instance of the <see cref="TypeDeclaration"/> class.
        /// </summary>
        /// <param name="typeSchema">The schema element related to the type.</param>
        /// <param name="builtInType">Determines whether this is a built-in type.</param>
        public TypeDeclaration(LocatedElement typeSchema = default, bool builtInType = false)
        {
            this.TypeSchema = typeSchema;
            this.BuiltInType = builtInType;
        }

        /// <summary>
        /// Gets or sets the parent declaration containing this type declaration.
        /// </summary>
        public TypeDeclaration? Parent { get; set; }

        /// <summary>
        /// Gets or sets the dotnet name of the type.
        /// </summary>
        public string? DotnetTypeName { get; set; }

        /// <summary>
        /// Gets a value indicating whether this is a lowered reference type.
        /// </summary>
        /// <remarks>
        /// If <c>true</c> you will not need to generate this instance of the type, but just use
        /// its type name.
        /// </remarks>
        public bool IsRef { get; private set; }

        /// <summary>
        /// Gets the fully qualified dotnet name of the type.
        /// </summary>
        public string? FullyQualifiedDotNetTypeName
        {
            get
            {
                if (this.DotnetTypeName is null)
                {
                    return null;
                }

                var nameSegments = new List<string>
                {
                    this.DotnetTypeName,
                };

                TypeDeclaration? parent = this.Parent;
                while (parent is TypeDeclaration p)
                {
                    nameSegments.Insert(0, p.DotnetTypeName!);
                    parent = parent.Parent;
                }

                return string.Join('.', nameSegments);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether this is a boolean true type.
        /// </summary>
        public bool IsBooleanTrueType { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this is a boolean false type.
        /// </summary>
        public bool IsBooleanFalseType { get; set; }

        /// <summary>
        /// Gets or sets the type array for this type declaration.
        /// </summary>
        public List<string>? Type { get; set; }

        /// <summary>
        /// Gets or sets the schema from which the type was built.
        /// </summary>
        public LocatedElement TypeSchema { get; set; }

        /// <summary>
        /// Gets a value indicating whether this is a built-in type or not.
        /// </summary>
        /// <remarks>
        /// Built-in types do not need generation, and may not be decorated.
        /// </remarks>
        public bool BuiltInType { get; }

        /// <summary>
        /// Gets the non-optional properties exposed by the type.
        /// </summary>
        public List<PropertyDeclaration>? Properties { get; private set; }

        /// <summary>
        /// Gets the list of conversion operators for the type.
        /// </summary>
        public List<ConversionOperatorDeclaration>? ConversionOperators { get; private set; }

        /// <summary>
        /// Gets the list of explicit AsSomeType() and IsSomeType() validation methods for the type.
        /// </summary>
        public List<AsConversionMethodDeclaration>? AsConversionMethods { get; private set; }

        /// <summary>
        /// Gets the list of nested types in this declaration.
        /// </summary>
        public List<TypeDeclaration>? NestedTypes { get; private set; }

        /// <summary>
        /// Gets the list of merged types in this declaration.
        /// </summary>
        /// <remarks>These will have been merged as a result of compounding property types through an <c>allOf</c> declaration, or an array-based <c>type</c> property.</remarks>
        public List<TypeDeclaration>? MergedTypes { get; private set; }

        /// <summary>
        /// Gets the list of types that form a oneOf set.
        /// </summary>
        public List<TypeDeclaration>? AnyOfTypes { get; private set; }

        /// <summary>
        /// Gets the list of types that form a oneOf set.
        /// </summary>
        public List<TypeDeclaration>? OneOfTypes { get; private set; }

        /// <summary>
        /// Gets the list of types that form an allOf set.
        /// </summary>
        public List<TypeDeclaration>? AllOfTypes { get; private set; }

        /// <summary>
        /// Gets or sets the Not type.
        /// </summary>
        public TypeDeclaration? NotType { get; set; }

        /// <summary>
        /// Gets or sets the If Then and Else types.
        /// </summary>
        public IfThenElse? IfThenElseTypes { get; set; }

        /// <summary>
        /// Gets or sets the additional items type.
        /// </summary>
        public TypeDeclaration? AdditionalItems { get; set; }

        /// <summary>
        /// Gets or sets the unevaluated items type.
        /// </summary>
        public TypeDeclaration? UnevaluatedItems { get; set; }

        /// <summary>
        /// Gets or sets the contains type.
        /// </summary>
        public TypeDeclaration? Contains { get; set; }

        /// <summary>
        /// Gets or sets the additional items type.
        /// </summary>
        public TypeDeclaration? AdditionalProperties { get; set; }

        /// <summary>
        /// Gets a value indicating whether this type allows additional properties.
        /// </summary>
        public bool AllowsAdditionalProperties
        {
            get
            {
                // The only case where we don't allow additional properties
                if (this.AdditionalProperties is not null &&
                    this.AdditionalProperties.IsBooleanFalseType)
                {
                    return false;
                }

                return true;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a boolean schema.
        /// </summary>
        public bool IsBooleanSchema => this.IsBooleanFalseType || this.IsBooleanTrueType;

        /// <summary>
        /// Gets a value indicating whether this type has been lowered.
        /// </summary>
        public bool IsLowered { get; private set; }

        /// <summary>
        /// Gets the fully lowered version of this type and its entire graph.
        /// </summary>
        public TypeDeclaration Lowered
        {
            get
            {
                TypeDeclaration current = this.Lower();
                while (current.lowered != null)
                {
                    current = current.lowered;
                }

                return current;
            }
        }

        /// <summary>
        /// Gets or sets the pattern for a string value.
        /// </summary>
        public string? Pattern { get; set; }

        /// <summary>
        /// Gets or sets the maximum length of a string.
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Gets or sets the minimum length of a string.
        /// </summary>
        public int? MinLength { get; set; }

        /// <summary>
        /// Gets or sets the multiple-of numeric validation.
        /// </summary>
        public double? MultipleOf { get; set; }

        /// <summary>
        /// Gets or sets the maximum numeric validation.
        /// </summary>
        public double? Maximum { get; set; }

        /// <summary>
        /// Gets or sets the exclusive maximum numeric validation.
        /// </summary>
        public double? ExclusiveMaximum { get; set; }

        /// <summary>
        /// Gets or sets the minimum numeric validation.
        /// </summary>
        public double? Minimum { get; set; }

        /// <summary>
        /// Gets or sets the exclusive minimum numeric validation.
        /// </summary>
        public double? ExclusiveMinimum { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items in the array.
        /// </summary>
        public int? MaxItems { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of items in the array.
        /// </summary>
        public int? MinItems { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the items in the array should be unique.
        /// </summary>
        public bool? UniqueItems { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of items in the array that match the contains type.
        /// </summary>
        public int? MaxContains { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of items in the array that match the contains type.
        /// </summary>
        public int? MinContains { get; set; }

        /// <summary>
        /// Gets or sets the maximum number of properties in the object.
        /// </summary>
        public int? MaxProperties { get; set; }

        /// <summary>
        /// Gets or sets the minimum number of properties in the object.
        /// </summary>
        public int? MinProperties { get; set; }

        /// <summary>
        /// Gets or sets the set of dependent required properties in the object.
        /// </summary>
        public Dictionary<string, List<string>>? DependendentRequired { get; set; }

        /// <summary>
        /// Add a conversion operator.
        /// </summary>
        /// <param name="conversionOperatorDeclaration">The operator to add.</param>
        /// <remarks>
        /// This will not add a conversion operator if it already existing in the type.
        /// </remarks>
        public void AddConversionOperator(ConversionOperatorDeclaration conversionOperatorDeclaration)
        {
            List<ConversionOperatorDeclaration> operators = this.EnsureConversionOperators();

            if (operators.Any(o => o.TargetType == conversionOperatorDeclaration.TargetType))
            {
                return;
            }

            operators.Add(conversionOperatorDeclaration);
        }

        /// <summary>
        /// Gets a value which determines whether this type contains a reference to a given type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to compare.</param>
        /// <returns><c>true</c> if this object is itself an instance of the type, or if any of its properties are instances of that type.</returns>
        public bool ContainsReferenceTo(TypeDeclaration typeDeclaration)
        {
            if (this == typeDeclaration)
            {
                return true;
            }

            return this.Properties.Any(p => p.TypeDeclaration?.ContainsReferenceTo(typeDeclaration) ?? false);
        }

        /// <summary>
        /// Add a child type declaration to this type.
        /// </summary>
        /// <param name="typeDeclaration">The type declaration to add.</param>
        public void AddTypeDeclaration(TypeDeclaration typeDeclaration)
        {
            this.ValidateMemberName(typeDeclaration.DotnetTypeName);
            this.memberNames.Add(typeDeclaration.DotnetTypeName!);
            this.EnsureNestedTypes().Add(typeDeclaration);
        }

        /// <summary>
        /// Add a property declaration to this type.
        /// </summary>
        /// <param name="propertyDeclaration">The property declaration to add.</param>
        public void AddPropertyDeclaration(PropertyDeclaration propertyDeclaration)
        {
            this.ValidateMemberName(propertyDeclaration.DotnetPropertyName);
            this.jsonPropertyNames.Add(propertyDeclaration.JsonPropertyName!);
            this.memberNames.Add(propertyDeclaration.DotnetPropertyName!);
            this.EnsureProperties().Add(propertyDeclaration);
        }

        /// <summary>
        /// Determines if we contain a member matching the given name.
        /// </summary>
        /// <param name="span">The name to match.</param>
        /// <returns>True if we match the name.</returns>
        public bool ContainsMemberName(Span<char> span)
        {
            foreach (string name in this.memberNames)
            {
                if (span.SequenceEqual(name.AsSpan()))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Merge the given type declartion into this type.
        /// </summary>
        /// <param name="allOfType">Add the given allOf type declaration into this type.</param>
        /// <remarks>
        /// The all of type will be merged with this type, and added to the allOf list for validation.
        /// </remarks>
        public void AddAllOfType(TypeDeclaration allOfType)
        {
            this.Merge(allOfType);
            List<TypeDeclaration> allOfTypes = this.EnsureAllOfTypes();
            if (!allOfTypes.Contains(allOfType))
            {
                allOfTypes.Add(allOfType);
                this.AddConversionOperatorsFor(allOfType, false);
            }
        }

        /// <summary>
        /// Merge the given type declartion into this type.
        /// </summary>
        /// <param name="anyOfType">Add the given anyOf type declaration into this type.</param>
        /// <remarks>
        /// The all of type will not be merged with this type, but is added to the anyOf list for validation.
        /// </remarks>
        public void AddAnyOfType(TypeDeclaration anyOfType)
        {
            List<TypeDeclaration> anyOfTypes = this.EnsureAnyOfTypes();
            if (!anyOfTypes.Contains(anyOfType))
            {
                anyOfTypes.Add(anyOfType);
                this.AddConversionOperatorsFor(anyOfType, true);
            }
        }

        /// <summary>
        /// Merge the given type declartion into this type.
        /// </summary>
        /// <param name="oneOfType">Add the given oneOf type declaration into this type.</param>
        /// <remarks>
        /// The all of type will not be merged with this type, but is added to the oneOf list for validation.
        /// </remarks>
        public void AddOneOfType(TypeDeclaration oneOfType)
        {
            List<TypeDeclaration> oneOfTypes = this.EnsureOneOfTypes();
            if (!oneOfTypes.Contains(oneOfType))
            {
                oneOfTypes.Add(oneOfType);
                this.AddConversionOperatorsFor(oneOfType, true);
            }
        }

        /// <summary>
        /// Merge the given type declartion into this type.
        /// </summary>
        /// <param name="typeToMerge">Merge the given type declaration into this type.</param>
        /// <remarks>
        /// The order in which you merge types is important.
        /// </remarks>
        public void Merge(TypeDeclaration typeToMerge)
        {
            List<TypeDeclaration> mergedTypes = this.EnsureMergedTypes();
            if (!mergedTypes.Contains(typeToMerge))
            {
                mergedTypes.Add(typeToMerge);
            }
        }

        /// <summary>
        /// Try to get the property declaration with the given JSON property name.
        /// </summary>
        /// <param name="jsonPropertyName">The JSON property name of the property.</param>
        /// <param name="propertyDeclaration">The property declaration.</param>
        /// <returns><c>true</c> if the type declaration contained a property with the specified name.</returns>
        public bool TryGetPropertyDeclaration(string jsonPropertyName, [NotNullWhen(true)] out PropertyDeclaration? propertyDeclaration)
        {
            if (this.Properties is null)
            {
                propertyDeclaration = default;
                return false;
            }

            foreach (PropertyDeclaration property in this.Properties)
            {
                if (property.JsonPropertyName == jsonPropertyName)
                {
                    propertyDeclaration = property;
                    return true;
                }
            }

            propertyDeclaration = default;
            return false;
        }

        /// <summary>
        /// Determines whether the type contains at least one JSON property
        /// of the given name.
        /// </summary>
        /// <param name="name">The JSON property name to check.</param>
        /// <returns><c>True</c> if there is at least one property declared with that JSON property name.</returns>
        public bool ContainsJsonProperty(string name)
        {
            return this.jsonPropertyNames.Contains(name);
        }

        /// <summary>
        /// Returns true if this type specializes the other type declaration.
        /// </summary>
        /// <param name="other">The other type delaration.</param>
        /// <returns><c>true</c> if this type represents a more constrained version of the other type.</returns>
        public bool Specializes(TypeDeclaration other)
        {
            //// TODO - consider recursive definitions here - do we need to break out of this if we see a deeper recursive loop?
            //// I believe we are OK as we have already dealt with that scenario...but we will have to confirm by testing.
            //// (There are existing tests which validate this)

            // Lower the types and work off those
            TypeDeclaration lowered = this.Lowered;
            TypeDeclaration loweredOther = other.Lowered;

            // If we are the lowered version of this type, just return true
            if (loweredOther == lowered)
            {
                return true;
            }

            // We always specialise the {} type.
            if (loweredOther.IsBooleanTrueType)
            {
                return true;
            }

            // Can never specialise the not type
            if (loweredOther.IsBooleanFalseType)
            {
                return false;
            }

            // Cannot specialize a type if we are not in its types list, or its types list is empty
            if (loweredOther.Type is List<string> otherTypes && loweredOther.Type.Count > 0)
            {
                // We are not more specialized if we are "any"
                if (lowered.Type is null)
                {
                    return false;
                }

                if (lowered.Type.Any(type => !loweredOther.Type.Contains(type)))
                {
                    return false;
                }
            }

            // We can short circuit the longer check, by looking at all of types directly.
            // If we must match this, then we are indeed a specialized version of that
            // type
            if (lowered.AllOfTypes is not null && lowered.AllOfTypes.Contains(loweredOther))
            {
                return true;
            }

            if (loweredOther.AnyOfTypes is not null && loweredOther.AnyOfTypes.Any(t => lowered.Specializes(t)))
            {
                return true;
            }

            if (loweredOther.OneOfTypes is not null && loweredOther.OneOfTypes.Any(t => lowered.Specializes(t)))
            {
                return true;
            }

            // Notice that we have to invert the check for the not type - we are a more specialized version of this if
            // the Not type is a more specialized version of us.
            // Consider if they are Not {} and we are not {type: boolean} - we cannot specialize because they are denying
            // everything and we are denying just booleans so we are more relaxed about the range of values we would support
            // and yet normally {type: boolean} would specialise {} as it is more constrained.
            if (loweredOther.NotType is not null &&
                lowered.NotType is not null &&
                !loweredOther.NotType.Specializes(lowered.NotType))
            {
                return false;
            }

            if (loweredOther.AdditionalItems is not null &&
                lowered.AdditionalItems is not null &&
                !lowered.AdditionalItems.Specializes(loweredOther.AdditionalItems))
            {
                return false;
            }

            if (loweredOther.UnevaluatedItems is not null &&
                lowered.UnevaluatedItems is not null &&
                !lowered.UnevaluatedItems.Specializes(loweredOther.UnevaluatedItems))
            {
                return false;
            }

            if (loweredOther.Contains is not null &&
                lowered.Contains is not null &&
                !lowered.Contains.Specializes(loweredOther.Contains))
            {
                return false;
            }

            if (loweredOther.AdditionalProperties is not null &&
                lowered.AdditionalProperties is not null &&
                !lowered.AdditionalProperties.Specializes(loweredOther.AdditionalProperties))
            {
                return false;
            }

            if (!loweredOther.AllowsAdditionalProperties)
            {
                if (loweredOther.Properties is null || loweredOther.Properties.Count == 0)
                {
                    return lowered.Properties is null || lowered.Properties.Count == 0;
                }

                if (!lowered.AllowsAdditionalProperties)
                {
                    if (lowered.Properties is null || loweredOther.Properties.Count > lowered.Properties.Count)
                    {
                        return false;
                    }
                }
                else
                {
                    if (lowered.Properties is not null && loweredOther.Properties.Count < lowered.Properties.Count)
                    {
                        return false;
                    }
                }
            }

            // So the type allows additional properties, or we have the same number or fewer properties than them
            // so let's check that all of the properties they have are specialized by the properties we have
            // If we see a property we don't have, we return false if we do not allow additional properties.

            // Note that none of lowered guarantees that we will be *valid* if we assign these properties
            // but it does determine whether the schema supports specialising these property values in our
            // composed class.
            if (loweredOther.Properties is null || loweredOther.Properties.Count == 0)
            {
                return true;
            }

            foreach (PropertyDeclaration? property in loweredOther.Properties)
            {
                if (property.JsonPropertyName is null)
                {
                    throw new InvalidOperationException("You must have set the JSON property name on all properties before calling Specializes()");
                }

                if (lowered.TryGetPropertyDeclaration(property.JsonPropertyName, out PropertyDeclaration? ourProperty))
                {
                    if (ourProperty.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must have set the property type on all properties before calling Specializes().");
                    }

                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must have set the property type on all properties before calling Specializes()");
                    }

                    if (!ourProperty.TypeDeclaration.Specializes(property.TypeDeclaration))
                    {
                        return false;
                    }
                }
                else
                {
                    // We've found a property in them that we don't have, so we can't specialize lowered type.
                    if (!lowered.AllowsAdditionalProperties)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        /// <summary>
        /// Collapses the merged type declarations into a single type declaration for use in generation.
        /// </summary>
        /// <returns>The lowered type declaration.</returns>
        public TypeDeclaration Lower()
        {
            if (this.lowered is TypeDeclaration)
            {
                return this.lowered;
            }

            // First - we don't change our type schema; we are still the same type, however we got here...
            // Our typename and the "type" of the item comes from us, and we will still parent into the existing
            // parent type
            var result = new TypeDeclaration(this.TypeSchema)
            {
                DotnetTypeName = this.DotnetTypeName,
                Type = this.Type,
                Parent = this.Parent,
                IsLowered = true,
            };

            // Ensure we have set the result early, before we start potentially recursively
            // lowering, so that the lowered result is available to recursive calls.
            this.lowered = result;

            if (this.MergedTypes is not null)
            {
                // Lower the types to merge.
                var loweredTypes = this.MergedTypes.Select(m => m.Lowered).ToList();

                if (loweredTypes.Count == 1)
                {
                    // If we are empty apart from a single merged type,
                    // then treat us as that merged type.
                    // Note that the IsRef = true means this instance won't be generated,
                    // and we are just taking on its properties for inspection purposes.
                    // If we used the original type directly, we would lose our referential
                    // scope in the absoluteKeywordLocation hierarchy, and also get into trouble
                    // with recursive references.
                    if (this.AdditionalItems is null &&
                        this.AdditionalProperties is null &&
                        this.AllOfTypes is null &&
                        this.AnyOfTypes is null &&
                        this.AsConversionMethods is null &&
                        this.Contains is null &&
                        this.ConversionOperators is null &&
                        this.DependendentRequired is null &&
                        this.ExclusiveMaximum is null &&
                        this.ExclusiveMinimum is null &&
                        this.IfThenElseTypes is null &&
                        this.MaxContains is null &&
                        this.Maximum is null &&
                        this.MaxItems is null &&
                        this.MaxLength is null &&
                        this.MaxProperties is null &&
                        this.MinContains is null &&
                        this.Minimum is null &&
                        this.MinItems is null &&
                        this.MinLength is null &&
                        this.MinProperties is null &&
                        this.MultipleOf is null &&
                        this.NotType is null &&
                        this.OneOfTypes is null &&
                        this.Pattern is null &&
                        this.Properties is null &&
                        this.UnevaluatedItems is null &&
                        this.UniqueItems is null &&
                        this.Type is null)
                    {
                        result.DotnetTypeName = loweredTypes[0].DotnetTypeName;
                        result.Type = loweredTypes[0].Type;
                        result.IsRef = true;
                    }
                }

                // Iterate the types to merge and merge them in
                foreach (TypeDeclaration typeToMerge in loweredTypes)
                {
                    MergeTypes(result, typeToMerge);
                }
            }

            // Then merge in lowered versions of our own items
            MergeAdditionalItems(this.AdditionalItems?.Lowered, result);
            MergeUnevaluatedItems(this.UnevaluatedItems?.Lowered, result);
            MergeContains(this.Contains?.Lowered, result);
            MergeAdditionalProperties(this.AdditionalProperties?.Lowered, result);
            MergeAllOfTypes(Lower(this.AllOfTypes), result);
            MergeAsConversionMethods(Lower(this.AsConversionMethods), result);
            MergeAnyOfTypes(Lower(this.AnyOfTypes), result);
            MergeConversionOperators(Lower(this.ConversionOperators), result);
            MergeIfThenElseTypes(Lower(this.IfThenElseTypes), result);
            MergeNotType(this.NotType?.Lowered, result);
            MergeOneOfTypes(Lower(this.OneOfTypes), result);
            MergeProperties(Lower(this.Properties), result);

            return this.lowered;
        }

        private static void MergeTypes(TypeDeclaration result, TypeDeclaration typeToMerge)
        {
            MergeAdditionalItems(typeToMerge.AdditionalItems, result);
            MergeUnevaluatedItems(typeToMerge.UnevaluatedItems, result);
            MergeContains(typeToMerge.Contains, result);
            MergeAdditionalProperties(typeToMerge.AdditionalProperties, result);
            MergeAllOfTypes(typeToMerge.AllOfTypes, result);
            MergeAsConversionMethods(typeToMerge.AsConversionMethods, result);
            MergeAnyOfTypes(typeToMerge.AnyOfTypes, result);
            MergeConversionOperators(typeToMerge.ConversionOperators, result);
            MergeIfThenElseTypes(typeToMerge.IfThenElseTypes, result);
            MergeNotType(typeToMerge.NotType, result);
            MergeOneOfTypes(typeToMerge.OneOfTypes, result);
            MergeProperties(typeToMerge.Properties, result);
        }

        private static IfThenElse? Lower(IfThenElse? ifThenElseTypes)
        {
            if (ifThenElseTypes is null ||
               (ifThenElseTypes.If.IsLowered &&
               (ifThenElseTypes.Then?.IsLowered ?? true) &&
               (ifThenElseTypes.Else?.IsLowered ?? true)))
            {
                return ifThenElseTypes;
            }

            return new IfThenElse(ifThenElseTypes.If.Lowered, ifThenElseTypes.Then?.Lowered, ifThenElseTypes.Else?.Lowered);
        }

        private static List<PropertyDeclaration>? Lower(List<PropertyDeclaration>? properties)
        {
            return properties?.Select(p => (p.TypeDeclaration?.IsLowered ?? true) ? p : new PropertyDeclaration { DotnetFieldName = p.DotnetFieldName, DotnetPropertyName = p.DotnetPropertyName, IsRequired = p.IsRequired, JsonPropertyName = p.JsonPropertyName, TypeDeclaration = p.TypeDeclaration?.Lowered }).ToList();
        }

        private static List<ConversionOperatorDeclaration>? Lower(List<ConversionOperatorDeclaration>? conversionOperators)
        {
            return conversionOperators?.Select(c => (c.TargetType?.IsLowered ?? true) ? c : new ConversionOperatorDeclaration { Conversion = c.Conversion, TargetType = c.TargetType?.Lowered }).ToList();
        }

        private static List<AsConversionMethodDeclaration>? Lower(List<AsConversionMethodDeclaration>? asConversionMethods)
        {
            return asConversionMethods?.Select(c => (c.TargetType?.IsLowered ?? true) ? c : new AsConversionMethodDeclaration { Conversion = c.Conversion, DotnetMethodTypeSuffix = c.DotnetMethodTypeSuffix, TargetType = c.TargetType?.Lowered }).ToList();
        }

        private static List<TypeDeclaration>? Lower(List<TypeDeclaration>? typeDeclarations)
        {
            return typeDeclarations?.Select(t => t.Lowered).ToList();
        }

        private static void MergeConversionOperators(List<ConversionOperatorDeclaration>? conversionOperatorsToMerge, TypeDeclaration result)
        {
            if (conversionOperatorsToMerge is null)
            {
                return;
            }

            List<ConversionOperatorDeclaration>? conversionOperators = result.EnsureConversionOperators();
            foreach (ConversionOperatorDeclaration conversion in conversionOperatorsToMerge)
            {
                if (!conversionOperators.Any(c => c.TargetType == conversion.TargetType))
                {
                    conversionOperators.Add(conversion);
                }
            }

            result.ConversionOperators = conversionOperators;
        }

        private static void MergeAsConversionMethods(List<AsConversionMethodDeclaration>? asConversionMethodsToMerge, TypeDeclaration result)
        {
            if (asConversionMethodsToMerge is null)
            {
                return;
            }

            List<AsConversionMethodDeclaration>? conversionMethods = result.EnsureAsConversionMethods();
            foreach (AsConversionMethodDeclaration conversion in asConversionMethodsToMerge)
            {
                if (!conversionMethods.Any(c => c.TargetType == conversion.TargetType))
                {
                    conversionMethods.Add(conversion);
                }
            }

            result.AsConversionMethods = conversionMethods;
        }

        private static void MergeProperties(List<PropertyDeclaration>? propertiesToMerge, TypeDeclaration result)
        {
            if (propertiesToMerge is null)
            {
                return;
            }

            List<PropertyDeclaration> properties = result.EnsureProperties();

            foreach (PropertyDeclaration property in propertiesToMerge)
            {
                if (property.JsonPropertyName is null)
                {
                    throw new InvalidOperationException("You must set the JsonPropertyName on all properties before calling Lower()");
                }

                if (result.TryGetPropertyDeclaration(property.JsonPropertyName, out PropertyDeclaration? propertyDeclaration))
                {
                    if (property.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must set the TypeDeclaration on all properties before calling Lower()");
                    }

                    if (propertyDeclaration.TypeDeclaration is null)
                    {
                        throw new InvalidOperationException("You must set the TypeDeclaration on all properties before calling Lower()");
                    }

                    if (property.TypeDeclaration.Specializes(propertyDeclaration.TypeDeclaration))
                    {
                        properties.Remove(propertyDeclaration);
                        properties.Add(property);
                    }
                }
                else
                {
                    properties.Add(property);
                }
            }
        }

        private static void MergeNotType(TypeDeclaration? typeToMerge, TypeDeclaration result)
        {
            result.NotType = PickMostDerivedTypeWithOptionals(typeToMerge, result.NotType);
        }

        private static void MergeIfThenElseTypes(IfThenElse? typeToMerge, TypeDeclaration result)
        {
            if (typeToMerge is not null)
            {
                if (result.IfThenElseTypes is null)
                {
                    result.IfThenElseTypes = typeToMerge;
                    return;
                }

                result.IfThenElseTypes = new IfThenElse(
                    PickMostDerivedType(typeToMerge.If, result.IfThenElseTypes.If),
                    PickMostDerivedTypeWithOptionals(typeToMerge.Then, result.IfThenElseTypes.Then),
                    PickMostDerivedTypeWithOptionals(typeToMerge.Else, result.IfThenElseTypes.Else));
            }
        }

        private static TypeDeclaration PickMostDerivedType(TypeDeclaration first, TypeDeclaration second)
        {
            if (first.Specializes(second))
            {
                return first;
            }

            return second;
        }

        private static TypeDeclaration? PickMostDerivedTypeWithOptionals(TypeDeclaration? first, TypeDeclaration? second)
        {
            if (first is null)
            {
                return second;
            }

            if (second is null)
            {
                return first;
            }

            if (first.Specializes(second))
            {
                return first;
            }

            return second;
        }

        private static void MergeAllOfTypes(List<TypeDeclaration>? allOfTypes, TypeDeclaration result)
        {
            if (allOfTypes is not null)
            {
                List<TypeDeclaration> resultTypes = result.EnsureAllOfTypes();

                foreach (TypeDeclaration type in allOfTypes)
                {
                    if (type != result && !resultTypes.Contains(type))
                    {
                        resultTypes.Add(type);
                    }
                }

                result.AllOfTypes = resultTypes;
            }
        }

        private static void MergeAnyOfTypes(List<TypeDeclaration>? anyOfTypes, TypeDeclaration result)
        {
            if (anyOfTypes is not null)
            {
                List<TypeDeclaration> resultTypes = result.EnsureAnyOfTypes();

                foreach (TypeDeclaration type in anyOfTypes)
                {
                    if (type != result && !resultTypes.Contains(type))
                    {
                        resultTypes.Add(type);
                    }
                }

                result.AnyOfTypes = resultTypes;
            }
        }

        private static void MergeOneOfTypes(List<TypeDeclaration>? oneOfTypes, TypeDeclaration result)
        {
            if (oneOfTypes is not null)
            {
                List<TypeDeclaration> resultTypes = result.EnsureOneOfTypes();

                foreach (TypeDeclaration type in oneOfTypes)
                {
                    if (type != result && !resultTypes.Contains(type))
                    {
                        resultTypes.Add(type);
                    }
                }

                result.OneOfTypes = resultTypes;
            }
        }

        private static void MergeAdditionalProperties(TypeDeclaration? additionalProperties, TypeDeclaration result)
        {
            result.AdditionalProperties = PickMostDerivedTypeWithOptionals(additionalProperties, result.AdditionalProperties);
        }

        private static void MergeAdditionalItems(TypeDeclaration? additionalItems, TypeDeclaration result)
        {
            result.AdditionalItems = PickMostDerivedTypeWithOptionals(additionalItems, result.AdditionalItems);
        }

        private static void MergeUnevaluatedItems(TypeDeclaration? unevaluatedItems, TypeDeclaration result)
        {
            result.UnevaluatedItems = PickMostDerivedTypeWithOptionals(unevaluatedItems, result.UnevaluatedItems);
        }

        private static void MergeContains(TypeDeclaration? contains, TypeDeclaration result)
        {
            result.Contains = PickMostDerivedTypeWithOptionals(contains, result.Contains);
        }

        private void AddAsConversionMethod(AsConversionMethodDeclaration asConversionMethodDeclaration)
        {
            List<AsConversionMethodDeclaration> conversionOperators = this.EnsureAsConversionMethods();
            conversionOperators.Add(asConversionMethodDeclaration);
        }

        private void AddConversionOperatorsFor(TypeDeclaration targetType, bool includeTargetConversions)
        {
            // Add implicit bidirectional conversion from the all/any/oneOf type.
            this.AddConversionOperator(
                new ConversionOperatorDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    Direction = ConversionOperatorDeclaration.ConversionDirection.BidirectionalImplicit,
                    TargetType = targetType,
                });

            // Add an As{Typename} method
            this.AddAsConversionMethod(
                new AsConversionMethodDeclaration
                {
                    Conversion = ConversionOperatorDeclaration.ConversionType.GenericAsAndStaticFrom,
                    TargetType = targetType,
                });

            if (includeTargetConversions)
            {
                if (targetType.ConversionOperators is not null)
                {
                    foreach (ConversionOperatorDeclaration conversion in targetType.ConversionOperators)
                    {
                        this.AddChildConversionOperator(targetType, conversion);
                    }
                }
            }
        }

        private void AddChildConversionOperator(TypeDeclaration targetType, ConversionOperatorDeclaration childConversion)
        {
            this.AddConversionOperator(childConversion.CreateViaTo(targetType));
        }

        private List<TypeDeclaration> EnsureMergedTypes()
        {
            return this.MergedTypes ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureAnyOfTypes()
        {
            return this.AnyOfTypes ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureOneOfTypes()
        {
            return this.OneOfTypes ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureAllOfTypes()
        {
            return this.AllOfTypes ??= new List<TypeDeclaration>();
        }

        private List<TypeDeclaration> EnsureNestedTypes()
        {
            return this.NestedTypes ??= new List<TypeDeclaration>();
        }

        private List<PropertyDeclaration> EnsureProperties()
        {
            return this.Properties ??= new List<PropertyDeclaration>();
        }

        private List<ConversionOperatorDeclaration> EnsureConversionOperators()
        {
            return this.ConversionOperators ??= new List<ConversionOperatorDeclaration>();
        }

        private List<AsConversionMethodDeclaration> EnsureAsConversionMethods()
        {
            return this.AsConversionMethods ??= new List<AsConversionMethodDeclaration>();
        }

        private void ValidateMemberName(string? name)
        {
            if (name is null)
            {
                throw new InvalidOperationException($"You must set the name of the member before adding it to its parent.");
            }

            if (this.memberNames.Contains(name))
            {
                throw new InvalidOperationException($"A member with the name {name} already exists in {this.DotnetTypeName}.");
            }
        }
    }
}
