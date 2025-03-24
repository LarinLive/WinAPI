// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace LarinLive.WinAPI.NativeMethods;

public static partial class ErrorCodes
{
	/// <summary>
	/// The returned data is valid.
	/// </summary>
	public const uint PDH_CSTATUS_VALID_DATA = 0x00000000;

	/// <summary>
	/// The return data value is valid and different from the last sample.
	/// </summary>
	public const uint PDH_CSTATUS_NEW_DATA = 0x00000001;

	/// <summary>
	/// Unable to connect to the specified computer, or the computer is offline.
	/// </summary>
	public const uint PDH_CSTATUS_NO_MACHINE = 0x800007D0;

	/// <summary>
	/// The specified instance is not present.
	/// </summary>
	public const uint PDH_CSTATUS_NO_INSTANCE = 0x800007D1;

	/// <summary>
	/// There is more data to return than would fit in the supplied buffer. Allocate a larger buffer and call the function again.
	/// </summary>
	public const uint PDH_MORE_DATA = 0x800007D2;

	/// <summary>
	/// The data item has been added to the query but has not been validated nor accessed. No other status information on this data item is available.
	/// </summary>
	public const uint PDH_CSTATUS_ITEM_NOT_VALIDATED = 0x800007D3;

	/// <summary>
	///	The selected operation should be retried.
	/// </summary>
	public const uint PDH_RETRY = 0x800007D4;

	/// <summary>
	/// No data to return.
	/// </summary>
	public const uint PDH_NO_DATA = 0x800007D5;

	/// <summary>
	/// A counter with a negative denominator value was detected.
	/// </summary>
	public const uint PDH_CALC_NEGATIVE_DENOMINATOR = 0x800007D6;

	/// <summary>
	///	A counter with a negative time base value was detected.
	/// </summary>
	public const uint PDH_CALC_NEGATIVE_TIMEBASE = 0x800007D7;

	/// <summary>
	/// A counter with a negative value was detected.
	/// </summary>
	public const uint PDH_CALC_NEGATIVE_VALUE = 0x800007D8;

	/// <summary>
	/// The user canceled the dialog box.
	/// </summary>
	public const uint PDH_DIALOG_CANCELLED = 0x800007D9;

	/// <summary>
	/// The end of the log file was reached.
	/// </summary>
	public const uint PDH_END_OF_LOG_FILE = 0x800007DA;

	/// <summary>
	///	A time-out occurred while waiting for the asynchronous counter collection thread to end.
	/// </summary>
	public const uint PDH_ASYNC_QUERY_TIMEOUT = 0x800007DB;

	/// <summary>
	/// Cannot change set default real-time data source. There are real-time query sessions collecting counter data.
	/// </summary>
	public const uint PDH_CANNOT_SET_DEFAULT_REALTIME_DATASOURCE = 0x800007DC;

	/// <summary>
	/// The specified object is not found on the system.
	/// </summary>
	public const uint PDH_CSTATUS_NO_OBJECT = 0xC0000BB8;

	/// <summary>
	/// The specified counter could not be found.
	/// </summary>
	public const uint PDH_CSTATUS_NO_COUNTER = 0xC0000BB9;

	/// <summary>
	/// The returned data is not valid.
	/// </summary>
	public const uint PDH_CSTATUS_INVALID_DATA = 0xC0000BBA;

	/// <summary>
	///	A PDH function could not allocate enough temporary memory to complete the operation. Close some applications or extend the page file and retry the function.
	/// </summary>
	public const uint PDH_MEMORY_ALLOCATION_FAILURE = 0xC0000BBB;

	/// <summary>
	/// The handle is not a valid PDH object.
	/// </summary>
	public const uint PDH_INVALID_HANDLE = 0xC0000BBC;

	/// <summary>
	/// A required argument is missing or incorrect.
	/// </summary>
	public const uint PDH_INVALID_ARGUMENT = 0xC0000BBD;

	/// <summary>
	/// Unable to find the specified function.
	/// </summary>
	public const uint PDH_FUNCTION_NOT_FOUND = 0xC0000BBE;

