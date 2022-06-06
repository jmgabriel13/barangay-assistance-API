using Base.Entities.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace Base.Services.Implementation.Account
{
    public interface IAccount
    {
        AccountDTO GetAccount(string username, string password);
        string Authenticate(Dictionary<string, string> payloads, int expireMinutes = 1440);
        ClaimsPrincipal GetClaimsPrincipal(string token);
        IEnumerable<AbsoluteAccountDTO> GetAllAccounts();
        void Add(UserModel accountObject, int userId);
        void Update(UserModel accountObject, int userId);
        void Delete(int id, int userId);
        bool ValidateUsername(string username);
        bool ValidateEmail(string email);
        GenderDTO GetGender(int genderId);
        IEnumerable<GenderDTO> GetAllGender();
        RoleDTO GetRole(int roleId);
        IEnumerable<RoleDTO> GetAllRoles();
    }
}
