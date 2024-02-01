using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terenski_zapisnik.Models;

namespace Terenski_zapisnik.Sections
{
    public partial class DionicaOkrCijev : Form
    {

        OkrugloCijevModel OkrugloCijevModel = new OkrugloCijevModel();

        public DionicaOkrCijev()
        {
            InitializeComponent();
        }





        //private void TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        OkrugloCijevModel.R = Convert.ToDouble(R_textBox.Text);
        //        OkrugloCijevModel.L = Convert.ToDouble(L_textBox.Text);
        //        OkrugloCijevModel.H = Convert.ToDouble(H_textBox.Text);
        //        OkrugloCijevModel.r = Convert.ToDouble(R2_textBox.Text);

        //        OkrugloCijevModel.IspitniTlak = Convert.ToDouble(TlakTextBox.Text);
        //        OkrugloCijevModel.VIzmjereno = Convert.ToDouble(VizmjerenoTextBox.Text);

        //        OkrugloCijevModel.VrijemePoc = StartTimeTextBox.Text;
        //        OkrugloCijevModel.VrijemeEnd = EndTimeTextBox.Text;
        //    }
        //    catch
        //    {

        //    }

        //    if (R_textBox.Text != "" && L_textBox.Text != "" && R2_textBox.Text != "" && H_textBox.Text != "" && TlakTextBox.Text != "" && VizmjerenoTextBox.Text != "" && StartTimeTextBox.Text != "" && EndTimeTextBox.Text != "" && !R_textBox.Focused && !L_textBox.Focused && !R2_textBox.Focused && !H_textBox.Focused && !TlakTextBox.Focused && !VizmjerenoTextBox.Focused && !StartTimeTextBox.Focused && !EndTimeTextBox.Focused)
        //    {
        //        OkrugloCijevModel.Output(Terenski_zapisnik.Models.Dionice.dionice[Terenski_zapisnik.Models.Dionice.activeIndex].DionicaModel);
        //    }
        //}

        private void LostFocus(object sender, EventArgs e)
        {
            if (R_textBox.Text != "" && H_textBox.Text != "" && L_textBox.Text != "" && R2_textBox.Text != "" && VizmjerenoTextBox.Text != "" && TlakTextBox.Text != "" && StartTimeTextBox.Text != "" && EndTimeTextBox.Text != "" && NazivDioniceTextBox.Text != "" && PromjerTextBox.Text != "" && MaterijalTextBox.Text != "")
            {
                OkrugloCijevModel.Image = pictureBox1.Image;
                OkrugloCijevModel.Output(Terenski_zapisnik.Models.Dionice.dionice[Terenski_zapisnik.Models.Dionice.activeIndex].DionicaModel);
            }
        }

        private void R_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(R_textBox.Text, out double R))
            {
                OkrugloCijevModel.R = R;
            }
        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(H_textBox.Text, out double H))
            {
                OkrugloCijevModel.H = H;
            }
        }

        private void L_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(L_textBox.Text, out double L))
            {
                OkrugloCijevModel.L = L;
            }
        }

        private void R2_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(R2_textBox.Text, out double R2))
            {
                OkrugloCijevModel.r = R2;
            }
        }

        private void VizmjerenoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(VizmjerenoTextBox.Text, out double VIzmj))
            {
                OkrugloCijevModel.VIzmjereno = VIzmj;
            }
        }

        private void TlakTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TlakTextBox.Text, out double Tlak))
            {
                OkrugloCijevModel.IspitniTlak = Tlak;
            }
        }

        private void StartTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.VrijemePoc = StartTimeTextBox.Text;
        }

        private void EndTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.VrijemeEnd = EndTimeTextBox.Text;
        }

        private void NazivDioniceTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.DionicaNaziv = NazivDioniceTextBox.Text;
        }

        private void MaterijalTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.DionicaMaterijal = MaterijalTextBox.Text;
        }

        private void PromjerTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.DionicaPromjer = PromjerTextBox.Text;
        }
    }
}
