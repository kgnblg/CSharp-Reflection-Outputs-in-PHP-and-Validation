using System;
using CSharpReflection;

namespace ReflectionTraining
{
    class ArrayHandler
    {
        static void Main(string[] args)
        {
            AssemblyReader assemblyReader = new AssemblyReader("C:/Paximum.Content.Messages.dll");
            TypeHandler typehandler = new TypeHandler(assemblyReader.GetAssembly());
            Elements elements = typehandler.TypeSender();

            VariableHandler variablehandler = new VariableHandler(elements);
            variablehandler.VariablePusher();

            Console.ReadKey();
        }
    }
}
