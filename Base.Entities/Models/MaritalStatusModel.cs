using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Entities.Models
{
    [Table("tbl_marital_status")]
    public class MaritalStatusModel
    {
        [Key]
        public int Id { get; set; }
        public string MaritalStatus { get; set; }
    }
}
