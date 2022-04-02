using System;
using System.Collections.Generic;
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
        public string Remarks { get; set; }
    }
}
