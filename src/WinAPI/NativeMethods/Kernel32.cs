// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Larin.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the Kernel32.dll Windows API library
/// </summary>
[SupportedOSPlatform("WINDOWS")]
public static class Kernel32
{
	public const string Kernel32Lib = "Kernel32.dll";

	public const nint INVALID_HANDLE_VALUE = -1;

	/// <summary>
	/// Frees the specified local memory object and invalidates its handle.
	/// </summary>
	/// <param name="hMem">A handle to the local memory object. This handle is returned by either the <see cref="LocalAlloc"/> or <see cref="LocalReAlloc"/> function.</param>
	/// <returns>If the function succeeds, the return value is NULL.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-localfree</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint LocalFree([In] nint hMem);
}
