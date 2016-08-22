using CSharpReflection;
using System.Collections.Generic;

namespace ReflectionTraining
{
    class TypeWriter
    {
        public List<FieldElements> fieldelements { get; set; }
        public List<PropertyElements> propertyelements { get; set; }

        public TypeWriter(List<FieldElements> fieldelements)
        {
            this.fieldelements = fieldelements;
        }

        public TypeWriter(List<FieldElements> fieldelements, List<PropertyElements> propertyelements)
        {
            this.fieldelements = fieldelements;
            this.propertyelements = propertyelements;
        }

        public void PrintTypesFunction()
        {
            PrintTypesFunctionHeader();

            FieldSeperator fieldseperator = new FieldSeperator(fieldelements);
            fieldseperator.SeperateFields();

            List<FieldElements> normalfields = fieldseperator.normalFields;
            List<FieldElements> genericfields = fieldseperator.genericFields;

            foreach (var field in normalfields)
            {
                string typeresult = TypeFinder.FindTypeforNormalFields(field);

                File.WritetoLine("      '" + field.fieldName + "' => '" + typeresult + "',");
            }

            foreach (var field in genericfields)
            {
                string typeresult = TypeFinder.FindTypeforGenericFields(field);

                File.WritetoLine("      '" + field.fieldName + "' => '" + typeresult + "',");
            }


            if (propertyelements != null)
            {
                PropertySeperator propertyseperator = new PropertySeperator(propertyelements);
                propertyseperator.SeperatePropertys();

                List<PropertyElements> normalpropertys = propertyseperator.normalPropertys;
                List<PropertyElements> genericpropertys = propertyseperator.genericPropertys;

                foreach (var property in normalpropertys)
                {
                    string typeresult = TypeFinder.FindTypeforNormalPropertys(property);

                    File.WritetoLine("      '" + property.propertyName + "' => '" + typeresult + "',");
                }

                foreach (var property in genericpropertys)
                {
                    string typeresult = TypeFinder.FindTypeforGenericPropertys(property);

                    File.WritetoLine("      '" + property.propertyName + "' => '" + typeresult + "',");
                }
            }

            PrintTypesFunctionFooter();
        }

        public void PrintTypesFunctionHeader()
        {
            File.WritetoLine("  public function _types() {");
            File.WritetoLine("      return [");
        }

        public void PrintTypesFunctionFooter()
        {
            File.WritetoLine("      ];");
            File.WritetoLine("  }");
        }
    }
}
