// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.Kernel32;

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the Shell32.dll Windows API library
/// </summary>
public static unsafe class Shell32
{
	/// <summary>
	/// Shell32 library file name
	/// </summary>
	public const string Shell32Lib = "Shell32.dll";

	/// <summary>
	/// Parses a Unicode command line string and returns an array of pointers to the command line arguments, along with a count of such arguments, in a way that is similar to the standard C run-time argv and argc values.
	/// </summary>
	/// <param name="lpCmdLine">Pointer to a null-terminated Unicode string that contains the full command line. If this parameter is an empty string the function returns the path to the current executable file.</param>
	/// <param name="pNumArgs">Pointer to an <see cref="int"/> that receives the number of array elements returned, similar to argc.</param>
	/// <returns>A pointer to an array of LPWSTR values, similar to argv. The calling application must call <see cref="LocalFree"/> function to free the memory used by the argument list when it is no longer needed.
	/// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/shellapi/nf-shellapi-commandlinetoargvw</remarks>
	[DllImport(Shell32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern void* CommandLineToArgv(
		[In] char* lpCmdLine,
		[Out] int* pNumArgs
	);
}
