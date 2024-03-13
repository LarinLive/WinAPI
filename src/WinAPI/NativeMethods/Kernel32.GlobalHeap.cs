// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;

namespace LarinLive.WinAPI.NativeMethods;

public static unsafe partial class Kernel32
{
	/// <summary>
	/// Allocates the specified number of bytes from the heap.
	/// </summary>
	/// <param name="uFlags">The memory allocation attributes.</param>
	/// <param name="dwBytes">The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <see cref="GMEM_MOVEABLE"/>, the function returns a handle to a memory object that is marked as discarded.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-globalalloc</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint GlobalAlloc(
		[In] uint uFlags,
		[In] nuint dwBytes
	);

	#region Possible values for the GlobalAlloc.uFlags parameter

	/// <summary>
	/// ombines <see cref="GMEM_MOVEABLE"/> and <see cref="GMEM_ZEROINIT"/>.
	/// </summary>
	public const uint GHND = GMEM_MOVEABLE | GMEM_ZEROINIT;

	/// <summary>
	/// Allocates fixed memory. The return value is a pointer.
	/// </summary>
	public const uint GMEM_FIXED = 0x00000000;

	/// <summary>
	/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap.
	/// The return value is a handle to the memory object. To translate the handle into a pointer, use the <see cref="GlobalLock"/> function.
	/// This value cannot be combined with <see cref="GMEM_FIXED"/>.
	/// </summary>
	public const uint GMEM_MOVEABLE = 0x00000002;

	/// <summary>
	/// Initializes memory contents to zero.
	/// </summary>
	public const uint GMEM_ZEROINIT = 0x00000040;

	/// <summary>
	/// Combines <see cref="GMEM_FIXED"/> and <see cref="GMEM_ZEROINIT"/>.
	/// </summary>
	public const uint GPTR = GMEM_FIXED | GMEM_ZEROINIT;

	#endregion

	/// <summary>
	/// Frees the specified global memory object and invalidates its handle.
	/// </summary>
	/// <param name="hMem">A handle to the global memory object. This handle is returned by either the <see cref="GlobalAlloc"/> or <see cref="GlobalReAlloc"/> function.</param>
	/// <returns>If the function succeeds, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-globalfree</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint GlobalFree(
		[In] nint hMem
	);

	/// <summary>
	/// Locks a global memory object and returns a pointer to the first byte of the object's memory block.
	/// </summary>
	/// <param name="hMem">A handle to the global memory object.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the first byte of the memory block. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-globallock</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern void* GlobalLock(
		[In] nint hMem
	);

	/// <summary>
	/// Changes the size or attributes of a specified global memory object. The size can increase or decrease.
	/// </summary>
	/// <param name="hMem">A handle to the global memory object to be reallocated. This handle is returned by either the <see cref="GlobalAlloc"/> or <see cref="GlobalReAlloc"/> function.</param>
	/// <param name="dwBytes">The new size of the memory block, in bytes. If uFlags specifies <see cref="GMEM_MODIFY"/>, this parameter is ignored.</param>
	/// <param name="uFlags">The reallocation options. </param>
	/// <returns>If the function succeeds, the return value is a handle to the reallocated memory object. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-globalrealloc</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint GlobalReAlloc(
		[In] nint hMem,
		[In] nint dwBytes,
		[In] uint uFlags
	);

	#region Possible values for the GlobalReAlloc.uFlags parameter

	/// <summary>
	/// If is specified, the function modifies the attributes of the memory object only (the dwBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
	/// </summary>
	public const uint GMEM_MODIFY = 0x00000080;

	#endregion

	/// <summary>
	/// Decrements the lock count associated with a memory object that was allocated with <see cref="GMEM_MOVEABLE"/>. This function has no effect on memory objects allocated with <see cref="GMEM_FIXED"/>.
	/// </summary>
	/// <param name="hMem">A handle to the global memory object.</param>
	/// <returns>If the memory object is still locked after decrementing the lock count, the return value is a nonzero value. 
	/// If the memory object is unlocked after decrementing the lock count, the function returns zero and <see cref="GetLastError"/> returns <see cref="NO_ERROR"/>.
	/// If the function fails, the return value is zero and GetLastError returns a value other than <see cref="NO_ERROR"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-globalunlock</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool GlobalUnlock(
		[In] nint hMem
	);
}
