using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Aikido.DAO
{
    public class Class
    {
        [Key]
        public int ID_Class { get; set; }

        [Required]
        [StringLength(30)]
        public String Class_Name { get; set; }

        [DataType(DataType.Time)]
        public DateTime Start_Time { get; set; }

        [DataType(DataType.Time)]
        public DateTime End_Time { get; set; }

        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
        public bool Saturday { get; set; }
        public bool Sunday { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Day_Create { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Day_Update { get; set; }

        public bool Delete_Flag { get; set; }

    }
}
