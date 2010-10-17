using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom.Compiler;
using System.Reflection;

namespace de.xalax.PluginManager
{
    public static class Extensions
    {

        public static Boolean IsNullOrEmpty<T1>(this IEnumerable<T1> myEnumeration)
        {
            return myEnumeration == null || !myEnumeration.Any();
        }

        public static Boolean IsBaseType(this Type myBaseType, Type myType)
        {
            var curType = myType;
            while (curType != null)
            {
                if (curType.BaseType == myBaseType)
                {
                    return true;
                }
                curType = curType.BaseType;
            }

            return false;
        }

        public static Boolean IsInterfaceOf(this Type myInterfaceType, Type myType)
        {
            return (myInterfaceType.IsAssignableFrom(myType));
        }

        public static String ErrorsToString(this CompilerErrorCollection myCompilerErrorCollection)
        {

            if (myCompilerErrorCollection == null || myCompilerErrorCollection.Count == 0)
            {
                return string.Empty;
            }

            var strBuilder = new StringBuilder();
            strBuilder.AppendLine("Errors(" + myCompilerErrorCollection.Count + "): ");
            foreach (var error in myCompilerErrorCollection)
            {
                strBuilder.AppendLine("["+error.ToString()+"]");
            }

            return strBuilder.ToString();

        }

        public static AssemblyName GetReferencedAssembly(this Assembly myAssembly, String myTargetAssemblyName)
        {

            Stack<Assembly> referencesToCheck      = new Stack<Assembly>();
            HashSet<String> assemblyAlreadyChecked = new HashSet<string>();

            referencesToCheck.Push(myAssembly);

            Assembly curAssembly;
            while (referencesToCheck.Count > 0)
            {
                curAssembly = referencesToCheck.Pop();

                #region Check the ReferencedAssemblies whether thy have the myTargetAssemblyName

                var assembly = curAssembly.GetReferencedAssemblies()
                                    .Where(an => an.Name == myTargetAssemblyName).FirstOrDefault();

                if (assembly != null)
                {
                    return assembly;
                }

                #endregion

                assemblyAlreadyChecked.Add(curAssembly.FullName);

                #region Load all referenced assemblies to check their referenced assemblies as well

                foreach (var refAss in curAssembly.GetReferencedAssemblies())
                {
                    if (!assemblyAlreadyChecked.Contains(refAss.FullName))
                    {
                        Assembly loadedAssembly = null;

                        #region Load the referenced assembly

                        try
                        {
                            loadedAssembly = Assembly.Load(refAss.FullName);
                        }
                        catch (System.IO.FileNotFoundException)
                        {

                            #region Try to load from the same path at the source assembly

                            try
                            {
                                loadedAssembly = Assembly.LoadFrom(new System.IO.DirectoryInfo(curAssembly.Location).Parent.Name + System.IO.Path.DirectorySeparatorChar + refAss.Name + ".dll");
                            }
                            catch { }

                            #endregion

                        }

                        #endregion

                        #region Assembly could not be load, proceed

                        if (loadedAssembly == null)
                        {
                            continue;
                        }

                        #endregion

                        referencesToCheck.Push(loadedAssembly);
                    }
                }

                #endregion

            }

            return null;

        }

    }
}
