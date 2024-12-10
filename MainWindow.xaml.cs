using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WPFTestProject
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Preload data into the DataGrid for the first environment.
            LoadEnvironmentData("A");
        }

        private void EnvironmentListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnvironmentListBox.SelectedItem is ListBoxItem selectedItem)
            {
                string environment = selectedItem.Tag.ToString();
                LoadEnvironmentData(environment);
            }
        }

        private void LoadEnvironmentData(string environment)
        {
            var data = new List<MachineData>();
            if (environment == "A")
            {
                data.Add(new MachineData { Id = "A1", Status = "Healthy" });
            }
            else if (environment == "B")
            {
                data.Add(new MachineData { Id = "B1", Status = "Faulted" });
            }

            DetailsDataGrid.ItemsSource = data;
        }

        public class MachineData
        {
            public string Id { get; set; }
            public string Status { get; set; }
        }
    }
}
