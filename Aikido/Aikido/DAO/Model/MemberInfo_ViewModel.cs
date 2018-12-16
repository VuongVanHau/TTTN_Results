using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikido.DAO.Model
{
   public  class MemberInfo_ViewModel
    {
        [Key]
        public int RegisterNumber { get; set; }

        [Required]
        [StringLength(20)]
        public String SKU { get; set; }

        [Required]
        [StringLength(50)]
        public String FullName { get; set; }

        [Required]
        [StringLength(50)]
        public String Nation { get; set; }

        [Required]
        [StringLength(100)]
        public String Address { get; set; }

        public byte[] Image { get; set; }

        [Required]
        [Phone]
        public String PhoneNumber { get; set; }

        [DataType(DataType.Date)]
        public DateTime Day_of_Birth { get; set; }

        [Required]
        [StringLength(50)]
        public String Place_of_Birth { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Register_day { get; set; }

        [Key]
        public int ID_Class { get; set; }

        [Required]
        [StringLength(30)]
        public String Class_Name { get; set; }

        public int ID_DAI_DAN { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Day_Provide { get; set; }


        public Dictionary<string, DateTime> listLevel { get; set; }



    }
}
