using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using Aikido.DAO.Model;
using Microsoft.EntityFrameworkCore.Internal;

namespace Aikido.DAO
{

    public class SearchMember_DAO
    {

        //lấy dữ liệu
        public List<Search_Model> GetStudent()
        {

            using (var dbContext = new AccessDB_DAO())
            {


                List<Search_Model> datas = new List<Search_Model>();
                try
                {
                     var query = dbContext.Fees.GroupBy(c => new { c.RegisterNumber, c.ID_Class }).Select(g=>g.First());   //Minh modified 4/8/2018
                    foreach (var i in query)
                    {
                        var MemberInfo = dbContext.Students.Single(c => c.RegisterNumber == i.RegisterNumber);
                        var ClassInfo = dbContext.Classes.Single(l => l.ID_Class == i.ID_Class);
                        Search_Model data = new Search_Model();
                        data.RegisterNumber = i.RegisterNumber;
                        data.SKU = MemberInfo.SKU;
                        data.FullName = MemberInfo.FullName;
                        data.Nation = MemberInfo.Nation;
                        data.Address = MemberInfo.Address;
                        data.PhoneNumber = MemberInfo.PhoneNumber;
                        data.Day_of_Birth = MemberInfo.Day_of_Birth.Date;
                        data.Place_of_birth = MemberInfo.Place_of_Birth;
                        data.Day_Create = MemberInfo.Day_Create.Date;
                        data.class_ID = ClassInfo.ID_Class;
                        data.Class_Name = ClassInfo.Class_Name;
                        data.Image = MemberInfo.Image;

                        //Lấy Mã DAI DAN
                        foreach (var dd in dbContext.Provide_Dai_Dans.Where(s => s.RegisterNumber == i.RegisterNumber))
                        {
                            var na = dbContext.Dai_Dans.Where(s => s.ID == dd.ID_DAI_DAN).First();
                            if (na.Name.Equals("Cap6")) data.DAI_Cap_6 = dd.Day_Provide;
                            if (na.Name.Equals("Cap5")) data.DAI_Cap_5 = dd.Day_Provide;
                            if (na.Name.Equals("Cap4")) data.DAI_Cap_4 = dd.Day_Provide;
                            if (na.Name.Equals("Cap3")) data.DAI_Cap_3 = dd.Day_Provide;
                            if (na.Name.Equals("Cap2")) data.DAI_Cap_2 = dd.Day_Provide;
                            if (na.Name.Equals("Cap1")) data.DAI_Cap_1 = dd.Day_Provide;
                            if (na.Name.Equals("DANVN1")) data.DAN_VN_1 = dd.Day_Provide;
                            if (na.Name.Equals("DANVN2")) data.DAN_VN_2 = dd.Day_Provide;
                            if (na.Name.Equals("DANVN3")) data.DAN_VN_3 = dd.Day_Provide;
                            if (na.Name.Equals("DANVN4")) data.DAN_VN_4 = dd.Day_Provide;
                            if (na.Name.Equals("DANVN5")) data.DAN_VN_5 = dd.Day_Provide;
                            if (na.Name.Equals("DANVN6")) data.DAN_VN_6 = dd.Day_Provide;
                            if (na.Name.Equals("DANVN7")) data.DAN_VN_7 = dd.Day_Provide;
                            if (na.Name.Equals("DANVN8")) data.DAN_VN_8 = dd.Day_Provide;
                            if (na.Name.Equals("DANAIKIKAI1")) data.DAN_AIKIKAI_1 = dd.Day_Provide;
                            if (na.Name.Equals("DANAIKIKAI2")) data.DAN_AIKIKAI_2 = dd.Day_Provide;
                            if (na.Name.Equals("DANAIKIKAI3")) data.DAN_AIKIKAI_3 = dd.Day_Provide;
                            if (na.Name.Equals("DANAIKIKAI4")) data.DAN_AIKIKAI_4 = dd.Day_Provide;
                            if (na.Name.Equals("DANAIKIKAI5")) data.DAN_AIKIKAI_5 = dd.Day_Provide;
                            if (na.Name.Equals("DANAIKIKAI6")) data.DAN_AIKIKAI_6 = dd.Day_Provide;
                            if (na.Name.Equals("DANAIKIKAI7")) data.DAN_AIKIKAI_7 = dd.Day_Provide;
                            if (na.Name.Equals("DANAIKIKAI8")) data.DAN_AIKIKAI_8 = dd.Day_Provide;
                        }

                        datas.Add(data);

                    }
                }
                catch
                {

                }
                return datas;
            }
        }

