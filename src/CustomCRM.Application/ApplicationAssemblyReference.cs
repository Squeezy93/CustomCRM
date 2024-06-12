using System.Reflection;

namespace CustomCRM.Application
{
    public sealed class ApplicationAssemblyReference
    {
        internal static readonly Assembly Assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}