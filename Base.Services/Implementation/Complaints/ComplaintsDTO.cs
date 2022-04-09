using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Base.Services.Implementation.Complaints
{
    public class ComplaintsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class AbsoluteComplaintsDTO
    {
        public int Id { get; set; }
        public string Complainant { get; set; }
        public string Statement { get; set; }
        public string Respondent { get; set; }
        public string Involved { get; set; }
        public string ProofImgPath { get; set; }
        public string VerificationImgPath { get; set; }
        public string Location { get; set; }
        public string PurposeStatus { get; set; }
    }

    public class PurposeStatusDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class UpdatePurposeDTO
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Complainant { get; set; }
        [Required]
        public string Statement { get; set; }
        [Required]
        public string Respondent { get; set; }
        [Required]
        public string Involved { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public int PurposeStatus { get; set; }
    }
}
