using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BAMTriviaProject2.WebAPI.AuthModels
{
    public class AuthAccountDetails
    {
        public string Username { get; set; }
        public bool AccountType { get; set; }
        public IEnumerable<string> Roles { get; set; }
    }
}
