// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.Crypt32;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;
using static LarinLive.WinAPI.NativeMethods.Kernel32;

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the Advapi32.dll Windows API library
/// </summary>
public static unsafe partial class Advapi32
{
	/// <summary>
	/// Advapi32 library file name
	/// </summary>
	public const string Advapi32Lib = "Advapi32.dll";


	/// <summary>
	/// Acquires a handle to a particular key container within a particular cryptographic service provider (CSP). This returned handle is used in calls to CryptoAPI functions that use the selected CSP.
	/// </summary>
	/// <param name="phProv">A pointer to a handle of a CSP. When you have finished using the CSP, release the handle by calling the <see cref="CryptReleaseContext"/> function.</param>
	/// <param name="szContainer">The key container name. This is a null-terminated string that identifies the key container to the CSP. This name is independent of the method used to store the keys. 
	/// Some CSPs store their key containers internally (in hardware), some use the system registry, and others use the file system. 
	/// In most cases, when dwFlags is set to <see cref="CRYPT_VERIFYCONTEXT"/>, pszContainer must be set to NULL. 
	/// However, for hardware-based CSPs, such as a smart card CSP, can be access publicly available information in the specfied container.</param>
	/// <param name="szProvider">A null-terminated string that contains the name of the CSP to be used. If this parameter is NULL, the user default provider is used.</param>
	/// <param name="dwProvType">Specifies the type of provider to acquire.</param>
	/// <param name="dwFlags">One or more of flags. Note, most applications should set the <see cref="CRYPT_VERIFYCONTEXT"/> flag unless they need to create digital signatures or decrypt messages.</param>
	/// <returns></returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptacquirecontextw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool CryptAcquireContextW(
		[Out] nint* phProv,
		[In] char* szContainer,
		[In] char* szProvider,
		[In] uint dwProvType,
		[In] uint dwFlags
	);


	/// <summary>
	/// The provider type supports both digital signatures and data encryption. It is considered a general purpose CSP. The RSA public key algorithm is used for all public key operations.
	/// </summary>
	public const uint PROV_RSA_FULL = 1;

	/// <summary>
	/// The provider type supports both digital signatures and data encryption. It is considered a general purpose cryptographic service provider (CSP). The RSA public key algorithm is used for all public key operations.
	/// </summary>
	public const uint PROV_RSA_AES = 24;

	/// <summary>
	/// This option is intended for applications that are using ephemeral keys, or applications that do not require access to persisted private keys, 
	/// such as applications that perform only hashing, encryption, and digital signature verification. Only applications that create signatures or decrypt messages need access to a private key. 
	/// In most cases, this flag should be set.
	/// </summary>
	public const uint CRYPT_VERIFYCONTEXT = 0xF0000000;

	/// <summary>
	/// Creates a new key container with the name specified by szContainer. If szContainer is NULL, a key container with the default name is created.
	/// </summary>
	public const uint CRYPT_NEWKEYSET = 0x00000008;

	/// <summary>
	/// By default, keys and key containers are stored as user keys. For Base Providers, this means that user key containers are stored in the user's profile. 
	/// A key container created without this flag by an administrator can be accessed only by the user creating the key container and a user with administration privileges.
	/// Windows XP: A key container created without this flag by an administrator can be accessed only by the user creating the key container and the local system account.
	/// </summary>
	public const uint CRYPT_MACHINE_KEYSET = 0x00000020;

	/// <summary>
	/// Delete the key container specified by szContainer. If szContainer is NULL, the key container with the default name is deleted. All key pairs in the key container are also destroyed.
	/// </summary>
	public const uint CRYPT_DELETEKEYSET = 0x00000010;

	/// <summary>
	/// The application requests that the CSP not display any user interface (UI) for this context. If the CSP must display the UI to operate, 
	/// the call fails and the <see cref="NTE_SILENT_CONTEXT"/> error code is set as the last error. 
	/// In addition, if calls are made to <see cref="CryptGenKey"/> with the <see cref="CRYPT_USER_PROTECTED"/> flag with a context that has been acquired with the <see cref="CRYPT_SILENT"/> flag, 
	/// the calls fail and the CSP sets <see cref="NTE_SILENT_CONTEXT"/>.
	/// </summary>
	public const uint CRYPT_SILENT = 0x00000040;
	
	/// <summary>
	/// Obtains a context for a smart card CSP that can be used for hashing and symmetric key operations but cannot be used for any operation that requires authentication to a smart card using a PIN. 
	/// This type of context is most often used to perform operations on an empty smart card, such as setting the PIN by using <see cref="CryptSetProvParam"/>. This flag can only be used with smart card CSPs.
	/// </summary>
	public const uint CRYPT_DEFAULT_CONTAINER_OPTIONAL = 0x00000080;


	/// <summary>
	/// The <see cref="CryptGenKey"/> function generates a random cryptographic session key or a public/private key pair.
	/// </summary>
	/// <param name="hProv">A handle to a cryptographic service provider (CSP) created by a call to <see cref="CryptAcquireContextW"/>.</param>
	/// <param name="Algid">An ALG_ID value that identifies the algorithm for which the key is to be generated. Values for this parameter vary depending on the CSP used.</param>
	/// <param name="dwFlags">Specifies the type of key generated. The sizes of a session key, RSA signature key, and RSA key exchange keys can be set when the key is generated. 
	/// The key size, representing the length of the key modulus in bits, is set with the upper 16 bits of this parameter. 
	/// Thus, if a 2,048-bit RSA signature key is to be generated, the value 0x08000000 is combined with any other dwFlags predefined value with a bitwise-OR operation. 
	/// The upper 16 bits of 0x08000000 is 0x0800, or decimal 2,048. The RSA1024BIT_KEY value can be used to specify a 1024-bit RSA key.</param>
	/// <param name="phKey">Address to which the function copies the handle of the newly generated key.
	/// When you have finished using the key, delete the handle to the key by calling the <see cref="CryptDestroyKey"/> function.</param>
	/// <returns>Returns nonzero if successful or zero otherwise. For extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptgenkey</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool CryptGenKey(
		[In] nint hProv,
		[In] uint Algid,
		[In] uint dwFlags,
		[Out] nint* phKey
	);

	#region Possible values for the CryptGenKey.dwFlags parameter

	/// <summary>
	/// If this flag is set, the key can be exported until its handle is closed by a call to CryptDestroyKey. 
	/// This allows newly generated keys to be exported upon creation for archiving or key recovery. After the handle is closed, the key is no longer exportable.
	/// </summary>
	public const uint CRYPT_ARCHIVABLE = 0x00004000;

	/// <summary>
	/// If this flag is set, then the key is assigned a random salt value automatically. You can retrieve this salt value by using the <see cref="CryptGetKeyParam"/> function with the dwParam parameter set to KP_SALT.
	/// If this flag is not set, then the key is given a salt value of zero.
	/// </summary>
	public const uint CRYPT_CREATE_SALT = 0x00000004;

	/// <summary>
	/// If this flag is set, then the key can be transferred out of the CSP into a key BLOB by using the CryptExportKey function. 
	/// Because session keys generally must be exportable, this flag should usually be set when they are created.
	/// If this flag is not set, then the key is not exportable. For a session key, this means that the key is available only within the current session and only the application that created it will be able to use it.
	/// For a public/private key pair, this means that the private key cannot be transported or backed up. 
	/// This flag applies only to session key and private key BLOBs. It does not apply to public keys, which are always exportable.
	/// </summary>
	public const uint CRYPT_EXPORTABLE = 0x00000001;

	/// <summary>
	/// This flag specifies strong key protection. When this flag is set, the user is prompted to enter a password for the key when the key is created. 
	/// The user will be prompted to enter the password whenever this key is used. This flag is only used by the CSPs that are provided by Microsoft.
	/// Third party CSPs will define their own behavior for strong key protection. 
	/// Specifying this flag causes the same result as calling this function with the <see cref="CRYPT_USER_PROTECTED"/> flag when strong key protection is specified in the system registry.
	/// </summary>
	public const uint CRYPT_FORCE_KEY_PROTECTION_HIGH = 0x00008000;

	/// <summary>
	/// This flag specifies that a no salt value gets allocated for a forty-bit symmetric key.
	/// </summary>
	public const uint CRYPT_NO_SALT = 0x00000010;

	/// <summary>
	/// This flag specifies an initial Diffie-Hellman or DSS key generation. This flag is useful only with Diffie-Hellman and DSS CSPs. 
	/// When used, a default key length will be used unless a key length is specified in the upper 16 bits of the dwFlags parameter. 
	/// If parameters that involve key lengths are set on a PREGEN Diffie-Hellman or DSS key using <see cref="CryptSetKeyParam"/>, the key lengths must be compatible with the key length set here.
	/// </summary>
	public const uint CRYPT_PREGEN = 0x00000040;

	/// <summary>
	///	If this flag is set, the user is notified through a dialog box or another method when certain actions are attempting to use this key. The precise behavior is specified by the CSP being used. 
	///	If the provider context was opened with the CRYPT_SILENT flag set, using this flag causes a failure and the last error is set to <see cref="NTE_SILENT_CONTEXT"/>.
	/// </summary>
	public const uint CRYPT_USER_PROTECTED = 0x00000002;

	#endregion

	/// <summary>
	/// Releases the handle referenced by the hKey parameter. After a key handle has been released, it is no longer valid and cannot be used again.
	/// </summary>
	/// <param name="hKey">The handle of the key to be destroyed.</param>
	/// <returns>Returns nonzero if successful or zero otherwise. For extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/wincrypt/nf-wincrypt-cryptdestroykey</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool CryptDestroyKey(
		[In] nint hKey
	);

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
	/// Specifies that the CSP must exclusively use the hardware random number generator (RNG). When <see cref="PP_USE_HARDWARE_RNG"/> is set, random values are taken exclusively from the hardware RNG and no other sources are used. 
	/// If a hardware RNG is supported by the CSP and it can be exclusively used, the function succeeds and returns TRUE; otherwise, the function fails and returns FALSE. 
	/// The pbData parameter must be NULL and dwFlags must be zero when using this value.
	/// </summary>
	public const uint PP_USE_HARDWARE_RNG = 38;

	/// <summary>
	/// Specifies the user certificate store for the smart card. This certificate store contains all of the user certificates that are stored on the smart card. 
	/// The certificates in this store are encoded by using <see cref="PKCS_7_ASN_ENCODING"/> or <see cref="X509_ASN_ENCODING"/> encoding and should contain the <see cref="CERT_KEY_PROV_INFO_PROP_ID"/> property.		
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
}
