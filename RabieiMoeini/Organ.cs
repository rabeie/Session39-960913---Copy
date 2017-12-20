using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabieiMoeini
{
   public class Organ
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)] public int OrganId { get; set; }
        [MaxLength(100,ErrorMessage ="نام ارگان نباید بیشتر از 100 کراکتر نباشد"), Required(ErrorMessage ="وارد کردن نام ارگان اجباری است")]
        public string OrganName { get; set; }
    }
}
