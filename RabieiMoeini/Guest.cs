using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabieiMoeini;

namespace SessionModel
{
    [Table("Guest", Schema = "People")]
    public class Guest:Person
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(false)]
        public int Id { get; set; }
        public int MeetingId { get; set; }
        [MaxLength(50)]
        public string In_Out { get; set; }
        //[Required(ErrorMessage = "وارد کردن نام ارگان اجباری است")]
        public int OrganId { get; set; }
       public virtual ICollection<Meeting> Meetings { get; internal set; }

        //public bool Selected { get; set; } = false;
    }
}
