using System;
using System.Reflection;

namespace ReflectionTraining
{
    class AssemblyFile
    {
        string importfile { get; set; }
        public AssemblyFile(string importfile)
        {
            this.importfile = importfile;
        }

        public Type [] GetFile()
        {
            var assembly = Assembly.LoadFile(importfile);
            var types = assembly.GetTypes();
            return types;
        }
    }
}
