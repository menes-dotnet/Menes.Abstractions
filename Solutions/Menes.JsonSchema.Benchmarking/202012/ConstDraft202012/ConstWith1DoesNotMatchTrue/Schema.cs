
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace ConstDraft202012Feature.ConstWith1DoesNotMatchTrue
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

        
    
            private static readonly Schema __MenesConstValue = JsonAny.Parse("1");
    
    
    
    
    
    

    
        private readonly JsonElement jsonElementBacking;

    
    
            private readonly double? numberBacking;
    
    
    
        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public Schema(JsonElement value)
        {
            this.jsonElementBacking = value;
                        this.numberBacking = default;
                    }

    
    
            /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="jsonNumber">The <see cref="JsonNumber"/> from which to construct the value.</param>
        public Schema(JsonNumber jsonNumber)
        {
            if (jsonNumber.HasJsonElement)
            {
                this.jsonElementBacking = jsonNumber.AsJsonElement;
                this.numberBacking = default;
            }
            else
            {
                this.jsonElementBacking = default;
                this.numberBacking = jsonNumber.GetDouble();
            }
                                        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="value">A number value.</param>
        public Schema(double value)
        {
            this.jsonElementBacking = default;
                                            this.numberBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="value">A number value.</param>
        public Schema(int value)
        {
            this.jsonElementBacking = default;
                                            this.numberBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="value">A number value.</param>
        public Schema(float value)
        {
            this.jsonElementBacking = default;
                                            this.numberBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="value">A number value.</param>
        public Schema(long value)
        {
            this.jsonElementBacking = default;
                                            this.numberBacking = value;
        }
    
    
    
    
    

    
    
    
            /// <summary>
        /// Gets a value indicating whether this is backed by a JSON element.
        /// </summary>
        public bool HasJsonElement =>
    
    
                            this.numberBacking is null
            
                ;

        /// <summary>
        /// Gets the value as a JsonElement.
        /// </summary>
        public JsonElement AsJsonElement
        {
            get
            {
    
    
                    if (this.numberBacking is double numberBacking)
                {
                    return JsonNumber.NumberToJsonElement(numberBacking);
                }

    
    
    
                return this.jsonElementBacking;
            }
        }

        /// <inheritdoc/>
        public JsonValueKind ValueKind
        {
            get
            {
    
    
                    if (this.numberBacking is double)
                {
                    return JsonValueKind.Number;
                }

    
    
    
                return this.jsonElementBacking.ValueKind;
            }
        }

        /// <inheritdoc/>
        public JsonAny AsAny
        {
            get
            {
    
    
                    if (this.numberBacking is double numberBacking)
                {
                    return new JsonAny(numberBacking);
                }

    
    
    
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
        /// Conversion from double.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(double value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to double.
        /// </summary>
        /// <param name="number">The number from which to convert.</param>
        public static implicit operator double(Schema number)
        {
            return number.AsNumber.GetDouble();
        }

        /// <summary>
        /// Conversion from float.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(float value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to float.
        /// </summary>
        /// <param name="number">The number from which to convert.</param>
        public static implicit operator float(Schema number)
        {
            return number.AsNumber.GetSingle();
        }

        /// <summary>
        /// Conversion from long.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(long value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to long.
        /// </summary>
        /// <param name="number">The number from which to convert.</param>
        public static implicit operator long(Schema number)
        {
            return number.AsNumber.GetInt64();
        }

        /// <summary>
        /// Conversion from int.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(int value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to int.
        /// </summary>
        /// <param name="number">The number from which to convert.</param>
        public static implicit operator int(Schema number)
        {
            return number.AsNumber.GetInt32();
        }

        /// <summary>
        /// Conversion from number.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(JsonNumber value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to number.
        /// </summary>
        /// <param name="number">The value from which to convert.</param>
        public static implicit operator JsonNumber(Schema number)
        {
            return number.AsNumber;
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
                        JsonValueKind.Number => this.AsNumber.GetHashCode(),
                        JsonValueKind.String => this.AsString().GetHashCode(),
                        JsonValueKind.True or JsonValueKind.False => this.AsBoolean().GetHashCode(),
                    JsonValueKind.Null => JsonNull.NullHashCode,
                _ => JsonAny.UndefinedHashCode,
            };
        }

        /// <summary>
        /// Writes the object to the <see cref="Utf8JsonWriter"/>.
        /// </summary>
        /// <param name="writer">The writer to which to write the object.</param>
        public void WriteTo(Utf8JsonWriter writer)
        {
    
    
                if (this.numberBacking is double numberBacking)
            {
                writer.WriteNumberValue(numberBacking);
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
                        JsonValueKind.Number => this.AsNumber.Equals(other.AsNumber()),
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
                        JsonValueKind.Number => this.AsNumber.Equals(other.AsNumber),
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
        
        

    
    
    
                result = Menes.Json.Validate.ValidateConst(this, result, level, __MenesConstValue);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

    
    
        
    
    
    
    
    
    
    

                return result;
        }

    
    
            /// <summary>
        /// Gets the value as a <see cref="JsonNumber"/>.
        /// </summary>
        private JsonNumber AsNumber
        {
            get
            {
                if (this.numberBacking is double numberBacking)
                {
                    return new JsonNumber(numberBacking);
                }

                return new JsonNumber(this.jsonElementBacking);
            }
        }
    
    
    
    
    
    
    
    
    
    
    
            

            

            

            

    
    
    
    
    
    
    }
    }
    