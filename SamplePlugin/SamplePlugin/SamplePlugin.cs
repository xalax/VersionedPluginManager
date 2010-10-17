using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace de.xalax.SamplePlugin
{
    public class SamplePlugin : ISamplePlugin.ISamplePlugin
    {
        #region ISamplePlugin Members

        public string SampleMethod(int param1, string param2)
        {
            return System.Reflection.Assembly.GetAssembly(typeof(SamplePlugin)).GetName().Name;
        }

        #endregion
    }
}
