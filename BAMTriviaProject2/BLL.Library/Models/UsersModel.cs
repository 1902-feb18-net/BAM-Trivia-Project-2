using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Library.Models
{
    public class UsersModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pw { get; set; }
        public string Username { get; set; }
        public long? CreditCardNumber { get; set; }
        public int PointTotal { get; set; }
        public bool? AccountType { get; set; }
    }
}
