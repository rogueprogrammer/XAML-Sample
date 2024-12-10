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
            LoadEnvironmentData("A");
        }

        private void LoadEnvironmentList()
        {
            var environments = new List<EnvironmentItem>
            {
                new EnvironmentItem { Name = "Environment A", Tag = "A" },
                new EnvironmentItem { Name = "Environment B", Tag = "B" }
            };
            EnvironmentListView.ItemsSource = environments;
        }

        private void EnvironmentListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (EnvironmentListView.SelectedItem is EnvironmentItem selectedEnvironment)
            {
                LoadEnvironmentData(selectedEnvironment.Tag);
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

        public class EnvironmentItem
        {
            public string Name { get; set; }
            public string Tag { get; set; }
        }

        public class MachineData
        {
            public string Id { get; set; }
            public string Status { get; set; }
        }
    }
}
