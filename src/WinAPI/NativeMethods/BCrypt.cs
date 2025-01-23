// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the BCrypt.dll Windows API library
/// </summary>
public static unsafe class BCrypt
{
	/// <summary>
	/// NCrypt library file name
	/// </summary>
	public const string BCryptLib = "BCrypt.dll";

	/// <summary>
	/// The structure is used to contain parameter header information for a Diffie-Hellman key. This structure is used with the BCRYPT_DH_PARAMETERS property in the BCryptSetProperty function.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/Bcrypt/ns-bcrypt-bcrypt_dh_parameter_header</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct BCRYPT_DH_PARAMETER_HEADER
	{
		/// <summary>
		/// The total size, in bytes, of this structure and the buffer that immediately follows this structure in memory.
		/// </summary>
		public uint cbLength;

		/// <summary>
		/// The magic value for the key. This member must be the <see cref="BCRYPT_DH_PARAMETERS_MAGIC"/> value.
		/// </summary>
		public uint dwMagic;

		/// <summary>
		/// The size, in bytes, of the key that this structure applies to.
		/// </summary>
		public uint cbKeyLength;
	}

	/// <summary>
	/// The magic value for a Diffie-Hellman key
	/// </summary>
	public const uint BCRYPT_DH_PARAMETERS_MAGIC = 0x4d504844;

	/// <summary>
	/// The structure is used to provide options for the Optimal Asymmetric Encryption Padding (OAEP) scheme.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/bcrypt/ns-bcrypt-bcrypt_oaep_padding_info</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct BCRYPT_OAEP_PADDING_INFO
	{
		/// <summary>
		/// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm to use to create the padding. This algorithm must be a hashing algorithm.
		/// </summary>
		public char* pszAlgId;

		/// <summary>
		/// The address of a buffer that contains the data to use to create the padding. The cbLabel member contains the size of this buffer.
		/// </summary>
		public void* pbLabel;

		/// <summary>
		/// Contains the number of bytes in the pbLabel buffer to use to create the padding.
		/// </summary>
		public uint cbLabel;
	}

	/// <summary>
	/// The structure is used to provide options for the PKCS #1 padding scheme.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/bcrypt/ns-bcrypt-bcrypt_pkcs1_padding_info</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct BCRYPT_PKCS1_PADDING_INFO
	{
		/// <summary>
		/// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm to use to create the padding. This algorithm must be a hashing algorithm. 
		/// When creating a signature, the object identifier (OID) that corresponds to this algorithm is added to the DigestInfo element in the signature, and if this member is NULL, then the OID is not added.
		/// When verifying a signature, the verification fails if the OID that corresponds to this member is not the same as the OID in the signature. 
		/// If there is no OID in the signature, then verification fails unless this member is NULL.
		/// </summary>
		public char* pszAlgId;
	}

	/// <summary>
	/// The structure is used to provide options for the Probabilistic Signature Scheme (PSS) padding scheme.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/bcrypt/ns-bcrypt-bcrypt_pss_padding_info</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct BCRYPT_PSS_PADDING_INFO
	{
		/// <summary>
		/// A pointer to a null-terminated Unicode string that identifies the cryptographic algorithm to use to create the padding. This algorithm must be a hashing algorithm.
		/// </summary>
		public char* pszAlgId;

		/// <summary>
		/// The size, in bytes, of the random salt to use for the padding.
		/// </summary>
		public uint cbSalt;
	}
}
