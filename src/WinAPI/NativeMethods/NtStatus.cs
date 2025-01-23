// Copyright © Anton Larin, 2024-2025. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace LarinLive.WinAPI.NativeMethods;

/// <summary>
/// Windows System Error codes
/// </summary>
/// <remarks>https://learn.microsoft.com/en-us/openspecs/windows_protocols/ms-erref/596a1078-e883-4972-9bbc-49e60bebca55</remarks>
public static class NtStatus
{
	/// <summary>
	/// The operation completed successfully.
	/// </summary>
	public const uint STATUS_WAIT_0 = 0x00000000;

	/// <summary>
	/// The caller attempted to wait for a mutex that has been abandoned.
	/// </summary>
	public const uint STATUS_ABANDONED_WAIT_0 = 0x00000080;

	/// <summary>
	/// The delay completed because the thread was alerted.
	/// </summary>
	public const uint STATUS_ALERTED = 0x00000101;

	/// <summary>
	/// The given Timeout interval expired.
	/// </summary>
	public const uint STATUS_TIMEOUT = 0x00000102;

	/// <summary>
	/// The operation that was requested is pending completion.
	/// </summary>
	public const uint STATUS_PENDING = 0x00000103;
}
