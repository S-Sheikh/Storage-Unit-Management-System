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
        public Client ClientObj { get; set; }
        public List<StorageUnit> StorageUnits { get; set; }
        public List<Client> Clients { get; set; } 
        public List<string> Data { get; } = new List<string> {"Client ID", "Name", "Surname", "City", "Province"};
        private GridViewColumnHeader _listViewSortCol = null;
        private SortAdorner _listViewSortAdorner = null;
        private GridViewColumnHeader listViewSortColUnits = null;
        private SortAdorner listViewSortAdornerUnits = null;
        public List<StorageUnit> suObjects { get; set; }
        private StorageUnit insertStorageUnit;
        public MainWindow()
        {
            InitializeComponent();
            _cbl = new CBL("ClientSQLiteProvider");
            _subl = new SUBL("StorageUnitSQLiteProvider");
            _lubl = new LUBL("LeaseUnitsSQLiteProvider");
            MessageBox.Show("dsadsa");
            //DataContext = new Client();
            //DataContext = new StorageUnit();
            //Test
        }



        private void textBox10_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tabControl1_SelectionChanged(object sender, SelectionChangedEventArgs e)
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
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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
            suObjects = _subl.SelectAll();
            List<string> classArray = new List<string>();
            foreach (StorageUnit unit in suObjects)
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

            List<StorageUnit> clientObjects = new List<StorageUnit>();
            clientObjects = _subl.SelectAll();
            LvListClient.Items.Clear();

            if (clientObjects.Count > 0)
            {
                LvListClient.Items.Clear();
                foreach (StorageUnit temp in clientObjects)
                {
                        LvListClient.Items.Add(temp);
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

                foreach (StorageUnit unit in suObjects)
                {
                    if (unit.UnitClassification == cb_addClass.SelectedValue.ToString())
                    {
                        lb_currentPrice.Content = "R" + unit.UnitPrice;
                        char[] charSize = unit.UnitSize.ToCharArray();
                        lb_currentDimensions.Content = "Width : " + charSize[0] + "m ; "
                            + "Length : " + charSize[2] + "m ; "
                            + "Height : " + charSize[4] + "m ; ";
                        insertStorageUnit = new StorageUnit();
                        insertStorageUnit.UnitSize = unit.UnitSize;
                        insertStorageUnit.UnitPrice = unit.UnitPrice;
                        insertStorageUnit.UnitArrears = Convert.ToBoolean(0);
                        insertStorageUnit.UnitUpToDate = Convert.ToBoolean(0);
                        insertStorageUnit.UnitInAdvance = Convert.ToBoolean(0);
                        insertStorageUnit.UnitOccupied = Convert.ToBoolean(0);
                        insertStorageUnit.UnitOwnerId = null;
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

        public bool TryParseInt32(string text, ref double value)
        {
            double tmp;
            if (double.TryParse(text, out tmp))
            {
                value = tmp;
                return true;
            }
            else
            {
                return false; // Leave "value" as it was
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
                    suObject.UnitSize = insertStorageUnit.UnitSize;
                    suObject.UnitPrice = insertStorageUnit.UnitPrice;
                    suObject.UnitArrears = insertStorageUnit.UnitArrears;
                    suObject.UnitUpToDate = insertStorageUnit.UnitUpToDate;
                    suObject.UnitInAdvance = insertStorageUnit.UnitInAdvance;
                    suObject.UnitOccupied = insertStorageUnit.UnitOccupied;
                    suObject.UnitOwnerId = "0";

                    for (int x = 0; x < Convert.ToInt16(tb_noOfNewUnits.Text); x++)
                    {
                        suObjects.Clear();
                        suObjects = _subl.SelectAll();
                        int max = 0;
                        foreach (StorageUnit temp in suObjects)
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
            string lblCurrentPrice = LbCurrentPrice.Content.ToString();
            char[] ch = lblCurrentPrice.ToCharArray();
            ch[0] = ' '; // index starts at 0! --->> Remove the 'R' character at the 1st position 
            string newLblCurrentPrice = new string(ch);
            
            double currentPrice = double.Parse(newLblCurrentPrice);
            int rc = 0;
            if (!(LeaseId.Text.Equals("") && LeaseName.Text.Equals("") && LeaseSurname.Text.Equals("")))
            {
                if (_cbl.DoesExist(LeaseId.Text))
                {
                    LeaseUnits leaseUnit = new LeaseUnits();
                    leaseUnit.Client.idNumber = LeaseId.Text;
                    leaseUnit.Client.FirstName = LeaseName.Text;
                    leaseUnit.Client.LastName = LeaseSurname.Text;
                    leaseUnit.StorageUnit.UnitPrice = currentPrice;
                    leaseUnit.NoOfUnits = int.Parse(TbNoOfNewUnits.Text);
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
                    }
                }
                else
                {
                    this.ShowMessageAsync("Client Does Not Exist", "Please Add A Client!");
                }
            }
            else
            {
                this.ShowMessageAsync("Empty Fields", "Fields Cannot Be Empty!");
            }
           
        }

        private void lvUnitsColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortColUnits != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortColUnits).Remove(listViewSortAdornerUnits);
                lv_Units.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortColUnits == column && listViewSortAdornerUnits.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortColUnits = column;
            listViewSortAdornerUnits = new SortAdorner(listViewSortColUnits, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortColUnits).Add(listViewSortAdornerUnits);
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
                if (LeaseId.Text.Equals(temp.idNumber))
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
        }


        public class
            SortAdorner : Adorner
        {
            private static Geometry _ascGeometry =
                Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

            private static Geometry _descGeometry =
                Geometry.Parse("M 0 0 L 3.5 4 L 7 0 Z");

            public ListSortDirection Direction { get; private set; }

            public SortAdorner(UIElement element, ListSortDirection dir)
                : base(element)
            {
                this.Direction = dir;
            }

            protected override void OnRender(DrawingContext drawingContext)
            {
                base.OnRender(drawingContext);

                if (AdornedElement.RenderSize.Width < 20)
                    return;

                TranslateTransform transform = new TranslateTransform
                    (
                    AdornedElement.RenderSize.Width - 15,
                    (AdornedElement.RenderSize.Height - 5)/2
                    );
                drawingContext.PushTransform(transform);

                Geometry geometry = _ascGeometry;
                if (this.Direction == ListSortDirection.Descending)
                    geometry = _descGeometry;
                drawingContext.DrawGeometry(Brushes.Black, null, geometry);

                drawingContext.Pop();
            }
        }

      
    }
}

    

