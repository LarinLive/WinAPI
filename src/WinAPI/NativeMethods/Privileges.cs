// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// Privilege Constants
/// </summary>
/// <remarks>https://learn.microsoft.com/en-us/windows/win32/secauthz/privilege-constants</remarks>
public class Privileges
{
	/// <summary>
	/// Required to assign the primary token of a process.
	/// User Right: Replace a process-level token.
	/// </summary>
	public const string SE_ASSIGNPRIMARYTOKEN_NAME = "SeAssignPrimaryTokenPrivilege";

	/// <summary>
	/// Required to generate audit-log entries. Give this privilege to secure servers.
	/// User Right: Generate security audits.
	/// </summary>
	public const string SE_AUDIT_NAME = "SeAuditPrivilege";

	/// <summary>
	/// Required to perform backup operations. This privilege causes the system to grant all read access control to any file, regardless of the access control list (ACL) specified for the file. 
	/// Any access request other than read is still evaluated with the ACL. 
	/// User Right: Back up files and directories.
	/// </summary>
	public const string SE_BACKUP_NAME = "SeBackupPrivilege";

	/// <summary>
	/// Required to receive notifications of changes to files or directories. This privilege also causes the system to skip all traversal access checks. It is enabled by default for all users.
	/// User Right: Bypass traverse checking.
	/// </summary>
	public const string SE_CHANGE_NOTIFY_NAME = "SeChangeNotifyPrivilege";

	/// <summary>
	/// Required to create named file mapping objects in the global namespace during Terminal Services sessions. This privilege is enabled by default for administrators, services, and the local system account.
	/// User Right: Create global objects.
	/// </summary>
	public const string SE_CREATE_GLOBAL_NAME = "SeCreateGlobalPrivilege";

	/// <summary>
	/// Required to create a paging file.
	/// User Right: Create a pagefile.
	/// </summary>
	public const string SE_CREATE_PAGEFILE_NAME = "SeCreatePagefilePrivilege";

	/// <summary>
	/// Required to create a permanent object.
	/// User Right: Create permanent shared objects.
	/// </summary>
	public const string SE_CREATE_PERMANENT_NAME = "SeCreatePermanentPrivilege";

	/// <summary>
	/// Required to create a symbolic link.
	/// User Right: Create symbolic links.
	/// </summary>
	public const string SE_CREATE_SYMBOLIC_LINK_NAME = "SeCreateSymbolicLinkPrivilege";

	/// <summary>
	/// Required to create a primary token. 
	/// User Right: Create a token object.
	/// You cannot add this privilege to a user account with the "Create a token object" policy.
	/// Additionally, you cannot add this privilege to an owned process using Windows APIs.
	/// </summary>
	public const string SE_CREATE_TOKEN_NAME = "SeCreateTokenPrivilege";

	/// <summary>
	/// Required to debug and adjust the memory of a process owned by another account.
	/// User Right: Debug programs.
	/// </summary>
	public const string SE_DEBUG_NAME = "SeDebugPrivilege";

	/// <summary>
	/// Required to obtain an impersonation token for another user in the same session.
	/// User Right: Impersonate other users.
	/// </summary>
	public const string SE_DELEGATE_SESSION_USER_IMPERSONATE_NAME = "SeDelegateSessionUserImpersonatePrivilege";

	/// <summary>
	/// Required to mark user and computer accounts as trusted for delegation.
	/// User Right: Enable computer and user accounts to be trusted for delegation.
	/// </summary>
	public const string SE_ENABLE_DELEGATION_NAME = "SeEnableDelegationPrivilege";

	/// <summary>
	/// Required to impersonate.
	/// User Right: Impersonate a client after authentication.
	/// </summary>
	public const string SE_IMPERSONATE_NAME = "SeImpersonatePrivilege";

	/// <summary>
	/// Required to increase the base priority of a process.
	/// User Right: Increase scheduling priority.
	/// </summary>
	public const string SE_INC_BASE_PRIORITY_NAME = "SeIncreaseBasePriorityPrivilege";

	/// <summary>
	/// Required to increase the quota assigned to a process.
	/// User Right: Adjust memory quotas for a process.
	/// </summary>
	public const string SE_INCREASE_QUOTA_NAME = "SeIncreaseQuotaPrivilege";

	/// <summary>
	/// Required to allocate more memory for applications that run in the context of users.
	/// User Right: Increase a process working set.
	/// </summary>
	public const string SE_INC_WORKING_SET_NAME = "SeIncreaseWorkingSetPrivilege";

	/// <summary>
	/// Required to load or unload a device driver.
	/// User Right: Load and unload device drivers.
	/// </summary>
	public const string SE_LOAD_DRIVER_NAME = "SeLoadDriverPrivilege";

