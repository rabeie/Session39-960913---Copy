using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SessionModel.Library;
using RabieiMoeini;

namespace SessionModel
{
    [Table("User", Schema = "People")]
    public class User:Person
    {

       //[ScaffoldColumn(false)]
       // public int UserId { get; set; }
        [MaxLength(50,ErrorMessage ="نام کاربری نباید بیشتر از 50 کاراکتر باشد"), Required(ErrorMessage ="ورود نام کاربری اجباری است"),Index(IsUnique =true)]
        [Display(Name ="نام کاربری")]
        public string Username { get; set; }
        [NotMapped, ScaffoldColumn(true)]
        [Display(Name = "کلمه عبور")]
        public string Password
        {
            get
            {
                return this.PasswordHash;
            }
            set
            {
               this.PasswordHash = UserHelper.CalculateMD5Hash(value);
            }
        }
        [MaxLength(100), ScaffoldColumn(false)]
        public string PasswordHash { get; set; }
        //public object Id { get; set; }
        //public string Role { get; set; }

        //public List<Meeting> Meetings { get; set; } 
    }
}
