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
    public partial class DionicaOkruglo : Form
    {

        OkrugloModel OkrugloModel = new OkrugloModel();


        public DionicaOkruglo()
        {
            InitializeComponent();

            //R_textBox.Text = Dionice.dionice[Dionice.activeIndex].R.ToString();
            //H_textBox.Text = Dionice.dionice[Dionice.activeIndex].H.ToString();
        }

        private void LostFocus(object sender, EventArgs e)
        {
            if (R_textBox.Text != "" && H_textBox.Text != "" && VizmjerenoTextBox.Text != "" && TlakTextBox.Text != "" && StartTimeTextBox.Text != "" && EndTimeTextBox.Text != "" && NazivDioniceTextBox.Text != "" && PromjerTextBox.Text != "" && MaterijalTextBox.Text != "")
            {
                OkrugloModel.Image = pictureBox1.Image;
                OkrugloModel.Output(Terenski_zapisnik.Models.Dionice.dionice[Terenski_zapisnik.Models.Dionice.activeIndex].DionicaModel);
            }
        }

        private void R_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(R_textBox.Text, out double R))
            {
                OkrugloModel.R = R;
            }
        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(H_textBox.Text, out double H))
            {
                OkrugloModel.H = H;
            }
        }

        private void VizmjerenoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(VizmjerenoTextBox.Text, out double VIzmj))
            {
                OkrugloModel.VIzmjereno = VIzmj;
            }
        }

        private void TlakTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TlakTextBox.Text, out double Tlak))
            {
                OkrugloModel.IspitniTlak = Tlak;
            }
        }

        private void NazivDioniceTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloModel.DionicaNaziv = NazivDioniceTextBox.Text; 
        }

        private void MaterijalTextBox_TextChanged(object sender, EventArgs e)
        {
             OkrugloModel.DionicaMaterijal = MaterijalTextBox.Text;            
        }

        private void PromjerTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloModel.DionicaPromjer = PromjerTextBox.Text;
        }

        private void StartTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloModel.VrijemePoc = StartTimeTextBox.Text;
        }

        private void EndTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloModel.VrijemeEnd = EndTimeTextBox.Text;
        }
    }
}
