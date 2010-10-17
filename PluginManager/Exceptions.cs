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

namespace xalax.PluginManager.Exceptions
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
