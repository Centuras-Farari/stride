// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

using System.Diagnostics;
using System.Reflection;

namespace Stride.Core;

/// <summary>
/// Platform specific queries and functions.
/// </summary>
public static class Platform
{
#if STRIDE_PLATFORM_UWP
    /// <summary>
    /// The current running <see cref="PlatformType"/>.
    /// </summary>
    public const PlatformType Type = PlatformType.UWP;
#else
    /// <summary>
    /// The current running <see cref="PlatformType"/>.
    /// </summary>
    public static readonly PlatformType Type
        = OperatingSystem.IsWindows() ? PlatformType.Windows
        : OperatingSystem.IsLinux()  ? PlatformType.Linux
        : OperatingSystem.IsMacOS() ? PlatformType.macOS
        : OperatingSystem.IsAndroid() ? PlatformType.Android
        : OperatingSystem.IsIOS() ? PlatformType.iOS
        : PlatformType.Windows; // For now we use Windows as fallback, but it might be better to throw an exception?
#endif

    /// <summary>
    /// Gets a value indicating whether the running platform is windows desktop.
    /// </summary>
    /// <value><c>true</c> if this instance is windows desktop; otherwise, <c>false</c>.</value>
    public static readonly bool IsWindowsDesktop = Type == PlatformType.Windows;

    /// <summary>
    /// Gets a value indicating whether the running assembly is a debug assembly.
    /// </summary>
    public static readonly bool IsRunningDebugAssembly = GetIsRunningDebugAssembly();

    /// <summary>
    /// Check if running assembly has the DebuggableAttribute set with the `DisableOptimizations` mode enabled.
    /// This function is called only once.
    /// </summary>
    private static bool GetIsRunningDebugAssembly()
    {
        var entryAssembly = Assembly.GetEntryAssembly();
        if (entryAssembly != null)
        {
            var debuggableAttribute = entryAssembly.GetCustomAttributes<DebuggableAttribute>().FirstOrDefault();
            if (debuggableAttribute != null)
            {
                return (debuggableAttribute.DebuggingFlags & DebuggableAttribute.DebuggingModes.DisableOptimizations) != 0;
            }
        }
        return false;
    }
}
