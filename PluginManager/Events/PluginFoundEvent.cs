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

namespace xalax.PluginManager.Events
{

    #region PluginFoundEvent

    public delegate void PluginFoundEvent(PluginManager myPluginManager, PluginFoundEventArgs myPluginFoundEventArgs);
    public class PluginFoundEventArgs : EventArgs
    {
        public Type PluginType { get; private set; }
        public object PluginInstance { get; private set; }

        public PluginFoundEventArgs(Type myPluginType, object myPluginInstance)
        {
            this.PluginType = myPluginType;
            this.PluginInstance = myPluginInstance;
        }

    }

    #endregion

}
