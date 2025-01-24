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

	#region CNG Algorithm Identifiers

	/// <summary>
	///	The triple data encryption standard symmetric encryption algorithm. Standard: SP800-67, SP800-38A.
	/// </summary>
	public const string BCRYPT_3DES_ALGORITHM = "3DES";

	/// <summary>
	/// The 112-bit triple data encryption standard symmetric encryption algorithm. Standard: SP800-67, SP800-38A.
	/// </summary>
	public const string BCRYPT_3DES_112_ALGORITHM = "3DES_112";

	/// <summary>
	/// The advanced encryption standard symmetric encryption algorithm. Standard: FIPS 197.
	/// </summary>
	public const string BCRYPT_AES_ALGORITHM = "AES";

	/// <summary>
	/// The advanced encryption standard (AES) cipher based message authentication code (CMAC) symmetric encryption algorithm. Standard: SP 800-38B.
	/// </summary>
	public const string BCRYPT_AES_CMAC_ALGORITHM = "AES-CMAC";

	/// <summary>
	/// The advanced encryption standard (AES) Galois message authentication code (GMAC) symmetric encryption algorithm. Standard: SP800-38D.
	/// </summary>
	public const string BCRYPT_AES_GMAC_ALGORITHM = "AES-GMAC";

	/// <summary>
	/// Crypto API (CAPI) key derivation function algorithm. Used by the <see cref="BCryptKeyDerivation"/> and <see cref="NCryptKeyDerivation"/> functions.
	/// </summary>
	public const string BCRYPT_CAPI_KDF_ALGORITHM = "CAPI_KDF";

	/// <summary>
	/// The data encryption standard symmetric encryption algorithm. Standard: FIPS 46-3, FIPS 81.
	/// </summary>
	public const string BCRYPT_DES_ALGORITHM = "DES";

	/// <summary>
	/// The extended data encryption standard symmetric encryption algorithm. Standard: None.
	/// </summary>
	public const string BCRYPT_DESX_ALGORITHM = "DESX";

	/// <summary>
	/// The Diffie-Hellman key exchange algorithm. Standard: PKCS #3.
	/// </summary>
	public const string BCRYPT_DH_ALGORITHM = "DH";

	/// <summary>
	/// The digital signature algorithm. Standard: FIPS 186-2.
	/// </summary>
	public const string BCRYPT_DSA_ALGORITHM = "DSA";

	/// <summary>
	/// The 256-bit prime elliptic curve Diffie-Hellman key exchange algorithm. Standard: SP800-56A.
	/// </summary>
	public const string BCRYPT_ECDH_P256_ALGORITHM = "ECDH_P256";

	/// <summary>
	/// The 384-bit prime elliptic curve Diffie-Hellman key exchange algorithm. Standard: SP800-56A.
	/// </summary>
	public const string BCRYPT_ECDH_P384_ALGORITHM = "ECDH_P384";

	/// <summary>
	/// The 521-bit prime elliptic curve Diffie-Hellman key exchange algorithm. Standard: SP800-56A.
	/// </summary>
	public const string BCRYPT_ECDH_P521_ALGORITHM = "ECDH_P521";

	/// <summary>
	/// The 256-bit prime elliptic curve digital signature algorithm (FIPS 186-2). Standard: FIPS 186-2, X9.62.
	/// </summary>
	public const string BCRYPT_ECDSA_P256_ALGORITHM = "ECDSA_P256";

	/// <summary>
	/// The 384-bit prime elliptic curve digital signature algorithm (FIPS 186-2). Standard: FIPS 186-2, X9.62.
	/// </summary>
	public const string BCRYPT_ECDSA_P384_ALGORITHM = "ECDSA_P384";

	/// <summary>
	/// The 521-bit prime elliptic curve digital signature algorithm (FIPS 186-2). Standard: FIPS 186-2, X9.62.
	/// </summary>
	public const string BCRYPT_ECDSA_P521_ALGORITHM = "ECDSA_P521";

	/// <summary>
	/// The MD2 hash algorithm. Standard: RFC 1319.
	/// </summary>
	public const string BCRYPT_MD2_ALGORITHM = "MD2";

	/// <summary>
	/// The MD4 hash algorithm. Standard: RFC 1320.
	/// </summary>
	public const string BCRYPT_MD4_ALGORITHM = "MD4";

	/// <summary>
	/// The MD5 hash algorithm. Standard: RFC 1321.
	/// </summary>
	public const string BCRYPT_MD5_ALGORITHM = "MD5";

	/// <summary>
	/// The RC2 block symmetric encryption algorithm. Standard: RFC 2268.
	/// </summary>
	public const string BCRYPT_RC2_ALGORITHM = "RC2";

	/// <summary>
	/// The RC4 symmetric encryption algorithm.	Standard: Various.
	/// </summary>
	public const string BCRYPT_RC4_ALGORITHM = "RC4";

	/// <summary>
	/// The random-number generator algorithm. Standard: FIPS 186-2, FIPS 140-2, NIST SP 800-90.
	/// </summary>
	public const string BCRYPT_RNG_ALGORITHM = "RNG";

	/// <summary>
	/// The dual elliptic curve random-number generator algorithm. Standard: SP800-90.
	/// </summary>
	public const string BCRYPT_RNG_DUAL_EC_ALGORITHM = "DUALECRNG";

	/// <summary>
	/// The random-number generator algorithm suitable for DSA (Digital Signature Algorithm). Standard: FIPS 186-2.
	/// </summary>
	public const string BCRYPT_RNG_FIPS186_DSA_ALGORITHM = "FIPS186DSARNG";

	/// <summary>
	/// The RSA public key algorithm. Standard: PKCS #1 v1.5 and v2.0.
	/// </summary>
	public const string BCRYPT_RSA_ALGORITHM = "RSA";

	/// <summary>
	/// The RSA signature algorithm. This algorithm is not currently supported. You can use the <see cref="BCRYPT_RSA_ALGORITHM"/> algorithm to perform RSA signing operations. Standard: PKCS #1 v1.5 and v2.0.
	/// </summary>
	public const string BCRYPT_RSA_SIGN_ALGORITHM = "RSA_SIGN";

	/// <summary>
	/// The 160-bit secure hash algorithm. Standard: FIPS 180-2, FIPS 198.
	/// </summary>
	public const string BCRYPT_SHA1_ALGORITHM = "SHA1";

	/// <summary>
	/// The 256-bit secure hash algorithm. Standard: FIPS 180-2, FIPS 198.
	/// </summary>
	public const string BCRYPT_SHA256_ALGORITHM = "SHA256";

	/// <summary>
	/// The 384-bit secure hash algorithm. Standard: FIPS 180-2, FIPS 198.
	/// </summary>
	public const string BCRYPT_SHA384_ALGORITHM = "SHA384";

	/// <summary>
	/// The 512-bit secure hash algorithm. Standard: FIPS 180-2, FIPS 198.
	/// </summary>
	public const string BCRYPT_SHA512_ALGORITHM = "SHA512";

	/// <summary>
	/// Counter mode, hash-based message authentication code (HMAC) key derivation function algorithm. Used by the <see cref="BCryptKeyDerivation"/> and <see cref="NCryptKeyDerivation"/> functions.
	/// </summary>
	public const string BCRYPT_SP800108_CTR_HMAC_ALGORITHM = "SP800_108_CTR_HMAC";

	/// <summary>
	/// SP800-56A key derivation function algorithm. Used by the <see cref="BCryptKeyDerivation"/> and <see cref="NCryptKeyDerivation"/> functions.
	/// </summary>
	public const string BCRYPT_SP80056A_CONCAT_ALGORITHM = "SP800_56A_CONCAT";

	/// <summary>
	/// Password-based key derivation function 2 (PBKDF2) algorithm.Used by the <see cref = "BCryptKeyDerivation" /> and <see cref= "NCryptKeyDerivation" /> functions.
	/// </summary>
	public const string BCRYPT_PBKDF2_ALGORITHM = "PBKDF2";

	/// <summary>
	/// Generic prime elliptic curve digital signature algorithm. Standard: ANSI X9.62.
	/// </summary>
	public const string BCRYPT_ECDSA_ALGORITHM = "ECDSA";

	/// <summary>
	/// Generic prime elliptic curve Diffie-Hellman key exchange algorithm. Standard: SP800-56A.
	/// </summary>
	public const string BCRYPT_ECDH_ALGORITHM = "ECDH";

	/// <summary>
	/// The advanced encryption standard symmetric encryption algorithm in XTS mode. Standard: SP-800-38E, IEEE Std 1619-2007.
	/// </summary>
	public const string BCRYPT_XTS_AES_ALGORITHM = "XTS-AES";

	#endregion

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
