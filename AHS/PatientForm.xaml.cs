using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for PatientForm.xaml
    /// </summary>
    public partial class PatientForm : Window
    {
		HospitalService service = new HospitalService();
        public PatientForm()
        {
            InitializeComponent();
        }
		private void inputDebt_KeyPress(object sender, TextCompositionEventArgs e)
		{
			if (Regex.IsMatch(e.Text, "^[a-zA-Z]"))
			{
				e.Handled = true;
			}
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			string name = inputName.Text.Trim();
			string hospital = inputHospital.Text.Trim();
			string debt = inputDebt.Text.Trim();
			bool insured = (bool)inputInsured.IsChecked;
			if (string.IsNullOrEmpty(name))
			{
				MessageBox.Show("Name MUST be declared!");
				return;
			}
			if (string.IsNullOrEmpty(hospital))
			{
				MessageBox.Show("Hospital name MUST be declared!");
				return;
			}
			if (debt.Length < 1)
			{
				debt = "0";
			}
			else if (Convert.ToInt32(debt) < 0)
			{
				MessageBox.Show("Debt cannot be less than zero!");
				return;
			}
			DataDef patient = new DataDef();
			patient.patient = name;
			patient.hospital = hospital;
			patient.debt = Convert.ToInt32(debt);
			patient.insured = insured;
			service.Add(patient);
			inputInsured.IsChecked = false;
			inputName.Text = "";
			inputDebt.Text = "";
			inputHospital.Text = "";
			MessageBox.Show($"Successfully added {patient.patient} to the list!");
		}
    }
}
