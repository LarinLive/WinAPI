// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;

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
	/// <param name="dwFlags"></param>
	/// <returns>If the function succeeds, it returns ERROR_SUCCESS and closes and deletes the query. If the function fails, the return value is a system error code or a PDH error code. </returns>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/pdh/nf-pdh-pdhcloselog</remarks>
	[DllImport(PdhLib, CharSet = CharSet.Unicode, SetLastError = true)]
	public static extern uint PdhCloseLog(
		[In] nint hLog,
		[In] uint dwFlags
	);
}
