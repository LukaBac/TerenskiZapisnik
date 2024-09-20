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
    public partial class DionicaOkruglo : Form, IForm
    {

        OkrugloModel OkrugloModel = new OkrugloModel();


        public DionicaOkruglo()
        {
            InitializeComponent();

            OkrugloModel.Image = pictureBox1.Image;
        }

        private void LostFocus(object sender, EventArgs e)
        {
            //if (R_textBox.Text != "" && H_textBox.Text != "" && VizmjerenoTextBox.Text != "" && TlakTextBox.Text != "" && StartTimeTextBox.Text != "" && EndTimeTextBox.Text != "" && NazivDioniceTextBox.Text != "" && PromjerTextBox.Text != "" && MaterijalTextBox.Text != "")
            //{
            //    OkrugloModel.Image = pictureBox1.Image;
            //    OkrugloModel.Output(Terenski_zapisnik.Models.Dionice.dionice[Terenski_zapisnik.Models.Dionice.activeIndex].DionicaModel);
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

        private void R_textBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloModel.R_Text = R_textBox.Text;

        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloModel.H_Text = H_textBox.Text;
        }

        private void VizmjerenoTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloModel.VIzmjereno_Text = VizmjerenoTextBox.Text;
        }

        private void TlakTextBox_TextChanged(object sender, EventArgs e)
        {
            OkrugloModel.IspitniTlak_Text = TlakTextBox.Text;
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

        public IModel ReturnModel()
        {
            return OkrugloModel;
        }
    }
}
