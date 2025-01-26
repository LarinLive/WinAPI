// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using LarinLive.WinAPI.NativeMethods;
using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

namespace LarinLive.WinAPI;

/// <summary>
/// Helper methods for unmanaged memory operations
/// </summary>
public static unsafe class UMM
{
	/// <summary>
	/// Allocates a fixed block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* GlobalAlloc(nuint size) =>
		(void*)Kernel32.GlobalAlloc(Kernel32.GPTR, size);

	/// <summary>
	/// Allocates a fixed block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* GlobalAlloc(int size) =>
		(void*)Kernel32.GlobalAlloc(Kernel32.GPTR, unchecked((uint)size));

	/// <summary>
	/// Allocates a fixed block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* GlobalAlloc(uint size) =>
		(void*)Kernel32.GlobalAlloc(Kernel32.GPTR, size);

	/// <summary>
	/// Allocates a movable block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint GlobalAllocMovable(nuint size) =>
		Kernel32.GlobalAlloc(Kernel32.GHND, size);

	/// <summary>
	/// Allocates a movable block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint GlobalAllocMovable(int size) =>
		Kernel32.GlobalAlloc(Kernel32.GHND, (nuint)size);

	/// <summary>
	/// Allocates a movable block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	public static nint GlobalAllocMovable(uint size) =>
		Kernel32.GlobalAlloc(Kernel32.GHND, size);

	/// <summary>
	/// Frees the specified global memory object and invalidates its pointer. 
	/// </summary>
	/// <param name="pMem">A pointer to the global memory object</param>
	/// <returns>If the function succeeds, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* GlobalFree(void* pMem) =>
		(void*)Kernel32.GlobalFree((nint)pMem);

	/// <summary>
	/// Frees the specified global memory object and invalidates its handle. 
	/// </summary>
	/// <param name="hMem">A handle to the global memory object</param>
	/// <returns>If the function succeeds, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint GlobalFree(nint hMem) =>
		Kernel32.GlobalFree(hMem);

	/// <summary>
	/// Allocates a fixed block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* LocalAlloc(nuint size) =>
		(void*)Kernel32.LocalAlloc(Kernel32.GPTR, size);

	/// <summary>
	/// Allocates a fixed block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* LocalAlloc(int size) =>
		(void*)Kernel32.LocalAlloc(Kernel32.GPTR, unchecked((uint)size));

	/// <summary>
	/// Allocates a fixed block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* LocalAlloc(uint size) =>
		(void*)Kernel32.LocalAlloc(Kernel32.GPTR, size);

	/// <summary>
	/// Allocates a movable block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint LocalAllocMovable(nuint size) =>
		Kernel32.LocalAlloc(Kernel32.GHND, size);

	/// <summary>
	/// Allocates a movable block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint LocalAllocMovable(int size) =>
		Kernel32.LocalAlloc(Kernel32.GHND, (nuint)size);

	/// <summary>
	/// Allocates a movable block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	public static nint LocalAllocMovable(uint size) =>
		Kernel32.LocalAlloc(Kernel32.GHND, size);

	/// <summary>
	/// Frees the specified Local memory object and invalidates its pointer. 
	/// </summary>
	/// <param name="pMem">A pointer to the Local memory object</param>
	/// <returns>If the function succeeds, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* LocalFree(void* pMem) =>
		(void*)Kernel32.LocalFree((nint)pMem);

	/// <summary>
	/// Frees the specified Local memory object and invalidates its handle. 
	/// </summary>
	/// <param name="hMem">A handle to the Local memory object</param>
	/// <returns>If the function succeeds, the return value is NULL.</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint LocalFree(nint hMem) =>
		Kernel32.LocalFree(hMem);

	/// <summary>
	/// Returns the size of a specified unmanaged type
	/// </summary>
	/// <typeparam name="T">A structure type which unmanaged size is calcualting</typeparam>
	/// <returns>The size in bytes</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SizeOf<T>() where T : struct =>
		Marshal.SizeOf<T>();

