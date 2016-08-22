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
            typelist.Add("System.DateTime", "string");
            typelist.Add("System.Byte[]", "array&single&integer");
            typelist.Add("System.SByte[]", "array&single&integer");
            typelist.Add("System.Int32[]", "array&single&integer");
            typelist.Add("System.UInt32[]", "array&single&integer");
            typelist.Add("System.Int16[]", "array&single&integer");
            typelist.Add("System.UInt16[]", "array&single&integer");
            typelist.Add("System.Int64[]", "array&single&integer");
            typelist.Add("System.UInt64[]", "array&single&integer");
            typelist.Add("System.Single[]", "array&single&double");
            typelist.Add("System.Double[]", "array&single&double");
            typelist.Add("System.Char[]", "array&single&string");
            typelist.Add("System.Boolean[]", "array&single&boolean");
            typelist.Add("System.String[]", "array&single&string");
            typelist.Add("System.Decimal[]", "array&single&integer");
        }
    }
}
