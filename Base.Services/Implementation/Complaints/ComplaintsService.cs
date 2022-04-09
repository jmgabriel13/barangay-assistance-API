using AutoMapper;
using Base.EFCore.Repositories;
using Base.Entities.Models;
using Base.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Base.Services.Implementation.Complaints
{
    public class ComplaintsService : IComplaints
    {

        private readonly IRepository<ComplaintsModel> _repository;
        private readonly IRepository<PurposeStatusModel> _purposeStatusRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ComplaintsService(IRepository<ComplaintsModel> repository, IRepository<PurposeStatusModel> purposeStatusRepository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _purposeStatusRepository = purposeStatusRepository;
        }

        #region Action
        public void Add(ComplaintsModel complaintsObject, int userId)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                complaintsObject.DateCreated = DateTime.Now;
                complaintsObject.CreatedBy = userId;

                _repository.Add(complaintsObject);
                _unitOfWork.SaveChanges();

                _unitOfWork.Commit();
            }
            catch (Exception x)
            {
                _unitOfWork.RollBack();
                throw;
            }
        }

        public void Update(UpdatePurposeDTO purposeObject, int userId)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var purpose = _repository.GetPurposeById(purposeObject.Id);
                purpose.Complainant = purposeObject.Complainant;
                purpose.Statement = purposeObject.Statement;
                purpose.Respondent = purposeObject.Respondent;
                purpose.Involved = purposeObject.Involved;
                purpose.Status = purposeObject.PurposeStatus;
                purpose.UpdatedBy = userId;
                purpose.DateModified = DateTime.Now;

                _repository.Update(purpose);
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
                var complaints = _repository.GetPurposeById(id);
                complaints.IsActive = false;
                complaints.IsDeleted = true;
                complaints.UpdatedBy = userId;
                complaints.DateModified = DateTime.Now;

                _repository.Update(complaints);
                _unitOfWork.SaveChanges();

                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                _unitOfWork.RollBack();
            }
        }
        #endregion

        public IEnumerable<AbsoluteComplaintsDTO> GetComplaints()
        {
            var comp = _repository.GetLists("complaints");
            var purposeStatus = _purposeStatusRepository.GetAllPurposeStatus();
            //var map = Mapper.Map<IEnumerable<ComplaintsModel>, IEnumerable<AbsoluteComplaintsDTO>>(complaints);

            var complaints = from cmp in comp
                             join status in purposeStatus on cmp.Status equals status.Id
                             select new AbsoluteComplaintsDTO()
                             {
                                 Id = cmp.Id,
                                 Complainant = cmp.Complainant,
                                 Statement = cmp.Statement,
                                 Respondent = cmp.Respondent,
                                 Involved = cmp.Involved,
                                 ProofImgPath = cmp.ProofImgPath,
                                 VerificationImgPath = cmp.VerificationImgPath,
                                 Location = cmp.Location,
                                 PurposeStatus = status.Description
                             };

            return complaints;
        }

        public IEnumerable<AbsoluteComplaintsDTO> GetAssistance()
        {
            var assist = _repository.GetLists("assistance");
            var purposeStatus = _purposeStatusRepository.GetAllPurposeStatus();

            var assistances = from cmp in assist
                             join status in purposeStatus on cmp.Status equals status.Id
                             select new AbsoluteComplaintsDTO()
                             {
                                 Id = cmp.Id,
                                 Complainant = cmp.Complainant,
                                 Statement = cmp.Statement,
                                 Respondent = cmp.Respondent,
                                 Involved = cmp.Involved,
                                 ProofImgPath = cmp.ProofImgPath,
                                 VerificationImgPath = cmp.VerificationImgPath,
                                 Location = cmp.Location,
                                 PurposeStatus = status.Description
                             };

            return assistances;
        }

        public bool ValidateComplaints(string name, int? id = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PurposeStatusDTO> GetAllPurposeStatus()
        {
            var roles = _purposeStatusRepository.GetAllPurposeStatus();
            var map = Mapper.Map<IEnumerable<PurposeStatusModel>, IEnumerable<PurposeStatusDTO>>(roles);
            return map;
        }
    }
}
