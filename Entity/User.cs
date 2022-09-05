using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [RegularExpression(@"^[a-zA-Z]*$")]
        public string UserName { get; set; } = null!;

        [DataType(DataType.EmailAddress)]
        [RegularExpression("^([A-Za-z]|[0-9])+$")]
        public string UserMail { get; set; } = null!;


        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*d)(?=.*[#$^+=!*()@%&]).{8,}$")]
        public string UserPassword { get; set; } = null!;


        public ICollection<SList> SLists { get; set; }
    }
}
