// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using Microsoft.Win32;
using System.Runtime.InteropServices;
using static Larin.WinAPI.NativeMethods.Crypt32;
using static Larin.WinAPI.NativeMethods.ErrorCodes;
using static Larin.WinAPI.NativeMethods.Kernel32;

namespace Larin.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the Advapi32.dll Windows API library
/// </summary>
public static unsafe class Advapi32
{
	/// <summary>
	/// Advapi32 library file name
	/// </summary>
	public const string Advapi32Lib = "Advapi32.dll";

	/// <summary>
	/// The CryptReleaseContext function releases the handle of a cryptographic service provider (CSP) and a key container.
	/// At each call to this function, the reference count on the CSP is reduced by one. When the reference count reaches zero,
	/// the context is fully released and it can no longer be used by any function in the application.
	/// </summary>
	/// <param name="hProv">Handle of a cryptographic service provider (CSP) created by a call to CryptAcquireContext</param>
	/// <param name="dwFlags">Reserved for future use and must be zero. If dwFlags is not set to zero, this function returns FALSE but the CSP is released.</param>
	/// <returns></returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptreleasecontext</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool CryptReleaseContext(
		[In] nint hProv,
		[In] uint dwFlags
	);


	/// <summary>
	/// Customizes the operations of a cryptographic service provider (CSP). This function is commonly used to set a security descriptor on the key container associated with a CSP to control access to the private keys in that key container.
	/// </summary>
	/// <param name="hProv">The handle of a CSP for which to set values. </param>
	/// <param name="dwParam">Specifies the parameter to set.</param>
	/// <param name="pvData">A pointer to a data buffer that contains the value to be set as a provider parameter. The form of this data varies depending on the dwParam value.</param>
	/// <param name="dwFlags">If dwParam contains PP_KEYSET_SEC_DESCR, dwFlags contains the SECURITY_INFORMATION applicable bit flags, as defined in the Platform SDK.</param>
	/// <returns>If the function succeeds, the return value is nonzero (TRUE). If the function fails, the return value is zero (FALSE). For extended error information, call GetLastError.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptsetprovparam</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool CryptSetProvParam(
		[In] nint hProv,
		[In] uint dwParam,
		[In] void* pvData,
		[In] uint dwFlags
	);

	/// <summary>
	/// Set the window handle that the provider uses as the parent of any dialog boxes it creates. pbData contains a pointer to an HWND that contains the parent window handle.
	/// This parameter must be set before calling CryptAcquireContext because many CSPs will display a user interface when CryptAcquireContext is called. 
	/// You can pass NULL for the hProv parameter to set this window handle for all cryptographic contexts subsequently acquired within this process.
	/// </summary>
	public const uint PP_CLIENT_HWND = 1;

	/// <summary>
	/// Sets the security descriptor on the key storage container. The pbData parameter is the address of a SECURITY_DESCRIPTOR structure that contains the new security descriptor for the key storage container.
	/// </summary>
	public const uint PP_KEYSET_SEC_DESCR = 8;

	/// <summary>
	/// For a smart card provider, sets the search string that is displayed to the user as a prompt to insert the smart card. 
	/// This string is passed as the lpstrSearchDesc member of the OPENCARDNAME_EX structure that is passed to the SCardUIDlgSelectCard function. 
	/// This string is used for the lifetime of the calling process. The pbData parameter is a pointer to a null-terminated Unicode string.
	/// </summary>
	public const uint PP_UI_PROMPT = 21;

	/// <summary>
	/// Delete the ephemeral key associated with a hash, encryption, or verification context. This will free memory and clear registry settings associated with the key.
	/// </summary>
	public const uint PP_DELETEKEY = 24;

	/// <summary>
	/// Specifies that the key exchange PIN is contained in pbData. The PIN is represented as a null-terminated ASCII string.
	/// </summary>
	public const uint PP_KEYEXCHANGE_PIN = 32;

	/// <summary>
	/// Specifies the signature PIN. The pbData parameter is a null-terminated ASCII string that represents the PIN.
	/// </summary>
	public const uint PP_SIGNATURE_PIN = 33;

	/// <summary>
	/// Specifies that the CSP must exclusively use the hardware random number generator (RNG). When PP_USE_HARDWARE_RNG is set, random values are taken exclusively from the hardware RNG and no other sources are used. 
	/// If a hardware RNG is supported by the CSP and it can be exclusively used, the function succeeds and returns TRUE; otherwise, the function fails and returns FALSE. 
	/// The pbData parameter must be NULL and dwFlags must be zero when using this value.
	/// </summary>
	public const uint PP_USE_HARDWARE_RNG = 38;

	/// <summary>
	/// Specifies the user certificate store for the smart card. This certificate store contains all of the user certificates that are stored on the smart card. 
	/// The certificates in this store are encoded by using PKCS_7_ASN_ENCODING or X509_ASN_ENCODING encoding and should contain the CERT_KEY_PROV_INFO_PROP_ID property.		
	/// The pbData parameter is an HCERTSTORE variable that receives the handle of an in-memory certificate store. When this handle is no longer needed, the caller must close it by using the CertCloseStore function.
	/// </summary>
	public const uint PP_USER_CERTSTORE = 42;

	/// <summary>
	/// Specifies the name of the smart card reader. The pbData parameter is the address of an ANSI character array that contains a null-terminated ANSI string that contains the name of the smart card reader.
	/// </summary>
	public const uint PP_SMARTCARD_READER = 43;

	/// <summary>
	/// Sets an alternate prompt string to display to the user when the user's PIN is requested. The pbData parameter is a pointer to a null-terminated Unicode string.
	/// </summary>
	public const uint PP_PIN_PROMPT_STRING = 44;

	/// <summary>
	/// Specifies the identifier of the smart card. The pbData parameter is the address of a GUID structure that contains the identifier of the smart card.
	/// </summary>
	public const uint PP_SMARTCARD_GUID = 45;

	/// <summary>
	/// Sets the root certificate store for the smart card. The provider will copy the root certificates from this store onto the smart card.
	/// The pbData parameter is an HCERTSTORE variable that contains the handle of the new certificate store. 
	/// The provider will copy the certificates from the store during this call, so it is safe to close this store after this function is called.
	/// </summary>
	public const uint PP_ROOT_CERTSTORE = 46;

	/// <summary>
	/// Specifies that an encrypted key exchange PIN is contained in pbData. The pbData parameter contains a <see cref="CRYPT_INTEGER_BLOB"/>.
	/// </summary>
	public const uint PP_SECURE_KEYEXCHANGE_PIN = 47;

	/// <summary>
	/// pecifies that an encrypted signature PIN is contained in pbData. The pbData parameter contains a <see cref="CRYPT_INTEGER_BLOB"/>.
	/// </summary>
	public const uint PP_SECURE_SIGNATURE_PIN = 48;


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
