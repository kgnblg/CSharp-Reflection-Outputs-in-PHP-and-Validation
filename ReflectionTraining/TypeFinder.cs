using System;
using System.Reflection;

namespace ReflectionTraining
{
    class TypeFinder
    {
        static GetDictionary fielddictionary = new GetDictionary();

        public static string FindTypeforField(FieldInfo type)
        {
            string gettype = type.FieldType.FullName;

            if(gettype.IndexOf("Nullable") != -1)
            {
                Type nullabletype = Nullable.GetUnderlyingType(type.FieldType);
                gettype = nullabletype.ToString();
            }

            if (type.FieldType.BaseType.FullName == "System.Enum")
            {
                return "integer&enum&" + gettype.Replace('.', '\\'); ;
            }

            if (type.FieldType.BaseType.FullName != "System.Enum" && gettype.IndexOf("System") == -1)
            {
                if (gettype.IndexOf("[]") != -1)
                {
                    return "array&" + gettype.Replace('.', '\\');
                }
                else
                {
                    return gettype.Replace('.', '\\');
                }
                
            }

            return fielddictionary.typelist[gettype];
        }

        public static string FindTypeforProperty(PropertyInfo type)
        {
            string gettype = type.PropertyType.FullName;

            return fielddictionary.typelist[gettype];
        }
    }
}
