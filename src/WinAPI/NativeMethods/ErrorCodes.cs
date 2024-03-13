// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// Windows System Error codes
/// </summary>
/// <remarks>https://learn.microsoft.com/en-us/windows/win32/debug/system-error-codes</remarks>
public static partial class ErrorCodes
{
	/// <summary>
	/// The operation completed successfully.
	/// </summary>
	public const uint NO_ERROR = 0;

	/// <summary>
	/// The operation completed successfully.
	/// </summary>
	public const uint ERROR_SUCCESS = 0;

	/// <summary>
	/// Incorrect function.
	/// </summary>
	public const uint ERROR_INVALID_FUNCTION = 1;

	/// <summary>
	/// The system cannot find the file specified.
	/// </summary>
	public const uint ERROR_FILE_NOT_FOUND = 2;

	/// <summary>
	/// The system cannot find the path specified.
	/// </summary>
	public const uint ERROR_PATH_NOT_FOUND = 3;

	/// <summary>
	/// The system cannot open the file.
	/// </summary>
	public const uint ERROR_TOO_MANY_OPEN_FILES = 4;

	/// <summary>
	/// Access is denied.
	/// </summary>
	public const uint ERROR_ACCESS_DENIED = 5;

	/// <summary>
	/// The data area passed to a system call is too small.
	/// </summary>
	public const uint ERROR_INVALID_HANDLE = 6;

	/// <summary>
	/// The storage control blocks were destroyed.
	/// </summary>
	public const uint ERROR_ARENA_TRASHED = 7;

	/// <summary>
	/// Not enough memory resources are available to process this command.
	/// </summary>
	public const uint ERROR_NOT_ENOUGH_MEMORY = 8;

	/// <summary>
	/// The storage control block address is invalid.
	/// </summary>
	public const uint ERROR_INVALID_BLOCK = 9;

	/// <summary>
	/// The environment is incorrect.
	/// </summary>
	public const uint ERROR_BAD_ENVIRONMENT = 10;

	/// <summary>
	/// An attempt was made to load a program with an incorrect format.
	/// </summary>
	public const uint ERROR_BAD_FORMAT = 11;

	/// <summary>
	/// The access code is invalid.
	/// </summary>
	public const uint ERROR_INVALID_ACCESS = 12;

	/// <summary>
	/// The data is invalid.
	/// </summary>
	public const uint ERROR_INVALID_DATA = 13;

	/// <summary>
	/// Not enough storage is available to complete this operation.
	/// </summary>
	public const uint ERROR_OUTOFMEMORY = 14;

	/// <summary>
	/// The system cannot find the drive specified.
	/// </summary>
	public const uint ERROR_INVALID_DRIVE = 15;

	/// <summary>
	/// The directory cannot be removed.
	/// </summary>
	public const uint ERROR_CURRENT_DIRECTORY = 16;

	/// <summary>
	/// The system cannot move the file to a different disk drive.
	/// </summary>
	public const uint ERROR_NOT_SAME_DEVICE = 17;

	/// <summary>
	/// There are no more files.
	/// </summary>
	public const uint ERROR_NO_MORE_FILES = 18;

	/// <summary>
	/// The media is write protected.
	/// </summary>
	public const uint ERROR_WRITE_PROTECT = 19;

	/// <summary>
	/// The system cannot find the device specified.
	/// </summary>
	public const uint ERROR_BAD_UNIT = 20;

	/// <summary>
	/// The device is not ready.
	/// </summary>
	public const uint ERROR_NOT_READY = 21;

	/// <summary>
	/// The device does not recognize the command.
	/// </summary>
	public const uint ERROR_BAD_COMMAND = 22;

	/// <summary>
	/// Data error (cyclic redundancy check).
	/// </summary>
	public const uint ERROR_CRC = 23;

	/// <summary>
	/// The program issued a command but the command length is incorrect.
	/// </summary>
	public const uint ERROR_BAD_LENGTH = 24;

	/// <summary>
	/// The drive cannot locate a specific area or track on the disk.
	/// </summary>
	public const uint ERROR_SEEK = 25;

	/// <summary>
	/// The specified disk or diskette cannot be accessed.
	/// </summary>
	public const uint ERROR_NOT_DOS_DISK = 26;

	/// <summary>
	/// The drive cannot find the sector requested.
	/// </summary>
	public const uint ERROR_SECTOR_NOT_FOUND = 27;

	/// <summary>
	/// The printer is out of paper.
	/// </summary>
	public const uint ERROR_OUT_OF_PAPER = 28;

	/// <summary>
	/// The system cannot write to the specified device.
	/// </summary>
	public const uint ERROR_WRITE_FAULT = 29;

