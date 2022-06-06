using AutoMapper;
using Base.EFCore.Repositories;
using Base.Entities.Models;
using Base.Services.Helpers.Utility;
using Base.Services.Repository;
using Microsoft.Extensions.Configuration;
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

        private IConfiguration Configuration { get; }

        public AccountServices(IRepository<UserModel> repo, IRepository<RoleModel> repoRole, IRepository<GenderModel> repoGender, IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _repo = repo;
            _repoRole = repoRole;
            _repoGender = repoGender;
            _unitOfWork = unitOfWork;
            Configuration = configuration;
        }

        public AccountDTO GetAccount(string username, string password)
        {
            var account = _repo.GetAccount(username, Crypto.Encrypt(password));
            if (account == null)
                return null;

            var payloads = new Dictionary<string, string>
            {
                ["userId"] = account.Id.ToString(),
                ["positionId"] = account.Position.ToString(),
                ["userName"] = account.Username.ToString(),
                ["lastName"] = account.LastName.ToString()
            };

            var map = Mapper.Map<UserModel, AccountDTO>(account);
            map.Token = Authenticate(payloads);
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

                //  encrypt password
                userObject.Password = Crypto.Encrypt(userObject.Password);

                _repo.Add(userObject);
                _unitOfWork.SaveChanges();

                _unitOfWork.Commit();
            }
            catch (Exception)
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
                throw;
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
                throw;
            }
        }

        public GenderDTO GetGender(int genderId)
        {
            var gender = _repoGender.GetGender(genderId);
            if (gender == null)
                return null;

            var map = Mapper.Map<GenderModel, GenderDTO>(gender);
            return map;
        }

        public IEnumerable<GenderDTO> GetAllGender()
        {
            var gender = _repoGender.GetAllGender();
            var map = Mapper.Map<IEnumerable<GenderModel>, IEnumerable<GenderDTO>>(gender);
            return map;
        }

        public RoleDTO GetRole(int roleId)
        {
            var role = _repoRole.GetRole(roleId);
            if (role == null)
                return null;

            var map = Mapper.Map<RoleModel, RoleDTO>(role);
            return map;
        }

        public IEnumerable<RoleDTO> GetAllRoles()
        {
            var roles = _repoRole.GetAllRoles();
            var map = Mapper.Map<IEnumerable<RoleModel>, IEnumerable<RoleDTO>>(roles);
            return map;
        }

        public bool ValidateUsername(string username)
        {
            return _repo.ValidateUsername(username.Trim().ToLower());
        }

        public bool ValidateEmail(string email)
        {
            return _repo.ValidateEmail(email.Trim().ToLower());
        }

        public string Authenticate(Dictionary<string, string> payloads, int expireMinutes = 1440)
        {
            List<Claim> claims = new();

            foreach (KeyValuePair<string, string> kpv in payloads)
                claims.Add(new Claim(kpv.Key, kpv.Value));

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(Configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireMinutes)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };

            var CreateToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(CreateToken);

            return token;
        }

        public ClaimsPrincipal GetClaimsPrincipal(string token)
        {
            throw new NotImplementedException();
        }
    }
}
