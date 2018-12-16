using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikido.DAO.Model
{
    public class dgvClass_ViewModel
    {
        [ColumnName("ID")]
        public int ID { get; set; }
        [ColumnName("Tên Lớp")]
        public string txtName { get; set; }
        [ColumnName("Giờ Học")]
        public string txtStartTime { get; set; }
        [ColumnName("Giờ Kết Thúc")]
        public string txtFinishTime { get; set; }
        [ColumnName("Thứ 2")]
        public bool cbMonday { get; set; }
        [ColumnName("Thứ 3")]
        public bool cbTuesday { get; set; }
        [ColumnName("Thứ 4")]
        public bool cbWednesday { get; set; }
        [ColumnName("Thứ 5")]
        public bool cbThursday { get; set; }
        [ColumnName("Thứ 6")]
        public bool cbFriday { get; set; }
        [ColumnName("Thứ 7")]
        public bool cbSarturday { get; set; }
        [ColumnName("Chủ Nhật")]
        public bool cbSunday { get; set; }
        [ColumnName("Số Học Viên")]
        public int txtAmountClass { get; set; }
    }
}
