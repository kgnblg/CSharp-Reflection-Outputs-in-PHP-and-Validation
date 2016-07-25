using System.Reflection;

namespace ReflectionTraining
{
    class Property
    {
        PropertyInfo [] propertyinfo { get; set; }

        public Property(PropertyInfo [] propertyinfo)
        {
            this.propertyinfo = propertyinfo;
        }

        public void PrintPropertys()
        {
            foreach (var property in propertyinfo)
            {
                var accessors = property.GetAccessors();
                string[] getsetcontrol = new string[2];

                if (CorrectString.SplitIt(accessors[0].Name, '_', 0) == "get")
                {
                    File.WritetoLine("  public function get" + property.Name + "() {");
                    File.WritetoLine("  return $this->" + property.Name.ToLower() + ";");
                    File.WritetoLine("  }");
                    File.WritetoLine("");
                }

                if (CorrectString.SplitIt(accessors[1].Name, '_', 0) == "set")
                {
                    File.WritetoLine("  public function set" + property.Name + "($value) {");
                    File.WritetoLine("  $this->" + property.Name.ToLower() +" = $value;");
                    File.WritetoLine("  }");
                    File.WritetoLine("");
                }
            }
        }
    }
}
