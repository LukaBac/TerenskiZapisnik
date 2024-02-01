using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terenski_zapisnik.Sections;

namespace Terenski_zapisnik.Models
{
    public class OkrugloCijevModel
    {
        #region StartValues
        public double R { get; set; }

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
        const double R_Nesigurnost = 0.003;
        const double H_Nesigurnost = 0.001;
        const double L_Nesigurnost = 0.161;
        const double r_Nesigurnost = 0.064;


        private double uC { get; set; } = Math.Pow(Math.Pow(R_Nesigurnost,2) + Math.Pow(H_Nesigurnost, 2) + Math.Pow(L_Nesigurnost, 2) + Math.Pow(r_Nesigurnost, 2), 0.5);


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
            dionica.OmocenoOplosje = 2*r*Math.PI*L+Math.Pow(R,2)*Math.PI+2*R*Math.PI*H;
            dionica.Vdopusteno = ((uC*2)+dionica.OmocenoOplosje) * 0.2;
            dionica.Image = Image;

            dionica.DionicaNaziv = DionicaNaziv;
            dionica.DionicaPromjer = DionicaPromjer;
            dionica.DionicaMaterijal = DionicaMaterijal;
        }
    }
}
