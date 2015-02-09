using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IW5_proj1
{
    /// <summary>
    /// Customer Address information
    /// </summary>
    public partial class Contact
    {
        #region Constructors
        public Contact() { }

        public Contact(string email, string phone)
        {
            this.Email = email;
            this.Phone = phone;
        }
        #endregion
    }
}