	/// <summary>
	/// No counter was specified.
	/// </summary>
	public const uint PDH_CSTATUS_NO_COUNTERNAME = 0xC0000BBF;

	/// <summary>
	/// Unable to parse the counter path. Check the format and syntax of the specified path.
	/// </summary>
	public const uint PDH_CSTATUS_BAD_COUNTERNAME = 0xC0000BC0;

	/// <summary>
	/// The buffer passed by the caller is not valid.
	/// </summary>
	public const uint PDH_INVALID_BUFFER = 0xC0000BC1;

	/// <summary>
	/// The requested data is larger than the buffer supplied. Unable to return the requested data.
	/// </summary>
	public const uint PDH_INSUFFICIENT_BUFFER = 0xC0000BC2;

	/// <summary>
	/// Unable to connect to the requested computer.
	/// </summary>
	public const uint PDH_CANNOT_CONNECT_MACHINE = 0xC0000BC3;

	/// <summary>
	/// The specified counter path could not be interpreted.
	/// </summary>
	public const uint PDH_INVALID_PATH = 0xC0000BC4;

	/// <summary>
	/// The instance name could not be read from the specified counter path.
	/// </summary>
	public const uint PDH_INVALID_INSTANCE = 0xC0000BC5;

	/// <summary>
	/// The data is not valid.
	/// </summary>
	public const uint PDH_INVALID_DATA = 0xC0000BC6;

	/// <summary>
	/// The dialog box data block was missing or not valid.
	/// </summary>
	public const uint PDH_NO_DIALOG_DATA = 0xC0000BC7;

	/// <summary>
	/// Unable to read the counter and/or help text from the specified computer.
	/// </summary>
	public const uint PDH_CANNOT_READ_NAME_STRINGS = 0xC0000BC8;

	/// <summary>
	/// Unable to create the specified log file.
	/// </summary>
	public const uint PDH_LOG_FILE_CREATE_ERROR = 0xC0000BC9;

	/// <summary>
	/// Unable to open the specified log file.
	/// </summary>
	public const uint PDH_LOG_FILE_OPEN_ERROR = 0xC0000BCA;

	/// <summary>
	/// The specified log file type has not been installed on this system.
	/// </summary>
	public const uint PDH_LOG_TYPE_NOT_FOUND = 0xC0000BCB;

	/// <summary>
	/// No more data is available.
	/// </summary>
	public const uint PDH_NO_MORE_DATA = 0xC0000BCC;

	/// <summary>
	/// The specified record was not found in the log file.
	/// </summary>
	public const uint PDH_ENTRY_NOT_IN_LOG_FILE = 0xC0000BCD;

	/// <summary>
	/// The specified data source is a log file.
	/// </summary>
	public const uint PDH_DATA_SOURCE_IS_LOG_FILE = 0xC0000BCE;

	/// <summary>
	/// The specified data source is the current activity.
	/// </summary>
	public const uint PDH_DATA_SOURCE_IS_REAL_TIME = 0xC0000BCF;

	/// <summary>
	/// The log file header could not be read.
	/// </summary>
	public const uint PDH_UNABLE_READ_LOG_HEADER = 0xC0000BD0;

	/// <summary>
	///	Unable to find the specified file.
	/// </summary>
	public const uint PDH_FILE_NOT_FOUND = 0xC0000BD1;

	/// <summary>
	/// There is already a file with the specified file name.
	/// </summary>
	public const uint PDH_FILE_ALREADY_EXISTS = 0xC0000BD2;

	/// <summary>
	/// The function referenced has not been implemented.
	/// </summary>
	public const uint PDH_NOT_IMPLEMENTED = 0xC0000BD3;

	/// <summary>
	/// Unable to find the specified string in the list of performance name and help text strings.
	/// </summary>
	public const uint PDH_STRING_NOT_FOUND = 0xC0000BD4;

	/// <summary>
	/// Unable to map to the performance counter name data files. The data will be read from the registry and stored locally.
	/// </summary>
	public const uint PDH_UNABLE_MAP_NAME_FILES = 0x80000BD5;