	/// <summary>
	/// Returns the size of a specified object of a unmanaged type
	/// </summary>
	/// <typeparam name="T">A structure type which unmanaged size is calcualting</typeparam>
	/// <param name="structure">A structure of the type <typeparamref name="T"/> which size is calculating</param>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int SizeOf<T>(this ref T structure) where T : struct =>
		Marshal.SizeOf(structure);

	/// <summary>
	/// Returns the size of a specified unmanaged type
	/// </summary>
	/// <typeparam name="T">A structure type which unmanaged size is calcualting</typeparam>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint USizeOf<T>() where T : struct =>
		unchecked((uint)Marshal.SizeOf<T>());

	/// <summary>
	/// Returns the size of a specified object of a unmanaged type
	/// </summary>
	/// <typeparam name="T">A structure type which unmanaged size is calcualting</typeparam>
	/// <param name="structure">A structure of the type <typeparamref name="T"/> which size is calculating</param>
	/// <returns></returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint USizeOf<T>(this ref T structure) where T : struct =>
		unchecked((uint)Marshal.SizeOf(structure));

	/// <summary>
	/// Adds a specified offset to a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* Add(void* ptr, int offset) =>
		(void*)unchecked((nint)ptr + offset);

	/// <summary>
	/// Adds a specified offset to a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* Add(void* ptr, uint offset) =>
		(void*)unchecked((nint)ptr + (nint)offset);

	/// <summary>
	/// Adds a specified offset to a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* Add(void* ptr, nint offset) =>
		(void*)unchecked((nint)ptr + offset);

	/// <summary>
	/// Adds a specified offset to a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Add(this nint ptr, int offset) =>
		unchecked(ptr + offset);

	/// <summary>
	/// Adds a specified offset to a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Add(this nint ptr, uint offset) =>
		unchecked(ptr + (nint)offset);

	/// <summary>
	/// Adds a specified offset to a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Add(this nint ptr, nint offset) =>
		unchecked(ptr + offset);

	/// <summary>
	/// Add a specified offset to a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* Sub(void* ptr, int offset) =>
		(void*)unchecked((nint)ptr - offset);

	/// <summary>
	/// Substracts a specified offset from a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* Sub(void* ptr, uint offset) =>
		(void*)unchecked((nint)ptr - (nint)offset);

	/// <summary>
	/// Substracts a specified offset from a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static void* Sub(void* ptr, nint offset) =>
		(void*)unchecked((nint)ptr - offset);

	/// <summary>
	/// Substracts a specified offset from a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Sub(this nint ptr, int offset) =>
		unchecked(ptr - offset);

	/// <summary>
	/// Substracts a specified offset from a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Sub(this nint ptr, uint offset) =>
		unchecked(ptr - (nint)offset);

	/// <summary>
	/// Substracts a specified offset from a specified pointer
	/// </summary>
	/// <param name="ptr">A pointer which value is adjusting</param>
	/// <param name="offset">An offset in bytes</param>
	/// <returns>Adjusted pointer</returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	/// <exception cref="ArgumentException"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint Sub(this nint ptr, nint offset) =>
		unchecked(ptr - offset);

	/// <summary>
	///  Creates a new <see cref="Span{T}"/> instance from a specified number of T elements starting at a specified memory address.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pBuffer">A pointer to the starting address of a specified number of T elements in memory.</param>
	/// <param name="length">A number of T elements to be included in the <see cref="Span{T}"/>.</param>
	/// <returns>A newly created instance of the <see cref="Span{T}"/> struct.</returns>
	public static Span<T> PtrToSpan<T>(void* pBuffer, uint length) =>
		new(pBuffer, (int)length);

	/// <summary>
	///  Creates a new <see cref="Span{T}"/> instance from a specified number of T elements starting at a specified memory address.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pBuffer">A pointer to the starting address of a specified number of T elements in memory.</param>
	/// <param name="length">A number of T elements to be included in the <see cref="Span{T}"/>.</param>
	/// <returns>A newly created instance of the <see cref="Span{T}"/> struct.</returns>
	public static Span<T> PtrToSpan<T>(void* pBuffer, int length) =>
		new(pBuffer, length);

