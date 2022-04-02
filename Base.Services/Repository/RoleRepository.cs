using Base.EFCore.Repositories;
using Base.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Services.Repository
{
    public static class RoleRepository
    {
        public static RoleModel GetRole(this IRepository<RoleModel> repository, int id)
        {
            return repository.Get().Where(x => x.Id == id).FirstOrDefault();
        }

        public static IEnumerable<RoleModel> GetAllRoles(this IRepository<RoleModel> repository)
        {
            return repository.Get().ToList();
        }
    }
}
