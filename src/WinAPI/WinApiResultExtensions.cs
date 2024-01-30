// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Larin.WinAPI.NativeMethods.Kernel32;

namespace Larin.WinAPI;

/// <summary>
/// Extension methods for checking WinAPI result values
/// </summary>
public static class WinApiResultExtensions
{
	/// <summary>
	/// Checks a specified WinAPI BOOL return value and throws the <see cref="Win32Exception"/> if the former is FALSE.
	/// </summary>
	/// <param name="input">A WinAPI function boolean return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool VerifyWinapiTrue(this bool input) =>
		input ? input : throw new Win32Exception(Marshal.GetLastPInvokeError());

	/// <summary>
	/// Checks a specified WinAPI INT_PTR return value and throws the <see cref="Win32Exception"/> if the former is zero.
	/// </summary>
	/// <param name="input">A WinAPI function INT_PTR return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiNonzero(this nint input) =>
		input != 0 ? input : throw new Win32Exception(Marshal.GetLastPInvokeError());

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if the former is zero.
	/// </summary>
	/// <param name="input">A WinAPI function DWORD return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiNonzero(this uint input) =>
		input != 0 ? input : throw new Win32Exception(Marshal.GetLastPInvokeError());

	/// <summary>
	/// Checks a specified WinAPI INT_PTR return value and throws the <see cref="Win32Exception"/> if the former is non-zero.
	/// </summary>
	/// <param name="input">A WinAPI function INT_PTR return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiZero(this nint input) =>
		input == 0 ? input : throw new Win32Exception(Marshal.GetLastPInvokeError());

	/// <summary>
	/// Checks a specified WinAPI INT_PTR return value and throws the <see cref="Win32Exception"/> if the former is <see cref="INVALID_HANDLE_VALUE"/>.
	/// </summary>
	/// <param name="input">A WinAPI function INT_PTR return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiValidHandle(this nint input) =>
		input != INVALID_HANDLE_VALUE ? input : throw new Win32Exception(Marshal.GetLastPInvokeError());

	/// <summary>
	/// Checks a specified WinAPI INT return value and throws the <see cref="Win32Exception"/> if the former is non-zero. The specified value is used as an error code itself.
	/// </summary>
	/// <param name="result">A WinAPI function INT return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int VerifyWinapiZeroItself(this int result) =>
		result == 0 ? result : throw new Win32Exception(result);

	/// <summary>
	/// Checks a specified WinAPI DWORD return value and throws the <see cref="Win32Exception"/> if the former is non-zero. The specified value is used as an error code itself.
	/// </summary>
	/// <param name="result">A WinAPI function DWORD return value</param>
	/// <returns>The same input value</returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiZeroItself(this uint result) =>
		result == 0U ? result : throw new Win32Exception(unchecked((int)result));

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
