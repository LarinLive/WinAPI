// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace LarinLive.WinAPI.NativeMethods;

public static partial class ErrorCodes
{
	/// <summary>
	/// Bad UID.
	/// </summary>
	public const uint NTE_BAD_UID = 0x80090001;

	/// <summary>
	/// Bad Hash.
	/// </summary>
	public const uint NTE_BAD_HASH = 0x80090002;

	/// <summary>
	/// Bad Key.
	/// </summary>
	public const uint NTE_BAD_KEY = 0x80090003;

	/// <summary>
	/// Bad Length.
	/// </summary>
	public const uint NTE_BAD_LEN = 0x80090004;

	/// <summary>
	/// Bad Data.
	/// </summary>
	public const uint NTE_BAD_DATA = 0x80090005;

	/// <summary>
	/// Invalid Signature.
	/// </summary>
	public const uint NTE_BAD_SIGNATURE = 0x80090006;

	/// <summary>
	/// Bad Version of provider.
	/// </summary>
	public const uint NTE_BAD_VER = 0x80090007;

	/// <summary>
	/// Invalid algorithm specified.
	/// </summary>
	public const uint NTE_BAD_ALGID = 0x80090008;

	/// <summary>
	/// Invalid flags specified.
	/// </summary>
	public const uint NTE_BAD_FLAGS = 0x80090009;

	/// <summary>
	/// Invalid type specified.
	/// </summary>
	public const uint NTE_BAD_TYPE = 0x8009000A;

	/// <summary>
	/// Key not valid for use in specified state.
	/// </summary>
	public const uint NTE_BAD_KEY_STATE = 0x8009000B;

	/// <summary>
	/// Hash not valid for use in specified state.
	/// </summary>
	public const uint NTE_BAD_HASH_STATE = 0x8009000C;

	/// <summary>
	/// Key does not exist.
	/// </summary>
	public const uint NTE_NO_KEY = 0x8009000D;

	/// <summary>
	/// Insufficient memory available for the operation.
	/// </summary>
	public const uint NTE_NO_MEMORY = 0x8009000E;

	/// <summary>
	/// Object already exists.
	/// </summary>
	public const uint NTE_EXISTS = 0x8009000F;

	/// <summary>
	/// Access denied.
	/// </summary>
	public const uint NTE_PERM = 0x80090010;

	/// <summary>
	/// Object was not found.
	/// </summary>
	public const uint NTE_NOT_FOUND = 0x80090011;

	/// <summary>
	/// Data already encrypted.
	/// </summary>
	public const uint NTE_DOUBLE_ENCRYPT = 0x80090012;

	/// <summary>
	/// Invalid provider specified.
	/// </summary>
	public const uint NTE_BAD_PROVIDER = 0x80090013;

	/// <summary>
	/// Invalid provider type specified.
	/// </summary>
	public const uint NTE_BAD_PROV_TYPE = 0x80090014;

	/// <summary>
	/// Provider's public key is invalid.
	/// </summary>
	public const uint NTE_BAD_PUBLIC_KEY = 0x80090015;

	/// <summary>
	/// Keyset does not exist
	/// </summary>
	public const uint NTE_BAD_KEYSET = 0x80090016;

	/// <summary>
	/// Provider type not defined.
	/// </summary>
	public const uint NTE_PROV_TYPE_NOT_DEF = 0x80090017;

	/// <summary>
	/// Provider type as registered is invalid.
	/// </summary>
	public const uint NTE_PROV_TYPE_ENTRY_BAD = 0x80090018;

	/// <summary>
	/// The keyset is not defined.
	/// </summary>
	public const uint NTE_KEYSET_NOT_DEF = 0x80090019;

	/// <summary>
	/// Keyset as registered is invalid.
	/// </summary>
	public const uint NTE_KEYSET_ENTRY_BAD = 0x8009001A;

	/// <summary>
	/// 	Provider type does not match registered value.
	/// </summary>
	public const uint NTE_PROV_TYPE_NO_MATCH = 0x8009001B;

	/// <summary>
	/// The digital signature file is corrupt.
	/// </summary>
	public const uint NTE_SIGNATURE_FILE_BAD = 0x8009001C;

	/// <summary>
	/// Provider DLL failed to initialize correctly.
	/// </summary>
	public const uint NTE_PROVIDER_DLL_FAIL = 0x8009001D;

	/// <summary>
	/// Provider DLL could not be found.
	/// </summary>
	public const uint NTE_PROV_DLL_NOT_FOUND = 0x8009001E;

	/// <summary>
	/// The Keyset parameter is invalid.
	/// </summary>
	public const uint NTE_BAD_KEYSET_PARAM = 0x8009001F;

	/// <summary>
	/// An internal error occurred.
	/// </summary>
	public const uint NTE_FAIL = 0x80090020;

	/// <summary>
	/// A base error occurred.
	/// </summary>
	public const uint NTE_SYS_ERR = 0x80090021;

