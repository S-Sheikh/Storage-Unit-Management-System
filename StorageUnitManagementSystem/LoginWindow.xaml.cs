using System;
using System.Collections.Generic;
using System.Diagnostics;
using StorageUnitManagementSystem.BL.Classes;using System.Windows;
using StorageUnitManagementSystem.BL;using System.Windows.Input;
using StorageUnitManagementSystem.DAL;using System.Windows.Navigation;
//
namespace StorageUnitManagementSystem
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        private UBL _ubl;
        public List<User> User
        {
            //
            //Property Name : Automatic property List<SalaryEmployee> SEObjects
            //Purpose       : Automatic Public property containing all the SalaryEmployee objects
            //Re-use        : none
            //Input         : List<SalaryEmployee>
            //                - generic list containing all the SalaryEmployee objects
            //Output        : List<SalaryEmployee>
            //                - generic list containing all the SalaryEmployee objects
            //
            get;
            set;
        } // end property
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Hyperlink_Register(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void Hyperlink_ForgotPassword(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            _ubl = new UBL("UserSQLiteProvider");
            User = _ubl.SelectAll();
            MainWindow window = new MainWindow();

            foreach (User user in User)
            {
                if (textBox.Text.ToString() == user.UserName.ToString() && textBox1.Text.ToString() == user.Password.ToString())
                {
                    window.Show();
                    MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(window, "Logging In", "Successfull Press OK to continue");

                    this.Close();

                    window.TextBlock1.Text = user.UserName;
                }
                else
                {
                    MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(this, "Logging In", "Unsuccessfull, Password or Username Incorrect");
                    break;
                }
            }
        }

        private void lettersOnlyTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Char.IsLetter((char)e.Key)) e.Handled = true;
        }
    }
}
