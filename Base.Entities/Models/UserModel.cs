using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Base.Entities.Models
{
    [Table("tbl_user")]
    public class UserModel : BaseEntity
    {
        [Key]
        public int Id { get; set; }
        public string PhotoPath { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public int Gender { get; set; }
        [Required]
        public int MaritalStatus { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public int Position { get; set; }
        [Required]
        public string Purok { get; set; }
        [Required]
        public DateTime TermFrom { get; set; }
        [Required]
        public DateTime TermTo { get; set; }
    }
}
