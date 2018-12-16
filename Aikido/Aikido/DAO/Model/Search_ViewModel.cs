using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Aikido.DAO.Model
{
    public class Search_Model
    {

     
        [ColumnName("Số Đăng Ký")]
        public int RegisterNumber { get; set; }

        [ColumnName("SKU")]
        public string SKU { get; set; }

        [ColumnName("Họ Tên")]
        public String FullName { get; set; }

        [ColumnName("Quốc Tịch")]
        public String Nation { get; set; }

        [ColumnName("Địa Chỉ")]
        public String Address { get; set; }

        [ColumnName("Số Điện Thoại")]
        public String PhoneNumber { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [ColumnName("Ngày Sinh")]
        public DateTime Day_of_Birth { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [ColumnName("Ngày Đăng Ký")]
        public DateTime Day_Create { get; set; }

        [ColumnName("Nơi Sinh")]
        public String Place_of_birth { get; set; }

        [ColumnName("Lớp")]
        public String Class_Name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [ColumnName("DAI Cấp 6")]
        public DateTime DAI_Cap_6 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [ColumnName("DAI Cấp 5")]
        public DateTime DAI_Cap_5 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [ColumnName("DAI Cấp 4")]
        public DateTime DAI_Cap_4 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [ColumnName("DAI Cấp 3")]
        public DateTime DAI_Cap_3 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [ColumnName("DAI Cấp 2")]
        public DateTime DAI_Cap_2 { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [ColumnName("DAI Cấp 1")]
        public DateTime DAI_Cap_1 { get; set; }

        [ColumnName("I DAN VN")]
        public DateTime DAN_VN_1 { get; set; }

        [ColumnName("II DAN VN")]
        public DateTime DAN_VN_2 { get; set; }

        [ColumnName("III DAN VN")]
        public DateTime DAN_VN_3 { get; set; }

        [ColumnName("IV DAN VN")]
        public DateTime DAN_VN_4 { get; set; }

        [ColumnName("V DAN VN")]
        public DateTime DAN_VN_5 { get; set; }

        [ColumnName("VI DAN VN")]
        public DateTime DAN_VN_6 { get; set; }

        [ColumnName("VII DAN VN")]
        public DateTime DAN_VN_7 { get; set; }

        [ColumnName("VIII DAN VN")]
        public DateTime DAN_VN_8 { get; set; }

        [ColumnName("I DAN AIKIKAI")]
        public DateTime DAN_AIKIKAI_1 { get; set; }

        [ColumnName("II DAN AIKIKAI")]
        public DateTime DAN_AIKIKAI_2 { get; set; }

        [ColumnName("III DAN AIKIKAI")]
        public DateTime DAN_AIKIKAI_3 { get; set; }

        [ColumnName("IV DAN AIKIKAI")]
        public DateTime DAN_AIKIKAI_4 { get; set; }

        [ColumnName("V DAN AIKIKAI")]
        public DateTime DAN_AIKIKAI_5 { get; set; }

        [ColumnName("VI DAN AIKIKAI")]
        public DateTime DAN_AIKIKAI_6 { get; set; }

        [ColumnName("VII DAN AIKIKAI")]
        public DateTime DAN_AIKIKAI_7 { get; set; }

        [ColumnName("VIII DAN AIKIKAI")]
        public DateTime DAN_AIKIKAI_8 { get; set; }
        public byte[] Image { get; internal set; }

        public int class_ID { get; set; }
    }
}
