using System;
using System.Drawing;
using System.Windows.Forms;
using ZDomoweWF.Properties;

namespace ZDomoweWF
{
    public partial class BaseForm : Form
    {
        DownloadClass dC = new DownloadClass();
        private DateTime FromDate;
        private DateTime ToDate;

        public BaseForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            dateControl1.dateTimePicker1.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            label2.Text = "Masz dostęp do tabel z roku " + DateTime.Now.Year.ToString();
            try
            {
                toolStripStatusLabel2.Text = PublicationClass.TableACpublication("a");
                toolStripStatusLabel6.Text = PublicationClass.TableACpublication("c");
                toolStripStatusLabel4.Text = PublicationClass.TableBpublication();
            }
            catch (Exception)
            {
            }
           
        }

        private void AddNode(string t)
        {
            var mainGroup = treeView1.Nodes.Add(t, "Tabele" + t.ToUpper());
            foreach (var item in dC.TypedOfT(t, FromDate, ToDate))
            {
                mainGroup.Nodes.Add(item.tType, "Z dnia: " + item.tDatePub.ToShortDateString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!tableSelectControl1.checkBox1.Checked && !tableSelectControl1.checkBox2.Checked && !tableSelectControl1.checkBox3.Checked)
            {
                UpdateTreWiew();
                treeView1.BackColor = Color.Azure;
                treeView1.BackColor = SystemColors.Window;
                MessageBox.Show("Wybierz conajmniej jedną tabelę");
            }
            else
            {
                UpdateTreWiew();
                treeView1.BackColor = SystemColors.Window;
                treeView1.BackColor = Color.Azure;
            }

        }

        private void UpdateTreWiew()
        {
            label3.Visible = false;
            linkLabel1.Visible = false;
            FromDate = this.dateControl1.dateTimePicker1.Value;
            ToDate = this.dateControl1.dateTimePicker2.Value;
            string t;
            treeView1.Nodes.Clear();

            if (tableSelectControl1.checkBox1.Checked)
            {
                t = "a";
                AddNode(t);
            }
            if (tableSelectControl1.checkBox2.Checked)
            {
                t = "b";
                AddNode(t);
            }
            if (tableSelectControl1.checkBox3.Checked)
            {
                t = "c";
                AddNode(t);
            }
            treeView1.Sort();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var q = dC.tUri("a", DateTime.Now);
            MessageBox.Show(q);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string t = e.Node.Name;
            DateTime d;
            try
            {
                d = Convert.ToDateTime(e.Node.Text.Substring(8, 10));
                var webA = dC.tUri(t, d);
                label3.Visible = true;
                linkLabel1.Visible = true;
                linkLabel1.Text = webA;
            }
            catch (Exception)
            {
            }
        }
        // Otwiera tabelę w przegladarce.
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabel1.LinkVisited = true;
            System.Diagnostics.Process.Start(linkLabel1.Text);
        }
    }
}



