namespace ZDomoweWF
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.daneNBPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daneZNbpplToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pokazTabeleZDyskuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.najwyzszyKursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.oProgramieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.daneNBPToolStripMenuItem,
            this.oProgramieToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // daneNBPToolStripMenuItem
            // 
            this.daneNBPToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.daneZNbpplToolStripMenuItem,
            this.pokazTabeleZDyskuToolStripMenuItem,
            this.najwyzszyKursToolStripMenuItem});
            this.daneNBPToolStripMenuItem.Name = "daneNBPToolStripMenuItem";
            this.daneNBPToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.daneNBPToolStripMenuItem.Text = "Menu";
            // 
            // daneZNbpplToolStripMenuItem
            // 
            this.daneZNbpplToolStripMenuItem.Name = "daneZNbpplToolStripMenuItem";
            this.daneZNbpplToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.daneZNbpplToolStripMenuItem.Text = "Pokaż tabele z NBP";
            this.daneZNbpplToolStripMenuItem.Click += new System.EventHandler(this.daneZNbpplToolStripMenuItem_Click);
            // 
            // pokazTabeleZDyskuToolStripMenuItem
            // 
            this.pokazTabeleZDyskuToolStripMenuItem.Name = "pokazTabeleZDyskuToolStripMenuItem";
            this.pokazTabeleZDyskuToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.pokazTabeleZDyskuToolStripMenuItem.Text = "Pokaż tabelę z dysku";
            this.pokazTabeleZDyskuToolStripMenuItem.Click += new System.EventHandler(this.pokazTabeleZDyskuToolStripMenuItem_Click);
            // 
            // najwyzszyKursToolStripMenuItem
            // 
            this.najwyzszyKursToolStripMenuItem.Name = "najwyzszyKursToolStripMenuItem";
            this.najwyzszyKursToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.najwyzszyKursToolStripMenuItem.Text = "Najwyższy kurs";
            this.najwyzszyKursToolStripMenuItem.Click += new System.EventHandler(this.najwyzszyKursToolStripMenuItem_Click);
            // 
            // oProgramieToolStripMenuItem
            // 
            this.oProgramieToolStripMenuItem.Name = "oProgramieToolStripMenuItem";
            this.oProgramieToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.oProgramieToolStripMenuItem.Text = "O programie";
            this.oProgramieToolStripMenuItem.Click += new System.EventHandler(this.oProgramieToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(77, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Program korzysta ze strony nbl.pl";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "XML files|*.xml";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 103);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Form1";
            this.Text = "NBP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem daneNBPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daneZNbpplToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pokazTabeleZDyskuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem oProgramieToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem najwyzszyKursToolStripMenuItem;
    }
}

