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
    public partial class TableSelectControl : UserControl
    {
        public TableSelectControl()
        {
            InitializeComponent();
        }

        private void TableSelectControl_Load(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
            checkBox2.Checked = true;
            checkBox3.Checked = true;
        }

      
    }
}
