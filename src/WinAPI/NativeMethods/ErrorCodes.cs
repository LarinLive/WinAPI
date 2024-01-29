// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace Larin.WinAPI.NativeMethods;

/// <summary>
/// Windows System Error codes
/// </summary>
/// <remarks>https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes</remarks>
public static class ErrorCodes
{
	/// <summary>
	/// The operation completed successfully.
	/// </summary>
	public const int ERROR_SUCCESS = 0;

	/// <summary>
	/// Incorrect function.
	/// </summary>
	public const int ERROR_INVALID_FUNCTION = 1;

	/// <summary>
	/// The system cannot find the file specified.
	/// </summary>
	public const int ERROR_FILE_NOT_FOUND = 2;

	/// <summary>
	/// The system cannot find the path specified.
	/// </summary>
	public const int ERROR_PATH_NOT_FOUND = 3;

	/// <summary>
	/// The system cannot open the file.
	/// </summary>
	public const int ERROR_TOO_MANY_OPEN_FILES = 4;

	/// <summary>
	/// Access is denied.
	/// </summary>
	public const int ERROR_ACCESS_DENIED = 5;

	/// <summary>
	/// The data area passed to a system call is too small.
	/// </summary>
	public const int ERROR_INVALID_HANDLE = 6;

	/// <summary>
	/// The storage control blocks were destroyed.
	/// </summary>
	public const int ERROR_ARENA_TRASHED = 7;

	/// <summary>
	/// Not enough memory resources are available to process this command.
	/// </summary>
	public const int ERROR_NOT_ENOUGH_MEMORY = 8;

	/// <summary>
	/// The storage control block address is invalid.
	/// </summary>
	public const int ERROR_INVALID_BLOCK = 9;

	/// <summary>
	/// The environment is incorrect.
	/// </summary>
	public const int ERROR_BAD_ENVIRONMENT = 10;

	/// <summary>
	/// An attempt was made to load a program with an incorrect format.
	/// </summary>
	public const int ERROR_BAD_FORMAT = 11;

	/// <summary>
	/// The access code is invalid.
	/// </summary>
	public const int ERROR_INVALID_ACCESS = 12;

	/// <summary>
	/// The data is invalid.
	/// </summary>
	public const int ERROR_INVALID_DATA = 13;

	/// <summary>
	/// Not enough storage is available to complete this operation.
	/// </summary>
	public const int ERROR_OUTOFMEMORY = 14;

	/// <summary>
	/// The system cannot find the drive specified.
	/// </summary>
	public const int ERROR_INVALID_DRIVE = 15;

	/// <summary>
	/// The directory cannot be removed.
	/// </summary>
	public const int ERROR_CURRENT_DIRECTORY = 16;

	/// <summary>
	/// The system cannot move the file to a different disk drive.
	/// </summary>
	public const int ERROR_NOT_SAME_DEVICE = 17;

	/// <summary>
	/// There are no more files.
	/// </summary>
	public const int ERROR_NO_MORE_FILES = 18;

	/// <summary>
	/// The media is write protected.
	/// </summary>
	public const int ERROR_WRITE_PROTECT = 19;

	/// <summary>
	/// The system cannot find the device specified.
	/// </summary>
	public const int ERROR_BAD_UNIT = 20;

	/// <summary>
	/// The device is not ready.
	/// </summary>
	public const int ERROR_NOT_READY = 21;

	/// <summary>
	/// The device does not recognize the command.
	/// </summary>
	public const int ERROR_BAD_COMMAND = 22;

	/// <summary>
	/// Data error (cyclic redundancy check).
	/// </summary>
	public const int ERROR_CRC = 23;

	/// <summary>
	/// The program issued a command but the command length is incorrect.
	/// </summary>
	public const int ERROR_BAD_LENGTH = 24;

	/// <summary>
	/// The drive cannot locate a specific area or track on the disk.
	/// </summary>
	public const int ERROR_SEEK = 25;

	/// <summary>
	/// The specified disk or diskette cannot be accessed.
	/// </summary>
	public const int ERROR_NOT_DOS_DISK = 26;

	/// <summary>
	/// The drive cannot find the sector requested.
	/// </summary>
	public const int ERROR_SECTOR_NOT_FOUND = 27;

	/// <summary>
	/// The printer is out of paper.
	/// </summary>
	public const int ERROR_OUT_OF_PAPER = 28;

	/// <summary>
	/// The system cannot write to the specified device.
	/// </summary>
	public const int ERROR_WRITE_FAULT = 29;

	/// <summary>
	/// The system cannot read from the specified device.
	/// </summary>
	public const int ERROR_READ_FAULT = 30;

	/// <summary>
	/// A device attached to the system is not functioning.
	/// </summary>
	public const int ERROR_GEN_FAILURE = 31;

	/// <summary>
	/// The process cannot access the file because it is being used by another process.
	/// </summary>
	public const int ERROR_SHARING_VIOLATION = 32;

	/// <summary>
	/// The process cannot access the file because another process has locked a portion of the file.
	/// </summary>
	public const int ERROR_LOCK_VIOLATION = 33;

	/// <summary>
	/// Reached the end of the file.
	/// </summary>
	public const int ERROR_HANDLE_EOF = 38;

