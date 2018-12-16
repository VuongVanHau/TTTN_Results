using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikido.DAO
{
    public class StoreSettingImage_Model
    {
        [Key]
        public int key { get; set; }
        public byte[] ImageSetting { get; set; }
    }
}
