//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
#nullable enable
namespace Marain.LineOfBusiness
{
    using System;
    using System.Collections.Immutable;
    using System.Text;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using Menes.Json;

    /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly struct LinksProperty : IJsonObject<LinksProperty>, IEquatable<LinksProperty>
    {
        /// <summary>
        /// JSON property name for <see cref = "Self"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> SelfUtf8JsonPropertyName = new byte[]{115, 101, 108, 102};
        /// <summary>
        /// JSON property name for <see cref = "Self"/>.
        /// </summary>
        public static readonly string SelfJsonPropertyName = "self";
        private static readonly ImmutableDictionary<string, PropertyValidator<LinksProperty>> __MenesLocalProperties = CreateLocalPropertyValidators();
        private readonly JsonElement jsonElementBacking;
        private readonly ImmutableDictionary<string, JsonAny>? objectBacking;
        /// <summary>
        /// Initializes a new instance of the <see cref = "LinksProperty"/> struct.
        /// </summary>
        /// <param name = "value">The backing <see cref = "JsonElement"/>.</param>
        public LinksProperty(JsonElement value)
        {
            this.jsonElementBacking = value;
            this.objectBacking = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "LinksProperty"/> struct.
        /// </summary>
        /// <param name = "value">A property dictionary.</param>
        public LinksProperty(ImmutableDictionary<string, JsonAny> value)
        {
            this.jsonElementBacking = default;
            this.objectBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "LinksProperty"/> struct.
        /// </summary>
        /// <param name = "jsonObject">The <see cref = "JsonObject"/> from which to construct the value.</param>
        public LinksProperty(JsonObject jsonObject)
        {
            if (jsonObject.HasJsonElement)
            {
                this.jsonElementBacking = jsonObject.AsJsonElement;
                this.objectBacking = default;
            }
            else
            {
                this.jsonElementBacking = default;
                this.objectBacking = jsonObject.AsPropertyDictionary;
            }
        }

        /// <summary>
        /// Gets Self.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Marain.LineOfBusiness.Link Self
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if (properties.TryGetValue(SelfJsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(SelfUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new Marain.LineOfBusiness.Link(result);
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is backed by a JSON element.
        /// </summary>
        public bool HasJsonElement => this.objectBacking is null;
        /// <summary>
        /// Gets the value as a JsonElement.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> objectBacking)
                {
                    return JsonObject.PropertiesToJsonElement(objectBacking);
                }

                return this.jsonElementBacking;
            }
        }

        /// <inheritdoc/>
        public JsonValueKind ValueKind
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny>)
                {
                    return JsonValueKind.Object;
                }

                return this.jsonElementBacking.ValueKind;
            }
        }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> objectBacking)
                {
                    return new JsonAny(objectBacking);
                }

                return new JsonAny(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Conversion from any.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinksProperty(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new LinksProperty(value.AsJsonElement);
            }

            return value.As<LinksProperty>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator JsonAny(LinksProperty value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Conversion from object.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinksProperty(JsonObject value)
        {
            return new LinksProperty(value);
        }

        /// <summary>
        /// Conversion to object.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator JsonObject(LinksProperty value)
        {
            return value.AsObject;
        }

        /// <summary>
        /// Implicit conversion to a property dictionary.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ImmutableDictionary<string, JsonAny>(LinksProperty value)
        {
            return value.AsObject.AsPropertyDictionary;
        }

        /// <summary>
        /// Implicit conversion from a property dictionary.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator LinksProperty(ImmutableDictionary<string, JsonAny> value)
        {
            return new LinksProperty(value);
        }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name = "lhs">The left hand side of the comparison.</param>
        /// <param name = "rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(LinksProperty lhs, LinksProperty rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name = "lhs">The left hand side of the comparison.</param>
        /// <param name = "rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(LinksProperty lhs, LinksProperty rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <summary>
        /// Creates an instance of a <see cref = "LinksProperty"/>.
        /// </summary>
        public static LinksProperty Create(Marain.LineOfBusiness.Link self)
        {
            var builder = ImmutableDictionary.CreateBuilder<string, JsonAny>();
            builder.Add(SelfJsonPropertyName, self);
            return builder.ToImmutable();
        }

        /// <summary>
        /// Sets self.
        /// </summary>
        /// <param name = "value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public LinksProperty WithSelf(Marain.LineOfBusiness.Link value)
        {
            return this.SetProperty(SelfJsonPropertyName, value);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is LinksProperty entity)
            {
                return this.Equals(entity);
            }

            return false;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            JsonValueKind valueKind = this.ValueKind;
            return valueKind switch
            {
            JsonValueKind.Object => this.AsObject.GetHashCode(), JsonValueKind.Array => this.AsArray().GetHashCode(), JsonValueKind.Number => this.AsNumber().GetHashCode(), JsonValueKind.String => this.AsString().GetHashCode(), JsonValueKind.True or JsonValueKind.False => this.AsBoolean().GetHashCode(), JsonValueKind.Null => JsonNull.NullHashCode, _ => 0, }

            ;
        }

        /// <summary>
        /// Writes the object to the <see cref = "Utf8JsonWriter"/>.
        /// </summary>
        /// <param name = "writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> objectBacking)
            {
                JsonObject.WriteProperties(objectBacking, writer);
                return;
            }

            if (this.jsonElementBacking.ValueKind != JsonValueKind.Undefined)
            {
                this.jsonElementBacking.WriteTo(writer);
                return;
            }

            writer.WriteNullValue();
        }

