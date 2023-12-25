using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terenski_zapisnik.Models
{
    public class OkrugloModel : Dionice
    {
        public string DionicaName { get; set; }

        public string DionicaTip { get; set; }

        public double R { get; set; } = 0;

        public double H { get; set; } = 0;

        public OkrugloModel (string dionicaName, string dionicaTip)
        {
            DionicaName = dionicaName;
            DionicaTip = dionicaTip;
        }
    }
}
