using Base.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Services.Implementation.Account
{
    public interface IAccount
    {
        AccountDTO GetAccount(string username, string password);
        IEnumerable<AbsoluteAccountDTO> GetAllAccounts();
        void Add(UserModel accountObject, int userId);
        void Update(UserModel accountObject, int userId);
        void Delete(int id, int userId);
        bool ValidateUsername(string username);
        bool ValidateEmail(string email);
    }
}
