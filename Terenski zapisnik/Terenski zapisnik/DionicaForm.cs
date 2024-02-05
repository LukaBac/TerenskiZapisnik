using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using Terenski_zapisnik.Models;
using Terenski_zapisnik.Sections;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Terenski_zapisnik.Sections.Dionice;

namespace Terenski_zapisnik
{
    public partial class DionicaForm : Form
    {

        private List<Button> NavButtons = new List<Button>();
        public string checkedBtn = "";

        public DionicaForm()
        {
            InitializeComponent();
            DionicaNameTextBox.Text = "";

            NavButtons.Add(OkrugloBtn);
            NavButtons.Add(OkrugloCijevBtn);
            NavButtons.Add(PravokutnoBtn);
            NavButtons.Add(Pravokutno2Btn);

            projectNameLabel.Text = ProjectModel.ProjectName;
        }

        private void AddDionicaBtn_Click(object sender, EventArgs e)
        {

            #region AddButton
            Button btn = new Button();
            btn.Size = new Size(184, 64);
            btn.Click += new System.EventHandler(this.DionicaBtn_Click);

            btn.BackColor = System.Drawing.Color.FromArgb(38, 43, 66);
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Text = $"Dionica {Dionice.dionice.Count() + 1}";
            btn.FlatAppearance.BorderSize = 0;
            #endregion

            #region AddForm

            Form form = new Form();

            switch (checkedBtn)
            {
                case "OkrugloBtn":
                    form = new DionicaOkruglo();
                    break;
                case "OkrugloCijevBtn":
                    form = new DionicaOkrCijev();
                    break;
                case "PravokutnoBtn":
                    form = new DionicaPravokutno();
                    break;
                case "Pravokutno2Btn":
                    form = new DionicaPravokutnoCijev();
                    break;
                default:
                    form = new DionicaOkruglo();
                    break;
            }

            form.TopLevel = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();

            if (checkedBtn != "")
            {
                Dionice.dionice.Add(new Dionica(btn.Text, checkedBtn, form, new DionicaModel()));
            }

            else
            {
                Dionice.dionice.Add(new Dionica(btn.Text, "OkrugloBtn", form, new DionicaModel()));
            }
            dionicaPanel.Controls.Add(btn);
            #endregion
        }

        private void DionicaBtn_Click(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;
            Dionice.activeIndex = dionicaPanel.Controls.IndexOf(clickedBtn);
            DionicaNameTextBox.Text = clickedBtn.Text;

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(Dionice.dionice[Dionice.activeIndex].Forma);

            foreach (Button b in NavButtons)
            {
                if (b.Name == Dionice.dionice[Dionice.activeIndex].Type)
                {
                    setNavButton(b);
                }
            }

        }

        private void addForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Show();
            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(form);
        }

        public void NavButtonClick(object sender, EventArgs e)
        {
            Button clickedBtn = (Button)sender;

            if (checkedBtn != clickedBtn.Name)
            {
                setNavButton(clickedBtn);

                Form form = new Form();
                switch (checkedBtn)
                {
                    case "OkrugloBtn":
                        form = new DionicaOkruglo();
                        break;
                    case "OkrugloCijevBtn":
                        form = new DionicaOkrCijev();
                        break;
                    case "PravokutnoBtn":
                        form = new DionicaPravokutno();
                        break;
                    case "Pravokutno2Btn":
                        form = new DionicaPravokutnoCijev();
                        break;
                    default:
                        form = new DionicaOkruglo();
                        break;
                }
                form.TopLevel = false;
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();

                if (mainPanel.Controls.Count == 0)
                {
                    AddDionicaBtn.PerformClick();
                    DionicaNameTextBox.Text = dionicaPanel.Controls[Dionice.activeIndex].Text;
                }
                else if(Dionice.dionice.Count != 0 && mainPanel.Controls.Count != 0)
                {
                    Dionice.dionice[Dionice.activeIndex].Type = checkedBtn;
                    Dionice.dionice[Dionice.activeIndex].Forma = form;
                    Dionice.dionice[Dionice.activeIndex].DionicaModel = new DionicaModel();
                }
                mainPanel.Controls.Clear();
                mainPanel.Controls.Add(form);
            }
        }

        private void setNavButton(Button clickedBtn)
        {
            clickedBtn.BackColor = System.Drawing.Color.White;
            clickedBtn.ForeColor = System.Drawing.Color.Black;

            checkedBtn = clickedBtn.Name;

            foreach (Button btn in NavButtons)
            {
                if (btn != clickedBtn)
                {
                    btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(166)))));
                    btn.ForeColor = System.Drawing.Color.White;
                }
            }
        }


        private void SaveBtn_Click(object sender, EventArgs e)
        {
            Dionice.dionice[Dionice.activeIndex].DionicaModel.Ispis();
        }

        private void DionicaNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (dionicaPanel.Controls.Count != 0 && mainPanel.Controls.Count != 0)
            {
                dionicaPanel.Controls[Dionice.activeIndex].Text = DionicaNameTextBox.Text;
                Dionice.dionice[Dionice.activeIndex].Name = DionicaNameTextBox.Text;
            }

            if (DionicaNameTextBox.Text == "")
            {
                DionicaNameTextBox.Focus();
            }
        }

        private void DeleteFormBtn_Click(object sender, EventArgs e)
        {
            if (Dionice.dionice.Count != 0 && mainPanel.Controls.Count > 0)
            {
                mainPanel.Controls.Clear();
                Dionice.dionice.RemoveAt(Dionice.activeIndex);
                dionicaPanel.Controls.RemoveAt(Dionice.activeIndex);
                DionicaNameTextBox.Text = "";
                if (Dionice.activeIndex != 0)
                {
                    Dionice.activeIndex = dionicaPanel.Controls.Count - 1;
                }
                mainPanel.Focus();
                #region resetNavButton
                foreach (Button btn in NavButtons)
                {
                    btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(166)))));
                    btn.ForeColor = System.Drawing.Color.White;
                    checkedBtn = "";
                }
                #endregion
            }
        }
    }
}
