// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Runtime.InteropServices;

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// P/Invoke items for the Minwinbase.h header
/// </summary>
public static unsafe partial class Minwinbase
{
	/// <summary>
	/// Contains a 64-bit value representing the number of 100-nanosecond intervals since January 1, 1601 (UTC).
	/// </summary>
	/// <remarks>https://learn.microsoft.com/en-us/windows/win32/api/minwinbase/ns-minwinbase-filetime</remarks>
	[StructLayout(LayoutKind.Sequential)]
	public struct FILETIME
	{
		/// <summary>
		/// The low-order part of the file time.
		/// </summary>
		public uint dwLowDateTime;

		/// <summary>
		/// The high-order part of the file time.
		/// </summary>
		public uint dwHighDateTime;
	}
}
