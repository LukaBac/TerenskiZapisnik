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
            //Form form = new Dionica();
            //form.TopLevel = false;
            //form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            //form.Dock = DockStyle.Fill;
            //form.Show();

            //mainPanel.Controls.Clear();
            //mainPanel.Controls.Add(form);

            Button btn = new Button();
            btn.Size = new Size(184, 64);
            btn.Click += new System.EventHandler(this.DionicaBtn_Click);

            btn.BackColor = System.Drawing.Color.FromArgb(38, 43, 66);
            btn.FlatStyle = FlatStyle.Flat;
            btn.ForeColor = System.Drawing.Color.White;
            btn.Text = $"Dionica {Dionice.dionice.Count() + 1}";
            btn.FlatAppearance.BorderSize = 0;

            Dionice.dionice.Add(new OkrugloModel(btn.Text, "OkrugloBtn"));
            dionicaPanel.Controls.Add(btn);
        }

        private void DionicaBtn_Click(object sender, EventArgs e)
        {
            //Form form = new Dionica2();
            //addForm(form);

            //OkrugloBtn.PerformClick();

            Button clickedBtn = (Button)sender;
            //activeIndex = dionicaPanel.Controls.IndexOf(clickedBtn);
            Dionice.activeIndex = dionicaPanel.Controls.IndexOf(clickedBtn);
            DionicaNameTextBox.Text = clickedBtn.Text;
            //Dionice.dionice[index];
            foreach (Button b in NavButtons)
            {
                if (b.Name == Dionice.dionice[Dionice.activeIndex].DionicaTip)
                {
                    b.PerformClick();
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
                clickedBtn.BackColor = System.Drawing.Color.White;
                clickedBtn.ForeColor = System.Drawing.Color.Black;

                checkedBtn = clickedBtn.Name;

                foreach (Button btn in NavButtons)
                {
                    if (btn != clickedBtn)
                    {
                        //btn.BackColor = Color.FromArgb(38, 43, 66, 255);
                        btn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(61)))), ((int)(((byte)(82)))), ((int)(((byte)(166)))));
                        btn.ForeColor = System.Drawing.Color.White;
                    }
                }

                Form form = null;
                switch (checkedBtn)
                {
                    case "OkrugloBtn":
                        form = new DionicaOkruglo();
                        Dionice.dionice[Dionice.activeIndex] = null;
                        Dionice.dionice[Dionice.activeIndex] = new OkrugloModel(DionicaNameTextBox.Text, "OkrugloBtn");
                        break;
                    case "OkrugloCijevBtn":
                        form = new DionicaOkrCijev();
                        Dionice.dionice[Dionice.activeIndex] = null;
                        Dionice.dionice[Dionice.activeIndex] = new OkrugloModel(DionicaNameTextBox.Text, "OkrugloBtn");
                        break;
                    default:
                        form = new DionicaOkrCijev();
                        Dionice.dionice[Dionice.activeIndex].DionicaTip = "OkrugloCijevBtn";
                        break;
                }
                addForm(form);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Word Documents|*.docx";
            saveFileDialog.Title = "Spremi zapis";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;

                // Create a .docx file
                using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, WordprocessingDocumentType.Document))
                {
                    MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                    mainPart.Document = new Document();
                    DocumentFormat.OpenXml.Wordprocessing.Body body = new DocumentFormat.OpenXml.Wordprocessing.Body();
                    Paragraph paragraph = new Paragraph(new Run(new DocumentFormat.OpenXml.Wordprocessing.Text("Hello, this is a sample document.")));
                    body.Append(paragraph);
                    mainPart.Document.Append(body);
                }

                MessageBox.Show($"File saved successfully: {filePath}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DionicaNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (dionicaPanel.Controls.Count != 0)
            {
                dionicaPanel.Controls[Dionice.activeIndex].Text = DionicaNameTextBox.Text;
            }

            if (DionicaNameTextBox.Text == "")
            {
                DionicaNameTextBox.Focus();
            }
        }
    }
}
