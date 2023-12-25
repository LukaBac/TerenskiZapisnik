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
        public DionicaOkruglo()
        {
            InitializeComponent();

            R_textBox.Text = Dionice.dionice[Dionice.activeIndex].R.ToString();
            H_textBox.Text = Dionice.dionice[Dionice.activeIndex].H.ToString();
        }

        private void R_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dionice.dionice[Dionice.activeIndex].R = Convert.ToDouble(R_textBox.Text);
            }
            catch
            {

            }
        }

        private void H_textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Dionice.dionice[Dionice.activeIndex].H = Convert.ToDouble(H_textBox.Text);
            }
            catch
            {

            }
        }
    }
}
