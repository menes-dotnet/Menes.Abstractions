// <copyright file="required000.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.Required000
{
public readonly struct Schema : Menes.IJsonObject, System.IEquatable<Schema>, Menes.IJsonAdditionalProperties<Menes.JsonAny>
{
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    private const string FooPropertyNamePath = ".foo";
    private const string BarPropertyNamePath = ".bar";
    private static readonly System.ReadOnlyMemory<byte> FooPropertyNameBytes = new byte[] { 102, 111, 111 };
    private static readonly System.ReadOnlyMemory<byte> BarPropertyNameBytes = new byte[] { 98, 97, 114 };
    private static readonly System.Text.Json.JsonEncodedText EncodedFooPropertyName = System.Text.Json.JsonEncodedText.Encode(FooPropertyNameBytes.Span);
    private static readonly System.Text.Json.JsonEncodedText EncodedBarPropertyName = System.Text.Json.JsonEncodedText.Encode(BarPropertyNameBytes.Span);
    private static readonly System.Collections.Immutable.ImmutableArray<System.ReadOnlyMemory<byte>> KnownProperties = System.Collections.Immutable.ImmutableArray.Create(FooPropertyNameBytes, BarPropertyNameBytes);
    private readonly Menes.JsonAny? foo;
    private readonly Menes.JsonAny? bar;
    private readonly Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking;
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.JsonElement = jsonElement;
        this.foo = null;
        this.bar = null;
        this.additionalPropertiesBacking = null;
    }
    public Schema(Menes.JsonAny foo)
    {
        this.foo = foo;
        this.bar = null;
        this.JsonElement = default;
        this.additionalPropertiesBacking = null;
    }
    public Schema(Menes.JsonAny foo, Menes.JsonAny? bar, Menes.JsonProperties<Menes.JsonAny> additionalPropertiesBacking)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public Schema(Menes.JsonAny foo, Menes.JsonAny? bar, params (string, Menes.JsonAny)[] additionalPropertiesBacking)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalPropertiesBacking);
    }
    public Schema(Menes.JsonAny foo, Menes.JsonAny? bar = null)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = null;
    }
    public Schema(Menes.JsonAny foo, Menes.JsonAny? bar, (string, Menes.JsonAny) additionalProperty1)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1);
    }
    public Schema(Menes.JsonAny foo, Menes.JsonAny? bar, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2);
    }
    public Schema(Menes.JsonAny foo, Menes.JsonAny? bar, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3);
    }
    public Schema(Menes.JsonAny foo, Menes.JsonAny? bar, (string, Menes.JsonAny) additionalProperty1, (string, Menes.JsonAny) additionalProperty2, (string, Menes.JsonAny) additionalProperty3, (string, Menes.JsonAny) additionalProperty4)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = Menes.JsonProperties<Menes.JsonAny>.FromValues(additionalProperty1, additionalProperty2, additionalProperty3, additionalProperty4);
    }
    private Schema(Menes.JsonAny foo, Menes.JsonAny? bar, Menes.JsonProperties<Menes.JsonAny>? additionalPropertiesBacking)
    {
        this.foo = foo;
        this.bar = bar;
        this.JsonElement = default;
        this.additionalPropertiesBacking = additionalPropertiesBacking;
    }
    public bool IsNull => (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null) && (this.foo is null || this.foo.Value.IsNull) && (this.bar is null || this.bar.Value.IsNull);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public Menes.JsonAny Foo => this.foo ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, FooPropertyNameBytes.Span);
    public Menes.JsonAny? Bar => this.bar ?? Menes.JsonAny.FromOptionalProperty(this.JsonElement, BarPropertyNameBytes.Span).AsOptional;
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
    public Schema WithFoo(Menes.JsonAny value)
    {
        return new Schema(value, this.Bar, this.GetJsonProperties());
    }
    public Schema WithBar(Menes.JsonAny? value)
    {
        return new Schema(this.Foo, value, this.GetJsonProperties());
    }
    public Schema ReplaceAll(Menes.JsonProperties<Menes.JsonAny> newAdditional)
    {
        return new Schema(this.Foo, this.Bar, newAdditional);
    }
    public Schema ReplaceAll(params (string, Menes.JsonAny)[] newAdditional)
    {
        return new Schema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional));
    }
    public Schema ReplaceAll((string, Menes.JsonAny) newAdditional1)
    {
        return new Schema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1));
    }
    public Schema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2)
    {
        return new Schema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2));
    }
    public Schema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3)
    {
        return new Schema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3));
    }
    public Schema ReplaceAll((string, Menes.JsonAny) newAdditional1, (string, Menes.JsonAny) newAdditional2, (string, Menes.JsonAny) newAdditional3, (string, Menes.JsonAny) newAdditional4)
    {
        return new Schema(this.Foo, this.Bar, Menes.JsonProperties<Menes.JsonAny>.FromValues(newAdditional1, newAdditional2, newAdditional3, newAdditional4));
    }
    public Schema Add(params (string, Menes.JsonAny)[] newAdditional)
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
        return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonAny value) newAdditional1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Add((string name, Menes.JsonAny value) newAdditional1, (string name, Menes.JsonAny value) newAdditional2, (string name, Menes.JsonAny value) newAdditional3, (string name, Menes.JsonAny value) newAdditional4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            arrayBuilder.Add(property);
        }
        arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional1.name, newAdditional1.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional2.name, newAdditional2.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional3.name, newAdditional3.value)); arrayBuilder.Add(Menes.JsonPropertyReference<Menes.JsonAny>.From(newAdditional4.name, newAdditional4.value)); return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(params string[] namesToRemove)
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
        return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1)
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
        return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1, string itemToRemove2)
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
        return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3)
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
        return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(string itemToRemove1, string itemToRemove2, string itemToRemove3, string itemToRemove4)
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
        return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
    }
    public Schema Remove(System.Predicate<Menes.JsonPropertyReference<Menes.JsonAny>> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonPropertyReference<Menes.JsonAny>>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonPropertyReference<Menes.JsonAny>>();
        foreach (Menes.JsonPropertyReference<Menes.JsonAny> property in this.JsonAdditionalProperties)
        {
            if (!removeIfTrue(property))
            {
                arrayBuilder.Add(property);
            }
        }
        return new Schema(this.Foo, this.Bar, new Menes.JsonProperties<Menes.JsonAny>(arrayBuilder.ToImmutable()));
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
            if (this.foo is Menes.JsonAny foo)
            {
                writer.WritePropertyName(EncodedFooPropertyName);
                foo.WriteTo(writer);
            }
            if (this.bar is Menes.JsonAny bar)
            {
                writer.WritePropertyName(EncodedBarPropertyName);
                bar.WriteTo(writer);
            }
            Menes.JsonProperties<Menes.JsonAny>.JsonPropertyEnumerator enumerator = this.JsonAdditionalProperties;
            while (enumerator.MoveNext())
            {
                enumerator.Current.Write(writer);
            }
            writer.WriteEndObject();
        }
    }
    public bool Equals(Schema other)
    {
        if ((this.IsNull && !other.IsNull) || (!this.IsNull && other.IsNull))
        {
            return false;
        }
        if (this.HasJsonElement && other.HasJsonElement)
        {
            return Menes.JsonAny.From(this).Equals(Menes.JsonAny.From(other));
        }
        return this.Foo.Equals(other.Foo) && this.Bar.Equals(other.Bar) && System.Linq.Enumerable.SequenceEqual(this.JsonAdditionalProperties, other.JsonAdditionalProperties);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        if (this.IsNull)
        {
            return validationContext.WithError($"6.1.1. type: the element with type {{this.JsonElement.ValueKind}} is not convertible to {{JsonValueKind.Object}}");
        }
        Menes.ValidationContext context = validationContext;
        context = Menes.Validation.ValidateRequiredProperty(context, this.Foo, FooPropertyNamePath);
        if (this.Bar is Menes.JsonAny bar)
        {
            context = Menes.Validation.ValidateProperty(context, bar, BarPropertyNamePath);
        }
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
}///  <summary>
/// required validation
/// </summary>
public static class Tests
{
/// <summary>
/// present required property is valid
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"foo\": 1}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Required000.Tests.Test0: present required property is valid");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// non-present required property is invalid
/// </summary>
    public static bool Test1()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("{\"bar\": 1}");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed Required000.Tests.Test1: non-present required property is invalid");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
/// <summary>
/// ignores arrays
/// </summary>
    public static bool Test2()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[]");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Required000.Tests.Test2: ignores arrays");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// ignores strings
/// </summary>
    public static bool Test3()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("\"\"");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Required000.Tests.Test3: ignores strings");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
/// <summary>
/// ignores other non-objects
/// </summary>
    public static bool Test4()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("12");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (!context.IsValid)
        {
            System.Console.WriteLine("Failed Required000.Tests.Test4: ignores other non-objects");
            System.Console.WriteLine("Expected: valid but was invalid");
            return false;
        }
            return true;
    }
}
}