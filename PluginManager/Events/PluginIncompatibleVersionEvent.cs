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
using System.Reflection;

namespace xalax.PluginManager.Events
{

    #region PluginIncompatibleVersionEvent

    public delegate void PluginIncompatibleVersionEvent(PluginManager myPluginManager, PluginIncompatibleVersionEventArgs myPluginIncompatibleVersionEventArgs);
    public class PluginIncompatibleVersionEventArgs : EventArgs
    {

        #region Properties

        public Version PluginVersion { get; private set; }
        public Version MinVersion { get; private set; }
        public Version MaxVersion { get; private set; }
        public Type PluginType { get; private set; }
        public Assembly PluginAssembly { get; private set; }

        #endregion

        public PluginIncompatibleVersionEventArgs(Assembly myPluginAssembly, Version myPluginVersion, Version myMinVersion, Version myMaxVersion, Type myPluginType)
        {
            this.PluginVersion = myPluginVersion;
            this.MinVersion = myMinVersion;
            this.MaxVersion = myMaxVersion;
            this.PluginType = myPluginType;
            this.PluginAssembly = myPluginAssembly;
        }

    }

    #endregion
    
}
