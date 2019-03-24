using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2.WebAPI.AuthModels
{
    public class AuthRegister
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public long? CreditCardNumber { get; set; }
        public bool AccountType { get; set; }
    }
}
