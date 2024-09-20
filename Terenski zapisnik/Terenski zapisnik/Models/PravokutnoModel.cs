using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terenski_zapisnik.Models
{
    public class PravokutnoModel : IModel
    {
        public string Š_Text { get; set; }

        public string d_Text { get; set; }

        public string H_Text { get; set; }

        public string IspitniTlak_Text { get; set; }
        public string VIzmjereno_Text { get; set; }




        #region StartValues
        public double Š { get; set; }

        public double d { get; set; }

        public double H { get; set; }

        public double IspitniTlak { get; set; }
        public double VIzmjereno { get; set; }


        public string VrijemePoc { get; set; }
        public string VrijemeEnd { get; set; }

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

            if (double.TryParse(Š_Text, out double num))
            {
                Š = num;
            }
            else
            {
                ProjectModel.InputError(nameof(Š));
                return false;
            }

            if (double.TryParse(d_Text, out double num1))
            {
                d = num1;
            }
            else
            {
                ProjectModel.InputError(nameof(d));
                return false;
            }

            if (double.TryParse(H_Text, out double num2))
            {
                H = num2;
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
            dionica.OmocenoOplosje = (2 * Š + 2 * d) * H + Š * d;
            dionica.Vdopusteno = ((uC * 2) + dionica.OmocenoOplosje) * 0.4;
            dionica.Image = Image;
            dionica.DionicaNaziv = DionicaNaziv;
            dionica.DionicaPromjer = DionicaPromjer;
            dionica.DionicaMaterijal = DionicaMaterijal;
            return true;
        }
    }
}
