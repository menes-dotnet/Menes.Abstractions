
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef
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
    public readonly struct SchemaJson :
                    IJsonValue,
            IEquatable<SchemaJson>
    {

        
    
    
    
    
    
    
    

    
        private readonly JsonElement jsonElementBacking;

    
    
    
    
    
        /// <summary>
        /// Initializes a new instance of the <see cref="SchemaJson"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public SchemaJson(JsonElement value)
        {
            this.jsonElementBacking = value;
                            }

    
    
    
    
    
    
            /// <summary>
        /// Initializes a new instance of the <see cref="SchemaJson"/> struct.
        /// </summary>
        /// <param name="conversion">The <see cref="RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson"/> from which to construct the value.</param>
        public SchemaJson(RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson conversion)
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
        /// Gets the value as a <see cref="RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson" />.
        /// </summary>
        public RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson AsMyobjectJson
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref="RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson" />.
        /// </summary>
        public bool IsMyobjectJson
        {
            get
            {
                return ((RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson)this).Validate().IsValid;
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
        /// Conversion from <see cref="RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator SchemaJson(RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson value)
        {
            return new SchemaJson(value);
        }

        /// <summary>
        /// Conversion to <see cref="RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson(SchemaJson value)
        {
                                                    return default;
        }
    
                /// <summary>
        /// Conversion from <see cref="RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson.AnyOf1Value" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator SchemaJson(RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson.AnyOf1Value value)
        {
            return (RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.SchemaJson)value;
        }

        /// <summary>
        /// Conversion to <see cref="RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson.AnyOf1Value" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson.AnyOf1Value(SchemaJson value)
        {
            return (RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.SchemaJson)value;
        }
    
        /// <summary>
        /// Conversion from any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator SchemaJson(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new SchemaJson(value.AsJsonElement);
            }

            return value.As<SchemaJson>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(SchemaJson value)
        {
            return value.AsAny;
        }

    
    
    
    
    
        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(SchemaJson lhs, SchemaJson rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(SchemaJson lhs, SchemaJson rhs)
        {
            return !lhs.Equals(rhs);
        }

    
    
        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is SchemaJson entity)
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
        public bool Equals(SchemaJson other)
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
            return this.As<SchemaJson, T>();
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

                

            ValidationContext anyOfResult0 = this.As<Menes.Json.JsonInteger>().Validate(validationContext.CreateChildContext(), level);

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

                

            ValidationContext anyOfResult1 = this.As<RecursiveRefDraft201909Feature.RecursiveRefWithRecursiveAnchorFalseWorksLikeRef.MyobjectJson>().Validate(validationContext.CreateChildContext(), level);

            if (anyOfResult1.IsValid)
            {
                result = result.MergeChildContext(anyOfResult1, level >= ValidationLevel.Detailed);
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
                    result = result.MergeResults(result.IsValid, level, anyOfResult1);
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeResults(result.IsValid, level, anyOfResult1);
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
    