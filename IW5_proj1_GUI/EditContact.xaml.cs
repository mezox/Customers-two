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
    /// Interaction logic for EditContact.xaml
    /// </summary>
    public partial class EditContact : Window
    {
        #region Private properties
        private bool isDataValid = true;
        private CustomerList parentWindow;
        private Contact selectedContact;
        private databaseAccess db;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="NewContact"/> class.
        /// </summary>
        public EditContact(CustomerList parent)
        {
            this.parentWindow = parent;
            this.db = new databaseAccess();

            InitializeComponent();

            selectedContact = (Contact)this.parentWindow.contactsView.SelectedItem;

            fillTextBoxes();
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the ClearButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            //clear text boxes
            this.resetTextBoxes();

            //hide validation labels
            this.EmailValidationLabel.Visibility = System.Windows.Visibility.Hidden;
            this.PhoneValidationLabel.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Fills text boxes with selected customer information.
        /// </summary>
        private void fillTextBoxes()
        {
            if (selectedContact != null)
            {
                txtBoxEditEmail.Text = selectedContact.Email.ToString();
                txtBoxEditPhone.Text = selectedContact.Phone.ToString();
            }
        }

        /// <summary>
        /// Clears text boxes.
        /// </summary>
        private void resetTextBoxes()
        {
            txtBoxEditEmail.Clear();
            txtBoxEditPhone.Clear();
        }

        /// <summary>
        /// Validates phone number.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validatePhone(object sender, TextChangedEventArgs e)
        {
            uint number = 0;
            if (!uint.TryParse(txtBoxEditPhone.Text.Trim(), out number))
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
            if (string.IsNullOrEmpty(txtBoxEditEmail.Text) || !Regex.IsMatch(txtBoxEditEmail.Text, @"^[-a-zA-Z0-9][-.a-zA-Z0-9]*@[-.a-zA-Z0-9]+[.][a-zA-Z]+$"))
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
        private void btnEditEmail_Click(object sender, RoutedEventArgs e)
        {
            if (isDataValid)
            {
                //create new object representing edited contact
                Contact editedContact = new Contact();

                editedContact.Email = txtBoxEditEmail.Text;
                editedContact.Phone = txtBoxEditPhone.Text;

                //edit contact in database
                db.EditContactInDB(selectedContact.Id, editedContact);

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