	/// <summary>
	///  Creates a new <see cref="Span{T}"/> instance from a specified number of T elements starting at a specified memory address.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pBuffer">A starting address of a specified number of T elements in memory.</param>
	/// <param name="length">A number of T elements to be included in the <see cref="Span{T}"/>.</param>
	/// <returns>A newly created instance of the <see cref="Span{T}"/> struct.</returns>
	public static Span<T> PtrToSpan<T>(nint pBuffer, uint length) =>
		new((void*)pBuffer, (int)length);

	/// <summary>
	///  Creates a new <see cref="Span{T}"/> instance from a specified number of T elements starting at a specified memory address.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pBuffer">A starting address of a specified number of T elements in memory.</param>
	/// <param name="length">A number of T elements to be included in the <see cref="Span{T}"/>.</param>
	/// <returns>A newly created instance of the <see cref="Span{T}"/> struct.</returns>
	public static Span<T> PtrToSpan<T>(nint pBuffer, int length) =>
		new((void*)pBuffer, length);

	/// <summary>
	///  Creates a new <see cref="ReadOnlySpan{T}"/> instance from a specified number of T elements starting at a specified memory address.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pBuffer">A pointer to the starting address of a specified number of T elements in memory.</param>
	/// <param name="length">A number of T elements to be included in the <see cref="ReadOnlySpan{T}"/>.</param>
	/// <returns>A newly created instance of the <see cref="ReadOnlySpan{T}"/> struct.</returns>
	public static ReadOnlySpan<T> PtrToReadOnlySpan<T>(void* pBuffer, uint length) =>
		new(pBuffer, (int)length);

	/// <summary>
	///  Creates a new <see cref="ReadOnlySpan{T}"/> instance from a specified number of T elements starting at a specified memory address.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pBuffer">A pointer to the starting address of a specified number of T elements in memory.</param>
	/// <param name="length">A number of T elements to be included in the <see cref="ReadOnlySpan{T}"/>.</param>
	/// <returns>A newly created instance of the <see cref="ReadOnlySpan{T}"/> struct.</returns>
	public static ReadOnlySpan<T> PtrToReadOnlySpan<T>(void* pBuffer, int length) =>
		new(pBuffer, length);

	/// <summary>
	///  Creates a new <see cref="ReadOnlySpan{T}"/> instance from a specified number of T elements starting at a specified memory address.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pBuffer">A starting address of a specified number of T elements in memory.</param>
	/// <param name="length">A number of T elements to be included in the <see cref="ReadOnlySpan{T}"/>.</param>
	/// <returns>A newly created instance of the <see cref="ReadOnlySpan{T}"/> struct.</returns>
	public static ReadOnlySpan<T> PtrToReadOnlySpan<T>(nint pBuffer, uint length) =>
		new((void*)pBuffer, (int)length);

	/// <summary>
	///  Creates a new <see cref="ReadOnlySpan{T}"/> instance from a specified number of T elements starting at a specified memory address.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <param name="pBuffer">A starting address of a specified number of T elements in memory.</param>
	/// <param name="length">A number of T elements to be included in the <see cref="ReadOnlySpan{T}"/>.</param>
	/// <returns>A newly created instance of the <see cref="ReadOnlySpan{T}"/> struct.</returns>
	public static ReadOnlySpan<T> PtrToReadOnlySpan<T>(nint pBuffer, int length) =>
		new((void*)pBuffer, length);

