using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using StorageUnitManagementSystem.BL;
using StorageUnitManagementSystem.BL.Classes;
using System.Collections.Generic;
using System.Windows.Documents;
using System.Windows.Media;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using MahApps.Metro.Controls;
using EASendMail;


namespace StorageUnitManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private SUBL _subl;
        private CBL _cbl;
        private LUBL _lubl;
        private UBL _ubl;
        public Client ClientObj { get; set; }
        public List<LeaseUnits> LeaseUnits { get; set; }
        public List<StorageUnit> StorageUnits { get; set; }
        public List<Client> Clients { get; set; }
        public List<string> Data { get; } = new List<string> {"Client ID", "Name", "Surname", "City", "Province"};

        public List<string> cb_UnitListSearchItems { get; } = new List<string>
        {
            "Vacant Units",
            "Occupied Units",
            "In Arrears",
            "Up-To-Date",
            "In Advance"
        };

        public List<string> cb_UnitListSearchItemsCopy { get; } = new List<string>
        {
            "Vacant Units",
            "Occupied Units",
            "In Arrears",
            "Up-To-Date",
            "In Advance",
            "ID"
        };
        private GridViewColumnHeader _listViewSortCol = null;
        private SortAdorner _listViewSortAdorner = null;
        private GridViewColumnHeader _listViewSortColUnits = null;
        private SortAdorner _listViewSortAdornerUnits = null;
        private List<StorageUnit> _suObjects;
        private StorageUnit _insertStorageUnit;
        int count = 0;
        public MainWindow()
        {
            InitializeComponent();
            _cbl = new CBL("ClientSQLiteProvider");
            _subl = new SUBL("StorageUnitSQLiteProvider");
            _lubl = new LUBL("LeaseUnitsSQLiteProvider");
            _ubl = new UBL("UserSQLiteProvider");
            //DataContext = new Client();
            DataContext = new StorageUnit();
            //Test
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            //TEST COMMITTTTTTTTTTTTTTTTTTTTTTTTTTTT!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            LoginWindow login = new LoginWindow();
            login.Show();
            this.Close();
        }

        //TO:DO COPY PASTE VALIDATION
        private void lettersOnlyTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            //if (char.IsLetter((char) e.Key))
            //{
            //    e.Handled = true;
            //}
            try
            {
                if ((e.Key < Key.A) || (e.Key > Key.Z))
                {
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(ex.Message, "Main Window : lettersOnlyTextBox_KeyDown");
            }

        }


        private void btn_Submit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void clients_cbo_class_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            Client clientObj = new Client();
            try
            {
                if (TxtBoxId.Text.Equals("") && TxtBoxName.Text.Equals("") &&
                    TxtBoxSurname.Text.Equals("") && TxtBoxDateOfBirth.Text.Equals("") &&
                    TxtBoxCellPhone.Text.Equals("") && TxtBoxTelephone.Text.Equals("") &&
                    TxtBoxEmail.Text.Equals("") && TxtBoxAddress.Text.Equals("") &&
                    TxtBoxLine2.Text.Equals("") && TxtBoxCity.Text.Equals("") &&
                    TxtBoxProvince.Text.Equals("") && TxtBoxCode.Text.Equals(""))
                {
                    this.ShowMessageAsync("Please Enter All Required Fields!", "");
                }
                else
                {
                    clientObj.idNumber = TxtBoxId.Text;
                    clientObj.FirstName = TxtBoxName.Text;
                    clientObj.LastName = TxtBoxSurname.Text;
                    clientObj.DateOfBirth = TxtBoxDateOfBirth.Text;
                    clientObj.Cellphone = TxtBoxCellPhone.Text;
                    clientObj.Telephone = TxtBoxTelephone.Text;
                    clientObj.EMailAddress = TxtBoxEmail.Text;
                    clientObj.Address.Line1 = TxtBoxAddress.Text;
                    clientObj.Address.Line2 = TxtBoxLine2.Text;
                    clientObj.Address.City = TxtBoxCity.Text;
                    clientObj.Address.Province = TxtBoxProvince.Text;
                    clientObj.Address.PostalCode = TxtBoxCode.Text;
                    rc = _cbl.Insert(clientObj);
                    if (rc == 0)
                    {
                        this.ShowMessageAsync(
                            "Client: " + clientObj.FirstName + " " + clientObj.LastName + " Successfully Added!",
                            "Client Added");
                        TxtBoxId.Clear();
                        TxtBoxName.Clear();
                        TxtBoxSurname.Clear();
                        TxtBoxDateOfBirth.Clear();
                        TxtBoxCellPhone.Clear();
                        TxtBoxTelephone.Clear();
                        TxtBoxEmail.Clear();
                        TxtBoxAddress.Clear();
                        TxtBoxLine2.Clear();
                        TxtBoxCity.Clear();
                        TxtBoxProvince.Clear();
                        TxtBoxCode.Clear();
                    } // end if
                    else
                    {
                        this.ShowMessageAsync("Duplicate Client exists. Please try again.", "Client Not Added");
                    } // end else
                }

            } // end try
            catch (Exception ex)
            {
                this.ShowMessageAsync(ex.Message, "Add Client: btnSubmit_Click");
            } // end catch
        }

        private void bntRemoveSearch_Click(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            Client clientObj = new Client();

            LblClientName.Visibility = Visibility.Visible;
            LblClientSurname.Visibility = Visibility.Visible;
            LblClientCellPhone.Visibility = Visibility.Visible;
            LblClientDateOfBirth.Visibility = Visibility.Visible;
            LblClientTelephone.Visibility = Visibility.Visible;
            LblClientAddress.Visibility = Visibility.Visible;
            LblClientEmail.Visibility = Visibility.Visible;

            TxtBoxRemoveClientName.Visibility = Visibility.Visible;
            TxtBoxRemoveClientSurname.Visibility = Visibility.Visible;
            TxtBoxRemoveClientCellPhone.Visibility = Visibility.Visible;
            TxtBoxRemoveClientDateOfBirth.Visibility = Visibility.Visible;
            TxtBoxRemoveClientTelephone.Visibility = Visibility.Visible;
            TxtBoxRemoveClientAddress.Visibility = Visibility.Visible;
            TxtBoxRemoveClientEmail.Visibility = Visibility.Visible;
            BtnRemoveClient.Visibility = Visibility.Visible;

            try
            {
                if (TxtBoxRemoveClientId.Text == "")
                {
                    LblClientName.Visibility = Visibility.Hidden;
                    LblClientSurname.Visibility = Visibility.Hidden;
                    LblClientCellPhone.Visibility = Visibility.Hidden;
                    LblClientDateOfBirth.Visibility = Visibility.Hidden;
                    LblClientTelephone.Visibility = Visibility.Hidden;
                    LblClientAddress.Visibility = Visibility.Hidden;
                    LblClientEmail.Visibility = Visibility.Hidden;

                    TxtBoxRemoveClientName.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                    BtnRemoveClient.Visibility = Visibility.Hidden;
                    this.ShowMessageAsync("Please enter Client ID!", "");
                }
                else
                {
                    rc = _cbl.SelectClient(TxtBoxRemoveClientId.Text, ref clientObj);
                    if (clientObj.Archived == Convert.ToBoolean(1))
                    {
                        LblClientName.Visibility = Visibility.Hidden;
                        LblClientSurname.Visibility = Visibility.Hidden;
                        LblClientCellPhone.Visibility = Visibility.Hidden;
                        LblClientDateOfBirth.Visibility = Visibility.Hidden;
                        LblClientTelephone.Visibility = Visibility.Hidden;
                        LblClientAddress.Visibility = Visibility.Hidden;
                        LblClientEmail.Visibility = Visibility.Hidden;

                        TxtBoxRemoveClientName.Visibility = Visibility.Hidden;
                        TxtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                        TxtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                        TxtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                        TxtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                        TxtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                        TxtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                        BtnRemoveClient.Visibility = Visibility.Hidden;
                        this.ShowMessageAsync("Client Not Found!", "");
                    }
                    else
                    {
                        if (rc == 0)
                        {
                            TxtBoxRemoveClientName.Text = clientObj.FirstName;
                            TxtBoxRemoveClientSurname.Text = clientObj.LastName;
                            TxtBoxRemoveClientCellPhone.Text = clientObj.Cellphone;
                            TxtBoxRemoveClientDateOfBirth.Text = clientObj.DateOfBirth;
                            TxtBoxRemoveClientTelephone.Text = clientObj.Telephone;
                            TxtBoxRemoveClientAddress.Text = clientObj.Address.Line1 + "\n" +
                                                             clientObj.Address.Line2 + "\n" +
                                                             clientObj.Address.City + "\n" +
                                                             clientObj.Address.Province + "\n" +
                                                             clientObj.Address.PostalCode;
                            TxtBoxRemoveClientEmail.Text = clientObj.EMailAddress;
                        }
                        else
                        {
                            LblClientName.Visibility = Visibility.Hidden;
                            LblClientSurname.Visibility = Visibility.Hidden;
                            LblClientCellPhone.Visibility = Visibility.Hidden;
                            LblClientDateOfBirth.Visibility = Visibility.Hidden;
                            LblClientTelephone.Visibility = Visibility.Hidden;
                            LblClientAddress.Visibility = Visibility.Hidden;
                            LblClientEmail.Visibility = Visibility.Hidden;

                            TxtBoxRemoveClientName.Visibility = Visibility.Hidden;
                            TxtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                            TxtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                            TxtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                            TxtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                            TxtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                            TxtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                            BtnRemoveClient.Visibility = Visibility.Hidden;
                            this.ShowMessageAsync("Client Not Found!", "");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(ex.Message, "Remove Client: bntRemoveSearch_Click");
            }
        }

        private void btnRemoveClient_Click(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            Client clientObj = new Client();
            try
            {
                rc = _cbl.SelectClient(TxtBoxRemoveClientId.Text, ref clientObj);
                if (rc == 0)
                {
                    clientObj.Archived = Convert.ToBoolean(1);
                    rc = _cbl.Update(clientObj);
                    this.ShowMessageAsync("Client Successfully Removed!", "");
                    TxtBoxRemoveClientName.Clear();
                    TxtBoxRemoveClientSurname.Clear();
                    TxtBoxRemoveClientCellPhone.Clear();
                    TxtBoxRemoveClientDateOfBirth.Clear();
                    TxtBoxRemoveClientTelephone.Clear();
                    TxtBoxRemoveClientAddress.Clear();
                    TxtBoxRemoveClientEmail.Clear();

                    LblClientName.Visibility = Visibility.Hidden;
                    LblClientSurname.Visibility = Visibility.Hidden;
                    LblClientCellPhone.Visibility = Visibility.Hidden;
                    LblClientDateOfBirth.Visibility = Visibility.Hidden;
                    LblClientTelephone.Visibility = Visibility.Hidden;
                    LblClientAddress.Visibility = Visibility.Hidden;
                    LblClientEmail.Visibility = Visibility.Hidden;

                    TxtBoxRemoveClientName.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                    TxtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                    BtnRemoveClient.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.ShowMessageAsync("Client Not Found!", "");
                }
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(ex.Message, "Remove Client: btnRemoveClient_Click");
            }
        }

        private void txtBoxRemoveClientID_TextChanged(object sender, TextChangedEventArgs e)
        {
            TxtBoxRemoveClientId.MaxLength = 13;
            if (TxtBoxRemoveClientId.Text == "")
            {
                TxtBoxRemoveClientName.Clear();
                TxtBoxRemoveClientSurname.Clear();
                TxtBoxRemoveClientCellPhone.Clear();
                TxtBoxRemoveClientDateOfBirth.Clear();
                TxtBoxRemoveClientTelephone.Clear();
                TxtBoxRemoveClientAddress.Clear();
                TxtBoxRemoveClientEmail.Clear();


                LblClientName.Visibility = Visibility.Hidden;
                LblClientSurname.Visibility = Visibility.Hidden;
                LblClientCellPhone.Visibility = Visibility.Hidden;
                LblClientDateOfBirth.Visibility = Visibility.Hidden;
                LblClientTelephone.Visibility = Visibility.Hidden;
                LblClientAddress.Visibility = Visibility.Hidden;
                LblClientEmail.Visibility = Visibility.Hidden;

                TxtBoxRemoveClientName.Visibility = Visibility.Hidden;
                TxtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                TxtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                TxtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                TxtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                TxtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                TxtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                BtnRemoveClient.Visibility = Visibility.Hidden;
            }
        }

        private void lvRestoreClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Client> clientObjects = new List<Client>();
            clientObjects = _cbl.SelectAll();

            if (clientObjects.Count > 0)
            {
                foreach (Client temp in clientObjects)
                {
                    if (temp.Archived == Convert.ToBoolean(1))
                    {
                        TxtBoxRestoreClientId.Text = temp.idNumber;
                        ;

                    }
                }

            }
            else
            {
                this.ShowMessageAsync("There are no Clients to list", "No Clients");
            }
        }

        private void cb_addClass_DropDownOpened(object sender, EventArgs e)
        {

            cb_addClass.Items.Clear();
            //suObjects.Clear();
            //MessageBox.Show(cb_addClass.SelectedItem.ToString());
            _suObjects = _subl.SelectAll();
            List<string> classArray = new List<string>();
            foreach (StorageUnit unit in _suObjects)
            {
                classArray.Add(unit.UnitClassification);
            }

            // You can convert it back to an array if you would like to
            string[] classStrings = classArray.ToArray();
            classStrings = classStrings.Distinct().ToArray();
            for (int x = 0; x < classStrings.Length; x++)
            {
                cb_addClass.Items.Add(classStrings[x]);
            }
            cb_addClass.SelectedIndex = 0;
        }
        private void btnRestoreSearch_Click(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            Client clientObj = new Client();

            try
            {
                if (TxtBoxRestoreClientId.Text == "")
                {
                    this.ShowMessageAsync("Please Enter Client ID", "");
                }
                else
                {
                    rc = _cbl.SelectClient(TxtBoxRestoreClientId.Text, ref clientObj);
                    if (rc == 0)
                    {
                        if (clientObj.Archived == Convert.ToBoolean(1))
                        {
                            LvRestoreClient.Items.Clear();
                            LvRestoreClient.Items.Add(clientObj);
                        }
                        else
                        {
                            this.ShowMessageAsync("Client Not Found!", "");
                        }
                    }
                    else
                    {
                        this.ShowMessageAsync("Client Not Found!", "");
                    }

                }
            }

            catch (Exception ex)
            {
                this.ShowMessageAsync(ex.Message, "Restore Client: btnRestoreSearch_Click");
            }
        }

        private void txtBoxRestoreClientID_TextChanged(object sender, TextChangedEventArgs e)
        {
            TxtBoxRestoreClientId.MaxLength = 13;
            if (TxtBoxRestoreClientId.Text == "")
            {
                LvRestoreClient.Items.Clear();
                TxtBoxRestoreClientId.Clear();
            }
        }

        private void btnRestoreClient_Click(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            Client clientObj = new Client();

            try
            {
                if (TxtBoxRestoreClientId.Text == "")
                {
                    this.ShowMessageAsync("Please Enter Client ID", "");
                    TxtBoxRestoreClientId.Clear();
                }
                else
                {
                    rc = _cbl.SelectClient(TxtBoxRestoreClientId.Text, ref clientObj);
                    if (rc == 0 && clientObj.Archived != Convert.ToBoolean(0))
                    {
                        clientObj.Archived = Convert.ToBoolean(0);
                        rc = _cbl.Update(clientObj);
                        LvRestoreClient.Items.Clear();
                        TxtBoxRestoreClientId.Clear();
                        this.ShowMessageAsync("Client Restored Successfully!", "");
                    }
                    else
                    {
                        this.ShowMessageAsync("Client Not Found!", "");
                    }
                }
            }
            catch (Exception ex)
            {
                this.ShowMessageAsync(ex.Message, "Restore Client: btnRestoreSearch_Click");
            }
        }

        private void lvClientsColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (_listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(_listViewSortCol).Remove(_listViewSortAdorner);
                LvRestoreClient.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (_listViewSortCol == column && _listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            _listViewSortCol = column;
            _listViewSortAdorner = new SortAdorner(_listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(_listViewSortCol).Add(_listViewSortAdorner);
            LvRestoreClient.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }


        private void lvListClientsColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (_listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(_listViewSortCol).Remove(_listViewSortAdorner);
                LvListClient.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (_listViewSortCol == column && _listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            _listViewSortCol = column;
            _listViewSortAdorner = new SortAdorner(_listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(_listViewSortCol).Add(_listViewSortAdorner);
            LvListClient.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private void btnRestoreListAll_Click(object sender, RoutedEventArgs e)
        {

            List<Client> clientObjects = new List<Client>();
            clientObjects = _cbl.SelectAll();
            LvRestoreClient.Items.Clear();

            if (clientObjects.Count > 0)
            {
                LvRestoreClient.Items.Clear();
                foreach (Client temp in clientObjects)
                {
                    if (temp.Archived == Convert.ToBoolean(1))
                        LvRestoreClient.Items.Add(temp);
                }
            }
            else
            {
                this.ShowMessageAsync("There are no Clients to list", "No Clients");
            }
        }

        private void imgRefresh_MouseDown(object sender, MouseButtonEventArgs e)
        {

            List<Client> clientObjects = new List<Client>();
            clientObjects = _cbl.SelectAll();
            LvListClient.Items.Clear();
            
            if (clientObjects.Count > 0)
            {
                LvListClient.Items.Clear();
                foreach (Client temp in clientObjects)
                {
                    if (temp.Archived == Convert.ToBoolean(0))
                        LvListClient.Items.Add(temp);
                }
            }
            else
            {
                this.ShowMessageAsync("There are no Clients to list", "No Clients");
            }
        }


        private void imgRefreshUnits_MouseDown(object sender, MouseButtonEventArgs e)
        {

            List<StorageUnit> suObjects = new List<StorageUnit>();
            suObjects = _subl.SelectAll();
            lv_Units.Items.Clear();

            if (suObjects.Count > 0)
            {
                lv_Units.Items.Clear();
                foreach (StorageUnit temp in suObjects)
                {
                    lv_Units.Items.Add(temp);
                }
            }
            else
            {
                this.ShowMessageAsync("There are no Storage Units to list", "No Units");
            }
        }
        private void imgRefreshUnitsSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {

            List<StorageUnit> suObjects = new List<StorageUnit>();
            suObjects = _subl.SelectAll();
            lv_Units_Search.Items.Clear();

            if (suObjects.Count > 0)
            {
                lv_Units_Search.Items.Clear();
                foreach (StorageUnit temp in suObjects)
                {
                    lv_Units_Search.Items.Add(temp);
                }
            }
            else
            {
                this.ShowMessageAsync("There are no Storage Units to list", "No Units");
            }
        }
        private void cboListSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem typeItem = (ComboBoxItem) CboListSearch.SelectedItem;
                string value = typeItem.Content.ToString();
            }
            catch (Exception)
            {
                // ignored
            }
        }

        //private void txtBoxName_LostFocus(object sender, RoutedEventArgs e)
        //{

        //    if (txtBoxName.Text == "")
        //    {
        //        txtBoxName.Text = "Name field cannot be empty!";
        //        //txtBoxName.FontStyle = Italic;
        //    }
        //}

        //private void txtBoxName_GotFocus(object sender, RoutedEventArgs e)
        //{
        //    txtBoxName.Clear();
        //}



        private void cboListSearch_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                CboListSearch.Items.Clear();
                CboListSearch.ItemsSource = Data;
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void cb_UnitListSearch_DropDownOpened(object sender, EventArgs e)
        {
            try
            {
                cb_UnitListSearch.Items.Clear();
                cb_UnitListSearch.ItemsSource = cb_UnitListSearchItems;
                cb_UnitListSearch.SelectedIndex = 0;
            }
            catch (Exception)
            {
                // Go Home WPF
            }
        }

        private void btnListSearch_Click(object sender, RoutedEventArgs e)
        {

            int rc = 0;
            List<Client> clients = new List<Client>();
            Client clientObj = new Client();
            if (CboListSearch.SelectedItem.ToString() == "Client ID")
            {
                LvListClient.Items.Clear();
                rc = _cbl.SelectClient(TxtBoxListSearch.Text, ref clientObj);
                if (rc == 0)
                {
                    LvListClient.Items.Clear();
                    LvListClient.Items.Add(clientObj);
                }
            }
            else if (CboListSearch.SelectedItem.ToString() == "Name")
            {
                //List< Client > clientObjects = new List<Client>();
                //clientObjects = cbl.SelectAll(txtBoxListSearch.Text);
                //lvListClient.Items.Clear();

                //if (clientObjects.Count > 0)
                //{
                //    lvListClient.Items.Clear();
                //    foreach (Client temp in clientObjects)
                //    {
                //        lvListClient.Items.Add(temp);
                //    }
                //}
                LvListClient.Items.Clear();
                Client clientName = new Client();
                rc = _cbl.SelectClientName(TxtBoxListSearch.Text, ref clientName);
                if (rc == 0)
                {
                    LvListClient.Items.Clear();
                    LvListClient.Items.Add(clientName);
                }
                else
                {
                    this.ShowMessageAsync("No Client loaded from datastore", "No Clients");
                }
            }
            else if (CboListSearch.SelectedItem.ToString() == "Surname")
            {

            }
            else if (CboListSearch.SelectedItem.ToString() == "City")
            {

            }
            else if (CboListSearch.SelectedItem.ToString() == "Province")
            {

            }
            else
            {
                this.ShowMessageAsync("Client Does Not Exist", "No Client");
            }

        }

        private void btn_UnitListSearch_Click(object sender, RoutedEventArgs e)
        {

            int rc = 0;
            List<StorageUnit> suObjects = new List<StorageUnit>();
            StorageUnit storageUnit = new StorageUnit();
            switch (cb_UnitListSearch.SelectedItem.ToString())
            {
                case "Sort By:":
                    this.ShowMessageAsync("Error", "Please Choose an Option from the Drop Down Box");
                    break;
                case "Vacant Units":
                    lv_Units.Items.Clear();
                    suObjects = _subl.SelectAll();
                    foreach (StorageUnit unit in suObjects)
                    {
                        if (unit.UnitOccupied.Equals(false))
                        {
                            lv_Units.Items.Add(unit);
                            rc = 1;
                        }
                        
                    }
                    if (rc == 0)
                    {
                        this.ShowMessageAsync("Error", "No Vacant Units Found");
                    }
                    break;
                case "Occupied Units":
                    lv_Units.Items.Clear();
                    suObjects = _subl.SelectAll();
                    foreach (StorageUnit unit in suObjects)
                    {
                        if (unit.UnitOccupied.Equals(true))
                        {
                            lv_Units.Items.Add(unit);
                            rc = 1;
                        }                        
                    }
                    if (rc == 0)
                    {
                        this.ShowMessageAsync("Error", "No Occupied Units Found");
                    }
                    break;
                case "In Arrears":
                    lv_Units.Items.Clear();
                    suObjects = _subl.SelectAll();
                    foreach (StorageUnit unit in suObjects)
                    {
                        if (unit.UnitArrears.Equals(true))
                        {
                            lv_Units.Items.Add(unit);
                            rc = 1;
                        }
                    }
                    if (rc == 0)
                    {
                        this.ShowMessageAsync("Error", "No Units in Arrears Found");
                    }
                    break;
                case "Up-To-Date":
                    lv_Units.Items.Clear();
                    suObjects = _subl.SelectAll();
                    foreach (StorageUnit unit in suObjects)
                    {
                        if (unit.UnitUpToDate.Equals(true))
                        {
                            lv_Units.Items.Add(unit);
                            rc = 1;
                        }
                    }
                    if (rc == 0)
                    {
                        this.ShowMessageAsync("Error", "No Up-To-Date Units Found");
                    }
                    break;
                case "In Advance":
                    lv_Units.Items.Clear();
                    suObjects = _subl.SelectAll();
                    foreach (StorageUnit unit in suObjects)
                    {
                        if (unit.UnitInAdvance.Equals(true))
                        {
                            lv_Units.Items.Add(unit);
                            rc = 1;
                        }
                    }
                    if (rc == 0)
                    {
                        this.ShowMessageAsync("Error", "No Units Paid for in Advance Found");
                    }
                    break;
                default:
                    this.ShowMessageAsync("Unit Does Not Exist", "No Unit");
                    break;
            }

        }

        private void AddClientTextBoxValidation(object sender, TextChangedEventArgs e)
        {
            if (TxtBoxId.Text.Length == 0)
            {
                //txtBoxId.Foreground = System.Windows.Media.Brushes.Red;
                TxtBoxId.SetValue(TextBoxHelper.WatermarkProperty, "ID number cannot be empty!");
            }
            else if (TxtBoxId.Text.Length > 13)
            {
                TxtBoxId.MaxLength = 13;
            }
        }

        private void UIElement_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+"); //regex that matches disallowed text
            return !regex.IsMatch(text);
        }

        // Use the DataObject.Pasting Handler 
        private void TextBoxPasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof (String)))
            {
                String text = (String) e.DataObject.GetData(typeof (String));
                if (!IsTextAllowed(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void txtBoxCellPhone_TextChanged(object sender, TextChangedEventArgs e)
        {
            TxtBoxCellPhone.MaxLength = 10;
        }

        private void txtBoxTelephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            TxtBoxTelephone.MaxLength = 10;
        }

        private void CbLeaseSelectClass_DropDownOpened(object sender, EventArgs e)
        {
            CbLeaseSelectClass.Items.Clear();
            //MessageBox.Show(cb_addClass.SelectedItem.ToString());
            StorageUnits = _subl.SelectAll();
            List<string> classArray = new List<string>();
            foreach (StorageUnit unit in StorageUnits)
            {
                classArray.Add(unit.UnitClassification);
            }

            // You can convert it back to an array if you would like to
            string[] classStrings = classArray.ToArray();
            classStrings = classStrings.Distinct().ToArray();
            for (int x = 0; x < classStrings.Length; x++)
            {
                CbLeaseSelectClass.Items.Add(classStrings[x]);
            }
            CbLeaseSelectClass.SelectedIndex = 0;
        }

        private int CountAvailableUnits(string unitClass) //returns number of available units
        {
            int availableUnits = 0;
            foreach (StorageUnit unit in StorageUnits)
            {

                if (unit.UnitOccupied == Convert.ToBoolean(0) && unit.UnitClassification.Equals(unitClass))
                {
                    availableUnits++;
                }
            }
            return availableUnits;
        }

        private void cb_addClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                foreach (StorageUnit unit in _suObjects)
                {
                    if (unit.UnitClassification == cb_addClass.SelectedValue.ToString())
                    {
                        lb_currentPrice.Content = "R" + unit.UnitPrice;
                        char[] charSize = unit.UnitSize.ToCharArray();
                        lb_currentDimensions.Content = "Width : " + charSize[0] + "m ; "
                            + "Length : " + charSize[2] + "m ; "
                            + "Height : " + charSize[4] + "m ; ";
                        _insertStorageUnit = new StorageUnit();
                        _insertStorageUnit.UnitSize = unit.UnitSize;
                        _insertStorageUnit.UnitPrice = unit.UnitPrice;
                        _insertStorageUnit.UnitArrears = Convert.ToBoolean(0);
                        _insertStorageUnit.UnitUpToDate = Convert.ToBoolean(0);
                        _insertStorageUnit.UnitInAdvance = Convert.ToBoolean(0);
                        _insertStorageUnit.UnitOccupied = Convert.ToBoolean(0);
                        _insertStorageUnit.UnitOwnerId = null;
                        break;
                    }

                }
            }
            catch (Exception)
            {
                //Go Home WPF , You're Drunk
            }
        }

        private int CountOccupiedUnits(string unitClass) //returns number of occupied units
        {
            int occupiedUnits = 0;
            foreach (StorageUnit unit in StorageUnits)
            {

                if (unit.UnitOccupied == Convert.ToBoolean(1) && unit.UnitClassification.Equals(unitClass))
                {
                    occupiedUnits++;
                }
            }
            return occupiedUnits;
        }

        private void CbLeaseSelectClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                foreach (StorageUnit unit in StorageUnits)
                {
                    if (unit.UnitClassification == CbLeaseSelectClass.SelectedValue.ToString())
                    {
                        LbCurrentPrice.Content = "R" + unit.UnitPrice;
                        char[] charSize = unit.UnitSize.ToCharArray();
                        LbCurrentDimensions.Content = "Width : " + charSize[0] + "m ; "
                                                      + "Length : " + charSize[2] + "m ; "
                                                      + "Height : " + charSize[4] + "m ; ";
                        LblAvailableUnits.Content = CountAvailableUnits(CbLeaseSelectClass.SelectedValue.ToString());
                        break;
                    }
                }
            }
            catch (Exception)
            {
                //Go Home WPF , You're Drunk
            }
        }

        private void TbNoOfNewUnits_KeyDown(object sender, KeyEventArgs e)
        {
            string LblCurrentPrice = LbCurrentPrice.Content.ToString();
            char[] ch = LblCurrentPrice.ToCharArray();
            ch[0] = ' '; // index starts at 0! --->> Remove the 'R' character at the 1st position 
            string newLblCurrentPrice = new string(ch);
            double unitPrice = 0;
            double noOfUnits = 0;
            string noOfUnits_ = TbNoOfNewUnits.Text;
            try
            {
                foreach (StorageUnit units in StorageUnits)
                {
                    if (units.UnitOccupied == Convert.ToBoolean(0))
                    {
                        if (units.UnitPrice == double.Parse(newLblCurrentPrice))
                        {
                            unitPrice = units.UnitPrice;
                            break;
                        }
                    }
                }

                if (double.TryParse(noOfUnits_, out noOfUnits))
                {
                   // TbNoOfNewUnits.Text.Remove(0);
                    LblTotal.Content = unitPrice * Convert.ToDouble(noOfUnits);
                }
                else
                {//
                    TbNoOfNewUnits.Text.Remove(0);
                    LblTotal.Content = ".....";
                }
            }
            catch (Exception)
            {
                this.ShowMessageAsync("Unit Class", "Please Select A Unit Class First");
                LblTotal.Content = ".....";
            }

        }

        private void btn_addNewUnits_Click(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            if (!string.IsNullOrEmpty(tb_noOfNewUnits.Text))
            {
                try
                {

                    StorageUnit suObject = new StorageUnit();
                    suObject.UnitClassification = cb_addClass.SelectedValue.ToString();
                    suObject.UnitSize = _insertStorageUnit.UnitSize;
                    suObject.UnitPrice = _insertStorageUnit.UnitPrice;
                    suObject.UnitArrears = _insertStorageUnit.UnitArrears;
                    suObject.UnitUpToDate = _insertStorageUnit.UnitUpToDate;
                    suObject.UnitInAdvance = _insertStorageUnit.UnitInAdvance;
                    suObject.UnitOccupied = _insertStorageUnit.UnitOccupied;
                    suObject.UnitOwnerId = "0";

                    for (int x = 0; x < Convert.ToInt16(tb_noOfNewUnits.Text); x++)
                    {
                        _suObjects.Clear();
                        _suObjects = _subl.SelectAll();
                        int max = 0;
                        foreach (StorageUnit temp in _suObjects)
                        {
                            if (Convert.ToInt16(temp.UnitId) >= max)
                            {
                                max = Convert.ToInt16(temp.UnitId);
                            }
                        }
                        suObject.UnitId = Convert.ToString(max + 1);
                        rc = _subl.Insert(suObject);
                    }
                    if (rc == 0)
                    {
                        this.ShowMessageAsync("Success", "Added New Unit/s ");
                    }
                    else
                    {
                        this.ShowMessageAsync("Error", "Could not Add New Unit");
                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            }
            else
            {
                this.ShowMessageAsync("Warning", "Please Enter all options");
            }
        }

        private void BtnLeaseSubmit_Click(object sender, RoutedEventArgs e)
        {
            string unitId = "";
            StorageUnits = _subl.SelectAll();
            LeaseUnits leaseUnit = new LeaseUnits();
            string lblCurrentPrice = LbCurrentPrice.Content.ToString();
            char[] ch = lblCurrentPrice.ToCharArray();
            ch[0] = ' '; // index starts at 0! --->> Remove the 'R' character at the 1st position 
            string newLblCurrentPrice = new string(ch);
            //double currentPrice = double.Parse(newLblCurrentPrice);
            double currentPrice;
            if (double.TryParse(newLblCurrentPrice, out currentPrice))
            {

            }
            else
            {
                //Do Nothing!!!
            }
            int rc = 0;
            if (!(LeaseId.Text.Equals("") && LeaseName.Text.Equals("") && LeaseSurname.Text.Equals("")))
            {
                if (_cbl.DoesExist(LeaseId.Text))
                {
                    //if (!(_lubl.DoesExist(LeaseId.Text)))
                    //{
                    //    foreach (StorageUnit storageUnit in StorageUnits)
                    //    {
                    //        if (storageUnit.UnitClassification == CbLeaseSelectClass.SelectedValue.ToString() &&
                    //            storageUnit.UnitOccupied == Convert.ToBoolean(0))
                    //        {
                    //            unitId = storageUnit.UnitId;
                    //            break; //break if its 1st value you inserting
                    //        }
                    //    }
                    //}
                    foreach (StorageUnit storageUnit in StorageUnits)
                    {
                        count++;
                        if (storageUnit.UnitClassification == CbLeaseSelectClass.SelectedValue.ToString() &&
                            storageUnit.UnitOccupied == Convert.ToBoolean(0))
                        {
                            if (count == 1)
                            {
                                unitId = storageUnit.UnitId;
                                break;
                            }
                        if (count > 1)
                        {
                            //unitId = StorageUnit;
                        }
                        //break if its 1st value you inserting
                        }
                    }
                    leaseUnit.LeaseID = unitId;
                    leaseUnit.StorageUnit.UnitId = unitId;
                    leaseUnit.Client.idNumber = LeaseId.Text;
                    leaseUnit.Client.FirstName = LeaseName.Text;
                    leaseUnit.Client.LastName = LeaseSurname.Text;
                    leaseUnit.StorageUnit.UnitPrice = currentPrice;
                    leaseUnit.NoOfUnits = int.Parse(TbNoOfNewUnits.Text);
                    leaseUnit.ClientAdded = Convert.ToBoolean(1);
                    if (CbLeaseSelectClass.SelectedValue.ToString() == "A")
                    {
                        leaseUnit.StorageUnit.UnitClassification = CbLeaseSelectClass.SelectedValue.ToString();
                        if (int.Parse(TbNoOfNewUnits.Text) >
                            CountAvailableUnits(CbLeaseSelectClass.SelectedValue.ToString()))
                        {
                            this.ShowMessageAsync("Units Occupied", "Units Not Available,Please Enter Less Units");
                        }
                    }
                    else if (CbLeaseSelectClass.SelectedValue.ToString() == "B")
                    {
                        leaseUnit.StorageUnit.UnitClassification = CbLeaseSelectClass.SelectedValue.ToString();
                        if (int.Parse(TbNoOfNewUnits.Text) >
                            CountAvailableUnits(CbLeaseSelectClass.SelectedValue.ToString()))
                        {
                            this.ShowMessageAsync("Units Occupied", "Units Not Available,Please Enter Less Units");
                        }
                    }
                    else if (CbLeaseSelectClass.SelectedValue.ToString() == "C")
                    {
                        leaseUnit.StorageUnit.UnitClassification = CbLeaseSelectClass.SelectedValue.ToString();
                        if (int.Parse(TbNoOfNewUnits.Text) >
                            CountAvailableUnits(CbLeaseSelectClass.SelectedValue.ToString()))
                        {
                            this.ShowMessageAsync("Units Occupied", "Units Not Available,Please Enter Less Units");
                        }
                    }
                    else if (CbLeaseSelectClass.SelectedValue.ToString() == "D")
                    {
                        leaseUnit.StorageUnit.UnitClassification = CbLeaseSelectClass.SelectedValue.ToString();
                        if (int.Parse(TbNoOfNewUnits.Text) >
                            CountAvailableUnits(CbLeaseSelectClass.SelectedValue.ToString()))
                        {
                            this.ShowMessageAsync("Units Occupied", "Units Not Available,Please Enter Less Units");
                        }
                    }
                    else if (CbLeaseSelectClass.SelectedValue.ToString() == "E")
                    {
                        leaseUnit.StorageUnit.UnitClassification = CbLeaseSelectClass.SelectedValue.ToString();
                        if (int.Parse(TbNoOfNewUnits.Text) >
                            CountAvailableUnits(CbLeaseSelectClass.SelectedValue.ToString()))
                        {
                            this.ShowMessageAsync("Units Occupied", "Units Not Available,Please Enter Less Units");
                        }
                    }
                    else if (CbLeaseSelectClass.SelectedValue.ToString() == "E")
                    {
                        leaseUnit.StorageUnit.UnitClassification = CbLeaseSelectClass.SelectedValue.ToString();
                        if (int.Parse(TbNoOfNewUnits.Text) >
                            CountAvailableUnits(CbLeaseSelectClass.SelectedValue.ToString()))
                        {
                            this.ShowMessageAsync("Units Occupied", "Units Not Available,Please Enter Less Units");
                        }
                    }
                    rc = _lubl.Insert(leaseUnit);
                    if (rc == 0)
                    {
                        this.ShowMessageAsync("Contract Successfully Created", "Contract Will Be Sent To Client!");
                        LeaseId.Clear();
                        LeaseName.Clear();
                        LeaseSurname.Clear();
                        TbNoOfNewUnits.Clear();
                        LbCurrentDimensions.Content = ".....";
                        LbCurrentPrice.Content = ".....";
                        LblAvailableUnits.Content = ".....";
                        LblTotal.Content = ".....";
                        foreach (Client client in Clients)
                        {
                            if (client.idNumber.Equals(LeaseId.Text))
                            {
                                SendEmail(client.EMailAddress, "Please find the attached document!");
                                //this.ShowMessageAsync("Email", "Send email here!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
                                break;
                            }
                        }
                        // SendEmail();
                    }

                    else
                    {
                        this.ShowMessageAsync("Insert Failed", "Record Not Inserted Into Database!");
                    }
                }
                else
                {
                    this.ShowMessageAsync("Empty Fields", "Fields Cannot Be Empty!");
                }
            }
        }

        private void SendEmail(string to,string body)
        {
            SmtpMail oMail = new SmtpMail("TryIt");
            SmtpClient oSmtp = new SmtpClient();

            // Set sender email address, please change it to yours
            oMail.From = "onesandzeroesmail@gmail.com";

            // Set recipient email address, please change it to yours
            oMail.To = to;

            // Set email subject
            oMail.Subject = "RE: Contract to be reviewed";

            // Set Html body
            //oMail.HtmlBody = "<font size=\"5\">This is</font> <font color=\"red\"><b>a test</b></font>";
            oMail.HtmlBody = body;

            // Your SMTP server address
            SmtpServer oServer = new SmtpServer("smtp.gmail.com");

            // User and password for ESMTP authentication, if your server doesn't require
            // User authentication, please remove the following codes.            
            oServer.User = "onesandzeroesmail@gmail.com";
            oServer.Password = "Onesandzeroes.";

            // If your smtp server requires SSL connection, please add this line
            // oServer.ConnectType = SmtpConnectType.ConnectSSLAuto;

            try
            {
                // Add attachment from local disk
                oMail.AddAttachment("C:\\Test\\TESTI.txt");

                // Add attachment from remote website
               // oMail.AddAttachment("http://www.emailarchitect.net/webapp/img/logo.jpg");

                //Console.WriteLine("start to send email with attachment ...");
                oSmtp.SendMail(oServer, oMail);
               // Console.WriteLine("email was sent successfully!");
            }
            catch (Exception ep)
            {
                this.ShowMessageAsync("Sending Email Failed", ep.Message);
            }
        
    }

        private void lvUnitsColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (_listViewSortColUnits != null)
            {
                AdornerLayer.GetAdornerLayer(_listViewSortColUnits).Remove(_listViewSortAdornerUnits);
                lv_Units.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (_listViewSortColUnits == column && _listViewSortAdornerUnits.Direction == newDir)
                newDir = ListSortDirection.Descending;

            _listViewSortColUnits = column;
            _listViewSortAdornerUnits = new SortAdorner(_listViewSortColUnits, newDir);
            AdornerLayer.GetAdornerLayer(_listViewSortColUnits).Add(_listViewSortAdornerUnits);
            lv_Units.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));

        }

        private void lvUnitsSearchColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (_listViewSortColUnits != null)
            {
                AdornerLayer.GetAdornerLayer(_listViewSortColUnits).Remove(_listViewSortAdornerUnits);
                lv_Units.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (_listViewSortColUnits == column && _listViewSortAdornerUnits.Direction == newDir)
                newDir = ListSortDirection.Descending;

            _listViewSortColUnits = column;
            _listViewSortAdornerUnits = new SortAdorner(_listViewSortColUnits, newDir);
            AdornerLayer.GetAdornerLayer(_listViewSortColUnits).Add(_listViewSortAdornerUnits);
            lv_Units.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));

        }

        private void TbNoOfNewUnits_TextChanged(object sender, TextChangedEventArgs e)
            //clears the textbox when there is no input
        {
            if (TbNoOfNewUnits.Text.Equals(""))
            {
                LblTotal.Content = ".....";
            }

        }

        private void LeaseId_TextChanged(object sender, TextChangedEventArgs e)
        {
            Clients = _cbl.SelectAll();
            foreach (Client temp in Clients)
            {
                if (LeaseId.Text.Equals(temp.idNumber) && temp.Archived.Equals(Convert.ToBoolean(0)))
                {
                    LeaseName.Text = temp.FirstName;
                    LeaseSurname.Text = temp.LastName;
                    break;
                }
            }
            if (LeaseId.Text.Equals(""))
            {
                LeaseName.Clear();
                LeaseSurname.Clear();
            }

            if (!(_cbl.DoesExist(LeaseId.Text)))
            {
                LblClientExist.Content = "Client Does Not Exist!";
            }
        }

        private void btn_UnitListSearch_Copy_OnClick(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            StorageUnit unitObject = new StorageUnit();
            lv_Units_Search.Items.Clear();

                    //lv_Units_Search.Items.Clear();
                    rc = _subl.SelectStorageUnit(tb_SearchUnit.Text, ref unitObject);
                    if (rc == 0)
                    {
                        //lv_Units_Search.Items.Clear();
                        lv_Units_Search.Items.Add(unitObject);
                    }
                    else
                    {
                        this.ShowMessageAsync("Error", "No Matching Unit ID Found");
                    }
        }

        private void Btn_ClearLessee_OnClick(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            StorageUnit selectedUnit = new StorageUnit();
            if (lv_Units.SelectedIndex >= 0)
            {
                //Get Selected Item as a SU Object , possible because of class binding
                var unitObj = lv_Units.SelectedItem as StorageUnit;
                string selectedID = unitObj.UnitId;
                rc = _subl.SelectStorageUnit(selectedID,ref selectedUnit);
                if (rc != 0)
                {
                    this.ShowMessageAsync("Error", "Could Not Find Storage Unit ... \n Please Refresh Unit List ");
                }
                else
                {
                    selectedUnit.UnitOccupied = false;
                    selectedUnit.UnitOwnerId = "0";
                    rc = _subl.Update(selectedUnit);
                    if (rc != 0)
                    {
                        this.ShowMessageAsync("Error", "Could not Remove Client from Unit");
                    }
                    else
                    {
                        LeaseUnits = _lubl.SelectAll();
                        this.ShowMessageAsync("DEBUG", "Im HERE");
                        foreach (LeaseUnits leaseUnit in LeaseUnits)
                        {
                            if (leaseUnit.StorageUnit.UnitId.Equals(selectedUnit.UnitId))
                            {
                                rc = _lubl.Delete(leaseUnit.LeaseID);
                                if (rc != 0)
                                {
                                    this.ShowMessageAsync("Error", "Could not Delete Lease Information");
                                }
                                else
                                {
                                    this.ShowMessageAsync("Success", "Removed Leasing Information for selected Unit");
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                this.ShowMessageAsync("Warning", "Please Choose a Unit in the List");
            }
        }
    }
}