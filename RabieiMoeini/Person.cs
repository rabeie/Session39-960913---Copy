using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabieiMoeini
{
    [Table("Person", Schema = "People")]
    public abstract class Person
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [MaxLength(50,ErrorMessage ="نام نباید بیشتر از 50 کاراکتر باشد"), Required(ErrorMessage = "وارد کردن نام اجباری است")]
       [Display(Name="نام")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "نام خانوادگی نباید بیشتر از 50 کاراکتر باشد"), Required(ErrorMessage = "وارد کردن نام خانوادگی اجباری است")]
        [Display(Name = "نام خانوادگی")]
        public string Family { get; set; }
        [MaxLength(200, ErrorMessage = "سمت نباید بیشتر از 200 کاراکتر باشد")]
        [Display(Name = "سمت")]
        public string Post { get; set; }
        [MaxLength(10, ErrorMessage = "کد ملی نباید بیشتر از 10 کاراکتر باشد"),RegularExpression(@"^\d{10}$",ErrorMessage ="کد ملی درست وارد نشده است")]
        [Display(Name = "کد ملی")]
        public string NationalCode { get; set; }
        [Timestamp]
        [ScaffoldColumn(false)]
        public byte[] RowVersion { get; set; }
    }
}
