using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using de.xalax.PluginManager;

namespace de.xalax.PluginManager.SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 100; i++)
            {
                var pm = new PluginManager(Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + "references")
                    .Register<ISamplePlugin.ISamplePlugin>(new Version(1, 0), new Version(2, 9))
                        .Discover();

                var plugin = pm.GetPlugins<ISamplePlugin.ISamplePlugin>(p => p.GetType().Name == "SamplePlugin").FirstOrDefault();
                Console.WriteLine(plugin.SampleMethod(0, ""));
            }

            Console.ReadKey();
        }
    }
}
