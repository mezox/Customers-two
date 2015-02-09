using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

using System.Xml;
using System.Xml.Serialization;

namespace IW5_proj1
{
    /// <summary>
    /// Collection of customers
    /// </summary>
    [Serializable]
    public class CustomersCollection: ObservableCollection<Person>,INotifyPropertyChanged
    {
        public CustomersCollection() : base() { }
    }

    /// <summary>
    /// Class representing a customer
    /// </summary>
    public partial class Person
    {
        #region Constructors

        //creates Person object
        public Person(  string name, string surname,
                        string s, int age,
                        string street, string city, string zipcode, string country,
                        int id = 0)
        {
            this.Id = id;
            this.Name = name.Substring(0, 1).ToUpper() + name.Substring(1);
            this.Surname = surname.Substring(0, 1).ToUpper() + surname.Substring(1);
            this.Age = age;
            this.Street = street;
            this.City = city;
            this.Zipcode = zipcode;
            this.Country = country;

            if(s == "f")
                this.Sex = "f";
            else
                this.Sex = "m";
        }
        #endregion
    }
}
