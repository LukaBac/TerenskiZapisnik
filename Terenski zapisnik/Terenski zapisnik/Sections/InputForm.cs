using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terenski_zapisnik.Sections
{
    public partial class InputForm : Form
    {
        public InputForm()
        {
            InitializeComponent();

            Radijus_Root3_Update();
            DubinaVode_Root3_Update();
            RadijusCijevi_Root3_Update();
        }

        private void TextUpdate(object sender, EventArgs e)
        {
            if (Double.TryParse(Radijus.Text, out double result))
            {

            }
            DubinaVode_Osjetljivost_Update();
            DuzinaCijevi_M_Update();
            Radijus_Osjetljivost_Update();
            Radijus_Osjetljivost_Update();
            DuzinaCijevu_Root3_Update();
            RadijusCijevi_Osjetljivost_Update();
            DuzinaCijevi_Osjetljivost_Update();
            Radijus_Nesigurnost_Update();
            RadijusCijevi_Nesigurnost_Update();
            DuzinaCijevi_Nesigurnost_Update();
            DubinaVode_Nesigurnost_Update();
        }

        #region TextBoxUpdates

        #region Radijus
        private void Radijus_Root3_Update()
        {
            Radijus_Root3.Text = Math.Round((Convert.ToDouble(Radijus_M.Text) / Math.Pow(3.0, 0.5)), 6).ToString();
        }

        private void Radijus_Osjetljivost_Update()
        {
            try
            {    
                Radijus_Osjetljivost.Text =  Math.Round((2 * Convert.ToDouble(Radijus.Text) * Math.PI + 2 * Math.PI * Convert.ToDouble(DubinaVode.Text)), 4).ToString();
            }
            catch
            {

            }
        }

        private void Radijus_Nesigurnost_Update()
        {
            try
            {
                Radijus_Nesigurnost.Text = Math.Round(Convert.ToDouble(Radijus_Root3.Text) * Convert.ToDouble(Radijus_Osjetljivost.Text), 3).ToString();
            }
            catch
            {

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
            try
            {
                DubinaVode_Osjetljivost.Text = Math.Round((2 * Convert.ToDouble(Radijus.Text) * Math.PI), 4).ToString();
            }
            catch
            {

            }
        }

        private void DubinaVode_Nesigurnost_Update()
        {
            try
            {
                DubinaVode_Nesigurnost.Text = Math.Round(Convert.ToDouble(DubinaVode_Root3.Text) * Convert.ToDouble(DubinaVode_Osjetljivost.Text), 3).ToString();
            }
            catch
            {

            }
        }
        #endregion

        #region DuzinaCijevi
        private void DuzinaCijevi_M_Update()
        {
            try
            {
                duzinaCijevi_M.Text = (Convert.ToDouble(DuzinaCijevi.Text) * 0.01).ToString();
            }
            catch{

            }
        }
        private void DuzinaCijevu_Root3_Update()
        {
            try
            {
                DuzinaCijevi_Root3.Text = Math.Round((Convert.ToDouble(duzinaCijevi_M.Text) / Math.Pow(3.0, 0.5)), 6).ToString();
            }
            catch
            {

            }
        }

        private void DuzinaCijevi_Osjetljivost_Update()
        {
            try
            {
                DuzinaCijevi_Osjetljivost.Text = Math.Round(2 * Convert.ToDouble(radijusCijevi.Text) * Math.PI, 4).ToString();
            }
            catch
            {

            }
        }

        private void DuzinaCijevi_Nesigurnost_Update()
        {
            try
            {
                DuzinaCijevi_Nesigurnost.Text = Math.Round(Convert.ToDouble(DuzinaCijevi_Root3.Text) * Convert.ToDouble(DuzinaCijevi_Osjetljivost.Text), 3).ToString();
            }
            catch
            {

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
            try
            {
                radijusCijevi_Osjetljivost.Text = Math.Round((2 * Math.PI * Convert.ToDouble(DuzinaCijevi.Text)), 4).ToString();
            }
            catch
            {

            }
        }

        private void RadijusCijevi_Nesigurnost_Update()
        {
            try
            {
                radijusCijevi_Nesigurnost.Text = Math.Round(Convert.ToDouble(radijusCijevi_Root3.Text) * Convert.ToDouble(radijusCijevi_Osjetljivost.Text), 3).ToString();
            }
            catch
            {

            }
        }

        #endregion

        #endregion

    }
}
