
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace NotDraft202012Feature.NotWithBooleanSchemaTrue
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
                JsonValueKind.Null => true,
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
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
                JsonValueKind.Null => true,
                JsonValueKind.True or JsonValueKind.False => this.AsBoolean().Equals(other.AsBoolean()),
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
        
        

    
    
    
    
    
        
    
    
                result = this.ValidateNot(result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

    
    
    
    
    

                return result;
        }

    
    
    
    
    
    
    
    
    
    
    
    
    
            

            

            

            
        private ValidationContext ValidateNot(ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;

            ValidationContext notResult = this.As<Menes.Json.JsonAny>().Validate(validationContext.CreateChildContext(), level);
            if (notResult.IsValid)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = validationContext.MergeResults(false, level, notResult).WithResult(isValid: false, "Validation 9.2.1.4. not - incorrectly validated successfully against the not schema.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = validationContext.MergeResults(false, level, notResult).WithResult(isValid: false, "Validation 9.2.1.4. not - incorrectly validated succesfully against the not schema.");
                }
                else
                {
                    result = validationContext.WithResult(isValid: false);
                }
            }
            else if (level >= ValidationLevel.Basic)
            {
                result = result.MergeResults(result.IsValid, level, notResult);
            }

            return result;
        }

            

    
    
    
    
    
    
    }
    }
    