using Base.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Base.Services.Implementation.Complaints
{
    public interface IPurposes
    {
        Task Add(ComplaintsModel compObject, int userId);
        void Update(UpdatePurposeDTO purposeObject, int userId);
        void Delete(int id, int userId);
        bool ValidateComplaints(string name, int? id = null);
        IEnumerable<AbsoluteComplaintsDTO> GetComplaints();
        IEnumerable<AbsoluteComplaintsDTO> GetAssistance();
        IEnumerable<PurposeStatusDTO> GetAllPurposeStatus();
    }
}
