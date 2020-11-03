// <copyright file="unevaluatedItems011.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
#pragma warning disable
namespace Menes.Json.Schema.Tests.UnevaluatedItems011
{
public readonly struct Schema : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<Schema>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
{
    public static readonly System.Func<System.Text.Json.JsonElement, Schema> FromJsonElement = e => new Schema(e);
    public static readonly Schema Null = new Schema(default(System.Text.Json.JsonElement));
    private readonly Menes.JsonArray<Menes.JsonAny>? value;
    public Schema(Menes.JsonArray<Menes.JsonAny> jsonArray)
    {
        if (jsonArray.HasJsonElement)
        {
            this.JsonElement = jsonArray.JsonElement;
            this.value = null;
        }
        else
        {
            this.value = jsonArray;
            this.JsonElement = default;
        }
    }
    public Schema(System.Text.Json.JsonElement jsonElement)
    {
        this.value = null;
        this.JsonElement = jsonElement;
    }
    public int Length
    {
        get
        {
            if (this.HasJsonElement)
            {
                return this.JsonElement.GetArrayLength();
            }
            if (this.value is Menes.JsonArray<Menes.JsonAny> value)
            {
                return value.Length;
            }
            return 0;
        }
    }
    public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
    public Schema? AsOptional => this.IsNull ? default(Schema?) : this;
    public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
    public System.Text.Json.JsonElement JsonElement { get; }
    public static implicit operator Schema(Menes.JsonArray<Menes.JsonAny> value)
    {
        return new Schema(value);
    }
    public static implicit operator Menes.JsonArray<Menes.JsonAny>(Schema value)
    {
        if (value.value is Menes.JsonArray<Menes.JsonAny> clrValue)
        {
            return clrValue;
        }
        return new Menes.JsonArray<Menes.JsonAny>(value.JsonElement);
    }
    public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
    {
        return Menes.JsonArray<Menes.JsonAny>.IsConvertibleFrom(jsonElement);
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
    public bool Equals(Schema other)
    {
        return this.Equals((Menes.JsonArray<Menes.JsonAny>)other);
    }
    public bool Equals(Menes.JsonArray<Menes.JsonAny> other)
    {
        return ((Menes.JsonArray<Menes.JsonAny>)this).Equals(other);
    }
    public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
    {
        Menes.JsonArray<Menes.JsonAny> array = this;
        Menes.ValidationContext context = validationContext;
        var newContext = array.Validate(context.ResetLastWasValid());
        if (!newContext.LastWasValid)
        {
            return newContext;
        }
        var itemsValidationEnumerator = array.GetEnumerator();
        if (itemsValidationEnumerator.MoveNext())
        {
            context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<Schema.Item1Value>(), $"[0]");
        }
        int extraIndex = 0;
        while (itemsValidationEnumerator.MoveNext())
        {
            context = Menes.Validation.ValidateProperty(context, Menes.JsonAny.From(itemsValidationEnumerator.Current).As<Menes.JsonAny>(), $"[{extraIndex + 1}]");
            extraIndex++;
        }
        return array.ValidateItems(context);
    }
    public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
    {
        if (this.HasJsonElement)
        {
            this.JsonElement.WriteTo(writer);
        }
        if (this.value is Menes.JsonArray<Menes.JsonAny> clrValue)
        {
            clrValue.WriteTo(writer);
        }
    }
    public Menes.JsonArray<Menes.JsonAny>.JsonArrayEnumerator GetEnumerator()
    {
        return ((Menes.JsonArray<Menes.JsonAny>)this).GetEnumerator();
    }
    System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
    public Schema Add(params Menes.JsonAny[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        foreach (Menes.JsonAny item in items)
        {
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Menes.JsonAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            arrayBuilder.Add(item);
        }
        arrayBuilder.Add(item1);
        arrayBuilder.Add(item2);
        arrayBuilder.Add(item3);
        arrayBuilder.Add(item4);
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, params Menes.JsonAny[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
        {
            if (index == indexToInsert)
            {
                foreach (Menes.JsonAny itemToInsert in items)
                {
                    arrayBuilder.Add(itemToInsert);
                }
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Menes.JsonAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
        {
            if (index == indexToInsert)
            {
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
            }
            arrayBuilder.Add(item);
            ++index;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(params Menes.JsonAny[] items)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            bool found = false;
            foreach (Menes.JsonAny itemToRemove in items)
            {
                if (itemToRemove.Equals(item))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                arrayBuilder.Add(item);
            }
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Menes.JsonAny item1)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            if (item1.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Menes.JsonAny item1, Menes.JsonAny item2)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            if (item1.Equals(item) || item2.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
            {
                break;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema RemoveAt(int indexToRemove)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
        {
            if (index == indexToRemove)
            {
                index++;
                continue;
            }
            arrayBuilder.Add(item);
            index++;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema RemoveRange(int startIndex, int length)
    {
        if (startIndex < 0 || startIndex > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(startIndex));
        }
        if (length < 1 || startIndex + length > this.Length - 1)
        {
            throw new System.ArgumentOutOfRangeException(nameof(length));
        }
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        int index = 0;
        foreach (Menes.JsonAny item in this)
        {
            if (index >= startIndex && index < startIndex + length)
            {
                index++;
                continue;
            }
            arrayBuilder.Add(item);
            index++;
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public Schema Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
    {
        System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
        foreach (Menes.JsonAny item in this)
        {
            if (removeIfTrue(item))
            {
                continue;
            }
            arrayBuilder.Add(item);
        }
        return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
    }
    public readonly struct SchemaValue : Menes.IJsonValue, System.IEquatable<SchemaValue>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, SchemaValue> FromJsonElement = e => new SchemaValue(e);
        public static readonly SchemaValue Null = new SchemaValue(default(System.Text.Json.JsonElement));
        private readonly Menes.JsonAny? value;
        public SchemaValue(Menes.JsonAny value)
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
        public SchemaValue(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public SchemaValue? AsOptional => this.IsNull ? default(SchemaValue?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator SchemaValue(Menes.JsonAny value)
        {
            return new SchemaValue(value);
        }
        public static implicit operator Menes.JsonAny(SchemaValue value)
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
        public static SchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaValue(property)
                    : Null)
                : Null;
        public static SchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaValue(property)
                    : Null)
                : Null;
        public static SchemaValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new SchemaValue(property)
                    : Null)
                : Null;
        public bool Equals(SchemaValue other)
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
            context = Menes.Validation.ValidateNot<Menes.JsonAny, Schema.SchemaValue.SchemaValueValue>(context, this);
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
        public readonly struct SchemaValueValue : Menes.IJsonValue, System.Collections.Generic.IEnumerable<Menes.JsonAny>, System.Collections.IEnumerable, System.IEquatable<SchemaValueValue>, System.IEquatable<Menes.JsonArray<Menes.JsonAny>>
        {
            public static readonly System.Func<System.Text.Json.JsonElement, SchemaValueValue> FromJsonElement = e => new SchemaValueValue(e);
            public static readonly SchemaValueValue Null = new SchemaValueValue(default(System.Text.Json.JsonElement));
            private readonly Menes.JsonArray<Menes.JsonAny>? value;
            public SchemaValueValue(Menes.JsonArray<Menes.JsonAny> jsonArray)
            {
                if (jsonArray.HasJsonElement)
                {
                    this.JsonElement = jsonArray.JsonElement;
                    this.value = null;
                }
                else
                {
                    this.value = jsonArray;
                    this.JsonElement = default;
                }
            }
            public SchemaValueValue(System.Text.Json.JsonElement jsonElement)
            {
                this.value = null;
                this.JsonElement = jsonElement;
            }
            public int Length
            {
                get
                {
                    if (this.HasJsonElement)
                    {
                        return this.JsonElement.GetArrayLength();
                    }
                    if (this.value is Menes.JsonArray<Menes.JsonAny> value)
                    {
                        return value.Length;
                    }
                    return 0;
                }
            }
            public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
            public SchemaValueValue? AsOptional => this.IsNull ? default(SchemaValueValue?) : this;
            public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
            public System.Text.Json.JsonElement JsonElement { get; }
            public static implicit operator SchemaValueValue(Menes.JsonArray<Menes.JsonAny> value)
            {
                return new SchemaValueValue(value);
            }
            public static implicit operator Menes.JsonArray<Menes.JsonAny>(SchemaValueValue value)
            {
                if (value.value is Menes.JsonArray<Menes.JsonAny> clrValue)
                {
                    return clrValue;
                }
                return new Menes.JsonArray<Menes.JsonAny>(value.JsonElement);
            }
            public static bool IsConvertibleFrom(System.Text.Json.JsonElement jsonElement)
            {
                return Menes.JsonArray<Menes.JsonAny>.IsConvertibleFrom(jsonElement);
            }
            public static SchemaValueValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaValueValue(property)
                        : Null)
                    : Null;
            public static SchemaValueValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaValueValue(property)
                        : Null)
                    : Null;
            public static SchemaValueValue FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
               parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                    (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                        ? new SchemaValueValue(property)
                        : Null)
                    : Null;
            public bool Equals(SchemaValueValue other)
            {
                return this.Equals((Menes.JsonArray<Menes.JsonAny>)other);
            }
            public bool Equals(Menes.JsonArray<Menes.JsonAny> other)
            {
                return ((Menes.JsonArray<Menes.JsonAny>)this).Equals(other);
            }
            public Menes.ValidationContext Validate(in Menes.ValidationContext validationContext)
            {
                Menes.JsonArray<Menes.JsonAny> array = this;
                Menes.ValidationContext context = validationContext;
                var newContext = array.Validate(context.ResetLastWasValid());
                if (!newContext.LastWasValid)
                {
                    return newContext;
                }
                return array.ValidateItems(context);
            }
            public void WriteTo(System.Text.Json.Utf8JsonWriter writer)
            {
                if (this.HasJsonElement)
                {
                    this.JsonElement.WriteTo(writer);
                }
                if (this.value is Menes.JsonArray<Menes.JsonAny> clrValue)
                {
                    clrValue.WriteTo(writer);
                }
            }
            public Menes.JsonArray<Menes.JsonAny>.JsonArrayEnumerator GetEnumerator()
            {
                return ((Menes.JsonArray<Menes.JsonAny>)this).GetEnumerator();
            }
            System.Collections.Generic.IEnumerator<Menes.JsonAny> System.Collections.Generic.IEnumerable<Menes.JsonAny>.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            public SchemaValueValue Add(params Menes.JsonAny[] items)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    arrayBuilder.Add(item);
                }
                foreach (Menes.JsonAny item in items)
                {
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Add(in Menes.JsonAny item1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Add(in Menes.JsonAny item1, in Menes.JsonAny item2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Add(in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    arrayBuilder.Add(item);
                }
                arrayBuilder.Add(item1);
                arrayBuilder.Add(item2);
                arrayBuilder.Add(item3);
                arrayBuilder.Add(item4);
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Insert(int indexToInsert, params Menes.JsonAny[] items)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int index = 0;
                foreach (Menes.JsonAny item in this)
                {
                    if (index == indexToInsert)
                    {
                        foreach (Menes.JsonAny itemToInsert in items)
                        {
                            arrayBuilder.Add(itemToInsert);
                        }
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Insert(int indexToInsert, in Menes.JsonAny item1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int index = 0;
                foreach (Menes.JsonAny item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int index = 0;
                foreach (Menes.JsonAny item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int index = 0;
                foreach (Menes.JsonAny item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                        arrayBuilder.Add(item3);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Insert(int indexToInsert, in Menes.JsonAny item1, in Menes.JsonAny item2, in Menes.JsonAny item3, in Menes.JsonAny item4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int index = 0;
                foreach (Menes.JsonAny item in this)
                {
                    if (index == indexToInsert)
                    {
                        arrayBuilder.Add(item1);
                        arrayBuilder.Add(item2);
                        arrayBuilder.Add(item3);
                        arrayBuilder.Add(item4);
                    }
                    arrayBuilder.Add(item);
                    ++index;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Remove(params Menes.JsonAny[] items)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    bool found = false;
                    foreach (Menes.JsonAny itemToRemove in items)
                    {
                        if (itemToRemove.Equals(item))
                        {
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        arrayBuilder.Add(item);
                    }
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Remove(Menes.JsonAny item1)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    if (item1.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Remove(Menes.JsonAny item1, Menes.JsonAny item2)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Remove(Menes.JsonAny item1, Menes.JsonAny item2, Menes.JsonAny item3, Menes.JsonAny item4)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    if (item1.Equals(item) || item2.Equals(item) || item3.Equals(item) || item4.Equals(item))
                    {
                        break;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue RemoveAt(int indexToRemove)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int index = 0;
                foreach (Menes.JsonAny item in this)
                {
                    if (index == indexToRemove)
                    {
                        index++;
                        continue;
                    }
                    arrayBuilder.Add(item);
                    index++;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue RemoveRange(int startIndex, int length)
            {
                if (startIndex < 0 || startIndex > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(startIndex));
                }
                if (length < 1 || startIndex + length > this.Length - 1)
                {
                    throw new System.ArgumentOutOfRangeException(nameof(length));
                }
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                int index = 0;
                foreach (Menes.JsonAny item in this)
                {
                    if (index >= startIndex && index < startIndex + length)
                    {
                        index++;
                        continue;
                    }
                    arrayBuilder.Add(item);
                    index++;
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
            public SchemaValueValue Remove(System.Predicate<Menes.JsonAny> removeIfTrue)
            {
                System.Collections.Immutable.ImmutableArray<Menes.JsonAny>.Builder arrayBuilder = System.Collections.Immutable.ImmutableArray.CreateBuilder<Menes.JsonAny>();
                foreach (Menes.JsonAny item in this)
                {
                    if (removeIfTrue(item))
                    {
                        continue;
                    }
                    arrayBuilder.Add(item);
                }
                return Menes.JsonArray.Create(arrayBuilder.ToImmutable());
            }
        }
    }
    public readonly struct Item1Value : Menes.IJsonValue, System.IEquatable<Item1Value>
    {
        public static readonly System.Func<System.Text.Json.JsonElement, Item1Value> FromJsonElement = e => new Item1Value(e);
        public static readonly Item1Value Null = new Item1Value(default(System.Text.Json.JsonElement));
        private static readonly Menes.JsonAny ConstValue = BuildConstValue();
        private readonly Menes.JsonAny? value;
        public Item1Value(Menes.JsonAny value)
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
        public Item1Value(System.Text.Json.JsonElement jsonElement)
        {
            this.value = null;
            this.JsonElement = jsonElement;
        }
        public bool IsNull => this.value == null && (this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Undefined || this.JsonElement.ValueKind == System.Text.Json.JsonValueKind.Null);
        public Item1Value? AsOptional => this.IsNull ? default(Item1Value?) : this;
        public bool HasJsonElement => this.JsonElement.ValueKind != System.Text.Json.JsonValueKind.Undefined;
        public System.Text.Json.JsonElement JsonElement { get; }
        public static implicit operator Item1Value(Menes.JsonAny value)
        {
            return new Item1Value(value);
        }
        public static implicit operator Menes.JsonAny(Item1Value value)
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
        public static Item1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<char> propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Item1Value(property)
                    : Null)
                : Null;
        public static Item1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, string propertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(propertyName, out System.Text.Json.JsonElement property)
                    ? new Item1Value(property)
                    : Null)
                : Null;
        public static Item1Value FromOptionalProperty(in System.Text.Json.JsonElement parentDocument, System.ReadOnlySpan<byte> utf8PropertyName) =>
           parentDocument.ValueKind == System.Text.Json.JsonValueKind.Object ?
                (parentDocument.TryGetProperty(utf8PropertyName, out System.Text.Json.JsonElement property)
                    ? new Item1Value(property)
                    : Null)
                : Null;
        public bool Equals(Item1Value other)
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
            using var document = System.Text.Json.JsonDocument.Parse("\"foo\"");
            return new Menes.JsonAny(document.RootElement.Clone());
        }
    }
}
///  <summary>
/// unevaluatedItems with not
/// </summary>
public static class Tests
{
/// <summary>
/// with unevaluated items
/// </summary>
    public static bool Test0()
    {
        using var doc = System.Text.Json.JsonDocument.Parse("[\"foo\", \"bar\"]");
        var schema = new Schema(doc.RootElement);
        var context = schema.Validate(Menes.ValidationContext.Root);
        if (context.IsValid)
        {
            System.Console.WriteLine("Failed UnevaluatedItems011.Tests.Test0: with unevaluated items");
            System.Console.WriteLine("Expected: invalid but was valid");
            return false;
        }
            return true;
    }
}
}