	/// <summary>
	/// Required to lock physical pages in memory.
	/// User Right: Lock pages in memory.
	/// </summary>
	public const string SE_LOCK_MEMORY_NAME = "SeLockMemoryPrivilege";

	/// <summary>
	/// Required to create a computer account.
	/// User Right: Add workstations to domain.
	/// </summary>
	public const string SE_MACHINE_ACCOUNT_NAME = "SeMachineAccountPrivilege";

	/// <summary>
	/// Required to enable volume management privileges.
	/// User Right: Perform volume maintenance tasks.
	/// </summary>
	public const string SE_MANAGE_VOLUME_NAME = "SeManageVolumePrivilege";

	/// <summary>
	/// Required to gather profiling information for a single process.
	/// User Right: Profile single process.
	/// </summary>
	public const string SE_PROF_SINGLE_PROCESS_NAME = "SeProfileSingleProcessPrivilege";

	/// <summary>
	/// Required to modify the mandatory integrity level of an object.
	/// User Right: Modify an object label.
	/// </summary>
	public const string SE_RELABEL_NAME = "SeRelabelPrivilege";

	/// <summary>
	/// Required to shut down a system using a network request.
	/// User Right: Force shutdown from a remote system.
	/// </summary>
	public const string SE_REMOTE_SHUTDOWN_NAME = "SeRemoteShutdownPrivilege";

	/// <summary>
	/// Required to perform restore operations. This privilege causes the system to grant all write access control to any file, regardless of the ACL specified for the file. Any access request other than write is still evaluated with the ACL. 
	/// User Right: Restore files and directories.
	/// </summary>
	public const string SE_RESTORE_NAME = "SeRestorePrivilege";

	/// <summary>
	/// Required to perform a number of security-related functions, such as controlling and viewing audit messages. This privilege identifies its holder as a security operator.
	/// User Right: Manage auditing and security log.
	/// </summary>
	public const string SE_SECURITY_NAME = "SeSecurityPrivilege";

	/// <summary>
	/// Required to shut down a local system.
	/// User Right: Shut down the system.
	/// </summary>
	public const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";

	/// <summary>
	/// Required for a domain controller to use the Lightweight Directory Access Protocol directory synchronization services. 
	/// This privilege enables the holder to read all objects and properties in the directory, regardless of the protection on the objects and properties. 
	/// By default, it is assigned to the Administrator and LocalSystem accounts on domain controllers.
	/// User Right: Synchronize directory service data.
	/// </summary>
	public const string SE_SYNC_AGENT_NAME = "SeSyncAgentPrivilege";

	/// <summary>
	/// Required to modify the nonvolatile RAM of systems that use this type of memory to store configuration information.
	/// User Right: Modify firmware environment values.
	/// </summary>
	public const string SE_SYSTEM_ENVIRONMENT_NAME = "SeSystemEnvironmentPrivilege";

	/// <summary>
	/// Required to gather profiling information for the entire system.
	/// User Right: Profile system performance.
	/// </summary>
	public const string SE_SYSTEM_PROFILE_NAME = "SeSystemProfilePrivilege";

	/// <summary>
	/// Required to modify the system time. 
	/// User Right: Change the system time.
	/// </summary>
	public const string SE_SYSTEMTIME_NAME = "SeSystemtimePrivilege";

	/// <summary>
	/// Required to take ownership of an object without being granted discretionary access. This privilege allows the owner value to be set only to those values that the holder may legitimately assign as the owner of an object.
	/// User Right: Take ownership of files or other objects.
	/// </summary>
	public const string SE_TAKE_OWNERSHIP_NAME = "SeTakeOwnershipPrivilege";

	/// <summary>
	/// This privilege identifies its holder as part of the trusted computer base. Some trusted protected subsystems are granted this privilege.
	/// User Right: Act as part of the operating system.
	/// </summary>
	public const string SE_TCB_NAME = "SeTcbPrivilege";

	/// <summary>
	/// Required to adjust the time zone associated with the computer's internal clock. User Right: Change the time zone.
	/// </summary>
	public const string SE_TIME_ZONE_NAME = "SeTimeZonePrivilege";

	/// <summary>
	/// Required to access Credential Manager as a trusted caller. User Right: Access Credential Manager as a trusted caller.
	/// </summary>
	public const string SE_TRUSTED_CREDMAN_ACCESS_NAME = "SeTrustedCredManAccessPrivilege";

	/// <summary>
	/// Required to undock a laptop. 
	/// User Right: Remove computer from docking station.
	/// </summary>
	public const string SE_UNDOCK_NAME = "SeUndockPrivilege";

	/// <summary>
	/// Required to read unsolicited input from a terminal device.
	/// User Right: Not applicable.
	/// </summary>
	public const string SE_UNSOLICITED_INPUT_NAME = "SeUnsolicitedInputPrivilege";
}
