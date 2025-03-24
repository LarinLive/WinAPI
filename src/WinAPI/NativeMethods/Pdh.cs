// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the Pdh.dll Windows API library
/// </summary>
public static unsafe partial class Pdh
{
	/// <summary>
	/// Pdh library file name
	/// </summary>
	public const string PdhLib = "Pdh.dll";

	/// <summary>
	/// Maximum counter name length.
	/// </summary>
	public const uint PDH_MAX_COUNTER_NAME = 1024;

	/// <summary>
	/// Maximum counter instance name length.
	/// </summary>
	public const uint PDH_MAX_INSTANCE_NAME = 1024;

	/// <summary>
	/// Maximum full counter path length.
	/// </summary>
	public const uint PDH_MAX_COUNTER_PATH = 2048;

	/// <summary>
	/// Maximum full counter log name length.
	/// </summary>
	public const uint PDH_MAX_DATASOURCE_PATH = 1024;

	/// <summary>
	/// Binds one or more binary log files together for reading log data.
	/// </summary>
	/// <param name="phDataSource">Handle to the bound data sources.</param>
	/// <param name="LogFileNameList">Null-terminated string that contains one or more binary log files to bind together.
	/// Terminate each log file name with a null-terminator character and the list with one additional null-terminator character. 
	/// The log file names can contain absolute or relative paths. You cannot specify more than 32 log files.
	/// If NULL, the source is a real-time data source.</param>
	/// <returns>Returns ERROR_SUCCESS if the function succeeds. If the function fails, the return value is a system error code or a PDH error code.</returns>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhBindInputDataSourceW(
		[Out] nint* phDataSource,
		[In] char* LogFileNameList
	);

	/// <summary>
	/// Closes the specified log file.
	/// </summary>
	/// <param name="hLog">Handle to the log file to be closed. This handle is returned by the <see cref="PdhOpenLog"/> function.</param>
	/// <param name="dwFlags">You can specify the <see cref="PDH_FLAGS_CLOSE_QUERY"/> flag.</param>
	/// <returns>If the function succeeds, it returns ERROR_SUCCESS and closes and deletes the query. If the function fails, the return value is a system error code or a PDH error code. </returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcloselog</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhCloseLog(
		[In] nint hLog,
		[In] uint dwFlags
	);

	/// <summary>
	/// Closes the query associated with the specified log file handle. See the hQuery parameter of <see cref="PdhOpenLog"/>.
	/// </summary>
	public const uint PDH_FLAGS_CLOSE_QUERY = 1;


	/// <summary>
	/// Returns the specified object's counter and instance names that exist on the specified computer or in the specified log file.
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the <see cref="PdhBindInputDataSourceW"/> function.</param>
	/// <param name="szMachineName">Null-terminated string that specifies the name of the computer that contains the counter and instance names that you want to enumerate.
	/// Include the leading slashes in the computer name, for example, \computername. If the szDataSource parameter is NULL, you can set szMachineName to NULL to specify the local computer.</param>
	/// <param name="szObjectName">Null-terminated string that specifies the name of the object whose counter and instance names you want to enumerate.</param>
	/// <param name="mszCounterList">Caller-allocated buffer that receives a list of null-terminated counter names provided by the specified object. The list contains unique counter names.
	/// The list is terminated by two NULL characters. Set to NULL if the pcchCounterListLength parameter is zero.</param>
	/// <param name="pcchCounterListLength">Size of the mszCounterList buffer, in TCHARs.
	/// If zero on input and the object exists, the function returns <see cref="PDH_MORE_DATA"/> and sets this parameter to the required buffer size. 
	/// If the buffer is larger than the required size, the function sets this parameter to the actual size of the buffer that was used. 
	/// If the specified size on input is greater than zero but less than the required size, you should not rely on the returned size to reallocate the buffer.</param>
	/// <param name="mszInstanceList">Caller-allocated buffer that receives a list of null-terminated instance names provided by the specified object. The list contains unique instance names. 
	/// The list is terminated by two NULL characters. Set to NULL if the pcchInstanceListLength parameter is zero.</param>
	/// <param name="pcchInstanceListLength">Size of the mszInstanceList buffer, in TCHARs. 
	/// If zero on input and the object exists, the function returns <see cref="PDH_MORE_DATA"/> and sets this parameter to the required buffer size. 
	/// If the buffer is larger than the required size, the function sets this parameter to the actual size of the buffer that was used. 
	/// If the specified size on input is greater than zero but less than the required size, you should not rely on the returned size to reallocate the buffer.
	/// If the specified object does not support variable instances, then the returned value will be zero. 
	/// If the specified object does support variable instances, but does not currently have any instances, then the value returned is 2, which is the size of an empty MULTI_SZ list string.</param>
	/// <param name="dwDetailLevel">Detail level of the performance items to return. All items that are of the specified detail level or less will be returned (the levels are listed in increasing order).</param>
	/// <param name="dwFlags">This parameter must be zero.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhenumobjectitemshw</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhEnumObjectItemsHW(
		[In] nint hDataSource,
		[In] char* szMachineName,
		[In] char* szObjectName,
		[Out] char* mszCounterList,
		[In, Out] uint* pcchCounterListLength,
		[Out] char* mszInstanceList,
		[In, Out] uint* pcchInstanceListLength,
		[In] uint dwDetailLevel,
		[In] uint dwFlags
	);

	/// <summary>
	/// Returns a list of objects available on the specified computer or in the specified log file.
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the <see cref="PdhBindInputDataSourceW"/> function.</param>
	/// <param name="szMachineName">Null-terminated string that specifies the name of the computer used to enumerate the performance objects.
	/// Include the leading slashes in the computer name, for example, \computername. If szDataSource is NULL, you can set szMachineName to NULL to specify the local computer.</param>
	/// <param name="mszObjectList">Caller-allocated buffer that receives the list of object names. Each object name in this list is terminated by a null character. 
	/// The list is terminated with two null-terminator characters. Set to NULL if pcchBufferLength is zero.</param>
	/// <param name="pcchBufferSize">Size of the mszObjectList buffer, in TCHARs. If zero on input, the function returns <see cref="PDH_MORE_DATA"/> and sets this parameter to the required buffer size. 
	/// If the buffer is larger than the required size, the function sets this parameter to the actual size of the buffer that was used. 
	/// If the specified size on input is greater than zero but less than the required size, you should not rely on the returned size to reallocate the buffer.</param>
	/// <param name="dwDetailLevel">Detail level of the performance items to return. All items that are of the specified detail level or less will be returned (the levels are listed in increasing order).</param>
	/// <param name="bRefresh">Indicates if the cached object list should be automatically refreshed. Specify one of the following values.	
	/// If you call this function twice, once to get the size of the list and a second time to get the actual list, set this parameter to TRUE on the first call and FALSE on the second call.
	/// If both calls are TRUE, the second call may also return <see cref="PDH_MORE_DATA"/> because the object data may have changed between calls.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhenumobjectshw</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhEnumObjectsHW(
		[In] nint hDataSource,
		[In] char* szMachineName,
		[Out] char* mszObjectList,
		[In, Out] uint* pcchBufferSize,
		[In] uint dwDetailLevel,
		[In] bool bRefresh
	);

	/// <summary>
	/// Novice user level of detail.
	/// </summary>
	public const uint PERF_DETAIL_NOVICE = 100;

	/// <summary>
	/// Advanced user level of detail.
	/// </summary>
	public const uint PERF_DETAIL_ADVANCED = 200;

	/// <summary>
	/// Expert user level of detail.
	/// </summary>
	public const uint PERF_DETAIL_EXPERT = 300;

	/// <summary>
	/// System designer level of detail.
	/// </summary>
	public const uint PERF_DETAIL_WIZARD = 400;
}
