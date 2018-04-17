using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;
using ZDomoweWF.Properties;

namespace ZDomoweWF
{
    public partial class WebTableForm : ZDomoweWF.BaseForm
    {
        public WebTableForm()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            button3.Enabled = false;
            tableRatesControl1.typeTextBox.Text = "";
            tableRatesControl1.typeTextBox.Text = treeView1.SelectedNode.Name;

            DownloadClass dC = new DownloadClass();
            try
            {
                if (treeView1.SelectedNode.Name == "a" && treeView1.SelectedNode.Text != "TabeleA" || treeView1.SelectedNode.Name == "b" && treeView1.SelectedNode.Text != "TabeleB")
                {
                    var elem = dC.CurrentTableAB(linkLabel1.Text);
                    foreach (var item in elem)
                    {
                        tableRatesControl1.dataGridView1.Rows.Add(item.nazwa_waluty, item.kod_waluty, item.kurs_sredni, item.przelicznik, "0,0000", 0);
                        button3.Enabled = true;
                    }
                }
                else if (treeView1.SelectedNode.Name == "c" && treeView1.SelectedNode.Text != "TabeleC")
                {
                    var elem = dC.CurrentTableC(linkLabel1.Text);
                    foreach (var item in elem)
                    {
                        tableRatesControl1.dataGridView1.Rows.Add(item.nazwa_waluty, item.kod_waluty, item.kurs_kupna, item.kurs_sprzedazy, item.przelicznik, "0,0000", "0,0000", 0);

                        button3.Enabled = true;


                    }
                }
            }
            catch
            {
                button3.Enabled = false;
            }
        }


        private void treeView1_ParentChanged(object sender, EventArgs e)
        {
            tableRatesControl1.typeTextBox.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = linkLabel1.Text.Substring(28, 15);
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = saveFileDialog1.FileName;
                XDocument dokXML = XDocument.Load(linkLabel1.Text);
                dokXML.Save(filename);
                MessageBox.Show("Zapisano tabelę");
            }

        }

        private void treeView1_BackColorChanged(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }


    }
}

