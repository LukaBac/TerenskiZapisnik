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
    public partial class DionicaOkrCijev : Form, IForm
    {

        OkrugloCijevModel OkrugloCijevModel = new OkrugloCijevModel();

        public DionicaOkrCijev()
        {
            InitializeComponent();

            OkrugloCijevModel.Image = pictureBox1.Image;
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

        private void LostFocus(object sender, EventArgs e)
        {
            //if (R_textBox.Text != "" && H_textBox.Text != "" && L_textBox.Text != "" && R2_textBox.Text != "" && VizmjerenoTextBox.Text != "" && TlakTextBox.Text != "" && StartTimeTextBox.Text != "" && EndTimeTextBox.Text != "" && NazivDioniceTextBox.Text != "" && PromjerTextBox.Text != "" && MaterijalTextBox.Text != "")
            //{
            //    OkrugloCijevModel.Image = pictureBox1.Image;
            //    OkrugloCijevModel.Output(Terenski_zapisnik.Models.Dionice.dionice[Terenski_zapisnik.Models.Dionice.activeIndex].DionicaModel);
            //}
        }

        private void R_textBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.R_Text = R_textBox.Text;
        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.H_Text = H_textBox.Text;
        }

        private void L_textBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.L_Text = L_textBox.Text;
        }

        private void R2_textBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.r_Text = R2_textBox.Text;
        }

        private void VizmjerenoTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.VIzmjereno_Text = VizmjerenoTextBox.Text;
        }

        private void TlakTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloCijevModel.IspitniTlak_Text = TlakTextBox.Text;
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

        public IModel ReturnModel()
        {
            return OkrugloCijevModel;
        }
    }
}
