// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;

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
	/// Retrieves the length of the specified disk, volume, or partition.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winioctl/ni-winioctl-ioctl_disk_get_length_info</remarks>
	public const uint IOCTL_DISK_GET_LENGTH_INFO = 0x0007405C;

	/// <summary>
	/// ontains disk, volume, or partition length information used by the <see cref="IOCTL_DISK_GET_LENGTH_INFO"/> control code.
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
