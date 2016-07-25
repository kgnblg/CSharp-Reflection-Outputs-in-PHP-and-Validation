using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionTraining
{
    class ModelClass
    {
        public Type[] types { get; set; }

        public ModelClass(Type[] types)
        {
            this.types = types;
        }

        public void Creator()
        {
            File file = new File("C:/dlloutputs/modelclass.php");
            file.SetFile();

            File.WritetoLine("<?php");
            File.WritetoLine("");

            File.WritetoLine("namespace "+ types[1].Namespace);
            File.WritetoLine("use Exception;");
        }
        


    }
}
