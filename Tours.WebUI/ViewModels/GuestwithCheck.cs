using SessionModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Session.WebUI.ViewModels
{
    public class GuestwithCheck:Guest
    {
        //[Display(Name = "نام")]
        //public string Name { get; set; }
        //[MaxLength(50, ErrorMessage = "نام خانوادگی نباید بیشتر از 50 کاراکتر باشد"), Required(ErrorMessage = "وارد کردن نام خانوادگی اجباری است")]
        //[Display(Name = "نام خانوادگی")]
        //public string Family { get; set; }
        //[MaxLength(200, ErrorMessage = "سمت نباید بیشتر از 200 کاراکتر باشد"), Required(ErrorMessage = "وارد کردن سمت اجباری است")]
        //[Display(Name = "سمت")]
        //public string Post { get; set; }
        //[MaxLength(10, ErrorMessage = "کد ملی نباید بیشتر از 10 کاراکتر باشد"), Required(ErrorMessage = "وارد کردن کدملی اجباری است"), RegularExpression(@"^\d{10}$", ErrorMessage = "کد ملی درست وارد نشده است")]
        //[Display(Name = "کد ملی")]
        //public string NationalCode { get; set; }
        //public int MeetingId { get; set; }
        //[MaxLength(50)]
        //public string In_Out { get; set; }
        //[Required(ErrorMessage = "وارد کردن نام ارگان اجباری است")]
        //public int OrganId { get; set; }
        public bool Selected { get; set; }

    }
}