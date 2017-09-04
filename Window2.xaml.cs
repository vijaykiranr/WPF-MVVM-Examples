using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfSample
{
    /// <summary>
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {

        public TaskDetail CurrentRecord { get; set; }
        
        public Window2(TaskDetail record = null)
        {
            InitializeComponent();
            CurrentRecord = (record != null) ? new TaskDetail { Id = record.Id, PlanName = record.PlanName, TaskTitle = record.TaskTitle, Bucket = record.Bucket, Progress = record.Progress, AssignedTo = "null", StartDate = record.StartDate, DueDate = record.DueDate, Label = record.Label } : new TaskDetail { Id = "1" };
            this.DataContext = CurrentRecord;
        }

        
        private void DatePicker_SelectedDateChanged(object sender,
               SelectionChangedEventArgs e)
        {
            // ... Get DatePicker reference.
            var picker = sender as DatePicker;

            // ... Get nullable DateTime from SelectedDate.
            DateTime? date = picker.SelectedDate;
            if (date == null)
            {
                // ... A null object.
                this.Title = "No date";
            }
            else
            {
                // ... No need to display the time.
                this.Title = date.Value.ToShortDateString();
            }
        }

        private void Edit_Save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(CurrentRecord.Id) || string.IsNullOrEmpty(CurrentRecord.PlanName) || string.IsNullOrEmpty(CurrentRecord.TaskTitle) || string.IsNullOrEmpty(CurrentRecord.Bucket) || string.IsNullOrEmpty(CurrentRecord.Progress) || string.IsNullOrEmpty(CurrentRecord.StartDate) || string.IsNullOrEmpty(CurrentRecord.DueDate) || string.IsNullOrEmpty(CurrentRecord.Label))
            {
                MessageBox.Show("Please Enter All the Fields...");
            }
            else
            {
                this.DialogResult = true;
            }
        }
    }
}
