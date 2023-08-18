using AutoMapper;
using Base.EFCore.Repositories;
using Base.Entities.Models;
using Base.Services.Helpers.Utility;
using Base.Services.Implementation.Mailer;
using Base.Services.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Base.Services.Implementation.Complaints
{
    public class PurposesService : IPurposes
    {

        private readonly IRepository<ComplaintsModel> _repository;
        private readonly IRepository<PurposeStatusModel> _purposeStatusRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMailService _mailService;

        public PurposesService(IRepository<ComplaintsModel> repository, IRepository<PurposeStatusModel> purposeStatusRepository, IUnitOfWork unitOfWork, IMailService mailService)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _purposeStatusRepository = purposeStatusRepository;
            _mailService = mailService;
        }

        #region Action
        public async Task Add(ComplaintsModel purposeObject, int userId)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                purposeObject.DateCreated = DateTime.Now;
                purposeObject.CreatedBy = userId;

                /// set the status as pending
                purposeObject.Status = (int)EPurposeStatus.PENDING;

                var mail = new MailRequestDTO()
                {
                    ToEmail = purposeObject.Email,
                    Subject = purposeObject.PurposeType,
                    Body = PurposeNotifMessage(purposeObject.Complainant)
                };

                _repository.Add(purposeObject);
                // to be fix the email sending
                //await _mailService.SendEmailAsync(mail);
                await Task.Delay(1000);
                _unitOfWork.SaveChanges();

                _unitOfWork.Commit();
            }
            catch (Exception)
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
                throw;
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
                throw;
            }
        }
        #endregion


        public IEnumerable<AbsoluteComplaintsDTO> GetComplaints()
        {
            var comp = _repository.GetLists("complaints");
            var purposeStatus = _purposeStatusRepository.GetAllPurposeStatus();
            //var map = Mapper.Map<IEnumerable<ComplaintsModel>, IEnumerable<AbsoluteComplaintsDTO>>(complaints);

            var complaints = (from cmp in comp
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
                                 PurposeStatus = status.Description,
                                 DateCreated = cmp.DateCreated
                             }).OrderByDescending(ob => ob.DateCreated);

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

        public static string PurposeNotifMessage(string name)
        {
            string message = "";
            message = "<b>Hi " + name + ",</b> <br/><br/>"
                + "Thanks for getting started with Netwire. <br/><br/>"
                + "Here is your credential details for log in: <br/><br/>"
                + "<i>Do not share these details with anyone. </i>" + "<br/><br/>"
                + "Upon logging in, change your password. <br/><br/>"
                + "Moving forward, you will be receiving OTP (One Time Password) via your email <br/>"
                + "for every login attempt, valid only for 5 mins.<br/><br/><br/>"

                + "Thanks, <br/><br/>"
                + "<b>Baranggay </b>";


            return message;
        }
    }
}
