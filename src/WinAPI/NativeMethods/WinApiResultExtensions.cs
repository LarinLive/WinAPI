// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Larin.WinAPI.NativeMethods;

/// <summary>
/// Extension methods for checking WinAPI result values
/// </summary>
public static class WinApiResultExtensions
{
	/// <summary>
	/// 
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static bool VerifyWinapiTrue(this bool input)
	{
		return input ? input : throw new Win32Exception(Marshal.GetLastPInvokeError());
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiNonzero(this nint input)
	{
		return input != 0 ? input : throw new Win32Exception(Marshal.GetLastPInvokeError());
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiNonzero(this uint input)
	{
		return input != 0 ? input : throw new Win32Exception(Marshal.GetLastPInvokeError());
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="input"></param>
	/// <returns></returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static nint VerifyWinapiZero(this nint input)
	{
		return input == 0 ? input : throw new Win32Exception(Marshal.GetLastPInvokeError());
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="result"></param>
	/// <returns></returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static int VerifyWinapiZeroItself(this int result)
	{
		return result == 0 ? result : throw new Win32Exception(result);
	}

	/// <summary>
	/// 
	/// </summary>
	/// <param name="result"></param>
	/// <returns></returns>
	/// <exception cref="Win32Exception"></exception>
	[MethodImpl(MethodImplOptions.AggressiveInlining)]
	public static uint VerifyWinapiZeroItself(this uint result)
	{
		return result == 0U ? result : throw new Win32Exception(unchecked((int)result));
	}
}
