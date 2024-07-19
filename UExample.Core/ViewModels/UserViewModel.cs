using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UExample.Core
{
    public class UserViewModel
    {
        [Display(Name = "آیدی")]
        public Guid Id { get; set; }

        [Display(Name = "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(20)]
        public string Username { get; set; }

        [Display(Name = "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(100)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        //*******************************************************

        [Display(Name = "آیدی")]
        public Guid User_Id { get; set; }

        [Display(Name = "شماره موبایل")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Display(Name = "بیوگرافی")]
        [MaxLength(350)]
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }
    }
}
