using Larin.WinAPI.NativeMethods;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Larin.WinAPI;

/// <summary>
/// Helper methods for unmanaged memory operations
/// </summary>
[SupportedOSPlatform("WINDOWS")]
public static unsafe class UMM
{
	/// <summary>
	/// Allocates a fixed block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	public static void* GlobalAlloc(nuint size)
	{
		return (void*)Kernel32.GlobalAlloc(Kernel32.GPTR, size);
	}

	/// <summary>
	/// Allocates a fixed block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	public static void* GlobalAlloc(int size)
	{
		return (void*)Kernel32.GlobalAlloc(Kernel32.GPTR, unchecked((uint)size));
	}

	/// <summary>
	/// Allocates a fixed block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a pointer to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	public static void* GlobalAlloc(uint size)
	{
		return (void*)Kernel32.GlobalAlloc(Kernel32.GPTR, size);
	}

	/// <summary>
	/// Allocates a movable block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	public static nint GlobalAllocMovable(nuint size)
	{
		return Kernel32.GlobalAlloc(Kernel32.GHND, size);
	}


	/// <summary>
	/// Allocates a movable block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	public static nint GlobalAllocMovable(int size)
	{
		return Kernel32.GlobalAlloc(Kernel32.GHND, (nuint)size);
	}


	/// <summary>
	/// Allocates a movable block with the specified size from the default unmanaged heap. 
	/// </summary>
	/// <param name="size">The number of bytes to allocate.</param>
	/// <returns>If the function succeeds, the return value is a handle to the newly allocated memory object. If the function fails, the return value is NULL.</returns>
	public static nint GlobalAllocMovable(uint size)
	{
		return Kernel32.GlobalAlloc(Kernel32.GHND, size);
	}


	/// <summary>
	/// Frees the specified global memory object and invalidates its pointer. 
	/// </summary>
	/// <param name="pMem">A pointer to the global memory object</param>
	/// <returns>If the function succeeds, the return value is NULL.</returns>
	public static void* GlobalFree(void* pMem)
	{
		return (void*)Kernel32.GlobalFree((nint)pMem);
	}

	/// <summary>
	/// Frees the specified global memory object and invalidates its handle. 
	/// </summary>
	/// <param name="hMem">A handle to the global memory object</param>
	/// <returns>If the function succeeds, the return value is NULL.</returns>
	public static nint GlobalFree(nint hMem)
	{
		return Kernel32.GlobalFree(hMem);
	}

	/// <summary>
	/// Returns the signed size of the specified structure type
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns>The size of the unmanaged structure type is bytes</returns>
	public static int SizeOf<T>() where T : struct
	{
		return Marshal.SizeOf<T>();
	}

	public static int SizeOf<T>(T structure) where T : struct
	{
		return Marshal.SizeOf(structure);
	}

	/// <summary>
	/// Returns the unsigned size of the specified structure type
	/// </summary>
	/// <typeparam name="T"></typeparam>
	/// <returns></returns>
	public static uint USizeOf<T>() where T : struct
	{
		return unchecked((uint)Marshal.SizeOf<T>());
	}

	public static uint USizeOf<T>(T structure) where T : struct
	{
		return unchecked((uint)Marshal.SizeOf(structure));
	}


	public static void* Add(void* ptr, int offset)
	{
		return (void*)unchecked((nint)ptr + offset);
	}

	public static void* Add(void* ptr, uint offset)
	{
		return (void*)unchecked((nint)ptr + (nint)offset);
	}

	public static void* Add(void* ptr, nint offset)
	{
		return (void*)unchecked((nint)ptr + offset);
	}

	public static nint Add(nint ptr, int offset)
	{
		return unchecked(ptr + offset);
	}

	public static nint Add(nint ptr, uint offset)
	{
		return unchecked(ptr + (nint)offset);
	}

	public static nint Add(nint ptr, nint offset)
	{
		return unchecked(ptr + offset);
	}

	public static void* Sub(void* ptr, int offset)
	{
		return (void*)unchecked((nint)ptr - offset);
	}

	public static void* Sub(void* ptr, uint offset)
	{
		return (void*)unchecked((nint)ptr - (nint)offset);
	}

	public static void* Sub(void* ptr, nint offset)
	{
		return (void*)unchecked((nint)ptr - offset);
	}

	public static nint Sub(nint ptr, int offset)
	{
		return unchecked(ptr - offset);
	}

	public static nint Sub(nint ptr, uint offset)
	{
		return unchecked(ptr - (nint)offset);
	}

	public static nint Sub(nint ptr, nint offset)
	{
		return unchecked(ptr - offset);
	}
}
