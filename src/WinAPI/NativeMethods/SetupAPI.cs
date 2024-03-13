// Copyright © Anton Larin, 2024. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.InteropServices;

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the SetupAPI.dll Windows API library
/// </summary>
public static unsafe class SetupAPI
{
	/// <summary>
	/// SetupAPI library file name
	/// </summary>
	public const string SetupApiLib = "SetupAPI.dll";

	/// <summary>
	/// Returns a handle to a device information set that contains requested device information elements for a local computer.
	/// </summary>
	/// <param name="ClassGuid">A pointer to the GUID for a device setup class or a device interface class. This pointer is optional and can be NULL.</param>
	/// <param name="Enumerator">A pointer to a NULL-terminated string that specifies:
	/// An identifier(ID) of a Plug and Play(PnP) enumerator.This ID can either be the value's globally unique identifier (GUID) or symbolic name. For example, "PCI" can be used to specify the PCI PnP value. Other examples of symbolic names for PnP values include "USB," "PCMCIA," and "SCSI".
	/// A PnP device instance ID.When specifying a PnP device instance ID, DIGCF_DEVICEINTERFACE must be set in the Flags parameter.
	/// This pointer is optional and can be NULL.If an enumeration value is not used to select devices, set Enumerator to NULL</param>
	/// <param name="hwndParent">A handle to the top-level window to be used for a user interface that is associated with installing a device instance in the device information set. This handle is optional and can be NULL.</param>
	/// <param name="Flags">A variable of type DWORD that specifies control options that filter the device information elements that are added to the device information set.</param>
	/// <returns>If the operation succeeds, SetupDiGetClassDevs returns a handle to a device information set that contains all installed devices that matched the supplied parameters. If the operation fails, the function returns INVALID_HANDLE_VALUE. To get extended error information, call GetLastError.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetclassdevsw</remarks>
	[DllImport(SetupApiLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern nint SetupDiGetClassDevs(
		[In] Guid* ClassGuid,
		[In] void* Enumerator,
		[In] nint hwndParent,
		[In] uint Flags
	);

	/// <summary>
	/// The GUID_DEVINTERFACE_CDROM device interface class is defined for CD-ROM storage devices.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows-hardware/drivers/install/guid-devinterface-cdrom</remarks>
	public static readonly Guid GUID_DEVINTERFACE_CDROM = new("53f56308-b6bf-11d0-94f2-00a0c91efb8b");

	/// <summary>
	/// The GUID_DEVINTERFACE_DISK device interface class is defined for hard disk storage devices.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows-hardware/drivers/install/guid-devinterface-disk</remarks>
	public static readonly Guid GUID_DEVINTERFACE_DISK = new("53f56307-b6bf-11d0-94f2-00a0c91efb8b");

	/// <summary>
	/// The GUID_DEVINTERFACE_HIDDEN_DISK device interface class is defined for hard disk storage devices are hidden in disk manager.
	/// </summary>
	/// <remarks>https://social.msdn.microsoft.com/Forums/windowsdesktop/en-US/de5f3123-3f8f-43cd-b85c-c754986a6250/get-physical-disk-mapping-for-win-8-storage-spaces-virtual-disks</remarks>
	public static readonly Guid GUID_DEVINTERFACE_HIDDEN_DISK = new("7fccc86c-228a-40ad-8a58-f590af7bfdce");

	/// <summary>
	/// The GUID_DEVINTERFACE_FLOPPY device interface class is defined for floppy disk storage devices.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows-hardware/drivers/install/guid-devinterface-floppy</remarks>
	public static readonly Guid GUID_DEVINTERFACE_FLOPPY = new("53f56311-b6bf-11d0-94f2-00a0c91efb8b");


	/// <summary>
	/// Return a list of installed devices for all device setup classes or all device interface classes.
	/// </summary>
	public const uint DIGCF_ALLCLASSES = 0x00000004;

	/// <summary>
	/// Return devices that support device interfaces for the specified device interface classes. This flag must be set in the Flags parameter if the Enumerator parameter specifies a device instance ID.
	/// </summary>
	public const uint DIGCF_DEVICEINTERFACE = 0x00000010;

	/// <summary>
	/// Return only the device that is associated with the system default device interface, if one is set, for the specified device interface classes.
	/// </summary>
	public const uint DIGCF_DEFAULT = 0x00000001;

	/// <summary>
	/// Return only devices that are currently present in a system.
	/// </summary>
	public const uint DIGCF_PRESENT = 0x00000002;

	/// <summary>
	/// Return only devices that are a part of the current hardware profile.
	/// </summary>
	public const uint DIGCF_PROFILE = 0x00000008;

	/// <summary>
	/// Returns a <see cref="SP_DEVINFO_DATA"/> structure that specifies a device information element in a device information set.
	/// </summary>
	/// <param name="hDeviceInfoSet">A handle to the device information set for which to return an <see cref="SP_DEVINFO_DATA"/> structure that represents a device information element.</param>
	/// <param name="MemberIndex">A zero-based index of the device information element to retrieve.</param>
	/// <param name="DeviceInfoData">A pointer to an <see cref="SP_DEVINFO_DATA"/> structure to receive information about an enumerated device information element. The caller must set DeviceInfoData.cbSize to sizeof(SP_DEVINFO_DATA).</param>
	/// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved with a call to <see cref="GetLastError"/>.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdienumdeviceinfo</remarks>
	[DllImport(SetupApiLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool SetupDiEnumDeviceInfo(
		[In] nint hDeviceInfoSet,
		[In] uint MemberIndex,
		[In] SP_DEVINFO_DATA* DeviceInfoData
	);

	/// <summary>
	/// Enumerates the device interfaces that are contained in a device information set.
	/// </summary>
	/// <param name="hDeviceInfoSet">A pointer to a device information set that contains the device interfaces for which to return information. This handle is typically returned by <see cref="SetupDiGetClassDevs"/>.</param>
	/// <param name="pDeviceInfoData">A pointer to a <see cref="SP_DEVINFO_DATA"/> structure that specifies a device information element in DeviceInfoSet. This parameter is optional and can be NULL. 
	/// If this parameter is specified, <see cref="SetupDiEnumDeviceInterfaces"/> constrains the enumeration to the interfaces that are supported by the specified device. 
	/// If this parameter is NULL, repeated calls to <see cref="SetupDiEnumDeviceInterfaces"/> return information about the interfaces that are associated with all the device information elements in DeviceInfoSet. 
	/// This pointer is typically returned by <see cref="SetupDiEnumDeviceInfo"/>.</param>
	/// <param name="InterfaceClassGuid">A pointer to a GUID that specifies the device interface class for the requested interface.</param>
	/// <param name="MemberIndex">A zero-based index into the list of interfaces in the device information set. The caller should call this function first with MemberIndex set to zero to obtain the first interface. 
	/// Then, repeatedly increment MemberIndex and retrieve an interface until this function fails and GetLastError returns ERROR_NO_MORE_ITEMS. 
	/// If DeviceInfoData specifies a particular device, the MemberIndex is relative to only the interfaces exposed by that device.</param>
	/// <param name="DeviceInterfaceData">A pointer to a caller-allocated buffer that contains, on successful return, a completed <see cref="SP_DEVICE_INTERFACE_DATA"/> structure that identifies an interface that meets the search parameters. 
	/// The caller must set DeviceInterfaceData.cbSize to sizeof(SP_DEVICE_INTERFACE_DATA) before calling this function.</param>
	/// <returns>Returns TRUE if the function completed without error. If the function completed with an error, FALSE is returned and the error code for the failure can be retrieved by calling GetLastError.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdienumdeviceinterfaces</remarks>
	[DllImport(SetupApiLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool SetupDiEnumDeviceInterfaces(
		[In] nint hDeviceInfoSet,
		[In, Optional] SP_DEVINFO_DATA* pDeviceInfoData,
		[In] Guid* InterfaceClassGuid,
		[In] uint MemberIndex,
		[Out] SP_DEVICE_INTERFACE_DATA* DeviceInterfaceData
	);

	/// <summary>
	/// Defines a device instance that is a member of a device information set.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_devinfo_data</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SP_DEVINFO_DATA
	{
		/// <summary>
		/// The size, in bytes, of the <see cref="SP_DEVINFO_DATA"/> structure.
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// The GUID of the device's setup class.
		/// </summary>
		public Guid ClassGuid;

		/// <summary>
		/// An opaque handle to the device instance (also known as a handle to the devnode). 
		/// Some functions, such as SetupDiXxx functions, take the whole SP_DEVINFO_DATA structure as input to identify a device in a device information set.
		/// Other functions, such as CM_Xxx functions like CM_Get_DevNode_Status, take this DevInst handle as input.
		/// </summary>
		public uint DevInst;

		/// <summary>
		/// Reserved. For internal use only.
		/// </summary>
		public nuint Reserved;

		/// <summary>
		/// Initializes a new instance of the <see cref="SP_DEVINFO_DATA"/> structure
		/// </summary>
		public SP_DEVINFO_DATA()
		{
			cbSize = (uint)Marshal.SizeOf(this);
		}
	}

	/// <summary>
	/// Defines a device interface in a device information set.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_device_interface_data</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SP_DEVICE_INTERFACE_DATA
	{
		/// <summary>
		/// The size, in bytes, of the <see cref="SP_DEVICE_INTERFACE_DATA"/> structure.
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// The GUID for the class to which the device interface belongs.
		/// </summary>
		public Guid InterfaceClassGuid;

		/// <summary>
		/// Can be one or more of the SPINT_XXX constants
		/// </summary>
		public uint Flags;

		/// <summary>
		/// Reserved. Do not use.
		/// </summary>
		public nuint Reserved;

		/// <summary>
		/// Initializes a new instance of the <see cref="SP_DEVICE_INTERFACE_DATA"/> structure
		/// </summary>
		public SP_DEVICE_INTERFACE_DATA()
		{
			cbSize = (uint)Marshal.SizeOf(this);
		}
	}

	/// <summary>
	/// The interface is active (enabled).
	/// </summary>
	public const uint SPINT_ACTIVE = 0x00000001;

	/// <summary>
	/// The interface is the default interface for the device class.
	/// </summary>
	public const uint SPINT_DEFAULT = 0x00000002;

	/// <summary>
	/// Return only devices that are a part of the current hardware profile.
	/// </summary>
	public const uint SPINT_REMOVED = 0x00000004;

	/// <summary>
	/// Returns details about a device interface.
	/// </summary>
	/// <param name="hDeviceInfoSet">A pointer to the device information set that contains the interface for which to retrieve details. This handle is typically returned by <see cref="SetupDiGetClassDevs"/>.</param>
	/// <param name="pDeviceInterfaceData">A pointer to an <see cref="SP_DEVICE_INTERFACE_DATA"/> structure that specifies the interface in DeviceInfoSet for which to retrieve details. 
	/// A pointer of this type is typically returned by <see cref="SetupDiEnumDeviceInterfaces"/>.</param>
	/// <param name="pDeviceInterfaceDetailData">A pointer to an <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA_W"/> structure to receive information about the specified interface. This parameter is optional and can be NULL. 
	/// This parameter must be NULL if DeviceInterfaceDetailSize is zero. If this parameter is specified, the caller must set DeviceInterfaceDetailData.cbSize to sizeof(SP_DEVICE_INTERFACE_DETAIL_DATA) before calling this function. 
	/// The cbSize member always contains the size of the fixed part of the data structure, not a size reflecting the variable-length string at the end.</param>
	/// <param name="DeviceInterfaceDetailDataSize">The size of the DeviceInterfaceDetailData buffer. The buffer must be at least (offsetof(SP_DEVICE_INTERFACE_DETAIL_DATA, DevicePath) + sizeof(TCHAR)) bytes, to contain the fixed part of the structure and a single NULL to terminate an empty MULTI_SZ string.
	/// This parameter must be zero if DeviceInterfaceDetailData is NULL.</param>
	/// <param name="pRequiredSize">A pointer to a variable of type DWORD that receives the required size of the DeviceInterfaceDetailData buffer. This size includes the size of the fixed part of the structure plus the number of bytes required for the variable-length device path string. This parameter is optional and can be NULL.</param>
	/// <param name="pDeviceInfoData">A pointer to a buffer that receives information about the device that supports the requested interface. The caller must set DeviceInfoData.cbSize to sizeof(SP_DEVINFO_DATA). This parameter is optional and can be NULL.</param>
	/// <returns>Returns TRUE if the function completed without error. If the function completed with an error, FALSE is returned and the error code for the failure can be retrieved by calling GetLastError.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdigetdeviceinterfacedetailw</remarks>
	[DllImport(SetupApiLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool SetupDiGetDeviceInterfaceDetail(
		[In] nint hDeviceInfoSet,
		[In] SP_DEVICE_INTERFACE_DATA* pDeviceInterfaceData,
		[Out, Optional] void* pDeviceInterfaceDetailData,
		[In] uint DeviceInterfaceDetailDataSize,
		[Out, Optional] uint* pRequiredSize,
		[Out, Optional] SP_DEVINFO_DATA* pDeviceInfoData
	);

	/// <summary>
	/// Contains the path for a device interface.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_device_interface_detail_data_w</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct SP_DEVICE_INTERFACE_DETAIL_DATA_W
	{
		/// <summary>
		/// The size, in bytes, of the <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA_W"/> structure.
		/// </summary>
		public uint cbSize;

		/// <summary>
		/// A NULL-terminated string that contains the device interface path. This path can be passed to Win32 functions such as CreateFile.
		/// </summary>
		public char DevicePath;

		/// <summary>
		/// Initializes a new instance of the <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA_W"/> structure
		/// </summary>
		public SP_DEVICE_INTERFACE_DETAIL_DATA_W()
		{
			cbSize = (uint)Marshal.SizeOf(this);
		}
	}

	/// <summary>
	/// Deletes a device information set and frees all associated memory.
	/// </summary>
	/// <param name="hDeviceInfoSet">A handle to the device information set to delete.</param>
	/// <returns>The function returns TRUE if it is successful. Otherwise, it returns FALSE and the logged error can be retrieved with a call to GetLastError.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/setupapi/nf-setupapi-setupdidestroydeviceinfolist</remarks>
	[DllImport(SetupApiLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern bool SetupDiDestroyDeviceInfoList(
		[In] nint hDeviceInfoSet
	);

}
