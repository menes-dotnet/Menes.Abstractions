
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics
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
    public readonly struct Schema :
                    IJsonValue,
            IEquatable<Schema>
    {

        
    
    
    
    
    
    
    

    
        private readonly JsonElement jsonElementBacking;

    
    
    
    
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public Schema(JsonElement value)
        {
            this.jsonElementBacking = value;
                            }

    
    
    
    
    
    
            /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="conversion">The <see cref="AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity"/> from which to construct the value.</param>
        public Schema(AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity conversion)
        {
            if (conversion.HasJsonElement)
            {
                this.jsonElementBacking = conversion.AsJsonElement;
                
                                    }
            else
            {
                this.jsonElementBacking = default;
                
                                    }
        }
    

    
            /// <summary>
        /// Gets the value as a <see cref="AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity" />.
        /// </summary>
        public AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity AsAnyOf0Entity
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref="AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity" />.
        /// </summary>
        public bool IsAnyOf0Entity
        {
            get
            {
                return ((AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity)this).Validate().IsValid;
            }
        }

    
    
            /// <summary>
        /// Gets a value indicating whether this is backed by a JSON element.
        /// </summary>
        public bool HasJsonElement =>
    
    
                
        true
                ;

        /// <summary>
        /// Gets the value as a JsonElement.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
    
    
    
    
    
                return this.jsonElementBacking;
            }
        }

        /// <inheritdoc/>
        public JsonValueKind ValueKind
        {
            get
            {
    
    
    
    
    
                return this.jsonElementBacking.ValueKind;
            }
        }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
    
    
    
    
    
                return new JsonAny(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonObject"/>.
        /// </summary>
        public JsonObject AsObject
        {
            get
            {
    
                return new JsonObject(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonArray"/>.
        /// </summary>
        public JsonArray AsArray
        {
            get
            {
    
                return new JsonArray(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonNumber"/>.
        /// </summary>
        public JsonNumber AsNumber
        {
            get
            {
                    return new JsonNumber(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonString"/>.
        /// </summary>
        public JsonString AsString
        {
            get
            {
                    return new JsonString(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonBoolean"/>.
        /// </summary>
        public JsonBoolean AsBoolean
        {
            get
            {
                    return new JsonBoolean(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonNull"/>.
        /// </summary>
        public JsonNull AsNull
        {
            get
            {
                return default;
            }
        }

            /// <summary>
        /// Conversion from <see cref="AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to <see cref="AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity(Schema value)
        {
                                                    return default;
        }
    
        
        /// <summary>
        /// Conversion from any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new Schema(value.AsJsonElement);
            }

            return value.As<Schema>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(Schema value)
        {
            return value.AsAny;
        }

    
    
    
    
    
        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(Schema lhs, Schema rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(Schema lhs, Schema rhs)
        {
            return !lhs.Equals(rhs);
        }

    
    
        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is Schema entity)
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
                JsonValueKind.Object => this.AsObject.GetHashCode(),
                JsonValueKind.Array => this.AsArray.GetHashCode(),
                JsonValueKind.Number => this.AsNumber.GetHashCode(),
                JsonValueKind.String => this.AsString.GetHashCode(),
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.GetHashCode(),
                JsonValueKind.Null => JsonNull.NullHashCode,
                _ => 0,
            };
        }

        /// <summary>
        /// Writes the object to the <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
    
    
    
    
    
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Undefined)
            {
                this.jsonElementBacking.WriteTo(writer);
                return;
            }

            writer.WriteNullValue();
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
                JsonValueKind.Object => this.AsObject.Equals(other.AsObject()),
                JsonValueKind.Array => this.AsArray.Equals(other.AsArray()),
                JsonValueKind.Number => this.AsNumber.Equals(other.AsNumber()),
                JsonValueKind.String => this.AsString.Equals(other.AsString()),
                JsonValueKind.Null => true,
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.Equals(other.AsBoolean()),
                _ => false,
            };
        }

        /// <inheritdoc/>
        public bool Equals(Schema other)
        {
            JsonValueKind valueKind = this.ValueKind;

            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
                JsonValueKind.Object => this.AsObject.Equals(other.AsObject),
                JsonValueKind.Array => this.AsArray.Equals(other.AsArray),
                JsonValueKind.Number => this.AsNumber.Equals(other.AsNumber),
                JsonValueKind.String => this.AsString.Equals(other.AsString),
                JsonValueKind.Null => true,
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.Equals(other.AsBoolean),
                _ => false,
            };
        }

    
    
        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.As<Schema, T>();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;
            if (level != ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }
        
        

    
    
    
    
    
        
    
    
    
    
                result = this.ValidateAnyOf(result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }
    
    
    

                return result;
        }

    
    
    
    
    
    
    
    
            

            
        private ValidationContext ValidateAnyOf(in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;

            bool foundValid = false;

                

            ValidationContext anyOfResult0 = this.As<AnyOfDraft202012Feature.NestedAnyOfToCheckValidationSemantics.Schema.AnyOf0Entity>().Validate(validationContext.CreateChildContext(), level);

            if (anyOfResult0.IsValid)
            {
                result = result.MergeChildContext(anyOfResult0, level >= ValidationLevel.Detailed);
                            if (level == ValidationLevel.Flag)
                {
                    return result;
                }
                else
                {
                    foundValid = true;
                }
                        }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult0);
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult0);
                }
            }

        
            if (foundValid)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: true, "Validation 10.2.1.2. anyOf - validated against the anyOf schema.");
                }
            }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.2. anyOf - failed to validate against the anyOf schema.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.2. anyOf - failed to validate against the anyOf schema.");
                }
                else
                {
                    result = result.WithResult(isValid: false);
                }
            }

            return result;
        }

            

            

            

    
    
    
    
    
    
    
        /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly struct AnyOf0Entity :
                    IJsonValue,
            IEquatable<AnyOf0Entity>
    {

        
    
    
    
    
    
    
    

    
        private readonly JsonElement jsonElementBacking;

    
    
    
    
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AnyOf0Entity"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public AnyOf0Entity(JsonElement value)
        {
            this.jsonElementBacking = value;
                            }

    
    
    
    
    
    
    

    
    
    
            /// <summary>
        /// Gets a value indicating whether this is backed by a JSON element.
        /// </summary>
        public bool HasJsonElement =>
    
    
                
        true
                ;

        /// <summary>
        /// Gets the value as a JsonElement.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
    
    
    
    
    
                return this.jsonElementBacking;
            }
        }

        /// <inheritdoc/>
        public JsonValueKind ValueKind
        {
            get
            {
    
    
    
    
    
                return this.jsonElementBacking.ValueKind;
            }
        }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
    
    
    
    
    
                return new JsonAny(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonObject"/>.
        /// </summary>
        public JsonObject AsObject
        {
            get
            {
    
                return new JsonObject(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonArray"/>.
        /// </summary>
        public JsonArray AsArray
        {
            get
            {
    
                return new JsonArray(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonNumber"/>.
        /// </summary>
        public JsonNumber AsNumber
        {
            get
            {
                    return new JsonNumber(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonString"/>.
        /// </summary>
        public JsonString AsString
        {
            get
            {
                    return new JsonString(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonBoolean"/>.
        /// </summary>
        public JsonBoolean AsBoolean
        {
            get
            {
                    return new JsonBoolean(this.jsonElementBacking);
            }
        }

        /// <summary>
        /// Gets the value as a <see cref="JsonNull"/>.
        /// </summary>
        public JsonNull AsNull
        {
            get
            {
                return default;
            }
        }

    
        
        /// <summary>
        /// Conversion from any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator AnyOf0Entity(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new AnyOf0Entity(value.AsJsonElement);
            }

            return value.As<AnyOf0Entity>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(AnyOf0Entity value)
        {
            return value.AsAny;
        }

    
    
    
    
    
        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(AnyOf0Entity lhs, AnyOf0Entity rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(AnyOf0Entity lhs, AnyOf0Entity rhs)
        {
            return !lhs.Equals(rhs);
        }

    
    
        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is AnyOf0Entity entity)
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
                JsonValueKind.Object => this.AsObject.GetHashCode(),
                JsonValueKind.Array => this.AsArray.GetHashCode(),
                JsonValueKind.Number => this.AsNumber.GetHashCode(),
                JsonValueKind.String => this.AsString.GetHashCode(),
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.GetHashCode(),
                JsonValueKind.Null => JsonNull.NullHashCode,
                _ => 0,
            };
        }

        /// <summary>
        /// Writes the object to the <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
    
    
    
    
    
            if (this.jsonElementBacking.ValueKind != JsonValueKind.Undefined)
            {
                this.jsonElementBacking.WriteTo(writer);
                return;
            }

            writer.WriteNullValue();
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
                JsonValueKind.Object => this.AsObject.Equals(other.AsObject()),
                JsonValueKind.Array => this.AsArray.Equals(other.AsArray()),
                JsonValueKind.Number => this.AsNumber.Equals(other.AsNumber()),
                JsonValueKind.String => this.AsString.Equals(other.AsString()),
                JsonValueKind.Null => true,
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.Equals(other.AsBoolean()),
                _ => false,
            };
        }

        /// <inheritdoc/>
        public bool Equals(AnyOf0Entity other)
        {
            JsonValueKind valueKind = this.ValueKind;

            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
                JsonValueKind.Object => this.AsObject.Equals(other.AsObject),
                JsonValueKind.Array => this.AsArray.Equals(other.AsArray),
                JsonValueKind.Number => this.AsNumber.Equals(other.AsNumber),
                JsonValueKind.String => this.AsString.Equals(other.AsString),
                JsonValueKind.Null => true,
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean.Equals(other.AsBoolean),
                _ => false,
            };
        }

    
    
        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.As<AnyOf0Entity, T>();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;
            if (level != ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }
        
        

    
    
    
    
    
        
    
    
    
    
                result = this.ValidateAnyOf(result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }
    
    
    

                return result;
        }

    
    
    
    
    
    
    
    
            

            
        private ValidationContext ValidateAnyOf(in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;

            bool foundValid = false;

                

            ValidationContext anyOfResult0 = this.As<Menes.Json.JsonNull>().Validate(validationContext.CreateChildContext(), level);

            if (anyOfResult0.IsValid)
            {
                result = result.MergeChildContext(anyOfResult0, level >= ValidationLevel.Detailed);
                            if (level == ValidationLevel.Flag)
                {
                    return result;
                }
                else
                {
                    foundValid = true;
                }
                        }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult0);
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult0);
                }
            }

        
            if (foundValid)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: true, "Validation 10.2.1.2. anyOf - validated against the anyOf schema.");
                }
            }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.2. anyOf - failed to validate against the anyOf schema.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.2. anyOf - failed to validate against the anyOf schema.");
                }
                else
                {
                    result = result.WithResult(isValid: false);
                }
            }

            return result;
        }

            

            

            

    
    
    
    
    
    
    }
    

    
    }
    }
    