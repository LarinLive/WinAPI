// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.Kernel32;

namespace LarinLive.WinAPI;

/// <summary>
/// Extension methods for checking WinAPI result values
/// </summary>
public static class WinApiResultExtensions
{
	/// <summary>
	/// Checks a specified WinAPI BOOL return value, and throws the <see cref="Win32Exception"/> with the error code returned by <see cref="GetLastError"/> if it equals FALSE.
	/// </summary>
	/// <param name="result">A WinAPI function BOOL return value.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool VerifyWinapiTrue(this bool result) =>
		result ? result : throw Marshal.GetLastPInvokeError().ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value, and throws the <see cref="Win32Exception"/> with the error code returned by <see cref="GetLastError"/> if it equals zero.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiNonzero(this uint result) =>
		result != 0U ? result : throw Marshal.GetLastPInvokeError().ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI INT return value, and throws the <see cref="Win32Exception"/> with the error code returned by <see cref="GetLastError"/> if it equals zero.
	/// </summary>
	/// <param name="result">A WinAPI function INT return value.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int VerifyWinapiTrue(this int result) =>
		result != 0 ? result : throw Marshal.GetLastPInvokeError().ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI INT_PTR return value, and throws the <see cref="Win32Exception"/> with the error code returned by <see cref="GetLastError"/> if it equals zero.
	/// </summary>
	/// <param name="result">A WinAPI function INT return value.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiTrue(this nint result) =>
		result != 0 ? result : throw Marshal.GetLastPInvokeError().ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI BOOL return value, and throws the <see cref="Win32Exception"/> with the error code returned by <see cref="GetLastError"/> if it equals TRUE.
	/// </summary>
	/// <param name="result">A WinAPI function BOOL return value.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool VerifyWinapiZero(this bool result) =>
		!result ? result : throw Marshal.GetLastPInvokeError().ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value, and throws the <see cref="Win32Exception"/> with the error code returned by <see cref="GetLastError"/> if it equals non-zero.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiZero(this uint result) =>
		result == 0U ? result : throw Marshal.GetLastPInvokeError().ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI INT return value, and throws the <see cref="Win32Exception"/> with the error code returned by <see cref="GetLastError"/> if it equals non-zero.
	/// </summary>
	/// <param name="result">A WinAPI function INT return value.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int VerifyWinapiZero(this int result) =>
		result == 0 ? result : throw Marshal.GetLastPInvokeError().ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI INT_PTR return value, and throws the <see cref="Win32Exception"/> with the error code returned by <see cref="GetLastError"/> if it equals non-zero.
	/// </summary>
	/// <param name="result">A WinAPI function INT return value.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiZero(this nint result) =>
		result == 0 ? result : throw Marshal.GetLastPInvokeError().ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if it equals non-zero.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiErrorCode(this uint result) =>
		result == 0U ? result : throw result.ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if it equals non-zero.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int VerifyWinapiErrorCode(this int result) =>
		result == 0 ? result : throw result.ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI INT_PTR return value and throws the <see cref="Win32Exception"/> with the error code returned by <see cref="GetLastError"/> if it equals <see cref="INVALID_HANDLE_VALUE"/>.
	/// </summary>
	/// <param name="resut">A WinAPI function INT_PTR return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiValidHandle(this nint resut) =>
		resut != INVALID_HANDLE_VALUE ? resut : throw Marshal.GetLastPInvokeError().ThrowPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if it equals not in the supplied values list. The specified value is used as an error code itself.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value.</param>
	/// <param name="successfulValues">A list of successfull values.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiErrorCodeInList(this uint result, params uint[] successfulValues) =>
		Array.IndexOf(successfulValues, result) >= 0 ? result : throw result.ThrowPlatformException();

	/// <summary>
	/// Throws a new instance <see cref="Win32Exception"/> with the specified error code.
	/// </summary>
	/// <param name="errorCode">A WinAPI function INT error code</param>
	/// <returns>A new instance of the <see cref="Win32Exception"/>class</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[DoesNotReturn]
	public static Win32Exception ThrowPlatformException(this int errorCode) =>
		throw new Win32Exception(errorCode);

	/// <summary>
	/// Throws a new instance <see cref="Win32Exception"/> with the specified error code.
	/// </summary>
	/// <param name="errorCode">A WinAPI function DWORD error code</param>
	/// <returns>A new instance of the <see cref="Win32Exception"/>class</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	[DoesNotReturn]
	public static Win32Exception ThrowPlatformException(this uint errorCode) =>
		throw new Win32Exception(unchecked((int)errorCode));
}
