using System;
using System.Collections.Generic;

namespace BAMTriviaProject2.DAL
{
    public partial class Tusers
    {
        public Tusers()
        {
            Reviews = new HashSet<Reviews>();
            UserQuizzes = new HashSet<UserQuizzes>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pw { get; set; }
        public string Username { get; set; }
        public long? CreditCardNumber { get; set; }
        public int PointTotal { get; set; }
        public bool? AccountType { get; set; }

        public virtual ICollection<Reviews> Reviews { get; set; }
        public virtual ICollection<UserQuizzes> UserQuizzes { get; set; }
    }
}
