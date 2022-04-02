using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Services.Implementation.Account
{
    public class UserLoginDTO
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AccountDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get; set; }
    }

    public class AbsoluteAccountDTO
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }
        public string Purok { get; set; }
        public DateTime TermFrom { get; set; }
        public DateTime TermTo { get; set; }
        public bool IsActive { get; set; }
    }
}
