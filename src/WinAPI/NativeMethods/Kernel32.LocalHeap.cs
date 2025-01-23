// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;

namespace LarinLive.WinAPI.NativeMethods;

public static unsafe partial class Kernel32
{
	/// <summary>
	/// Allocates the specified number of bytes from the heap.
	/// </summary>
	/// <param name="uFlags">The memory allocation attributes. The default is the <see cref="LMEM_FIXED"/> value.</param>
	/// <param name="dwBytes">The number of bytes to allocate. If this parameter is zero and the uFlags parameter specifies <see cref="LMEM_MOVEABLE"/>, the function returns a handle to a memory object that is marked as discarded.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-localalloc</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint LocalAlloc(
		[In] uint uFlags,
		[In] nuint dwBytes
	);

	#region Possible values for the LocalAlloc.uFlags parameter

	/// <summary>
	/// ombines <see cref="LMEM_MOVEABLE "/> and <see cref="LMEM_ZEROINIT"/>.
	/// </summary>
	public const uint LHND = LMEM_MOVEABLE | LMEM_ZEROINIT;

	/// <summary>
	/// Allocates fixed memory. The return value is a pointer.
	/// </summary>
	public const uint LMEM_FIXED = 0x00000000;

	/// <summary>
	/// Allocates movable memory. Memory blocks are never moved in physical memory, but they can be moved within the default heap.
	/// The return value is a handle to the memory object. To translate the handle into a pointer, use the <see cref="LocalLock"/> function.
	/// This value cannot be combined with <see cref="LMEM_FIXED"/>.
	/// </summary>
	public const uint LMEM_MOVEABLE = 0x00000002;

	/// <summary>
	/// Initializes memory contents to zero.
	/// </summary>
	public const uint LMEM_ZEROINIT = 0x00000040;

	/// <summary>
	/// Combines <see cref="LMEM_FIXED"/> and <see cref="LMEM_ZEROINIT"/>.
	/// </summary>
	public const uint GPLPTRR = LMEM_FIXED | LMEM_ZEROINIT;

	#endregion

	/// <summary>
	/// Frees the specified local memory object and invalidates its handle.
	/// </summary>
	/// <param name="hMem">A handle to the local memory object. This handle is returned by either the <see cref="LocalAlloc"/> or <see cref="LocalReAlloc"/> function.</param>
	/// <returns>If the function succeeds, the return value is NULL.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-localfree</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint LocalFree(
		[In] nint hMem
	);

	/// <summary>
	/// Locks a local memory object and returns a pointer to the first byte of the object's memory block.
	/// </summary>
	/// <param name="hMem">A handle to the local memory object.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the first byte of the memory block. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-locallock</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern void* LocalLock(
		[In] nint hMem
	);

	/// <summary>
	/// Changes the size or attributes of a specified local memory object. The size can increase or decrease.
	/// </summary>
	/// <param name="hMem">A handle to the local memory object to be reallocated. This handle is returned by either the <see cref="LocalAlloc"/> or <see cref="LocalReAlloc"/> function.</param>
	/// <param name="dwBytes">The new size of the memory block, in bytes. If uFlags specifies <see cref="LMEM_MODIFY"/>, this parameter is ignored.</param>
	/// <param name="uFlags">The reallocation options. </param>
	/// <returns>If the function succeeds, the return value is a handle to the reallocated memory object. If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-Localrealloc</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint LocalReAlloc(
		[In] nint hMem,
		[In] nint dwBytes,
		[In] uint uFlags
	);

	#region Possible values for the LocalReAlloc.uFlags parameter

	/// <summary>
	/// If is specified, the function modifies the attributes of the memory object only (the dwBytes parameter is ignored.) Otherwise, the function reallocates the memory object.
	/// </summary>
	public const uint LMEM_MODIFY = 0x00000080;

	#endregion

	/// <summary>
	/// Decrements the lock count associated with a memory object that was allocated with <see cref="LMEM_MOVEABLE"/>. This function has no effect on memory objects allocated with <see cref="LMEM_FIXED"/>.
	/// </summary>
	/// <param name="hMem">A handle to the local memory object.</param>
	/// <returns>If the memory object is still locked after decrementing the lock count, the return value is a nonzero value. 
	/// If the memory object is unlocked after decrementing the lock count, the function returns zero and <see cref="GetLastError"/> returns <see cref="NO_ERROR"/>.
	/// If the function fails, the return value is zero and GetLastError returns a value other than <see cref="NO_ERROR"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-Localunlock</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool LocalUnlock(
		[In] nint hMem
	);
}
