﻿// <copyright file="JsonReaderHelper.cs" company="Endjin Limited">
// Copyright (c) Endjin Limited. All rights reserved.
// </copyright>
// Derived from code:
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

#pragma warning disable

using System;
using System.Buffers;
using System.Buffers.Text;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace Menes.Json
{
    public static partial class JsonReaderHelper
    {
        public static bool TryGetUnescapedBase64Bytes(ReadOnlySpan<byte> utf8Source, int idx, [NotNullWhen(true)] out byte[]? bytes)
        {
            byte[]? unescapedArray = null;

            Span<byte> utf8Unescaped = utf8Source.Length <= JsonConstants.StackallocThreshold ?
                stackalloc byte[utf8Source.Length] :
                (unescapedArray = ArrayPool<byte>.Shared.Rent(utf8Source.Length));

            Unescape(utf8Source, utf8Unescaped, idx, out int written);
            Debug.Assert(written > 0);

            utf8Unescaped = utf8Unescaped.Slice(0, written);
            Debug.Assert(!utf8Unescaped.IsEmpty);

            bool result = TryDecodeBase64InPlace(utf8Unescaped, out bytes!);

            if (unescapedArray != null)
            {
                utf8Unescaped.Clear();
                ArrayPool<byte>.Shared.Return(unescapedArray);
            }
            return result;
        }

        // Reject any invalid UTF-8 data rather than silently replacing.
        public static readonly UTF8Encoding s_utf8Encoding = new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true);

        // TODO: Similar to escaping, replace the unescaping logic with publicly shipping APIs from https://github.com/dotnet/runtime/issues/27919
        public static string GetUnescapedString(ReadOnlySpan<byte> utf8Source, int idx)
        {
            // The escaped name is always >= than the unescaped, so it is safe to use escaped name for the buffer length.
            int length = utf8Source.Length;
            byte[]? pooledName = null;

            Span<byte> utf8Unescaped = length <= JsonConstants.StackallocThreshold ?
                stackalloc byte[length] :
                (pooledName = ArrayPool<byte>.Shared.Rent(length));

            Unescape(utf8Source, utf8Unescaped, idx, out int written);
            Debug.Assert(written > 0);

            utf8Unescaped = utf8Unescaped.Slice(0, written);
            Debug.Assert(!utf8Unescaped.IsEmpty);

            string utf8String = TranscodeHelper(utf8Unescaped);

            if (pooledName != null)
            {
                utf8Unescaped.Clear();
                ArrayPool<byte>.Shared.Return(pooledName);
            }

            return utf8String;
        }

        public static ReadOnlySpan<byte> GetUnescapedSpan(ReadOnlySpan<byte> utf8Source, int idx)
        {
            // The escaped name is always >= than the unescaped, so it is safe to use escaped name for the buffer length.
            int length = utf8Source.Length;
            byte[]? pooledName = null;

            Span<byte> utf8Unescaped = length <= JsonConstants.StackallocThreshold ?
                stackalloc byte[length] :
                (pooledName = ArrayPool<byte>.Shared.Rent(length));

            Unescape(utf8Source, utf8Unescaped, idx, out int written);
            Debug.Assert(written > 0);

            ReadOnlySpan<byte> propertyName = utf8Unescaped.Slice(0, written).ToArray();
            Debug.Assert(!propertyName.IsEmpty);

            if (pooledName != null)
            {
                new Span<byte>(pooledName, 0, written).Clear();
                ArrayPool<byte>.Shared.Return(pooledName);
            }

            return propertyName;
        }

        public static bool UnescapeAndCompare(ReadOnlySpan<byte> utf8Source, ReadOnlySpan<byte> other)
        {
            Debug.Assert(utf8Source.Length >= other.Length && utf8Source.Length / JsonConstants.MaxExpansionFactorWhileEscaping <= other.Length);

            byte[]? unescapedArray = null;

            Span<byte> utf8Unescaped = utf8Source.Length <= JsonConstants.StackallocThreshold ?
                stackalloc byte[utf8Source.Length] :
                (unescapedArray = ArrayPool<byte>.Shared.Rent(utf8Source.Length));

            Unescape(utf8Source, utf8Unescaped, 0, out int written);
            Debug.Assert(written > 0);

            utf8Unescaped = utf8Unescaped.Slice(0, written);
            Debug.Assert(!utf8Unescaped.IsEmpty);

            bool result = other.SequenceEqual(utf8Unescaped);

            if (unescapedArray != null)
            {
                utf8Unescaped.Clear();
                ArrayPool<byte>.Shared.Return(unescapedArray);
            }

            return result;
        }

        public static bool UnescapeAndCompare(ReadOnlySequence<byte> utf8Source, ReadOnlySpan<byte> other)
        {
            Debug.Assert(!utf8Source.IsSingleSegment);
            Debug.Assert(utf8Source.Length >= other.Length && utf8Source.Length / JsonConstants.MaxExpansionFactorWhileEscaping <= other.Length);

            byte[]? escapedArray = null;
            byte[]? unescapedArray = null;

            int length = checked((int)utf8Source.Length);

            Span<byte> utf8Unescaped = length <= JsonConstants.StackallocThreshold ?
                stackalloc byte[length] :
                (unescapedArray = ArrayPool<byte>.Shared.Rent(length));

            Span<byte> utf8Escaped = length <= JsonConstants.StackallocThreshold ?
                stackalloc byte[length] :
                (escapedArray = ArrayPool<byte>.Shared.Rent(length));

            utf8Source.CopyTo(utf8Escaped);
            utf8Escaped = utf8Escaped.Slice(0, length);

            Unescape(utf8Escaped, utf8Unescaped, 0, out int written);
            Debug.Assert(written > 0);

            utf8Unescaped = utf8Unescaped.Slice(0, written);
            Debug.Assert(!utf8Unescaped.IsEmpty);

            bool result = other.SequenceEqual(utf8Unescaped);

            if (unescapedArray != null)
            {
                Debug.Assert(escapedArray != null);
                utf8Unescaped.Clear();
                ArrayPool<byte>.Shared.Return(unescapedArray);
                utf8Escaped.Clear();
                ArrayPool<byte>.Shared.Return(escapedArray);
            }

            return result;
        }

        public static bool TryDecodeBase64InPlace(Span<byte> utf8Unescaped, [NotNullWhen(true)] out byte[]? bytes)
        {
            OperationStatus status = Base64.DecodeFromUtf8InPlace(utf8Unescaped, out int bytesWritten);
            if (status != OperationStatus.Done)
            {
                bytes = null;
                return false;
            }
            bytes = utf8Unescaped.Slice(0, bytesWritten).ToArray();
            return true;
        }

        public static bool TryDecodeBase64(ReadOnlySpan<byte> utf8Unescaped, [NotNullWhen(true)] out byte[]? bytes)
        {
            byte[]? pooledArray = null;

            Span<byte> byteSpan = utf8Unescaped.Length <= JsonConstants.StackallocThreshold ?
                stackalloc byte[utf8Unescaped.Length] :
                (pooledArray = ArrayPool<byte>.Shared.Rent(utf8Unescaped.Length));

            OperationStatus status = Base64.DecodeFromUtf8(utf8Unescaped, byteSpan, out int bytesConsumed, out int bytesWritten);

            if (status != OperationStatus.Done)
            {
                bytes = null;

                if (pooledArray != null)
                {
                    byteSpan.Clear();
                    ArrayPool<byte>.Shared.Return(pooledArray);
                }

                return false;
            }
            Debug.Assert(bytesConsumed == utf8Unescaped.Length);

            bytes = byteSpan.Slice(0, bytesWritten).ToArray();

            if (pooledArray != null)
            {
                byteSpan.Clear();
                ArrayPool<byte>.Shared.Return(pooledArray);
            }

            return true;
        }

        public static string TranscodeHelper(ReadOnlySpan<byte> utf8Unescaped)
        {
            try
            {
                return s_utf8Encoding.GetString(utf8Unescaped);
            }
            catch (DecoderFallbackException ex)
            {
                // We want to be consistent with the exception being thrown
                // so the user only has to catch a single exception.
                // Since we already throw InvalidOperationException for mismatch token type,
                // and while unescaping, using that exception for failure to decode invalid UTF-8 bytes as well.
                // Therefore, wrapping the DecoderFallbackException around an InvalidOperationException.
                throw new InvalidOperationException("Read Invalid UTF8", ex);
            }
        }

        internal static int GetUtf8ByteCount(ReadOnlySpan<char> text)
        {
            try
            {
                return s_utf8Encoding.GetByteCount(text);
            }
            catch (EncoderFallbackException ex)
            {
                // We want to be consistent with the exception being thrown
                // so the user only has to catch a single exception.
                // Since we already throw ArgumentException when validating other arguments,
                // using that exception for failure to encode invalid UTF-16 chars as well.
                // Therefore, wrapping the EncoderFallbackException around an ArgumentException.
                throw new ArgumentException("Read Invalid UTF16", ex);
            }
        }

        internal static int GetUtf8FromText(ReadOnlySpan<char> text, Span<byte> dest)
        {
            try
            {
                return s_utf8Encoding.GetBytes(text, dest);
            }
            catch (EncoderFallbackException ex)
            {
                // We want to be consistent with the exception being thrown
                // so the user only has to catch a single exception.
                // Since we already throw ArgumentException when validating other arguments,
                // using that exception for failure to encode invalid UTF-16 chars as well.
                // Therefore, wrapping the EncoderFallbackException around an ArgumentException.
                throw new ArgumentException("Read Invalid UTF16", ex);
            }
        }

        internal static string GetTextFromUtf8(ReadOnlySpan<byte> utf8Text)
        {
            return s_utf8Encoding.GetString(utf8Text);
        }

        internal static void Unescape(ReadOnlySpan<byte> source, Span<byte> destination, int idx, out int written)
        {
            Debug.Assert(idx >= 0 && idx < source.Length);
            Debug.Assert(source[idx] == JsonConstants.BackSlash);
            Debug.Assert(destination.Length >= source.Length);

            source.Slice(0, idx).CopyTo(destination);
            written = idx;

            for (; idx < source.Length; idx++)
            {
                byte currentByte = source[idx];
                if (currentByte == JsonConstants.BackSlash)
                {
                    idx++;
                    currentByte = source[idx];

                    if (currentByte == JsonConstants.Quote)
                    {
                        destination[written++] = JsonConstants.Quote;
                    }
                    else if (currentByte == 'n')
                    {
                        destination[written++] = JsonConstants.LineFeed;
                    }
                    else if (currentByte == 'r')
                    {
                        destination[written++] = JsonConstants.CarriageReturn;
                    }
                    else if (currentByte == JsonConstants.BackSlash)
                    {
                        destination[written++] = JsonConstants.BackSlash;
                    }
                    else if (currentByte == JsonConstants.Slash)
                    {
                        destination[written++] = JsonConstants.Slash;
                    }
                    else if (currentByte == 't')
                    {
                        destination[written++] = JsonConstants.Tab;
                    }
                    else if (currentByte == 'b')
                    {
                        destination[written++] = JsonConstants.BackSpace;
                    }
                    else if (currentByte == 'f')
                    {
                        destination[written++] = JsonConstants.FormFeed;
                    }
                    else if (currentByte == 'u')
                    {
                        // The source is known to be valid JSON, and hence if we see a \u, it is guaranteed to have 4 hex digits following it
                        // Otherwise, the Utf8JsonReader would have alreayd thrown an exception.
                        Debug.Assert(source.Length >= idx + 5);

                        bool result = Utf8Parser.TryParse(source.Slice(idx + 1, 4), out int scalar, out int bytesConsumed, 'x');
                        Debug.Assert(result);
                        Debug.Assert(bytesConsumed == 4);
                        idx += bytesConsumed;     // The loop iteration will increment idx past the last hex digit

                        if (JsonHelpers.IsInRangeInclusive((uint)scalar, JsonConstants.HighSurrogateStartValue, JsonConstants.LowSurrogateEndValue))
                        {
                            // The first hex value cannot be a low surrogate.
                            if (scalar >= JsonConstants.LowSurrogateStartValue)
                            {
                                throw new InvalidOperationException($"Read Invalid UTF16: {scalar}");
                            }

                            Debug.Assert(JsonHelpers.IsInRangeInclusive((uint)scalar, JsonConstants.HighSurrogateStartValue, JsonConstants.HighSurrogateEndValue));

                            idx += 3;   // Skip the last hex digit and the next \u

                            // We must have a low surrogate following a high surrogate.
                            if (source.Length < idx + 4 || source[idx - 2] != '\\' || source[idx - 1] != 'u')
                            {
                                throw new InvalidOperationException("Read Invalid UTF16");
                            }

                            // The source is known to be valid JSON, and hence if we see a \u, it is guaranteed to have 4 hex digits following it
                            // Otherwise, the Utf8JsonReader would have alreayd thrown an exception.
                            result = Utf8Parser.TryParse(source.Slice(idx, 4), out int lowSurrogate, out bytesConsumed, 'x');
                            Debug.Assert(result);
                            Debug.Assert(bytesConsumed == 4);

                            // If the first hex value is a high surrogate, the next one must be a low surrogate.
                            if (!JsonHelpers.IsInRangeInclusive((uint)lowSurrogate, JsonConstants.LowSurrogateStartValue, JsonConstants.LowSurrogateEndValue))
                            {
                                throw new InvalidOperationException($"Read Invalid UTF16: {lowSurrogate}");
                            }

                            idx += bytesConsumed - 1;  // The loop iteration will increment idx past the last hex digit

                            // To find the unicode scalar:
                            // (0x400 * (High surrogate - 0xD800)) + Low surrogate - 0xDC00 + 0x10000
                            scalar = (JsonConstants.BitShiftBy10 * (scalar - JsonConstants.HighSurrogateStartValue))
                                + (lowSurrogate - JsonConstants.LowSurrogateStartValue)
                                + JsonConstants.UnicodePlane01StartValue;
                        }

                        var rune = new Rune(scalar);
                        int bytesWritten = rune.EncodeToUtf8(destination.Slice(written));
                        Debug.Assert(bytesWritten <= 4);
                        written += bytesWritten;
                    }
                }
                else
                {
                    destination[written++] = currentByte;
                }
            }
        }
    }
}