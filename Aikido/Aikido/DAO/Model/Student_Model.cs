using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aikido.DAO
{
    public class Student
    {
        [Key]
        public int RegisterNumber { get; set; }

        [Required]
        [StringLength(20)]
        [Index(IsUnique = true)]
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

        [Required]
        [Phone]
        public String PhoneNumber { get; set; }

        public byte[] Image { get; set; }


        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Day_of_Birth { get; set; }

        [Required]
        [StringLength(50)]
        public String Place_of_Birth { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Day_Create { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Day_Update { get; set; }

        public bool Delete_Flag { get; set; }
    }
}

