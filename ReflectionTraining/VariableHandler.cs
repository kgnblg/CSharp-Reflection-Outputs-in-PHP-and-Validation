using CSharpReflection;

namespace ReflectionTraining
{
    class VariableHandler
    {
        Elements elements;

        public VariableHandler(Elements elements)
        {
            this.elements = elements;
        }

        public void VariablePusher()
        {
            Class classhandler = new Class(elements.classList);
            classhandler.PrintClassBody();
            classhandler.CreateModelClass();

            Structs structhandler = new Structs(elements.structList);
            structhandler.PrintStructBody();

            Enum enumhandler = new Enum(elements.enumList);
            enumhandler.PrintEnumBody();
        }
    }
}
