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
using System.Windows.Shapes;

namespace AHS
{
    /// <summary>
    /// Interaction logic for Operations.xaml
    /// </summary>
    public partial class Operations : Window
    {
        public Operations(DataDef selected)
        {
            InitializeComponent();
            patientName.Content = $"{selected.patient}'s";
            opLog.ItemsSource = selected.operationLogs;
        }

		private void routineOperations_Click(object sender, RoutedEventArgs e)
		{
            uniqueInputs.Visibility = Visibility.Collapsed;
            routineInputs.Visibility = Visibility.Visible;
		}

		private void uniqueOperation_Click(object sender, RoutedEventArgs e)
		{
            uniqueInputs.Visibility = Visibility.Visible;
            routineInputs.Visibility = Visibility.Collapsed;
		}
	}
}
