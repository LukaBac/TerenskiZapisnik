using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terenski_zapisnik.Models
{
    public class Dionica
    {
        public string Name { get; set; }

        public string Type { get; set; }

        public Form Forma { get; set; }

        public DionicaModel DionicaModel { get; set; }

        public Dionica(string name, string type, Form forma, DionicaModel dionicaModel)
        {
            Name = name;
            Type = type;    
            Forma = forma;
            DionicaModel = dionicaModel;
        }
    }
}
