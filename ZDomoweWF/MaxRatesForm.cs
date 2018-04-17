using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using ZDomoweWF.Properties;

namespace ZDomoweWF
{
    public partial class MaxRatesForm : ZDomoweWF.BaseForm
    {
        DownloadClass dC = new DownloadClass();
        List<MaxRateClass> allT = new List<MaxRateClass>();
        public MaxRatesForm()
        {
            InitializeComponent();

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            linkLabel1.Visible = false;
            label3.Visible = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            allT.Clear();

            foreach (var item in NodeListUri())
            {
                allT.AddRange(dC.AllTablesRates(item));

            }

            var combo1Code = (from p in allT
                              select new { p.eK, p.eN }).Distinct().ToList();
            comboBox1.DataSource = combo1Code;
            comboBox1.DisplayMember = "eN";
            comboBox1.ValueMember = "eK";
            comboBox1.SelectedValue = "";
            label4.Enabled = true;
            comboBox1.Enabled = true;
            label5.Enabled = true;
            comboBox2.Enabled = true;
            textBox1.Enabled = true;
            label6.Enabled = true;
            treeView1.ExpandAll();
        }

        private List<string> NodeListUri()
        {
            try
            {
                List<string> str = new List<string>();

                if (treeView1.Nodes.Count > 0)
                {
                    foreach (TreeNode n in treeView1.Nodes)
                    {
                        foreach (TreeNode ch in n.Nodes)
                        {
                            string t = ch.Name;
                            DateTime d;
                            try
                            {
                                d = Convert.ToDateTime(ch.Text.Substring(8, 10));
                                var webL = dC.tUri(t, d);
                                str.Add(webL);
                            }
                            catch (Exception)
                            {
                            }
                        }
                    }

                }
                return str;
            }
            catch (Exception)
            {
                return null;
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            try
            {
                var combo2Code = (from p in allT
                                  where p.eK == comboBox1.SelectedValue.ToString()
                                  select new { p.aK, p.aKn }).Distinct().ToList();
                comboBox2.DataSource = combo2Code;
                comboBox2.DisplayMember = "aKn";
                comboBox2.ValueMember = "aK";
                UpdateBoxAndMax();
            }
            catch (Exception)
            {

            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateBoxAndMax();
        }

        private void UpdateBoxAndMax()
        {
            try
            {
                var k = (from p in allT
                         where p.eK == comboBox1.SelectedValue.ToString() && p.aK == (short)comboBox2.SelectedValue
                         select p).ToList();
                listBox1.Items.Clear();

                foreach (var item in k)
                {
                    listBox1.Items.Add("Tabela " + item.tType.ToUpper() + " | " + item.tDatePub + " | " + item.eK + " | " + item.eV + " | " + item.aKn);
                }
                textBox1.Text = k.Max(v => v.eV).ToString();
            }
            catch (Exception)
            {
            }
        }

        private void MaxRatesForm_Load(object sender, EventArgs e)
        {
            label4.Enabled = false;
            label5.Enabled = false;
            label6.Enabled = false;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
            textBox1.Enabled = false;
          
          
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBoxAndMax();
        }

    }
}