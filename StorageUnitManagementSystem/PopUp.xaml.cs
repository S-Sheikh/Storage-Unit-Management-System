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
using MahApps.Metro.Controls.Dialogs;
using StorageUnitManagementSystem.BL;
using StorageUnitManagementSystem.BL.Classes;

namespace StorageUnitManagementSystem
{
    /// <summary>
    /// Interaction logic for PopUp.xaml
    /// </summary>
    public partial class PopUp 
    {
        private LUBL _lubl;
        public PopUp()
        {
            InitializeComponent();
            _lubl = new LUBL("LeaseUnitsSQLiteProvider");
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            LeaseUnits leaseUnit = new LeaseUnits();
            LeaseIDTxtBox.IsEnabled = false;
            ClientIDTxtBox.IsEnabled = false;
            leaseUnit.LeaseID = LeaseIDTxtBox.Text;
            leaseUnit.Client.FirstName = LeaseNameTxtBox.Text;
            leaseUnit.Client.LastName = LeaseSurnameTxtBox.Text;
            leaseUnit.AmountOwed = LeaseOwedTxtBox.Text;
            leaseUnit.AmountPaid = LeasePaidTxtBox.Text;
            leaseUnit.DateOfPayment = LeaseDateTxtBox.Text;
            leaseUnit.UnitLeased = Convert.ToBoolean(LeaseUnitTxtBox.Text);
            rc = _lubl.UpdatePopUp(leaseUnit);
            if (rc == 0)
            {
                this.ShowMessageAsync("Updated", "Successfully Updated!");
            }
            else
            {
                this.ShowMessageAsync("Updated Failed", "Update Did Not Perform!");
            }
        }
    }
}
