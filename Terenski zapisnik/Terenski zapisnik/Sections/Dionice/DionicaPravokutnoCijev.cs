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
    public partial class DionicaPravokutnoCijev : Form, IForm
    {
        PravokutnoCijevModel PravokutnoCijevModel = new PravokutnoCijevModel();

        public DionicaPravokutnoCijev()
        {
            InitializeComponent();

            PravokutnoCijevModel.Image = pictureBox1.Image;
        }

        private void LostFocus(object sender, EventArgs e)
        {
            //if (š_textBox.Text != "" && h_textBox.Text != "" && d_textBox.Text != "" && L_textBox.Text != "" && r_textBox.Text != "" && VizmjerenoTextBox.Text != "" && TlakTextBox.Text != "" && StartTimeTextBox.Text != "" && EndTimeTextBox.Text != "" && NazivDioniceTextBox.Text != "" && PromjerTextBox.Text != "" && MaterijalTextBox.Text != "")
            //{
            //    PravokutnoCijevModel.Image = pictureBox1.Image;
            //    PravokutnoCijevModel.Output(Terenski_zapisnik.Models.Dionice.dionice[Terenski_zapisnik.Models.Dionice.activeIndex].DionicaModel);
            //}
        }

        private void KeyPressValidation(object sender, KeyPressEventArgs e)
        {
            // Check if the pressed key is not a digit or is not the backspace key
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
            {
                // Mark the event as handled to prevent the character from being entered
                e.Handled = true;
            }
        }

        private void Š_textBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.Š_Text = š_textBox.Text;
        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.H_Text = h_textBox.Text;

        }
        private void d_textBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.d_Text = d_textBox.Text;

        }

        private void L_textBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.L_Text = L_textBox.Text;

        }

        private void r_textBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.r_Text = r_textBox.Text;

        }

        private void VizmjerenoTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.VIzmjereno_Text = VizmjerenoTextBox.Text;

        }

        private void TlakTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoCijevModel.IspitniTlak_Text = TlakTextBox.Text;
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

        public IModel ReturnModel()
        {
            return PravokutnoCijevModel;
        }
    }
}
