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
    public partial class MainForm : Form
    {
        private List<Button> NavButtons = new List<Button>();

        public MainForm()
        {
            InitializeComponent();
            label1.Text = ProjectModel.ProjectName;


            #region styling
            NavButtons.Add(OknoBtn);
            NavButtons.Add(OknoCijevBtn);
            NavButtons.Add(PravokutnoBtn);
            NavButtons.Add(PravokutnoCijevBtn);

            Form form = new InputForm();
            form.TopLevel = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();

            OknoBtn.BackColor = Color.FromArgb(255, 71, 80, 122);
            OknoBtn.ForeColor = Color.White;

            #endregion

            OknoCijevBtn.Focus();
            OknoCijevBtn.PerformClick();

            mainPanel.Controls.Add(form);
        }

        public void NavButtonClick(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;

            clickedBtn.BackColor = Color.White;
            clickedBtn.ForeColor = Color.Black;

            foreach (Button btn in NavButtons)
            {
                if (btn != clickedBtn) {
                    //btn.BackColor = Color.FromArgb(38, 43, 66, 255);
                    btn.BackColor = Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(43)))), ((int)(((byte)(66)))));
                    btn.ForeColor = Color.White;
                }
            }
        }
    }
}
