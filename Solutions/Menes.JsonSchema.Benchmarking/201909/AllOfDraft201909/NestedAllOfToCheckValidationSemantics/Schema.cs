
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Immutable;
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
        /// <param name="conversion">The <see cref="AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity"/> from which to construct the value.</param>
        public Schema(AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity conversion)
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
        /// Gets the value as a <see cref="AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity" />.
        /// </summary>
        public AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity AsAllOf0Entity
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref="AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity" />.
        /// </summary>
        public bool IsAllOf0Entity
        {
            get
            {
                return ((AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity)this).Validate().IsValid;
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
        /// Conversion from <see cref="AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to <see cref="AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity(Schema value)
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
                    JsonValueKind.Object => this.AsObject().GetHashCode(),
                        JsonValueKind.Array => this.AsArray().GetHashCode(),
                        JsonValueKind.Number => this.AsNumber().GetHashCode(),
                        JsonValueKind.String => this.AsString().GetHashCode(),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().GetHashCode(),
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
                    JsonValueKind.Object => this.AsObject().Equals(other.AsObject()),
                        JsonValueKind.Array => this.AsArray().Equals(other.AsArray()),
                        JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()),
                        JsonValueKind.String => this.AsString().Equals(other.AsString()),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
                    JsonValueKind.Null => true,
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
                                JsonValueKind.Object => this.AsObject().Equals(other.AsObject()),
                        JsonValueKind.Array => this.AsArray().Equals(other.AsArray()),
                        JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()),
                        JsonValueKind.String => this.AsString().Equals(other.AsString()),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
                    JsonValueKind.Null => true,
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

                        
        
        
    
    
    
    
    
        
    
    
    
                result = this.ValidateAllOf(result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }
    
    
    
    

                return result;
        }


    
    
    
    
    
    
    
    
    
    
    
    
    
            

            

            
        private ValidationContext ValidateAllOf(in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;

                

            ValidationContext allOfResult0 = this.As<AllOfDraft201909Feature.NestedAllOfToCheckValidationSemantics.Schema.AllOf0Entity>().Validate(validationContext.CreateChildContext(), level);

            if (!allOfResult0.IsValid)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.MergeChildContext(allOfResult0, true).WithResult(isValid: false, "Validation 10.2.1.1. allOf - failed to validate against the allOf schema.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeChildContext(allOfResult0, true).WithResult(isValid: false, "Validation 10.2.1.1. allOf - failed to validate against the allOf schema.");
                }
                else
                {
                    result = result.MergeChildContext(allOfResult0, false).WithResult(isValid: false);
                    return result;
                }
            }
            else
            {
                result = result.MergeChildContext(allOfResult0, level >= ValidationLevel.Detailed);
            }

        
            return result;
        }

            

            

    
    
    
    
    
    
    
        /// <summary>
    /// A type generated from a JsonSchema specification.
    /// </summary>
    public readonly struct AllOf0Entity :
                    IJsonValue,
            IEquatable<AllOf0Entity>
    {

        
    
    
    
    
    
    
    

    
        private readonly JsonElement jsonElementBacking;

    
    
    
    
    
        /// <summary>
        /// Initializes a new instance of the <see cref="AllOf0Entity"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public AllOf0Entity(JsonElement value)
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
        /// Conversion from any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator AllOf0Entity(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new AllOf0Entity(value.AsJsonElement);
            }

            return value.As<AllOf0Entity>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(AllOf0Entity value)
        {
            return value.AsAny;
        }

    
    
    
    
    
        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(AllOf0Entity lhs, AllOf0Entity rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(AllOf0Entity lhs, AllOf0Entity rhs)
        {
            return !lhs.Equals(rhs);
        }

    
    
        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is AllOf0Entity entity)
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
                    JsonValueKind.Object => this.AsObject().GetHashCode(),
                        JsonValueKind.Array => this.AsArray().GetHashCode(),
                        JsonValueKind.Number => this.AsNumber().GetHashCode(),
                        JsonValueKind.String => this.AsString().GetHashCode(),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().GetHashCode(),
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
                    JsonValueKind.Object => this.AsObject().Equals(other.AsObject()),
                        JsonValueKind.Array => this.AsArray().Equals(other.AsArray()),
                        JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()),
                        JsonValueKind.String => this.AsString().Equals(other.AsString()),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
                    JsonValueKind.Null => true,
                _ => false,
            };
        }

        /// <inheritdoc/>
        public bool Equals(AllOf0Entity other)
        {
            JsonValueKind valueKind = this.ValueKind;

            if (other.ValueKind != valueKind)
            {
                return false;
            }

            return valueKind switch
            {
                                JsonValueKind.Object => this.AsObject().Equals(other.AsObject()),
                        JsonValueKind.Array => this.AsArray().Equals(other.AsArray()),
                        JsonValueKind.Number => this.AsNumber().Equals(other.AsNumber()),
                        JsonValueKind.String => this.AsString().Equals(other.AsString()),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
                    JsonValueKind.Null => true,
                _ => false,
            };
        }

    
    
        /// <inheritdoc/>
        public T As<T>()
            where T : struct, IJsonValue
        {
            return this.As<AllOf0Entity, T>();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;
            if (level != ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }

                        
        
        
    
    
    
    
    
        
    
    
    
                result = this.ValidateAllOf(result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }
    
    
    
    

                return result;
        }


    
    
    
    
    
    
    
    
    
    
    
    
    
            

            

            
        private ValidationContext ValidateAllOf(in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;

                

            ValidationContext allOfResult0 = this.As<Menes.Json.JsonNull>().Validate(validationContext.CreateChildContext(), level);

            if (!allOfResult0.IsValid)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.MergeChildContext(allOfResult0, true).WithResult(isValid: false, "Validation 10.2.1.1. allOf - failed to validate against the allOf schema.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeChildContext(allOfResult0, true).WithResult(isValid: false, "Validation 10.2.1.1. allOf - failed to validate against the allOf schema.");
                }
                else
                {
                    result = result.MergeChildContext(allOfResult0, false).WithResult(isValid: false);
                    return result;
                }
            }
            else
            {
                result = result.MergeChildContext(allOfResult0, level >= ValidationLevel.Detailed);
            }

        
            return result;
        }

            

            

    
    
    
    
    
    
    }
    

    
    }
    }
    