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
    using System.Collections.Generic;
    using System.Collections.Immutable;
    using System.Linq;
    using System.Text;
    using System.Text.Json;
    using System.Text.RegularExpressions;
    using Menes.Json;

    /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly struct Resource : IJsonObject<Resource>, IEquatable<Resource>
    {
        /// <summary>
        /// JSON property name for <see cref = "Links"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> LinksUtf8JsonPropertyName = new byte[]{95, 108, 105, 110, 107, 115};
        /// <summary>
        /// JSON property name for <see cref = "Links"/>.
        /// </summary>
        public static readonly string LinksJsonPropertyName = "_links";
        /// <summary>
        /// JSON property name for <see cref = "ContentType"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> ContentTypeUtf8JsonPropertyName = new byte[]{99, 111, 110, 116, 101, 110, 116, 84, 121, 112, 101};
        /// <summary>
        /// JSON property name for <see cref = "ContentType"/>.
        /// </summary>
        public static readonly string ContentTypeJsonPropertyName = "contentType";
        /// <summary>
        /// JSON property name for <see cref = "Embedded"/>.
        /// </summary>
        public static readonly ReadOnlyMemory<byte> EmbeddedUtf8JsonPropertyName = new byte[]{95, 101, 109, 98, 101, 100, 100, 101, 100};
        /// <summary>
        /// JSON property name for <see cref = "Embedded"/>.
        /// </summary>
        public static readonly string EmbeddedJsonPropertyName = "_embedded";
        private static readonly ImmutableDictionary<string, Func<Resource, ValidationContext, ValidationLevel, ValidationContext>> __MenesLocalProperties = CreateLocalPropertyValidators();
        private readonly JsonElement jsonElementBacking;
        private readonly ImmutableDictionary<string, JsonAny>? objectBacking;
        /// <summary>
        /// Initializes a new instance of the <see cref = "Resource"/> struct.
        /// </summary>
        /// <param name = "value">The backing <see cref = "JsonElement"/>.</param>
        public Resource(JsonElement value)
        {
            this.jsonElementBacking = value;
            this.objectBacking = default;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Resource"/> struct.
        /// </summary>
        /// <param name = "value">A property dictionary.</param>
        public Resource(ImmutableDictionary<string, JsonAny> value)
        {
            this.jsonElementBacking = default;
            this.objectBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref = "Resource"/> struct.
        /// </summary>
        /// <param name = "jsonObject">The <see cref = "JsonObject"/> from which to construct the value.</param>
        public Resource(JsonObject jsonObject)
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
        /// Gets Links.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Marain.LineOfBusiness.LinksProperty Links
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if (properties.TryGetValue(LinksJsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(LinksUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new Marain.LineOfBusiness.LinksProperty(result);
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets ContentType.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Menes.Json.JsonString ContentType
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if (properties.TryGetValue(ContentTypeJsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(ContentTypeUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new Menes.Json.JsonString(result);
                    }
                }

                return default;
            }
        }

        /// <summary>
        /// Gets Embedded.
        /// </summary>
        /// <remarks>
        /// {Property title}.
        /// {Property description}.
        /// </remarks>
        /// <example>
        /// {Property examples}.
        /// </example>
        public Marain.LineOfBusiness.EmbeddedProperty Embedded
        {
            get
            {
                if (this.objectBacking is ImmutableDictionary<string, JsonAny> properties)
                {
                    if (properties.TryGetValue(EmbeddedJsonPropertyName, out JsonAny result))
                    {
                        return result;
                    }
                }

                if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
                {
                    if (this.jsonElementBacking.TryGetProperty(EmbeddedUtf8JsonPropertyName.Span, out JsonElement result))
                    {
                        return new Marain.LineOfBusiness.EmbeddedProperty(result);
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
        public static implicit operator Resource(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new Resource(value.AsJsonElement);
            }

            return value.As<Resource>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator JsonAny(Resource value)
        {
            return value.AsAny;
        }

        /// <summary>
        /// Conversion from object.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Resource(JsonObject value)
        {
            return new Resource(value);
        }

        /// <summary>
        /// Conversion to object.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator JsonObject(Resource value)
        {
            return value.AsObject;
        }

        /// <summary>
        /// Implicit conversion to a property dictionary.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator ImmutableDictionary<string, JsonAny>(Resource value)
        {
            return value.AsObject.AsPropertyDictionary;
        }

        /// <summary>
        /// Implicit conversion from a property dictionary.
        /// </summary>
        /// <param name = "value">The value from which to convert.</param>
        public static implicit operator Resource(ImmutableDictionary<string, JsonAny> value)
        {
            return new Resource(value);
        }

        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name = "lhs">The left hand side of the comparison.</param>
        /// <param name = "rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(Resource lhs, Resource rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name = "lhs">The left hand side of the comparison.</param>
        /// <param name = "rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(Resource lhs, Resource rhs)
        {
            return !lhs.Equals(rhs);
        }

        /// <summary>
        /// Creates an instance of a <see cref = "Resource"/>.
        /// </summary>
        public static Resource Create(Marain.LineOfBusiness.LinksProperty links, Menes.Json.JsonString? contentType = null, Marain.LineOfBusiness.EmbeddedProperty? embedded = null)
        {
            var builder = ImmutableDictionary.CreateBuilder<string, JsonAny>();
            builder.Add(LinksJsonPropertyName, links);
            if (contentType is Menes.Json.JsonString contentType__)
            {
                builder.Add(ContentTypeJsonPropertyName, contentType__);
            }

            if (embedded is Marain.LineOfBusiness.EmbeddedProperty embedded__)
            {
                builder.Add(EmbeddedJsonPropertyName, embedded__);
            }

            return builder.ToImmutable();
        }

        /// <summary>
        /// Sets _links.
        /// </summary>
        /// <param name = "value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Resource WithLinks(Marain.LineOfBusiness.LinksProperty value)
        {
            return this.SetProperty(LinksJsonPropertyName, value);
        }

        /// <summary>
        /// Sets contentType.
        /// </summary>
        /// <param name = "value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Resource WithContentType(Menes.Json.JsonString value)
        {
            return this.SetProperty(ContentTypeJsonPropertyName, value);
        }

        /// <summary>
        /// Sets _embedded.
        /// </summary>
        /// <param name = "value">The value to set.</param>
        /// <returns>The entity with the updated property.</returns>
        public Resource WithEmbedded(Marain.LineOfBusiness.EmbeddedProperty value)
        {
            return this.SetProperty(EmbeddedJsonPropertyName, value);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is Resource entity)
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
            JsonValueKind.Object => this.AsObject().GetHashCode(), JsonValueKind.Array => this.AsArray().GetHashCode(), JsonValueKind.Number => this.AsNumber().GetHashCode(), JsonValueKind.String => this.AsString().GetHashCode(), JsonValueKind.True or JsonValueKind.False => this.AsBoolean().GetHashCode(), JsonValueKind.Null => JsonNull.NullHashCode, _ => 0, }

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
            JsonValueKind.Object => this.AsObject().Equals(other.AsObject()), JsonValueKind.Array => this.AsArray().Equals(other.AsArray()), JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()), JsonValueKind.String => this.AsString().Equals(other.AsString()), JsonValueKind.Null => true, JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()), _ => false, }

            ;
        }

        /// <inheritdoc/>
        public bool Equals(Resource other)
        {
            JsonValueKind valueKind = this.ValueKind;
            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
            JsonValueKind.Object => this.AsObject().Equals(other.AsObject()), JsonValueKind.Array => this.AsArray().Equals(other.AsArray()), JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()), JsonValueKind.String => this.AsString().Equals(other.AsString()), JsonValueKind.Null => true, JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()), _ => false, }

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
                return properties.TryGetValue(Encoding.UTF8.GetString(utf8name), out _);
            }

            if (this.jsonElementBacking.ValueKind == JsonValueKind.Object)
            {
                return this.jsonElementBacking.TryGetProperty(utf8name, out JsonElement _);
            }

            return false;
        }

        /// <inheritdoc/>
        public Resource SetProperty<TValue>(string name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Resource SetProperty<TValue>(ReadOnlySpan<char> name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Resource SetProperty<TValue>(ReadOnlySpan<byte> utf8name, TValue value)
            where TValue : IJsonValue
        {
            if (this.ValueKind == JsonValueKind.Object || this.ValueKind == JsonValueKind.Undefined)
            {
                return this.AsObject.SetProperty(utf8name, value);
            }

            return this;
        }

        /// <inheritdoc/>
        public Resource RemoveProperty(string name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public Resource RemoveProperty(ReadOnlySpan<char> name)
        {
            if (this.ValueKind == JsonValueKind.Object)
            {
                return this.AsObject.RemoveProperty(name);
            }

            return this;
        }

        /// <inheritdoc/>
        public Resource RemoveProperty(ReadOnlySpan<byte> utf8Name)
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
            return this.As<Resource, T>();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;
            if (level != ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }

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

        private static ImmutableDictionary<string, Func<Resource, ValidationContext, ValidationLevel, ValidationContext>> CreateLocalPropertyValidators()
        {
            ImmutableDictionary<string, Func<Resource, ValidationContext, ValidationLevel, ValidationContext>>.Builder builder = ImmutableDictionary.CreateBuilder<string, Func<Resource, ValidationContext, ValidationLevel, ValidationContext>>();
            builder.Add(LinksJsonPropertyName, (that, validationContext, level) =>
            {
                Marain.LineOfBusiness.LinksProperty property = that.Links;
                return property.Validate(validationContext, level);
            });
            builder.Add(ContentTypeJsonPropertyName, (that, validationContext, level) =>
            {
                Menes.Json.JsonString property = that.ContentType;
                return property.Validate(validationContext, level);
            });
            builder.Add(EmbeddedJsonPropertyName, (that, validationContext, level) =>
            {
                Marain.LineOfBusiness.EmbeddedProperty property = that.Embedded;
                return property.Validate(validationContext, level);
            });
            return builder.ToImmutable();
        }

        private ValidationContext ValidateObject(JsonValueKind valueKind, in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;
            if (valueKind != JsonValueKind.Object)
            {
                return result;
            }

            bool foundLinks = false;
            foreach (Property property in this.EnumerateObject())
            {
                string propertyName = property.Name;
                if (__MenesLocalProperties.TryGetValue(propertyName, out Func<Resource, ValidationContext, ValidationLevel, ValidationContext>? propertyValidator))
                {
                    result = result.WithLocalProperty(propertyName);
                    var propertyResult = propertyValidator(this, result, level);
                    result = result.MergeResults(propertyResult.IsValid, level, propertyResult);
                    if (level == ValidationLevel.Flag && !result.IsValid)
                    {
                        return result;
                    }

                    if (LinksJsonPropertyName.Equals(propertyName))
                    {
                        foundLinks = true;
                    }
                }
            }

            if (!foundLinks)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: false, $"6.5.3. required - required property \"_links\" not present.");
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