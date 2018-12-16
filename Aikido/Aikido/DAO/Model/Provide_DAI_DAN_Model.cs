using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Aikido.DAO
{
    public class Provide_DAI_DAN
    {
        [Key]
        public int ID_Provide { get; set; }

        [ForeignKey("Student")]
        public int RegisterNumber { get; set; }


        [ForeignKey("DAI_DAN")]
        public int ID_DAI_DAN { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Day_Provide { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime Day_Create { get; set; }


        [DataType(DataType.DateTime)]
        public DateTime? Day_Update { get; set; }

        public bool Delete_FLag { get; set; }

        public virtual Student Student { get; set; }
        public virtual DAI_DAN DAI_DAN { get; set; }
    }
}
