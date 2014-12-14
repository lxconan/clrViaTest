using System.CodeDom.Compiler;

namespace BanKai.Basic.Extensions
{
    internal static class SimpleCSharpCompiler
    {
        public static CompilerResults CompileWithoutRun(string shortProgram)
        {
            CodeDomProvider csharpCodeProvider = CodeDomProvider.CreateProvider("CSharp");
            var compilerParameters = new CompilerParameters
            {
                GenerateInMemory = true,
                TreatWarningsAsErrors = false
            };

            CompilerResults compilerResults =
                csharpCodeProvider.CompileAssemblyFromSource(compilerParameters, shortProgram);
            return compilerResults;
        }
    }
}