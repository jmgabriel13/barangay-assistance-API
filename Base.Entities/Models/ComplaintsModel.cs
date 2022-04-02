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
        [Required]
        public string Complainant { get; set; }
        [Required]
        public string ContactNo { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Statement { get; set; }
        public string Respondent { get; set; }
        [Required]
        public string Involved { get; set; }
        [Required]
        public string ProofImgPath { get; set; }
        [Required]
        public string VerificationImgPath { get; set; }
        [Required]
        public string Location { get; set; }
        public string Remarks { get; set; }
    }
}