	/// <summary>
	///	The format of the specified log file is not recognized by the PDH DLL.
	/// </summary>
	public const uint PDH_UNKNOWN_LOG_FORMAT = 0xC0000BD6;

	/// <summary>
	/// The specified Log Service command value is not recognized.
	/// </summary>
	public const uint PDH_UNKNOWN_LOGSVC_COMMAND = 0xC0000BD7;

	/// <summary>
	/// The specified query from the Log Service could not be found or could not be opened.
	/// </summary>
	public const uint PDH_LOGSVC_QUERY_NOT_FOUND = 0xC0000BD8;

	/// <summary>
	/// The Performance Data Log Service key could not be opened. This may be due to insufficient privilege or because the service has not been installed.
	/// </summary>
	public const uint PDH_LOGSVC_NOT_OPENED = 0xC0000BD9;

	/// <summary>
	/// An error occurred while accessing the WBEM data store.
	/// </summary>
	public const uint PDH_WBEM_ERROR = 0xC0000BDA;

	/// <summary>
	/// Unable to access the desired computer or service. Check the permissions and authentication of the log service or the interactive user session against those on the computer or service being monitored.
	/// </summary>
	public const uint PDH_ACCESS_DENIED = 0xC0000BDB;

	/// <summary>
	/// The maximum log file size specified is too small to log the selected counters. No data will be recorded in this log file. Specify a smaller set of counters to log or a larger file size and retry this call.
	/// </summary>
	public const uint PDH_LOG_FILE_TOO_SMALL = 0xC0000BDC;

	/// <summary>
	/// Cannot connect to ODBC DataSource Name.
	/// </summary>
	public const uint PDH_INVALID_DATASOURCE = 0xC0000BDD;

	/// <summary>
	/// SQL Database does not contain a valid set of tables for Perfmon.
	/// </summary>
	public const uint PDH_INVALID_SQLDB = 0xC0000BDE;

	/// <summary>
	/// No counters were found for this Perfmon SQL Log Set.
	/// </summary>
	public const uint PDH_NO_COUNTERS = 0xC0000BDF;

	/// <summary>
	/// Call to SQLAllocStmt failed with %1.
	/// </summary>
	public const uint PDH_SQL_ALLOC_FAILED = 0xC0000BE0;

	/// <summary>
	/// Call to SQLAllocConnect failed with %1.
	/// </summary>
	public const uint PDH_SQL_ALLOCCON_FAILED = 0xC0000BE1;

	/// <summary>
	/// Call to SQLExecDirect failed with %1.
	/// </summary>
	public const uint PDH_SQL_EXEC_DIRECT_FAILED = 0xC0000BE2;

	/// <summary>
	/// Call to SQLFetch failed with %1.
	/// </summary>
	public const uint PDH_SQL_FETCH_FAILED = 0xC0000BE3;

	/// <summary>
	/// Call to SQLRowCount failed with %1.
	/// </summary>
	public const uint PDH_SQL_ROWCOUNT_FAILED = 0xC0000BE4;

	/// <summary>
	///	Call to SQLMoreResults failed with %1.
	/// </summary>
	public const uint PDH_SQL_MORE_RESULTS_FAILED = 0xC0000BE5;

	/// <summary>
	/// Call to SQLConnect failed with %1.
	/// </summary>
	public const uint PDH_SQL_CONNECT_FAILED = 0xC0000BE6;

	/// <summary>
	///	Call to SQLBindCol failed with %1.
	/// </summary>
	public const uint PDH_SQL_BIND_FAILED = 0xC0000BE7;

	/// <summary>
	/// Unable to connect to the WMI server on requested computer.
	/// </summary>
	public const uint PDH_CANNOT_CONNECT_WMI_SERVER = 0xC0000BE8;

	/// <summary>
	/// Collection "%1!s!" is already running.
	/// </summary>
	public const uint PDH_PLA_COLLECTION_ALREADY_RUNNING = 0xC0000BE9;

