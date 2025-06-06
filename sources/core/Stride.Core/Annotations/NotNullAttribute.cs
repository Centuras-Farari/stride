// Copyright (c) .NET Foundation and Contributors (https://dotnetfoundation.org/ & https://stride3d.net) and Silicon Studio Corp. (https://www.siliconstudio.co.jp)
// Distributed under the MIT license. See the LICENSE.md file in the project root for more information.

namespace Stride.Core.Annotations;

/// <summary>
/// Indicates that the value of the marked element could never be <c>null</c>.
/// </summary>
/// <example>
/// <code>
/// [NotNull] object Foo() {
///   return null; // Warning: Possible 'null' assignment
/// }
/// </code>
/// </example>
[AttributeUsage(
     AttributeTargets.Method | AttributeTargets.Parameter | AttributeTargets.Property |
     AttributeTargets.Delegate | AttributeTargets.Field | AttributeTargets.Event |
     AttributeTargets.Class | AttributeTargets.Interface | AttributeTargets.GenericParameter)]
// [Obsolete("Consider using the built-in nullable feature")]
public sealed class NotNullAttribute : Attribute;
