using System;
using System.Collections.Generic;
using System.Reflection;

namespace ReflectionTraining
{
    class TypeFinder
    {
        static GetDictionary fielddictionary = new GetDictionary();

        public static string FindTypeforField(FieldInfo type)
        {
            string gettype = type.FieldType.FullName;

            if (type.FieldType.IsGenericType)
            {
                var typedefinition = type.FieldType.GetGenericTypeDefinition();

                if (typedefinition.BaseType.IsAssignableFrom(typeof(IEnumerable<>)))
                {
                    if (type.FieldType.GetGenericArguments().Length >= 2)
                    {
                        //Dictionary.
                        return "array&" + fielddictionary.typelist[type.FieldType.GetGenericArguments()[0].ToString()] + "&" + fielddictionary.typelist[type.FieldType.GetGenericArguments()[1].ToString()];
                    }
                    else
                    {
                        //List types.
                        return "array&single&" + fielddictionary.typelist[type.FieldType.GetGenericArguments()[0].ToString()];
                    }
                }
                else
                {
                    //Nullable.
                    Type nullabletype = Nullable.GetUnderlyingType(type.FieldType);
                    gettype = nullabletype.ToString();
                    return fielddictionary.typelist[gettype];
                }
            }
            else
            {
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
        }

        public static string FindTypeforProperty(PropertyInfo type)
        {
            string gettype = type.PropertyType.FullName;

            return fielddictionary.typelist[gettype];
        }
    }
}
