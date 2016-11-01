using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;
using MahApps.Metro.Controls.Dialogs;
using StorageUnitManagementSystem.BL;
using StorageUnitManagementSystem.BL.Binding;
using StorageUnitManagementSystem.BL.Classes;

namespace StorageUnitManagementSystem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private SUBL _suBL;
        //TEST
        

        public List<StorageUnit> suObjects { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            _suBL = new SUBL("StorageUnitSQLiteProvider");
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

        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void listView1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void cb_addClass_DropDownOpened(object sender, EventArgs e)
        {
            
            cb_addClass.Items.Clear();
            //MessageBox.Show(cb_addClass.SelectedItem.ToString());
            suObjects = _suBL.SelectAll();
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
                        break;
                    }

                }
            }
            catch (Exception)
            {
                //Go Home WPF , You're Drunk
            }
        }

        private void btn_addNewUnits_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_noOfNewUnits.Text))
                try
                {
                    for (int x = 0; x < Convert.ToInt16(tb_noOfNewUnits.Text); x++)
                    {

                    }
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.ToString());
                }
            else
            {
                 this.ShowMessageAsync("This is the title", "Some message");
            }
        }

    }
}