	/// <summary>
	/// The disk is full.
	/// </summary>
	public const int ERROR_HANDLE_DISK_FULL = 39;

	/// <summary>
	/// The request is not supported.
	/// </summary>
	public const int ERROR_NOT_SUPPORTED = 50;

	/// <summary>
	/// The file exists.
	/// </summary>
	public const int ERROR_FILE_EXISTS = 80;

	/// <summary>
	/// The filename, directory name, or volume label syntax is incorrect.
	/// </summary>
	public const int ERROR_INSUFFICIENT_BUFFER = 122;

	/// <summary>
	/// The handle is invalid.
	/// </summary>
	public const int ERROR_INVALID_NAME = 123;

	/// <summary>
	/// Cannot create a file when that file already exists.
	/// </summary>
	public const int ERROR_ALREADY_EXISTS = 183;

	/// <summary>
	/// More data is available.
	/// </summary>
	public const int ERROR_MORE_DATA = 234;

	/// <summary>
	/// The wait operation timed out.
	/// </summary>
	public const int WAIT_TIMEOUT = 258;

	/// <summary>
	/// No more data is available.
	/// </summary>
	public const int ERROR_NO_MORE_ITEMS = 259;

	/// <summary>
	/// The directory name is invalid.
	/// </summary>
	public const int ERROR_DIRECTORY = 267;

	/// <summary>
	/// Cannot find the original signer.
	/// </summary>
	public const int CRYPT_E_SIGNER_NOT_FOUND = unchecked((int)0x8009100E);

	/// <summary>
	/// Cannot find object or property.
	/// </summary>
	public const int CRYPT_E_NOT_FOUND = unchecked((int)0x80092004);

	/// <summary>
	/// The signed cryptographic message does not have a signer for the specified signer index.
	/// </summary>
	public const int CRYPT_E_NO_SIGNER = unchecked((int)0x8009200E);

	/// <summary>
	/// The certificate or signature has been revoked.
	/// </summary>
	public const int CRYPT_E_REVOKED = unchecked((int)0x80092010);

	/// <summary>
	/// The signature of the certificate cannot be verified.
	/// </summary>
	public const int TRUST_E_CERT_SIGNATURE = unchecked((int)0x80096004);

	/// <summary>
	/// A certification chain processed correctly but terminated in a root certificate that is not trusted by the trust provider.
	/// </summary>
	public const int CERT_E_UNTRUSTEDROOT = unchecked((int)0x800B0109);

	/// <summary>
	/// The root certificate is a testing certificate, and policy settings disallow test certificates.
	/// </summary>
	public const int CERT_E_UNTRUSTEDTESTROOT = unchecked((int)0x800B010D);

	/// <summary>
	/// A chain of certificates was not correctly created.
	/// </summary>
	public const int CERT_E_CHAINING = unchecked((int)0x800B010A);

	/// <summary>
	/// The certificate is not valid for the requested usage.
	/// </summary>
	public const int CERT_E_WRONG_USAGE = unchecked((int)0x800B0110);

	/// <summary>
	/// A required certificate is not within its validity period.
	/// </summary>
	public const int CERT_E_EXPIRED = unchecked((int)0x800B0101);

	/// <summary>
	/// The certificate has an invalid name. Either the name is not included in the permitted list, or it is explicitly excluded.
	/// </summary>
	public const int CERT_E_INVALID_NAME = unchecked((int)0x800B0114);

	/// <summary>
	/// The certificate has an invalid policy. 
	/// </summary>
	public const int CERT_E_INVALID_POLICY = unchecked((int)0x800B0113);

	/// <summary>
	/// The basic constraints of the certificate are not valid, or they are missing.
	/// </summary>
	public const int TRUST_E_BASIC_CONSTRAINTS = unchecked((int)0x80096019);

	/// <summary>
	/// The validity periods of the certification chain do not nest correctly.
	/// </summary>
	public const int CERT_E_CRITICAL = unchecked((int)0x800B0102);

	/// <summary>
	/// The validity periods of the certification chain do not nest correct
	/// </summary>
	public const int CERT_E_VALIDITYPERIODNESTING = unchecked((int)0x800B0102);

	/// <summary>
	/// The revocation function was unable to check revocation for the certificate.
	/// </summary>
	public const int CRYPT_E_NO_REVOCATION_CHECK = unchecked((int)0x80092012);

	/// <summary>
	/// The revocation function was unable to check revocation because the revocation server was offline.
	/// </summary>
	public const int CRYPT_E_REVOCATION_OFFLINE = unchecked((int)0x80092013);

	/// <summary>
	/// The certificate is being used for a purpose other than one specified by the issuing CA.
	/// </summary>
	public const int CERT_E_PURPOSE = unchecked((int)0x800B0106);

	/// <summary>
	/// The revocation process could not continue, and the certificate could not be checked.
	/// </summary>
	public const int CERT_E_REVOCATION_FAILURE = unchecked((int)0x800B010E);

	/// <summary>
	/// The certificate's CN name does not match the passed value.
	/// </summary>
	public const int CERT_E_CN_NO_MATCH = unchecked((int)0x800B010F);

	/// <summary>
	/// A certificate that can only be used as an end-entity is being used as a CA or vice versa.
	/// </summary>
	public const int CERT_E_ROLE = unchecked((int)0x800B0103);
}


