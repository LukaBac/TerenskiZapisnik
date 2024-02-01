using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terenski_zapisnik.Models
{
    public class PravokutnoCijevModel
    {
        #region StartValues
        public double Š { get; set; }

        public double d { get; set; }

        public double H { get; set; }

        public double L { get; set; }

        public double r { get; set; }

        public double IspitniTlak { get; set; }
        public string VrijemePoc { get; set; }
        public string VrijemeEnd { get; set; }
        public double VIzmjereno { get; set; }

        public Image Image { get; set; }


        #endregion

        #region HelperValues
        private double uC { get; set; } = 0.077;


        public string DionicaNaziv { get; set; }
        public string DionicaMaterijal { get; set; }
        public string DionicaPromjer { get; set; }

        #endregion


        public void Output(DionicaModel dionica)
        {
            dionica.StartTime = VrijemePoc;
            dionica.EndTime = VrijemeEnd;
            dionica.IspitniTlak = IspitniTlak;
            dionica.VIzmjereno = VIzmjereno;
            dionica.OmocenoOplosje = (2 * Š * H) + (2 * d * H) + (Š * d) + (2 * r * Math.PI * L);
            dionica.Vdopusteno = ((uC * 2) + dionica.OmocenoOplosje) * 0.2;
            dionica.Image = Image;
            dionica.DionicaNaziv = DionicaNaziv;
            dionica.DionicaPromjer = DionicaPromjer;
            dionica.DionicaMaterijal = DionicaMaterijal;
        }
    }
}
