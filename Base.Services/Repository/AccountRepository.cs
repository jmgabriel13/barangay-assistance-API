﻿using Base.EFCore.Repositories;
using Base.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Services.Repository
{
    public static class AccountRepository
    {
        public static UserModel GetAccount(this IRepository<UserModel> repository, string username, string password)
        {
            return repository.Get().Where(x => x.Username == username && x.Password == password
                                          && x.IsActive && !x.IsDeleted).FirstOrDefault();
        }

        public static IEnumerable<UserModel> GetAllAccount(this IRepository<UserModel> repository)
        {
            return repository.Get().Where(x => x.IsActive && !x.IsDeleted).ToList();
        }

        public static UserModel GetAccountById(this IRepository<UserModel> repository, int id)
        {
            return repository.Get().Where(x => x.Id == id && x.IsActive && !x.IsDeleted).FirstOrDefault();
        }

        public static bool ValidateUsername(this IRepository<UserModel> repository, string username)
        {
            return repository.Get().Any(w => w.Username.Trim().ToLower() == username);
        }

        public static bool ValidateEmail(this IRepository<UserModel> repository, string email)
        {
            return repository.Get().Any(w => w.Email.Trim().ToLower() == email);
        }
    }
}
