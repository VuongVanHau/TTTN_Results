using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aikido.DAO.Model
{
    public class dgvFee_ViewModel
    {


        [ColumnName("ID_Learn")]
        public int ID_Learn { get; set; }

        [ColumnName("ID_Class")]
        public int ID_Class { get; set; }

        [ColumnName("RegisterNumber")]
        public int RegisterNumber { get; set; }

        [ColumnName("SKU")]
        public string lblSKU { get; set; }

        [ColumnName("Tên Hội Viên")]
        public string lblnameHV { get; set; }

        [ColumnName("Tên Lớp")]
        public string lblnameClass { get; set; }

        [ColumnName("Loại Phí")]
        public string lbltypeFee { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT3A { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT2A { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT1A { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT1P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT2P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT3P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT4P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT5P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT6P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblToTalS { get; set; }
    }
    public class dgvTotalC_ViewModel
    {
        public string lblToal { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT3A { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT2A { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT1A { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT1P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT2P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT3P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT4P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT5P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblmonthHT6P { get; set; }

        [DisplayFormat(DataFormatString = "{#,##0.0}")]
        public decimal lblToTalS { get; set; }
    }
}
