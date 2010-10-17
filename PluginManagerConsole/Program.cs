/*
* VersionedPluginManager
* http://github.com/xalax/VersionedPluginManager
*
* Copyright (c) 2010 Stefan Licht
*
* Licensed under the MIT License. You may not use this file except
* in compliance with the License. You may obtain a copy of the License at
*
* http://www.opensource.org/licenses/mit-license.php
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xalax.PluginManager;

namespace xalax.PluginManager.SampleConsole
{
    class Program
    {
        static void Main(string[] args)
        {


            #region Discover succeed due to a compatible version

            Console.WriteLine("Discover all ISamplePlugin plugins with version > 1.0 and version < 1.9.3 ...");
            
            var pm = new PluginManager(Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + "SamplePlugin")
                .Register<ISamplePlugin.ISamplePlugin>(new Version(1, 0), new Version(1, 9, 3))
                    .Discover();

            var plugin = pm.GetPlugins<ISamplePlugin.ISamplePlugin>(p => p.GetType().Name == "SamplePlugin").FirstOrDefault();
            Console.WriteLine("Succeeded for: " + plugin.SampleMethod(1, ""));
            
            #endregion

            #region Discovering fail due to an incompatible version

            Console.WriteLine("");
            Console.WriteLine("Discover all ISamplePlugin plugins with version > 1.0 and version < 1.8 ...");

            pm = new PluginManager(Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + "SamplePlugin")
                .Register<ISamplePlugin.ISamplePlugin>(new Version(1, 0), new Version(1, 8));
            
            pm.OnPluginIncompatibleVersion += (sender, e) =>
            {
                Console.WriteLine("Failed: [{0}] is not between [{1}] and [{2}]", e.PluginVersion, e.MinVersion, e.MaxVersion);
            };
            pm.Discover(false); // do not throw an axception

            #endregion

            Console.ReadKey();
        }
    }
}
