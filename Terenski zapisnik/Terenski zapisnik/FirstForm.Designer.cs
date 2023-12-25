namespace Terenski_zapisnik
{
    partial class FirstForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.newProject_Btn = new System.Windows.Forms.Button();
            this.contentPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.imeTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(368, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(399, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Terenski Zapisnik";
            // 
            // newProject_Btn
            // 
            this.newProject_Btn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.newProject_Btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newProject_Btn.Location = new System.Drawing.Point(3, 122);
            this.newProject_Btn.Margin = new System.Windows.Forms.Padding(3, 50, 3, 3);
            this.newProject_Btn.Name = "newProject_Btn";
            this.newProject_Btn.Size = new System.Drawing.Size(162, 45);
            this.newProject_Btn.TabIndex = 1;
            this.newProject_Btn.Text = "Novi Projekt";
            this.newProject_Btn.UseVisualStyleBackColor = true;
            this.newProject_Btn.Click += new System.EventHandler(this.newProject_Btn_Click);
            // 
            // contentPanel
            // 
            this.contentPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.contentPanel.Controls.Add(this.newProject_Btn);
            this.contentPanel.Controls.Add(this.imeTextBox);
            this.contentPanel.Controls.Add(this.label2);
            this.contentPanel.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.contentPanel.Location = new System.Drawing.Point(480, 261);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(168, 170);
            this.contentPanel.TabIndex = 2;
            // 
            // imeTextBox
            // 
            this.imeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imeTextBox.Location = new System.Drawing.Point(3, 43);
            this.imeTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.imeTextBox.Name = "imeTextBox";
            this.imeTextBox.Size = new System.Drawing.Size(162, 26);
            this.imeTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Naziv:";
            // 
            // FirstForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1178, 750);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.label1);
            this.Name = "FirstForm";
            this.Text = "FirstForm";
            this.contentPanel.ResumeLayout(false);
            this.contentPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button newProject_Btn;
        private System.Windows.Forms.FlowLayoutPanel contentPanel;
        private System.Windows.Forms.TextBox imeTextBox;
        private System.Windows.Forms.Label label2;
    }
}