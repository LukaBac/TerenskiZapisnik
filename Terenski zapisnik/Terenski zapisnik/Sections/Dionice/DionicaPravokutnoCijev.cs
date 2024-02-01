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

namespace Terenski_zapisnik.Sections.Dionice
{
    public partial class DionicaPravokutnoCijev : Form
    {
        PravokutnoCijevModel PravokutnoCijevModel = new PravokutnoCijevModel();

        public DionicaPravokutnoCijev()
        {
            InitializeComponent();
        }

        private void LostFocus(object sender, EventArgs e)
        {
            if (š_textBox.Text != "" && h_textBox.Text != "" && d_textBox.Text != "" && L_textBox.Text != "" && r_textBox.Text != "" && VizmjerenoTextBox.Text != "" && TlakTextBox.Text != "" && StartTimeTextBox.Text != "" && EndTimeTextBox.Text != "" && NazivDioniceTextBox.Text != "" && PromjerTextBox.Text != "" && MaterijalTextBox.Text != "")
            {
                PravokutnoCijevModel.Image = pictureBox1.Image;
                PravokutnoCijevModel.Output(Terenski_zapisnik.Models.Dionice.dionice[Terenski_zapisnik.Models.Dionice.activeIndex].DionicaModel);
            }
        }

        private void Š_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(š_textBox.Text, out double Š))
            {
                PravokutnoCijevModel.Š = Š;
            }
        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(h_textBox.Text, out double H))
            {
                PravokutnoCijevModel.H = H;
            }
        }
        private void d_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(d_textBox.Text, out double d))
            {
                PravokutnoCijevModel.d = d;
            }
        }

        private void L_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(L_textBox.Text, out double L))
            {
                PravokutnoCijevModel.L = L;
            }
        }

        private void r_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(r_textBox.Text, out double r))
            {
                PravokutnoCijevModel.r = r;
            }
        }

        private void VizmjerenoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(VizmjerenoTextBox.Text, out double VIzmj))
            {
                PravokutnoCijevModel.VIzmjereno = VIzmj;
            }
        }

        private void TlakTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TlakTextBox.Text, out double Tlak))
            {
                PravokutnoCijevModel.IspitniTlak = Tlak;
            }
        }

        private void NazivDioniceTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.DionicaNaziv = NazivDioniceTextBox.Text;
        }

        private void MaterijalTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.DionicaMaterijal = MaterijalTextBox.Text;
        }

        private void PromjerTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.DionicaPromjer = PromjerTextBox.Text;
        }

        private void StartTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.VrijemePoc = StartTimeTextBox.Text;
        }

        private void EndTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.VrijemeEnd = EndTimeTextBox.Text;
        }
    }
}
