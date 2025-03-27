// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;

namespace LarinLive.WinAPI.NativeMethods;

public static unsafe partial class Kernel32
{
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
	/// Determines whether the specified volume is mounted, or if the specified file or directory is on a mounted volume.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_is_volume_mounted</remarks>
	public const uint FSCTL_IS_VOLUME_MOUNTED = 0x00090028;


	/// <summary>
	/// Given a file handle, retrieves a data structure that describes the allocation and location on disk of a specific file, or, given a volume handle, the locations of bad clusters on a volume.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-fsctl_get_retrieval_pointers</remarks>
	public const uint FSCTL_GET_RETRIEVAL_POINTERS = 0x00090073;

	/// <summary>
	/// Contains the starting VCN to the <see cref="FSCTL_GET_RETRIEVAL_POINTERS"/> control code.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-starting_vcn_input_buffer</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct STARTING_VCN_INPUT_BUFFER
	{
		/// <summary>
		/// The VCN at which the operation will begin enumerating extents in the file. This value may be rounded down to the first VCN of the extent in which the specified extent is found.
		/// </summary>
		public long StartingVcn;
	}

	/// <summary>
	/// Contains the output for the  <see cref="FSCTL_GET_RETRIEVAL_POINTERS"/> control code.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-retrieval_pointers_buffer</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct RETRIEVAL_POINTERS_BUFFER
	{
		/// <summary>
		/// The count of elements in the Extents array.
		/// </summary>
		public int ExtentCount;

		/// <summary>
		/// The starting VCN returned by the function call. This is not necessarily the VCN requested by the function call,
		/// as the file system driver may round down to the first VCN of the extent in which the requested starting VCN is found.
		/// </summary>
		public long StartingVcn;

		/// <summary>
		/// The VCN at which the next extent begins. This value minus either StartingVcn (for the first Extents array member) or the NextVcn of the previous member of the array (for all other Extents array members) is the length, in clusters, of the current extent. 
		/// The length is an input to the FSCTL_MOVE_FILE operation.
		/// </summary>
		public long NextVcn;

		/// <summary>
		/// The LCN at which the current extent begins on the volume. 
		/// On the NTFS file system, the value (LONGLONG) –1 indicates either a compression unit that is partially allocated, or an unallocated region of a sparse file.
		/// </summary>
		public long Lcn;
	}


	/// <summary>
	/// Retrieves the physical location of a specified volume on one or more disks.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_volume_get_volume_disk_extents</remarks>
	public const uint IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS = 0x00560000;

	/// <summary>
	/// Represents a physical location on a disk. It is the output buffer for the <see cref="IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS"/> control code.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-volume_disk_extents</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct VOLUME_DISK_EXTENTS
	{
		/// <summary>
		/// The number of disks in the volume (a volume can span multiple disks). An extent is a contiguous run of sectors on one disk. 
		/// When the number of extents returned is greater than one (1), the error code <see cref="ERROR_MORE_DATA"/> is returned. 
		/// You should call <see cref="DeviceIoControl"/> again, allocating enough buffer space based on the value of NumberOfDiskExtents after the first <see cref="DeviceIoControl"/> call.
		/// </summary>
		public uint NumberOfDiskExtents;

		/// <summary>
		/// An array of DISK_EXTENT structures.
		/// </summary>
		public DISK_EXTENT Extents;
	}

	/// <summary>
	/// Represents a disk extent.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-disk_extent</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct DISK_EXTENT
	{

		/// <summary>
		/// The number of the disk that contains this extent. This is the same number that is used to construct the name of the disk, for example, the X in "\\?\PhysicalDriveX" or "\\?\\HarddiskX".
		/// </summary>
		public uint DiskNumber;

		/// <summary>
		/// The offset from the beginning of the disk to the extent, in bytes.
		/// </summary>
		public ulong StartingOffset;

		/// <summary>
		/// The number of bytes in this extent.
		/// </summary>
		public ulong ExtentLength;
	}


	/// <summary>
	/// Retrieves the length of the specified disk, volume, or partition.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_length_info</remarks>
	public const uint IOCTL_DISK_GET_LENGTH_INFO = 0x0007405C;

	/// <summary>
	/// Contains disk, volume, or partition length information used by the <see cref="IOCTL_DISK_GET_LENGTH_INFO"/> control code.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ns-winioctl-get_length_information</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct GET_LENGTH_INFORMATION
	{
		/// <summary>
		/// The length of the disk, volume, or partition, in bytes.
		/// </summary>
		public ulong Length;
	}
}
