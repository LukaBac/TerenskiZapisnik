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
    public partial class DionicaPravokutno : Form, IForm
    {
        public PravokutnoModel PravokutnoModel = new PravokutnoModel();


        public DionicaPravokutno()
        {
            InitializeComponent();

            PravokutnoModel.Image = pictureBox1.Image;
        }

        private void LostFocus(object sender, EventArgs e)
        {
            //if (š_textBox.Text != "" && h_textBox.Text != "" && d_textBox.Text != "" && VizmjerenoTextBox.Text != "" && TlakTextBox.Text != "" && StartTimeTextBox.Text != "" && EndTimeTextBox.Text != "" && NazivDioniceTextBox.Text != "" && PromjerTextBox.Text != "" && MaterijalTextBox.Text != "")
            //{
            //    PravokutnoModel.Image = pictureBox1.Image;
            //    PravokutnoModel.Output(Terenski_zapisnik.Models.Dionice.dionice[Terenski_zapisnik.Models.Dionice.activeIndex].DionicaModel);
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
            PravokutnoModel.Š_Text = š_textBox.Text;
        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoModel.H_Text = h_textBox.Text;
        }
        private void d_textBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoModel.d_Text = d_textBox.Text;
        }

        private void VizmjerenoTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoModel.VIzmjereno_Text = VizmjerenoTextBox.Text;
        }

        private void TlakTextBox_TextChanged(object sender, EventArgs e)
        {
            PravokutnoModel.IspitniTlak_Text = TlakTextBox.Text;
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

        public IModel ReturnModel()
        {
            return PravokutnoModel;
        }
    }
}
