using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Entities.Models
{
    [Table("tbl_purposeStatus")]
    public class PurposeStatusModel
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
