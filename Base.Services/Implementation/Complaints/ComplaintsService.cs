﻿using AutoMapper;
using Base.EFCore.Repositories;
using Base.Entities.Models;
using Base.Services.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Base.Services.Implementation.Complaints
{
    public class ComplaintsService : IComplaints
    {

        private readonly IRepository<ComplaintsModel> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ComplaintsService(IRepository<ComplaintsModel> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
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

        public void Update(ComplaintsModel complaintsObject, int userId)
        {
            _unitOfWork.BeginTransaction();
            try
            {
                var complaints = _repository.GetComplaintsById(complaintsObject.Id);
                complaints.Complainant = complaintsObject.Complainant;
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

        public void Delete(int id, int userId)
        {

            _unitOfWork.BeginTransaction();
            try
            {
                var complaints = _repository.GetComplaintsById(id);
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
            var complaints = _repository.GetComplaints();
            var map = Mapper.Map<IEnumerable<ComplaintsModel>, IEnumerable<AbsoluteComplaintsDTO>>(complaints);
            return map;
        }

        public bool ValidateComplaints(string name, int? id = null)
        {
            throw new NotImplementedException();
        }
    }
}
