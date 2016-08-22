using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTraining
{
    class TypeHandler
    {
        public Type type;
        static GetDictionary dictionary = new GetDictionary();

        public TypeHandler(Type type)
        {
            this.type = type;
        }

        public string Finder()
        {
            if (type.IsPrimitive || type == typeof(string))
            {
                return dictionary.typelist[type.FullName];
            }

            if (type.IsEnum)
            {
                return "integer&enum&" + type.FullName.Replace('.', '\\');
            }

            if (type.IsArray && !type.IsGenericType)
            {
                return dictionary.typelist[type.FullName];
            }

            if (type.IsGenericType)
            {
                var typedefinition = type.GetGenericTypeDefinition();

                if
            }
        }
    }
}
