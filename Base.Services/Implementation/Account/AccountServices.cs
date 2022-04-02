using AutoMapper;
using Base.EFCore.Repositories;
using Base.Entities.Models;
using Base.Services.Repository;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Base.Services.Implementation.Account
{
    public class AccountServices : IAccount
    {
        private readonly IRepository<UserModel> _repo;
        private readonly IRepository<RoleModel> _repoRole;
        private readonly IRepository<GenderModel> _repoGender;
        private readonly IUnitOfWork _unitOfWork;
        public AccountServices(IRepository<UserModel> repo, IRepository<RoleModel> repoRole, IRepository<GenderModel> repoGender, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _repoRole = repoRole;
            _repoGender = repoGender;
            _unitOfWork = unitOfWork;
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
            var acc = _repo.GetAllAccount();
            var roles = _repoRole.GetAllRoles();
            var gender = _repoGender.GetAllGender();

            var accounts = from usr in acc
                           join role in roles on usr.Position equals role.Id
                           join gndr in gender on usr.Gender equals gndr.Id
                           select new AbsoluteAccountDTO()
                          {
                               Id = usr.Id,
                               PhotoPath = usr.PhotoPath,
                               FirstName = usr.FirstName,
                               LastName = usr.LastName,
                               Age = usr.Age,
                               Gender = gndr.Description,
                               BirthDate = usr.BirthDate,
                               BirthPlace = usr.BirthPlace,
                               PhoneNumber = usr.PhoneNumber,
                               Email = usr.Email,
                               Position = role.Description,
                               Purok = usr.Purok,
                               TermFrom = usr.TermFrom,
                               TermTo = usr.TermTo,
                               IsActive = usr.IsActive
                          };

            return accounts;
        }

        public void Add(UserModel userObject, int userId)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                userObject.DateCreated = DateTime.Now;
                userObject.CreatedBy = userId;

                _repo.Add(userObject);
                _unitOfWork.SaveChanges();

                _unitOfWork.Commit();
            }
            catch (Exception x)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public void Update(UserModel userObject, int userId)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var account = _repo.GetAccountById(userObject.Id);
                account.Password = userObject.Password;
                account.UpdatedBy = userId;
                account.DateModified = DateTime.Now;

                _repo.Update(account);
                _unitOfWork.SaveChanges();

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
            }
        }

        public void Delete(int id, int userId)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var account = _repo.GetAccountById(id);
                account.IsActive = false;
                account.UpdatedBy = userId;
                account.DateModified = DateTime.Now;

                _repo.Update(account);
                _unitOfWork.SaveChanges();

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
            }
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

        public bool ValidateUsername(string username)
        {
            return _repo.ValidateUsername(username.Trim().ToLower());
        }

        public bool ValidateEmail(string email)
        {
            return _repo.ValidateEmail(email.Trim().ToLower());
        }
    }
}
