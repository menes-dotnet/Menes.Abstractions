
    //------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

#nullable enable

namespace OneOfDraft201909Feature.OneOf
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
        /// Initializes a new instance of the <see cref="Schema"/> struct.
        /// </summary>
        /// <param name="conversion">The <see cref="OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity"/> from which to construct the value.</param>
        public Schema(OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity conversion)
        {
            if (conversion.HasJsonElement)
            {
                this.jsonElementBacking = conversion.AsJsonElement;
                
                                this.numberBacking = default;
                            }
            else
            {
                this.jsonElementBacking = default;
                
                                if (conversion.ValueKind == JsonValueKind.Number)
                {
                    this.numberBacking = conversion;
                }
                else
                {
                    this.numberBacking = default;
                }
                            }
        }
    

    
            /// <summary>
        /// Gets the value as a <see cref="OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity" />.
        /// </summary>
        public OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity AsOneOf1Entity
        {
            get
            {
                return this;
            }
        }

        /// <summary>
        /// Gets a value indicating whether this is a valid <see cref="OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity" />.
        /// </summary>
        public bool IsOneOf1Entity
        {
            get
            {
                return ((OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity)this).Validate().IsValid;
            }
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
                    if (this.numberBacking is double numberBacking)
                {
                    return new JsonNumber(numberBacking);
                }

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
        /// Conversion from <see cref="OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator Schema(OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity value)
        {
            return new Schema(value);
        }

        /// <summary>
        /// Conversion to <see cref="OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity" />.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity(Schema value)
        {
                                                    if (value.ValueKind == JsonValueKind.Number)
            {
                return new OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity(value.AsNumber);
            }
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

                        
        
        
    
    
    
    
    
        
    
    
    
    
    
                result = this.ValidateOneOf(result, level);
            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

    
    

                return result;
        }

    
    
    
    
    
    
    
    
            
        private ValidationContext ValidateOneOf(in ValidationContext validationContext, ValidationLevel level)
        {
            ValidationContext result = validationContext;

            int oneOfCount = 0;

                

            ValidationContext oneOfResult0 = this.As<Menes.Json.JsonInteger>().Validate(validationContext.CreateChildContext(), level);

            if (oneOfResult0.IsValid)
            {
                result = result.MergeChildContext(oneOfResult0, level >= ValidationLevel.Detailed);
                oneOfCount += 1;
                            if (oneOfCount > 1 && level == ValidationLevel.Flag)
                {
                    result = result.WithResult(isValid: false);
                    return result;
                }
                        }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.MergeResults(result.IsValid, level, oneOfResult0);
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeResults(result.IsValid, level, oneOfResult0);
                }
                else
                {
                    result = result.MergeResults(result.IsValid, level, oneOfResult0);
                }
            }

                

            ValidationContext oneOfResult1 = this.As<OneOfDraft201909Feature.OneOf.Schema.OneOf1Entity>().Validate(validationContext.CreateChildContext(), level);

            if (oneOfResult1.IsValid)
            {
                result = result.MergeChildContext(oneOfResult1, level >= ValidationLevel.Detailed);
                oneOfCount += 1;
                            if (oneOfCount > 1 && level == ValidationLevel.Flag)
                {
                    result = result.WithResult(isValid: false);
                    return result;
                }
                        }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.MergeResults(result.IsValid, level, oneOfResult1);
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.MergeResults(result.IsValid, level, oneOfResult1);
                }
                else
                {
                    result = result.MergeResults(result.IsValid, level, oneOfResult1);
                }
            }

        
            if (oneOfCount == 1)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: true, "Validation 10.2.1.3. onef - validated against the oneOf schema.");
                }
            }
            else if (oneOfCount == 0)
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.3. oneOf - failed to validate against any of the oneOf schema.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.3. oneOf - failed to validate against any of the oneOf schema.");
                }
                else
                {
                    result = result.WithResult(isValid: false);
                }
            }
            else
            {
                if (level >= ValidationLevel.Detailed)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.3. oneOf - validated against more than one of the oneOf schema.");
                }
                else if (level >= ValidationLevel.Basic)
                {
                    result = result.WithResult(isValid: false, "Validation 10.2.1.3. oneOf - failed to validate against more than one of the oneOf schema.");
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
    public readonly struct OneOf1Entity :
                    IJsonValue,
            IEquatable<OneOf1Entity>
    {

        
    
    
    
    
    
    
    

    
        private readonly JsonElement jsonElementBacking;

    
    
            private readonly double? numberBacking;
    
    
    
        /// <summary>
        /// Initializes a new instance of the <see cref="OneOf1Entity"/> struct.
        /// </summary>
        /// <param name="value">The backing <see cref="JsonElement"/>.</param>
        public OneOf1Entity(JsonElement value)
        {
            this.jsonElementBacking = value;
                        this.numberBacking = default;
                    }

    
    
            /// <summary>
        /// Initializes a new instance of the <see cref="OneOf1Entity"/> struct.
        /// </summary>
        /// <param name="jsonNumber">The <see cref="JsonNumber"/> from which to construct the value.</param>
        public OneOf1Entity(JsonNumber jsonNumber)
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
        /// Initializes a new instance of the <see cref="OneOf1Entity"/> struct.
        /// </summary>
        /// <param name="value">A number value.</param>
        public OneOf1Entity(double value)
        {
            this.jsonElementBacking = default;
                                            this.numberBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOf1Entity"/> struct.
        /// </summary>
        /// <param name="value">A number value.</param>
        public OneOf1Entity(int value)
        {
            this.jsonElementBacking = default;
                                            this.numberBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOf1Entity"/> struct.
        /// </summary>
        /// <param name="value">A number value.</param>
        public OneOf1Entity(float value)
        {
            this.jsonElementBacking = default;
                                            this.numberBacking = value;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OneOf1Entity"/> struct.
        /// </summary>
        /// <param name="value">A number value.</param>
        public OneOf1Entity(long value)
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
                    if (this.numberBacking is double numberBacking)
                {
                    return new JsonNumber(numberBacking);
                }

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
        public static implicit operator OneOf1Entity(JsonAny value)
        {
            if (value.HasJsonElement)
            {
                return new OneOf1Entity(value.AsJsonElement);
            }

            return value.As<OneOf1Entity>();
        }

        /// <summary>
        /// Conversion to any.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator JsonAny(OneOf1Entity value)
        {
            return value.AsAny;
        }

    
    
    
    
        /// <summary>
        /// Conversion from double.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator OneOf1Entity(double value)
        {
            return new OneOf1Entity(value);
        }

        /// <summary>
        /// Conversion to double.
        /// </summary>
        /// <param name="number">The number from which to convert.</param>
        public static implicit operator double(OneOf1Entity number)
        {
            return number.AsNumber.GetDouble();
        }

        /// <summary>
        /// Conversion from float.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator OneOf1Entity(float value)
        {
            return new OneOf1Entity(value);
        }

        /// <summary>
        /// Conversion to float.
        /// </summary>
        /// <param name="number">The number from which to convert.</param>
        public static implicit operator float(OneOf1Entity number)
        {
            return number.AsNumber.GetSingle();
        }

        /// <summary>
        /// Conversion from long.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator OneOf1Entity(long value)
        {
            return new OneOf1Entity(value);
        }

        /// <summary>
        /// Conversion to long.
        /// </summary>
        /// <param name="number">The number from which to convert.</param>
        public static implicit operator long(OneOf1Entity number)
        {
            return number.AsNumber.GetInt64();
        }

        /// <summary>
        /// Conversion from int.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator OneOf1Entity(int value)
        {
            return new OneOf1Entity(value);
        }

        /// <summary>
        /// Conversion to int.
        /// </summary>
        /// <param name="number">The number from which to convert.</param>
        public static implicit operator int(OneOf1Entity number)
        {
            return number.AsNumber.GetInt32();
        }

        /// <summary>
        /// Conversion from number.
        /// </summary>
        /// <param name="value">The value from which to convert.</param>
        public static implicit operator OneOf1Entity(JsonNumber value)
        {
            return new OneOf1Entity(value);
        }

        /// <summary>
        /// Conversion to number.
        /// </summary>
        /// <param name="number">The value from which to convert.</param>
        public static implicit operator JsonNumber(OneOf1Entity number)
        {
            return number.AsNumber;
        }

    
    
        /// <summary>
        /// Standard equality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are equal.</returns>
        public static bool operator ==(OneOf1Entity lhs, OneOf1Entity rhs)
        {
            return lhs.Equals(rhs);
        }

        /// <summary>
        /// Standard inequality operator.
        /// </summary>
        /// <param name="lhs">The left hand side of the comparison.</param>
        /// <param name="rhs">The right hand side of the comparison.</param>
        /// <returns>True if they are not equal.</returns>
        public static bool operator !=(OneOf1Entity lhs, OneOf1Entity rhs)
        {
            return !lhs.Equals(rhs);
        }

    
    
        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            if (obj is OneOf1Entity entity)
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
        public bool Equals(OneOf1Entity other)
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
            return this.As<OneOf1Entity, T>();
        }

        /// <inheritdoc/>
        public ValidationContext Validate(in ValidationContext? validationContext = null, ValidationLevel level = ValidationLevel.Flag)
        {
            ValidationContext result = validationContext ?? ValidationContext.ValidContext;
            if (level != ValidationLevel.Flag)
            {
                result = result.UsingStack();
            }

                        
        
        
    
    
    
    
    
                result = Menes.Json.Validate.ValidateNumber(
                this,
                result,
                level,
                        null,
                                null,
                                null,
                                 2,
                                null
                        );

            if (level == ValidationLevel.Flag && !result.IsValid)
            {
                return result;
            }

        
    
    
    
    
    
    
    

                return result;
        }

    
    
    
    
    
    
    
    
            

            

            

            

    
    
    
    
    
    
    }
    

    
    }
    }
    