	/// <summary>
	/// The specified start time is after the end time.
	/// </summary>
	public const uint PDH_PLA_ERROR_SCHEDULE_OVERLAP = 0xC0000BEA;

	/// <summary>
	/// Collection "%1!s!" does not exist.
	/// </summary>
	public const uint PDH_PLA_COLLECTION_NOT_FOUND = 0xC0000BEB;

	/// <summary>
	/// The specified end time has already elapsed.
	/// </summary>
	public const uint PDH_PLA_ERROR_SCHEDULE_ELAPSED = 0xC0000BEC;

	/// <summary>
	/// Collection "%1!s!" did not start; check the application event log for any errors.
	/// </summary>
	public const uint PDH_PLA_ERROR_NOSTART = 0xC0000BED;

	/// <summary>
	///	Collection "%1!s!" already exists.
	/// </summary>
	public const uint PDH_PLA_ERROR_ALREADY_EXISTS = 0xC0000BEE;

	/// <summary>
	/// There is a mismatch in the settings type.
	/// </summary>
	public const uint PDH_PLA_ERROR_TYPE_MISMATCH = 0xC0000BEF;

	/// <summary>
	/// The information specified does not resolve to a valid path name.
	/// </summary>
	public const uint PDH_PLA_ERROR_FILEPATH = 0xC0000BF0;

	/// <summary>
	/// The "Performance Logs and Alerts" service did not respond.
	/// </summary>
	public const uint PDH_PLA_SERVICE_ERROR = 0xC0000BF1;

	/// <summary>
	/// The information passed is not valid.
	/// </summary>
	public const uint PDH_PLA_VALIDATION_ERROR = 0xC0000BF2;

	/// <summary>
	///	The information passed is not valid.
	/// </summary>
	public const uint PDH_PLA_VALIDATION_WARNING = 0x80000BF3;

	/// <summary>
	/// The name supplied is too long.
	/// </summary>
	public const uint PDH_PLA_ERROR_NAME_TOO_LONG = 0xC0000BF4;

	/// <summary>
	/// SQL log format is incorrect. Correct format is SQL:DSN-name!LogSet-Name.
	/// </summary>
	public const uint PDH_INVALID_SQL_LOG_FORMAT = 0xC0000BF5;

	/// <summary>
	/// Performance counter in <see cref="PdhAddCounterW"/> call has already been added in the performance query. This counter is ignored.
	/// </summary>
	public const uint PDH_COUNTER_ALREADY_IN_QUERY = 0xC0000BF6;

	/// <summary>
	/// Unable to read counter information and data from input binary log files.
	/// </summary>
	public const uint PDH_BINARY_LOG_CORRUPT = 0xC0000BF7;

	/// <summary>
	/// At least one of the input binary log files contain fewer than two data samples.
	/// </summary>
	public const uint PDH_LOG_SAMPLE_TOO_SMALL = 0xC0000BF8;

	/// <summary>
	/// The version of the operating system on the computer named %1 is later than that on the local computer. This operation is not available from the local computer.
	/// </summary>
	public const uint PDH_OS_LATER_VERSION = 0xC0000BF9;

	/// <summary>
	///	%1 supports %2 or later. Check the operating system version on the computer named %3.
	/// </summary>
	public const uint PDH_OS_EARLIER_VERSION = 0xC0000BFA;

	/// <summary>
	/// The output file must contain earlier data than the file to be appended.
	/// </summary>
	public const uint PDH_INCORRECT_APPEND_TIME = 0xC0000BFB;

	/// <summary>
	/// Both files must have identical counters in order to append.
	/// </summary>
	public const uint PDH_UNMATCHED_APPEND_COUNTER = 0xC0000BFC;

	/// <summary>
	/// Cannot alter CounterDetail table layout in SQL database.
	/// </summary>
	public const uint PDH_SQL_ALTER_DETAIL_FAILED = 0xC0000BFD;

	/// <summary>
	///	System is busy. A time-out occurred when collecting counter data. Please retry later or increase the CollectTime registry value. 
	/// </summary>
	public const uint PDH_QUERY_PERF_DATA_TIMEOUT = 0xC0000BFE;
}
