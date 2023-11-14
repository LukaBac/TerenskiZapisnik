using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Terenski_zapisnik.Sections
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();

            setStyles();

            Radijus_Root3_Update();
            DubinaVode_Root3_Update();
            RadijusCijevi_Root3_Update();

            //DubinaVode_Osjetljivost_Update();
            //DuzinaCijevi_M_Update();
            //Radijus_Osjetljivost_Update();
            //Radijus_Osjetljivost_Update();
            //DuzinaCijevu_Root3_Update();
            //RadijusCijevi_Osjetljivost_Update();
            //DuzinaCijevi_Osjetljivost_Update();
            //Radijus_Nesigurnost_Update();
            //RadijusCijevi_Nesigurnost_Update();
            //DuzinaCijevi_Nesigurnost_Update();
            //DubinaVode_Nesigurnost_Update();


            //uC_Update();
            //Oplosje1_Update();
            //Oplosje2_Update();
            //Oplosje3_Update();
            //TextUpdate();
        }

        private void inputChange(object sender, EventArgs e){
            if (Double.TryParse(Radijus.Text, out double num1) && Double.TryParse(DubinaVode.Text, out double num2) && Double.TryParse(DuzinaCijevi.Text, out double num3) && Double.TryParse(radijusCijevi.Text, out double num4))
            {
                TextUpdate();
            }
        }
        #region Style
        private void setStyles()
        {
            Radijus.SelectionAlignment = HorizontalAlignment.Center;
        }
        #endregion
        private void TextUpdate()
        {
            DuzinaCijevi_M_Update();

            DuzinaCijevu_Root3_Update();

            Radijus_Osjetljivost_Update();
            DubinaVode_Osjetljivost_Update();
            DuzinaCijevi_Osjetljivost_Update();
            RadijusCijevi_Osjetljivost_Update();
            
            Radijus_Nesigurnost_Update();
            DubinaVode_Nesigurnost_Update();
            DuzinaCijevi_Nesigurnost_Update();
            RadijusCijevi_Nesigurnost_Update();
            
            uC_Update();

            Oplosje1_Update();
            Oplosje2_Update();
            Oplosje3_Update();
        }

        private void uC_Update()
        {
            if (Double.TryParse(Radijus_Nesigurnost.Text, out double num1) && Double.TryParse(DubinaVode_Nesigurnost.Text, out double num2) && Double.TryParse(DuzinaCijevi_Nesigurnost.Text, out double num3) && Double.TryParse(radijusCijevi_Nesigurnost.Text, out double num4))
            {
                ucOutput.Text = Math.Round(Math.Pow((Math.Pow(num1, 2) + Math.Pow(num2, 2) + Math.Pow(num3, 2) + Math.Pow(num4, 2)), 0.5), 4).ToString();
                uOutput.Text = Math.Round(Convert.ToDouble(ucOutput.Text)*2, 4).ToString();
                Oplosje2.Text = uOutput.Text;
                uLOutput.Text = Math.Round(Convert.ToDouble(uOutput.Text) * 0.2, 2).ToString();
            }
        }

        #region TextBoxUpdates

        #region Radijus
        private void Radijus_Root3_Update()
        {
            Radijus_Root3.Text = Math.Round((Convert.ToDouble(Radijus_M.Text) / Math.Pow(3.0, 0.5)), 6).ToString();
        }

        private void Radijus_Osjetljivost_Update()
        {
            if (Double.TryParse(Radijus.Text, out double num1) && Double.TryParse(DubinaVode.Text, out double num2))
            {
                Radijus_Osjetljivost.Text = Math.Round((2 * num1 * Math.PI + 2 * Math.PI * num2), 4).ToString();
            }
        }

        private void Radijus_Nesigurnost_Update()
        {
            if (Double.TryParse(Radijus_Root3.Text, out double num1) && Double.TryParse(Radijus_Osjetljivost.Text, out double num2))
            {
                Radijus_Nesigurnost.Text = Math.Round(num1 * num2, 3).ToString();

            }
        }

        #endregion

        #region DubinaVode
        private void DubinaVode_Root3_Update()
        {
            DubinaVode_Root3.Text = Math.Round((Convert.ToDouble(DubinaVode_M.Text) / Math.Pow(3.0, 0.5)), 6).ToString();
        }

        private void DubinaVode_Osjetljivost_Update()
        {
            if (Double.TryParse(Radijus.Text, out double num))
            {
                DubinaVode_Osjetljivost.Text = Math.Round((2 * num * Math.PI), 4).ToString();

            }
        }

        private void DubinaVode_Nesigurnost_Update()
        {
            if(Double.TryParse(DubinaVode_Root3.Text, out double num1) && Double.TryParse(DubinaVode_Osjetljivost.Text, out double num2))
            {
                DubinaVode_Nesigurnost.Text = Math.Round(num1 * num2, 3).ToString();

            }
        }
        #endregion

        #region DuzinaCijevi
        private void DuzinaCijevi_M_Update()
        {
            if (Double.TryParse(DuzinaCijevi.Text, out double num))
            {
                duzinaCijevi_M.Text = (num * 0.01).ToString();
            }
        }
        private void DuzinaCijevu_Root3_Update()
        {
            if (Double.TryParse(duzinaCijevi_M.Text, out double num))
            {
                DuzinaCijevi_Root3.Text = Math.Round((num / Math.Pow(3.0, 0.5)), 6).ToString();
            }
        }

        private void DuzinaCijevi_Osjetljivost_Update()
        {
            if (Double.TryParse(radijusCijevi.Text, out double num))
            {
                DuzinaCijevi_Osjetljivost.Text = Math.Round(2 * num * Math.PI, 4).ToString();

            }
        }

        private void DuzinaCijevi_Nesigurnost_Update()
        {
            if (Double.TryParse(DuzinaCijevi_Root3.Text, out double num1) && Double.TryParse(DuzinaCijevi_Osjetljivost.Text, out double num2))
            {
                DuzinaCijevi_Nesigurnost.Text = Math.Round(num1 * num2, 3).ToString();

            }
        }

        #endregion

        #region RadijusCijevi

        private void RadijusCijevi_Root3_Update()
        {
            radijusCijevi_Root3.Text = Math.Round((Convert.ToDouble(radijusCijevi_M.Text) / Math.Pow(3.0, 0.5)), 6).ToString();
        }

        private void RadijusCijevi_Osjetljivost_Update()
        {
            if (Double.TryParse(DuzinaCijevi.Text, out double num2))
            {
                radijusCijevi_Osjetljivost.Text = Math.Round((2 * Math.PI * Convert.ToDouble(DuzinaCijevi.Text)), 4).ToString();

            }
        }

        private void RadijusCijevi_Nesigurnost_Update()
        {
            if (Double.TryParse(radijusCijevi_Root3.Text, out double num1) && Double.TryParse(radijusCijevi_Osjetljivost.Text, out double num2))
            {
                radijusCijevi_Nesigurnost.Text = Math.Round(num1 * num2, 3).ToString();

            }
        }

        #endregion

        #endregion

        private void Vdod_Racun_Update(object sender, EventArgs e)
        {
            if (Double.TryParse(Vdod1.Text, out double num1) && Double.TryParse(Vdod2.Text, out double num2) && Double.TryParse(Vdod3.Text, out double num3))
            {
                Vdod_Racun.Text = Math.Round(num1+num2+num3,2).ToString();
            }
        }

        private void Vdod_MJN_Update(object sender, EventArgs e)
        {
            if (Double.TryParse(Vdod1_MJN.Text, out double num1) && Double.TryParse(Vdod2_MJN.Text, out double num2) && Double.TryParse(Vdod3_MJN.Text, out double num3))
            {
                VdodRacun_MJN.Text = Math.Round(Math.Pow(Math.Pow(num1,2) + Math.Pow(num2, 2) + Math.Pow(num3, 2), 0.5), 3).ToString();
            }
        }



        #region oplosje

        private void Oplosje1_Update()
        {
            if (Double.TryParse(Radijus.Text, out double num1) && Double.TryParse(DubinaVode.Text, out double num2) && Double.TryParse(DuzinaCijevi.Text, out double num3) && Double.TryParse(radijusCijevi.Text, out double num4))
            {
                Oplosje1.Text = Math.Round(2*num4*Math.PI*num3+Math.Pow(num1,2)*Math.PI+2*num1*Math.PI*num2 ,3).ToString();
            }
        }

        private void Oplosje2_Update()
        {
            Oplosje2.Text = uOutput.Text;
        }

        private void Oplosje3_Update()
        {
            if (Double.TryParse(Oplosje1.Text, out double num1) && Double.TryParse(Oplosje2.Text, out double num2))
            {
                Oplosje3.Text = (num1 + num2).ToString();
                VdopL.Text = Math.Round((Convert.ToDouble(Oplosje3.Text) * 0.2),2).ToString();
                Vdopmm.Text = Math.Round((Convert.ToDouble(VdopL.Text) / (Convert.ToDouble(Radijus.Text) * Convert.ToDouble(Radijus.Text) * 3.14)),2).ToString();
            }
        }

        #endregion
    }
}
