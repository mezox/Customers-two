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
using System.Text.RegularExpressions;
using IW5_proj1;

namespace IW5_proj1_GUI
{
    /// <summary>
    /// Interaction logic for NewContact.xaml
    /// </summary>
    public partial class NewContact : Window
    {
        #region Private properties
        private bool isDataValid = true;
        private CustomerList parentWindow;
        private databaseAccess db;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="NewContact"/> class.
        /// </summary>
        public NewContact(CustomerList parent)
        {
            this.parentWindow = parent;
            this.db = new databaseAccess();

            InitializeComponent();

            //fill customers in combobox
            using (var ctx = new customersEntities())
            {
                CustomerComboBox.ItemsSource = ctx.Person.ToList();
                CustomerComboBox.SelectedValuePath = "Id";
            }
        }

        /// <summary>
        /// Validates phone number.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validatePhone(object sender, TextChangedEventArgs e)
        {
            uint number = 0;
            if (!uint.TryParse(txtBoxAddPhone.Text.Trim(), out number))
            {
                PhoneValidationLabel.Visibility = System.Windows.Visibility.Visible;
                isDataValid = false;
            }
            else
            {
                PhoneValidationLabel.Visibility = System.Windows.Visibility.Hidden;
                isDataValid = true;
            }
        }

        /// <summary>
        /// Validates email.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validateEmail(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxAddEmail.Text) || !Regex.IsMatch(txtBoxAddEmail.Text, @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+[.][a-zA-Z]+$"))
            {
                this.EmailValidationLabel.Visibility = System.Windows.Visibility.Visible;
                isDataValid = false;
            }
            else
            {
                this.EmailValidationLabel.Visibility = System.Windows.Visibility.Hidden;
                isDataValid = true;
            }
        }

        /// <summary>
        /// Handles the Click event of the btnAddEmail control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void btnAddContact_Click(object sender, RoutedEventArgs e)
        {
            //get selected value
            var item = CustomerComboBox.SelectedItem as Person;
            int personID = item.Id;

            if (isDataValid)
            {
                //create new contact object
                Contact newContact = new Contact();

                newContact.Email = txtBoxAddEmail.Text;
                newContact.Phone = txtBoxAddPhone.Text;
                newContact.CustomerId = personID;

                //add contact to database
                db.AddNewContactToDB(newContact);
                    
                this.Hide();
                parentWindow.refreshContacts();
            }
            else
            {
                MessageBox.Show("Missing some required data or wrong data format!");
            }
        }
    }
}
