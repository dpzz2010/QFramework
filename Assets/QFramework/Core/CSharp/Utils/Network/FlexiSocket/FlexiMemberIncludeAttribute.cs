
namespace QFramework
{
    using System;

    /// <summary>
    /// Attributed non-public members will be serialized
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public sealed class FlexiMemberIncludeAttribute : Attribute
    {

    }
}