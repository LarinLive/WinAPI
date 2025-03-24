// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Drawing;
using System;
using System.Reflection.Metadata;
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

	/// <summary>
	/// Retrieves the name of a volume on a computer. <see cref="FindFirstVolumeW"/> is used to begin scanning the volumes of a computer.
	/// </summary>
	/// <param name="lpszVolumeName">A pointer to a buffer that receives a null-terminated string that specifies a volume GUID path for the first volume that is found.</param>
	/// <param name="cchBufferLength">The length of the buffer to receive the volume GUID path, in TCHARs.</param>
	/// <returns>If the function succeeds, the return value is a search handle used in a subsequent call to the <see cref="FindNextVolumeW "/> and <see cref="FindVolumeClose"/> functions. 
	/// If the function fails to find any volumes, the return value is the <see cref="INVALID_HANDLE_VALUE"/> error code.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-findfirstvolumew</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint FindFirstVolumeW(
		[Out] char* lpszVolumeName,
		[In] uint cchBufferLength
	);

	/// <summary>
	/// Continues a volume search started by a call to the <see cref="FindFirstVolumeW"/> function. <see cref="FindNextVolumeW"/> finds one volume per call.
	/// </summary>
	/// <param name="hFindVolume">The volume search handle returned by a previous call to the <see cref="FindFirstVolumeW"/> function.</param>
	/// <param name="lpszVolumeName">A pointer to a string that receives the volume GUID path that is found.</param>
	/// <param name="cchBufferLength">The length of the buffer that receives the volume GUID path, in TCHARs.</param>
	/// <returns>f the function succeeds, the return value is nonzero. 
	/// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
	/// If no matching files can be found, the <see cref="GetLastError"/> function returns the <see cref="ERROR_NO_MORE_FILES"/> error code.
	/// In that case, close the search with the <see cref="FindVolumeClose"/> function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-findnextvolumew</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool FindNextVolumeW(
		[In] nint hFindVolume,
		[Out] char* lpszVolumeName,
		[In] uint cchBufferLength
	);

	/// <summary>
	/// Closes the specified volume search handle. The <see cref="FindFirstVolumeW"/> and <see cref="FindNextVolumeW"/> functions use this search handle to locate volumes.
	/// </summary>
	/// <param name="hFindVolume">The volume search handle to be closed. This handle must have been previously opened by the <see cref="FindFirstVolumeW"/> function.</param>
	/// <returns>If the function succeeds, the return value is nonzero.	If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-findvolumeclose</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool FindVolumeClose(
		[In] nint hFindVolume
	);

	/// <summary>
	/// Retrieves the final path for the specified file.
	/// </summary>
	/// <param name="hFile">A handle to a file or directory.</param>
	/// <param name="lpszFilePath">A pointer to a buffer that receives the path of hFile.</param>
	/// <param name="cchFilePath">The size of lpszFilePath, in TCHARs. This value must include a NULL termination character.</param>
	/// <param name="dwFlags">The type of result to return.</param>
	/// <returns>If the function succeeds, the return value is the length of the string received by lpszFilePath, in TCHARs. This value does not include the size of the terminating null character.
	/// If the function fails because lpszFilePath is too small to hold the string plus the terminating null character, the return value is the required buffer size, in TCHARs.
	/// This value includes the size of the terminating null character.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-getfinalpathnamebyhandlew</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool GetFinalPathNameByHandleW(
	[In] nint hFile,
	[Out] char* lpszFilePath,
	[In] uint cchFilePath,
	[In] uint dwFlags
	);

	#region Possible values for the GetFinalPathNameByHandleW.dwFlags parameter

	/// <summary>
	/// 	Return the normalized drive name. This is the default.
	/// </summary>
	public const uint FILE_NAME_NORMALIZED = 0x0;

	/// <summary>
	/// Return the opened file name (not normalized).
	/// </summary>
	public const uint FILE_NAME_OPENED = 0x8;

	/// <summary>
	/// Return the path with the drive letter. This is the default.
	/// </summary>
	public const uint VOLUME_NAME_DOS = 0x0;

	/// <summary>
	/// Return the path with a volume GUID path instead of the drive name.
	/// </summary>
	public const uint VOLUME_NAME_GUID = 0x1;

	/// <summary>
	/// Return the path with no drive information.
	/// </summary>
	public const uint VOLUME_NAME_NONE = 0x4;

	/// <summary>
	/// Return the NT device object path.
	/// </summary>
	public const uint VOLUME_NAME_NT = 0x2;

	#endregion


	/// <summary>
	/// Retrieves information about the file system and volume associated with the specified file.
	/// </summary>
	/// <param name="hFile">A handle to the file.</param>
	/// <param name="lpVolumeNameBuffer">A pointer to a buffer that receives the name of a specified volume. The maximum buffer size is <see cref="MAX_PATH"/>+1.</param>
	/// <param name="nVolumeNameSize">The length of a volume name buffer, in WCHARs. The maximum buffer size is <see cref="MAX_PATH"/>+1. This parameter is ignored if the volume name buffer is not supplied.</param>
	/// <param name="lpVolumeSerialNumber">A pointer to a variable that receives the volume serial number. This parameter can be NULL if the serial number is not required.
	/// This function returns the volume serial number that the operating system assigns when a hard disk is formatted.</param>
	/// <param name="lpMaximumComponentLength">A pointer to a variable that receives the maximum length, in WCHARs, of a file name component that a specified file system supports.
	/// A file name component is the portion of a file name between backslashes. 
	/// /// The value that is stored in the variable that* lpMaximumComponentLength points to is used to indicate that a specified file system supports long names.
	/// For example, for a FAT file system that supports long names, the function stores the value 255, rather than the previous 8.3 indicator.
	/// Long names can also be supported on systems that use the NTFS file system.</param>
	/// <param name="lpFileSystemFlags">A pointer to a variable that receives flags associated with the specified file system.</param>
	/// <param name="lpFileSystemNameBuffer">A pointer to a buffer that receives the name of the file system, for example, the FAT file system or the NTFS file system.
	/// The buffer size is specified by the nFileSystemNameSize parameter.</param>
	/// <param name="nFileSystemNameSize">The length of the file system name buffer, in WCHARs. The maximum buffer size is <see cref="MAX_PATH"/>+1.
	/// This parameter is ignored if the file system name buffer is not supplied.</param>
	/// <returns>If all the requested information is retrieved, the return value is nonzero. If not all the requested information is retrieved, the return value is zero. 
	/// To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-getvolumeinformationbyhandlew</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool GetVolumeInformationByHandleW(
		[In] nint hFile,
		[Out, Optional] char* lpVolumeNameBuffer,
		[In] uint nVolumeNameSize,
		[Out, Optional] uint* lpVolumeSerialNumber,
		[Out, Optional] uint* lpMaximumComponentLength,
		[Out, Optional] uint* lpFileSystemFlags,
		[Out, Optional] char* lpFileSystemNameBuffer,
		[In] uint nFileSystemNameSize
	);

	/// <summary>
	/// Retrieves information about the file system and volume associated with the specified root directory.
	/// </summary>
	/// <param name="lpRootPathName">A pointer to a string that contains the root directory of the volume to be described. If this parameter is NULL, the root of the current directory is used.
	/// A trailing backslash is required.For example, specify \\MyServer\MyShare as "\\MyServer\MyShare\", or the C drive as "C:\".</param>
	/// <param name="lpVolumeNameBuffer">A pointer to a buffer that receives the name of a specified volume. The maximum buffer size is <see cref="MAX_PATH"/>+1.</param>
	/// <param name="nVolumeNameSize">The length of a volume name buffer, in WCHARs. The maximum buffer size is <see cref="MAX_PATH"/>+1. This parameter is ignored if the volume name buffer is not supplied.</param>
	/// <param name="lpVolumeSerialNumber">A pointer to a variable that receives the volume serial number. This parameter can be NULL if the serial number is not required.
	/// This function returns the volume serial number that the operating system assigns when a hard disk is formatted.</param>
	/// <param name="lpMaximumComponentLength">A pointer to a variable that receives the maximum length, in WCHARs, of a file name component that a specified file system supports.
	/// A file name component is the portion of a file name between backslashes. 
	/// /// The value that is stored in the variable that* lpMaximumComponentLength points to is used to indicate that a specified file system supports long names.
	/// For example, for a FAT file system that supports long names, the function stores the value 255, rather than the previous 8.3 indicator.
	/// Long names can also be supported on systems that use the NTFS file system.</param>
	/// <param name="lpFileSystemFlags">A pointer to a variable that receives flags associated with the specified file system.</param>
	/// <param name="lpFileSystemNameBuffer">A pointer to a buffer that receives the name of the file system, for example, the FAT file system or the NTFS file system.
	/// The buffer size is specified by the nFileSystemNameSize parameter.</param>
	/// <param name="nFileSystemNameSize">The length of the file system name buffer, in WCHARs. The maximum buffer size is <see cref="MAX_PATH"/>+1.
	/// This parameter is ignored if the file system name buffer is not supplied.</param>
	/// <returns>If all the requested information is retrieved, the return value is nonzero. If not all the requested information is retrieved, the return value is zero. 
	/// To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-getvolumeinformationw</remarks>
		[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool GetVolumeInformationW(
		[In, Optional] char* lpRootPathName,
		[Out, Optional] char* lpVolumeNameBuffer,
		[In] uint nVolumeNameSize,
		[Out, Optional] uint* lpVolumeSerialNumber,
		[Out, Optional] uint* lpMaximumComponentLength,
		[Out, Optional] uint* lpFileSystemFlags,
		[Out, Optional] char* lpFileSystemNameBuffer,
		[In] uint nFileSystemNameSize
	);

	#region FileSystemFlags values for GetVolumeInformationByHandleW and GetVolumeInformationW fucntions

	/// <summary>
	/// The specified volume supports case-sensitive file names.
	/// </summary>
	public const uint FILE_CASE_SENSITIVE_SEARCH = 0x00000001;

	/// <summary>
	/// The specified volume supports preserved case of file names when it places a name on disk.
	/// </summary>
	public const uint FILE_CASE_PRESERVED_NAMES = 0x00000002;

	/// <summary>
	/// The specified volume supports Unicode in file names as they appear on disk.
	/// </summary>
	public const uint FILE_UNICODE_ON_DISK = 0x00000004;

	/// <summary>
	/// The specified volume preserves and enforces access control lists (ACL). For example, the NTFS file system preserves and enforces ACLs, and the FAT file system does not.
	/// </summary>
	public const uint FILE_PERSISTENT_ACLS = 0x00000008;

	/// <summary>
	/// The specified volume supports file-based compression.
	/// </summary>
	public const uint FILE_FILE_COMPRESSION = 0x00000010;

	/// <summary>
	/// The specified volume supports disk quotas.
	/// </summary>
	public const uint FILE_VOLUME_QUOTAS = 0x00000020;

	/// <summary>
	/// The specified volume supports sparse files.
	/// </summary>
	public const uint FILE_SUPPORTS_SPARSE_FILES = 0x00000040;

	/// <summary>
	/// The specified volume supports reparse points.
	/// </summary>
	public const uint FILE_SUPPORTS_REPARSE_POINTS = 0x00000080;

	/// <summary>
	/// The file system supports remote storage.
	/// </summary>
	public const uint FILE_SUPPORTS_REMOTE_STORAGE = 0x00000100;

	/// <summary>
	/// On a successful cleanup operation, the file system returns information that describes additional actions taken during cleanup, such as deleting the file. 
	/// File system filters can examine this information in their post-cleanup callback.
	/// </summary>
	public const uint FILE_RETURNS_CLEANUP_RESULT_INFO = 0x00000200;

	/// <summary>
	/// The file system supports POSIX-style delete and rename operations.
	/// </summary>
	public const uint FILE_SUPPORTS_POSIX_UNLINK_RENAME = 0x00000400;

	/// <summary>
	/// The specified volume is a compressed volume, for example, a DoubleSpace volume.
	/// </summary>
	public const uint FILE_VOLUME_IS_COMPRESSED = 0x00008000;

	/// <summary>
	/// The specified volume supports object identifiers.
	/// </summary>
	public const uint FILE_SUPPORTS_OBJECT_IDS = 0x00010000;

	/// <summary>
	/// The specified volume supports the Encrypted File System (EFS).
	/// </summary>
	public const uint FILE_SUPPORTS_ENCRYPTION = 0x00020000;

	/// <summary>
	/// The specified volume supports named streams.
	/// </summary>
	public const uint FILE_NAMED_STREAMS = 0x00040000;

	/// <summary>
	/// The specified volume is read-only.
	/// </summary>
	public const uint FILE_READ_ONLY_VOLUME = 0x00080000;

	/// <summary>
	/// The specified volume supports a single sequential write.
	/// </summary>
	public const uint FILE_SEQUENTIAL_WRITE_ONCE = 0x00100000;

	/// <summary>
	/// The specified volume supports transactions.
	/// </summary>
	public const uint FILE_SUPPORTS_TRANSACTIONS = 0x00200000;

	/// <summary>
	/// The specified volume supports hard links.
	/// </summary>
	public const uint FILE_SUPPORTS_HARD_LINKS = 0x00400000;

	/// <summary>
	/// The specified volume supports extended attributes. An extended attribute is a piece of application-specific metadata that an application can associate with a file and is not part of the file's data.
	/// </summary>
	public const uint FILE_SUPPORTS_EXTENDED_ATTRIBUTES = 0x00800000;

	/// <summary>
	/// The file system supports open by FileID.
	/// </summary>
	public const uint FILE_SUPPORTS_OPEN_BY_FILE_ID = 0x01000000;

	/// <summary>
	/// The specified volume supports update sequence number (USN) journals.
	/// </summary>
	public const uint FILE_SUPPORTS_USN_JOURNAL = 0x02000000;

	/// <summary>
	/// The file system supports integrity streams.
	/// </summary>
	public const uint FILE_SUPPORTS_INTEGRITY_STREAMS = 0x04000000;

	/// <summary>
	/// The specified volume supports sharing logical clusters between files on the same volume. The file system reallocates on writes to shared clusters. 
	/// Indicates that FSCTL_DUPLICATE_EXTENTS_TO_FILE is a supported operation.
	/// </summary>
	public const uint FILE_SUPPORTS_BLOCK_REFCOUNTING = 0x08000000;

	/// <summary>
	/// The file system tracks whether each cluster of a file contains valid data (either from explicit file writes or automatic zeros) or invalid data (has not yet been written to or zeroed).
	/// File systems that use sparse valid data length (VDL) do not store a valid data length and do not require that valid data be contiguous within a file.
	/// </summary>
	public const uint FILE_SUPPORTS_SPARSE_VDL = 0x10000000;

	/// <summary>
	/// The specified volume is a direct access (DAX) volume.
	/// </summary>
	public const uint FILE_DAX_VOLUME = 0x20000000;

	/// <summary>
	/// The file system supports ghosting.
	/// </summary>
	public const uint FILE_SUPPORTS_GHOSTING = 0x40000000;

	#endregion

	/// <summary>
	/// Retrieves a list of drive letters and mounted folder paths for the specified volume.
	/// </summary>
	/// <param name="lpszVolumeName">A volume GUID path for the volume. A volume GUID path is of the form "\\?\Volume{xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx}\".</param>
	/// <param name="lpszVolumePathNames">A pointer to a buffer that receives the list of drive letters and mounted folder paths. The list is an array of null-terminated strings terminated by an additional NULL character.
	/// If the buffer is not large enough to hold the complete list, the buffer holds as much of the list as possible.</param>
	/// <param name="cchBufferLength">The length of the lpszVolumePathNames buffer, in WCHARs, including all NULL characters.</param>
	/// <param name="lpcchReturnLength">If the call is successful, this parameter is the number of WCHARs copied to the lpszVolumePathNames buffer.
	/// Otherwise, this parameter is the size of the buffer required to hold the complete list, in WCHARs.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.
	/// If the buffer is not large enough to hold the complete list, the error code is <see cref="ERROR_MORE_DATA"/> and the lpcchReturnLength parameter receives the required buffer size.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-getvolumepathnamesforvolumenamew</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool GetVolumePathNamesForVolumeNameW(
		[In] char* lpszVolumeName,
		[Out] char* lpszVolumePathNames,
		[In] uint cchBufferLength,
		[Out] uint* lpcchReturnLength
	);

	/// <summary>
	/// Retrieves information about MS-DOS device names. The function can obtain the current mapping for a particular MS-DOS device name. The function can also obtain a list of all existing MS-DOS device names.
	/// </summary>
	/// <param name="lpDeviceName">An MS-DOS device name string specifying the target of the query. The device name cannot have a trailing backslash; for example, use "C:", not "C:\".
	/// This parameter can be NULL. In that case, the <see cref="QueryDosDeviceW"/> function will store a list of all existing MS-DOS device names into the buffer pointed to by lpTargetPath.</param>
	/// <param name="lpTargetPath">A pointer to a buffer that will receive the result of the query. The function fills this buffer with one or more null-terminated strings. The final null-terminated string is followed by an additional NULL.
	/// If lpDeviceName is non-NULL, the function retrieves information about the particular MS-DOS device specified by lpDeviceName.
	/// The first null-terminated string stored into the buffer is the current mapping for the device.The other null-terminated strings represent undeleted prior mappings for the device.
	/// If lpDeviceName is NULL, the function retrieves a list of all existing MS-DOS device names.
	/// Each null-terminated string stored into the buffer is the name of an existing MS-DOS device, for example, \Device\HarddiskVolume1 or \Device\Floppy0.</param>
	/// <param name="ucchMax">The maximum number of TCHARs that can be stored into the buffer pointed to by lpTargetPath.</param>
	/// <returns>If the function succeeds, the return value is the number of TCHARs stored into the buffer pointed to by lpTargetPath. 
	/// If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.
	/// If the buffer is too small, the function fails and the last error code is <see cref="ERROR_INSUFFICIENT_BUFFER"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/fileapi/nf-fileapi-querydosdevicew</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint QueryDosDeviceW(
		[In, Optional] char* lpDeviceName,
		[Out] char* lpTargetPath,
		[In] uint ucchMax
	);
}
