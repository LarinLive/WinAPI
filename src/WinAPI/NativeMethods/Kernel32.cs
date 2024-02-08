// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static Larin.WinAPI.NativeMethods.NtStatus;

namespace Larin.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the Kernel32.dll Windows API library
/// </summary>
public static unsafe partial class Kernel32
{
	/// <summary>
	/// Kernel32 library file name
	/// </summary>
	public const string Kernel32Lib = "Kernel32.dll";

	/// <summary>
	/// Invalid handle value
	/// </summary>
	public const nint INVALID_HANDLE_VALUE = -1;

	/// <summary>
	/// The maximum length for a path
	/// </summary>
	public const uint MAX_PATH = 260;

	/// <summary>
	/// Infinite timeout
	/// </summary>
	public const uint INFINITE = 0xFFFFFFFF;

	/// <summary>
	/// Retrieves the calling thread's last-error code value. The last-error code is maintained on a per-thread basis. Multiple threads do not overwrite each other's last-error code.
	/// </summary>
	/// <returns>The return value is the calling thread's last-error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/errhandlingapi/nf-errhandlingapi-getlasterror</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = false)]
	public static extern uint GetLastError();

	/// <summary>
	/// Contains information used in asynchronous (or overlapped) input and output (I/O).
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-overlapped</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct OVERLAPPED
	{
		/// <summary>
		/// The status code for the I/O request. When the request is issued, the system sets this member to <see cref="STATUS_PENDING"/> to indicate that the operation has not yet started. 
		/// When the request is completed, the system sets this member to the status code for the completed request.
		/// </summary>
		public nuint Internal;

		/// <summary>
		/// The number of bytes transferred for the I/O request. The system sets this member if the request is completed without errors.
		/// </summary>
		public nuint InternalHigh;


		/// <summary>
		/// The low-order portion of the file position at which to start the I/O request, as specified by the user. 
		/// This member is nonzero only when performing I/O requests on a seeking device that supports the concept of an offset(also referred to as a file pointer mechanism), such as a file.
		/// Otherwise, this member must be zero.
		/// </summary>
		public uint Offset;

		/// <summary>
		/// The high-order portion of the file position at which to start the I/O request, as specified by the user. 
		/// This member is nonzero only when performing I/O requests on a seeking device that supports the concept of an offset(also referred to as a file pointer mechanism), such as a file.
		/// Otherwise, this member must be zero.
		/// </summary>
		public uint OffsetHigh;

		/// <summary>
		/// A handle to the event that will be set to a signaled state by the system when the operation has completed. 
		/// The user must initialize this member either to zero or a valid event handle using the <see cref="CreateEvent"/> function before passing this structure to any overlapped functions. 
		/// This event can then be used to synchronize simultaneous I/O requests for a device.
		/// </summary>
		public nint hEvent;
	}


	/// <summary>
	/// Contains the security descriptor for an object and specifies whether the handle retrieved by specifying this structure is inheritable.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/wtypesbase/ns-wtypesbase-security_attributes</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SECURITY_ATTRIBUTES
	{
		/// <summary>
		/// The size, in bytes, of this structure. Set this value to the size of the <see cref="SECURITY_ATTRIBUTES"/> structure.
		/// </summary>
		public uint nLength;

		/// <summary>
		/// A pointer to a SECURITY_DESCRIPTOR structure that controls access to the object. 
		/// If the value of this member is NULL, the object is assigned the default security descriptor associated with the access token of the calling process. 
		/// This is not the same as granting access to everyone by assigning a NULL discretionary access control list (DACL). 
		/// By default, the default DACL in the access token of a process allows access only to the user represented by the access token.
		/// </summary>
		public void* lpSecurityDescriptor;

		/// <summary>
		/// A boolean value that specifies whether the returned handle is inherited when a new process is created. If this member is TRUE, the new process inherits the handle.
		/// </summary>
		public bool bInheritHandle;
	}

	/// <summary>
	/// The right to delete the object.
	/// </summary>
	public const uint DELETE = 0x00010000;

	/// <summary>
	/// The right to read the information in the object's security descriptor, not including the information in the system access control list (SACL).
	/// </summary>
	public const uint READ_CONTROL = 0x00020000;

	/// <summary>
	/// The right to modify the discretionary access control list (DACL) in the object's security descriptor.
	/// </summary>
	public const uint WRITE_DAC = 0x00040000;

	/// <summary>
	/// The right to change the owner in the object's security descriptor.
	/// </summary>
	public const uint WRITE_OWNER = 0x00080000;

	/// <summary>
	/// The right to use the object for synchronization. This enables a thread to wait until the object is in the signaled state. Some object types do not support this access right.
	/// </summary>
	public const uint SYNCHRONIZE = 0x00100000;

