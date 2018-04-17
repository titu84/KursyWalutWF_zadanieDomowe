using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZDomoweWF
{
    public partial class TableRatesControl : UserControl
    {
        public TableRatesControl()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }



        private void TableRatesControl_Load(object sender, EventArgs e)
        {

            typeTextBox.Text = "";
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.EditMode = DataGridViewEditMode.EditOnEnter;

        }

        private void typeTextBox_TextChanged(object sender, EventArgs e)
        {
            switch (typeTextBox.Text)
            {
                case "":

                    dataGridView1.Columns.Clear();
                    dataGridView1.Rows.Clear();
                    break;
                case "a":
                    AddABColumns();
                    break;
                case "b":
                    AddABColumns();
                    break;
                case "c":
                    AddCColumns();
                    break;

                default:
                    break;
            }
        }

        private void AddCColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("c1", "Nazwa waluty");
            dataGridView1.Columns["c1"].Width = 110;
            dataGridView1.Columns["c1"].ReadOnly = true;
            dataGridView1.Columns.Add("c2", "Kod waluty");
            dataGridView1.Columns["c2"].Width = 50;
            dataGridView1.Columns["c2"].ReadOnly = true;
            dataGridView1.Columns.Add("c3", "Kurs kupna");
            dataGridView1.Columns["c3"].Width = 50;
            dataGridView1.Columns["c3"].ReadOnly = true;
            dataGridView1.Columns.Add("c6", "Kurs sprzedaży");
            dataGridView1.Columns["c6"].Width = 50;
            dataGridView1.Columns["c6"].ReadOnly = true;
            dataGridView1.Columns.Add("c4", "Przelicznik");
            dataGridView1.Columns["c4"].Width = 50;
            dataGridView1.Columns["c4"].ReadOnly = true;
            dataGridView1.Columns.Add("c5", "Złotych: kupna");
            dataGridView1.Columns["c5"].Width = 80;
            dataGridView1.Columns["c5"].ReadOnly = true;
            dataGridView1.Columns.Add("c7", "Złotych: sprzedaży");
            dataGridView1.Columns["c7"].Width = 80;
            dataGridView1.Columns["c7"].ReadOnly = true;
            dataGridView1.Columns.Add("c10", "Wartość");
            dataGridView1.Columns["c10"].ValueType = typeof(int);
        }

        private void AddABColumns()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Add("c1", "Nazwa waluty");
            dataGridView1.Columns["c1"].Width = 110;
            dataGridView1.Columns["c1"].ReadOnly = true;
            dataGridView1.Columns.Add("c2", "Kod waluty");
            dataGridView1.Columns["c2"].Width = 50;
            dataGridView1.Columns["c2"].ReadOnly = true;
            dataGridView1.Columns.Add("c3", "Kurs średni");
            dataGridView1.Columns["c3"].Width = 50;
            dataGridView1.Columns["c3"].ReadOnly = true;
            dataGridView1.Columns.Add("c4", "Przelicznik");
            dataGridView1.Columns["c4"].Width = 50;
            dataGridView1.Columns["c4"].ReadOnly = true;
            dataGridView1.Columns.Add("c5", "Złotych");
            dataGridView1.Columns["c5"].Width = 80;
            dataGridView1.Columns["c5"].ReadOnly = true;
            dataGridView1.Columns.Add("c10", "Wartość");
            dataGridView1.Columns["c10"].ValueType = typeof(int);
            
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
            int i = dataGridView1.CurrentRow.Index;
            decimal kS = Convert.ToDecimal(dataGridView1.Rows[i].Cells["c3"].Value);
                       decimal przel = Convert.ToDecimal(dataGridView1.Rows[i].Cells["c4"].Value);
            decimal wartosc = Convert.ToDecimal(dataGridView1.Rows[i].Cells["c10"].Value);
           
                if (dataGridView1.Columns["c3"].HeaderText == "Kurs kupna")
                {
                    decimal kSprzedazy = Convert.ToDecimal(dataGridView1.Rows[i].Cells["c6"].Value);
                    dataGridView1.Rows[i].Cells["c5"].Value = kS * wartosc / przel;
                    dataGridView1.Rows[i].Cells["c7"].Value = kSprzedazy * wartosc / przel;
                }
                else
                {
                    dataGridView1.Rows[i].Cells["c5"].Value = kS * wartosc / przel;
                }
            }
            catch 
            {
               
            }
           


        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            

                MessageBox.Show("Wartość musi być liczbą całkowitą");
                dataGridView1.CurrentCell.Value = 0;

            
        }


    }

}
