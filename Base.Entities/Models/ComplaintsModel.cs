using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Base.Entities.Models
{
    [Table("tbl_complaints")]
    public class ComplaintsModel : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string Complainant { get; set; }
        public string Statement { get; set; }
        public string Respondent { get; set; }
        public string Involved { get; set; }
        public string Location { get; set; }
        public string Remarks { get; set; }
    }
}