	/// <summary>
	/// Reads a null terminated unicode string from an unmanaged memory buffer as a read-only span.
	/// </summary>
	/// <param name="pBuffer">A pointer to an unmanaged memory buffer.</param>
	/// <param name="bufferSize">A buffer size in bytes.</param>
	/// <param name="startOffset">An offset from the buffer start for string reading.</param>
	/// <returns>A read-only char span from the unmanaged buffer without the terminating character.</returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	/// <exception cref="ArgumentException"></exception>
	/// <exception cref="ArgumentNullException"></exception>
	public static ReadOnlySpan<char> PtrToUnicodeSpan(void* pBuffer, uint bufferSize, uint startOffset = 0U)
	{
		if (pBuffer is null)
			throw new (nameof(pBuffer));
		var charSize = sizeof(char);
		if (bufferSize < charSize)
			throw new ArgumentOutOfRangeException(nameof(bufferSize));
		else if (startOffset > bufferSize - charSize)
			throw new ArgumentOutOfRangeException(nameof(startOffset));

		if (startOffset > 0U)
		{
			bufferSize -= startOffset;
			pBuffer = Add(pBuffer, startOffset);
		}

		var maxCharCount = bufferSize >> 1;
		var span = new ReadOnlySpan<char>(pBuffer, unchecked((int)maxCharCount));
		var terminatorOffset = span.IndexOf('\0');
		if (terminatorOffset > 0)
			return span[..terminatorOffset];
		else if (terminatorOffset == 0)
			return [];
		else
			throw new ArgumentException("An unicode string terminator is not found in the input buffer.", nameof(pBuffer));
	}

	/// <summary>
	/// Reads a null terminated unicode string from an unmanaged memory buffer.
	/// </summary>
	/// <param name="pBuffer">A pointer to an unmanaged memory buffer.</param>
	/// <param name="bufferSize">A buffer size in bytes.</param>
	/// <param name="startOffset">An offset from the buffer start for string reading.</param>
	/// <returns>A new string copied from the unmanaged buffer without the terminating character.</returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	/// <exception cref="ArgumentException"></exception>
	public static string? PtrToUnicodeString(void* pBuffer, uint bufferSize, uint startOffset = 0U) =>
		pBuffer is not null ? new(PtrToUnicodeSpan(pBuffer, bufferSize, startOffset)) : null;

	/// <summary>
	/// Reads a null terminated ANSI string from an unmanaged memory buffer as a read-only span.
	/// </summary>
	/// <param name="pBuffer">A pointer to an unmanaged memory buffer</param>
	/// <param name="bufferSize">A buffer size in bytes</param>
	/// <param name="startOffset">An offset from the buffer start for string reading</param>
	/// <returns>A read-only byte span from the unmanaged buffer without the terminating character.</returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	/// <exception cref="ArgumentException"></exception>
	public static ReadOnlySpan<byte> PtrToAnsiSpan(void* pBuffer, uint bufferSize, uint startOffset = 0U)
	{
		if (pBuffer is null)
			throw new ArgumentNullException(nameof(pBuffer));
		else if (bufferSize < 1)
			throw new ArgumentOutOfRangeException(nameof(bufferSize));
		else if (startOffset > bufferSize - 1)
			throw new ArgumentOutOfRangeException(nameof(startOffset));

		if (startOffset > 0U)
		{
			bufferSize -= startOffset;
			pBuffer = Add(pBuffer, startOffset);
		}

		var span = new ReadOnlySpan<byte>(pBuffer, unchecked((int)bufferSize));
		var terminatorOffset = span.IndexOf((byte)0);
		if (terminatorOffset > 0)
			return span[..terminatorOffset];
		else if (terminatorOffset == 0)
			return [];
		else
			throw new ArgumentException("An ANSI string terminator is not found in the input buffer", nameof(pBuffer));
	}

	/// <summary>
	/// Reads a null terminated ANSI string from an unmanaged memory buffer.
	/// </summary>
	/// <param name="pBuffer">A pointer to an unmanaged memory buffer</param>
	/// <param name="bufferSize">A buffer size in bytes</param>
	/// <param name="startOffset">An offset from the buffer start for string reading</param>
	/// <param name="encoding">An appropriate encoding of the ANSI string</param>
	/// <returns>A new string copied from the unmanaged buffer without the terminating character</returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	/// <exception cref="ArgumentException"></exception>
	public static string? PtrToAnsiString(void* pBuffer, uint bufferSize, uint startOffset, Encoding encoding) =>
		pBuffer is not null ? encoding.GetString(PtrToAnsiSpan(pBuffer, bufferSize, startOffset)) : null;
}