	/// <summary>
	/// Combines DELETE, READ_CONTROL, WRITE_DAC, and WRITE_OWNER access.
	/// </summary>
	public const uint STANDARD_RIGHTS_REQUIRED = 0x000F0000;

	/// <summary>
	/// Currently defined to equal <see cref="READ_CONTROL"/>.
	/// </summary>
	public const uint STANDARD_RIGHTS_READ = READ_CONTROL;

	/// <summary>
	/// Currently defined to equal <see cref="READ_CONTROL"/>.
	/// </summary>
	public const uint STANDARD_RIGHTS_WRITE = READ_CONTROL;

	/// <summary>
	/// Currently defined to equal <see cref="READ_CONTROL"/>.
	/// </summary>
	public const uint STANDARD_RIGHTS_EXECUTE = READ_CONTROL;

	/// <summary>
	/// Combines DELETE, READ_CONTROL, WRITE_DAC, WRITE_OWNER, and SYNCHRONIZE access.
	/// </summary>
	public const uint STANDARD_RIGHTS_ALL = 0x001F0000;

	/// <summary>
	/// Specific access rights mask
	/// </summary>
	public const uint SPECIFIC_RIGHTS_ALL = 0x0000FFFF;

	/// <summary>
	/// Controls the ability to get or set the SACL in an object's security descriptor.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/secauthz/sacl-access-right</remarks>
	public const uint ACCESS_SYSTEM_SECURITY = 0x01000000;

	/// <summary>
	/// Requests that the object be opened with all the access rights that are valid for the caller.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/secauthz/requesting-access-rights-to-an-object?source=recommendations</remarks>
	public const uint MAXIMUM_ALLOWED = 0x02000000;

	/// <summary>
	/// Read access.
	/// </summary>
	public const uint GENERIC_READ = 0x80000000;

	/// <summary>
	/// Write access.
	/// </summary>
	public const uint GENERIC_WRITE = 0x40000000;

	/// <summary>
	/// Execute access.
	/// </summary>
	public const uint GENERIC_EXECUTE = 0x20000000;

	/// <summary>
	/// All possible access rights.
	/// </summary>
	public const uint GENERIC_ALL = 0x10000000;

	/// <summary>
	/// Impersonation flags exits
	/// </summary>
	public const uint SECURITY_SQOS_PRESENT = 0x00100000;

	/// <summary>
	/// Impersonates a client at the Anonymous impersonation level.
	/// </summary>
	public const uint SECURITY_ANONYMOUS = 0x00000000;

	/// <summary>
	/// Impersonates a client at the Identification impersonation level.
	/// </summary>
	public const uint SECURITY_IDENTIFICATION = 0x00010000;

	/// <summary>
	/// Impersonate a client at the impersonation level. This is the default behavior if no other flags are specified along with the <see cref="SECURITY_SQOS_PRESENT"/> flag.
	/// </summary>
	public const uint SECURITY_IMPERSONATION = 0x00100000;

	/// <summary>
	/// Impersonates a client at the Delegation impersonation level.
	/// </summary>
	public const uint SECURITY_DELEGATION = 0x00110000;

	/// <summary>
	/// The security tracking mode is dynamic. If this flag is not specified, the security tracking mode is static.
	/// </summary>
	public const uint SECURITY_CONTEXT_TRACKING = 0x00040000;

	/// <summary>
	/// Only the enabled aspects of the client's security context are available to the server. If you do not specify this flag, all aspects of the client's security context are available.
	/// This allows the client to limit the groups and privileges that a server can use while impersonating the client.
	/// </summary>
	public const uint SECURITY_EFFECTIVE_ONLY = 0x00080000;

	/// <summary>
	/// Closes an open object handle.
	/// </summary>
	/// <param name="hObject">A valid handle to an open object.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call GetLastError.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-localfree</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint CloseHandle(
		[In] nint hObject
	);

	/// <summary>
	/// Retrieves the current Windows ANSI code page identifier for the operating system.
	/// </summary>
	/// <returns>Returns the current Windows ANSI code page (ACP) identifier for the operating system. See Code Page Identifiers for a list of identifiers for Windows ANSI code pages and other code pages.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-getacp</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint GetACP();

	/// <summary>
	/// Retrieves the command-line string for the current process.
	/// </summary>
	/// <returns>The return value is a pointer to the command-line string for the current process.The lifetime of the returned value is managed by the system, applications should not free or modify this value.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/processenv/nf-processenv-getcommandlinew</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern char* GetCommandLine();

	/// <summary>
	/// Returns the current original equipment manufacturer (OEM) code page identifier for the operating system.
	/// </summary>
	/// <returns>Returns the current OEM code page identifier for the operating system.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winnls/nf-winnls-getoemcp</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint GetOEMCP();
}
