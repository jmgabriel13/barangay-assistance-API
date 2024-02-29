using Base.EFCore.Repositories;
using Base.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.Repository
{
    public static class PurposeStatusRepository
    {
        public static PurposeStatusModel GetPurposeStatus(this IRepository<PurposeStatusModel> repository, int id)
        {
            return repository.Get().Where(x => x.Id == id).FirstOrDefault();
        }

        public static IEnumerable<PurposeStatusModel> GetAllPurposeStatus(this IRepository<PurposeStatusModel> repository)
        {
            return repository.Get().ToList();
        }
    }
}
