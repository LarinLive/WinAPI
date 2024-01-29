// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static Larin.WinAPI.NativeMethods.ErrorCodes;

namespace Larin.WinAPI.NativeMethods;

public static unsafe partial class Kernel32
{
	/// <summary>
	/// Creates or opens a named or unnamed event object.
	/// </summary>
	/// <param name="lpEventAttributes">A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure. If this parameter is NULL, the handle cannot be inherited by child processes.
	/// The lpSecurityDescriptor member of the structure specifies a security descriptor for the new event. If lpEventAttributes is NULL, the event gets a default security descriptor. 
	/// The ACLs in the default security descriptor for an event come from the primary or impersonation token of the creator.</param>
	/// <param name="bManualReset">If this parameter is TRUE, the function creates a manual-reset event object, which requires the use of the ResetEvent function to set the event state to nonsignaled. 
	/// If this parameter is FALSE, the function creates an auto-reset event object, and system automatically resets the event state to nonsignaled after a single waiting thread has been released.</param>
	/// <param name="bInitialState">If this parameter is TRUE, the initial state of the event object is signaled; otherwise, it is nonsignaled.</param>
	/// <param name="lpName">The name of the event object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
	/// If lpName matches the name of an existing named event object, this function requests the <see cref="EVENT_ALL_ACCESS"/> access right. 
	/// In this case, the bManualReset and bInitialState parameters are ignored because they have already been set by the creating process. 
	/// If the lpEventAttributes parameter is not NULL, it determines whether the handle can be inherited, but its security-descriptor member is ignored.
	/// If lpName is NULL, the event object is created without a name.</param>
	/// <returns>If the function succeeds, the return value is a handle to the event object. 
	/// If the named event object existed before the function call, the function returns a handle to the existing object and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
	/// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-createeventw</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint CreateEvent(
		[In, Optional] SECURITY_ATTRIBUTES* lpEventAttributes,
		[In] bool bManualReset,
		[In] bool bInitialState,
		[In, Optional] char* lpName
	);

	/// <summary>
	/// Creates or opens a named or unnamed event object and returns a handle to the object.
	/// </summary>
	/// <param name="lpEventAttributes">A pointer to a <see cref="SECURITY_ATTRIBUTES"/> structure. If this parameter is NULL, the handle cannot be inherited by child processes.
	/// The lpSecurityDescriptor member of the structure specifies a security descriptor for the new event. If lpEventAttributes is NULL, the event gets a default security descriptor. 
	/// The ACLs in the default security descriptor for an event come from the primary or impersonation token of the creator.</param>
	/// <param name="lpName">The name of the event object. The name is limited to MAX_PATH characters. Name comparison is case sensitive.
	/// If lpName matches the name of an existing named event object, this function requests the <see cref="EVENT_ALL_ACCESS"/> access right. 
	/// In this case, the bManualReset and bInitialState parameters are ignored because they have already been set by the creating process. 
	/// If the lpEventAttributes parameter is not NULL, it determines whether the handle can be inherited, but its security-descriptor member is ignored.
	/// If lpName is NULL, the event object is created without a name.</param>
	/// <param name="dwFlags"></param>
	/// <param name="dwDesiredAccess">The access mask for the event object. </param>
	/// <returns>If the function succeeds, the return value is a handle to the event object. 
	/// If the named event object existed before the function call, the function returns a handle to the existing object and <see cref="GetLastError"/> returns <see cref="ERROR_ALREADY_EXISTS"/>.
	/// If the function fails, the return value is NULL. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-createeventexw</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint CreateEventEx(
		[In, Optional] SECURITY_ATTRIBUTES* lpEventAttributes,
		[In, Optional] char* lpName,
		[In] uint dwFlags,
		[In] uint dwDesiredAccess
	);

	#region Event access rights

	/// <summary>
	/// All possible access rights for an event object. Use this right only if your application requires access beyond that granted by the standard access rights and <see cref="EVENT_MODIFY_STATE"/>. 
	/// Using this access right increases the possibility that your application must be run by an Administrator.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/sync/synchronization-object-security-and-access-rights</remarks>
	public const uint EVENT_ALL_ACCESS = 0x001F0003;

	/// <summary>
	/// Modify state access, which is required for the <see cref="SetEvent"/>, <see cref="ResetEvent"/> and <see cref="PulseEvent"/> functions.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/sync/synchronization-object-security-and-access-rights</remarks>
	public const uint EVENT_MODIFY_STATE = 0x00000002;

	#endregion

	#region Possible values for the CreateEventEx.dwFlags parameter

	/// <summary>
	/// The initial state of the event object is signaled; otherwise, it is nonsignaled.
	/// </summary>
	public const uint CREATE_EVENT_INITIAL_SET = 0x00000002;

	/// <summary>
	/// The event must be manually reset using the ResetEvent function. Any number of waiting threads, or threads that subsequently begin wait operations for the specified event object, can be released while the object's state is signaled.
	/// If this flag is not specified, the system automatically resets the event after releasing a single waiting thread.
	/// </summary>
	public const uint CREATE_EVENT_MANUAL_RESET = 0x00000001;

	#endregion

	/// <summary>
	/// Opens an existing named event object.
	/// </summary>
	/// <param name="dwDesiredAccess">The access to the event object. The function fails if the security descriptor of the specified object does not permit the requested access for the calling process.</param>
	/// <param name="bInheritHandle">If this value is TRUE, processes created by this process will inherit the handle. Otherwise, the processes do not inherit this handle.</param>
	/// <param name="lpName">The name of the event to be opened. Name comparisons are case sensitive.</param>
	/// <returns>If the function succeeds, the return value is a handle to the event object. If the function fails, the return value is NULL.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-openeventw</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint OpenEvent(
		[In] uint dwDesiredAccess,
		[In] uint bInheritHandle,
		[In] char* lpName
	);

	/// <summary>
	/// Sets the specified event object to the signaled state and then resets it to the nonsignaled state after releasing the appropriate number of waiting threads.
	/// </summary>
	/// <param name="hEvent">A handle to the event object. The handle must have the <see cref="EVENT_MODIFY_STATE"/> access right.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-pulseevent</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool PulseEvent(
		[In] nint hEvent
	);

	/// <summary>
	/// Sets the specified event object to the nonsignaled state.
	/// </summary>
	/// <param name="hEvent">A handle to the event object. The handle must have the <see cref="EVENT_MODIFY_STATE"/> access right.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-resetevent</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool ResetEvent(
		[In] nint hEvent
	);

	/// <summary>
	/// Sets the specified event object to the signaled state.
	/// </summary>
	/// <param name="hEvent">A handle to the event object. The handle must have the <see cref="EVENT_MODIFY_STATE"/> access right.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/synchapi/nf-synchapi-setevent</remarks>
	[DllImport(Kernel32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool SetEvent(
		[In] nint hEvent
	);
}
