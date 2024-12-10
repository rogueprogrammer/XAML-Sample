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
            LoadEnvironmentList();
            // Preload data into the DataGrid for the first environment.
            LoadEnvironmentData("Environment A");
        }

        private void LoadEnvironmentList()
        {
            var environments = new List<string>
            {
                "Environment A",
                "Environment B"
            };
            EnvironmentListView.ItemsSource = environments;
        }

        private void EnvironmentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnvironmentListView.SelectedItem is string selectedEnvironment)
            {
                LoadEnvironmentData(selectedEnvironment);
            }
        }

        private void LoadEnvironmentData(string environmentName)
        {
            var data = new List<MachineData>();
            if (environmentName == "Environment A")
            {
                data.Add(new MachineData { Id = "A1", Status = "Healthy" });
            }
            else if (environmentName == "Environment B")
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