	/// <summary>
	/// The system cannot read from the specified device.
	/// </summary>
	public const uint ERROR_READ_FAULT = 30;

	/// <summary>
	/// A device attached to the system is not functioning.
	/// </summary>
	public const uint ERROR_GEN_FAILURE = 31;

	/// <summary>
	/// The process cannot access the file because it is being used by another process.
	/// </summary>
	public const uint ERROR_SHARING_VIOLATION = 32;

	/// <summary>
	/// The process cannot access the file because another process has locked a portion of the file.
	/// </summary>
	public const uint ERROR_LOCK_VIOLATION = 33;

	/// <summary>
	/// Reached the end of the file.
	/// </summary>
	public const uint ERROR_HANDLE_EOF = 38;

	/// <summary>
	/// The disk is full.
	/// </summary>
	public const uint ERROR_HANDLE_DISK_FULL = 39;

	/// <summary>
	/// The request is not supported.
	/// </summary>
	public const uint ERROR_NOT_SUPPORTED = 50;

	/// <summary>
	/// The file exists.
	/// </summary>
	public const uint ERROR_FILE_EXISTS = 80;

	/// <summary>
	/// The directory or file cannot be created.
	/// </summary>
	public const uint ERROR_CANNOT_MAKE = 82;

	/// <summary>
	/// The local device name is already in use.
	/// </summary>
	public const uint ERROR_ALREADY_ASSIGNED = 85;

	/// <summary>
	/// The specified network password is not correct.
	/// </summary>
	public const uint ERROR_INVALID_PASSWORD = 86;

	/// <summary>
	/// The parameter is incorrect.
	/// </summary>
	public const uint ERROR_INVALID_PARAMETER = 87;

	/// <summary>
	/// The filename, directory name, or volume label syntax is incorrect.
	/// </summary>
	public const uint ERROR_INSUFFICIENT_BUFFER = 122;

	/// <summary>
	/// The handle is invalid.
	/// </summary>
	public const uint ERROR_INVALID_NAME = 123;

	/// <summary>
	/// The system call level is not correct.
	/// </summary>
	public const uint ERROR_INVALID_LEVEL = 124;

	/// <summary>
	/// Cannot create a file when that file already exists.
	/// </summary>
	public const uint ERROR_ALREADY_EXISTS = 183;

	/// <summary>
	/// More data is available.
	/// </summary>
	public const uint ERROR_MORE_DATA = 234;

	/// <summary>
	/// The wait operation timed out.
	/// </summary>
	public const uint WAIT_TIMEOUT = 258;

	/// <summary>
	/// No more data is available.
	/// </summary>
	public const uint ERROR_NO_MORE_ITEMS = 259;

	/// <summary>
	/// The directory name is invalid.
	/// </summary>
	public const uint ERROR_DIRECTORY = 267;

	/// <summary>
	/// Attempt to access invalid address.
	/// </summary>
	public const uint ERROR_INVALID_ADDRESS = 487;

	/// <summary>
	/// A stop control has been sent to a service that other running services are dependent on.
	/// </summary>
	public const uint ERROR_DEPENDENT_SERVICES_RUNNING = 1051;

	/// <summary>
	/// The requested control is not valid for this service.
	/// </summary>
	public const uint ERROR_INVALID_SERVICE_CONTROL = 1052;

	/// <summary>
	/// The service did not respond to the start or control request in a timely fashion.
	/// </summary>
	public const uint ERROR_SERVICE_REQUEST_TIMEOUT = 1053;

	/// <summary>
	/// A thread could not be created for the service.
	/// </summary>
	public const uint ERROR_SERVICE_NO_THREAD = 1054;

	/// <summary>
	/// The service database is locked.
	/// </summary>
	public const uint ERROR_SERVICE_DATABASE_LOCKED = 1055;

	/// <summary>
	/// An instance of the service is already running.
	/// </summary>
	public const uint ERROR_SERVICE_ALREADY_RUNNING = 1056;

	/// <summary>
	/// The account name is invalid or does not exist, or the password is invalid for the account name specified.
	/// </summary>
	public const uint ERROR_INVALID_SERVICE_ACCOUNT = 1057;

	/// <summary>
	/// The service cannot be started, either because it is disabled or because it has no enabled devices associated with it.
	/// </summary>
	public const uint ERROR_SERVICE_DISABLED = 1058;

	/// <summary>
	/// Circular service dependency was specified.
	/// </summary>
	public const uint ERROR_CIRCULAR_DEPENDENCY = 1059;

	/// <summary>
	/// The specified service does not exist as an installed service.
	/// </summary>
	public const uint ERROR_SERVICE_DOES_NOT_EXIST = 1060;

