using CSharpReflection;
using System;
using System.Collections.Generic;

namespace ReflectionTraining
{
    class TypeFinder
    {
        static GetDictionary dictionary = new GetDictionary();

        public static string FindTypeforNormalFields(FieldElements field)
        {
            if (field.FieldType.IsEnum)
            {
                return "integer&enum&" + field.fieldTypeFullName.Replace('.', '\\');
            }

            if (field.FieldType.IsArray)
            {
                if (field.FieldType.IsPrimitive)
                {
                    return dictionary.typelist[field.fieldTypeFullName];
                }
                else
                {
                    if (field.fieldReturnType == "String")
                    {
                        return dictionary.typelist[field.fieldTypeFullName];
                    }
                    else
                    {
                        return "array&single&" + field.fieldTypeFullName.Replace('.', '\\');
                    }
                }
            }

            if (field.FieldType.IsPrimitive)
            {
                return dictionary.typelist[field.fieldTypeFullName];
            }
            else
            {
                if (field.fieldReturnType == "String")
                {
                    return dictionary.typelist[field.fieldTypeFullName];
                }
                else
                {
                    return "object&" + field.fieldTypeFullName.Replace('.', '\\');
                }
            }
        }

        public static string FindTypeforGenericFields(FieldElements field)
        {
            var typedefinition = field.FieldType.GetGenericTypeDefinition();

            if (field.FieldType == typeof(DateTime))
            {
                return dictionary.typelist[field.FieldType.ToString()];
            }

            if (typedefinition.GetInterface("IEnumerable") != null)
            {
                if (field.FieldType.GetGenericArguments().Length >= 2)
                {
                    return "array&multiple&" + dictionary.typelist[field.FieldType.GetGenericArguments()[0].ToString()] + "&" + dictionary.typelist[field.FieldType.GetGenericArguments()[1].ToString()];
                }
                else
                {
                    if (field.FieldType.GetGenericArguments()[0].IsPrimitive)
                    {
                        return "array&single&" + dictionary.typelist[field.FieldType.GetGenericArguments()[0].ToString()];
                    }
                    else
                    {
                        if (field.FieldType.GetGenericArguments()[0] == typeof(string))
                        {
                            return "array&single&" + dictionary.typelist[field.FieldType.GetGenericArguments()[0].ToString()];
                        }
                        else
                        {
                            return "array&single&" + field.FieldType.GetGenericArguments()[0].ToString().Replace('.','\\');
                        }
                    }

                }
            }

            if (Nullable.GetUnderlyingType(field.FieldType) != null)
            {
                return dictionary.typelist[Nullable.GetUnderlyingType(field.FieldType).ToString()];
            }

            throw new Exception(field.fieldName + " can't handle type via FindTypeForGenericFields() in TypeFinder.cs");
        }

        public static string FindTypeforNormalPropertys(PropertyElements property)
        {
            if (property.propertyType.IsEnum)
            {
                return "integer&enum&" + property.propertyTypeFullName.Replace('.', '\\');
            }

            if (property.propertyType.IsArray)
            {
                if (property.propertyType.IsPrimitive)
                {
                    return dictionary.typelist[property.propertyTypeFullName];
                }
                else
                {
                    if (property.propertyReturnType == "String")
                    {
                        return dictionary.typelist[property.propertyTypeFullName];
                    }
                    else
                    {
                        return "array&single&" + property.propertyTypeFullName.Replace('.', '\\');
                    }
                }
            }

            if (property.propertyType.IsPrimitive)
            {
                return dictionary.typelist[property.propertyTypeFullName];
            }
            else
            {
                if (property.propertyReturnType == "String")
                {
                    return dictionary.typelist[property.propertyTypeFullName];
                }
                else
                {
                    return "object&" + property.propertyTypeFullName.Replace('.', '\\');
                }
            }
        }

        public static string FindTypeforGenericPropertys(PropertyElements property)
        {
            var typedefinition = property.propertyType.GetGenericTypeDefinition();

            if (typedefinition == typeof(DateTime))
            {
                return dictionary.typelist[property.propertyType.ToString()];
            }

            if (typedefinition.GetInterface("IEnumerable") != null)
            {
                if (property.propertyType.GetGenericArguments().Length >= 2)
                {
                    string firstargument, secondargument;

                    if (property.propertyType.GetGenericArguments()[0].IsPrimitive)
                    {
                        firstargument = dictionary.typelist[property.propertyType.GetGenericArguments()[0].ToString()];
                    }
                    else
                    {
                        if (property.propertyType.GetGenericArguments()[0] == typeof(string))
                        {
                            firstargument = dictionary.typelist[property.propertyType.GetGenericArguments()[0].ToString()];
                        }
                        else
                        {
                            firstargument = property.propertyType.GetGenericArguments()[0].ToString().Replace('.', '\\');
                        }
                    }

                    if (property.propertyType.GetGenericArguments()[1].IsPrimitive)
                    {
                        secondargument = dictionary.typelist[property.propertyType.GetGenericArguments()[1].ToString()];
                    }
                    else
                    {
                        if (property.propertyType.GetGenericArguments()[1] == typeof(string))
                        {
                            secondargument = dictionary.typelist[property.propertyType.GetGenericArguments()[1].ToString()];
                        }
                        else
                        {
                            secondargument = property.propertyType.GetGenericArguments()[1].ToString().Replace('.', '\\');
                        }
                    }



                    return "array&multiple&" + firstargument + "&" + secondargument;
                }
                else
                {
                    if (property.propertyType.GetGenericArguments()[0].IsPrimitive)
                    {
                        return "array&single&" + dictionary.typelist[property.propertyType.GetGenericArguments()[0].ToString()];
                    }
                    else
                    {
                        if (property.propertyType.GetGenericArguments()[0] == typeof(string))
                        {
                            return "array&single&" + dictionary.typelist[property.propertyType.GetGenericArguments()[0].ToString()];
                        }
                        else
                        {
                            return "array&single&" + property.propertyType.GetGenericArguments()[0].ToString().Replace('.','\\');
                        }
                    }

                }
            }

            if (Nullable.GetUnderlyingType(property.propertyType) != null)
            {
                if (Nullable.GetUnderlyingType(property.propertyType).IsPrimitive)
                {
                    return dictionary.typelist[Nullable.GetUnderlyingType(property.propertyType).ToString()];
                }
                else
                {
                    if (Nullable.GetUnderlyingType(property.propertyType) == typeof(string))
                    {
                        return dictionary.typelist[Nullable.GetUnderlyingType(property.propertyType).ToString()];
                    }
                    else
                    {
                        return "object&" + Nullable.GetUnderlyingType(property.propertyType).ToString().Replace('.', '\\');
                    }
                }
            }
            throw new Exception(property.propertyName + " can't handle this type in FindTypeForGenericPropertys() at TypeFinder.cs");
        }
    }
}
