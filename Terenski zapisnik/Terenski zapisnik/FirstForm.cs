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
    public partial class FirstForm : Form
    {
        private MainContainer mainFormReference;
        public FirstForm()
        {
            InitializeComponent();
            contentPanel.Size = new System.Drawing.Size(168, 60);

            //Control parent = this.Parent;
            //while (parent != null && !(parent is MainContainer))
            //{
            //    parent = parent.Parent;
            //}

            //this.mainFormReference = parent as MainContainer;

            //mainFormReference.Size = new Size(300, 500);
        }

        private void newProject_Btn_Click(object sender, EventArgs e)
        {
            contentPanel.Size = new System.Drawing.Size(168, 160);
            contentPanel.Location = new System.Drawing.Point(480, 261);

            newProject_Btn.Text = "Dalje";

            if (imeTextBox.Text != "" && newProject_Btn.Text == "Dalje")
            {
                ProjectModel.ProjectName = imeTextBox.Text;

                Panel mainPanel = (Panel)this.Parent;

                Form form = new SecondForm();
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
