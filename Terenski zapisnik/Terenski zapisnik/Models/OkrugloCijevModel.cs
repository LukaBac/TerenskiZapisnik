using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terenski_zapisnik.Models
{
    public class OkrugloCijevModel
    {
        public string DionicaName { get; set; }

        public string DionicaTip { get; set; }

        public double R { get; set; }

        public double H { get; set; }

        public double L { get; set; }

        public double r { get; set; }

        public OkrugloCijevModel(string dionicaName, string dionicaTip)
        {
            DionicaName = dionicaName;
            DionicaTip = dionicaTip;
        }
    }
}
