using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.xalax.PluginManager.Exceptions
{

    #region PluginManagerException

    public class PluginManagerException : Exception
    {

        public PluginManagerException()
            : base()
        { }

        public PluginManagerException(string myMessage)
            : base(myMessage)
        { }

        public PluginManagerException(string myMessage, Exception myInnerException)
            : base(myMessage, myInnerException)
        { }

    }
    
    #endregion

    #region PluginActivatorException

    public class PluginActivatorException : PluginManagerException
    {

        public PluginActivatorException()
            : base()
        { }

        public PluginActivatorException(string myMessage)
            : base(myMessage)
        { }

        public PluginActivatorException(string myMessage, Exception myInnerException)
            : base(myMessage, myInnerException)
        { }

    }
    
    #endregion

    #region IncompatiblePluginVersion

    public class IncompatiblePluginVersionException : PluginActivatorException
    {

        public IncompatiblePluginVersionException(Version myCurrentVersion, Version myMinVersion)
            : base(String.Format("The plugin version '{0}' is lower than the minimum supported version '{1}'", myCurrentVersion, myMinVersion))
        {

        }

        public IncompatiblePluginVersionException(Version myCurrentVersion, Version myMinVersion, Version myMaxVersion)
            : base(String.Format("The plugin version '{0}' is not a supported version. Minimum version is '{1}' and maximum version is '{2}'", myCurrentVersion, myMinVersion, myMaxVersion))
        {

        }

    }

    #endregion

}
