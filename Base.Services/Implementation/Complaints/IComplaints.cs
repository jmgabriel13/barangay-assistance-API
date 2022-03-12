using Base.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Services.Implementation.Complaints
{
    public interface IComplaints
    {
        void Add(ComplaintsModel jobObject, int userId);
        void Update(ComplaintsModel jobObject, int userId);
        void Delete(int id, int userId);
        bool ValidateComplaints(string name, int? id = null);
        IEnumerable<AbsoluteComplaintsDTO> GetComplaints();
    }
}
