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
            var pm = new PluginManager(Environment.CurrentDirectory + System.IO.Path.DirectorySeparatorChar + "SamplePlugin")
                .Register<ISamplePlugin.ISamplePlugin>(new Version(1, 0), new Version(1, 9))
                    .Discover();

            var plugin = pm.GetPlugins<ISamplePlugin.ISamplePlugin>(p => p.GetType().Name == "SamplePlugin").FirstOrDefault();
            Console.WriteLine(plugin.SampleMethod(1, ""));

            Console.ReadKey();
        }
    }
}
