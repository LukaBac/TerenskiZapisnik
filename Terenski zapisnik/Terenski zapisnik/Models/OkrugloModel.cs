using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terenski_zapisnik.Models
{
    public class OkrugloModel : IModel
    {
        #region StartValues

        public string R_Text { get; set; }

        public string H_Text { get; set; }

        public string IspitniTlak_Text { get; set; }
        public string VIzmjereno_Text { get; set; }

        public double R { get; set; } = 0;

        public double H { get; set; } = 0;

        public double IspitniTlak { get; set; }
        public double VIzmjereno { get; set; }
        public string VrijemePoc { get; set; }
        public string VrijemeEnd { get; set; }

        public Image Image { get; set; }

        #endregion


        #region HelperValues
        const double R_Nesigurnost = 0.002;
        const double H_Nesigurnost = 0.001;



        private double uC { get; set; } = Math.Pow(Math.Pow(R_Nesigurnost, 2) + Math.Pow(H_Nesigurnost, 2), 0.5);


        public string DionicaNaziv { get; set; }
        public string DionicaMaterijal { get; set; }
        public string DionicaPromjer { get; set; }

        #endregion

        public bool Output(DionicaModel dionica)
        {
            if (VrijemePoc == "" || VrijemePoc == null)
            {
                ProjectModel.RunError($"Prazno polje \"Vrijeme Početak\"");
                return false;
            }
            if (VrijemeEnd == "" || VrijemeEnd == null)
            {
                ProjectModel.RunError($"Prazno polje \"Vrijeme Kraj\"");
                return false;
            }
            if (DionicaNaziv == "" || DionicaNaziv == null)
            {
                ProjectModel.RunError($"Prazno polje \"Naziv Dionice\"");
                return false;
            }
            if (DionicaPromjer == "" || DionicaPromjer == null)
            {
                ProjectModel.RunError($"Prazno polje \"Promjer\"");
                return false;
            }
            if (DionicaMaterijal == "" || DionicaMaterijal == null)
            {
                ProjectModel.RunError($"Prazno polje \"Materijal\"");
                return false;
            }

            if (double.TryParse(R_Text, out double num))
            {
                R = num;
            }
            else
            {
                ProjectModel.InputError(nameof(R));
                return false;
            }

            if (double.TryParse(H_Text, out double num1))
            {
                H = num1;
            }
            else
            {
                ProjectModel.InputError(nameof(H));
                return false;
            }

            if (double.TryParse(VIzmjereno_Text, out double num3))
            {
                VIzmjereno = num3;
            }
            else
            {
                ProjectModel.InputError(nameof(VIzmjereno));
                return false;
            }

            if (double.TryParse(IspitniTlak_Text, out double num4))
            {
                IspitniTlak = num3;
            }
            else
            {
                ProjectModel.InputError(nameof(IspitniTlak));
                return false;
            }

            dionica.StartTime = VrijemePoc;
            dionica.EndTime = VrijemeEnd;
            dionica.IspitniTlak = IspitniTlak;
            dionica.VIzmjereno = VIzmjereno;
            dionica.OmocenoOplosje = 2 * R * Math.PI * H + Math.Pow(R, 2) * Math.PI;
            dionica.Vdopusteno = ((uC * 2) + dionica.OmocenoOplosje) * 0.4;
            dionica.Image = Image;

            dionica.DionicaNaziv = DionicaNaziv;
            dionica.DionicaPromjer = DionicaPromjer;
            dionica.DionicaMaterijal = DionicaMaterijal;
            return true;
        }
    }
}
