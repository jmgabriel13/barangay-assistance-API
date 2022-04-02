using Base.EFCore.Repositories;
using Base.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Services.Repository
{
    public static class GenderRepository
    {
        public static GenderModel GetGender(this IRepository<GenderModel> repository, int id)
        {
            return repository.Get().Where(x => x.Id == id).FirstOrDefault();
        }

        public static IEnumerable<GenderModel> GetAllGender(this IRepository<GenderModel> repository)
        {
            return repository.Get().ToList();
        }
    }
}
