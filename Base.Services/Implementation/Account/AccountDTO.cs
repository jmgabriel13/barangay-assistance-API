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
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
