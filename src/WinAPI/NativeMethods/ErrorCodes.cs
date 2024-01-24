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
	/// The handle is invalid.
	/// </summary>
	public const int ERROR_INVALID_HANDLE = 6;

	/// <summary>
	/// No more data is available.
	/// </summary>
	public const int ERROR_NO_MORE_ITEMS = 259;
}

