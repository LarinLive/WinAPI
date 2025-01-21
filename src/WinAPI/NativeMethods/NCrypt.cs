// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Data.Common;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
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
	public unsafe struct NCryptKeyName
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
	public unsafe struct NCryptProviderName
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
	///<remarks>hhttps://learn.microsoft.com/en-us/windows/win32/api/ncrypt/nf-ncrypt-ncryptgetproperty</remarks>
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
	/// Requests that the key service provider (KSP) not display any user interface. If the provider must display the UI to operate, the call fails and the KSP should set the <see cref="NTE_SILENT_CONTEXT"/> error code as the last error.
	/// </summary>
	public const uint NCRYPT_SILENT_FLAG = 0x00000040;

	/// <summary>
	/// The key applies to the local computer. If this flag is not present, the key applies to the current user.
	/// </summary>
	public const uint NCRYPT_MACHINE_KEY_FLAG = 0x00000020;

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
	/// /// </summary>
	public const string NCRYPT_EXPORT_POLICY_PROPERTY = "Export Policy";

	/// <summary>
	/// A pointer to a null-terminated Unicode string that contains the PIN. The PIN is used for a smart card key or the password for a password-protected key stored in a software-based KSP. 
	/// This property can only be set. Microsoft KSPs will cache this value so that the user is only prompted once per process.
	/// </summary>
	public const string NCRYPT_PIN_PROPERTY = "SmartCardPin";

	/// <summary>
	/// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure that contains access control information for the key. This property only applies to persistent keys. 
	/// The dwFlags parameter of the <see cref="NCryptGetProperty"/> or <see cref="NCryptSetProperty"/> function identifies the part of the security descriptor to get or set.
	/// </summary>
	public const string NCRYPT_SECURITY_DESCR_PROPERTY = "Security Descr";

	#endregion
}
