using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Base.Entities.Models
{
    [Table("tbl_gender")]
    public class GenderModel
    {
        [Key]
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string Description { get; set; }
    }
}