	/// <summary>
	/// Provider could not perform the action since the context was acquired as silent.
	/// </summary>
	public const uint NTE_SILENT_CONTEXT = 0x80090022;

	/// <summary>
	/// The security token does not have storage space available for an additional container.
	/// </summary>
	public const uint NTE_TOKEN_KEYSET_STORAGE_FULL = 0x80090023;

	/// <summary>
	/// The profile for the user is a temporary profile.
	/// </summary>
	public const uint NTE_TEMPORARY_PROFILE = 0x80090024;

	/// <summary>
	/// The key parameters could not be set because the CSP uses fixed parameters.
	/// </summary>
	public const uint NTE_FIXEDPARAMETER = 0x80090025;

	/// <summary>
	/// The supplied handle is invalid.
	/// </summary>
	public const uint NTE_INVALID_HANDLE = 0x80090026;

	/// <summary>
	/// The parameter is incorrect.
	/// </summary>
	public const uint NTE_INVALID_PARAMETER = 0x80090027;

	/// <summary>
	/// The buffer supplied to a function was too small.
	/// </summary>
	public const uint NTE_BUFFER_TOO_SMALL = 0x80090028;

	/// <summary>
	/// The requested operation is not supported.
	/// </summary>
	public const uint NTE_NOT_SUPPORTED = 0x80090029;

	/// <summary>
	/// No more data is available.
	/// </summary>
	public const uint NTE_NO_MORE_ITEMS = 0x8009002A;

	/// <summary>
	/// The supplied buffers overlap incorrectly.
	/// </summary>
	public const uint NTE_BUFFERS_OVERLAP = 0x8009002B;

	/// <summary>
	/// The specified data could not be decrypted.
	/// </summary>
	public const uint NTE_DECRYPTION_FAILURE = 0x8009002D;

	/// <summary>
	/// An internal consistency check failed.
	/// </summary>
	public const uint NTE_INTERNAL_ERROR = 0x8009002D;

	/// <summary>
	///	This operation requires input from the user.
	/// </summary>
	public const uint NTE_UI_REQUIRED = 0x8009002E;

	/// <summary>
	/// The cryptographic provider does not support HMAC.
	/// </summary>
	public const uint NTE_HMAC_NOT_SUPPORTED = 0x8009002F;

	/// <summary>
	/// The device that is required by this cryptographic provider is not ready for use.
	/// </summary>
	public const uint NTE_DEVICE_NOT_READY = 0x80090030;

	/// <summary>
	/// The dictionary attack mitigation is triggered and the provided authorization was ignored by the provider.
	/// </summary>
	public const uint NTE_AUTHENTICATION_IGNORED = 0x80090031;

	/// <summary>
	/// The validation of the provided data failed the integrity or signature validation.
	/// </summary>
	public const uint NTE_VALIDATION_FAILED = 0x80090032;

	/// <summary>
	/// Incorrect password.
	/// </summary>
	public const uint NTE_INCORRECT_PASSWORD = 0x80090033;

	/// <summary>
	/// Encryption failed.
	/// </summary>
	public const uint NTE_ENCRYPTION_FAILURE = 0x80090034;


	/// <summary>
	/// An error occurred while performing an operation on a cryptographic message.
	/// </summary>
	public const uint CRYPT_E_MSG_ERROR = 0x80091001;

	/// <summary>
	/// Cannot find the original signer.
	/// </summary>
	public const uint CRYPT_E_SIGNER_NOT_FOUND = 0x8009100E;

	/// <summary>
	/// Cannot find object or property.
	/// </summary>
	public const uint CRYPT_E_NOT_FOUND = 0x80092004;

	/// <summary>
	/// The signed cryptographic message does not have a signer for the specified signer index.
	/// </summary>
	public const uint CRYPT_E_NO_SIGNER = 0x8009200E;

	/// <summary>
	/// The certificate or signature has been revoked.
	/// </summary>
	public const uint CRYPT_E_REVOKED = 0x80092010;

	/// <summary>
	/// The revocation function was unable to check revocation for the certificate.
	/// </summary>
	public const uint CRYPT_E_NO_REVOCATION_CHECK = 0x80092012;

	/// <summary>
	/// The revocation function was unable to check revocation because the revocation server was offline.
	/// </summary>
	public const uint CRYPT_E_REVOCATION_OFFLINE = 0x80092013;

	/// <summary>
	/// ASN1 end of data expected.
	/// </summary>
	public const uint CRYPT_E_ASN1_NOEOD = 0x80093202;


	/// <summary>
	/// A system-level error occurred while verifying trust.
	/// </summary>
	public const uint TRUST_E_SYSTEM_ERROR = 0x80096001;

	/// <summary>
	/// The certificate for the signer of the message is invalid or not found.
	/// </summary>
	public const uint TRUST_E_NO_SIGNER_CERT = 0x80096002;

