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
        private CBL cbl;
        public List<string> Data { get; } = new List<string> { "Client ID", "Name", "Surname", "City", "Province" };

        private GridViewColumnHeader listViewSortCol = null;
        private SortAdorner listViewSortAdorner = null;
        public MainWindow()
        {
            InitializeComponent();
            cbl = new CBL("ClientSQLiteProvider");
            DataContext = new Client();
           
        }

        public Client clientObj
        {
            get;
            set;
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
                if (txtBoxId.Text.Equals("") && txtBoxName.Text.Equals("") &&
                    txtBoxSurname.Text.Equals("") && txtBoxDateOfBirth.Text.Equals("") &&
                    txtBoxCellPhone.Text.Equals("") && txtBoxTelephone.Text.Equals("") &&
                    txtBoxEmail.Text.Equals("") && txtBoxAddress.Text.Equals("") &&
                    txtBoxLine2.Text.Equals("") && txtBoxCity.Text.Equals("") &&
                    txtBoxProvince.Text.Equals("") && txtBoxCode.Text.Equals(""))
                {
                    this.ShowMessageAsync("Please Enter All Required Fields!", "");
                }
                else
                {
                    clientObj.idNumber = txtBoxId.Text;
                    clientObj.FirstName = txtBoxName.Text;
                    clientObj.LastName = txtBoxSurname.Text;
                    clientObj.DateOfBirth = txtBoxDateOfBirth.Text;
                    clientObj.Cellphone = txtBoxCellPhone.Text;
                    clientObj.Telephone = txtBoxTelephone.Text;
                    clientObj.EMailAddress = txtBoxEmail.Text;
                    clientObj.Address.Line1 = txtBoxAddress.Text;
                    clientObj.Address.Line2 = txtBoxLine2.Text;
                    clientObj.Address.City = txtBoxCity.Text;
                    clientObj.Address.Province = txtBoxProvince.Text;
                    clientObj.Address.PostalCode = txtBoxCode.Text;
                    rc = cbl.Insert(clientObj);
                    if (rc == 0)
                    {
                        this.ShowMessageAsync("Client: " + clientObj.FirstName + " " + clientObj.LastName + " Successfully Added!","Client Added");
                        txtBoxId.Clear();
                        txtBoxName.Clear();
                        txtBoxSurname.Clear();
                        txtBoxDateOfBirth.Clear();
                        txtBoxCellPhone.Clear();
                        txtBoxTelephone.Clear();
                        txtBoxEmail.Clear();
                        txtBoxAddress.Clear();
                        txtBoxLine2.Clear();
                        txtBoxCity.Clear();
                        txtBoxProvince.Clear();
                        txtBoxCode.Clear();
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
           
            lblClientName.Visibility = Visibility.Visible;
            lblClientSurname.Visibility = Visibility.Visible;
            lblClientCellPhone.Visibility = Visibility.Visible;
            lblClientDateOfBirth.Visibility = Visibility.Visible;
            lblClientTelephone.Visibility = Visibility.Visible;
            lblClientAddress.Visibility = Visibility.Visible;
            lblClientEmail.Visibility = Visibility.Visible;

            txtBoxRemoveClientName.Visibility = Visibility.Visible;
            txtBoxRemoveClientSurname.Visibility = Visibility.Visible;
            txtBoxRemoveClientCellPhone.Visibility = Visibility.Visible;
            txtBoxRemoveClientDateOfBirth.Visibility = Visibility.Visible;
            txtBoxRemoveClientTelephone.Visibility = Visibility.Visible;
            txtBoxRemoveClientAddress.Visibility = Visibility.Visible;
            txtBoxRemoveClientEmail.Visibility = Visibility.Visible;
            btnRemoveClient.Visibility = Visibility.Visible;

            try
            {
                 if (txtBoxRemoveClientID.Text == "")
                {
                    lblClientName.Visibility = Visibility.Hidden;
                    lblClientSurname.Visibility = Visibility.Hidden;
                    lblClientCellPhone.Visibility = Visibility.Hidden;
                    lblClientDateOfBirth.Visibility = Visibility.Hidden;
                    lblClientTelephone.Visibility = Visibility.Hidden;
                    lblClientAddress.Visibility = Visibility.Hidden;
                    lblClientEmail.Visibility = Visibility.Hidden;

                    txtBoxRemoveClientName.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                    btnRemoveClient.Visibility = Visibility.Hidden;
                    this.ShowMessageAsync("Please enter Client ID!","");
                }
                else
                {
                    rc = cbl.SelectClient(txtBoxRemoveClientID.Text, ref clientObj);
                    if (clientObj.Archived == Convert.ToBoolean(1))
                    {
                        lblClientName.Visibility = Visibility.Hidden;
                        lblClientSurname.Visibility = Visibility.Hidden;
                        lblClientCellPhone.Visibility = Visibility.Hidden;
                        lblClientDateOfBirth.Visibility = Visibility.Hidden;
                        lblClientTelephone.Visibility = Visibility.Hidden;
                        lblClientAddress.Visibility = Visibility.Hidden;
                        lblClientEmail.Visibility = Visibility.Hidden;

                        txtBoxRemoveClientName.Visibility = Visibility.Hidden;
                        txtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                        txtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                        txtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                        txtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                        txtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                        txtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                        btnRemoveClient.Visibility = Visibility.Hidden;
                        this.ShowMessageAsync("Client Not Found!","");
                    }
                    else
                    {
                        if (rc == 0)
                        {
                            txtBoxRemoveClientName.Text = clientObj.FirstName;
                            txtBoxRemoveClientSurname.Text = clientObj.LastName;
                            txtBoxRemoveClientCellPhone.Text = clientObj.Cellphone;
                            txtBoxRemoveClientDateOfBirth.Text = clientObj.DateOfBirth;
                            txtBoxRemoveClientTelephone.Text = clientObj.Telephone;
                            txtBoxRemoveClientAddress.Text = clientObj.Address.Line1 + "\n" +
                                                             clientObj.Address.Line2 + "\n" +
                                                             clientObj.Address.City + "\n" +
                                                             clientObj.Address.Province + "\n" +
                                                             clientObj.Address.PostalCode;
                            txtBoxRemoveClientEmail.Text = clientObj.EMailAddress;
                        }
                        else
                        {
                            lblClientName.Visibility = Visibility.Hidden;
                            lblClientSurname.Visibility = Visibility.Hidden;
                            lblClientCellPhone.Visibility = Visibility.Hidden;
                            lblClientDateOfBirth.Visibility = Visibility.Hidden;
                            lblClientTelephone.Visibility = Visibility.Hidden;
                            lblClientAddress.Visibility = Visibility.Hidden;
                            lblClientEmail.Visibility = Visibility.Hidden;

                            txtBoxRemoveClientName.Visibility = Visibility.Hidden;
                            txtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                            txtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                            txtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                            txtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                            txtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                            txtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                            btnRemoveClient.Visibility = Visibility.Hidden;
                            this.ShowMessageAsync("Client Not Found!","");
                        }
                    }
                }
            }
            catch(Exception ex)
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
                rc = cbl.SelectClient(txtBoxRemoveClientID.Text, ref clientObj);
                if(rc == 0)
                 {
                    clientObj.Archived = Convert.ToBoolean(1);
                    rc = cbl.Update(clientObj);
                    this.ShowMessageAsync("Client Successfully Removed!","");
                    txtBoxRemoveClientName.Clear();
                    txtBoxRemoveClientSurname.Clear();
                    txtBoxRemoveClientCellPhone.Clear();
                    txtBoxRemoveClientDateOfBirth.Clear();
                    txtBoxRemoveClientTelephone.Clear();
                    txtBoxRemoveClientAddress.Clear();
                    txtBoxRemoveClientEmail.Clear();

                    lblClientName.Visibility = Visibility.Hidden;
                    lblClientSurname.Visibility = Visibility.Hidden;
                    lblClientCellPhone.Visibility = Visibility.Hidden;
                    lblClientDateOfBirth.Visibility = Visibility.Hidden;
                    lblClientTelephone.Visibility = Visibility.Hidden;
                    lblClientAddress.Visibility = Visibility.Hidden;
                    lblClientEmail.Visibility = Visibility.Hidden;

                    txtBoxRemoveClientName.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                    txtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                    btnRemoveClient.Visibility = Visibility.Hidden;
                }
                else
                {
                    this.ShowMessageAsync("Client Not Found!","");
                }
            }
            catch(Exception ex)
            {
                this.ShowMessageAsync(ex.Message, "Remove Client: btnRemoveClient_Click");
            }
        }

        private void txtBoxRemoveClientID_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtBoxRemoveClientID.MaxLength = 13;
            if (txtBoxRemoveClientID.Text == "")
            {
                txtBoxRemoveClientName.Clear();
                txtBoxRemoveClientSurname.Clear();
                txtBoxRemoveClientCellPhone.Clear();
                txtBoxRemoveClientDateOfBirth.Clear();
                txtBoxRemoveClientTelephone.Clear();
                txtBoxRemoveClientAddress.Clear();
                txtBoxRemoveClientEmail.Clear();


                lblClientName.Visibility = Visibility.Hidden;
                lblClientSurname.Visibility = Visibility.Hidden;
                lblClientCellPhone.Visibility = Visibility.Hidden;
                lblClientDateOfBirth.Visibility = Visibility.Hidden;
                lblClientTelephone.Visibility = Visibility.Hidden;
                lblClientAddress.Visibility = Visibility.Hidden;
                lblClientEmail.Visibility = Visibility.Hidden;

                txtBoxRemoveClientName.Visibility = Visibility.Hidden;
                txtBoxRemoveClientSurname.Visibility = Visibility.Hidden;
                txtBoxRemoveClientCellPhone.Visibility = Visibility.Hidden;
                txtBoxRemoveClientDateOfBirth.Visibility = Visibility.Hidden;
                txtBoxRemoveClientTelephone.Visibility = Visibility.Hidden;
                txtBoxRemoveClientAddress.Visibility = Visibility.Hidden;
                txtBoxRemoveClientEmail.Visibility = Visibility.Hidden;
                btnRemoveClient.Visibility = Visibility.Hidden;
            }
        }

        private void lvRestoreClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Client> clientObjects = new List<Client>();
            clientObjects = cbl.SelectAll();

            if (clientObjects.Count > 0)
            {
                foreach (Client temp in clientObjects)
                {
                    if(temp.Archived == Convert.ToBoolean(1))
                    {
                        txtBoxRestoreClientID.Text = temp.idNumber; ;
                        
                    }
                }
              
            }
            else
            {
                this.ShowMessageAsync("There are no Clients to list", "No Clients");
            }
        }


        private void btnRestoreSearch_Click(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            Client clientObj = new Client();

            try
            {
                if(txtBoxRestoreClientID.Text == "")
                {
                    this.ShowMessageAsync("Please Enter Client ID","");
                }
                else
                {
                    rc = cbl.SelectClient(txtBoxRestoreClientID.Text, ref clientObj);
                    if (rc == 0)
                    {
                        if (clientObj.Archived == Convert.ToBoolean(1))
                        {
                            lvRestoreClient.Items.Clear();
                            lvRestoreClient.Items.Add(clientObj);
                        }
                        else
                        {
                            this.ShowMessageAsync("Client Not Found!","");
                        }
                    }
                    else
                    {
                        this.ShowMessageAsync("Client Not Found!","");
                    }

                }
            }
             
            catch(Exception ex)
            {
                this.ShowMessageAsync(ex.Message, "Restore Client: btnRestoreSearch_Click");
            }
        }

        private void txtBoxRestoreClientID_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtBoxRestoreClientID.MaxLength = 13;
            if (txtBoxRestoreClientID.Text == "")
            {
                lvRestoreClient.Items.Clear();
                txtBoxRestoreClientID.Clear();
            }
        }

        private void btnRestoreClient_Click(object sender, RoutedEventArgs e)
        {
            int rc = 0;
            Client clientObj = new Client();

            try
            {
                if (txtBoxRestoreClientID.Text == "")
                {
                    this.ShowMessageAsync("Please Enter Client ID","");
                    txtBoxRestoreClientID.Clear();
                }
                else
                {
                    rc = cbl.SelectClient(txtBoxRestoreClientID.Text, ref clientObj);
                    if (rc == 0 && clientObj.Archived != Convert.ToBoolean(0))
                    {
                        clientObj.Archived = Convert.ToBoolean(0);
                        rc = cbl.Update(clientObj);
                        lvRestoreClient.Items.Clear();
                        txtBoxRestoreClientID.Clear();
                        this.ShowMessageAsync("Client Restored Successfully!","");
                    }
                    else
                    {
                        this.ShowMessageAsync("Client Not Found!","");
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
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lvRestoreClient.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lvRestoreClient.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }


        private void lvListClientsColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);
            string sortBy = column.Tag.ToString();
            if (listViewSortCol != null)
            {
                AdornerLayer.GetAdornerLayer(listViewSortCol).Remove(listViewSortAdorner);
                lvListClient.Items.SortDescriptions.Clear();
            }

            ListSortDirection newDir = ListSortDirection.Ascending;
            if (listViewSortCol == column && listViewSortAdorner.Direction == newDir)
                newDir = ListSortDirection.Descending;

            listViewSortCol = column;
            listViewSortAdorner = new SortAdorner(listViewSortCol, newDir);
            AdornerLayer.GetAdornerLayer(listViewSortCol).Add(listViewSortAdorner);
            lvListClient.Items.SortDescriptions.Add(new SortDescription(sortBy, newDir));
        }

        private void btnRestoreListAll_Click(object sender, RoutedEventArgs e)
        {
            
            List<Client> clientObjects = new List<Client>();
            clientObjects = cbl.SelectAll();
            lvRestoreClient.Items.Clear();

            if (clientObjects.Count > 0)
            {
                lvRestoreClient.Items.Clear();
                foreach (Client temp in clientObjects)
                {
                    if (temp.Archived == Convert.ToBoolean(1))
                        lvRestoreClient.Items.Add(temp);
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
            clientObjects = cbl.SelectAll();
            lvListClient.Items.Clear();

            if (clientObjects.Count > 0)
            {
                lvListClient.Items.Clear();
                foreach (Client temp in clientObjects)
                {
                    if (temp.Archived == Convert.ToBoolean(0))
                        lvListClient.Items.Add(temp);
                }
            }
            else
            {
                this.ShowMessageAsync("There are no Clients to list", "No Clients");
            }
        }

        private void cboListSearch_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ComboBoxItem typeItem = (ComboBoxItem)cboListSearch.SelectedItem;
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
                cboListSearch.Items.Clear();
                cboListSearch.ItemsSource = Data;
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
            if (cboListSearch.SelectedItem.ToString() == "Client ID")
            {
                lvListClient.Items.Clear();
                rc = cbl.SelectClient(txtBoxListSearch.Text, ref clientObj);
                if (rc == 0)
                {
                    lvListClient.Items.Clear();
                    lvListClient.Items.Add(clientObj);
                }
               
            }
            else if (cboListSearch.SelectedItem.ToString() == "Name")
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
                lvListClient.Items.Clear();
                Client clientName = new Client();
                rc = cbl.SelectClientName(txtBoxListSearch.Text, ref clientName);
                if (rc == 0)
                {
                    lvListClient.Items.Clear();
                    lvListClient.Items.Add(clientName);
                }
                else
                {
                    this.ShowMessageAsync("No Client loaded from datastore","No Clients");
                }
            }
            else if (cboListSearch.SelectedItem.ToString() == "Surname")
            {
              
            }
            else if (cboListSearch.SelectedItem.ToString() == "City")
            {
             
            }
            else if (cboListSearch.SelectedItem.ToString() == "Province")
            {
               
            }
            else
            {
                this.ShowMessageAsync("Client Does Not Exist","No Client");
            }
          
        }

        private void addClientTextBoxValidation(object sender, TextChangedEventArgs e)
        {
            if (txtBoxId.Text.Length == 0)
            {
                //txtBoxId.Foreground = System.Windows.Media.Brushes.Red;
                txtBoxId.SetValue(TextBoxHelper.WatermarkProperty, "ID number cannot be empty!");
            }
            else if (txtBoxId.Text.Length > 13)
            {
                txtBoxId.MaxLength = 13;
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
            if (e.DataObject.GetDataPresent(typeof(String)))
            {
                String text = (String)e.DataObject.GetData(typeof(String));
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
            txtBoxCellPhone.MaxLength = 10;
        }

        private void txtBoxTelephone_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtBoxTelephone.MaxLength = 10;
        }
    }
}
public class SortAdorner : Adorner
{
    private static Geometry ascGeometry =
            Geometry.Parse("M 0 4 L 3.5 0 L 7 4 Z");

    private static Geometry descGeometry =
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
                        (AdornedElement.RenderSize.Height - 5) / 2
                );
        drawingContext.PushTransform(transform);

        Geometry geometry = ascGeometry;
        if (this.Direction == ListSortDirection.Descending)
            geometry = descGeometry;
        drawingContext.DrawGeometry(Brushes.Black, null, geometry);

        drawingContext.Pop();
    }
}

    

