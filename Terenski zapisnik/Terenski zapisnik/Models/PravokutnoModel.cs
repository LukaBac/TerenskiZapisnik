using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terenski_zapisnik.Models
{
    public class PravokutnoModel
    {
        #region StartValues
        public double Š { get; set; }

        public double d { get; set; }

        public double H { get; set; }

        public double IspitniTlak { get; set; }
        public string VrijemePoc { get; set; }
        public string VrijemeEnd { get; set; }
        public double VIzmjereno { get; set; }

        public Image Image { get; set; }


        #endregion

        #region HelperValues
        const double Š_Nesigurnost = 0.00052;
        const double d_Nesigurnost = 0.00052;
        const double H_Nesigurnost = 0.000462;



        private double uC { get; set; } = Math.Pow(Math.Pow(Š_Nesigurnost, 2) + Math.Pow(d_Nesigurnost, 2) + Math.Pow(H_Nesigurnost, 2), 0.5);


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
            dionica.OmocenoOplosje = (2 * Š + 2 * d) * H + Š * d;
            dionica.Vdopusteno = ((uC * 2) + dionica.OmocenoOplosje) * 0.4;
            dionica.Image = Image;
            dionica.DionicaNaziv = DionicaNaziv;
            dionica.DionicaPromjer = DionicaPromjer;
            dionica.DionicaMaterijal = DionicaMaterijal;
        }
    }
}
