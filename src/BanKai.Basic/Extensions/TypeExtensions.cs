using System;
using System.Reflection;

namespace BanKai.Basic.Extensions
{
    internal static class TypeExtensions
    {
        public static bool HasDefaultConstructor(this object instance)
        {
            if (instance == null)
            {
                return false;
            }

            Type type = instance.GetType();

            const BindingFlags bindingFlags = 
                BindingFlags.CreateInstance | 
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic;

            ConstructorInfo constructorInfo = type.GetConstructor(
                bindingFlags,
                null,
                CallingConventions.Any,
                new Type[0],
                new ParameterModifier[0]);

            return constructorInfo != null;
        }
    }
}