using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using Xunit;

namespace BanKai.TypeAndMember
{
    public class AssemblyFact
    {
        [Fact]
        public void an_assembly_has_name_version_and_culture()
        {
            // If you do not know where to find these information, please see AssemblyInfo.cs
            string name = string.Empty;
            string version = string.Empty;
            CultureInfo culture = null;

            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName assemblyName = assembly.GetName();
            Assert.Equal(assemblyName.Name, name);
            Assert.Equal(assemblyName.Version, Version.Parse(version));
            Assert.Equal(assemblyName.CultureInfo, culture);
        }

        [Fact]
        public void an_assembly_clearly_indicates_its_dependency()
        {
            // currently, the xunit assembly has been loaded. so ...
            string oneOfItsReferenceNames = string.Empty;
            Assembly assembly = Assembly.GetExecutingAssembly();
            AssemblyName[] referencedAssemblies = assembly.GetReferencedAssemblies();
            string[] referencedAssemblyNames = referencedAssemblies.Select(a => a.Name).ToArray();

            Assert.Contains(oneOfItsReferenceNames, referencedAssemblyNames);
        }
    }
}