	/// <summary>
	/// The service cannot accept control messages at this time.
	/// </summary>
	public const uint ERROR_SERVICE_CANNOT_ACCEPT_CTRL = 1061;

	/// <summary>
	/// The service has not been started.
	/// </summary>
	public const uint ERROR_SERVICE_NOT_ACTIVE = 1062;

	/// <summary>
	/// The service process could not connect to the service controller.
	/// </summary>
	public const uint ERROR_FAILED_SERVICE_CONTROLLER_CONNECT = 1063;

	/// <summary>
	/// An exception occurred in the service when handling the control request.
	/// </summary>
	public const uint ERROR_EXCEPTION_IN_SERVICE = 1064;

	/// <summary>
	/// The database specified does not exist.
	/// </summary>
	public const uint ERROR_DATABASE_DOES_NOT_EXIST = 1065;

	/// <summary>
	/// The service has returned a service-specific error code.
	/// </summary>
	public const uint ERROR_SERVICE_SPECIFIC_ERROR = 1066;

	/// <summary>
	/// The process terminated unexpectedly.
	/// </summary>
	public const uint ERROR_PROCESS_ABORTED = 1067;

	/// <summary>
	/// The dependency service or group failed to start.
	/// </summary>
	public const uint ERROR_SERVICE_DEPENDENCY_FAIL = 1068;

	/// <summary>
	/// The service did not start due to a logon failure.
	/// </summary>
	public const uint ERROR_SERVICE_LOGON_FAILED = 1069;

	/// <summary>
	/// After starting, the service hung in a start-pending state.
	/// </summary>
	public const uint ERROR_SERVICE_START_HANG = 1070;

	/// <summary>
	/// The specified service database lock is invalid.
	/// </summary>
	public const uint ERROR_INVALID_SERVICE_LOCK = 1071;

	/// <summary>
	/// The specified service has been marked for deletion.
	/// </summary>
	public const uint ERROR_SERVICE_MARKED_FOR_DELETE = 1072;

	/// <summary>
	/// The specified service already exists.
	/// </summary>
	public const uint ERROR_SERVICE_EXISTS = 1073;

	/// <summary>
	/// The system is currently running with the last-known-good configuration.
	/// </summary>
	public const uint ERROR_ALREADY_RUNNING_LKG = 1074;

	/// <summary>
	/// The dependency service does not exist or has been marked for deletion.
	/// </summary>
	public const uint ERROR_SERVICE_DEPENDENCY_DELETED = 1075;

	/// <summary>
	/// The current boot has already been accepted for use as the last-known-good control set.
	/// </summary>
	public const uint ERROR_BOOT_ALREADY_ACCEPTED = 1076;

	/// <summary>
	/// No attempts to start the service have been made since the last boot.
	/// </summary>
	public const uint ERROR_SERVICE_NEVER_STARTED = 1077;

	/// <summary>
	/// The name is already in use as either a service name or a service display name.
	/// </summary>
	public const uint ERROR_DUPLICATE_SERVICE_NAME = 1078;

	/// <summary>
	/// The account specified for this service is different from the account specified for other services running in the same process.
	/// </summary>
	public const uint ERROR_DIFFERENT_SERVICE_ACCOUNT = 1079;

	/// <summary>
	/// Failure actions can only be set for Win32 services, not for drivers.
	/// </summary>
	public const uint ERROR_CANNOT_DETECT_DRIVER_FAILURE = 1080;

	/// <summary>
	/// This service runs in the same process as the service control manager. Therefore, the service control manager cannot take action if this service's process terminates unexpectedly.
	/// </summary>
	public const uint ERROR_CANNOT_DETECT_PROCESS_ABORT = 1081;

	/// <summary>
	/// No recovery program has been configured for this service.
	/// </summary>
	public const uint ERROR_NO_RECOVERY_PROGRAM = 1082;

	/// <summary>
	/// The executable program that this service is configured to run in does not implement the service.
	/// </summary>
	public const uint ERROR_SERVICE_NOT_IN_EXE = 1083;

	/// <summary>
	/// This service cannot be started in Safe Mode.
	/// </summary>
	public const uint ERROR_NOT_SAFEBOOT_SERVICE = 1084;

	/// <summary>
	/// A system shutdown is in progress.
	/// </summary>
	public const uint ERROR_SHUTDOWN_IN_PROGRESS = 1115;

	/// <summary>
	/// Unable to abort the system shutdown because no shutdown was in progress.
	/// </summary>
	public const uint ERROR_NO_SHUTDOWN_IN_PROGRESS = 1116;

	/// <summary>
	/// The service notification client is lagging too far behind the current state of services in the machine.
	/// </summary>
	public const uint ERROR_SERVICE_NOTIFY_CLIENT_LAGGING = 1294;
}