        //Tìm kiếm theo điều kiện
        public List<Search_Model> SearchMember(String SKU, String HoTen, String NgayDangKy, String NgaySinh)
        {

            using (var db = new AccessDB_DAO())
            {
                if (NgayDangKy == "" && NgaySinh == "")
                {
                    List<Search_Model> listThanhVien = new List<Search_Model>();
                    foreach (var i in GetStudent())
                    {
                        if (i.FullName.ToUpper().Contains(HoTen.ToUpper()) && i.SKU.ToUpper().Contains(SKU.ToUpper()))
                        {
                            listThanhVien.Add(i);
                        }

                    }
                    return listThanhVien.ToList();
                }

                else if (NgayDangKy == "" && NgaySinh != "")
                {

                    List<Search_Model> listThanhVien = new List<Search_Model>();
                    foreach (var i in GetStudent())
                    {
                        if (i.FullName.ToUpper().Contains(HoTen.ToUpper()) && i.SKU.ToUpper().Contains(SKU.ToUpper()) && i.Day_of_Birth == DateTime.Parse(NgaySinh))
                        {
                            listThanhVien.Add(i);
                        }
                    }
                    return listThanhVien.ToList();
                }
                else if (NgaySinh == "" && NgayDangKy != "")
                {
                    List<Search_Model> listThanhVien = new List<Search_Model>();
                    foreach (var i in GetStudent())
                    {
                        if (i.FullName.ToUpper().Contains(HoTen.ToUpper()) && i.SKU.ToUpper().Contains(SKU.ToUpper()) && i.Day_Create == DateTime.Parse(NgayDangKy))
                        {
                            listThanhVien.Add(i);
                        }
                    }
                    return listThanhVien.ToList();
                }

                else
                {

                    List<Search_Model> listThanhVien = new List<Search_Model>();
                    foreach (var i in GetStudent())
                    {
                        if (i.FullName.ToUpper().Contains(HoTen.ToUpper()) && i.SKU.ToUpper().Contains(SKU.ToUpper()) && i.Day_Create == DateTime.Parse(NgayDangKy)
                                        && i.Day_of_Birth == DateTime.Parse(NgaySinh))
                        {
                            listThanhVien.Add(i);
                        }
                    }
                    return listThanhVien.ToList();
                }
            }

        }
        //Tìm kiếm nhanh
        public List<Search_Model> QuicSearchMember(String key)
        {
            using (var db = new AccessDB_DAO())
            {
                CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
                ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                Thread.CurrentThread.CurrentCulture = ci;
                List<Search_Model> listThanhVien = new List<Search_Model>();

                try
                {
                    DateTime x = DateTime.Parse(key);
                    foreach (var i in GetStudent())
                    {
                        if (i.Day_Create == x || i.Day_of_Birth == x)
                        {
                            listThanhVien.Add(i);
                        }
                    }
                    return listThanhVien.ToList();
                }
                catch
                {
                    foreach (var i in GetStudent())
                    {
                        if (i.FullName.ToUpper().Contains(key.ToUpper()) || i.SKU.ToUpper().Contains(key.ToUpper()))
                        {
                            listThanhVien.Add(i);
                        }
                    }
                    return listThanhVien.ToList();
                }
            }
        }

    }
}
