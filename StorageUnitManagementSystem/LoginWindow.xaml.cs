using System;
using System.Collections.Generic;
using System.Diagnostics;
using StorageUnitManagementSystem.BL.Classes;using System.Windows;
using StorageUnitManagementSystem.BL;using System.Windows.Input;
using StorageUnitManagementSystem.DAL;using System.Windows.Navigation;
using System.Data;
using System.Data.SQLite;
using System.IO;
namespace StorageUnitManagementSystem{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow
    {
        //private static string Path = System.IO.Path.Combine(Environment.GetFolderPath(
        //                             Environment.SpecialFolder.ApplicationData), "StorageUnitManagementDB.db");
        //private string _conStr;
        //private SQLiteConnection _sqlCon;
        private UBL _ubl;
        public List<User> User
        {
            //
            //Property Name : Automatic property List<User> User
            //Purpose       : Automatic Public property containing all the User objects
            //Re-use        : none
            //Input         : List<User>
            //                - generic list containing all the User objects
            //Output        : List<User>
            //                - generic list containing all the User objects
            //
            get;
            set;
        } // end property
        public LoginWindow()
        {
            //
            //Method Name : deflault constructor
            //Purpose       : Automatic Public property containing all the User objects
            //Re-use        : none
            //Input         : List<User>
            //                - generic list containing all the User objects
            //Output        : List<User>
            //                - generic list containing all the User objects
            //
            InitializeComponent();
           CreateDatabase.CreateDb();// Call create db
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }
        private void Hyperlink_Register(object sender, RequestNavigateEventArgs e)
        {

            //Method Name : Hyperlink_Register
            //Purpose       : Automatic Public property containing all the User objects
            //Re-use        : none
            //Input         : List<User>
            //                - generic list containing all the User objects
            //Output        : List<User>
            //                - generic list containing all the User objects
            //
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }
        private void Hyperlink_ForgotPassword(object sender, RequestNavigateEventArgs e)

        //Method Name : Hyperlink_ForgotPassword
        //Purpose       : none
        //Re-use        : none
        //Input         : List<User>
        //                - generic list containing all the User objects
        //Output        : List<User>
        //                - generic list containing all the User objects
        //
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {

            //Method Name : void btnLogin_Click
            //Purpose       : loggin
            //Re-use        : none
            //Input         : none
            //                - generic list containing all the User objects
            //Output        : none
            //                - generic list containing all the User objects
            //
            _ubl = new UBL("UserSQLiteProvider");
            User = _ubl.SelectAll();        //calling database to get list
            MainWindow window = new MainWindow();

            foreach (User user in User)
            {
                if (textBox.Text.ToString() == user.UserName.ToString() &&
                    textBox1.Password.ToString() == user.Password.ToString()) // Validating user email
                {
                    window.Show();
                    MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(window, "Logging In",
                        "Successfull Press OK to continue");
                    window.TextBlock1.Text = user.UserName;
                   this.Close();
                }//end if
                              
                else
                {
                    MahApps.Metro.Controls.Dialogs.DialogManager.ShowMessageAsync(this, "Logging In",
                        "Unsuccessfull, Password or Username Incorrect");
                    break;
                }//end else
            }//end foreach
        }//end method

        private void lettersOnlyTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            
            if (Char.IsLetter((char)e.Key)) e.Handled = true;
        }//end method
    }//end class 
}//end namespace
