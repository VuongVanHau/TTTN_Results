using System;
using System.Collections.Generic;
using Aikido.DAO;
using Aikido.DAO.Model;

namespace Aikido.BLO
{

    public class SearchMember_BLO
    {
       
        SearchMember_DAO getdata = new SearchMember_DAO();

        public List<Search_Model> getstudent()
        {
            return getdata.GetStudent();
        }

        public List<Search_Model> SearchCon(String SKU, String HoTen, String NgayDangKy, String NgaySinh)
        {
            return getdata.SearchMember(SKU, HoTen, NgayDangKy, NgaySinh);
        }

        //Tìm kiếm nhanh
        public List<Search_Model> SearchQuick(String key)
        {
            return getdata.QuicSearchMember(key);
        }
    }
}


