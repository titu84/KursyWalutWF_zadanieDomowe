using System;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using ZDomoweWF.Properties;
namespace ZDomoweWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void oProgramieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                (new AboutBox1()).Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();


        }

        private void daneZNbpplToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new WebTableForm()).Show();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DownloadClass dc1 = new DownloadClass();
            if (!dc1.NetTest())
            {
                label1.Text = "Nie znaleziono strony nbp.pl\n Sprawdź połączenie z internetem";
                label1.ForeColor = Color.Red;
                daneNBPToolStripMenuItem.Enabled = false;
            }
            if ((Settings.Default.FormSize.Width + Settings.Default.FormSize.Height) > 0)
            {
                this.ClientSize = Settings.Default.FormSize;
            }
        }

        private void pokazTabeleZDyskuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                DownloadClass dC = new DownloadClass();
                FileTableForm fTF = new FileTableForm();
                fTF.Show();
                fTF.tableRatesControl1.typeTextBox.Text = dC.FileTableType(filename);
                fTF.Text = "Tabela z: " + filename;
                if (fTF.tableRatesControl1.typeTextBox.Text == "a" || fTF.tableRatesControl1.typeTextBox.Text == "b")
                {
                    var elem = dC.CurrentTableAB(filename);
                    foreach (var item in elem)
                    {
                        fTF.tableRatesControl1.dataGridView1.Rows.Add(item.nazwa_waluty, item.kod_waluty, item.kurs_sredni, item.przelicznik, "0,0000", 0);

                    }
                }
                else if (fTF.tableRatesControl1.typeTextBox.Text == "c")
                {
                    var elem = dC.CurrentTableC(filename);
                    foreach (var item in elem)
                    {
                        fTF.tableRatesControl1.dataGridView1.Rows.Add(item.nazwa_waluty, item.kod_waluty, item.kurs_kupna, item.kurs_sprzedazy, item.przelicznik, "0,0000", "0,0000", 0);
                    }
                }
            }

        }

        private void najwyzszyKursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            (new MaxRatesForm()).Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.FormSize = this.ClientSize;
            Settings.Default.Save();
        }

    }
}
