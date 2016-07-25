using System;
using System.Reflection;

namespace ReflectionTraining
{
    class TypeFinder
    {
        public static string FindType(FieldInfo type)
        {
            string gettype = type.FieldType.FullName;

            if (CorrectString.SplitIt(gettype,'.',0) == "System")
            {
                string typevalue = CorrectString.SplitIt(gettype, '.', 1);
                string returnback;

                if (typevalue.IndexOf("Nullable") != -1)
                {
                    Type nullabletype = Nullable.GetUnderlyingType(type.FieldType);

                    typevalue = CorrectString.SplitIt(nullabletype.ToString(), '.', 1);
                }

                if (typevalue.IndexOf("Int") != -1 || typevalue.IndexOf("Decimal") != -1)
                {
                    returnback = "integer";
                }
                else
                {
                    returnback = typevalue.ToLower();
                }

                if (returnback.IndexOf("[]") != -1)
                {
                    return "array`" + returnback.Remove('[').Remove(']');
                }

                return returnback;
            }
            else
            {
                string returnback = gettype.ToString().Replace('.','\\');

                if (returnback.IndexOf("[]") != -1)
                {
                    return "array`" + returnback.Remove('[').Remove(']'); ;
                }

                return returnback;
            }
        }
    }
}
