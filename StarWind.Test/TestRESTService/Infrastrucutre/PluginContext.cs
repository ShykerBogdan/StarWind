using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http;
using TestCommon;

namespace TestRESTService.Infrastrucutre
{
    public static class PluginContext
    {
        private static IList<Type> s_pluginsList;

        public static IList<Type> S_PluginList
        {
            get
            {
                if (s_pluginsList == null)
                {
                    LoadPluginTypes();
                }

                return s_pluginsList;
            }
        }

        private static void LoadPluginTypes()
        {
            s_pluginsList = (from a in GetAssemblies()
                             from t in a.GetTypes()
                             where t.GetTypeInfo().ImplementedInterfaces.Contains(typeof(IPlugin))
                             select t).ToList();
        }

        public static IPlugin ActivatePlagin(string type)
        {
            var item = S_PluginList.First(x => x.Name.Equals(type));
            return Activator.CreateInstance(item) as IPlugin;
        }

        private static IEnumerable<Assembly> GetAssemblies()
        {
            var assemblies = new List<Assembly>();
            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            foreach (string dll in Directory.GetFiles(path, "Plugins\\*.dll"))
                assemblies.Add(Assembly.LoadFile(dll));

            return assemblies;
        }

        public static IEnumerable<IPlugin> ActivatePlugins(IEnumerable<Type> plugins)
        {
            int count = 0;
            IPlugin result;
            foreach (var item in plugins)
            {
                result = Activator.CreateInstance(item) as IPlugin;
                if (result != null)
                {
                    count++;
                    yield return result;
                }
            }
            if (count == 0)
                throw new ApplicationException(
                    $"Can't find any type which implement");
        }
    }
}

