using System.Collections.Generic;

namespace ReflectionTraining
{
    class GetDictionary
    {
        public Dictionary<string, string> typelist = new Dictionary<string, string>();

        public GetDictionary()
        {
            typelist.Add("System.Byte", "integer");
            typelist.Add("System.SByte", "integer");
            typelist.Add("System.Int32", "integer");
            typelist.Add("System.UInt32", "integer");
            typelist.Add("System.Int16", "integer");
            typelist.Add("System.UInt16", "integer");
            typelist.Add("System.Int64", "integer");
            typelist.Add("System.UInt64", "integer");
            typelist.Add("System.Single", "double");
            typelist.Add("System.Double", "double");
            typelist.Add("System.Char", "string");
            typelist.Add("System.Boolean", "boolean");
            typelist.Add("System.String", "string");
            typelist.Add("System.Decimal", "integer");
            typelist.Add("System.Byte[]", "array&integer");
            typelist.Add("System.SByte[]", "array&integer");
            typelist.Add("System.Int32[]", "array&integer");
            typelist.Add("System.UInt32[]", "array&integer");
            typelist.Add("System.Int16[]", "array&integer");
            typelist.Add("System.UInt16[]", "array&integer");
            typelist.Add("System.Int64[]", "array&integer");
            typelist.Add("System.UInt64[]", "array&integer");
            typelist.Add("System.Single[]", "array&double");
            typelist.Add("System.Double[]", "array&double");
            typelist.Add("System.Char[]", "array&string");
            typelist.Add("System.Boolean[]", "array&boolean");
            typelist.Add("System.String[]", "array&string");
            typelist.Add("System.Decimal[]", "array&integer");
        }
    }
}
