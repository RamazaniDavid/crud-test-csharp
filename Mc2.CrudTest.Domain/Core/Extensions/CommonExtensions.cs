using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;

namespace Mc2.CrudTest.Core.Extensions
{
    public static class CommonExtensions
    {
        public static List<string> GetAllClassNames(this Type type)
        {
            List<Assembly> list = Directory.GetFiles(AppContext.BaseDirectory, "Mc2.CrudTest.*.dll")
                .Select(dllPath => AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath)).ToList();
            return list.SelectMany(x => x.GetTypes())
                 .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .Select(x => x.FullName).ToList();
        }

        public static List<Type> GetAllClassTypes(this Type type)
        {
            var lista = new List<Assembly>();
            foreach (string dllPath in Directory.GetFiles(AppContext.BaseDirectory, "Mc2.CrudTest.*.dll"))
            {
                var shadowCopiedAssembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(dllPath);
                lista.Add(shadowCopiedAssembly);
            }

            return lista.SelectMany(x => x.GetTypes())
                 .Where(x => type.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
                 .ToList();
        }

    }
}
