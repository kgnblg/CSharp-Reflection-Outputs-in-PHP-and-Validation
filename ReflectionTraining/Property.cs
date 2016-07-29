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
                File.WritetoLine("  public $" + property.Name.ToLower() + ";");
            }
        }
    }
}
