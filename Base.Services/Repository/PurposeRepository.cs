using Base.EFCore.Repositories;
using Base.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Services.Repository
{
    public static class PurposeRepository
    {
        public static IEnumerable<ComplaintsModel> GetLists(this IRepository<ComplaintsModel> repository, string type)
        {
            return repository.Get().Where(x => x.IsActive && !x.IsDeleted && x.PurposeType.Trim().ToLower() == type.Trim().ToLower()).ToList();
        }

        public static ComplaintsModel GetPurposeById(this IRepository<ComplaintsModel> repository, int id)
        {
            return repository.Get().Where(x => x.Id == id && x.IsActive && !x.IsDeleted).FirstOrDefault();
        }

        public static ComplaintsModel ValidateComplaints(this IRepository<ComplaintsModel> repository, string name)
        {
            return repository.Get().Where(x => x.Complainant.ToLower() == name.ToLower() && x.IsActive && !x.IsDeleted).FirstOrDefault();
        }

        public static ComplaintsModel ValidateComplaints(this IRepository<ComplaintsModel> repository, string name, int? id)
        {
            return repository.Get().Where(x => x.Complainant.ToLower() == name.ToLower() && x.Id != id && x.IsActive && !x.IsDeleted).FirstOrDefault();
        }
    }
}
