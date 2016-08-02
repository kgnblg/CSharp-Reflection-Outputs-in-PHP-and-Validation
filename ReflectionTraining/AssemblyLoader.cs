using System;

namespace ReflectionTraining
{
    class AssemblyLoader
    {
        static void Main(string[] args)
        {
            AssemblyFile assemblyfile = new AssemblyFile("C:/Users/KGN/Documents/Visual Studio 2015/Projects/ReflectionOrnekClass/ReflectionOrnekClass/bin/Debug/ReflectionOrnekClass.dll");
            var classtypes = assemblyfile.GetFile();

            Class classes = new Class(classtypes);
            classes.CreateModelClass();
            classes.PrintIt();

            Enum enums = new Enum(classtypes);
            enums.PrintIt();

            Structs structs = new Structs(classtypes);
            structs.PrintIt();

            Console.ReadKey();
        }
    }
}
