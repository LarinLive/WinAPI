// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;
using static LarinLive.WinAPI.NativeMethods.Kernel32;
using static LarinLive.WinAPI.NativeMethods.SetupApi;

namespace LarinLive.WinAPI.NativeMethods;

public static unsafe partial class Advapi32
{

	/// <summary>
	/// Changes the configuration parameters of a service.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function and must have the <see cref="SERVICE_CHANGE_CONFIG"/> access right. </param>
	/// <param name="dwServiceType">The type of service. Specify <see cref="SERVICE_NO_CHANGE"/> if you are not changing the existing service type</param>
	/// <param name="dwStartType">The service start options. Specify <see cref="SERVICE_NO_CHANGE"/> if you are not changing the existing start type.</param>
	/// <param name="dwErrorControl">The severity of the error, and action taken, if this service fails to start. Specify <see cref="SERVICE_NO_CHANGE"/> if you are not changing the existing error control.</param>
	/// <param name="lpBinaryPathName">The fully qualified path to the service binary file. Specify NULL if you are not changing the existing path. 
	/// If the path contains a space, it must be quoted so that it is correctly interpreted. For example, "d:\my share\myservice.exe" should be specified as ""d:\my share\myservice.exe"".
	/// The path can also include arguments for an auto-start service. These arguments are passed to the service entry point (typically the main function).</param>
	/// <param name="lpLoadOrderGroup">The name of the load ordering group of which this service is a member. Specify NULL if you are not changing the existing group.
	/// Specify an empty string if the service does not belong to a group.</param>
	/// <param name="lpdwTagId">A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter. Specify NULL if you are not changing the existing tag.
	/// Tags are only evaluated for driver services that have <see cref="SERVICE_BOOT_START"/> or <see cref="SERVICE_SYSTEM_START"/> start types.</param>
	/// <param name="lpDependencies">A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must start before this service can be started. 
	/// (Dependency on a group means that this service can run if at least one member of the group is running after an attempt to start all members of the group.) 
	/// Specify NULL if you are not changing the existing dependencies. Specify an empty string if the service has no dependencies.</param>
	/// <param name="lpServiceStartName">The name of the account under which the service should run. Specify NULL if you are not changing the existing account name. 
	/// If the service type is <see cref="SERVICE_WIN32_OWN_PROCESS"/>, use an account name in the form DomainName\UserName. The service process will be logged on as this user. 
	/// If the account belongs to the built-in domain, you can specify .\UserName</param>
	/// <param name="lpPassword">The password to the account name specified by the lpServiceStartName parameter. Specify NULL if you are not changing the existing password. 
	/// Specify an empty string if the account has no password or if the service runs in the LocalService, NetworkService, or LocalSystem account. </param>
	/// <param name="lpDisplayName">The display name to be used by applications to identify the service for its users. Specify NULL if you are not changing the existing display name;
	/// otherwise, this string has a maximum length of 256 characters. The name is case-preserved in the service control manager. Display name comparisons are always case-insensitive.
	/// This parameter can specify a localized string using the following format: @[path] dllname,-strID
	/// The string with identifier strID is loaded from dllname; the path is optional. For more information, see <see cref="RegLoadMUIString"/>.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-changeserviceconfigw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool ChangeServiceConfig(
		[In] nint hService,
		[In] uint dwServiceType,
		[In] uint dwStartType,
		[In] uint dwErrorControl,
		[In, Optional] char* lpBinaryPathName,
		[In, Optional] char* lpLoadOrderGroup,
		[Out, Optional] uint* lpdwTagId,
		[In, Optional] char* lpDependencies,
		[In, Optional] char* lpServiceStartName,
		[In, Optional] char* lpPassword,
		[In, Optional] char* lpDisplayName
	);
	
	/// <summary>
	/// Changes the optional configuration parameters of a service.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function and must have the <see cref="SERVICE_CHANGE_CONFIG"/> access right. </param>
	/// <param name="dwInfoLevel">The configuration information to be changed.</param>
	/// <param name="lpInfo">A pointer to the new value to be set for the configuration information. The format of this data depends on the value of the dwInfoLevel parameter.
	/// If this value is NULL, the information remains unchanged.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-changeserviceconfig2w</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool ChangeServiceConfig2(
		[In] nint hService,
		[In] uint dwInfoLevel,
		[In, Optional] void* lpInfo
	);

	#region Access Rights for the Service Control Manager (https://learn.microsoft.com/en-us/windows/win32/services/service-security-and-access-rights#access-rights-for-a-service)

	/// <summary>
	/// Includes <see cref="STANDARD_RIGHTS_REQUIRED"/>, in addition to all access rights in this table.
	/// </summary>
	public const uint SC_MANAGER_ALL_ACCESS = 0x0000F003F;

	/// <summary>
	/// Required to call the <see cref="CreateService"/> function to create a service object and add it to the database.
	/// </summary>
	public const uint SC_MANAGER_CREATE_SERVICE = 0x00000002;

	/// <summary>
	/// Required to connect to the service control manager.
	/// </summary>
	public const uint SC_MANAGER_CONNECT = 0x00000001;

	/// <summary>
	/// Required to call the <see cref="EnumServicesStatus"/> or <see cref="EnumServicesStatusEx"/> function to list the services that are in the database.
	/// Required to call the <see cref="NotifyServiceStatusChange"/> function to receive notification when any service is created or deleted.
	/// </summary>
	public const uint SC_MANAGER_ENUMERATE_SERVICE = 0x00000004;

	/// <summary>
	/// Required to call the LockServiceDatabase function to acquire a lock on the database.
	/// </summary>
	public const uint SC_MANAGER_LOCK = 0x00000008;

	/// <summary>
	///	Required to call the <see cref="NotifyBootConfigStatus"/> function.
	/// </summary>
	public const uint SC_MANAGER_MODIFY_BOOT_CONFIG = 0x00000020;

	/// <summary>
	/// Required to call the QueryServiceLockStatus function to retrieve the lock status information for the database.
	/// </summary>
	public const uint SC_MANAGER_QUERY_LOCK_STATUS = 0x00000010;

	#endregion

	#region Access Rights for a Service (https://learn.microsoft.com/en-us/windows/win32/services/service-security-and-access-rights#access-rights-for-a-service)

	/// <summary>
	/// Includes <see cref="STANDARD_RIGHTS_REQUIRED"/> in addition to all access rights in this table.
	/// </summary>
	public const uint SERVICE_ALL_ACCESS = 0x000F01FF;

	/// <summary>
	/// Required to call the <see cref="ChangeServiceConfig"/> or <see cref="ChangeServiceConfig2"/> function to change the service configuration. 
	/// Because this grants the caller the right to change the executable file that the system runs, it should be granted only to administrators.
	/// </summary>
	public const uint SERVICE_CHANGE_CONFIG = 0x00000002;

	/// <summary>
	/// Required to call the <see cref="EnumDependentServices"/> function to enumerate all the services dependent on the service.
	/// </summary>
	public const uint SERVICE_ENUMERATE_DEPENDENTS = 0x00000008;

	/// <summary>
	/// Required to call the <see cref="ControlService"/> function to ask the service to report its status immediately.
	/// </summary>
	public const uint SERVICE_INTERROGATE = 0x00000080;

	/// <summary>
	/// Required to call the <see cref="ControlService"/> function to pause or continue the service.
	/// </summary>
	public const uint SERVICE_PAUSE_CONTINUE = 0x00000040;

	/// <summary>
	/// Required to call the <see cref="QueryServiceConfig"/> and <see cref="QueryServiceConfig2"/> functions to query the service configuration.
	/// </summary>
	public const uint SERVICE_QUERY_CONFIG = 0x00000001;

	/// <summary>
	///	Required to call the <see cref="QueryServiceStatus"/> or <see cref="QueryServiceStatusEx"/> function to ask the service control manager about the status of the service.
	///	Required to call the <see cref="NotifyServiceStatusChange"/> function to receive notification when a service changes status.
	/// </summary>
	public const uint SERVICE_QUERY_STATUS = 0x00000004;

	/// <summary>
	/// Required to call the <see cref="StartService"/> function to start the service.
	/// </summary>
	public const uint SERVICE_START = 0x00000010;

	/// <summary>
	/// Required to call the <see cref="ControlService"/> function to stop the service.
	/// </summary>
	public const uint SERVICE_STOP = 0x00000020;

	/// <summary>
	/// Required to call the <see cref="ControlService"/> function to specify a user-defined control code.
	/// </summary>
	public const uint SERVICE_USER_DEFINED_CONTROL = 0x00000100;

	#endregion

	/// <summary>
	/// Closes a handle to a service control manager or service object.
	/// </summary>
	/// <param name="hSCObject"></param>
	/// <returns>A handle to the service control manager object or the service object to close. Handles to service control manager objects are returned by the <see cref="OpenSCManager"/> function, 
	/// and handles to service objects are returned by either the <see cref="OpenService"/> or <see cref="CreateService"/> function.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-closeservicehandle</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool CloseServiceHandle(
		[In] nint hSCObject
	);

	/// <summary>
	/// Sends a control code to a service.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function.</param>
	/// <param name="dwControl">A service control code</param>
	/// <param name="lpServiceStatus">A pointer to a <see cref="SERVICE_STATUS"/> structure that receives the latest service status information.
	/// The information returned reflects the most recent status that the service reported to the service control manager.
	/// The service control manager fills in the structure only when <see cref="GetLastError"/> returns one of the following error codes: <see cref="ERROR_SUCCESS"/>,
	/// <see cref="ERROR_INVALID_SERVICE_CONTROL"/>, <see cref="ERROR_SERVICE_CANNOT_ACCEPT_CTRL"/>, or <see cref="ERROR_SERVICE_NOT_ACTIVE"/>. Otherwise, the structure is not filled in.</param>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-controlservice</remarks>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool ControlService(
		[In] nint hService,
		[In] uint dwControl,
		[Out] SERVICE_STATUS* lpServiceStatus
	);

	#region Service control codes

	/// <summary>
	/// Notifies a paused service that it should resume. The hService handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
	/// </summary>
	public const uint SERVICE_CONTROL_CONTINUE = 0x00000003;

	/// <summary>
	/// Notifies a service that it should report its current status information to the service control manager. The hService handle must have the <see cref="SERVICE_INTERROGATE"/> access right.
	/// Note that this control is not generally useful as the SCM is aware of the current state of the service.
	/// </summary>
	public const uint SERVICE_CONTROL_INTERROGATE = 0x00000004;

	/// <summary>
	/// Notifies a network service that there is a new component for binding. The hService handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right. 
	/// </summary>
	[Obsolete("This control code has been deprecated; use Plug and Play functionality instead.")]
	public const uint SERVICE_CONTROL_NETBINDADD = 0x00000007;

	/// <summary>
	/// Notifies a network service that one of its bindings has been disabled. The hService handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right. 
	/// </summary>
	[Obsolete("This control code has been deprecated; use Plug and Play functionality instead.")]
	public const uint SERVICE_CONTROL_NETBINDDISABLE = 0x0000000A;

	/// <summary>
	/// Notifies a network service that a disabled binding has been enabled. The hService handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right. 
	/// </summary>
	[Obsolete("This control code has been deprecated; use Plug and Play functionality instead.")]
	public const uint SERVICE_CONTROL_NETBINDENABLE = 0x00000009;

	/// <summary>
	/// Notifies a network service that a component for binding has been removed. The hService handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right. 
	/// </summary>
	[Obsolete("This control code has been deprecated; use Plug and Play functionality instead.")]
	public const uint SERVICE_CONTROL_NETBINDREMOVE = 0x00000008;

	/// <summary>
	/// Notifies a service that its startup parameters have changed. The hService handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
	/// </summary>
	public const uint SERVICE_CONTROL_PARAMCHANGE = 0x00000006;

	/// <summary>
	/// Notifies a service that it should pause. The hService handle must have the <see cref="SERVICE_PAUSE_CONTINUE"/> access right.
	/// </summary>
	public const uint SERVICE_CONTROL_PAUSE = 0x00000002;

	/// <summary>
	/// Notifies a service that it should stop. The hService handle must have the <see cref="SERVICE_STOP"/> access right. After sending the stop request to a service, you should not send other controls to the service.
	/// </summary>
	public const uint SERVICE_CONTROL_STOP = 0x00000001;

	/// <summary>
	/// Notifies a service that the system is shutting down so the service can perform cleanup tasks. 
	/// Note that services that register for <see cref="SERVICE_CONTROL_PRESHUTDOWN"/> notifications cannot receive this notification because they have already stopped.
	/// </summary>
	public const uint SERVICE_CONTROL_SHUTDOWN = 0x00000005;

	#endregion


	/// <summary>
	/// Sends a control code to a service.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function.</param>
	/// <param name="dwControl">A service control code</param>
	/// <param name="dwInfoLevel">The information level for the service control parameters. This parameter must be set to <see cref="SERVICE_CONTROL_STATUS_REASON_INFO"/>.</param>
	/// <param name="pControlParams">A pointer to the service control parameters. If dwInfoLevel is SERVICE_CONTROL_STATUS_REASON_INFO, this member is a pointer to a <see cref="SERVICE_CONTROL_STATUS_REASON_PARAMS"/> structure.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-controlserviceexw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool ControlServiceEx(
		[In] nint hService,
		[In] uint dwControl,
		[In] uint dwInfoLevel,
		[In, Out] void* pControlParams
	);

	#region Extended service control codes

	/// <summary>
	/// Notifies a service of device events. (The service must have registered to receive these notifications using the RegisterDeviceNotification function.) 
	/// The dwEventType and lpEventData parameters contain additional information.
	/// </summary>
	public const uint SERVICE_CONTROL_DEVICEEVENT = 0x0000000B;

	/// <summary>
	/// Notifies a service that the computer's hardware profile has changed. The dwEventType parameter contains additional information.
	/// </summary>
	public const uint SERVICE_CONTROL_HARDWAREPROFILECHANGE = 0x0000000C;

	/// <summary>
	/// Notifies a service of system power events. The dwEventType parameter contains additional information. If dwEventType is PBT_POWERSETTINGCHANGE, the lpEventData parameter also contains additional information.
	/// </summary>
	public const uint SERVICE_CONTROL_POWEREVENT = 0x0000000D;

	/// <summary>
	/// Notifies a service of session change events. Note that a service will only be notified of a user logon if it is fully loaded before the logon attempt is made.
	/// The dwEventType and lpEventData parameters contain additional information.
	/// </summary>
	public const uint SERVICE_CONTROL_SESSIONCHANGE = 0x0000000E;

	/// <summary>
	/// Notifies a service that the system will be shutting down. Services that need additional time to perform cleanup tasks beyond the tight time restriction at system shutdown can use this notification. 
	/// The service control manager sends this notification to applications that have registered for it before sending a <see cref="SERVICE_CONTROL_SHUTDOWN"/> notification to applications that have registered for that notification.
	/// </summary>
	public const uint SERVICE_CONTROL_PRESHUTDOWN = 0x0000000F;

	/// <summary>
	/// Notifies a service that the system time has changed. The lpEventData parameter contains additional information. The dwEventType parameter is not used.
	/// </summary>
	public const uint SERVICE_CONTROL_TIMECHANGE = 0x00000010;

	/// <summary>
	/// Notifies a service registered for a service trigger event that the event has occurred.
	/// </summary>
	public const uint SERVICE_CONTROL_TRIGGEREVENT = 0x00000020;

	/// <summary>
	/// Notifies a service that the user has initiated a reboot.
	/// </summary>
	public const uint SERVICE_CONTROL_USERMODEREBOOT = 0x00000040;

	/// <summary>
	/// Notifies a service that the resources level is too low.
	/// </summary>
	public const uint SERVICE_CONTROL_LOWRESOURCES = 0x00000060;

	/// <summary>
	/// Notifies a service that the system resources level is too low.
	/// </summary>
	public const uint SERVICE_CONTROL_SYSTEMLOWRESOURCES = 0x00000061;

	#endregion

	#region Possible values for the ControlServiceEx.dwInfoLevel parameter

	/// <summary>
	/// The single default value
	/// </summary>
	public const uint SERVICE_CONTROL_STATUS_REASON_INFO = 0x00000001;

	#endregion

	/// <summary>
	/// Contains service control parameters.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_control_status_reason_paramsw</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_CONTROL_STATUS_REASON_PARAMS
	{
		/// <summary>
		/// The reason for changing the service status to <see cref="SERVICE_CONTROL_STOP"/>. If the current control code is not <see cref="SERVICE_CONTROL_STOP"/>, this member is ignored.
		/// This member must be set to a combination of one general code, one major reason code, and one minor reason code.
		/// </summary>
		public uint dwReason;

		/// <summary>
		/// An optional string that provides additional information about the service stop. This string is stored in the event log along with the stop reason code. 
		/// This member must be NULL or a valid string that is less than 128 characters, including the terminating null character.
		/// </summary>
		public char* pszComment;

		/// <summary>
		/// A pointer to a <see cref="SERVICE_STATUS_PROCESS"/> structure that receives the latest service status information. The information returned reflects the most recent status that the service reported to the service control manager.
		/// The service control manager fills in the structure only when <see cref="ControlServiceEx"/> returns one of the following error codes: 
		/// <see cref="NO_ERROR"/>, <see cref="ERROR_INVALID_SERVICE_CONTROL"/>, <see cref="ERROR_SERVICE_CANNOT_ACCEPT_CTRL"/>, or <see cref="ERROR_SERVICE_NOT_ACTIVE"/>. Otherwise, the structure is not filled in.
		/// </summary>
		public SERVICE_STATUS_PROCESS* ServiceStatus;
	}

	#region Possible values for the SERVICE_CONTROL_STATUS_REASON_PARAMS.dwReason member

	/// <summary>
	/// The reason code is defined by the user. If this flag is not present, the reason code is defined by the system. If this flag is specified with a system reason code, the function call fails.
	/// </summary>
	public const uint SERVICE_STOP_REASON_FLAG_CUSTOM = 0x20000000;

	/// <summary>
	/// The service stop was planned.
	/// </summary>
	public const uint SERVICE_STOP_REASON_FLAG_PLANNED = 0x40000000;

	/// <summary>
	/// The service stop was not planned.
	/// </summary>
	public const uint SERVICE_STOP_REASON_FLAG_UNPLANNED = 0x10000000;


	/// <summary>
	/// Application issue.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MAJOR_APPLICATION = 0x00050000;

	/// <summary>
	/// Hardware issue.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MAJOR_HARDWARE = 0x00020000;

	/// <summary>
	/// No major reason.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MAJOR_NONE = 0x00060000;

	/// <summary>
	/// Operating system issue.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MAJOR_OPERATINGSYSTEM = 0x00030000;

	/// <summary>
	/// Other issue.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MAJOR_OTHER = 0x00010000;

	/// <summary>
	/// Software issue.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MAJOR_SOFTWARE = 0x00040000;


	/// <summary>
	/// Disk.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_DISK = 0x00000008;

	/// <summary>
	/// Environment.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_ENVIRONMENT = 0x0000000a;

	/// <summary>
	/// Driver.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_HARDWARE_DRIVER = 0x0000000b;

	/// <summary>
	/// Unresponsive.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_HUNG = 0x00000006;

	/// <summary>
	/// Installation.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_INSTALLATION = 0x00000003;

	/// <summary>
	/// Maintenance.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_MAINTENANCE = 0x00000002;

	/// <summary>
	/// MMC issue.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_MMC = 0x00000016;

	/// <summary>
	/// Network connectivity.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_NETWORK_CONNECTIVITY = 0x00000011;

	/// <summary>
	/// Network card.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_NETWORKCARD = 0x00000009;

	/// <summary>
	/// No minor reason.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_NONE = 0x00060000;

	/// <summary>
	/// Other issue.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_OTHER = 0x00000001;

	/// <summary>
	/// Other driver event.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_OTHERDRIVER = 0x0000000c;

	/// <summary>
	/// Reconfigure.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_RECONFIG = 0x00000005;

	/// <summary>
	/// Security issue.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_SECURITY = 0x00000010;

	/// <summary>
	/// Security update.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_SECURITYFIX = 0x0000000f;

	/// <summary>
	/// Security update uninstall.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_SECURITYFIX_UNINSTALL = 0x00000015;

	/// <summary>
	/// Service pack.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_SERVICEPACK = 0x0000000d;

	/// <summary>
	/// Service pack uninstall.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_SERVICEPACK_UNINSTALL = 0x00000013;

	/// <summary>
	/// Software update.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_SOFTWARE_UPDATE = 0x0000000e;

	/// <summary>
	/// Software update uninstall.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_SOFTWARE_UPDATE_UNINSTALL = 0x0000000E;

	/// <summary>
	/// Unstable.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_UNSTABLE = 0x00000007;

	/// <summary>
	/// Upgrade.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_UPGRADE = 0x00000004;

	/// <summary>
	/// WMI issue.
	/// </summary>
	public const uint SERVICE_STOP_REASON_MINOR_WMI = 0x00000012;

	#endregion

	/// <summary>
	/// Creates a service object and adds it to the specified service control manager database.
	/// </summary>
	/// <param name="hSCManager">A handle to the service control manager database. This handle is returned by the <see cref="OpenSCManager"/> function and must have the <see cref="SC_MANAGER_CREATE_SERVICE"/> access right. </param>
	/// <param name="lpServiceName">The name of the service to install. The maximum string length is 256 characters. The service control manager database preserves the case of the characters,
	/// but service name comparisons are always case insensitive. Forward-slash (/) and backslash (\) are not valid service name characters.</param>
	/// <param name="lpDisplayName">The display name to be used by user interface programs to identify the service. This string has a maximum length of 256 characters.
	/// The name is case-preserved in the service control manager. Display name comparisons are always case-insensitive.</param>
	/// <param name="dwDesiredAccess">The access to the service. Before granting the requested access, the system checks the access token of the calling process.</param>
	/// <param name="dwServiceType">The service type.</param>
	/// <param name="dwStartType">The service start options.</param>
	/// <param name="dwErrorControl">The severity of the error, and action taken, if this service fails to start.</param>
	/// <param name="lpBinaryPathName">The fully qualified path to the service binary file. If the path contains a space, it must be quoted so that it is correctly interpreted. 
	/// The path can also include arguments for an auto-start service. These arguments are passed to the service entry point (typically the main function).</param>
	/// <param name="lpLoadOrderGroup">The names of the load ordering group of which this service is a member. Specify NULL or an empty string if the service does not belong to a group.</param>
	/// <param name="lpdwTagId">A pointer to a variable that receives a tag value that is unique in the group specified in the lpLoadOrderGroup parameter. Specify NULL if you are not changing the existing tag.
	/// Tags are only evaluated for driver services that have <see cref="SERVICE_BOOT_START"/> or <see cref="SERVICE_SYSTEM_START"/> start types.</param>
	/// <param name="lpDependencies">A pointer to a double null-terminated array of null-separated names of services or load ordering groups that the system must start before this service. Specify NULL or an empty string if the service has no dependencies. 
	/// Dependency on a group means that this service can run if at least one member of the group is running after an attempt to start all members of the group.</param>
	/// <param name="lpServiceStartName">The name of the account under which the service should run.</param>
	/// <param name="lpPassword">The password to the account name specified by the lpServiceStartName parameter. Specify an empty string if the account has no password or if the service runs in the LocalService, NetworkService, or LocalSystem account.</param>
	/// <returns>If the function succeeds, the return value is a handle to the service. If the function fails, the return value is NULL.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-createservicew</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint CreateService(
		[In] nint hSCManager,
		[In] char* lpServiceName,
		[In, Optional] char* lpDisplayName,
		[In] uint dwDesiredAccess,
		[In] uint dwServiceType,
		[In] uint dwStartType,
		[In] uint dwErrorControl,
		[In, Optional] char* lpBinaryPathName,
		[In, Optional] char* lpLoadOrderGroup,
		[Out, Optional] uint* lpdwTagId,
		[In, Optional] char* lpDependencies,
		[In, Optional] char* lpServiceStartName,
		[In, Optional] char* lpPassword
	);

	#region Possible values for the CreateService.dwServiceType parameter

	/// <summary>
	/// Reserved.
	/// </summary>
	public const uint SERVICE_ADAPTER = 0x00000004;

	/// <summary>
	/// File system driver service.
	/// </summary>
	public const uint SERVICE_FILE_SYSTEM_DRIVER = 0x00000002;

	/// <summary>
	/// Driver service.
	/// </summary>
	public const uint SERVICE_KERNEL_DRIVER = 0x00000001;

	/// <summary>
	/// Reserved.
	/// </summary>
	public const uint SERVICE_RECOGNIZER_DRIVER = 0x00000008;

	/// <summary>
	/// Service that runs in its own process.
	/// </summary>
	public const uint SERVICE_WIN32_OWN_PROCESS = 0x00000010;

	/// <summary>
	/// Service that shares a process with one or more other services.
	/// </summary>
	public const uint SERVICE_WIN32_SHARE_PROCESS = 0x00000020;

	/// <summary>
	/// Services of type <see cref="SERVICE_WIN32_OWN_PROCESS"/> and <see cref="SERVICE_WIN32_SHARE_PROCESS"/>.
	/// </summary>
	public const uint SERVICE_WIN32 = 0x00000030;

	/// <summary>
	/// The service can interact with the desktop.
	/// </summary>
	public const uint SERVICE_INTERACTIVE_PROCESS = 0x00000100;

	/// <summary>
	/// Value to indicate no change to an optional parameter 
	/// </summary>
	public const uint SERVICE_NO_CHANGE = 0XFFFFFFFF;

	#endregion

	#region Possible values for the CreateService.dwStartType parameter

	/// <summary>
	/// A service started automatically by the service control manager during system startup. 
	/// </summary>
	public const uint SERVICE_AUTO_START = 0x00000002;

	/// <summary>
	/// A device driver started by the system loader. This value is valid only for driver services.
	/// </summary>
	public const uint SERVICE_BOOT_START = 0x00000000;

	/// <summary>
	/// A service started by the service control manager when a process calls the <see cref="StartService"/> function. 
	/// </summary>
	public const uint SERVICE_DEMAND_START = 0x00000003;

	/// <summary>
	/// A service that cannot be started. Attempts to start the service result in the error code <see cref="ERROR_SERVICE_DISABLED"/>.
	/// </summary>
	public const uint SERVICE_DISABLED = 0x00000004;

	/// <summary>
	/// A device driver started by the IoInitSystem function. This value is valid only for driver services.
	/// </summary>
	public const uint SERVICE_SYSTEM_START = 0x00000001;

	#endregion

	#region Possible values for the CreateService.dwErrorControl parameter

	/// <summary>
	/// The startup program logs the error in the event log, if possible. If the last-known-good configuration is being started, the startup operation fails.
	/// Otherwise, the system is restarted with the last-known good configuration.
	/// </summary>
	public const uint SERVICE_ERROR_CRITICAL = 0x00000003;

	/// <summary>
	/// The startup program ignores the error and continues the startup operation.
	/// </summary>
	public const uint SERVICE_ERROR_IGNORE = 0x00000000;

	/// <summary>
	/// The startup program logs the error in the event log but continues the startup operation.
	/// </summary>
	public const uint SERVICE_ERROR_NORMAL = 0x00000001;

	/// <summary>
	/// The startup program logs the error in the event log. If the last-known-good configuration is being started, the startup operation continues.
	/// Otherwise, the system is restarted with the last-known-good configuration.
	/// </summary>
	public const uint SERVICE_ERROR_SEVERE = 0x00000002;

	#endregion

	/// <summary>
	/// Marks the specified service for deletion from the service control manager database.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function, and it must have the DELETE access right.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-deleteservice</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool DeleteService(
		[In] nint hService
	);

	/// <summary>
	/// Retrieves the name and status of each service that depends on the specified service; that is, the specified service must be running before the dependent services can run.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function, and it must have the <see cref="SERVICE_ENUMERATE_DEPENDENTS"/> access right.</param>
	/// <param name="dwServiceState">The state of the services to be enumerated.</param>
	/// <param name="lpServices">A pointer to an array of <see cref="ENUM_SERVICE_STATUS"/> structures that receives the name and service status information for each dependent service in the database. 
	/// The buffer must be large enough to hold the structures, plus the strings to which their members point. The order of the services in this array is the reverse of the start order of the services.
	/// In other words, the first service in the array is the one that would be started last, and the last service in the array is the one that would be started first.
	/// The maximum size of this array is 64,000 bytes. To determine the required size, specify NULL for this parameter and 0 for the cbBufSize parameter.
	/// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_MORE_DATA"/>. The pcbBytesNeeded parameter will receive the required size.</param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpServices parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">A pointer to a variable that receives the number of bytes needed to store the array of service entries. 
	/// The variable only receives this value if the buffer pointed to by lpServices is too small, indicated by function failure and the <see cref="ERROR_MORE_DATA"/> error.
	/// Otherwise, the contents of pcbBytesNeeded are undefined.</param>
	/// <param name="lpServicesReturned">A pointer to a variable that receives the number of service entries returned.</param>
	/// <returns></returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-enumdependentservicesw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool EnumDependentServices(
		[In] nint hService,
		[In] uint dwServiceState,
		[Out, Optional] ENUM_SERVICE_STATUS* lpServices,
		[In] uint cbBufSize,
		[Out] uint* pcbBytesNeeded,
		[Out] uint* lpServicesReturned
	);

	/// <summary>
	/// Enumerates services in the specified service control manager database. The name and status of each service are provided.
	/// </summary>
	/// <param name="hSCManager">A handle to the service control manager database. This handle is returned by the <see cref="OpenSCManager"/> function, and must have the <see cref="SC_MANAGER_ENUMERATE_SERVICE"/> access right. </param>
	/// <param name="dwServiceType">The type of services to be enumerated.</param>
	/// <param name="dwServiceState">The state of the services to be enumerated.</param>
	/// <param name="lpServices">A pointer to a buffer that contains an array of <see cref="ENUM_SERVICE_STATUS"/> structures that receive the name and service status information for each service in the database. 
	/// The buffer must be large enough to hold the structures, plus the strings to which their members point.
	/// The maximum size of this array is 256K bytes. To determine the required size, specify NULL for this parameter and 0 for the cbBufSize parameter.
	/// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_MORE_DATA"/>.The pcbBytesNeeded parameter will receive the required size.</param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpServices parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">A pointer to a variable that receives the number of bytes needed to return the remaining service entries, if the buffer is too small.</param>
	/// <param name="lpServicesReturned">A pointer to a variable that receives the number of service entries returned.</param>
	/// <param name="lpResumeHandle">A pointer to a variable that, on input, specifies the starting point of enumeration. You must set this value to zero the first time this function is called. 
	/// On output, this value is zero if the function succeeds. However, if the function returns zero and the <see cref="GetLastError"/> function returns <see cref="ERROR_MORE_DATA"/>,
	/// this value is used to indicate the next service entry to be read when the function is called to retrieve the additional data.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>. </returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-enumservicesstatusw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool EnumServicesStatus(
		[In] nint hSCManager,
		[In] uint dwServiceType,
		[In] uint dwServiceState,
		[Out, Optional] ENUM_SERVICE_STATUS* lpServices,
		[In] uint cbBufSize,
		[Out] uint* pcbBytesNeeded,
		[Out] uint* lpServicesReturned,
		[In, Out, Optional] uint* lpResumeHandle
	);

	/// <summary>
	/// 
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-enum_service_statusw</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct ENUM_SERVICE_STATUS
	{
		/// <summary>
		/// The name of a service in the service control manager database. The maximum string length is 256 characters. 
		/// The service control manager database preserves the case of the characters, but service name comparisons are always case insensitive. 
		/// A slash (/), backslash (\), comma, and space are invalid service name characters.
		/// </summary>
		public char* lpServiceName;

		/// <summary>
		/// A display name that can be used by service control programs, such as Services in Control Panel, to identify the service. This string has a maximum length of 256 characters. 
		/// The name is case-preserved in the service control manager. Display name comparisons are always case-insensitive.
		/// </summary>
		public char* lpDisplayName;

		/// <summary>
		/// A <see cref="SERVICE_STATUS"/> structure that contains status information for the lpServiceName service.
		/// </summary>
		public SERVICE_STATUS ServiceStatus;
	}

	/// <summary>
	/// Enumerates services in the specified service control manager database. The name and status of each service are provided, along with additional data based on the specified information level.
	/// </summary>
	/// <param name="hSCManager">A handle to the service control manager database. This handle is returned by the <see cref="OpenSCManager"/> function, and must have the <see cref="SC_MANAGER_ENUMERATE_SERVICE"/> access right. </param>
	/// <param name="InfoLevel">The service attributes that are to be returned.</param>
	/// <param name="dwServiceType">The type of services to be enumerated.</param>
	/// <param name="dwServiceState">The state of the services to be enumerated.</param>
	/// <param name="lpServices">A pointer to the buffer that receives the status information. The format of this data depends on the value of the InfoLevel parameter.
	/// The maximum size of this array is 256K bytes.To determine the required size, specify NULL for this parameter and 0 for the cbBufSize parameter.
	/// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_MORE_DATA"/>.The pcbBytesNeeded parameter will receive the required size.</param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpServices parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">A pointer to a variable that receives the number of bytes needed to return the remaining service entries, if the buffer is too small.</param>
	/// <param name="lpServicesReturned">A pointer to a variable that receives the number of service entries returned.</param>
	/// <param name="lpResumeHandle">A pointer to a variable that, on input, specifies the starting point of enumeration. You must set this value to zero the first time the <see cref="EnumServicesStatusEx"/> function is called. 
	/// On output, this value is zero if the function succeeds. However, if the function returns zero and the <see cref="GetLastError"/> function returns <see cref="ERROR_MORE_DATA"/>,
	/// this value indicates the next service entry to be read when the <see cref="EnumServicesStatusEx"/> function is called to retrieve the additional data.</param>
	/// <param name="pszGroupName">The load-order group name. If this parameter is a string, the only services enumerated are those that belong to the group that has the name specified by the string. 
	/// If this parameter is an empty string, only services that do not belong to any group are enumerated. If this parameter is NULL, group membership is ignored and all services are enumerated.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>. </returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-enumservicesstatusexw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool EnumServicesStatusEx(
		[In] nint hSCManager,
		[In] uint InfoLevel,
		[In] uint dwServiceType,
		[In] uint dwServiceState,
		[Out, Optional] void* lpServices,
		[In] uint cbBufSize,
		[Out] uint* pcbBytesNeeded,
		[Out] uint* lpServicesReturned,
		[In, Out, Optional] uint* lpResumeHandle,
		[In, Optional] char* pszGroupName
	);

	#region Possible values for the EnumServicesStatusEx.InfoLevel parameter

	/// <summary>
	/// Retrieve the name and service status information for each service in the database. The lpServices parameter is a pointer to a buffer that receives an array of <see cref="ENUM_SERVICE_STATUS_PROCESS"/> structures. 
	/// The buffer must be large enough to hold the structures as well as the strings to which their members point.
	/// </summary>
	public const uint SC_ENUM_PROCESS_INFO = 0x00000000;

	#endregion

	/// <summary>
	/// Contains the name of a service in a service control manager database and information about the service. It is used by the <see cref="EnumServicesStatusEx"/> function.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-enum_service_status_processw</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct ENUM_SERVICE_STATUS_PROCESS
	{
		/// <summary>
		/// The name of a service in the service control manager database. The maximum string length is 256 characters. 
		/// The service control manager database preserves the case of the characters, but service name comparisons are always case insensitive. 
		/// A slash (/), backslash (\), comma, and space are invalid service name characters.
		/// </summary>
		public char* lpServiceName;

		/// <summary>
		/// A display name that can be used by service control programs, such as Services in Control Panel, to identify the service. This string has a maximum length of 256 characters. 
		/// The case is preserved in the service control manager. Display name comparisons are always case-insensitive.
		/// </summary>
		public char* lpDisplayName;

		/// <summary>
		/// A <see cref="SERVICE_STATUS_PROCESS"/> structure that contains status information for the lpServiceName service.
		/// </summary>
		public SERVICE_STATUS_PROCESS ServiceStatusProcess;
	}

	#region Possible values for the EnumServicesStatusEx.dwServiceState parameter

	/// <summary>		
	/// Enumerates services that are in the following states: <see cref="SERVICE_START_PENDING"/>, <see cref="SERVICE_STOP_PENDING"/>, <see cref="SERVICE_RUNNING"/>, <see cref="SERVICE_CONTINUE_PENDING"/>, <see cref="SERVICE_PAUSE_PENDING"/>, and <see cref="SERVICE_PAUSED"/>.
	/// </summary>
	public const uint SERVICE_ACTIVE = 0x00000001;

	/// <summary>
	/// Enumerates services that are in the <see cref="SERVICE_STOPPED"/> state.
	/// </summary>
	public const uint SERVICE_INACTIVE = 0x00000002;

	/// <summary>
	/// Combines the <see cref="SERVICE_ACTIVE"/> and <see cref="SERVICE_INACTIVE"/> states.
	/// </summary>
	public const uint SERVICE_STATE_ALL = 0x00000003;



	#endregion
	/// <summary>
	/// Retrieves the display name of the specified service.
	/// </summary>
	/// <param name="hSCManager">A handle to the service control manager database. This handle is returned by the <see cref="OpenSCManager"/> function.</param>
	/// <param name="lpServiceName">The service name. This name is the same as the service's registry key name. It is best to choose a name that is less than 256 characters.</param>
	/// <param name="lpDisplayName">A pointer to a buffer that receives the service's display name. If the function fails, this buffer will contain an empty string.
	/// The maximum size of this array is 4K bytes. To determine the required size, specify NULL for this parameter and 0 for the lpcchBuffer parameter.
	/// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_INSUFFICIENT_BUFFER"/>. The lpcchBuffer parameter will receive the required size.
	/// This parameter can specify a localized string using the following format: @[path] dllname,-strID
	/// The string with identifier strID is loaded from dllname; the path is optional.For more information, see <see cref="RegLoadMUIString"/>.</param>
	/// <param name="lpcchBuffer">A pointer to a variable that specifies the size of the buffer pointed to by lpDisplayName, in TCHARs. 
	/// On output, this variable receives the size of the service's display name, in characters, excluding the null-terminating character.
	/// If the buffer pointed to by lpDisplayName is too small to contain the display name, the function does not store it.
	/// When the function returns, lpcchBuffer contains the size of the service's display name, excluding the null-terminating character.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-getservicedisplaynamew</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool GetServiceDisplayName(
		[In] nint hSCManager,
		[In] char* lpServiceName,
		[Out, Optional] char* lpDisplayName,
		[In, Out] uint* lpcchBuffer
	);



	/// <summary>
	/// Retrieves the service name of the specified service.
	/// </summary>
	/// <param name="hSCManager">A handle to the service control manager database. This handle is returned by the <see cref="OpenSCManager"/> function.</param>
	/// <param name="lpDisplayName">The service display name. This string has a maximum length of 256 characters.</param>
	/// <param name="lpServiceName">A pointer to a buffer that receives the service name. If the function fails, this buffer will contain an empty string.
	/// The maximum size of this array is 4K bytes. To determine the required size, specify NULL for this parameter and 0 for the lpcchBuffer parameter.
	/// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_INSUFFICIENT_BUFFER"/>. The lpcchBuffer parameter will receive the required size.</param>
	/// <param name="lpcchBuffer">A pointer to variable that specifies the size of the buffer pointed to by the lpServiceName parameter, in TCHARs. 
	/// When the function returns, this parameter contains the size of the service name, in TCHARs, excluding the null-terminating character.
	/// If the buffer pointed to by lpServiceName is too small to contain the service name, the function stores no data in it. 
	/// When the function returns, lpcchBuffer contains the size of the service name, excluding the NULL terminator.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-getservicekeynamew</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool GetServiceKeyName(
		[In] nint hSCManager,
		[In] char* lpDisplayName,
		[Out, Optional] char* lpServiceName,
		[In, Out] uint* lpcchBuffer
	);


	/// <summary>
	/// Reports the boot status to the service control manager. It is used by boot verification programs. This function can be called only by a process running in the LocalSystem or Administrator's account.
	/// </summary>
	/// <param name="BootAcceptable">If the value is TRUE, the system saves the configuration as the last-known good configuration. 
	/// If the value is FALSE, the system immediately reboots, using the previously saved last-known good configuration.</param>
	/// <returns>If the BootAcceptable parameter is FALSE, the function does not return. If the last-known good configuration was successfully saved, the return value is nonzero.
	/// If an error occurs, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-notifybootconfigstatus</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool NotifyBootConfigStatus(
		[In] bool BootAcceptable
	);


	/// <summary>
	/// Enables an application to receive notification when the specified service is created or deleted or when its status changes.
	/// </summary>
	/// <param name="hService">A handle to the service or the service control manager. Handles to services are returned by the <see cref="OpenService"/> or <see cref="CreateService"/>ы function and must have the <see cref="SERVICE_QUERY_STATUS"/> access right. 
	/// Handles to the service control manager are returned by the <see cref="OpenSCManager"/> function and must have the <see cref="SC_MANAGER_ENUMERATE_SERVICE"/> access right.
	/// There can only be one outstanding notification request per service.</param>
	/// <param name="dwNotifyMask">The type of status changes that should be reported.</param>
	/// <param name="pNotifyBuffer">A pointer to a <see cref="SERVICE_NOTIFY_2"/> structure that contains notification information, such as a pointer to the callback function. 
	/// This structure must remain valid until the callback function is invoked or the calling thread cancels the notification request.
	/// Do not make multiple calls to NotifyServiceStatusChange with the same buffer parameter until the callback function from the first call has finished with the buffer or the first notification request has been canceled.
	/// Otherwise, there is no guarantee which version of the buffer the callback function will receive.</param>
	/// <returns>If the function succeeds, the return value is <see cref="ERROR_SUCCESS"/>. If the service has been marked for deletion, the return value is <see cref="ERROR_SERVICE_MARKED_FOR_DELETE"/> and the handle to the service must be closed. 
	/// If service notification is lagging too far behind the system state, the function returns <see cref="ERROR_SERVICE_NOTIFY_CLIENT_LAGGING"/>. 
	/// In this case, the client should close the handle to the SCM, open a new handle, and call this function again.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-notifyservicestatuschangew</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint NotifyServiceStatusChange(
		[In] nint hService,
		[In] uint dwNotifyMask,
		[In] SERVICE_NOTIFY_2* pNotifyBuffer
	);

	#region Possible values for the NotifyServiceStatusChange.dwNotifyMask parameter
	/// <summary>		
	/// Report when the service has been created.
	/// The hService parameter must be a handle to the SCM.
	/// </summary>
	public const uint SERVICE_NOTIFY_CREATED = 0x00000080;

	/// <summary>		
	/// Report when the service is about to continue.
	/// The hService parameter must be a handle to the service.
	/// </summary>
	public const uint SERVICE_NOTIFY_CONTINUE_PENDING = 0x00000010;

	/// <summary>		
	/// Report when an application has specified the service in a call to the DeleteService function. Your application should close any handles to the service so it can be deleted.
	/// The hService parameter must be a handle to the service.
	/// </summary>
	public const uint SERVICE_NOTIFY_DELETE_PENDING = 0x00000200;

	/// <summary>		
	/// Report when the service has been deleted. An application cannot receive this notification if it has an open handle to the service.
	/// The hService parameter must be a handle to the SCM.
	/// </summary>
	public const uint SERVICE_NOTIFY_DELETED = 0x00000100;

	/// <summary>		
	/// Report when the service is pausing.
	/// The hService parameter must be a handle to the service.
	/// </summary>
	public const uint SERVICE_NOTIFY_PAUSE_PENDING = 0x00000020;

	/// <summary>		
	/// Report when the service has paused.
	/// The hService parameter must be a handle to the service.
	/// </summary>
	public const uint SERVICE_NOTIFY_PAUSED = 0x00000040;

	/// <summary>		
	/// Report when the service is running.
	/// The hService parameter must be a handle to the service.
	/// </summary>
	public const uint SERVICE_NOTIFY_RUNNING = 0x00000008;

	/// <summary>		
	/// Report when the service is starting.
	/// The hService parameter must be a handle to the service.
	/// </summary>
	public const uint SERVICE_NOTIFY_START_PENDING = 0x00000002;

	/// <summary>		
	/// Report when the service is stopping.
	/// The hService parameter must be a handle to the service.
	/// </summary>
	public const uint SERVICE_NOTIFY_STOP_PENDING = 0x00000004;

	/// <summary>		
	/// Report when the service has stopped.
	/// The hService parameter must be a handle to the service.
	/// </summary>
	public const uint SERVICE_NOTIFY_STOPPED = 0x00000001;

	#endregion

	/// <summary>
	/// The callback function for the <see cref="NotifyServiceStatusChange"/> function
	/// </summary>
	/// <param name="pParameter">A pointer to the <see cref="SERVICE_NOTIFY_2"/> structure provided by the caller.</param>
	public delegate void FN_SC_NOTIFY_CALLBACK(SERVICE_NOTIFY_2* pParameter);

	/// <summary>
	/// Represents service status notification information. It is used by the <see cref="NotifyServiceStatusChange"/> function.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_notify_2w</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_NOTIFY_2
	{
		/// <summary>
		/// he structure version. This member must be SERVICE_NOTIFY_STATUS_CHANGE (2).
		/// </summary>
		public uint dwVersion;

		/// <summary>
		/// A pointer to the callback function.
		/// </summary>
		public void* pfnNotifyCallback;

		/// <summary>
		/// Any user-defined data to be passed to the callback function.
		/// </summary>
		public void* pContext;

		/// <summary>
		/// A value that indicates the notification status. If this member is <see cref="ERROR_SUCCESS"/>, the notification has succeeded and the ServiceStatus member contains valid information. 
		/// If this member is <see cref="ERROR_SERVICE_MARKED_FOR_DELETE"/>, the service has been marked for deletion and the service handle used by <see cref="NotifyServiceStatusChange"/> must be closed.
		/// </summary>
		public uint dwNotificationStatus;

		/// <summary>
		/// A <see cref="SERVICE_STATUS_PROCESS"/> structure that contains the service status information. This member is only valid if dwNotificationStatus is <see cref="ERROR_SUCCESS"/>.
		/// </summary>
		public SERVICE_STATUS_PROCESS ServiceStatus;

		/// <summary>
		/// If dwNotificationStatus is <see cref="ERROR_SUCCESS"/>, this member contains a bitmask of the notifications that triggered this call to the callback function.
		/// </summary>
		public uint dwNotificationTriggered;


		/// <summary>
		/// If dwNotificationStatus is <see cref="ERROR_SUCCESS"/> and the notification is <see cref="SERVICE_NOTIFY_CREATED"/> or <see cref="SERVICE_NOTIFY_DELETED"/>, 
		/// this member is valid and it is a MULTI_SZ string that contains one or more service names. The names of the created services will have a '/' prefix so you can distinguish them from the names of the deleted services.
		/// If this member is valid, the notification callback function must free the string using the <see cref="LocalFree"/> function.
		/// </summary>
		public char* pszServiceNames;

		/// <summary>
		/// Initializes a new instance of the <see cref="SERVICE_NOTIFY_2"/> structure.
		/// </summary>
		public SERVICE_NOTIFY_2()
		{
			dwVersion = 2;
		}
	}

	/// <summary>
	/// Contains status information for a service
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_status</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_STATUS
	{
		/// <summary>
		/// The type of service.
		/// </summary>
		public uint dwServiceType;

		/// <summary>
		/// The current state of the service. 
		/// </summary>
		public uint dwCurrentState;

		/// <summary>
		/// The control codes the service accepts and processes in its handler function (see Handler and HandlerEx). 
		/// A user interface process can control a service by specifying a control command in the <see cref="ControlService"/> or <see cref="ControlServiceEx"/> function. 
		/// By default, all services accept the <see cref="SERVICE_CONTROL_INTERROGATE"/> value.
		/// </summary>
		public uint dwControlsAccepted;

		/// <summary>
		/// The error code that the service uses to report an error that occurs when it is starting or stopping. 
		/// To return an error code specific to the service, the service must set this value to <see cref="ERROR_SERVICE_SPECIFIC_ERROR"/> to indicate that the dwServiceSpecificExitCode member contains the error code. 
		/// The service should set this value to <see cref="ERROR_SUCCESS"/> when it is running and when it terminates normally.
		/// </summary>
		public uint dwWin32ExitCode;

		/// <summary>
		/// The service-specific error code that the service returns when an error occurs while the service is starting or stopping. 
		/// This value is ignored unless the dwWin32ExitCode member is set to <see cref="ERROR_SERVICE_SPECIFIC_ERROR"/>.
		/// </summary>
		public uint dwServiceSpecificExitCode;

		/// <summary>
		/// The check-point value that the service increments periodically to report its progress during a lengthy start, stop, pause, or continue operation. 
		/// For example, the service should increment this value as it completes each step of its initialization when it is starting up. 
		/// The user interface program that invoked the operation on the service uses this value to track the progress of the service during a lengthy operation. 
		/// This value is not valid and should be zero when the service does not have a start, stop, pause, or continue operation pending.
		/// </summary>
		public uint dwCheckPoint;

		/// <summary>
		/// The estimated time required for a pending start, stop, pause, or continue operation, in milliseconds. 
		/// Before the specified amount of time has elapsed, the service should make its next call to the <see cref="SetServiceStatus"/> function with either an incremented dwCheckPoint value or a change in dwCurrentState.
		/// If the amount of time specified by dwWaitHint passes, and dwCheckPoint has not been incremented or dwCurrentState has not changed, the service control manager or service control program can assume that an error has occurred and the service should be stopped. 
		/// However, if the service shares a process with other services, the service control manager cannot terminate the service application because it would have to terminate the other services sharing the process as well.
		/// </summary>
		public uint dwWaitHint;
	}

	/// <summary>
	/// Contains process status information for a service.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_status_process</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_STATUS_PROCESS
	{
		/// <summary>
		/// The type of service.
		/// </summary>
		public uint dwServiceType;

		/// <summary>
		/// The current state of the service. 
		/// </summary>
		public uint dwCurrentState;

		/// <summary>
		/// The control codes the service accepts and processes in its handler function (see Handler and HandlerEx). 
		/// A user interface process can control a service by specifying a control command in the <see cref="ControlService"/> or <see cref="ControlServiceEx"/> function. 
		/// By default, all services accept the <see cref="SERVICE_CONTROL_INTERROGATE"/> value.
		/// </summary>
		public uint dwControlsAccepted;

		/// <summary>
		/// The error code that the service uses to report an error that occurs when it is starting or stopping. 
		/// To return an error code specific to the service, the service must set this value to <see cref="ERROR_SERVICE_SPECIFIC_ERROR"/> to indicate that the dwServiceSpecificExitCode member contains the error code. 
		/// The service should set this value to <see cref="ERROR_SUCCESS"/> when it is running and when it terminates normally.
		/// </summary>
		public uint dwWin32ExitCode;

		/// <summary>
		/// The service-specific error code that the service returns when an error occurs while the service is starting or stopping. 
		/// This value is ignored unless the dwWin32ExitCode member is set to <see cref="ERROR_SERVICE_SPECIFIC_ERROR"/>.
		/// </summary>
		public uint dwServiceSpecificExitCode;

		/// <summary>
		/// The check-point value that the service increments periodically to report its progress during a lengthy start, stop, pause, or continue operation. 
		/// For example, the service should increment this value as it completes each step of its initialization when it is starting up. 
		/// The user interface program that invoked the operation on the service uses this value to track the progress of the service during a lengthy operation. 
		/// This value is not valid and should be zero when the service does not have a start, stop, pause, or continue operation pending.
		/// </summary>
		public uint dwCheckPoint;

		/// <summary>
		/// The estimated time required for a pending start, stop, pause, or continue operation, in milliseconds. 
		/// Before the specified amount of time has elapsed, the service should make its next call to the <see cref="SetServiceStatus"/> function with either an incremented dwCheckPoint value or a change in dwCurrentState.
		/// If the amount of time specified by dwWaitHint passes, and dwCheckPoint has not been incremented or dwCurrentState has not changed, the service control manager or service control program can assume that an error has occurred and the service should be stopped. 
		/// However, if the service shares a process with other services, the service control manager cannot terminate the service application because it would have to terminate the other services sharing the process as well.
		/// </summary>
		public uint dwWaitHint;

		/// <summary>
		/// The process identifier of the service.
		/// </summary>
		public uint dwProcessId;

		/// <summary>
		/// The service flags.
		/// </summary>
		public uint dwServiceFlags;
	}

	#region Possible values for the SERVICE_STATUS_PROCESS.dwCurrentState member

	/// <summary>
	/// The service is about to continue.
	/// </summary>
	public const uint SERVICE_CONTINUE_PENDING = 0x00000005;

	/// <summary>
	/// The service is pausing.
	/// </summary>
	public const uint SERVICE_PAUSE_PENDING = 0x00000006;

	/// <summary>
	/// The service is paused.
	/// </summary>
	public const uint SERVICE_PAUSED = 0x00000007;

	/// <summary>
	/// The service is running.
	/// </summary>
	public const uint SERVICE_RUNNING = 0x00000004;

	/// <summary>
	/// The service is starting.
	/// </summary>
	public const uint SERVICE_START_PENDING = 0x00000002;

	/// <summary>
	/// The service is stopping.
	/// </summary>
	public const uint SERVICE_STOP_PENDING = 0x00000003;

	/// <summary>
	/// The service has stopped.
	/// </summary>
	public const uint SERVICE_STOPPED = 0x00000001;

	#endregion

	#region Possible values for the SERVICE_STATUS_PROCESS.dwControlsAccepted member

	/// <summary>
	/// The service is a network component that can accept changes in its binding without being stopped and restarted.
	/// This control code allows the service to receive <see cref="SERVICE_CONTROL_NETBINDADD"/>, <see cref="SERVICE_CONTROL_NETBINDREMOVE"/>, <see cref="SERVICE_CONTROL_NETBINDENABLE"/>,
	/// and <see cref="SERVICE_CONTROL_NETBINDDISABLE"/> notifications.
	/// </summary>
	public const uint SERVICE_ACCEPT_NETBINDCHANGE = 0x00000010;

	/// <summary>
	/// The service can reread its startup parameters without being stopped and restarted. This control code allows the service to receive <see cref="SERVICE_CONTROL_PARAMCHANGE"/> notifications.
	/// </summary>
	public const uint SERVICE_ACCEPT_PARAMCHANGE = 0x00000008;

	/// <summary>
	/// The service can be paused and continued. This control code allows the service to receive <see cref="SERVICE_CONTROL_PAUSE"/> and <see cref="SERVICE_CONTROL_CONTINUE"/> notifications.
	/// </summary>
	public const uint SERVICE_ACCEPT_PAUSE_CONTINUE = 0x00000002;

	/// <summary>
	///	The service can perform preshutdown tasks. This control code enables the service to receive <see cref="SERVICE_CONTROL_PRESHUTDOWN"/> notifications.
	///	Note that <see cref="ControlService"/> and <see cref="ControlServiceEx"/> cannot send this notification; only the system can send it.
	/// </summary>
	public const uint SERVICE_ACCEPT_PRESHUTDOWN = 0x00000100;

	/// <summary>
	/// The service is notified when system shutdown occurs. This control code allows the service to receive <see cref="SERVICE_CONTROL_SHUTDOWN"/> notifications.
	///	Note that <see cref="ControlService"/> and <see cref="ControlServiceEx"/> cannot send this notification; only the system can send it.
	/// </summary>
	public const uint SERVICE_ACCEPT_SHUTDOWN = 0x00000004;

	/// <summary>
	/// The service can be stopped. This control code allows the service to receive <see cref="SERVICE_CONTROL_STOP"/> notifications.
	/// </summary>
	public const uint SERVICE_ACCEPT_STOP = 0x00000001;

	/// <summary>
	/// The service is notified when the computer's hardware profile has changed. This enables the system to send <see cref="SERVICE_CONTROL_HARDWAREPROFILECHANGE"/> notifications to the service.
	/// </summary>
	public const uint SERVICE_ACCEPT_HARDWAREPROFILECHANGE = 0x00000020;

	/// <summary>
	/// The service is notified when the computer's power status has changed. This enables the system to send <see cref="SERVICE_CONTROL_POWEREVENT"/> notifications to the service.
	/// </summary>
	public const uint SERVICE_ACCEPT_POWEREVENT = 0x00000040;

	/// <summary>
	/// The service is notified when the computer's session status has changed. This enables the system to send <see cref="SERVICE_CONTROL_SESSIONCHANGE"/> notifications to the service.
	/// </summary>
	public const uint SERVICE_ACCEPT_SESSIONCHANGE = 0x00000080;

	#endregion

	#region Possible values for the SERVICE_STATUS_PROCESS.dwServiceFlags member

	/// <summary>
	/// The service runs in a system process that must always be running.
	/// </summary>
	public const uint SERVICE_RUNS_IN_SYSTEM_PROCESS = 0x00000001;

	#endregion

	/// <summary>
	/// Establishes a connection to the service control manager on the specified computer and opens the specified service control manager database.
	/// </summary>
	/// <param name="lpMachineName">The name of the target computer. If the pointer is NULL or points to an empty string, the function connects to the service control manager on the local computer.</param>
	/// <param name="lpDatabaseName">The name of the service control manager database. This parameter should be set to <see cref="SERVICES_ACTIVE_DATABASE"/>. 
	/// If it is NULL, the <see cref="SERVICES_ACTIVE_DATABASE"/> database is opened by default.</param>
	/// <param name="dwDesiredAccess">The access to the service control manager. The <see cref="SC_MANAGER_CONNECT"/> access right is implicitly specified by calling this function.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero.To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-openscmanagerw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint OpenSCManager(
		[In, Optional] char* lpMachineName,
		[In, Optional] char* lpDatabaseName,
		[In] uint dwDesiredAccess
	);

	#region Possible values for the OpenSCManager.lpDatabaseName parameter

	/// <summary>
	/// Active services database
	/// </summary>
	public const string SERVICES_ACTIVE_DATABASE = "ServicesActive";

	/// <summary>
	/// Failed services database
	/// </summary>
	public const string SERVICES_FAILED_DATABASE = "ServicesFailed";

	#endregion

	/// <summary>
	/// Opens an existing service.
	/// </summary>
	/// <param name="hSCManager">A handle to the service control manager database. The <see cref="OpenSCManager"/> function returns this handle. </param>
	/// <param name="lpServiceName">The name of the service to be opened. This is the name specified by the lpServiceName parameter of the <see cref="CreateService"/> function when the service object was created,
	/// not the service display name that is shown by user interface applications to identify the service.</param>
	/// <param name="dwDesiredAccess">The access to the service.</param>
	/// <returns>If the function succeeds, the return value is a handle to the service. If the function fails, the return value is NULL.To get extended error information, call <see cref="GetLastError"/>.</returns>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint OpenService(
		[In] nint hSCManager,
		[In] char* lpServiceName,
		[In] uint dwDesiredAccess
	);

	/// <summary>
	/// Retrieves the configuration parameters of the specified service.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="CreateService"/> or <see cref="OpenService"/> function, and it must have the <see cref="SERVICE_QUERY_CONFIG"/> access right.</param>
	/// <param name="lpServiceConfig">A pointer to a buffer that receives the service configuration information. The format of the data is a <see cref="QUERY_SERVICE_CONFIG"/> structure. 
	/// The maximum size of this array is 8K bytes. To determine the required size, specify NULL for this parameter and 0 for the cbBufSize parameter.
	/// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_INSUFFICIENT_BUFFER"/>. The pcbBytesNeeded parameter will receive the required size.</param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpServiceConfig parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">A pointer to a variable that receives the number of bytes needed to store all the configuration information, if the function fails with <see cref="ERROR_INSUFFICIENT_BUFFER"/>.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryserviceconfigw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool QueryServiceConfig(
		[In] nint hService,
		[Out, Optional] void* lpServiceConfig,
		[In] uint cbBufSize,
		[Out] uint* pcbBytesNeeded
	);

	/// <summary>
	/// Contains configuration information for an installed service. It is used by the <see cref="QueryServiceConfig"/> function.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-query_service_configw</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct QUERY_SERVICE_CONFIG
	{
		/// <summary>
		/// The type of service. 
		/// </summary>
		public uint dwServiceType;

		/// <summary>
		/// When to start the service. 
		/// </summary>
		public uint dwStartType;

		/// <summary>
		/// The severity of the error, and action taken, if this service fails to sta
		/// </summary>
		public uint dwErrorControl;

		/// <summary>
		/// The fully qualified path to the service binary file. The path can also include arguments for an auto-start service.These arguments are passed to the service entry point (typically the main function).
		/// </summary>
		public char* lpBinaryPathName;

		/// <summary>
		/// The name of the load ordering group to which this service belongs. If the member is NULL or an empty string, the service does not belong to a load ordering group.
		/// </summary>
		public char* lpLoadOrderGroup;

		/// <summary>
		/// A unique tag value for this service in the group specified by the lpLoadOrderGroup parameter. A value of zero indicates that the service has not been assigned a tag. 
		/// Tags are only evaluated for <see cref="SERVICE_KERNEL_DRIVER"/> and <see cref="SERVICE_FILE_SYSTEM_DRIVER"/> type services that have <see cref="SERVICE_BOOT_START"/> or <see cref="SERVICE_SYSTEM_START"/> start types.
		/// </summary>
		public uint dwTagId;

		/// <summary>
		/// A pointer to an array of null-separated names of services or load ordering groups that must start before this service. The array is doubly null-terminated. 
		/// If the pointer is NULL or if it points to an empty string, the service has no dependencies.
		/// </summary>
		public char* lpDependencies;

		/// <summary>
		/// If the service type is SERVICE_WIN32_OWN_PROCESS or SERVICE_WIN32_SHARE_PROCESS, this member is the name of the account that the service process will be logged on as when it runs. 
		/// This name can be of the form Domain\UserName. If the account belongs to the built-in domain, the name can be of the form .\UserName. 
		/// The name can also be "LocalSystem" if the process is running under the LocalSystem account.
		/// </summary>
		public char* lpServiceStartName;

		/// <summary>
		/// The display name to be used by service control programs to identify the service. This string has a maximum length of 256 characters. The name is case-preserved in the service control manager. Display name comparisons are always case-insensitive.
		/// This parameter can specify a localized string using the following format: @[Path] DLLName,-StrID 
		/// The string with identifier StrID is loaded from DLLName; the Path is optional. For more information, see <see cref="RegLoadMUIString"/>.
		/// </summary>
		public char* lpDisplayName;
	}

	/// <summary>
	/// Retrieves the current status of the specified service.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="CreateService"/> or <see cref="OpenService"/> function, and it must have the <see cref="SERVICE_QUERY_STATUS"/> access right.</param>
	/// <param name="lpServiceStatus">A pointer to a <see cref="SERVICE_STATUS"/> structure that receives the status information.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryservicestatus</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool QueryServiceStatus(
		[In] nint hService,
		[Out] SERVICE_STATUS* lpServiceStatus
	);

	/// <summary>
	/// Retrieves the optional configuration parameters of the specified service.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="CreateService"/> or <see cref="OpenService"/> function, and it must have the <see cref="SERVICE_QUERY_STATUS"/> access right.</param>
	/// <param name="dwInfoLevel">The configuration information to be queried. </param>
	/// <param name="lpBuffer">A pointer to the buffer that receives the service configuration information. The format of this data depends on the value of the dwInfoLevel parameter.
	/// The maximum size of this array is 8K bytes. To determine the required size, specify NULL for this parameter and 0 for the cbBufSize parameter. 
	/// The function fails and <see cref="GetLastError"/> returns <see cref="ERROR_INSUFFICIENT_BUFFER"/>. The pcbBytesNeeded parameter receives the needed size.</param>
	/// <param name="cbBufSize">The size of the structure pointed to by the lpBuffer parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">A pointer to a variable that receives the number of bytes required to store the configuration information, if the function fails with <see cref="ERROR_INSUFFICIENT_BUFFER"/>.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryserviceconfig2w</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool QueryServiceConfig2(
			[In] nint hService,
			[In] uint dwInfoLevel,
			[Out, Optional] void* lpBuffer,
			[In] uint cbBufSize,
			[Out] uint* pcbBytesNeeded
		);

	#region Possible values for the QueryServiceConfig2.dwInfoLevel parameter

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_DELAYED_AUTO_START_INFO"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_DELAYED_AUTO_START_INFO = 3;

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_DESCRIPTION"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_DESCRIPTION = 1;

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_FAILURE_ACTIONS"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_FAILURE_ACTIONS = 2;

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_FAILURE_ACTIONS_FLAG"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_FAILURE_ACTIONS_FLAG = 4;

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_PREFERRED_NODE_INFO"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_PREFERRED_NODE = 9;

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_PRESHUTDOWN_INFO"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_PRESHUTDOWN_INFO = 7;

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_REQUIRED_PRIVILEGES_INFO"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_REQUIRED_PRIVILEGES_INFO = 6;

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_SID_INFO"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_SERVICE_SID_INFO = 5;

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_TRIGGER_INFO"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_TRIGGER_INFO = 8;

	/// <summary>
	/// The lpInfo parameter is a pointer to a <see cref="SERVICE_LAUNCH_PROTECTED_INFO"/> structure.
	/// </summary>
	public const uint SERVICE_CONFIG_LAUNCH_PROTECTED = 12;

	#endregion

	/// <summary>
	/// Contains the delayed auto-start setting of an auto-start service.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_delayed_auto_start_info</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_DELAYED_AUTO_START_INFO
	{
		/// <summary>
		/// If this member is TRUE, the service is started after other auto-start services are started plus a short delay. Otherwise, the service is started during system boot.
		/// This setting is ignored unless the service is an auto-start service.
		/// </summary>
		public bool fDelayedAutostart;
	}

	/// <summary>
	/// Contains a service description.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_descriptionw</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_DESCRIPTION
	{
		/// <summary>
		/// The description of the service. If this member is NULL, the description remains unchanged. If this value is an empty string (""), the current description is deleted.
		/// The service description must not exceed the size of a registry value of type REG_SZ. This member can specify a localized string using the following format: @[path] dllname,-strID
		/// The string with identifier strID is loaded from dllname; the path is optional. For more information, see <see cref="RegLoadMUIString"/>.
		/// </summary>
		public char* lpDescription;
	}

	/// <summary>
	/// Represents the action the service controller should take on each failure of a service. A service is considered failed when it terminates without reporting a status of <see cref="SERVICE_STOPPED"/> to the service controller.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_failure_actionsw</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_FAILURE_ACTIONS
	{
		/// <summary>
		/// The time after which to reset the failure count to zero if there are no failures, in seconds. Specify <see cref="INFINITE"/> to indicate that this value should never be reset.
		/// </summary>
		public uint dwResetPeriod;

		/// <summary>
		/// The message to be broadcast to server users before rebooting in response to the <see cref="SC_ACTION_REBOOT"/> service controller action. 
		/// If this value is NULL, the reboot message is unchanged.If the value is an empty string (""), the reboot message is deleted and no message is broadcast.
		/// This member can specify a localized string using the following format: @[path] dllname,-strID
		/// The string with identifier strID is loaded from dllname; the path is optional. For more information, see <see cref="RegLoadMUIString"/>.
		/// </summary>
		public char* lpRebootMsg;

		/// <summary>
		/// The command line of the process for the CreateProcess function to execute in response to the <see cref="SC_ACTION_RUN_COMMAND"/> service controller action. This process runs under the same account as the service.
		/// If this value is NULL, the command is unchanged. If the value is an empty string (""), the command is deleted and no program is run when the service fails.
		/// </summary>
		public char* lpCommand;

		/// <summary>
		/// The number of elements in the lpsaActions array. If this value is 0, but lpsaActions is not NULL, the reset period and array of failure actions are deleted.
		/// </summary>
		public uint cActions;

		/// <summary>
		/// A pointer to an array of <see cref="SC_ACTION"/> structures. If this value is NULL, the cActions and dwResetPeriod members are ignored.
		/// </summary>
		public SC_ACTION* lpsaActions;
	}


	/// <summary>
	/// Represents an action that the service control manager can perform.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-sc_action</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SC_ACTION
	{
		/// <summary>
		/// The action to be performed.
		/// </summary>
		public uint Type;

		/// <summary>
		/// The time to wait before performing the specified action, in milliseconds.
		/// </summary>
		public uint Delay;
	}

	#region Possible values for the SC_ACTION.Type member

	/// <summary>
	/// No action.
	/// </summary>
	public const uint SC_ACTION_NONE = 0;

	/// <summary>
	/// Reboot the computer.
	/// </summary>
	public const uint SC_ACTION_REBOOT = 2;

	/// <summary>
	/// Restart the service.
	/// </summary>
	public const uint SC_ACTION_RESTART = 1;

	/// <summary>
	/// Run a command.
	/// </summary>
	public const uint SC_ACTION_RUN_COMMAND = 3;

	#endregion

	/// <summary>
	/// Contains the failure actions flag setting of a service. This setting determines when failure actions are to be executed.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_failure_actions_flag</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_FAILURE_ACTIONS_FLAG
	{
		/// <summary>
		/// If this member is TRUE and the service has configured failure actions, the failure actions are queued if the service process terminates without reporting a status of <see cref="SERVICE_STOPPED"/> 
		/// or if it enters the <see cref="SERVICE_STOPPED"/> state but the dwWin32ExitCode member of the <see cref="SERVICE_STATUS"/> structure is not <see cref="ERROR_SUCCESS"/>.
		/// If this member is FALSE and the service has configured failure actions, the failure actions are queued only if the service terminates without reporting a status of <see cref="SERVICE_STOPPED"/>.
		/// This setting is ignored unless the service has configured failure actions. For information on configuring failure actions, see <see cref="ChangeServiceConfig2"/>.
		/// </summary>
		public bool fFailureActionsOnNonCrashFailures;
	}

	/// <summary>
	/// Represents the preferred node on which to run a service. 
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_preferred_node_info</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_PREFERRED_NODE_INFO
	{
		/// <summary>
		/// The node number of the preferred node.
		/// </summary>
		public ushort usPreferredNode;

		/// <summary>
		/// If this member is TRUE, the preferred node setting is deleted.
		/// </summary>
		public bool fDelete;
	}

	/// <summary>
	/// Contains preshutdown settings.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_preshutdown_info</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_PRESHUTDOWN_INFO
	{
		/// <summary>
		/// The time-out value, in milliseconds.
		/// </summary>
		public uint dwPreshutdownTimeout;
	}

	/// <summary>
	/// Represents the required privileges for a service.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_required_privileges_infow</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_REQUIRED_PRIVILEGES_INFO
	{
		/// <summary>
		/// A multi-string that specifies the privileges. For a list of possible values, see Privilege Constants.
		/// A multi-string is a sequence of null-terminated strings, terminated by an empty string (\0). The following is an example: String1\0String2\0String3\0LastString\0\0.
		/// </summary>
		public char* pmszRequiredPrivileges;
	}

	/// <summary>
	/// Represents a service security identifier (SID).
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_sid_info</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_SID_INFO
	{
		/// <summary>
		/// The service SID type.
		/// </summary>
		public uint dwServiceSidType;
	}

	#region Possible values for the SERVICE_SID_INFO.dwServiceSidType member

	/// <summary>
	/// Use this type to reduce application compatibility issues.
	/// </summary>
	public const uint SERVICE_SID_TYPE_NONE = 0x00000000;

	/// <summary>
	/// This type includes SERVICE_SID_TYPE_UNRESTRICTED. The service SID is also added to the restricted SID list of the process token. Three additional SIDs are also added to the restricted SID list:
	/// World SID S-1-1-0
	/// Service logon SID
	/// Write-restricted SID S-1-5-33
	/// One ACE that allows <see cref="GENERIC_ALL"/> access for the service logon SID is also added to the service process token object.
	/// If there are multiple services hosted in the same process and one service has <see cref="SERVICE_SID_TYPE_RESTRICTED"/>, all services must have <see cref="SERVICE_SID_TYPE_RESTRICTED"/>.
	/// </summary>
	public const uint SERVICE_SID_TYPE_RESTRICTED = 0x00000003;

	/// <summary>
	/// When the service process is created, the service SID is added to the service process token with the following attributes: SE_GROUP_ENABLED_BY_DEFAULT | SE_GROUP_OWNER.
	/// </summary>
	public const uint SERVICE_SID_TYPE_UNRESTRICTED = 0x00000001;

	#endregion

	/// <summary>
	/// Contains trigger event information for a service. This structure is used by the <see cref="ChangeServiceConfig2"/> and <see cref="QueryServiceConfig2"/> functions.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_trigger_info</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_TRIGGER_INFO
	{
		/// <summary>
		/// The number of triggers in the array of <see cref="SERVICE_TRIGGER"/> structures pointed to by the pTriggers member. 
		/// If this member is 0 in a <see cref="SERVICE_TRIGGER_INFO"/> structure passed to <see cref="ChangeServiceConfig2"/>, all previously configured triggers are removed from the service. 
		/// If the service has no triggers configured, <see cref="ChangeServiceConfig2"/> fails with <see cref="ERROR_INVALID_PARAMETER"/>.
		/// </summary>
		public uint cTriggers;

		/// <summary>
		/// A pointer to an array of <see cref="SERVICE_TRIGGER"/> structures that specify the trigger events for the service. If the cTriggers member is 0, this member is not used.
		/// </summary>
		public SERVICE_TRIGGER* pTriggers;

		/// <summary>
		/// This member is reserved and must be NULL.
		/// </summary>
		public void* pReserved;
	}

	/// <summary>
	/// Represents a service trigger event. This structure is used by the <see cref="SERVICE_TRIGGER_INFO"/> structure.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_trigger</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_TRIGGER
	{
		/// <summary>
		/// The trigger event type. 
		/// </summary>
		public uint dwTriggerType;

		/// <summary>
		/// The action to take when the specified trigger event occurs.
		/// </summary>
		public uint dwAction;

		/// <summary>
		/// Points to a GUID that identifies the trigger event subtype. The value of this member depends on the value of the dwTriggerType member.
		/// </summary>
		public Guid* pTriggerSubtype;

		/// <summary>
		/// The number of <see cref="SERVICE_TRIGGER_SPECIFIC_DATA_ITEM"/> structures in the array pointed to by pDataItems.
		/// </summary>
		public uint cDataItems;

		/// <summary>
		/// A pointer to an array of <see cref="SERVICE_TRIGGER_SPECIFIC_DATA_ITEM"/> structures that contain trigger-specific data.
		/// </summary>
		public SERVICE_TRIGGER_SPECIFIC_DATA_ITEM* pDataItems;
	}

	#region Possible values for the SERVICE_TRIGGER.dwTriggerType member

	/// <summary>
	/// The event is a custom event generated by an Event Tracing for Windows(ETW) provider. This trigger event can be used to start or stop a service.
	/// The pTriggerSubtype member specifies the event provider's GUID. The pDataItems member specifies trigger-specific data defined by the provider
	/// </summary>
	public const uint SERVICE_TRIGGER_TYPE_CUSTOM = 20;

	/// <summary>
	/// The event is triggered when a device of the specified device interface class arrives or is present when the system starts. This trigger event is commonly used to start a service.
	/// The pTriggerSubtype member specifies the device interface class GUID. These GUIDs are defined in device-specific header files provided with the Windows Driver Kit(WDK).
	/// The pDataItems member specifies one or more hardware ID and compatible ID strings for the device interface class. Strings must be Unicode.
	/// If more than one string is specified, the event is triggered if any one of the strings match. 
	/// For example, the Wpdbusenum service is started when a device of device interface class <see cref="GUID_DEVINTERFACE_DISK"/> and a hardware ID string of "USBSTOR\GenDisk" arrives.
	/// </summary>
	public const uint SERVICE_TRIGGER_TYPE_DEVICE_INTERFACE_ARRIVAL = 1;

	/// <summary>
	/// The event is triggered when the computer joins or leaves a domain. This trigger event can be used to start or stop a service. 
	/// The pTriggerSubtype member specifies <see cref="DOMAIN_JOIN_GUID"/> or <see cref="DOMAIN_LEAVE_GUID"/>. The pDataItems member is not used.
	/// </summary>
	public const uint SERVICE_TRIGGER_TYPE_DOMAIN_JOIN = 3;

	/// <summary>
	/// The event is triggered when a firewall port is opened or approximately 60 seconds after the firewall port is closed. This trigger event can be used to start or stop a service.
	/// The pTriggerSubtype member specifies <see cref="FIREWALL_PORT_OPEN_GUID"/> or <see cref="FIREWALL_PORT_CLOSE_GUID"/>.
	/// </summary>
	public const uint SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT = 4;

	/// <summary>
	/// The event is triggered when a machine policy or user policy change occurs. This trigger event is commonly used to start a service.
	/// The pTriggerSubtype member specifies <see cref="MACHINE_POLICY_PRESENT_GUID"/> or <see cref="USER_POLICY_PRESENT_GUID"/>. The pDataItems member is not used.
	/// </summary>
	public const uint SERVICE_TRIGGER_TYPE_GROUP_POLICY = 5;

	/// <summary>
	/// The event is triggered when the first IP address on the TCP/IP networking stack becomes available or the last IP address on the stack becomes unavailable. 
	/// This trigger event can be used to start or stop a service.The pTriggerSubtype member specifies <see cref="NETWORK_MANAGER_FIRST_IP_ADDRESS_ARRIVAL_GUID"/> or <see cref="NETWORK_MANAGER_LAST_IP_ADDRESS_REMOVAL_GUID"/>.
	/// The pDataItems member is not used.
	/// </summary>
	public const uint SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY = 2;

	/// <summary>
	/// The event is triggered when a packet or request arrives on a particular network protocol. This request is commonly used to start a service that has stopped itself after an idle time-out when there is no work to do.
	/// The pTriggerSubtype member specifies one of the following values: RPC_INTERFACE_EVENT_GUID or NAMED_PIPE_EVENT_GUID.
	/// The pDataItems member specifies an endpoint or interface GUID. The string must be Unicode.The event triggers if the string is an exact match.
	/// The dwAction member must be <see cref="SERVICE_TRIGGER_ACTION_SERVICE_START"/>.
	/// </summary>
	public const uint SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT = 6;

	#endregion

	#region Possible values for the SERVICE_TRIGGER.dwAction member

	/// <summary>
	/// Start the service when the specified trigger event occurs.
	/// </summary>
	public const uint SERVICE_TRIGGER_ACTION_SERVICE_START = 1;

	/// <summary>
	/// Stop the service when the specified trigger event occurs.
	/// </summary>
	public const uint SERVICE_TRIGGER_ACTION_SERVICE_STOP = 2;

	#endregion

	#region Possible values for the SERVICE_TRIGGER.pTriggerSubtype member

	/// <summary>
	/// The event is triggered when a request is made to open the named pipe specified by pDataItems. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT"/>.
	/// The dwAction member must be <see cref="SERVICE_TRIGGER_ACTION_SERVICE_START"/>
	/// </summary>
	public static readonly Guid NAMED_PIPE_EVENT_GUID = new("1f81d131-3fac-4537-9e0c-7e7b0c2f4b55");

	/// <summary>
	/// The event is triggered when an endpoint resolution request arrives for the RPC interface GUID specified by pDataItems. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_NETWORK_ENDPOINT"/>.
	/// The dwAction member must be <see cref="SERVICE_TRIGGER_ACTION_SERVICE_START"/>
	/// </summary>
	public static readonly Guid RPC_INTERFACE_EVENT_GUID = new("bc90d167-9470-4139-a9ba-be0bbbf5b74d");

	/// <summary>
	/// The event is triggered when the computer joins a domain. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_DOMAIN_JOIN"/>.
	/// </summary>
	public static readonly Guid DOMAIN_JOIN_GUID = new("1ce20aba-9851-4421-9430-1ddeb766e809");

	/// <summary>
	/// The event is triggered when the computer leaves a domain. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_DOMAIN_JOIN"/>.
	/// </summary>
	public static readonly Guid DOMAIN_LEAVE_GUID = new("ddaf516e-58c2-4866-9574-c3b615d42ea1");

	/// <summary>
	/// The event is triggered when the specified firewall port is opened. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT"/>.
	/// </summary>
	public static readonly Guid FIREWALL_PORT_OPEN_GUID = new("b7569e07-8421-4ee0-ad10-86915afdad09");

	/// <summary>
	/// The event is triggered approximately 60 seconds after the specified firewall port is closed. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_FIREWALL_PORT_EVENT"/>.
	/// </summary>
	public static readonly Guid FIREWALL_PORT_CLOSE_GUID = new("a144ed38-8e12-4de4-9d96-e64740b1a524");

	/// <summary>
	/// The event is triggered when the machine policy has changed. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_GROUP_POLICY"/>.
	/// </summary>
	public static readonly Guid MACHINE_POLICY_PRESENT_GUID = new("659fcae6-5bdb-4da9-b1ff-ca2a178d46e0");

	/// <summary>
	/// The event is triggered when the first IP address on the TCP/IP networking stack becomes available. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY"/>.
	/// </summary>
	public static readonly Guid NETWORK_MANAGER_FIRST_IP_ADDRESS_ARRIVAL_GUID = new("4f27f2de-14e2-430b-a549-7cd48cbc8245");

	/// <summary>
	/// The event is triggered when the last IP address on the TCP/IP networking stack becomes unavailable. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_IP_ADDRESS_AVAILABILITY"/>.
	/// </summary>
	public static readonly Guid NETWORK_MANAGER_LAST_IP_ADDRESS_REMOVAL_GUID = new("cc4ba62a-162e-4648-847a-b6bdf993e335");

	/// <summary>
	/// The event is triggered when the user policy has changed. The dwTriggerType member must be <see cref="SERVICE_TRIGGER_TYPE_GROUP_POLICY"/>.
	/// </summary>
	public static readonly Guid USER_POLICY_PRESENT_GUID = new("54fb46c8-f089-464c-b1fd-59d1b62c3b50");

	#endregion

	/// <summary>
	/// Contains trigger-specific data for a service trigger event. This structure is used by the <see cref="SERVICE_TRIGGER"/> structure.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_trigger_specific_data_item</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_TRIGGER_SPECIFIC_DATA_ITEM
	{
		/// <summary>
		/// The data type of the trigger-specific data pointed to by pData.
		/// </summary>
		public uint dwDataType;

		/// <summary>
		/// The size of the trigger-specific data pointed to pData, in bytes. The maximum value is 1024.
		/// </summary>
		public uint cbData;

		/// <summary>
		/// A pointer to the trigger-specific data for the service trigger event. The trigger-specific data depends on the trigger event type.
		/// If the dwDataType member is <see cref="SERVICE_TRIGGER_DATA_TYPE_BINARY"/>, the trigger-specific data is an array of bytes.
		/// If the dwDataType member is <see cref="SERVICE_TRIGGER_DATA_TYPE_STRING"/>, the trigger-specific data is a null-terminated string or a multistring of null-terminated strings, 
		/// ending with two null-terminating characters. For example: "5001\0UDP\0%programfiles%\MyApplication\MyServiceProcess.exe\0MyService\0\0". 
		/// Strings must be Unicode; ANSI strings are not supported.
		/// </summary>
		public void* pData;
	}

	#region Possible values for the SERVICE_TRIGGER_SPECIFIC_DATA_ITEM.dwDataType member

	/// <summary>
	/// The trigger-specific data is in binary format.
	/// </summary>
	public const uint SERVICE_TRIGGER_DATA_TYPE_BINARY = 1;

	/// <summary>
	/// The trigger-specific data is in string format.
	/// </summary>
	public const uint SERVICE_TRIGGER_DATA_TYPE_STRING = 2;

	/// <summary>
	/// The trigger-specific data is a byte value.
	/// </summary>
	public const uint SERVICE_TRIGGER_DATA_TYPE_LEVEL = 3;

	/// <summary>
	/// The trigger-specific data is a 64-bit unsigned integer value.
	/// </summary>
	public const uint SERVICE_TRIGGER_DATA_TYPE_KEYWORD_ANY = 4;

	/// <summary>
	/// The trigger-specific data is a 64-bit unsigned integer value.
	/// </summary>
	public const uint SERVICE_TRIGGER_DATA_TYPE_KEYWORD_ALL = 5;

	#endregion

	/// <summary>
	/// Indicates a service protection type.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_launch_protected_info</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_LAUNCH_PROTECTED_INFO
	{
		/// <summary>
		/// The protection type of the service.
		/// </summary>
		public uint dwLaunchProtected;
	}

	#region Possible values for the SERVICE_LAUNCH_PROTECTED_INFO.dwLaunchProtected member

	/// <summary>
	/// Unprotected launch
	/// </summary>
	public const uint SERVICE_LAUNCH_PROTECTED_NONE = 0;

	/// <summary>
	/// Reserved for internal Windows use only
	/// </summary>
	public const uint SERVICE_LAUNCH_PROTECTED_WINDOWS = 1;

	/// <summary>
	/// Reserved for internal Windows use only
	/// </summary>
	public const uint SERVICE_LAUNCH_PROTECTED_WINDOWS_LIGHT = 2;

	/// <summary>
	/// Can be used by the anti-malware vendors to launch their anti-malware service as protected.
	/// </summary>
	public const uint SERVICE_LAUNCH_PROTECTED_ANTIMALWARE_LIGHT = 3;

	#endregion


	/// <summary>
	/// Retrieves the current status of the specified service based on the specified information level.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="CreateService"/> or <see cref="OpenService"/> function, and it must have the <see cref="SERVICE_QUERY_STATUS"/> access right. </param>
	/// <param name="InfoLevel">The service attributes to be returned. Use <see cref="SC_STATUS_PROCESS_INFO"/> to retrieve the service status information. The 
	/// lpBuffer parameter is a pointer to a <see cref="SERVICE_STATUS_PROCESS"/> structure. Currently, no other information levels are defined.</param>
	/// <param name="lpBuffer">A pointer to the buffer that receives the status information. The format of this data depends on the value of the InfoLevel parameter. 
	/// The maximum size of this array is 8K bytes.To determine the required size, specify NULL for this parameter and 0 for the cbBufSize parameter.
	/// The function will fail and <see cref="GetLastError"/> will return <see cref="ERROR_INSUFFICIENT_BUFFER"/>. The pcbBytesNeeded parameter will receive the required size.</param>
	/// <param name="cbBufSize">The size of the buffer pointed to by the lpBuffer parameter, in bytes.</param>
	/// <param name="pcbBytesNeeded">A pointer to a variable that receives the number of bytes needed to store all status information, if the function fails with ERROR_INSUFFICIENT_BUFFER.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-queryservicestatusex</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool QueryServiceStatusEx(
		[In] nint hService,
		[In] uint InfoLevel,
		[Out, Optional] void* lpBuffer,
		[In] uint cbBufSize,
		[Out] uint* pcbBytesNeeded
	);

	#region Possible values for the QueryServiceStatusEx.InfoLevel parameter

	/// <summary>
	/// The service attributes to be returned. The lpBuffer parameter is a pointer to a <see cref="SERVICE_STATUS_PROCESS"/> structure.
	/// </summary>
	public const uint SC_STATUS_PROCESS_INFO = 0x00000000;

	#endregion

	/// <summary>
	/// Registers a function to handle extended service control requests.
	/// </summary>
	/// <param name="lpServiceName">The name of the service run by the calling thread. This is the service name that the service control program specified in the CreateService function when creating the service.</param>
	/// <param name="lpHandlerProc">A pointer to the handler function to be registered. For more information, see HandlerEx.</param>
	/// <param name="lpContext">Any user-defined data. This parameter, which is passed to the handler function, can help identify the service when multiple services share a process.</param>
	/// <returns>If the function succeeds, the return value is a service status handle. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-registerservicectrlhandlerexw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint RegisterServiceCtrlHandlerEx(
		[In] char* lpServiceName,
		[In] void* lpHandlerProc,
		[In] void* lpContext
	);

	/// <summary>
	/// An application-defined callback function used with the <see cref="RegisterServiceCtrlHandlerEx"/> function. A service program can use it as the control handler function of a particular service.
	/// </summary>
	/// <param name="dwControl">The control code. </param>
	/// <param name="dwEventType">The type of event that has occurred. This parameter is used if dwControl is <see cref="SERVICE_CONTROL_DEVICEEVENT"/>, <see cref="SERVICE_CONTROL_HARDWAREPROFILECHANGE"/>, 
	/// <see cref="SERVICE_CONTROL_POWEREVENT"/>, or <see cref="SERVICE_CONTROL_SESSIONCHANGE"/>. Otherwise, it is zero.</param>
	/// <param name="lpEventData">Additional device information, if required. The format of this data depends on the value of the dwControl and dwEventType parameters.</param>
	/// <param name="lpContext">User-defined data passed from <see cref="RegisterServiceCtrlHandlerEx"/>. When multiple services share a process, the lpContext parameter can help identify the service.</param>
	/// <returns>The return value for this function depends on the control code received.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nc-winsvc-lphandler_function_ex</remarks>
	public delegate uint HandlerEx(
		[In] uint dwControl,
		[In] uint dwEventType,
		[In] void* lpEventData,
		[In] void* lpContext
	);

	/// <summary>
	/// Updates the service control manager's status information for the calling service.
	/// </summary>
	/// <param name="hServiceStatus">A handle to the status information structure for the current service. This handle is returned by the <see cref="RegisterServiceCtrlHandlerEx"/> function.</param>
	/// <param name="lpServiceStatus">A pointer to the <see cref="SERVICE_STATUS"/> structure the contains the latest status information for the calling service.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-setservicestatus</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool SetServiceStatus(
		[In] nint hServiceStatus,
		[In] SERVICE_STATUS* lpServiceStatus
	);

	/// <summary>
	/// Starts a service.
	/// </summary>
	/// <param name="hService">A handle to the service. This handle is returned by the <see cref="OpenService"/> or <see cref="CreateService"/> function, and it must have the <see cref="SERVICE_START"/> access right.</param>
	/// <param name="dwNumServiceArgs">The number of strings in the lpServiceArgVectors array. If lpServiceArgVectors is NULL, this parameter can be zero.</param>
	/// <param name="lpServiceArgVectors">The null-terminated strings to be passed to the ServiceMain function for the service as arguments. If there are no arguments, this parameter can be NULL. 
	/// Otherwise, the first argument (lpServiceArgVectors[0]) is the name of the service, followed by any additional arguments (lpServiceArgVectors[1] through lpServiceArgVectors[dwNumServiceArgs-1]).
	/// Driver services do not receive these arguments.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-startservicew</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool StartService(
		[In] nint hService,
		[In] uint dwNumServiceArgs,
		[In, Optional] char* lpServiceArgVectors
	);

	/// <summary>
	/// Connects the main thread of a service process to the service control manager, which causes the thread to be the service control dispatcher thread for the calling process.
	/// </summary>
	/// <param name="lpServiceStartTable">A pointer to an array of <see cref="SERVICE_TABLE_ENTRY"/> structures containing one entry for each service that can execute in the calling process.
	/// The members of the last entry in the table must have NULL values to designate the end of the table.</param>
	/// <returns>If the function succeeds, the return value is nonzero. If the function fails, the return value is zero. To get extended error information, call <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/nf-winsvc-startservicectrldispatcherw</remarks>
	[DllImport(Advapi32Lib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool StartServiceCtrlDispatcher(
		[In] SERVICE_TABLE_ENTRY* lpServiceStartTable
	);

	/// <summary>
	/// Specifies the ServiceMain function for a service that can run in the calling process. It is used by the <see cref="StartServiceCtrlDispatcher"/> function.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/winsvc/ns-winsvc-service_table_entryw</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SERVICE_TABLE_ENTRY
	{
		/// <summary>
		/// The name of a service to be run in this service process. If the service is installed with the <see cref="SERVICE_WIN32_OWN_PROCESS"/> service type, this member is ignored, but cannot be NULL. This member can be an empty string ("").
		/// If the service is installed with the <see cref="SERVICE_WIN32_SHARE_PROCESS"/> service type, this member specifies the name of the service that uses the <see cref="ServiceMain"/> function pointed to by the lpServiceProc member.
		/// </summary>
		public char* lpServiceName;

		/// <summary>
		/// A pointer to a <see cref="ServiceMain"/> function.
		/// </summary>
		public void* lpServiceProc;
	}

	/// <summary>
	/// The entry point for a service.
	/// </summary>
	/// <param name="dwNumServicesArgs">The number of arguments in the lpServiceArgVectors array.</param>
	/// <param name="lpServiceArgVectors">The null-terminated argument strings passed to the service by the call to the StartService function that started the service.
	/// If there are no arguments, this parameter can be NULL. Otherwise, the first argument (lpServiceArgVectors[0]) is the name of the service, 
	/// followed by any additional arguments (lpServiceArgVectors[1] through lpServiceArgVectors[dwNumServicesArgs-1]).</param>
	public delegate void ServiceMain(
		[In] uint dwNumServicesArgs,
		[In] char* lpServiceArgVectors
	);
}
