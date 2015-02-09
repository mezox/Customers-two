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
    /// Interaction logic for EditCustomer.xaml
    /// </summary>
    public partial class EditCustomer : Window
    {
        private bool isDataValid = true;
        private CustomerList parentWindow;
        private Person selectedCustomer;
        private databaseAccess db;

        #region Constructors
        public EditCustomer(CustomerList parent)
        {
            this.parentWindow = parent;
            this.db = new databaseAccess(); 

            selectedCustomer = (Person)this.parentWindow.customersFromFile.SelectedItem;

            InitializeComponent();

            fillTextBoxes();
        }
        #endregion

        /// <summary>
        /// Fills text boxes with selected customer information.
        /// </summary>
        private void fillTextBoxes()
        {
            if (selectedCustomer != null)
            {
                txtBoxAddName.Text = selectedCustomer.Name.ToString();
                txtBoxAddSurName.Text = selectedCustomer.Surname;

                if (selectedCustomer.Sex == "m")
                    comboBoxAddSex.SelectedIndex = 0;
                else
                    comboBoxAddSex.SelectedIndex = 1;

                txtBoxAddAge.Text = selectedCustomer.Age.ToString();

                txtBoxAddStreet.Text = selectedCustomer.Street;
                txtBoxAddCity.Text = selectedCustomer.City;
                txtBoxAddZipcode.Text = selectedCustomer.Zipcode;
                txtBoxAddCountry.Text = selectedCustomer.Country;
            }
        }

        /// <summary>
        /// Clears text boxes.
        /// </summary>
        private void resetTextBoxes()
        {
            txtBoxAddAge.Clear();
            txtBoxAddCity.Clear();
            txtBoxAddCountry.Clear();
            txtBoxAddName.Clear();
            txtBoxAddStreet.Clear();
            txtBoxAddSurName.Clear();
            txtBoxAddZipcode.Clear();
        }

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
            this.NameValidationLabel.Visibility = System.Windows.Visibility.Hidden;
            this.SurnameValidationLabel.Visibility = System.Windows.Visibility.Hidden;
            this.AgeValidationLabel.Visibility = System.Windows.Visibility.Hidden;
            this.StreetValidationLabel.Visibility = System.Windows.Visibility.Hidden;
            this.CityValidationLabel.Visibility = System.Windows.Visibility.Hidden;
            this.ZipcodeValidationLabel.Visibility = System.Windows.Visibility.Hidden;
            this.CountryValidationLabel.Visibility = System.Windows.Visibility.Hidden;
        }

        /// <summary>
        /// Validates data in Name textbox
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validateName(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxAddName.Text) || !Regex.IsMatch(txtBoxAddName.Text, @"^[a-zA-Z]+$"))
            {
                this.NameValidationLabel.Visibility = System.Windows.Visibility.Visible;
                isDataValid = false;
            }
            else
            {
                this.NameValidationLabel.Visibility = System.Windows.Visibility.Hidden;
                isDataValid = true;
            }
        }

        /// <summary>
        /// Validates data in Surname box.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validateSurName(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxAddSurName.Text) || !Regex.IsMatch(txtBoxAddSurName.Text, @"^[a-z A-Z]+$"))
            {
                this.SurnameValidationLabel.Visibility = System.Windows.Visibility.Visible;
                isDataValid = false;
            }
            else
            {
                this.SurnameValidationLabel.Visibility = System.Windows.Visibility.Hidden;
                isDataValid = true;
            }
        }

        /// <summary>
        /// Validates age.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validateAge(object sender, TextChangedEventArgs e)
        {
            uint number = 0;
            if (!uint.TryParse(txtBoxAddAge.Text.Trim(), out number))
            {
                AgeValidationLabel.Visibility = System.Windows.Visibility.Visible;
                isDataValid = false;
            }
            else
            {
                AgeValidationLabel.Visibility = System.Windows.Visibility.Hidden;
                isDataValid = true;
            }
        }

        /// <summary>
        /// Validates street.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validateStreet(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxAddStreet.Text))
            {
                StreetValidationLabel.Visibility = System.Windows.Visibility.Visible;
                isDataValid = false;
            }
            else
            {
                StreetValidationLabel.Visibility = System.Windows.Visibility.Hidden;
                isDataValid = true;
            }
        }

        /// <summary>
        /// Validates city.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validateCity(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxAddCity.Text) || !Regex.IsMatch(txtBoxAddCity.Text, @"^[a-z A-Z]+$"))
            {
                CityValidationLabel.Visibility = System.Windows.Visibility.Visible;
                isDataValid = false;
            }
            else
            {
                CityValidationLabel.Visibility = System.Windows.Visibility.Hidden;
                isDataValid = true;
            }
        }

        /// <summary>
        /// Validates postal/zipcode.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validateZipcode(object sender, TextChangedEventArgs e)
        {
            uint zipcode;

            if (string.IsNullOrEmpty(txtBoxAddZipcode.Text) || !uint.TryParse(txtBoxAddZipcode.Text.Trim(), out zipcode))
            {
                ZipcodeValidationLabel.Visibility = System.Windows.Visibility.Visible;
                isDataValid = false;
            }
            else
            {
                ZipcodeValidationLabel.Visibility = System.Windows.Visibility.Hidden;
                isDataValid = true;
            }
        }

        /// <summary>
        /// Validates country.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="TextChangedEventArgs"/> instance containing the event data.</param>
        private void validateCountry(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxAddCountry.Text) || !Regex.IsMatch(txtBoxAddCountry.Text, @"^[a-z A-Z]+$"))
            {
                CountryValidationLabel.Visibility = System.Windows.Visibility.Visible;
                isDataValid = false;
            }
            else
            {
                CountryValidationLabel.Visibility = System.Windows.Visibility.Hidden;
                isDataValid = true;
            }
        }

        /// <summary>
        /// Adds customer to database
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            if (isDataValid)
            {
                //create new object representing edited customer
                Person editedCustomer = new Person();

                editedCustomer.Name = txtBoxAddName.Text;
                editedCustomer.Surname = txtBoxAddSurName.Text;
                editedCustomer.Sex = (comboBoxAddSex.SelectedIndex == 0) ? "m" : "f";
                editedCustomer.Age = int.Parse(txtBoxAddAge.Text);
                editedCustomer.Street = txtBoxAddStreet.Text;
                editedCustomer.City = txtBoxAddCity.Text;
                editedCustomer.Zipcode = txtBoxAddZipcode.Text;
                editedCustomer.Country = txtBoxAddCountry.Text;

                //edit customer in database
                db.EditCustomerInDB(selectedCustomer.Id, editedCustomer);

                this.Hide();
                this.parentWindow.refreshCustomers();
            }
            else
            {
                MessageBox.Show("Missing some required data or wrong data format!");
            }
        }
    }
}
