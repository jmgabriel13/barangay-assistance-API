using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Services.Implementation.Account
{
    public interface IAccount
    {
        AccountDTO GetAccount(string username, string password);
        IEnumerable<AbsoluteAccountDTO> GetAllAccounts();
    }
}
