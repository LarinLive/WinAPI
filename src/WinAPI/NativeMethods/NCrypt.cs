// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.BCrypt;
using static LarinLive.WinAPI.NativeMethods.Crypt32;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the NCrypt.dll Windows API library
/// </summary>
public static unsafe class NCrypt
{
	/// <summary>
	/// NCrypt library file name
	/// </summary>
	public const string NCryptLib = "NCrypt.dll";

	/// <summary>
	/// Decrypts a block of encrypted data.
	/// </summary>
	/// <param name="hKey">The handle of the key to use to decrypt the data.</param>
	/// <param name="pbInput">The address of a buffer that contains the data to be decrypted. The cbInput parameter contains the size of the data to decrypt.</param>
	/// <param name="cbInput">The number of bytes in the pbInput buffer to decrypt.</param>
	/// <param name="pPaddingInfo">A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the value of the dwFlags parameter. 
	/// This parameter is only used with asymmetric keys and must be NULL otherwise.</param>
	/// <param name="pbOutput">The address of a buffer that will receive the decrypted data produced by this function. The cbOutput parameter contains the size of this buffer. 
	/// If this parameter is NULL, this function will calculate the size needed for the decrypted data and return the size in the location pointed to by the pcbResult parameter.</param>
	/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is NULL.</param>
	/// <param name="pcbResult">A pointer to a DWORD variable that receives the number of bytes copied to the pbOutput buffer. If pbOutput is NULL, this receives the size, in bytes, required for the decrypted data.</param>
	/// <param name="dwFlags">Flags that modify function behavior. The allowed set of flags depends on the type of key specified by the hKey parameter.</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptdecrypt</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptDecrypt(
		[In] nint hKey,
		[In] void* pbInput,
		[In] uint cbInput,
		[In, Optional] void* pPaddingInfo,
		[Out] void* pbOutput,
		[In] uint cbOutput,
		[Out] uint* pcbResult,
		[In] uint dwFlags
	);

	/// <summary>
	/// Encrypts a block of data.
	/// </summary>
	/// <param name="hKey">The handle of the key to use to encrypt the data.</param>
	/// <param name="pbInput">The address of a buffer that contains the data to be encrypted. The cbInput parameter contains the size of the data to encrypt.</param>
	/// <param name="cbInput">The number of bytes in the pbInput buffer to encrypt.</param>
	/// <param name="pPaddingInfo">A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the value of the dwFlags parameter. 
	/// This parameter is only used with asymmetric keys and must be NULL otherwise.</param>
	/// <param name="pbOutput">The address of a buffer that will receive the encrypted data produced by this function. The cbOutput parameter contains the size of this buffer. 
	/// If this parameter is NULL, this function will calculate the size needed for the encrypted data and return the size in the location pointed to by the pcbResult parameter.</param>
	/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer. This parameter is ignored if the pbOutput parameter is NULL.</param>
	/// <param name="pcbResult">A pointer to a DWORD variable that receives the number of bytes copied to the pbOutput buffer. If pbOutput is NULL, this receives the size, in bytes, required for the ciphertext.</param>
	/// <param name="dwFlags">Flags that modify function behavior.</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptencrypt</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptEncrypt(
		[In] nint hKey,
		[In] void* pbInput,
		[In] uint cbInput,
		[In, Optional] void* pPaddingInfo,
		[Out] void* pbOutput,
		[In] uint cbOutput,
		[Out] uint* pcbResult,
		[In] uint dwFlags
	);

	#region The NCryptEncrypt.dwFlags and NCryptDecrypt.dwFlags allowed values

	/// <summary>
	///	No padding was used when the data was encrypted. The pPaddingInfo parameter is not used.
	/// </summary>
	public const uint NCRYPT_NO_PADDING_FLAG = 0x00000001;

	/// <summary>
	///	The Optimal Asymmetric Encryption Padding (OAEP) scheme was used when the data was encrypted. The pPaddingInfo parameter is a pointer to a <see cref="BCRYPT_OAEP_PADDING_INFO"/> structure.
	/// </summary>
	public const uint NCRYPT_PAD_OAEP_FLAG = 0x00000004;

	/// <summary>
	/// The data was padded with a random number to round out the block size when the data was encrypted. The pPaddingInfo parameter is not used.
	/// </summary>
	public const uint NCRYPT_PAD_PKCS1_FLAG = 0x00000002;

	#endregion

	/// <summary>
	/// Obtains the names of the keys that are stored by the provider.
	/// </summary>
	/// <param name="hProvider">The handle of the key storage provider to enumerate the keys for. This handle is obtained with the <see cref="NCryptOpenStorageProvider"/> function.</param>
	/// <param name="pszScope">This parameter is not currently used and must be NULL.</param>
	/// <param name="ppKeyName">The address of a pointer to an <see cref="NCryptKeyName"/> structure that receives the name of the retrieved key.
	/// When the application has finished using this memory, free it by calling the <see cref="NCryptFreeBuffer"/> function.</param>
	/// <param name="ppEnumState">The address of a VOID pointer that receives enumeration state information that is used in subsequent calls to this function. 
	/// This information only has meaning to the key storage provider and is opaque to the caller. The key storage provider uses this information to determine which item is next in the enumeration. 
	/// If the variable pointed to by this parameter contains NULL, the enumeration is started from the beginning.
	/// When this memory is no longer needed, it must be freed by passing this pointer to the <see cref="NCryptFreeBuffer"/> function.</param>
	/// <param name="dwFlags">Flags that modify function behavior.</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptenumkeys</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptEnumKeys(
		[In] nint hProvider,
		[In, Optional] char* pszScope,
		[Out] NCryptKeyName** ppKeyName,
		[In, Out] void* ppEnumState,
		[In] uint dwFlags
	);

	/// <summary>
	/// The structure is used to contain information about a CNG key.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/ns-ncrypt-ncryptkeyname</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct NCryptKeyName
	{
		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the name of the key.
		/// </summary>
		public char* pszName;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the identifier of the cryptographic algorithm that the key was created with.
		/// </summary>
		public char* pszAlgid;

		/// <summary>
		/// A legacy identifier that specifies the type of key.
		/// </summary>
		public uint dwLegacyKeySpec;

		/// <summary>
		/// A set of flags that provide more information about the key.
		/// </summary>
		public uint dwFlags;
	}

	/// <summary>
	/// Obtains the names of the registered key storage providers.
	/// </summary>
	/// <param name="pdwProviderCount">The address of a DWORD to receive the number of elements in the ppProviderList array.</param>
	/// <param name="ppProviderList">The address of an NCryptProviderName structure pointer to receive an array of the registered key storage provider names. 
	/// The variable pointed to by the pdwProviderCount parameter receives the number of elements in this array.
	/// When this memory is no longer needed, free it by passing this pointer to the <see cref="NCryptFreeBuffer"/> function.</param>
	/// <param name="dwFlags">Flags that modify function behavior.</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptEnumStorageProviders(
		[Out] uint* pdwProviderCount,
		[Out] NCryptProviderName** ppProviderList,
		[In] uint dwFlags
	);

	/// <summary>
	/// Contains the name of a CNG key storage provider. This structure is used with the <see cref="NCryptEnumStorageProviders"/> function to return the names of the registered CNG key storage providers.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/ns-ncrypt-ncryptprovidername</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct NCryptProviderName
	{
		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the name of the provider.
		/// </summary>
		public char* pszName;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains optional text for the provider.
		/// </summary>
		public char* pszComment;
	}

	/// <summary>
	/// Releases a block of memory allocated by a CNG key storage provider.
	/// </summary>
	/// <param name="pvInput">The address of the memory to be released.</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptfreebuffer</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptFreeBuffer(
		[In] void* pvInput
	);

	/// <summary>
	/// Completes a CNG key storage key. The key cannot be used until this function has been called.
	/// </summary>
	/// <param name="hKey">The handle of the key to complete. This handle is obtained by calling the <see cref="NCryptCreatePersistedKey"/> function.</param>
	/// <param name="dwFlags">Flags that modify function behavior. </param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptfinalizekey</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptFinalizeKey(
		[In] nint hKey,
		[In] uint dwFlags
	);

	/// <summary>
	/// Frees a CNG key storage object
	/// </summary>
	/// <param name="hObject">The handle of the object to free. This can be either a provider handle (NCRYPT_PROV_HANDLE) or a key handle (NCRYPT_KEY_HANDLE)</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptfreeobject</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptFreeObject(
		[In] nint hObject
	);

	/// <summary>
	/// Retrieves the value of a named property for a key storage object.
	/// </summary>
	/// <param name="hObject">The handle of the object to get the property for. This can be a provider handle (NCRYPT_PROV_HANDLE) or a key handle (NCRYPT_KEY_HANDLE).</param>
	/// <param name="pszProperty">A pointer to a null-terminated Unicode string that contains the name of the property to retrieve. This can be one of the predefined Key Storage Property Identifiers or a custom property identifier.</param>
	/// <param name="pbOutput">The address of a buffer that receives the property value. The cbOutput parameter contains the size of this buffer. 
	/// To calculate the size required for the buffer, set this parameter to NULL. The size, in bytes, required is returned in the location pointed to by the pcbResult parameter.</param>
	/// <param name="cbOutput">The size, in bytes, of the pbOutput buffer.</param>
	/// <param name="pcbResult">A pointer to a <see cref="uint"/> variable that receives the number of bytes that were copied to the pbOutput buffer.
	/// If the pbOutput parameter is NULL, the size, in bytes, required for the buffer is placed in the location pointed to by this parameter.</param>
	/// <param name="dwFlags">Flags that modify function behavior.</param>
	/// <returns></returns>
	///<remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptgetproperty</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptGetProperty(
		[In] nint hObject,
		[In] char* pszProperty,
		[Out] void* pbOutput,
		[In] uint cbOutput,
		[Out] uint* pcbResult,
		[In] uint dwFlags
	);

	/// <summary>
	/// Opens a key that exists in the specified CNG key storage provider.
	/// </summary>
	/// <param name="hProvider">The handle of the key storage provider to open the key from.</param>
	/// <param name="phKey">A pointer to a NCRYPT_KEY_HANDLE variable that receives the key handle. When you have finished using this handle, release it by passing it to the <see cref="NCryptFreeObject"/> function.</param>
	/// <param name="pszKeyName">A pointer to a null-terminated Unicode string that contains the name of the key to retrieve.</param>
	/// <param name="dwLegacyKeySpec">A legacy identifier that specifies the type of key.</param>
	/// <param name="dwFlags">Flags that modify function behavior.</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptopenkey</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptOpenKey(
		[In] nint hProvider,
		[Out] nint* phKey,
		[In] char* pszKeyName,
		[In] uint dwLegacyKeySpec,
		[In] uint dwFlags
	);

	/// <summary>
	/// Loads and initializes a CNG key storage provider.
	/// </summary>
	/// <param name="phProvider">A pointer to a <see cref="nint"/> variable that receives the provider handle. When you have finished using this handle, release it by passing it to the <see cref="NCryptFreeObject"/> function.</param>
	/// <param name="pszProviderName">A pointer to a null-terminated Unicode string that identifies the key storage provider to load. This is the registered alias of the key storage provider. 
	/// This parameter is optional and can be NULL. If this parameter is NULL, the default key storage provider is loaded.</param>
	/// <param name="dwFlags">Flags that modify the behavior of the function. No flags are defined for this function.</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptopenstorageprovider</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptOpenStorageProvider(
		[Out] nint* phProvider,
		[In, Optional] char* pszProviderName,
		[In] uint dwFlags
	);

	/// <summary>
	/// Identifies the software key storage provider that is provided by Microsoft.
	/// </summary>
	public const string MS_KEY_STORAGE_PROVIDER = "Microsoft Software Key Storage Provider";

	/// <summary>
	/// Identifies the smart card key storage provider that is provided by Microsoft.
	/// </summary>
	public const string MS_SMART_CARD_KEY_STORAGE_PROVIDER = "Microsoft Smart Card Key Storage Provider";

	/// <summary>
	/// Identifies the TPM key storage provider that is provided by Microsoft.
	/// </summary>
	public const string MS_PLATFORM_CRYPTO_PROVIDER = "Microsoft Platform Crypto Provider";

	/// <summary>
	/// Sets the value for a named property for a CNG key storage object.
	/// </summary>
	/// <param name="hObject">The handle of the key storage object to set the property for.</param>
	/// <param name="pszProperty">A pointer to a null-terminated Unicode string that contains the name of the property to set. 
	/// This can be one of the predefined Key Storage Property Identifiers or a custom property identifier.</param>
	/// <param name="pbInput">The address of a buffer that contains the new property value. The cbInput parameter contains the size of this buffer.</param>
	/// <param name="cbInput">The size, in bytes, of the pbInput buffer.</param>
	/// <param name="dwFlags">Flags that modify function behavior.</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptsetproperty</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptSetProperty(
		[In] nint hObject,
		[In] char* pszProperty,
		[In] void* pbInput,
		[In] uint cbInput,
		[In] uint dwFlags
	);

	/// <summary>
	/// Maximum length of property data (in bytes) 
	/// </summary>
	public const uint NCRYPT_MAX_PROPERTY_DATA = 0x100000;

	/// <summary>
	/// Maximum size of a property name, in characters.
	/// </summary>
	public const uint NCRYPT_MAX_PROPERTY_NAME = 64;

	/// <summary>
	/// Do not overwrite any built-in values for this property and only set the user-persisted properties of the key. The maximum size of the data for any persisted property is <see cref="NCRYPT_MAX_PROPERTY_DATA"/> bytes. 
	/// This flag cannot be used with the <see cref="NCRYPT_SECURITY_DESCR_PROPERTY"/> property.
	/// </summary>
	public const uint NCRYPT_PERSIST_ONLY_FLAG = 0x40000000;

	/// <summary>
	/// The property should be stored in key storage along with the key material. This flag can only be used when the hObject parameter is the handle of a persisted key. 
	/// The maximum size of the data for any persisted property is NCRYPT_MAX_PROPERTY_DATA bytes.
	/// </summary>
	public const uint NCRYPT_PERSIST_FLAG = 0x80000000;

	/// <summary>
	///	Do not validate the public portion of the key pair. This flag only applies to public/private key pairs.
	/// </summary>
	public const uint NCRYPT_NO_KEY_VALIDATION = BCRYPT_NO_KEY_VALIDATION;

	/// <summary>
	/// Also save the key in legacy storage. This allows the key to be used with CryptoAPI. This flag only applies to RSA keys.
	/// </summary>
	public const uint NCRYPT_WRITE_KEY_TO_LEGACY_STORE_FLAG = 0x00000200;

	/// <summary>
	/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the <see cref="NTE_SILENT_CONTEXT"/> error code as the last error.
	/// </summary>
	public const uint NCRYPT_SILENT_FLAG = 0x00000040;

	/// <summary>
	/// The key applies to the local computer. If this flag is not present, the key applies to the current user.
	/// </summary>
	public const uint NCRYPT_MACHINE_KEY_FLAG = 0x00000020;


	#region Key Storage Property Identifiers

	/// <summary>
	/// A null-terminated Unicode string that contains the name of the object's algorithm group. This property only applies to keys. The following identifiers are returned by the Microsoft key storage provider.
	/// </summary>
	public const string NCRYPT_ALGORITHM_GROUP_PROPERTY = "Algorithm Group";

	/// <summary>
	/// The RSA algorithm group.
	/// </summary>
	public const string NCRYPT_RSA_ALGORITHM_GROUP = "RSA";

	/// <summary>
	/// The Diffie-Hellman algorithm group.
	/// </summary>
	public const string NCRYPT_DH_ALGORITHM_GROUP = "DH";

	/// <summary>
	/// The DSA algorithm group.
	/// </summary>
	public const string NCRYPT_DSA_ALGORITHM_GROUP = "DSA";

	/// <summary>
	/// The elliptic curve DSA algorithm group.
	/// </summary>
	public const string NCRYPT_ECDSA_ALGORITHM_GROUP = "ECDSA";

	/// <summary>
	/// The elliptic curve Diffie-Hellman algorithm group.
	/// </summary>
	public const string NCRYPT_ECDH_ALGORITHM_GROUP = "ECDH";

	/// <summary>
	/// A null-terminated Unicode string that contains the name of the object's algorithm. This can be one of the predefined CNG Algorithm Identifiers or another registered algorithm identifier. 
	/// This property only applies to keys.
	/// </summary>
	public const string NCRYPT_ALGORITHM_PROPERTY = "Algorithm Name";

	/// <summary>
	/// An LPWSTR value that indicates the container name of the Elliptic Curve Diffie-Hellman (ECDH) key to use during logon for a given handle to an Elliptic Curve Digital Signature Algorithm (ECDSA) key. 
	/// If there are no ECDH keys on the card, the key storage provider (KSP) returns NTE_NOT_FOUND. This property applies to ECDSA keys for logon with smart cards. 
	/// The property is supported by the Microsoft Smart Card key storage provider and not by the Microsoft Software key storage provider.
	/// </summary>
	public const string NCRYPT_ASSOCIATED_ECDH_KEY = "SmartCardAssociatedECDHKey";

	/// <summary>
	/// A DWORD that contains the length, in bytes, of the encryption block. This property only applies to keys that support encryption.
	/// </summary>
	public const string NCRYPT_BLOCK_LENGTH_PROPERTY = "Block Length";

	/// <summary>
	/// A BLOB that contains an X.509 certificate that is associated with the key.
	/// </summary>
	public const string NCRYPT_CERTIFICATE_PROPERTY = "SmartCardKeyCertificate";

	/// <summary>
	/// Specifies parameters to use with a Diffie-Hellman key. This data type is a pointer to a <see cref="BCRYPT_DH_PARAMETER_HEADER"/> structure. 
	/// This property can only be set and must be set for the key before the key is completed.
	/// </summary>
	public const string NCRYPT_DH_PARAMETERS_PROPERTY = "DHParameters";

	/// <summary>
	/// A DWORD that contains a set of flags that specify the export policy for a persisted key. This property only applies to keys. 
	/// </summary>
	public const string NCRYPT_EXPORT_POLICY_PROPERTY = "Export Policy";

	/// <summary>
	/// The private key can be exported.
	/// </summary>
	public const uint NCRYPT_ALLOW_EXPORT_FLAG = 0x00000001;

	/// <summary>
	/// The private key can be exported in plaintext form.
	/// </summary>
	public const uint NCRYPT_ALLOW_PLAINTEXT_EXPORT_FLAG = 0x00000002;

	/// <summary>
	/// The private key can be exported once for archiving purposes. This flag only applies to the original key handle on which it is set. 
	/// This policy can only be applied to the original key handle. After the key handle has been closed, the key can no longer be exported for archiving purposes.
	/// </summary>
	public const uint NCRYPT_ALLOW_ARCHIVING_FLAG = 0x00000004;

	/// <summary>
	/// The private key can be exported once in plaintext form for archiving purposes. This flag only applies to the original key handle on which it is set. 
	/// This policy can only be applied to the original key handle. After the key handle has been closed, the key can no longer be exported for archiving purposes.
	/// </summary>
	public const uint NCRYPT_ALLOW_PLAINTEXT_ARCHIVING_FLAG = 0x00000008;

	/// <summary>
	/// A DWORD that contains a set of flags that define implementation details of the provider. This property only applies to key storage providers.
	/// </summary>
	public const string NCRYPT_IMPL_TYPE_PROPERTY = "Impl Type";

	/// <summary>
	/// The provider is hardware based.
	/// </summary>
	public const uint NCRYPT_IMPL_HARDWARE_FLAG = 0x00000001;

	/// <summary>
	/// The provider is software based.
	/// </summary>
	public const uint NCRYPT_IMPL_SOFTWARE_FLAG = 0x00000002;

	/// <summary>
	/// The provider is removable.
	/// </summary>
	public const uint NCRYPT_IMPL_REMOVABLE_FLAG = 0x00000008;

	/// <summary>
	/// The provider is a hardware based random number generator.
	/// </summary>
	public const uint NCRYPT_IMPL_HARDWARE_RNG_FLAG = 0x00000010;

	/// <summary>
	/// A DWORD that contains a set of flags that define the key type. This property only applies to keys.
	/// </summary>
	public const string NCRYPT_KEY_TYPE_PROPERTY = "Key Type";

	/// <summary>
	/// A DWORD that contains a set of flags that define the usage details for a key. This property only applies to keys.
	/// </summary>
	public const string NCRYPT_KEY_USAGE_PROPERTY = "\"Key Usage";

	/// <summary>
	/// The key can be used for decryption.
	/// </summary>
	public const uint NCRYPT_ALLOW_DECRYPT_FLAG = 0x00000001;

	/// <summary>
	/// The key can be used for signing.
	/// </summary>
	public const uint NCRYPT_ALLOW_SIGNING_FLAG = 0x00000002;

	/// <summary>
	/// The key can be used for secret agreement encryption.
	/// </summary>
	public const uint NCRYPT_ALLOW_KEY_AGREEMENT_FLAG = 0x00000004;

	/// <summary>
	/// Indicates the key is a key with attestation.
	/// </summary>
	public const uint NCRYPT_ALLOW_KEY_ATTESTATION_FLAG = 0x00000010;

	/// <summary>
	/// The key can be used for any purpose.
	/// </summary>
	public const uint NCRYPT_ALLOW_ALL_USAGES = 0x00ffffff;

	/// <summary>
	/// Indicates when the key was last modified. This data type is a pointer to a <see cref="FILETIME"/> structure. This property only applies to persisted keys.
	/// </summary>
	public const string NCRYPT_LAST_MODIFIED_PROPERTY = "Modified";

	/// <summary>
	/// A DWORD that contains the length, in bits, of the key. This property only applies to keys.
	/// </summary>
	public const string NCRYPT_LENGTH_PROPERTY = "Length";

	/// <summary>
	/// Indicates the key sizes that are supported by the key. This data type is a pointer to an <see cref="NCRYPT_SUPPORTED_LENGTHS"/> structure that contains this information. This property only applies to keys.
	/// </summary>
	public const string NCRYPT_LENGTHS_PROPERTY = "Lengths";

	/// <summary>
	/// A DWORD that contains the maximum length, in characters, of the name of a persistent key. This property only applies to a provider.
	/// This property is primarily intended to be used by key storage providers that store their keys on a device that has a limited amount of available memory, such as a smart card.
	/// </summary>
	public const string NCRYPT_MAX_NAME_LENGTH_PROPERTY = "Max Name Length";

	/// <summary>
	/// A pointer to a null-terminated Unicode string that contains the name of the object.
	/// </summary>
	public const string NCRYPT_NAME_PROPERTY = "Name";

	/// <summary>
	/// This value is not supported.
	/// </summary>
	public const string NCRYPT_PIN_PROMPT_PROPERTY = "SmartCardPinPrompt";

	/// <summary>
	/// A pointer to a null-terminated Unicode string that contains the PIN. The PIN is used for a smart card key or the password for a password-protected key stored in a software-based KSP. 
	/// This property can only be set. Microsoft KSPs will cache this value so that the user is only prompted once per process.
	/// </summary>
	public const string NCRYPT_PIN_PROPERTY = "SmartCardPin";

	/// <summary>
	/// An NCRYPT_PROV_HANDLE that contains the handle of the CNG key storage provider. When you are finished using the handle, you must call <see cref="NCryptFreeObject"/> to release it.
	/// </summary>
	public const string NCRYPT_PROVIDER_HANDLE_PROPERTY = "Provider Handle";

	/// <summary>
	/// A pointer to a null-terminated Unicode string that contains the name of the smart card reader. This property can only be set.
	/// </summary>
	public const string NCRYPT_READER_PROPERTY = "SmartCardReader";

	/// <summary>
	/// An HCERTSTORE that represents the smart card root certificate store.
	/// </summary>
	public const string NCRYPT_ROOT_CERTSTORE_PROPERTY = "SmartcardRootCertStore";

	/// <summary>
	/// A pointer to the PIN_ID value associated with a given cryptographic key on a smart card. This is a read-only property. The PIN_ID data type is defined in Cardmod.h.
	/// </summary>
	public const string NCRYPT_SCARD_PIN_ID = "SmartCardPinId";

	/// <summary>
	/// A pointer to PIN_INFO structure of the PIN associated with a given cryptographic key on the smart card. The caller provides the key handle. This property is a read-only property. The PIN_INFO structure is defined in Cardmod.h.
	/// </summary>
	public const string NCRYPT_SCARD_PIN_INFO = "SmartCardPinInfo";

	/// <summary>
	/// A pointer to a null-terminated Unicode string that contains the smart card session PIN. This property can only be set.
	/// </summary>
	public const string NCRYPT_SECURE_PIN_PROPERTY = "SmartCardSecurePin";

	/// <summary>
	/// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure that contains access control information for the key. This property only applies to persistent keys. 
	/// The dwFlags parameter of the <see cref="NCryptGetProperty"/> or <see cref="NCryptSetProperty"/> function identifies the part of the security descriptor to get or set.
	/// </summary>
	public const string NCRYPT_SECURITY_DESCR_PROPERTY = "Security Descr";

	/// <summary>
	/// ndicates whether the provider supports security descriptors for keys. This property is a DWORD that contains 1 if the provider supports security descriptors for keys. 
	/// If this property contains any other value, or if the <see cref="NCryptGetProperty"/> function returns <see cref="NTE_NOT_SUPPORTED"/>, then the provider does not support security descriptors for keys. 
	/// This property only applies to providers.
	/// </summary>
	public const string NCRYPT_SECURITY_DESCR_SUPPORT_PROPERTY = "Security Descr Support";

	/// <summary>
	/// A BLOB that contains the identifier of the smart card.
	/// </summary>
	public const string NCRYPT_SMARTCARD_GUID_PROPERTY = "SmartCardGuid";


	/// <summary>
	/// If used with the NCryptSetProperty or NCryptGetProperty function, this is a pointer to an <see cref="NCRYPT_UI_POLICY"/> structure that contains the strong key user interface policy for the key. 
	/// This property only applies to persistent keys. This property can only be set when the key is being generated. 
	/// Once the <see cref="NCryptFinalizeKey"/> function has been called for this key, this property becomes read-only.
	/// A key storage provider can receive this parameter through an NCryptSetPropertyFn callback function. The parameter value is an NCRYPT_UI_POLICY_BLOB structure that contains the same information.
	/// Similarly, when an application makes a request through NCryptSetPropertyFn to the provider to return this property, the provider is expected to return an NCRYPT_UI_POLICY_BLOB structure.
	/// </summary>
	public const string NCRYPT_UI_POLICY_PROPERTY = "UI Policy";

	/// <summary>
	/// A pointer to a null-terminated Unicode string that contains the unique name of the object. This is an alternate name that can be used when accessing the key. 
	/// This property is used when it is thought that the key name originally passed to <see cref="NCryptCreatePersistedKey"/> is not unique enough to reliably identify the persisted key. 
	/// The Microsoft key storage provider will return the file name of the key as this property.
	/// </summary>
	public const string NCRYPT_UNIQUE_NAME_PROPERTY = "Unique Name";


	/// <summary>
	/// A pointer to a null-terminated Unicode string that describes the context of the operation. This property is not persistent and can be set on either a provider or a key. 
	/// A key does not have access to the <see cref="NCRYPT_USE_CONTEXT_PROPERTY"/> property of the provider because the property is specific only to the handle it is set for.
	/// An example where this property would be used in the context of a provider is a key storage provider that needs to prompt the user during a call to <see cref="NCryptOpenKey"/> (for example, "Insert your smart card in the reader."). 
	/// Because the key handle is not available until after <see cref="NCryptOpenKey"/> returns, the application should set this property on the provider handle prior to calling <see cref="NCryptOpenKey"/>.
	/// An example where this property would be used in the context of a key handle is a key storage provider that needs to prompt the user during an operation using the key (for example, "This application needs to use this key to sign a document.").
	/// The provider could then relay this context information to the user in any user interface shown during the operation.
	/// </summary>
	public const string NCRYPT_USE_CONTEXT_PROPERTY = "Use Context";

	/// <summary>
	/// Indicates whether the provider supports usage counting for keys. This property is a DWORD that contains 1 if the provider supports usage counting for keys. 
	/// If this property contains any other value, or if the <see cref="NCryptGetProperty"/> function returns <see cref="NTE_NOT_SUPPORTED"/>, then the provider does not support usage counting for keys. 
	/// This property only applies to providers.
	/// </summary>
	public const string NCRYPT_USE_COUNT_ENABLED_PROPERTY = "Enabled Use Count";

	/// <summary>
	/// A ULARGE_INTEGER variable that contains the number of operations that the specified private key has performed. This property is optional and may not be supported by all providers. 
	/// Providers that support this property on keys should also support the <see cref="NCRYPT_USE_COUNT_ENABLED_PROPERTY"/> property on the provider handle. 
	/// The Microsoft key storage provider does not support this property. This property only applies to persistent keys.
	/// </summary>
	public const string NCRYPT_USE_COUNT_PROPERTY = "Use Count";

	/// <summary>
	/// An HCERTSTORE that represents the smart card user certificate store.
	/// </summary>
	public const string NCRYPT_USER_CERTSTORE_PROPERTY = "SmartCardUserCertStore";

	/// <summary>
	/// A new property of the MS_KEY_STORAGE_PROVIDER provider. This property enables the retrieval of the public part of the root Signing Key (IDKS) of Virtualization Based Security (VBS).
	/// </summary>
	public const string NCRYPT_VBS_ROOT_PUB_PROPERTY = "VBS_ROOT_PUB";

	/// <summary>
	/// A DWORD that contains the software version of the provider. The high word contains the major version and the low word contains the minor version. For example, 0x00030033 = 3.51. 
	/// This property only applies to providers.
	/// </summary>
	public const string NCRYPT_VERSION_PROPERTY = "Version";

	/// <summary>
	/// A pointer to the window handle (HWND) to be used as the parent of any user interface that is displayed. 
	/// Because undesirable behavior can happen when a user interface is shown by using a NULL window handle for the parent, we strongly recommend that a key storage provider not display a user interface unless this property is set.
	/// </summary>
	public const string NCRYPT_WINDOW_HANDLE_PROPERTY = "HWND Handle";

	#endregion

	/// <summary>
	/// The structure is used with the <see cref="NCRYPT_LENGTHS_PROPERTY"/> property to contain length information for a key.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/Ncrypt/ns-ncrypt-ncrypt_supported_lengths</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct NCRYPT_SUPPORTED_LENGTHS
	{
		/// <summary>
		/// The minimum length, in bits, of a key.
		/// </summary>
		public uint dwMinLength;

		/// <summary>
		/// The maximum length, in bits, of a key.
		/// </summary>
		public uint dwMaxLength;

		/// <summary>
		/// The number of bits that the key size can be incremented between dwMinLength and dwMaxLength.
		/// </summary>
		public uint dwIncrement;

		/// <summary>
		/// The default length, in bits, of a key.
		/// </summary>
		public uint dwDefaultLength;
	}

	/// <summary>
	/// The structure is used with the <see cref="NCRYPT_UI_POLICY_PROPERTY"/> property to contain strong key user interface information for a key. 
	/// This structure is used with the <see cref="NCryptSetProperty"/> and <see cref="NCryptGetProperty"/> functions with the <see cref="NCRYPT_UI_POLICY_PROPERTY"/> property.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/Ncrypt/ns-ncrypt-ncrypt_ui_policy</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct NCRYPT_UI_POLICY
	{
		/// <summary>
		/// The version number of the structure. This member must contain 1.
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// A set of flags that provide additional user interface information or requirements.
		/// </summary>
		public uint dwFlags;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the text that will be used in the title of the strong key dialog box when the key is completed. 
		/// If this member is NULL, a default creation title will be used in the strong key dialog box. This member is only used on key finalization.
		/// </summary>
		public char* pszCreationTitle;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the text that will be displayed in the strong key dialog box as the name of the key. 
		/// If this member is NULL, a default name will be used in the strong key dialog box. This member is used both when the key is completed and when the key is used.
		/// </summary>
		public char* pszFriendlyName;

		/// <summary>
		/// A pointer to a null-terminated Unicode string that contains the text that will be displayed in the strong key dialog box as the description of the key. 
		/// If this member is NULL, a default description will be used in the strong key dialog box. This member is used both when the key is completed and when the key is used.
		/// </summary>
		public char* pszDescription;
	}

	#region NCRYPT_UI_POLICY.dwFlags allowed values

	/// <summary>
	/// Display the strong key user interface as needed.
	/// </summary>
	public const uint NCRYPT_UI_PROTECT_KEY_FLAG = 0x00000001;

	/// <summary>
	/// Force high protection.
	/// </summary>
	public const uint NCRYPT_UI_FORCE_HIGH_PROTECTION_FLAG = 0x00000002;

	/// <summary>
	/// An app container has accessed a medium key that is not strongly protected. For example, a key that is for user consent only, or is password or fingerprint protected.
	/// </summary>
	public const uint NCRYPT_UI_APPCONTAINER_ACCESS_MEDIUM_FLAG = 0x00000008;



	#endregion
	/// <summary>
	/// Creates a signature of a hash value.
	/// </summary>
	/// <param name="hKey">The handle of the key to use to sign the hash.</param>
	/// <param name="pPaddingInfo">A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the value of the dwFlags parameter. 
	/// This parameter is only used with asymmetric keys and must be NULL otherwise.</param>
	/// <param name="pbHashValue">A pointer to a buffer that contains the hash value to sign. The cbInput parameter contains the size of this buffer.</param>
	/// <param name="cbHashValue">The number of bytes in the pbHashValue buffer to sign.</param>
	/// <param name="pbSignature">The address of a buffer to receive the signature produced by this function. The cbSignature parameter contains the size of this buffer. 
	/// If this parameter is NULL, this function will calculate the size required for the signature and return the size in the location pointed to by the pcbResult parameter.</param>
	/// <param name="cbSignature">The size, in bytes, of the pbSignature buffer. This parameter is ignored if the pbSignature parameter is NULL.</param>
	/// <param name="pcbResult">A pointer to a DWORD variable that receives the number of bytes copied to the pbSignature buffer. 
	/// If pbSignature is NULL, this receives the size, in bytes, required for the signature.</param>
	/// <param name="dwFlags">Flags that modify function behavior. The allowed set of flags depends on the type of key specified by the hKey parameter.</param>
	/// <returns>Returns a status code that indicates the success or failure of the function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptsignhash</remarks>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptSignHash(
		[In] nint hKey,
		[In, Optional] void* pPaddingInfo,
		[In] void* pbHashValue,
		[In] uint cbHashValue,
		[Out] void* pbSignature,
		[In] uint cbSignature,
		[Out] uint* pcbResult,
		[In] uint dwFlags
	);

	/// <summary>
	/// Verifies that the specified signature matches the specified hash.
	/// </summary>
	/// <param name="hKey">The handle of the key to use to decrypt the signature. This must be an identical key or the public key portion of the key pair used to sign the data with the <see cref="NCryptSignHash"/> function.</param>
	/// <param name="pPaddingInfo">A pointer to a structure that contains padding information. The actual type of structure this parameter points to depends on the value of the dwFlags parameter.
	/// This parameter is only used with asymmetric keys and must be NULL otherwise.</param>
	/// <param name="pbHashValue">The address of a buffer that contains the hash of the data. The cbHash parameter contains the size of this buffer.</param>
	/// <param name="cbHashValue">The size, in bytes, of the pbHash buffer.</param>
	/// <param name="pbSignature">The address of a buffer that contains the signed hash of the data. The <see cref="NCryptSignHash"/> function is used to create the signature. The cbSignature parameter contains the size of this buffer.</param>
	/// <param name="cbSignature">The size, in bytes, of the pbSignature buffer. The <see cref="NCryptSignHash"/> function is used to create the signature.</param>
	/// <param name="dwFlags">Flags that modify function behavior. The allowed set of flags depends on the type of key specified by the hKey parameter.</param>
	/// <returns></returns>
	[DllImport(NCryptLib, CharSet = CharSet.Unicode)]
	public static extern uint NCryptVerifySignature(
		[In] nint hKey,
		[In, Optional] void* pPaddingInfo,
		[In] void* pbHashValue,
		[In] uint cbHashValue,
		[In] void* pbSignature,
		[In] uint cbSignature,
		[In] uint dwFlags
	);

	#region The NCryptSignHash.dwFlags and NCryptDecrypt.dwFlags allowed values

	/// <summary>
	///	Use the Probabilistic Signature Scheme (PSS) padding scheme. The pPaddingInfo parameter is a pointer to a <see cref="BCRYPT_PSS_PADDING_INFO"/> structure.
	/// </summary>
	public const uint NCRYPT_PAD_PSS_FLAG = 0x00000008;

	#endregion
}