	/// <summary>
	/// One of the counter signatures was invalid.
	/// </summary>
	public const uint TRUST_E_COUNTER_SIGNER = 0x80096003;

	/// <summary>
	/// The signature of the certificate cannot be verified.
	/// </summary>
	public const uint TRUST_E_CERT_SIGNATURE = 0x80096004;

	/// <summary>
	/// The timestamp signature and/or certificate could not be verified or is malformed.
	/// </summary>
	public const uint TRUST_E_TIME_STAMP = 0x80096005;

	/// <summary>
	/// The digital signature of the object did not verify.
	/// </summary>
	public const uint TRUST_E_BAD_DIGEST = 0x80096010;

	/// <summary>
	/// A certificate's basic constraint extension has not been observed.
	/// </summary>
	public const uint TRUST_E_BASIC_CONSTRAINTS = 0x80096019;

	/// <summary>
	/// The certificate does not meet or contain the Authenticode(tm) financial extensions.
	/// </summary>
	public const uint TRUST_E_FINANCIAL_CRITERIA = 0x8009601E;


	/// <summary>
	/// A required certificate is not within its validity period.
	/// </summary>
	public const uint CERT_E_EXPIRED = 0x800B0101;

	/// <summary>
	/// The validity periods of the certification chain do not nest correct
	/// </summary>
	public const uint CERT_E_VALIDITYPERIODNESTING = 0x800B0102;

	/// <summary>
	/// A certificate that can only be used as an end-entity is being used as a CA or vice versa.
	/// </summary>
	public const uint CERT_E_ROLE = 0x800B0103;

	/// <summary>
	/// A path length constraint in the certification chain has been violated.
	/// </summary>
	public const uint CERT_E_PATHLENCONST = 0x800B0104;

	/// <summary>
	/// A certificate contains an unknown extension that is marked 'critical'.
	/// </summary>
	public const uint CERT_E_CRITICAL = 0x800B0105;

	/// <summary>
	/// The certificate is being used for a purpose other than one specified by the issuing CA.
	/// </summary>
	public const uint CERT_E_PURPOSE = 0x800B0106;

	/// <summary>
	///A parent of a given certificate in fact did not issue that child certificate.
	/// </summary>
	public const uint CERT_E_ISSUERCHAINING = 0x800B0107;

	/// <summary>
	/// The certificate is being used for a purpose other than one specified by the issuing CA.
	/// </summary>
	public const uint CERT_E_MALFORMED = 0x800B0108;

	/// <summary>
	/// A certification chain processed correctly but terminated in a root certificate that is not trusted by the trust provider.
	/// </summary>
	public const uint CERT_E_UNTRUSTEDROOT = 0x800B0109;

	/// <summary>
	/// A chain of certificates was not correctly created.
	/// </summary>
	public const uint CERT_E_CHAINING = 0x800B010A;

	/// <summary>
	/// Generic trust failure.
	/// </summary>
	public const uint TRUST_E_FAIL = 0x800B010B;

	/// <summary>
	/// A certificate was explicitly revoked by its issuer.
	/// </summary>
	public const uint CERT_E_REVOKED = 0x800B010C;

	/// <summary>
	/// The root certificate is a testing certificate, and policy settings disallow test certificates.
	/// </summary>
	public const uint CERT_E_UNTRUSTEDTESTROOT = 0x800B010D;

	/// <summary>
	/// The revocation process could not continue, and the certificate could not be checked.
	/// </summary>
	public const uint CERT_E_REVOCATION_FAILURE = 0x800B010E;

	/// <summary>
	/// The certificate's CN name does not match the passed value.
	/// </summary>
	public const uint CERT_E_CN_NO_MATCH = 0x800B010F;

	/// <summary>
	/// The certificate is not valid for the requested usage.
	/// </summary>
	public const uint CERT_E_WRONG_USAGE = 0x800B0110;

	/// <summary>
	/// 	The certificate was explicitly marked as untrusted by the user.
	/// </summary>
	public const uint TRUST_E_EXPLICIT_DISTRUST = 0x800B0111;

	/// <summary>
	///	A certification chain processed correctly, but one of the CA certificates is not trusted by the policy provider. 
	/// </summary>
	public const uint CERT_E_UNTRUSTEDCA = 0x800B0112;

	/// <summary>
	/// The certificate has an invalid policy. 
	/// </summary>
	public const uint CERT_E_INVALID_POLICY = 0x800B0113;

	/// <summary>
	/// The certificate has an invalid name. Either the name is not included in the permitted list, or it is explicitly excluded.
	/// </summary>
	public const uint CERT_E_INVALID_NAME = 0x800B0114;


	/// <summary>
	/// An internal consistency check failed. 
	/// </summary>
	public const uint SCARD_F_INTERNAL_ERROR = 0x80100001;

	/// <summary>
	/// The new cache item exceeds the maximum per-item size defined for the cache.
	/// </summary>
	public const uint SCARD_W_CACHE_ITEM_TOO_BIG = 0x80100072;

}


