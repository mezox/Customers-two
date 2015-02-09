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
using System.ComponentModel;
using System.Collections.Specialized;
using System.Text.RegularExpressions;
using IW5_proj1;

namespace IW5_proj1_GUI
{
    /// <summary>
    /// Interaction logic for CustomerList.xaml
    /// </summary>
    public partial class CustomerList : Window
    {
        #region Class Variables
        //private CustomersCollection m_customers;
        //private List<object> m_checkedToDelete;
        //private XMLWorker<CustomersCollection> m_worker;
        //private bool m_editMode = false;
        //private bool m_dataVal = true;
        private string m_title;
        //private string m_ex;

        private databaseAccess db;
        private int m_customerCount = 0;
        #endregion

        #region Constructors
        public CustomerList()
        {
            InitializeComponent();

            #region customersXML
            //create collection for customers
            //m_customers = new CustomersCollection();

            //create list for delete
            //m_checkedToDelete = new List<object>();

            //new xml worker, use default file Customers.xml in ./ dir
            //m_worker = new XMLWorker<CustomersCollection>();

            //load default file
            //m_title = @"Customers.xml";
            //this.m_customers = m_worker.Load(out m_ex);
            //m_customerCount = m_customers.Count;  

            //set binding data source
            //customersFromFile.ItemsSource = m_customers;
            #endregion
            db = new databaseAccess();

            //update window title [data file]
            this.Title += " | Active File: " + m_title;

            //load customers from database
            this.refreshCustomers();

            this.Show();
        }
        #endregion

        /// <summary>
        /// Handles the Checked event of the checkBoxDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void checkBoxDelete_Checked(object sender, EventArgs e)
        {
            var cb = sender as CheckBox;
            var item = cb.DataContext;

            if(customersFromFile.SelectionMode == SelectionMode.Multiple || (customersFromFile.SelectedItems.Count == 0))
                customersFromFile.SelectedItems.Add(item);
        }

        /// <summary>
        /// Handles the Click event of the buttonDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonDelete_Click(object sender, RoutedEventArgs e)
        {
            //deletes selected customers from DB
            System.Collections.IList items = this.customersFromFile.SelectedItems;
            // any selected item
            if (items.Count == 0)
            {
                MessageBox.Show("No customer was selected! Please select customer and try again.");
                return;
            }

            List<Person> deleteList = new List<Person>();

            //add selected customers to delete list
            foreach (IW5_proj1.Person item in items)
            {
                deleteList.Add(item);
            }

            db.DeleteCustomers(deleteList);

            //refresh customer list and set contacts list data context to null
            this.refreshCustomers();
            this.contactsView.DataContext = null;
        }

        /// <summary>
        /// Handles the Unchecked event of the checkBoxDelete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void checkBoxDelete_Unchecked(object sender, RoutedEventArgs e)
        {
            var cb = sender as CheckBox;
            var item = cb.DataContext;

            customersFromFile.SelectedItems.Remove(item);
        }

        /// <summary>
        /// Fills customer contact information on listview selection change.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="SelectionChangedEventArgs"/> instance containing the event data.</param>
        private void customersFromFile_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Person selectedPerson = (Person)customersFromFile.SelectedItem;

            if(selectedPerson != null)
            {
                this.refreshContacts();
            }
        }

        /// <summary>
        /// Disables multiple row selection in customer list view
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void checkBoxMultiSelect_Unchecked(object sender, RoutedEventArgs e)
        {
            customersFromFile.SelectionMode = SelectionMode.Single;
        }

        /// <summary>
        /// Enables multiple row selection in customer list view
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void checkBoxMultiSelect_Checked(object sender, RoutedEventArgs e)
        {
            customersFromFile.SelectionMode = SelectionMode.Multiple;
        }

        /// <summary>
        /// Opens new add customer window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CustomerMenuItemAdd_Click(object sender, RoutedEventArgs e)
        {
            var nCustomer = new NewCustomerWindow(this);
            nCustomer.Show();
        }

        /// <summary>
        /// Opens new edit customer window and fills textboxes with selected customer info.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void CustomerMenuItemEdit_Click(object sender, RoutedEventArgs e)
        {
            //get selected customer
            Person selectedCustomer = (Person)this.customersFromFile.SelectedItem;

            if(selectedCustomer != null)
            {
                var eCustomer = new EditCustomer(this);
                eCustomer.Show();
            }
            else
            {
                MessageBox.Show("No customer selected! Please select customer and try again.");
            }
        }

        /// <summary>
        /// Deletes selected contact in listview. If no contact is selected shows message box and returns .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void buttonDeleteContact_Click(object sender, RoutedEventArgs e)
        {
            Contact item = (Contact)this.contactsView.SelectedItem;

            // any selected item
            if (item == null)
            {
                MessageBox.Show("No contact was selected! Please select contact and try again.");
                return;
            }
            else
            {
                db.DeleteContact(item);

                //refresh contact list
                this.refreshContacts();
            }
        }

        /// <summary>
        /// Refreshes customers list
        /// </summary>
        public void refreshCustomers()
        {
            using (var ctx = new customersEntities())
            {
                try
                {
                    this.customersFromFile.DataContext = ctx.Person.ToList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Couldnt load database!");
                }
                
            }
        }

        /// <summary>
        /// Refreshes contact list.
        /// </summary>
        public void refreshContacts()
        {
            Person selectedPerson = (Person)customersFromFile.SelectedItem;

            using (var ctx = new customersEntities())
            {
                this.contactsView.DataContext = ctx.Contact.Where(c => c.CustomerId == selectedPerson.Id).ToList();
            }
            
        }

        /// <summary>
        /// Opens new contact window.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void contactAdd_Click(object sender, RoutedEventArgs e)
        {
            var nContact = new NewContact(this);
            nContact.Show();
        }

        /// <summary>
        /// Filters customers.
        /// </summary>
        /// <param name="filterMode">Parameter to filter by [name/surname].</param>
        private void filter(int filterMode)
        {
            var foundList = new List<Person>();

            using(var ctx = new customersEntities())
            {
                var customers = ctx.Person.ToList();

                if(filterMode == 1)
                {
                    foundList.AddRange(customers.Where(c => c.Surname == txtBoxFilter.Text));
                }
                else
                {
                    foundList.AddRange(customers.Where(c => c.Name == txtBoxFilter.Text));
                }
            }

            this.customersFromFile.DataContext = foundList;
        }

        /// <summary>
        /// Filters customer based on combo box value.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void txtBoxFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.comboBoxFilter != null)
            {
                if (string.IsNullOrEmpty(this.txtBoxFilter.Text))
                {
                    this.refreshCustomers();
                }
                else
                {
                    filter(comboBoxFilter.SelectedIndex);
                }
            }
        }

        /// <summary>
        /// Opens edit contact window
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void contactEdit_Click(object sender, RoutedEventArgs e)
        {
            //get selected contact
            Contact selectedContact = (Contact)this.contactsView.SelectedItem;

            if (selectedContact != null)
            {
                var eContact = new EditContact(this);
                eContact.Show();
            }
            else
            {
                MessageBox.Show("No contact selected! Please select contact and try again.");
            }
        }
    }
}