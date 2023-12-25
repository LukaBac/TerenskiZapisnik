using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terenski_zapisnik.Models
{
    public class Dionice
    {
        public static List<OkrugloModel> dionice = new List<OkrugloModel>();

        public string DionicaName { get; set; }

        public static int activeIndex { get; set; }

        //public string DionicaTip { get; set; }
    }
}
