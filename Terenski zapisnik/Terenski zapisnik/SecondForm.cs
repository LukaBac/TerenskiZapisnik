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
using Terenski_zapisnik.Sections;

namespace Terenski_zapisnik
{
    public partial class SecondForm : Form
    {
        public SecondForm()
        {
            InitializeComponent();

            ProjectNameLabel.Text = ProjectModel.ProjectName;
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            #region Setting Values

            if (KupacTextBox.Text != "" && LokacijaTextBox.Text != "" && KupacTextBox.Text != "" && RadniNalogTextBox.Text != "" && DatumTextBox.Text != "" && IspitivacTextBox.Text != "" && VoditeljTextBox.Text != "")
            {
                ProjectModel.Kupac = KupacTextBox.Text;
                ProjectModel.Lokacija = LokacijaTextBox.Text;
                ProjectModel.RadniNalog = RadniNalogTextBox.Text;
                ProjectModel.Datum = DatumTextBox.Text;
                //ProjectModel.Datum = DateTime.Parse(DatumTextBox.Text);
                ProjectModel.Ispitivac = IspitivacTextBox.Text;
                ProjectModel.Voditelj = VoditeljTextBox.Text;

                #endregion

                Panel mainPanel = (Panel)this.Parent;

                Form form = new DionicaForm();
                form.TopLevel = false;
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();


                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(form);
            }
        }
    }
}
