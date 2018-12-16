using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikido.DAO
{
    public class Fee_Model
    {
        [Key]
        public int ID_Learn { get; set; }

        [ForeignKey("Student")]
        public int RegisterNumber { get; set; }

        [ForeignKey("Class")]
        public int ID_Class { get; set; }

        public string Fee_Type { get; set; }

        public int Month { get; set; }

        public int Year { get; set; }

        public decimal Fee_Value { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime Day_Create { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? Day_Update { get; set; }

        public bool Delete_Flag { get; set; }
    }
}
