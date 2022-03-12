using AutoMapper;
using Base.EFCore.Repositories;
using Base.Entities.Models;
using Base.Services.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Base.Services.Implementation.Account
{
    public class AccountServices : IAccount
    {
        private readonly IRepository<UserModel> _repo;
        public AccountServices(IRepository<UserModel> repo)
        {
            _repo = repo;
        }

        public AccountDTO GetAccount(string username, string password)
        {
            var account = _repo.GetAccount(username, password);
            if (account == null)
                return null;

            var map = Mapper.Map<UserModel, AccountDTO>(account);
            map.Token = GenerateToken();
            return map;
        }

        public IEnumerable<AbsoluteAccountDTO> GetAllAccounts()
        {
            var accounts = _repo.GetAllAccount();
            var map = Mapper.Map<IEnumerable<UserModel>, IEnumerable<AbsoluteAccountDTO>>(accounts);
            return map;
        }

        public string GenerateToken()
        {
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes($"ba secretKey@256"));
            var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: "http://localhost:44360",
                audience: "http://localhost:44360",
                claims: new List<Claim>(),
                expires: DateTime.Now.AddMinutes(30),
                signingCredentials: signingCredentials
            );

            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
            return tokenString;
        }
    }
}
