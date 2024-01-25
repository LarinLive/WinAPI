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
}

