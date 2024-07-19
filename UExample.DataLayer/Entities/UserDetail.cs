using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UExample.DataLayer
{
    public class UserDetail
    {
        [Key]
        [Display(Name = "آیدی")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [ForeignKey("User")]
        public Guid User_Id { get; set; }

        [Display(Name = "شماره موبایل")]
        [MaxLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }

        [Display(Name = "بیوگرافی")]
        [MaxLength(950)]
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }



        //Navigation Properties
        public virtual User User { get; set; }

        public UserDetail()
        {
            
        }
    }
}
