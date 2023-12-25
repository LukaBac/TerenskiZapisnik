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
    public partial class MainContainer : Form
    {
        public MainContainer()
        {
            InitializeComponent();

            #region styling
            Form form = new FirstForm();
            form.TopLevel = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(form);

            #endregion

        }

    }
}
