using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace IceBlinkCore
{
    public class AssemblyObjects
    {
        private string assemblyFileName = "";
        private Assembly assemblyCompiled;

        public string AssemblyFileName
        {
            get { return assemblyFileName; }
            set { assemblyFileName = value; }
        }
        public Assembly AssemblyCompiled
        {
            get { return assemblyCompiled; }
            set { assemblyCompiled = value; }
        }

        public AssemblyObjects()
        {
        }
    }
}
