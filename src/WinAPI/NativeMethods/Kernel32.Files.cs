// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;

namespace LarinLive.WinAPI.NativeMethods;

public static unsafe partial class Kernel32
{
	/// <summary>
	/// Creates or opens a file or I/O device. 
	/// </summary>
	/// <param name="lpFileName">The name of the file or device to be created or opened. You may use either forward slashes (/) or backslashes (\) in this name.</param>
	/// <param name="dwDesiredAccess">The requested access to the file or device, which can be summarized as read, write, both or neither zero).</param>
	/// <param name="dwShareMode">The requested sharing mode of the file or device, which can be read, write, both, delete, all of these, or none. Access requests to attributes or extended attributes are not affected by this flag.</param>
	/// <param name="lpSecurityAttributes">A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure that contains two separate but related data members: an optional security descriptor, and a Boolean value that determines whether the returned handle can be inherited by child processes. 
	/// If this parameter is NULL, the handle returned by CreateFile cannot be inherited by any child processes the application may create and the file or device associated with the returned handle gets a default security descriptor.</param>
	/// <param name="dwCreationDisposition">An action to take on a file or device that exists or does not exist. For devices other than files, this parameter is usually set to <see cref="OPEN_EXISTING"/>.</param>
	/// <param name="dwFlagsAndAttributes">The file or device attributes and flags, <see cref="FILE_ATTRIBUTE_NORMAL"/> being the most common default value for files.</param>
	/// <param name="hTemplateFile">A valid handle to a template file with the <see cref="GENERIC_READ"/> access right. 
	/// The template file supplies file attributes and extended attributes for the file that is being created. 
	/// This parameter can be NULL. When opening an existing file, <see cref="CreateFile"/> ignores this parameter.</param>
	/// <returns>If the function succeeds, the return value is an open handle to the specified file, device, named pipe, or mail slot.
	/// If the function fails, the return value is <see cref="INVALID_HANDLE_VALUE"/>.To get extended error information, call GetLastError.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-createfilew</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint CreateFile(
		[In] string lpFileName,
		[In] uint dwDesiredAccess,
		[In] uint dwShareMode,
		[In, Optional] void* lpSecurityAttributes,
		[In] uint dwCreationDisposition,
		[In] uint dwFlagsAndAttributes,
		[In, Optional] nint hTemplateFile
	);

	#region Possible values for the CreateFile.dwShareMode parameter

	/// <summary>
	/// Prevents subsequent open operations on a file or device if they request delete, read, or write access.
	/// </summary>
	public const uint FILE_SHARE_NONE = 0x0000000;

	/// <summary>
	/// Enables subsequent open operations on a file or device to request read access. Otherwise, no process can open the file or device if it requests read access.
	/// If this flag is not specified, but the file or device has been opened for read access, the function fails.
	/// </summary>
	public const uint FILE_SHARE_READ = 0x00000001;

	/// <summary>
	/// Enables subsequent open operations on a file or device to request write access. Otherwise, no process can open the file or device if it requests write access.
	/// If this flag is not specified, but the file or device has been opened for write access or has a file mapping with write access, the function fails.
	/// </summary>
	public const uint FILE_SHARE_WRITE = 0x00000002;

	/// <summary>
	/// Enables subsequent open operations on a file or device to request delete access. Otherwise, no process can open the file or device if it requests delete access. 
	/// If this flag is not specified, but the file or device has been opened for delete access, the function fails.
	/// </summary>
	public const uint FILE_SHARE_DELETE = 0x00000004;

	#endregion

	#region Possible values for the CreateFile.dwDesiredAccess parameter

	/// <summary>
	/// For a directory, the right to create a file in the directory.
	/// </summary>
	public const uint FILE_ADD_FILE = 0x02;

	/// <summary>
	/// For a directory, the right to create a subdirectory.
	/// </summary>
	public const uint FILE_ADD_SUBDIRECTORY = 0x04;

	/// <summary>
	/// All possible access rights for a file.
	/// </summary>
	public const uint FILE_ALL_ACCESS = STANDARD_RIGHTS_REQUIRED | SYNCHRONIZE | 0x1FF;

	/// <summary>
	/// Generic file read right
	/// </summary>
	public const uint FILE_GENERIC_READ = STANDARD_RIGHTS_READ | FILE_READ_DATA | FILE_READ_ATTRIBUTES | FILE_READ_EA | SYNCHRONIZE;

	/// <summary>
	/// Generic file write right
	/// </summary>
	public const uint FILE_GENERIC_WRITE = STANDARD_RIGHTS_WRITE | FILE_WRITE_DATA | FILE_WRITE_ATTRIBUTES | FILE_WRITE_EA | FILE_APPEND_DATA | SYNCHRONIZE;

	/// <summary>
	/// Generic file execute right
	/// </summary>
	public const uint FILE_GENERIC_EXECUTE = STANDARD_RIGHTS_EXECUTE | FILE_READ_ATTRIBUTES | FILE_EXECUTE | SYNCHRONIZE;


	/// <summary>
	/// For a file object, the right to append data to the file. (For local files, write operations will not overwrite existing data if this flag is specified without <see cref="FILE_WRITE_DATA"/>.) 
	/// For a directory object, the right to create a subdirectory (<see cref="FILE_ADD_SUBDIRECTORY"/>).
	/// </summary>
	public const uint FILE_APPEND_DATA = 0x04;

	/// <summary>
	///For a named pipe, the right to create a pipe.
	/// </summary>
	public const uint FILE_CREATE_PIPE_INSTANCE = 0x04;

	/// <summary>
	///For a directory, the right to delete a directory and all the files it contains, including read-only files.
	/// </summary>
	public const uint FILE_DELETE_CHILD = 0x40;

	/// <summary>
	///For a native code file, the right to execute the file. This access right given to scripts may cause the script to be executable, depending on the script interpreter.
	/// </summary>
	public const uint FILE_EXECUTE = 0x20;

	/// <summary>
	/// For a directory, the right to list the contents of the directory.
	/// </summary>
	public const uint FILE_LIST_DIRECTORY = 0x01;

	/// <summary>
	/// The right to read file attributes.
	/// </summary>
	public const uint FILE_READ_ATTRIBUTES = 0x80;

	/// <summary>
	///For a file object, the right to read the corresponding file data. For a directory object, the right to read the corresponding directory data.
	/// </summary>
	public const uint FILE_READ_DATA = 0x01;

	/// <summary>
	/// The right to read extended file attributes.
	/// </summary>
	public const uint FILE_READ_EA = 0x08;

	/// <summary>
	/// For a directory, the right to traverse the directory. By default, users are assigned the BYPASS_TRAVERSE_CHECKING privilege, which ignores the <see cref="FILE_TRAVERSE"/> access right. 
	/// </summary>
	public const uint FILE_TRAVERSE = 0x20;

	/// <summary>
	/// The right to write file attributes.
	/// </summary>
	public const uint FILE_WRITE_ATTRIBUTES = 0x100;

	/// <summary>
	///For a file object, the right to write data to the file. For a directory object, the right to create a file in the directory (<see cref="FILE_ADD_FILE"/>).
	/// </summary>
	public const uint FILE_WRITE_DATA = 0x02;

	/// <summary>
	/// The right to write extended file attributes.
	/// </summary>
	public const uint FILE_WRITE_EA = 0x10;

	#endregion

	#region Possible values for the CreateFile.dwCreationDisposition parameter

	/// <summary>
	/// Creates a new file, only if it does not already exist. If the specified file exists, the function fails and the last-error code is set to <see cref="ERROR_FILE_EXISTS"/>.
	/// If the specified file does not exist and is a valid path to a writable location, a new file is created.
	/// </summary>
	public const uint CREATE_NEW = 1;

	/// <summary>
	/// Creates a new file, always. If the specified file exists and is writable, the function truncates the file, the function succeeds, and last-error code is set to <see cref="ERROR_ALREADY_EXISTS"/>.
	/// If the specified file does not exist and is a valid path, a new file is created, the function succeeds, and the last-error code is set to zero.
	/// </summary>
	public const uint CREATE_ALWAYS = 2;

	/// <summary>
	/// Opens a file or device, only if it exists. If the specified file or device does not exist, the function fails and the last-error code is set to <see cref="ERROR_FILE_NOT_FOUND"/>
	/// </summary>
	public const uint OPEN_EXISTING = 3;

	/// <summary>
	/// Opens a file, always. If the specified file exists, the function succeeds and the last-error code is set to <see cref="ERROR_ALREADY_EXISTS"/>. 
	/// If the specified file does not exist and is a valid path to a writable location, the function creates a file and the last-error code is set to zero.
	/// </summary>
	public const uint OPEN_ALWAYS = 4;

	/// <summary>
	/// Opens a file and truncates it so that its size is zero bytes, only if it exists. If the specified file does not exist, the function fails and the last-error code is set to <see cref="ERROR_FILE_NOT_FOUND"/>.
	/// The calling process must open the file with the <see cref="GENERIC_WRITE"/> bit set as part of the dwDesiredAccess parameter.
	/// </summary>
	public const uint TRUNCATE_EXISTING = 5;

	#endregion

	#region Possible values for the CreateFile.dwFlagsAndAttributes parameter

	/// <summary>
	/// The file should be archived. Applications use this attribute to mark files for backup or removal.
	/// </summary>
	public const uint FILE_ATTRIBUTE_ARCHIVE = 0x0020;

	/// <summary>
	/// The file or directory is encrypted. For a file, this means that all data in the file is encrypted. For a directory, this means that encryption is the default for newly created files and subdirectories.
	/// </summary>
	public const uint FILE_ATTRIBUTE_ENCRYPTED = 0x4000;

	/// <summary>
	/// The file is hidden. Do not include it in an ordinary directory listing.
	/// </summary>
	public const uint FILE_ATTRIBUTE_HIDDEN = 0x0002;

	/// <summary>
	/// The file does not have other attributes set. This attribute is valid only if used alone.
	/// </summary>
	public const uint FILE_ATTRIBUTE_NORMAL = 0x0080;

	/// <summary>
	/// The data of a file is not immediately available. This attribute indicates that file data is physically moved to offline storage.
	/// This attribute is used by Remote Storage, the hierarchical storage management software. Applications should not arbitrarily change this attribute.
	/// </summary>
	public const uint FILE_ATTRIBUTE_OFFLINE = 0x1000;

	/// <summary>
	/// The file is read only. Applications can read the file, but cannot write to or delete it.
	/// </summary>
	public const uint FILE_ATTRIBUTE_READONLY = 0x0001;

	/// <summary>
	/// The file is part of or used exclusively by an operating system.
	/// </summary>
	public const uint FILE_ATTRIBUTE_SYSTEM = 0x0004;

	/// <summary>
	/// The file is being used for temporary storage.
	/// </summary>
	public const uint FILE_ATTRIBUTE_TEMPORARY = 0x0100;


	/// <summary>
	/// The file is being opened or created for a backup or restore operation. The system ensures that the calling process overrides file security checks when the process has SE_BACKUP_NAME and SE_RESTORE_NAME privileges. 
	/// You must set this flag to obtain a handle to a directory. A directory handle can be passed to some functions instead of a file handle
	/// </summary>
	public const uint FILE_FLAG_BACKUP_SEMANTICS = 0x02000000;

	/// <summary>
	/// The file is to be deleted immediately after all of its handles are closed, which includes the specified handle and any other open or duplicated handles.
	/// If there are existing open handles to a file, the call fails unless they were all opened with the <see cref="FILE_SHARE_DELETE"/> share mode.
	/// Subsequent open requests for the file fail, unless the <see cref="FILE_SHARE_DELETE"/> share mode is specified.
	/// </summary>
	public const uint FILE_FLAG_DELETE_ON_CLOSE = 0x04000000;

	/// <summary>
	/// The file or device is being opened with no system caching for data reads and writes. This flag does not affect hard disk caching or memory mapped files.
	/// There are strict requirements for successfully working with files opened with CreateFile using the <see cref="FILE_FLAG_NO_BUFFERING"/> flag.
	/// </summary>
	public const uint FILE_FLAG_NO_BUFFERING = 0x20000000;

	/// <summary>
	/// The file data is requested, but it should continue to be located in remote storage. It should not be transported back to local storage. This flag is for use by remote storage systems.
	/// </summary>
	public const uint FILE_FLAG_OPEN_NO_RECALL = 0x00100000;

	/// <summary>
	/// Normal reparse point processing will not occur; CreateFile will attempt to open the reparse point. 
	/// When a file is opened, a file handle is returned, whether or not the filter that controls the reparse point is operational.
	/// This flag cannot be used with the <see cref="CREATE_ALWAYS"/> flag. If the file is not a reparse point, then this flag is ignored.
	/// </summary>
	public const uint FILE_FLAG_OPEN_REPARSE_POINT = 0x00200000;

	/// <summary>
	/// The file or device is being opened or created for asynchronous I/O. 
	/// When subsequent I/O operations are completed on this handle, the event specified in the OVERLAPPED structure will be set to the signaled state.
	/// If this flag is specified, the file can be used for simultaneous read and write operations.
	/// If this flag is not specified, then I/O operations are serialized, even if the calls to the read and write functions specify an OVERLAPPED structure.
	/// </summary>
	public const uint FILE_FLAG_OVERLAPPED = 0x40000000;

	/// <summary>
	/// Access will occur according to POSIX rules. This includes allowing multiple files with names, differing only in case, for file systems that support that naming.
	/// </summary>
	public const uint FILE_FLAG_POSIX_SEMANTICS = 0x01000000;

	/// <summary>
	/// Access is intended to be random. The system can use this as a hint to optimize file caching. 
	/// This flag has no effect if the file system does not support cached I/O and <see cref="FILE_FLAG_NO_BUFFERING"/>.
	/// </summary>
	public const uint FILE_FLAG_RANDOM_ACCESS = 0x10000000;

	/// <summary>
	/// The file or device is being opened with session awareness. If this flag is not specified, then per-session devices (such as a device using RemoteFX USB Redirection) 
	/// cannot be opened by processes running in session 0. This flag has no effect for callers not in session 0. This flag is supported only on server editions of Windows.
	/// </summary>
	public const uint FILE_FLAG_SESSION_AWARE = 0x00800000;

	/// <summary>
	/// Access is intended to be sequential from beginning to end. The system can use this as a hint to optimize file caching.
	/// This flag should not be used if read-behind(that is, reverse scans) will be used. 
	/// This flag has no effect if the file system does not support cached I/O and <see cref="FILE_FLAG_NO_BUFFERING"/>.
	/// </summary>
	public const uint FILE_FLAG_SEQUENTIAL_SCAN = 0x08000000;

	/// <summary>
	/// Write operations will not go through any intermediate cache, they will go directly to disk.
	/// </summary>
	public const uint FILE_FLAG_WRITE_THROUGH = 0x80000000;

	#endregion

	/// <summary>
	/// Sends a control code directly to a specified device driver, causing the corresponding device to perform the corresponding operation.
	/// </summary>
	/// <param name="hDevice">A handle to the device on which the operation is to be performed. The device is typically a volume, directory, file, or stream. 
	/// To retrieve a device handle, use the <see cref="CreateFile"/> function.</param>
	/// <param name="dwIoControlCode">The control code for the operation. This value identifies the specific operation to be performed and the type of device on which to perform it.</param>
	/// <param name="lpInBuffer">A pointer to the input buffer that contains the data required to perform the operation. The format of this data depends on the value of the dwIoControlCode parameter.
	/// This parameter can be NULL if dwIoControlCode specifies an operation that does not require input data.</param>
	/// <param name="nInBufferSize">The size of the input buffer, in bytes.</param>
	/// <param name="lpOutBuffer">A pointer to the output buffer that is to receive the data returned by the operation. The format of this data depends on the value of the dwIoControlCode parameter.
	/// This parameter can be NULL if dwIoControlCode specifies an operation that does not return data.</param>
	/// <param name="nOutBufferSize">The size of the output buffer, in bytes.</param>
	/// <param name="lpBytesReturned">A pointer to a variable that receives the size of the data stored in the output buffer, in bytes.</param>
	/// <param name="lpOverlapped">A pointer to an <see cref="OVERLAPPED"/> structure. If hDevice was opened without specifying <see cref="FILE_FLAG_OVERLAPPED"/>, lpOverlapped is ignored.
	/// If hDevice was opened with the <see cref="FILE_FLAG_OVERLAPPED"/> flag, the operation is performed as an overlapped(asynchronous) operation.
	/// In this case, lpOverlapped must point to a valid <see cref="OVERLAPPED"/> structure that contains a handle to an event object. Otherwise, the function fails in unpredictable ways.
	/// For overlapped operations, <see cref="DeviceIoControl"/> returns immediately, and the event object is signaled when the operation has been completed. 
	/// Otherwise, the function does not return until the operation has been completed or an error occurs.</param>
	/// <returns></returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/ioapiset/nf-ioapiset-deviceiocontrol</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool DeviceIoControl(
		[In] nint hDevice,
		[In] uint dwIoControlCode,
		[In, Optional] void* lpInBuffer,
		[In] uint nInBufferSize,
		[Out, Optional] void* lpOutBuffer,
		[In] uint nOutBufferSize,
		[Out, Optional] uint* lpBytesReturned,
		[In, Out, Optional] OVERLAPPED* lpOverlapped
	);
}
