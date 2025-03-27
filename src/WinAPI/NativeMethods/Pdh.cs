// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;
using static LarinLive.WinAPI.NativeMethods.Kernel32;
using static LarinLive.WinAPI.NativeMethods.ErrorCodes;
using static LarinLive.WinAPI.NativeMethods.Minwinbase;

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
	/// Mininal counter scale factor
	/// </summary>
	public const int PDH_MIN_SCALE = -7;

	/// <summary>
	/// Maximal counter scale factor
	/// </summary>
	public const int PDH_MAX_SCALE = 7;

	/// <summary>
	/// Adds the specified counter to the query.
	/// </summary>
	/// <param name="hQuery">Handle to the query to which you want to add the counter. This handle is returned by the <see cref="PdhOpenQueryH"/> function.</param>
	/// <param name="szFullCounterPath">Null-terminated string that contains the counter path. The maximum length of a counter path is <see cref="PDH_MAX_COUNTER_PATH"/>.</param>
	/// <param name="dwUserData">User-defined value. This value becomes part of the counter information. 
	/// To retrieve this value later, call the <see cref="PdhGetCounterInfoW"/> function and access the dwUserData member of the <see cref="PDH_COUNTER_INFO_W"/> structure.</param>
	/// <param name="phCounter">Handle to the counter that was added to the query. You may need to reference this handle in subsequent calls.</param>
	/// <returns>Return <see cref="ERROR_SUCCESS"/> if the function succeeds. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhaddcounterw</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhAddCounterW(
		[In] nint hQuery,
		[In] char* szFullCounterPath,
		[In] nuint dwUserData,
		[Out] nint* phCounter
	);

	/// <summary>
	/// Adds the specified language-neutral counter to the query.
	/// </summary>
	/// <param name="hQuery">Handle to the query to which you want to add the counter. This handle is returned by the <see cref="PdhOpenQueryH"/> function.</param>
	/// <param name="szFullCounterPath">Null-terminated string that contains the counter path. The maximum length of a counter path is <see cref="PDH_MAX_COUNTER_PATH"/>.</param>
	/// <param name="dwUserData">User-defined value. This value becomes part of the counter information. 
	/// To retrieve this value later, call the <see cref="PdhGetCounterInfoW"/> function and access the dwUserData member of the <see cref="PDH_COUNTER_INFO_W"/> structure.</param>
	/// <param name="phCounter">Handle to the counter that was added to the query. You may need to reference this handle in subsequent calls.</param>
	/// <returns>Return <see cref="ERROR_SUCCESS"/> if the function succeeds. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhaddenglishcounterw</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhAddEnglishCounterW(
		[In] nint hQuery,
		[In] char* szFullCounterPath,
		[In] nuint dwUserData,
		[Out] nint* phCounter
	);

	/// <summary>
	/// Binds one or more binary log files together for reading log data.
	/// </summary>
	/// <param name="phDataSource">Handle to the bound data sources.</param>
	/// <param name="LogFileNameList">Null-terminated string that contains one or more binary log files to bind together.
	/// Terminate each log file name with a null-terminator character and the list with one additional null-terminator character. 
	/// The log file names can contain absolute or relative paths. You cannot specify more than 32 log files.
	/// If NULL, the source is a real-time data source.</param>
	/// <returns>returns <see cref="ERROR_SUCCESS"/> if the function succeeds. If the function fails, the return value is a system error code or a PDH error code.</returns>
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
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/> and closes and deletes the query. If the function fails, the return value is a system error code or a PDH error code. </returns>
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
	/// Closes all counters contained in the specified query, closes all handles related to the query, and frees all memory associated with the query.
	/// </summary>
	/// <param name="hQuery">Handle to the query to close. This handle is returned by the <see cref="PdhOpenQueryW"/> function.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/> and closes and deletes the query. If the function fails, the return value is a system error code or a PDH error code. </returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhclosequery</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhCloseQuery(
		[In] nint hQuery
	);

	/// <summary>
	/// Collects the current raw data value for all counters in the specified query and updates the status code of each counter.
	/// </summary>
	/// <param name="hQuery">Handle of the query for which you want to collect data. The PdhOpenQuery function returns this handle.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/> and closes and deletes the query. If the function fails, the return value is a system error code or a PDH error code. </returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcollectquerydata</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhCollectQueryData(
		[In] nint hQuery
	);

	/// <summary>
	/// Uses a separate thread to collect the current raw data value for all counters in the specified query. 
	/// The function then signals the application-defined event and waits the specified time interval before returning.
	/// </summary>
	/// <param name="hQuery">Handle of the query for which you want to collect data. The PdhOpenQuery function returns this handle.</param>
	/// <param name="dwIntervalTime">Time interval to wait, in seconds.</param>
	/// <param name="hNewDataEvent">Handle to the event that you want PDH to signal after the time interval expires. To create an event object, call the <see cref="CreateEvent"/> function.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/> and closes and deletes the query. If the function fails, the return value is a system error code or a PDH error code. </returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcollectquerydataex</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhCollectQueryDataEx(
		[In] nint hQuery,
		[In] uint dwIntervalTime,
		[In] nint hNewDataEvent
	);


	/// <summary>
	/// Collects the current raw data value for all counters in the specified query and updates the status code of each counter.
	/// </summary>
	/// <param name="hQuery">Handle of the query for which you want to collect data. The PdhOpenQuery function returns this handle.</param>
	/// <param name="pllTimeStamp">Time stamp when the first counter value in the query was retrieved. The time is specified as <see cref="FILETIME"/>.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/> and closes and deletes the query. If the function fails, the return value is a system error code or a PDH error code. </returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcollectquerydatawithtime</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhCollectQueryDataWithTime(
		[In] nint hQuery,
		[Out] long* pllTimeStamp
	);

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


	/// <summary>
	/// Examines the specified computer or log file and returns those counter paths that match the given counter path which contains wildcard characters.
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the <see cref="PdhBindInputDataSourceW"/> function.</param>
	/// <param name="szWildCardPath">Null-terminated string that specifies the counter path to expand. The maximum length of a counter path is <see cref="PDH_MAX_COUNTER_PATH"/>.
	/// If hDataSource is a real time data source, the function searches the computer specified in the path for matches.
	/// If the path does not specify a computer, the function searches the local computer.</param>
	/// <param name="mszExpandedPathList">Caller-allocated buffer that receives a list of null-terminated counter paths that match the wildcard specification in the szWildCardPath. 
	/// The list is terminated by two NULL characters. Set to NULL if pcchPathListLength is zero.</param>
	/// <param name="pcchPathListLength">Size of the mszExpandedPathList buffer, in TCHARs. 
	/// If zero on input and the object exists, the function returns <see cref="PDH_MORE_DATA"/> and sets this parameter to the required buffer size. 
	/// If the buffer is larger than the required size, the function sets this parameter to the actual size of the buffer that was used. 
	/// If the specified size on input is greater than zero but less than the required size, you should not rely on the returned size to reallocate the buffer.</param>
	/// <param name="dwFlags">Flags that indicate which wildcard characters not to expand.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhexpandwildcardpathhw</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhExpandWildCardPathHW(
		[In] nint hDataSource,
		[In] char* szWildCardPath,
		[Out] char* mszExpandedPathList,
		[In, Out] uint* pcchPathListLength,
		[In] uint dwFlags
	);

	/// <summary>
	/// Examines the specified computer or log file and returns those counter paths that match the given counter path which contains wildcard characters.
	/// </summary>
	/// <param name="szDataSource">Null-terminated string that contains the name of a log file. 
	/// The function uses the performance objects and counters defined in the log file to expand the path specified in the szWildCardPath parameter.
	/// If NULL, the function searches the computer specified in szWildCardPath.</param>
	/// <param name="szWildCardPath">Null-terminated string that specifies the counter path to expand. The maximum length of a counter path is <see cref="PDH_MAX_COUNTER_PATH"/>.
	/// If hDataSource is a real time data source, the function searches the computer specified in the path for matches.
	/// If the path does not specify a computer, the function searches the local computer.</param>
	/// <param name="mszExpandedPathList">Caller-allocated buffer that receives a list of null-terminated counter paths that match the wildcard specification in the szWildCardPath. 
	/// The list is terminated by two NULL characters. Set to NULL if pcchPathListLength is zero.</param>
	/// <param name="pcchPathListLength">Size of the mszExpandedPathList buffer, in TCHARs. 
	/// If zero on input and the object exists, the function returns <see cref="PDH_MORE_DATA"/> and sets this parameter to the required buffer size. 
	/// If the buffer is larger than the required size, the function sets this parameter to the actual size of the buffer that was used. 
	/// If the specified size on input is greater than zero but less than the required size, you should not rely on the returned size to reallocate the buffer.</param>
	/// <param name="dwFlags">Flags that indicate which wildcard characters not to expand.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhexpandwildcardpathw</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhExpandWildCardPathW(
		[In] char* szDataSource,
		[In] char* szWildCardPath,
		[Out] char* mszExpandedPathList,
		[In, Out] uint* pcchPathListLength,
		[In] uint dwFlags
	);

	#region Possible values for the PdhExpandWildCardPath.dwFlags parameter

	/// <summary>
	/// Do not expand the counter name if the path contains a wildcard character for counter name.
	/// </summary>
	public const uint PDH_NOEXPANDCOUNTERS = 1;

	/// <summary>
	/// 	Do not expand the instance name if the path contains a wildcard character for parent instance, instance name, or instance index.
	/// </summary>
	public const uint PDH_NOEXPANDINSTANCES = 2;

	/// <summary>
	/// Refresh the counter list.
	/// </summary>
	public const uint PDH_REFRESHCOUNTERS = 4;

	#endregion

	/// <summary>
	/// Retrieves information about a counter, such as data size, counter type, path, and user-supplied data values.
	/// </summary>
	/// <param name="hCounter">Handle of the counter from which you want to retrieve information. The <see cref="PdhAddCounterW"/> function returns this handle.</param>
	/// <param name="bRetrieveExplainText">Determines whether explain text is retrieved. If you set this parameter to TRUE, the explain text for the counter is retrieved.
	/// If you set this parameter to FALSE, the field in the returned buffer is NULL.</param>
	/// <param name="pdwBufferSize">Size of the lpBuffer buffer, in bytes. If zero on input, the function returns <see cref="PDH_MORE_DATA"/> and sets this parameter to the required buffer size. 
	/// If the buffer is larger than the required size, the function sets this parameter to the actual size of the buffer that was used.
	/// If the specified size on input is greater than zero but less than the required size, you should not rely on the returned size to reallocate the buffer.</param>
	/// <param name="lpBuffer">Caller-allocated buffer that receives a <see cref="PDH_COUNTER_INFO_W"/> structure. The structure is variable-length, because the string data is appended to the end of the fixed-format portion of the structure. This is done so that all data is returned in a single buffer allocated by the caller. Set to NULL if pdwBufferSize is zero.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetcounterinfow</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhGetCounterInfoW(
		[In] nint hCounter,
		[In] bool bRetrieveExplainText,
		[In, Out] uint* pdwBufferSize,
		[Out] PDH_COUNTER_INFO_W* lpBuffer
	);

	/// <summary>
	/// Contains information describing the properties of a counter. This information also includes the counter path.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_counter_info_w</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct PDH_COUNTER_INFO_W
	{
		/// <summary>
		/// Size of the structure, including the appended strings, in bytes.
		/// </summary>
		public uint dwLength;

		/// <summary>
		/// Counter type. For a list of counter types, see the Counter Types section of the Windows Server 2003 Deployment Kit. The counter type constants are defined in Winperf.h.
		/// </summary>
		public uint dwType;

		/// <summary>
		/// Counter version information. Not used.
		/// </summary>
		public uint CVersion;

		/// <summary>
		/// Counter status that indicates if the counter value is valid.
		/// </summary>
		public uint CStatus;

		/// <summary>
		/// Scale factor to use when computing the displayable value of the counter. The scale factor is a power of ten. 
		/// The valid range of this parameter is <see cref="PDH_MIN_SCALE"/> to <see cref="PDH_MAX_SCALE"/> . A value of zero will set the scale to one, so that the actual value is returned.
		/// </summary>
		public int lScale;

		/// <summary>
		/// Default scale factor as suggested by the counter's provider.
		/// </summary>
		public int lDefaultScale;

		/// <summary>
		/// The value passed in the dwUserData parameter when calling <see cref="PdhAddCounterW"/>.
		/// </summary>
		public nuint dwUserData;

		/// <summary>
		/// The value passed in the dwUserData parameter when calling <see cref="PdhOpenQueryW"/>.
		/// </summary>
		public nuint dwQueryUserData;

		/// <summary>
		/// Null-terminated string that specifies the full counter path. The string follows this structure in memory.
		/// </summary>
		public char* szFullPath;

		/// <summary>
		/// A <see cref="PDH_COUNTER_PATH_ELEMENTS_W"/> structure.
		/// </summary>
		public PDH_COUNTER_PATH_ELEMENTS_W CounterPath;

		/// <summary>
		/// Help text that describes the counter. Is NULL if the source is a log file.
		/// </summary>
		public char* szExplainText;
	}

	/// <summary>
	/// Contains the components of a counter path.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_counter_path_elements_w</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct PDH_COUNTER_PATH_ELEMENTS_W
	{
		/// <summary>
		/// Pointer to a null-terminated string that specifies the computer name.
		/// </summary>
		public char* szMachineName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the object name.
		/// </summary>
		public char* szObjectName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the instance name. Can contain a wildcard character.
		/// </summary>
		public char* szInstanceName;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the parent instance name. Can contain a wildcard character.
		/// </summary>
		public char* szParentInstance;

		/// <summary>
		/// Index used to uniquely identify duplicate instance names.
		/// </summary>
		public uint dwInstanceIndex;

		/// <summary>
		/// Pointer to a null-terminated string that specifies the counter name.
		/// </summary>
		public char* szCounterName;
	}

	/// <summary>
	/// Computes a displayable value for the specified counter.
	/// </summary>
	/// <param name="hCounter">Handle of the counter for which you want to compute a displayable value. The <see cref="PdhAddCounterW"/> function returns this handle.</param>
	/// <param name="dwFormat">Determines the data type of the formatted value.</param>
	/// <param name="lpdwType">Receives the counter type. </param>
	/// <param name="pValue">A <see cref="PDH_FMT_COUNTERVALUE"/> structure that receives the counter value.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhgetformattedcountervalue</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhGetFormattedCounterValue(
		[In] nint hCounter,
		[In] uint dwFormat,
		[Out] uint* lpdwType,
		[Out] PDH_FMT_COUNTERVALUE* pValue
	);

	#region Possible values for the PdhGetFormattedCounterValue.dwFormat parameter

	/// <summary>
	/// Return data as a double-precision floating point real.
	/// </summary>
	public const uint PDH_FMT_DOUBLE = 0x00000200;

	/// <summary>
	/// Return data as a 64-bit integer.
	/// </summary>
	public const uint PDH_FMT_LARGE = 0x00000400;

	/// <summary>
	/// Return data as a long integer.
	/// </summary>
	public const uint PDH_FMT_LONG = 0x00000100;

	/// <summary>
	/// Do not apply the counter's default scaling factor.
	/// </summary>
	public const uint PDH_FMT_NOSCALE = 0x00001000;

	/// <summary>
	/// Counter values greater than 100 (for example, counter values measuring the processor load on multiprocessor computers) will not be reset to 100. 
	/// The default behavior is that counter values are capped at a value of 100.
	/// </summary>
	public const uint PDH_FMT_NOCAP100 = 0x00008000;

	/// <summary>
	/// Multiply the actual value by 1,000.
	/// </summary>
	public const uint PDH_FMT_1000 = 0x00002000;

	#endregion

	/// <summary>
	/// Contains the computed value of the counter and its status.
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/ns-pdh-pdh_fmt_countervalue</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct PDH_FMT_COUNTERVALUE
	{
		/// <summary>
		/// Counter status that indicates if the counter value is valid. Check this member before using the data in a calculation or displaying its value.
		/// </summary>
		public uint CStatus;

		/// <summary>
		/// The computed counter value.
		/// </summary>
		public long value;
	}


	/// <summary>
	/// Creates a new query that is used to manage the collection of performance data.
	/// </summary>
	/// <param name="hDataSource">Handle to a data source returned by the <see cref="PdhBindInputDataSourceW"/> function.</param>
	/// <param name="dwUserData">User-defined value to associate with this query. To retrieve the user data later, call <see cref="PdhGetCounterInfoW"/> and access the dwQueryUserData member of <see cref="PDH_COUNTER_INFO_W"/>.</param>
	/// <param name="phQuery">Handle to the query. You use this handle in subsequent calls.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhopenqueryh</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhOpenQueryH(
		[In] nint hDataSource,
		[In] nuint dwUserData,
		[Out] nint* phQuery
	);

	/// <summary>
	/// Creates a new query that is used to manage the collection of performance data.
	/// </summary>
	/// <param name="szDataSource">Null-terminated string that specifies the name of the log file from which to retrieve performance data. If NULL, performance data is collected from a real-time data source.</param>
	/// <param name="dwUserData"></param>
	/// <param name="phQuery">Handle to the query. You use this handle in subsequent calls.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhopenqueryw</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhOpenQueryW(
		[In] char* szDataSource,
		[In] nuint dwUserData,
		[Out] nint* phQuery
	);

	/// <summary>
	/// Removes a counter from a query.
	/// </summary>
	/// <param name="hCounter">Handle of the counter to remove from its query. The <see cref="PdhAddCounterW"/> function returns this handle.</param>
	/// <returns>If the function succeeds, it returns <see cref="ERROR_SUCCESS"/>. If the function fails, the return value is a system error code or a PDH error code.</returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhremovecounter</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhRemoveCounter(
		[In] nint hCounter
	);
}
