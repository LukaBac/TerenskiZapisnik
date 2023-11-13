using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Terenski_zapisnik.Sections;

namespace Terenski_zapisnik
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Form form = new InputForm();
            form.TopLevel = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();

            mainPanel.Controls.Add(form);
        }
    }
}
