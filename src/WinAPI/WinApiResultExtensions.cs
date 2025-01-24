// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.ComponentModel;
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
	/// Checks a specified WinAPI BOOL return value and throws the <see cref="Win32Exception"/> if the former is FALSE.
	/// </summary>
	/// <param name="result">A WinAPI function boolean return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool VerifyWinapiTrue(this bool result) =>
		result ? result : throw Marshal.GetLastPInvokeError().NewPlatformException();

	/// <summary>
	/// Checks a specified WinAPI BOOL return value and throws the <see cref="Win32Exception"/> if the former is TRUE.
	/// </summary>
	/// <param name="result">A WinAPI function boolean return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool VerifyWinapiFalse(this bool result) =>
		!result ? result : throw Marshal.GetLastPInvokeError().NewPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if the former is zero.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value</param>
	/// <param name="resultIsErrorCode">Set to <see langword="true"/> if a result is an error code itself.</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiNonzero(this uint result, bool resultIsErrorCode) =>
		result != 0 ? result : throw (resultIsErrorCode ? result : (uint)Marshal.GetLastPInvokeError()).NewPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if the former is non-zero. The specified value is used as an error code itself.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value</param>
	/// <param name="resultIsErrorCode">Set to <see langword="true"/> if a result is an error code itself.</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiZero(this uint result, bool resultIsErrorCode) =>
		result == 0 ? result : throw (resultIsErrorCode ? result : (uint)Marshal.GetLastPInvokeError()).NewPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if the former is zero.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value</param>
	/// <param name="resultIsErrorCode">Set to <see langword="true"/> if a result is an error code itself.</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int VerifyWinapiNonzero(this int result, bool resultIsErrorCode) =>
		result != 0 ? result : throw (resultIsErrorCode ? result : Marshal.GetLastPInvokeError()).NewPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if the former is non-zero. The specified value is used as an error code itself.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value.</param>
	/// <param name="resultIsErrorCode">Set to <see langword="true"/> if a result is an error code itself.</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int VerifyWinapiZero(this int result, bool resultIsErrorCode) =>
		result == 0U ? result : throw (resultIsErrorCode ? result : Marshal.GetLastPInvokeError()).NewPlatformException();

	/// <summary>
	/// Checks a specified WinAPI INT_PTR return value and throws the <see cref="Win32Exception"/> if the former is zero.
	/// </summary>
	/// <param name="result">A WinAPI function INT_PTR return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiNonzero(this nint result) =>
		result != 0 ? result : throw Marshal.GetLastPInvokeError().NewPlatformException();

	/// <summary>
	/// Checks a specified WinAPI INT_PTR return value and throws the <see cref="Win32Exception"/> if the former is non-zero.
	/// </summary>
	/// <param name="result">A WinAPI function INT_PTR return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiZero(this nint result) =>
		result == 0 ? result : throw Marshal.GetLastPInvokeError().NewPlatformException();

	/// <summary>
	/// Checks a specified WinAPI INT_PTR return value and throws the <see cref="Win32Exception"/> if the former is <see cref="INVALID_HANDLE_VALUE"/>.
	/// </summary>
	/// <param name="resut">A WinAPI function INT_PTR return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiValidHandle(this nint resut) =>
		resut != INVALID_HANDLE_VALUE ? resut : throw Marshal.GetLastPInvokeError().NewPlatformException();

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if it is not in the supplied values list. The specified value is used as an error code itself.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value.</param>
	/// <param name="resultIsErrorCode">Set to <see langword="true"/> if a result is an error code itself.</param>
	/// <param name="successfulValues">A list of successfull values.</param>
	/// <returns>The same input value.</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiInList(this uint result, bool resultIsErrorCode, params uint[] successfulValues) =>
		Array.IndexOf(successfulValues, result) >= 0 ? result : throw (resultIsErrorCode ? result : (uint)Marshal.GetLastPInvokeError()).NewPlatformException();

	/// <summary>
	/// Creates a new instance <see cref="Win32Exception"/> with the specified error code.
	/// </summary>
	/// <param name="errorCode">A WinAPI function INT error code</param>
	/// <returns>A new instance of the <see cref="Win32Exception"/>class</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Win32Exception NewPlatformException(this int errorCode) =>
		new(errorCode);

	/// <summary>
	/// Creates a new instance <see cref="Win32Exception"/> with the specified error code.
	/// </summary>
	/// <param name="errorCode">A WinAPI function DWORD error code</param>
	/// <returns>A new instance of the <see cref="Win32Exception"/>class</returns>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static Win32Exception NewPlatformException(this uint errorCode) =>
		new(unchecked((int)errorCode));
}
