using System;
using System.Windows.Forms;

namespace ZDomoweWF
{
    public partial class DateControl : UserControl
    {
        public DateControl()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
          DateTime minDate = new DateTime(DateTime.Today.Year,1,1);

            if (this.dateTimePicker1.Value<minDate)
            {
                MessageBox.Show("Data minimalna nie może być mniejsza niż 1 stycznia br.");
                this.dateTimePicker1.Value = minDate;
            }

            else if (this.dateTimePicker1.Value >= DateTime.Today.AddDays(1))
            {
                MessageBox.Show("Ustawienie daty początkowj na później niż dziś nie ma sensu...");
                this.dateTimePicker1.Value = DateTime.Today;
            }
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            DateValid();
        }

        private void DateValid()
        {
            if (this.dateTimePicker2.Value < this.dateTimePicker1.Value)
            {
                MessageBox.Show("Błędny przedział dat.");
                this.dateTimePicker2.Value = this.dateTimePicker1.Value.AddDays(1);
            }
        }

        private void DateControl_Leave(object sender, EventArgs e)
        {
            DateValid();
        }
    }
}
