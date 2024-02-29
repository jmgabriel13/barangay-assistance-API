using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Base.Entities.Models
{
    public class BaseEntity
    {
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public BaseEntity()
        {
            IsActive = true;
            IsDeleted = false;
            DateCreated = DateTime.Now;
        }
    }
}
