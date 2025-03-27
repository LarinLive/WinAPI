// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;
using static LarinLive.WinAPI.NativeMethods.Kernel32;

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the Advapi32.dll Windows API library
/// </summary>
public static unsafe partial class Advapi32
{

	/// <summary>
	/// Loads the specified string from the specified key and subkey.
	/// </summary>
	/// <param name="hKey">A handle to an open registry key. The key must have been opened with the <see cref="KEY_QUERY_VALUE"/> access right.
	/// This handle is returned by the RegCreateKeyEx or RegOpenKeyEx function.</param>
	/// <param name="pszValue">The name of the registry value.</param>
	/// <param name="pszOutBuf">A pointer to a buffer that receives the string. 
	/// Strings of the following form receive special handling: @[path]\dllname,-strID
	/// The string with identifier strID is loaded from dllname; the path is optional. If the pszDirectory parameter is not NULL, the directory is prepended to the path specified in the registry data.
	/// Note that dllname can contain environment variables to be expanded.</param>
	/// <param name="cbOutBuf">The size of the pszOutBuf buffer, in bytes.</param>
	/// <param name="pcbData">A pointer to a variable that receives the size of the data copied to the pszOutBuf buffer, in bytes.
	/// If the buffer is not large enough to hold the data, the function returns <see cref="ERROR_MORE_DATA"/> and stores the required buffer size in the variable pointed to by pcbData.
	/// In this case, the contents of the buffer are undefined.</param>
	/// <param name="Flags">Optional flags</param>
	/// <param name="pszDirectory">The directory path.</param>
	/// <returns>If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code.
	/// If the pcbData buffer is too small to receive the string, the function returns <see cref="ERROR_MORE_DATA"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winreg/nf-winreg-regloadmuistringw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint RegLoadMUIString(
		[In] nint hKey,
		[In, Optional] char* pszValue,
		[Out, Optional] char* pszOutBuf,
		[In] uint cbOutBuf,
		[Out, Optional] uint* pcbData,
		[In] uint Flags,
		[In, Optional] char* pszDirectory
	);

	#region Registry Key Security and Access Rights (https://learn.microsoft.com/en-us/windows/win32/sysinfo/registry-key-security-and-access-rights)

	/// <summary>
	/// Combines the <see cref="STANDARD_RIGHTS_REQUIRED"/>, <see cref="KEY_QUERY_VALUE"/>, <see cref="KEY_SET_VALUE"/>, <see cref="KEY_CREATE_SUB_KEY"/>, <see cref="KEY_ENUMERATE_SUB_KEYS"/>, <see cref="KEY_NOTIFY"/>, and <see cref="KEY_CREATE_LINK"/> access rights.
	/// </summary>
	public const uint KEY_ALL_ACCESS = 0x0000F003F;

	/// <summary>
	/// Reserved for system use.
	/// </summary>
	public const uint KEY_CREATE_LINK = 0x0000F003F;

	/// <summary>
	/// Required to create a subkey of a registry key.
	/// </summary>
	public const uint KEY_CREATE_SUB_KEY = 0x0020;

	/// <summary>
	/// Required to enumerate the subkeys of a registry key.
	/// </summary>
	public const uint KEY_ENUMERATE_SUB_KEYS = 0x0008;

	/// <summary>
	/// Equivalent to <see cref="KEY_READ"/>.
	/// </summary>
	public const uint KEY_EXECUTE = 0x20019;

	/// <summary>
	/// Required to request change notifications for a registry key or for subkeys of a registry key.
	/// </summary>
	public const uint KEY_NOTIFY = 0x0010;

	/// <summary>
	/// Required to query the values of a registry key.
	/// </summary>
	public const uint KEY_QUERY_VALUE = 0x0001;

	/// <summary>
	/// Combines the <see cref="STANDARD_RIGHTS_READ"/>, <see cref="KEY_QUERY_VALUE"/>, <see cref="KEY_ENUMERATE_SUB_KEYS"/>, and <see cref="KEY_NOTIFY"/> values.
	/// </summary>
	public const uint KEY_READ = 0x20019;

	/// <summary>
	///Required to create, delete, or set a registry value.
	/// </summary>
	public const uint KEY_SET_VALUE = 0x0200;

	/// <summary>
	/// Indicates that an application on 64-bit Windows should operate on the 32-bit registry view. This flag is ignored by 32-bit Windows. 
	/// This flag must be combined using the OR operator with the other flags in this table that either query or access registry values.
	/// </summary>
	public const uint KEY_WOW64_32KEY = 0x0200;

	/// <summary>
	/// Indicates that an application on 64-bit Windows should operate on the 64-bit registry view. This flag is ignored by 32-bit Windows. 
	/// This flag must be combined using the OR operator with the other flags in this table that either query or access registry values.
	/// </summary>
	public const uint KEY_WOW64_64KEY = 0x0100;

	/// <summary>
	/// Combines the <see cref="STANDARD_RIGHTS_WRITE"/>, <see cref="KEY_SET_VALUE"/>, and <see cref="KEY_CREATE_SUB_KEY"/> access rights.
	/// </summary>
	public const uint KEY_WRITE = 0x00020006;

	#endregion

	#region Possible values for the RegLoadMUIString.Flags parameter

	/// <summary>
	/// The string is truncated to fit the available size of the pszOutBuf buffer. If this flag is specified, pcbData must be NULL.
	/// </summary>
	public const uint REG_MUI_STRING_TRUNCATE = 0x00000001;

	#endregion
}
