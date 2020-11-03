// <copyright file="unevaluatedProperties010.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.UnevaluatedProperties010
{
public readonly struct Schema : Menes.IJsonValue
{
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    private readonly Schema.SchemaValue? item1;
    public Schema(Schema.SchemaValue clrInstance)
    {
        if (clrInstance.HasJsonElement)
        {
            this.JsonElement = clrInstance.JsonElement;
            this.item1 = null;
        }
        else
        {
            this.item1 = clrInstance;
            this.JsonElement = default;
        }
    }
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.item1 = null;
        this.JsonElement = jsonElement;
    }
    public bool IsNull => this.item1 is null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public bool IsSchemaValue => this.item1 is Schema.SchemaValue || (Schema.SchemaValue.IsConvertibleFrom(this.JsonElement) && Schema.SchemaValue.FromJsonElement(this.JsonElement).Validate(Menes.ValidationContext.Root).IsValid);
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static explicit operator Schema.SchemaValue(Schema value) => value.AsSchemaValue();
    public static implicit operator Schema(Schema.SchemaValue value) => new Schema(value);
    public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null)
            : Null;
    public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null)
            : Null;
    public static Schema FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
       parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
            (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                ? new Schema(property)
                : Null)
            : Null;
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        if (Schema.SchemaValue.IsConvertibleFrom(jsonElement))
        {
            return true;
        }
        return false;
    }
    public Schema.SchemaValue AsSchemaValue() => this.item1 ?? new Schema.SchemaValue(this.JsonElement);
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.item1 is Schema.SchemaValue item1)
        {
            item1.WriteTo(writer);
        }
        else
        {
            this.JsonElement.WriteTo(writer);
        }
    }
    public override string ToString()
    {
        var builder = new System.Text.StringBuilder();
        if (this.IsSchemaValue)
        {
            builder.Append("{");
            builder.Append("SchemaValue");
            builder.Append(", ");
            builder.Append(this.AsSchemaValue().ToString());
            builder.AppendLine("}");
        }
        return builder.Length > 0 ? builder.ToString() : this.JsonElement.ToString();
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.ValidationContext validationContext1 = Menes.ValidationContext.Root.WithPath(validationContext.Path);
        if (this.IsSchemaValue)
        {
            validationContext1 = this.AsSchemaValue().Validate(validationContext1);
        }
        else
        {
            validationContext1 = validationContext1.WithError("The value is not convertible to a Schema.SchemaValue.");
        }
        return Menes.Validation.ValidateAnyOf(validationContext, validationContext1);
    }

    public readonly struct SchemaValue : Menes.IJsonObject, System.IEquatable<Schema.SchemaValue>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
    {
        public static readonly Schema.SchemaValue Null = new Schema.SchemaValue(default(System.Text.Json.JsonElement));
        public static readonly System.Func<System.Text.Json.JsonElement, Schema.SchemaValue> FromJsonElement = e => new Schema.SchemaValue(e);
        private const string BarPropertyNamePath = ".bar";
        private const string BazPropertyNamePath = ".baz";
        private const string QuuxPropertyNamePath = ".quux";
        private static readonly System.ReadOnlyMemory<byte> BarPropertyNameBytes = new byte[] { 98, 97, 114 };
        private static readonly System.ReadOnlyMemory<byte> BazPropertyNameBytes = new byte[] { 98, 97, 122 };
        private static readonly System.ReadOnlyMemory<byte> QuuxPropertyNameBytes = new byte[] { 113, 117, 117, 120 };
        private static readonly System.Text.Json.JsonEncodedText EncodedBarPropertyName = System.Text.Json.JsonEncodedText.Encode(BarPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedBazPropertyName = System.Text.Json.JsonEncodedText.Encode(BazPropertyNameBytes.Span);
        private static readonly System.Text.Json.JsonEncodedText EncodedQuuxPropertyName = System.Text.Json.JsonEncodedText.Encode(QuuxPropertyNameBytes.Span);
        private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(BarPropertyNameBytes, BazPropertyNameBytes, QuuxPropertyNameBytes);
        private readonly Schema.SchemaValue.BarValue? bar;
        private readonly Schema.BazValue? baz;
        private readonly Schema.QuuxValue? quux;
        private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
        public SchemaValue(System.Text.Json.JsonElement jsonElement)
        {
            this.JsonElement = jsonElement;
            this.bar = null;
            this.baz = null;
            this.quux = null;
            this.additionalPropertiesBacking = null;
        }
        public SchemaValue(Schema.SchemaValue.BarValue bar, Schema.BazValue baz, Schema.QuuxValue quux)
        {
            this.bar = bar;
            this.baz = baz;
            this.quux = quux;
            this.JsonElement = default;
            this.additionalPropertiesBacking = null;
        }
        public SchemaValue(Schema.SchemaValue.BarValue bar, Schema.BazValue baz, Schema.QuuxValue quux, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
        {
            this.bar = bar;
            this.baz = baz;
            this.quux = quux;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
        }
        public SchemaValue(Schema.SchemaValue.BarValue bar, Schema.BazValue baz, Schema.QuuxValue quux, (string, Menes.JsonAny) additionalProperty1)
        {
            this.bar = bar;
            this.baz = baz;
            this.quux = quux;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
        }
        public SchemaValue(Schema.SchemaValue.BarValue bar, Schema.BazValue baz, Schema.QuuxValue quux, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
        {
            this.bar = bar;
            this.baz = baz;
            this.quux = quux;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
        }
        public SchemaValue(Schema.SchemaValue.BarValue bar, Schema.BazValue baz, Schema.QuuxValue quux, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
        {
            this.bar = bar;
            this.baz = baz;
            this.quux = quux;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
        }
        public SchemaValue(Schema.SchemaValue.BarValue bar, Schema.BazValue baz, Schema.QuuxValue quux, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
        {
            this.bar = bar;
            this.baz = baz;
            this.quux = quux;
            this.JsonElement = default;
            this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
        }
        private SchemaValue(Schema.SchemaValue.BarValue bar, Schema.BazValue baz, Schema.QuuxValue quux, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
        {
            this.bar = bar;
            this.baz = baz;
            this.quux = quux;
            this.JsonElement = default;
            this.additionalPropertiesBacking = additionalPropertiesBacking;
        }
        public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.bar is null || this.bar.Value.IsNull) && (this.baz is null || this.baz.Value.IsNull) && (this.quux is null || this.quux.Value.IsNull);
        public Schema.SchemaValue? AsOptional => this.IsNull ? default(Schema.SchemaValue?) : this;
        public Schema.SchemaValue.BarValue Bar => this.bar ?? Schema.SchemaValue.BarValue.FromOptionalProperty(this.JsonElement, BarPropertyNameBytes.Span);
        public Schema.BazValue Baz => this.baz ?? Schema.BazValue.FromOptionalProperty(this.JsonElement, BazPropertyNameBytes.Span);
        public Schema.QuuxValue Quux => this.quux ?? Schema.QuuxValue.FromOptionalProperty(this.JsonElement, QuuxPropertyNameBytes.Span);
        public int PropertiesCount => KnownProperties.Length + this.JsonAdditionalPropertiesCount;
        public int JsonAdditionalPropertiesCount
        {
            get
            {
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                int count = 0;

                while (enumerator.MoveNext())
                {
                    count++;
                }

                return count;
            }
        }
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator JsonAdditionalProperties
        {
            get
            {
                if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> ap)
                {
                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(ap, KnownProperties);
                }

                if (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Object)
                {
                    return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(this.JsonElement, KnownProperties);
                }

                return new Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator(Menes.JsonProperties<Menes.JsonAny>.Empty, KnownProperties);
            }
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return jsonElement.ValueKind == System.Text.Json.JsonValueKind.Object || jsonElement.ValueKind == System.Text.Json.JsonValueKind.Null;
        }
        public static Schema.SchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.SchemaValue(property)
                    : Null)
                : Null;
        public static Schema.SchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.SchemaValue(property)
                    : Null)
                : Null;
        public static Schema.SchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Schema.SchemaValue(property)
                    : Null)
            : Null;
        public Schema.SchemaValue WithBar(Schema.SchemaValue.BarValue value)
        {
            return new Schema.SchemaValue(value, this.Baz, this.Quux, this.GetJsonProperties());
        }
        public Schema.SchemaValue WithBaz(Schema.BazValue value)
        {
            return new Schema.SchemaValue(this.Bar, value, this.Quux, this.GetJsonProperties());
        }
        public Schema.SchemaValue WithQuux(Schema.QuuxValue value)
        {
            return new Schema.SchemaValue(this.Bar, this.Baz, value, this.GetJsonProperties());
        }
        public Schema.SchemaValue ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
        {
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, newAdditional);
        }
        public Schema.SchemaValue ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
        {
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
        }
        public Schema.SchemaValue ReplaceAll((string, Menes.JsonAny) newAdditional1)
        {
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
        }
        public Schema.SchemaValue ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
        {
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
        }
        public Schema.SchemaValue ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
        {
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
        }
        public Schema.SchemaValue ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
        {
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
        }
        public Schema.SchemaValue Add(params (string, Menes.JsonAny)[] newAdditional)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            foreach ((string name, Menes.JsonAny value) in newAdditional)
            {
                arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(name, value));
            }
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Add((string name, Menes.JsonAny value) newAdditional1)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                arrayBuilder.Add(property);
            }
            arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Remove(params string[] namesToRemove)
        {
            System.Collections.Immutable.ImmutableHashSet<string> ihs = System.Collections.Immutable.ImmutableHashSet.Create<string>(namesToRemove);
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Remove(string itemToRemove1)
        {
            System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
            ihsBuilder.Add(itemToRemove1); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Remove(string itemToRemove1, string itemToRemove2)
        {
            System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
            ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
        {
            System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
            ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
        {
            System.Collections.Immutable.ImmutableHashSet<string>.Builder ihsBuilder = System.Collections.Immutable.ImmutableHashSet.CreateBuilder<string>();
            ihsBuilder.Add(itemToRemove1); ihsBuilder.Add(itemToRemove2); ihsBuilder.Add(itemToRemove3); ihsBuilder.Add(itemToRemove4); System.Collections.Immutable.ImmutableHashSet<string> ihs = ihsBuilder.ToImmutable();
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!ihs.Contains(property.Name))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public Schema.SchemaValue Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
        {
            System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (!removeIfTrue(property))
                {
                    arrayBuilder.Add(property);
                }
            }
            return new Schema.SchemaValue(this.Bar, this.Baz, this.Quux, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
        }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            else
            {
                writer.WriteStartObject();
                if (this.bar is Schema.SchemaValue.BarValue bar)
                {
                    writer.WritePropertyName(EncodedBarPropertyName);
                    bar.WriteTo(writer);
                }
                if (this.baz is Schema.BazValue baz)
                {
                    writer.WritePropertyName(EncodedBazPropertyName);
                    baz.WriteTo(writer);
                }
                if (this.quux is Schema.QuuxValue quux)
                {
                    writer.WritePropertyName(EncodedQuuxPropertyName);
                    quux.WriteTo(writer);
                }
                Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
                while (enumerator.MoveNext())
                {
                    enumerator.Current.Write(writer);
                }
                writer.WriteEndObject();
            }
        }
        public bool Equals(Schema.SchemaValue other)
        {
            if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
            {
                return false;
            }
            if (this.HasJsonElement && other.HasJsonElement)
            {
                return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
            }
            return this.Bar.Equals(other.Bar) && this.Baz.Equals(other.Baz) && this.Quux.Equals(other.Quux) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            if (this.IsNull)
            {
                return validationContext.WithError($"6.1.1. type: the element with type {{this.JsonElement.ValueKind}} is not convertible to {{JsonValueKind.Object}}");
            }
            Menes.ValidationContext context = validationContext;
            context = Menes.Validation.ValidateRequiredProperty(context, this.Bar, BarPropertyNamePath);
            context = Menes.Validation.ValidateRequiredProperty(context, this.Baz, BazPropertyNamePath);
            context = Menes.Validation.ValidateRequiredProperty(context, this.Quux, QuuxPropertyNamePath);
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                string propertyName = property.Name;
                context = Menes.Validation.ValidateProperty(context, property.AsValue(), "." + property.Name);
            }
            return context;
        }
        public bool TryGet(string propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
        {
            return this.TryGet(System.MemoryExtensions.AsSpan(propertyName), out value);
        }
        public bool TryGet(System.ReadOnlySpan<byte> utf8PropertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
        {
            foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
            {
                if (property.NameEquals(utf8PropertyName))
                {
                    value = property.AsValue();
                    return true;
                }
            }
            value = default;
            return false;
        }
        public bool TryGet(System.ReadOnlySpan<char> propertyName, [System.Diagnostics.CodeAnalysis.NotNullWhen(true)] out Menes.JsonAny value)
        {
            System.Span<byte> bytes = stackalloc byte[propertyName.Length * 4];
            int written = System.Text.Encoding.UTF8.GetBytes(propertyName, bytes);
            return this.TryGet(bytes.Slice(0, written), out value);
        }
        public override string ToString()
        {
            return Menes.JsonAny.From(this).ToString();
        }
        private Menes.JsonProperties<Menes.JsonAny> GetJsonProperties()
        {
            if (this.additionalPropertiesBacking is Menes.JsonProperties<Menes.JsonAny> props)
            {
                return props;
            }
            return new Menes.JsonProperties<Menes.JsonAny>(System.Collections.Immutable.ImmutableArray.ToImmutableArray(this.JsonAdditionalProperties));
        }
        public readonly struct BarValue : Menes.IJsonValue, System.IEquatable<BarValue>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, BarValue> FromJsonElement = e => new BarValue(e);
            public static readonly BarValue Null = new BarValue(default(System.Text.Json.JsonElement));
            private static readonly Menes.JsonAny ConstValue = BuildConstValue();
            private readonly Menes.JsonAny? value;
            public BarValue(Menes.JsonAny value)
            {
                if (value.HasJsonElement)
                {
                    this.JsonElement = value.JsonElement;
                    this.value = null;
                }
                else
                {
                    this.value = value;
                    this.JsonElement = default;
                }
            }
            public BarValue(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public BarValue? AsOptional => this.IsNull ? default(BarValue?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator BarValue(Menes.JsonAny value)
            {
                return new BarValue(value);
            }
            public static implicit operator Menes.JsonAny(BarValue value)
            {
                if (value.value is Menes.JsonAny clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonAny(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonAny.IsConvertibleFrom(jsonElement);
            }
            public static BarValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new BarValue(property)
                        : Null)
                    : Null;
            public static BarValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new BarValue(property)
                        : Null)
                    : Null;
            public static BarValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new BarValue(property)
                        : Null)
                    : Null;
            public bool Equals(BarValue other)
            {
                return this.Equals((Menes.JsonAny)other);
            }
            public bool Equals(Menes.JsonAny other)
            {
                return ((Menes.JsonAny)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonAny value = this;
                Menes.ValidationContext context = validationContext;
                context = value.Validate(context);
                context = Menes.Validation.ValidateConst(context, value, ConstValue);
                return context;
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                else if (this.value is Menes.JsonAny clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public override string ToString()
            {
                if (this.value is Menes.JsonAny clrValue)
                {
                    return clrValue.ToString();
                }
                else
                {
                    return this.JsonElement.GetRawText();
                }
            }
            private static Menes.JsonAny BuildConstValue()
            {
                using var document = System.Text.Json.JsonDocument.Parse("\"bar\"");
                return new Menes.JsonAny(document.RootElement.Clone());
            }
        }
    }

    public readonly struct BazValue : Menes.IJsonValue, System.IEquatable<BazValue>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, BazValue> FromJsonElement = e => new BazValue(e);
        public static readonly BazValue Null = new BazValue(default(System.Text.Json.JsonElement));
        private static readonly Menes.JsonAny ConstValue = BuildConstValue();
        private readonly Menes.JsonAny? value;
        public BazValue(Menes.JsonAny value)
        {
            if (value.HasJsonElement)
            {
                this.JsonElement = value.JsonElement;
                this.value = null;
            }
            else
            {
                this.value = value;
                this.JsonElement = default;
            }
        }
        public BazValue(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public BazValue? AsOptional => this.IsNull ? default(BazValue?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator BazValue(Menes.JsonAny value)
        {
            return new BazValue(value);
        }
        public static implicit operator Menes.JsonAny(BazValue value)
        {
            if (value.value is Menes.JsonAny clrValue)
            {
                return clrValue;
            }
            return new Menes.JsonAny(value.JsonElement);
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return Menes.JsonAny.IsConvertibleFrom(jsonElement);
        }
        public static BazValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new BazValue(property)
                    : Null)
                : Null;
        public static BazValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new BazValue(property)
                    : Null)
                : Null;
        public static BazValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new BazValue(property)
                    : Null)
                : Null;
        public bool Equals(BazValue other)
        {
            return this.Equals((Menes.JsonAny)other);
        }
        public bool Equals(Menes.JsonAny other)
        {
            return ((Menes.JsonAny)this).Equals(other);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.JsonAny value = this;
            Menes.ValidationContext context = validationContext;
            context = value.Validate(context);
            context = Menes.Validation.ValidateConst(context, value, ConstValue);
            return context;
        }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            else if (this.value is Menes.JsonAny clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }
        public override string ToString()
        {
            if (this.value is Menes.JsonAny clrValue)
            {
                return clrValue.ToString();
            }
            else
            {
                return this.JsonElement.GetRawText();
            }
        }
        private static Menes.JsonAny BuildConstValue()
        {
            using var document = System.Text.Json.JsonDocument.Parse("\"baz\"");
            return new Menes.JsonAny(document.RootElement.Clone());
        }
    }
    public readonly struct QuuxValue : Menes.IJsonValue, System.IEquatable<QuuxValue>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, QuuxValue> FromJsonElement = e => new QuuxValue(e);
        public static readonly QuuxValue Null = new QuuxValue(default(System.Text.Json.JsonElement));
        private static readonly Menes.JsonAny ConstValue = BuildConstValue();
        private readonly Menes.JsonAny? value;
        public QuuxValue(Menes.JsonAny value)
        {
            if (value.HasJsonElement)
            {
                this.JsonElement = value.JsonElement;
                this.value = null;
            }
            else
            {
                this.value = value;
                this.JsonElement = default;
            }
        }
        public QuuxValue(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public QuuxValue? AsOptional => this.IsNull ? default(QuuxValue?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator QuuxValue(Menes.JsonAny value)
        {
            return new QuuxValue(value);
        }
        public static implicit operator Menes.JsonAny(QuuxValue value)
        {
            if (value.value is Menes.JsonAny clrValue)
            {
                return clrValue;
            }
            return new Menes.JsonAny(value.JsonElement);
        }
        public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
        {
            return Menes.JsonAny.IsConvertibleFrom(jsonElement);
        }
        public static QuuxValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new QuuxValue(property)
                    : Null)
                : Null;
        public static QuuxValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new QuuxValue(property)
                    : Null)
                : Null;
        public static QuuxValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new QuuxValue(property)
                    : Null)
                : Null;
        public bool Equals(QuuxValue other)
        {
            return this.Equals((Menes.JsonAny)other);
        }
        public bool Equals(Menes.JsonAny other)
        {
            return ((Menes.JsonAny)this).Equals(other);
        }
        public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
        {
            Menes.JsonAny value = this;
            Menes.ValidationContext context = validationContext;
            context = value.Validate(context);
            context = Menes.Validation.ValidateConst(context, value, ConstValue);
            return context;
        }
        public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
        {
            if (this.HasJsonElement)
            {
                this.JsonElement.WriteTo(writer);
            }
            else if (this.value is Menes.JsonAny clrValue)
            {
                clrValue.WriteTo(writer);
            }
        }
        public override string ToString()
        {
            if (this.value is Menes.JsonAny clrValue)
            {
                return clrValue.ToString();
            }
            else
            {
                return this.JsonElement.GetRawText();
            }
        }
        private static Menes.JsonAny BuildConstValue()
        {
            using var document = System.Text.Json.JsonDocument.Parse("\"quux\"");
            return new Menes.JsonAny(document.RootElement.Clone());
        }
    }
}
///  <summary>
/// unevaluatedProperties with anyOf
/// </summary>
public static class Tests
{
/// <summary>
/// when one matches and has no unevaluated properties
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"foo\": \"foo\",\r\n                    \"bar\": \"bar\"\r\n                }");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedProperties010.Tests.Test0: when one matches and has no unevaluated properties");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// when one matches and has unevaluated properties
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"foo\": \"foo\",\r\n                    \"bar\": \"bar\",\r\n                    \"baz\": \"not-baz\"\r\n                }");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedProperties010.Tests.Test1: when one matches and has unevaluated properties");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// when two match and has no unevaluated properties
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"foo\": \"foo\",\r\n                    \"bar\": \"bar\",\r\n                    \"baz\": \"baz\"\r\n                }");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedProperties010.Tests.Test2: when two match and has no unevaluated properties");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// when two match and has unevaluated properties
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\r\n                    \"foo\": \"foo\",\r\n                    \"bar\": \"bar\",\r\n                    \"baz\": \"baz\",\r\n                    \"quux\": \"not-quux\"\r\n                }");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedProperties010.Tests.Test3: when two match and has unevaluated properties");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}