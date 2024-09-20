using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Terenski_zapisnik.Models
{
    public class PravokutnoCijevModel : IModel
    {
        #region StartValues
        public string Š_Text { get; set; }

        public string d_Text { get; set; }

        public string H_Text { get; set; }

        public string L_Text { get; set; }

        public string r_Text { get; set; }

        public string IspitniTlak_Text { get; set; }
        public string VIzmjereno_Text { get; set; }


        public string DionicaName { get; set; }


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

            if (double.TryParse(L_Text, out double num5))
            {
                L = num5;
            }
            else
            {
                ProjectModel.InputError(nameof(L));
                return false;
            }

            if (double.TryParse(r_Text, out double num7))
            {
                r = num7;
            }
            else
            {
                ProjectModel.InputError(nameof(r));
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
            dionica.OmocenoOplosje = (2 * Š * H) + (2 * d * H) + (Š * d) + (2 * r * Math.PI * L);
            dionica.Vdopusteno = ((uC * 2) + dionica.OmocenoOplosje) * 0.2;
            dionica.Image = Image;
            dionica.DionicaNaziv = DionicaNaziv;
            dionica.DionicaPromjer = DionicaPromjer;
            dionica.DionicaMaterijal = DionicaMaterijal;
            return true;
        }
    }
}
