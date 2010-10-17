using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.xalax.PluginManager.Events
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

        #endregion

        public PluginIncompatibleVersionEventArgs(Version myPluginVersion, Version myMinVersion, Version myMaxVersion, Type myPluginType)
        {
            this.PluginVersion = myPluginVersion;
            this.MinVersion = myMinVersion;
            this.MaxVersion = myMaxVersion;
            this.PluginType = myPluginType;
        }

    }

    #endregion
    
}
