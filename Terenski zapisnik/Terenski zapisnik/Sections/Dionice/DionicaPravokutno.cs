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
    public partial class DionicaPravokutno : Form
    {
        PravokutnoModel PravokutnoModel = new PravokutnoModel();


        public DionicaPravokutno()
        {
            InitializeComponent();
        }

        private void LostFocus(object sender, EventArgs e)
        {
            if (š_textBox.Text != "" && h_textBox.Text != "" && d_textBox.Text != "" && VizmjerenoTextBox.Text != "" && TlakTextBox.Text != "" && StartTimeTextBox.Text != "" && EndTimeTextBox.Text != "" && NazivDioniceTextBox.Text != "" && PromjerTextBox.Text != "" && MaterijalTextBox.Text != "")
            {
                PravokutnoModel.Image = pictureBox1.Image;
                PravokutnoModel.Output(Terenski_zapisnik.Models.Dionice.dionice[Terenski_zapisnik.Models.Dionice.activeIndex].DionicaModel);
            }
        }

        private void Š_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(š_textBox.Text, out double Š))
            {
                PravokutnoModel.Š = Š;
            }
        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(h_textBox.Text, out double H))
            {
                PravokutnoModel.H = H;
            }
        }
        private void d_textBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(d_textBox.Text, out double d))
            {
                PravokutnoModel.d = d;
            }
        }

        private void VizmjerenoTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(VizmjerenoTextBox.Text, out double VIzmj))
            {
                PravokutnoModel.VIzmjereno = VIzmj;
            }
        }

        private void TlakTextBox_TextChanged(object sender, EventArgs e)
        {
            if (Double.TryParse(TlakTextBox.Text, out double Tlak))
            {
                PravokutnoModel.IspitniTlak = Tlak;
            }
        }

        private void NazivDioniceTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoModel.DionicaNaziv = NazivDioniceTextBox.Text;
        }

        private void MaterijalTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoModel.DionicaMaterijal = MaterijalTextBox.Text;
        }

        private void PromjerTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoModel.DionicaPromjer = PromjerTextBox.Text;
        }

        private void StartTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoModel.VrijemePoc = StartTimeTextBox.Text;
        }

        private void EndTimeTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoModel.VrijemeEnd = EndTimeTextBox.Text;
        }
    }
}
