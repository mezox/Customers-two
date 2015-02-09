using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW5_proj1
{
    /// <summary>
    /// Class for representing database operations with customers and their contacts
    /// </summary>
    public class databaseAccess
    {
        #region Constructors
        public databaseAccess() { }
        #endregion

        /// <summary>
        /// Edits the customer in database.
        /// </summary>
        public void EditCustomerInDB(int id, Person customer)
        {
            using (var ctx = new customersEntities())
            {
                var original = ctx.Person.Find(id);

                if (original != null)
                {
                    original.Name = customer.Name;
                    original.Surname = customer.Surname;
                    original.Sex = customer.Sex;
                    original.Age = customer.Age;
                    original.Street = customer.Street;
                    original.City = customer.City;
                    original.Zipcode = customer.Zipcode;
                    original.Country = customer.Country;
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Adds the new contact to database.
        /// </summary>
        public void AddNewContactToDB(Contact contact)
        {
            using (var ctx = new customersEntities())
            {
                //create new database customer object
                IW5_proj1.Contact newContact = ctx.Contact.Create();

                //insert Contact info to specified person in database object
                newContact.Email = contact.Email;
                newContact.Phone = contact.Phone;
                newContact.CustomerId = contact.CustomerId;

                //add, save customer to db and refresh list
                ctx.Contact.Add(newContact);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Edits the contact in database.
        /// </summary>
        /// <param name="selectedContact">The selected contact.</param>
        public void EditContactInDB(int id, Contact contact)
        {
            using (var ctx = new customersEntities())
            {
                //get original object
                var original = ctx.Contact.Find(id);

                if (original != null)
                {
                    //change values
                    original.Email = contact.Email;
                    original.Phone = contact.Phone;

                    //save changes in database
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Adds the customer to database.
        /// </summary>
        public void AddCustomerToDB(Person customer)
        {
            using (var ctx = new customersEntities())
            {
                //create new database customer object
                IW5_proj1.Person newCustomer = ctx.Person.Create();

                //insert person info in database object
                newCustomer.Name = customer.Name;
                newCustomer.Surname = customer.Surname;
                newCustomer.Sex = customer.Sex;
                newCustomer.Age = customer.Age;
                newCustomer.Street = customer.Street;
                newCustomer.City = customer.City;
                newCustomer.Zipcode = customer.Zipcode;
                newCustomer.Country = customer.Country;

                //add, save customer to db and refresh list
                ctx.Person.Add(newCustomer);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes selected customers from database.
        /// </summary>
        /// <param name="deleteList">list of customers to delete.</param>
        public void DeleteCustomers(List<Person> deleteList)
        {
            using (var ctx = new customersEntities())
            {
                //delete them from database
                foreach (IW5_proj1.Person item in deleteList)
                {
                    var deleteCustomer = ctx.Person.First(c => c.Id == item.Id);

                    //delete them from database
                    ctx.Person.Remove(deleteCustomer);

                    //save changes and refresh list
                    ctx.SaveChanges();
                }
            }
        }

        /// <summary>
        /// Deletes the contact.
        /// </summary>
        /// <param name="item">The item.</param>
        public void DeleteContact(Contact item)
        {
            //create datacontext and delete
            using (var ctx = new customersEntities())
            {
                var deleteContact = ctx.Contact.First(c => c.Id == item.Id);

                //delete them from database
                ctx.Contact.Remove(deleteContact);

                //save changes and refresh list
                ctx.SaveChanges();
            }
        }

    }
}
