using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SessionModel
{
    [Table("Meetings", Schema = "Meeting")]
    public class Meeting
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int Id { get; set; }
        //[Required]
        //public int PersonId { get; set; }
        [MaxLength(100 ,ErrorMessage = "عنوان جلسه نباید بیشتر از 100 کاراکتر باشد"), Required(ErrorMessage ="وارد کردن عنوان جلسه اجباری است")]
        [Display(Name = "عنوان جلسه")]
        public string TItle { get; set; }
        [MaxLength(10, ErrorMessage = "تاریخ نباید بیشتر از 10 کاراکتر باشد"), Required(ErrorMessage ="وارد کردن تاریخ جلسه اجباری است")]
        [Display(Name = "تاریخ")]
        public string Date { get; set; }
        [MaxLength(5), Required(ErrorMessage = "وارد کردن زمان شروع جلسه اجباری است")]
        [Display(Name = "ساعت شروع")]
        public string StartTime { get; set; }
        [MaxLength(5), Required(ErrorMessage = "وارد کردن زمان پایان جلسه اجباری است")]
        [Display(Name = "ساعت پایان")]
        public string EndTime { get; set; }
        [MaxLength(100)]
        [Display(Name = "مکان جلسه")]
        public string Place { get; set; }
        [MaxLength(300)]
        [Display(Name = "شرح جلسه")]
        public string Explain { get; set; }
        
        public virtual ICollection<Guest> Guests { get; set; }
        public virtual ICollection<Attachment> Attachments { get; set; }
    }
}