        /// <summary>
        /// Enumerate the object as the given item type
        /// </summary>
        public JsonObjectEnumerator<Marain.LineOfBusiness.LinkProperty> EnumerateProperties()
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
            {
                return new JsonObjectEnumerator<Marain.LineOfBusiness.LinkProperty>(properties);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return new JsonObjectEnumerator<Marain.LineOfBusiness.LinkProperty>(this.jsonElementBacking);
            }

            return default;
        }

        /// <inheritdoc/>
        public JsonObjectEnumerator EnumerateObject()
        {
            return this.AsObject.EnumerateObject();
        }

        /// <inheritdoc/>
        public bool TryGetProperty(string name, out JsonAny value)
        {
            return this.AsObject.TryGetProperty(name, out value);
        }

        /// <inheritdoc/>
        public bool TryGetProperty(ReadOnlySpan<char> name, out JsonAny value)
        {
            return this.AsObject.TryGetProperty(name, out value);
        }

        /// <inheritdoc/>
        public bool TryGetProperty(ReadOnlySpan<byte> utf8name, out JsonAny value)
        {
            return this.AsObject.TryGetProperty(utf8name, out value);
        }

        /// <inheritdoc/>
        public bool Equals<T>(T other)
            where T : struct, IJsonValue
        {
            JsonValueKind valueKind = this.ValueKind;
            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
            JsonValueKind.Object => this.AsObject.Equals(other.AsObject()), JsonValueKind.Array => this.AsArray().Equals(other.AsArray()), JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()), JsonValueKind.String => this.AsString().Equals(other.AsString()), JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()), JsonValueKind.Null => true, _ => false, }

            ;
        }

        /// <inheritdoc/>
        public bool Equals(LinksProperty other)
        {
            JsonValueKind valueKind = this.ValueKind;
            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
            JsonValueKind.Object => this.AsObject.Equals(other.AsObject), JsonValueKind.Array => this.AsArray().Equals(other.AsArray()), JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()), JsonValueKind.String => this.AsString().Equals(other.AsString()), JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()), JsonValueKind.Null => true, _ => false, }

            ;
        }

        /// <inheritdoc/>
        public bool HasProperty(string name)
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
            {
                return properties.TryGetValue(name, out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(name.ToString(), out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<char> name)
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
            {
                return properties.TryGetValue(name.ToString(), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(name, out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public bool HasProperty(ReadOnlySpan<byte> utf8name)
        {
            if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
            {
                return properties.TryGetValue(System.Text.Encoding.UTF8.GetString(utf8name), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(utf8name, out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public LinksProperty SetProperty<TValue>(string name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinksProperty SetProperty<TValue>(ReadOnlySpan<char> name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinksProperty SetProperty<TValue>(ReadOnlySpan<byte> utf8name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(utf8name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinksProperty RemoveProperty(string name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinksProperty RemoveProperty(ReadOnlySpan<char> name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public LinksProperty RemoveProperty(ReadOnlySpan<byte> utf8Name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(utf8Name);
            }

            return this;
        }

        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.As<LinksProperty, T>();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;
            if (level != ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }

            result = result.UsingEvaluatedProperties();
            JsonValueKind valueKind = this.ValueKind;
            result = this.ValidateType(valueKind, result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

            result = this.ValidateObject(valueKind, result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

            return result;
        }

        /// <summary>
        /// Gets the value as a <see cref = "JsonObject"/>.
        /// </summary>
        private JsonObject AsObject
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> objectBacking)
                {
                    return new JsonObject(objectBacking);
                }

                return new JsonObject(this.jsonElementBacking);
            }
        }

        private static ImmutableDictionary<string, PropertyValidator<LinksProperty>> CreateLocalPropertyValidators()
        {
            ImmutableDictionary<string, PropertyValidator<LinksProperty>>.Builder builder = ImmutableDictionary.CreateBuilder<string, PropertyValidator<LinksProperty>>();
            builder.Add(SelfJsonPropertyName, __MenesValidateSelf);
            return builder.ToImmutable();
        }

        private static ValidationContext __MenesValidateSelf(in LinksProperty that, in ValidationContext validationContext, ValidationLevel level)
        {
            Marain.LineOfBusiness.Link property = that.Self;
            return property.Validate(validationContext, level);
        }

        private ValidationContext ValidateObject(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;
            if (valueKind != JsonValueKind.Object)
            {
                return result;
            }

            int propertyCount = 0;
            bool foundSelf = false;
            foreach (Property property in this.EnumerateObject())
            {
                string propertyName = property.Name;
                if (__MenesLocalProperties.TryGetValue(propertyName, out PropertyValidator<LinksProperty>? propertyValidator))
                {
                    result = result.WithLocalProperty(propertyCount);
                    var propertyResult = propertyValidator(this, result.CreateChildContext(), level);
                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);
                    if (level == ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }

                    if (SelfJsonPropertyName.Equals(propertyName))
                    {
                        foundSelf = true;
                    }
                }

                if (!result.HasEvaluatedLocalProperty(propertyCount))
                {
                    result = property.ValueAs<Marain.LineOfBusiness.LinkProperty>().Validate(result, level);
                    if (level == ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }

                    result = result.WithLocalProperty(propertyCount);
                }

                propertyCount++;
            }

            if (!foundSelf)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: false, $"6.5.3. required - required property \"self\" not present.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "6.5.3. required - required property not present.");
                }
                else
                {
                    return result.WithResult(isValid: false);
                }
            }

            return result;
        }

        private ValidationContext ValidateType(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;
            bool isValid = false;
            ValidationContext localResultObject = Menes.Json.Validate.TypeObject(valueKind, result, level);
            if (level == ValidationLevel.Flag && localResultObject.IsValid)
            {
                return validationContext;
            }

            if (localResultObject.IsValid)
            {
                isValid = true;
            }

            result = result.MergeResults(isValid, level, localResultObject);
            return result;
        }
    }
}