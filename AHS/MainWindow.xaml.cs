using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AHS
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		HospitalService service = new HospitalService();
		public MainWindow()
		{
			//American Hospital Simulator
			InitializeComponent();
			patientTable.ItemsSource = service.GetAll();
		}
		private void btnOpenForm(object sender, RoutedEventArgs e)
		{
			PatientForm patientForm = new PatientForm();
			patientForm.Closed += (_, _) =>
			{
				patientTable.ItemsSource = service.GetAll();
			};
			patientForm.ShowDialog();
		}
		private void btnReload(object sender, RoutedEventArgs e)
		{
			patientTable.ItemsSource = service.GetAll();
		}
		private void btnRemove(object sender, RoutedEventArgs e)
		{
			DataDef selected = patientTable.SelectedItem as DataDef;
			if (selected == null)
			{
				MessageBox.Show("To delete data, you MUST select an item from the list!");
				return;
			}
			MessageBoxResult result = MessageBox.Show($"Are you sure you want to delete {selected.patient}'s data from the list?", "Delete", MessageBoxButton.YesNo);
			if (result == MessageBoxResult.Yes)
			{
				if (!service.Delete(selected))
				{
					MessageBox.Show($"An ERROR has occurred during the removal of {selected.patient}!");
				}
				else
				{
					MessageBox.Show("Successfully deleted user from the table!");
				}
				patientTable.ItemsSource = service.GetAll();
			}
		}
		private void DataGridCell_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			DataDef selected = patientTable.SelectedItem as DataDef;
			Operations operations = new Operations(selected);
			operations.Closed += (_, _) =>
			{
				patientTable.ItemsSource = service.GetAll();
			};
			operations.ShowDialog();
		}
	}
}
