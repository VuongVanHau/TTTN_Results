using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Aikido.DAO.Model;
namespace Aikido.DAO
{
    public class LoadFee_DAO
    {
        public List<dgvFee_ViewModel> selectFee(int id)
        {
            List<dgvFee_ViewModel> data = new List<dgvFee_ViewModel>();

            using (var dataContext = new AccessDB_DAO())
            {

                var dts = dataContext.Students.Where(s => s.Delete_Flag == false);
                int r = DateTime.Now.Month;
                foreach (var st in dts)
                {
                    dgvFee_ViewModel dtg = new dgvFee_ViewModel();
                    dtg.RegisterNumber = st.RegisterNumber;
                    dtg.lblSKU = st.SKU;
                    dtg.lblnameHV = st.FullName;
                    dtg.lbltypeFee = "Hội Phí";

                    dgvFee_ViewModel dtg1 = new dgvFee_ViewModel();
                    dtg1.RegisterNumber = st.RegisterNumber;
                    dtg1.lblSKU = st.SKU;
                    dtg1.lblnameHV = st.FullName;
                    dtg1.lbltypeFee = "Phí Khác";

                    var clshp = id > 0 ? dataContext.Fees.Where(s => s.Delete_Flag == false && s.ID_Class == id && s.RegisterNumber == st.RegisterNumber && s.Fee_Type.Contains("Hội Phí") == true) : dataContext.Fees.Where(s => s.Delete_Flag == false && s.RegisterNumber == st.RegisterNumber && s.Fee_Type.Contains("Hội Phí") == true);
                    var clspk = id > 0 ? dataContext.Fees.Where(s => s.Delete_Flag == false && s.ID_Class == id && s.RegisterNumber == st.RegisterNumber && s.Fee_Type.Contains("Phí Khác") == true) : dataContext.Fees.Where(s => s.Delete_Flag == false && s.RegisterNumber == st.RegisterNumber && s.Fee_Type.Contains("Phí Khác") == true);

                    foreach (var dt in clshp)
                    {
                        var feeN = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year - 1 && s.Fee_Type.Contains("Hội Phí") == true);
                        var fee = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year && s.Fee_Type.Contains("Hội Phí") == true);
                        var feeP = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year + 1 && s.Fee_Type.Contains("Hội Phí") == true);

                        var dtc = dataContext.Classes.Where(s => s.ID_Class == dt.ID_Class).First();  //Minh - Modified 5/8/2018
                        dtg.ID_Learn = dt.ID_Learn;
                        dtg.ID_Class = dt.ID_Class;

                        dtg.lblnameClass = dtc.Class_Name;


                        switch (r)
                        {
                            case 1:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 10) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 11) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 12) dtg.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 2) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 3) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 7:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 4) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT5P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 8:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 5) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT4P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 9:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 6) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT3P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 10:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 7) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT2P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 11:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 8) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT1P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 12:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 9) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                        }
                        dtg.lblToTalS = dtg.lblmonthHT3A + dtg.lblmonthHT2A + dtg.lblmonthHT1A + dtg.lblmonthHT + dtg.lblmonthHT1P + dtg.lblmonthHT2P + dtg.lblmonthHT3P + dtg.lblmonthHT4P + dtg.lblmonthHT5P + dtg.lblmonthHT6P;
                    }
                    if (dtg.ID_Class > 0) data.Add(dtg);
                    foreach (var dt in clspk)
                    {
                        var feeN = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year - 1 && s.Fee_Type.Contains("Phí Khác") == true);
                        var fee = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year && s.Fee_Type.Contains("Phí Khác") == true);
                        var feeP = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year + 1 && s.Fee_Type.Contains("Phí Khác") == true);
                        
                        var dtc = dataContext.Classes.Where(s => s.ID_Class == dt.ID_Class ).First(); //Minh - Modified 5/8/2018

                        dtg1.ID_Learn = dt.ID_Learn;
                        dtg1.ID_Class = dtc.ID_Class;
                        dtg1.lbltypeFee = "Phí Khác";
                        dtg1.lblnameClass = dtc.Class_Name;
                        switch (r)
                        {
                            case 1:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 10) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 11) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT1A = i.Fee_Value;
                                    }

                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 12) dtg1.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 2) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 3) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 7:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 4) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT5P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 8:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 5) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT4P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 9:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 6) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT3P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 10:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 7) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT2P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 11:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 8) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT1P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 12:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 9) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                        }
                        dtg1.lblToTalS = dtg1.lblmonthHT3A + dtg1.lblmonthHT2A + dtg1.lblmonthHT1A + dtg1.lblmonthHT + dtg1.lblmonthHT1P + dtg1.lblmonthHT2P + dtg1.lblmonthHT3P + dtg1.lblmonthHT4P + dtg1.lblmonthHT5P + dtg1.lblmonthHT6P;
                    }
                    if (dtg1.ID_Class > 0) data.Add(dtg1);
                }
                return data;
            }
        }

        public List<dgvFee_ViewModel> selectFeeM(int id)
        {
            List<dgvFee_ViewModel> data = new List<dgvFee_ViewModel>();

            using (var dataContext = new AccessDB_DAO())
            {

                var dts = dataContext.Students.Where(s => s.Delete_Flag == false);
                int r = DateTime.Now.Month;
                foreach (var st in dts)
                {
                    dgvFee_ViewModel dtg = new dgvFee_ViewModel();
                    dtg.RegisterNumber = st.RegisterNumber;
                    dtg.lblSKU = st.SKU;
                    dtg.lblnameHV = st.FullName;
                    dtg.lbltypeFee = "Hội Phí";

                    dgvFee_ViewModel dtg1 = new dgvFee_ViewModel();
                    dtg1.RegisterNumber = st.RegisterNumber;
                    dtg1.lblSKU = st.SKU;
                    dtg1.lblnameHV = st.FullName;
                    dtg1.lbltypeFee = "Phí Khác";

                    var clshp = id > 0 ? dataContext.Fees.Where(s => s.Delete_Flag == false && s.ID_Class == id && s.RegisterNumber == st.RegisterNumber && s.Fee_Type.Contains("Hội Phí") == true) : dataContext.Fees.Where(s => s.Delete_Flag == false && s.RegisterNumber == st.RegisterNumber && s.Fee_Type.Contains("Hội Phí") == true);
                    var clspk = id > 0 ? dataContext.Fees.Where(s => s.Delete_Flag == false && s.ID_Class == id && s.RegisterNumber == st.RegisterNumber && s.Fee_Type.Contains("Phí Khác") == true) : dataContext.Fees.Where(s => s.Delete_Flag == false && s.RegisterNumber == st.RegisterNumber && s.Fee_Type.Contains("Phí Khác") == true);

                    foreach (var dt in clshp)
                    {
                        var feeN = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year - 1 && s.Fee_Type.Contains("Hội Phí") == true);
                        var fee = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year && s.Fee_Type.Contains("Hội Phí") == true);
                        var feeP = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year + 1 && s.Fee_Type.Contains("Hội Phí") == true);

                        var dtc = dataContext.Classes.Where(s => s.ID_Class == dt.ID_Class ).First();  //Minh - Modified 5/8/2018
                        dtg.ID_Learn = dt.ID_Learn;
                        dtg.ID_Class = dt.ID_Class;

                        dtg.lblnameClass = dtc.Class_Name;


                        switch (r)
                        {
                            case 1:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 10) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 11) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 12) dtg.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 2) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 3) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 7:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 4) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT5P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 8:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 5) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT4P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 9:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 6) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 7) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT3P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 10:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 7) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 8) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT2P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 11:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 8) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 9) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT1P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 12:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 9) dtg.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 10) dtg.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 11) dtg.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 12) dtg.lblmonthHT = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 2) dtg.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 3) dtg.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 4) dtg.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 5) dtg.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 6) dtg.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                        }
                        dtg.lblToTalS = dtg.lblmonthHT3A + dtg.lblmonthHT2A + dtg.lblmonthHT1A + dtg.lblmonthHT + dtg.lblmonthHT1P + dtg.lblmonthHT2P + dtg.lblmonthHT3P + dtg.lblmonthHT4P + dtg.lblmonthHT5P + dtg.lblmonthHT6P;
                    }
                    if (dtg.ID_Class > 0) data.Add(dtg);
                    foreach (var dt in clspk)
                    {
                        var feeN = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year - 1 && s.Fee_Type.Contains("Phí Khác") == true);
                        var fee = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year && s.Fee_Type.Contains("Phí Khác") == true);
                        var feeP = dataContext.Fees.Where(s => s.RegisterNumber == st.RegisterNumber && s.Delete_Flag == false && s.Year == DateTime.Now.Year + 1 && s.Fee_Type.Contains("Phí Khác") == true);

                        var dtc = dataContext.Classes.Where(s => s.ID_Class == dt.ID_Class ).First();  //Minh - Modified 5/8/2018

                        dtg1.ID_Learn = dt.ID_Learn;
                        dtg1.ID_Class = dt.ID_Class;
                        dtg1.lbltypeFee = "Phí Khác";
                        dtg1.lblnameClass = dtc.Class_Name;
                        switch (r)
                        {
                            case 1:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 10) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 2:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 11) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT1A = i.Fee_Value;
                                    }

                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 3:
                                {
                                    foreach (var i in feeN)
                                    {
                                        if (i.Month == 12) dtg1.lblmonthHT1A = i.Fee_Value;
                                    }
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 4:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 5:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 2) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 6:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 3) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 7:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 4) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT5P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 8:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 5) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT4P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 9:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 6) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 7) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT3P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 10:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 7) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 8) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT2P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 11:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 8) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 9) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT1P = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                            case 12:
                                {
                                    foreach (var i in fee)
                                    {
                                        if (i.Month == 9) dtg1.lblmonthHT3A = i.Fee_Value;
                                        if (i.Month == 10) dtg1.lblmonthHT2A = i.Fee_Value;
                                        if (i.Month == 11) dtg1.lblmonthHT1A = i.Fee_Value;
                                        if (i.Month == 12) dtg1.lblmonthHT = i.Fee_Value;
                                    }
                                    foreach (var i in feeP)
                                    {
                                        if (i.Month == 1) dtg1.lblmonthHT1P = i.Fee_Value;
                                        if (i.Month == 2) dtg1.lblmonthHT2P = i.Fee_Value;
                                        if (i.Month == 3) dtg1.lblmonthHT3P = i.Fee_Value;
                                        if (i.Month == 4) dtg1.lblmonthHT4P = i.Fee_Value;
                                        if (i.Month == 5) dtg1.lblmonthHT5P = i.Fee_Value;
                                        if (i.Month == 6) dtg1.lblmonthHT6P = i.Fee_Value;
                                    }
                                    break;
                                }
                        }
                        dtg1.lblToTalS = dtg1.lblmonthHT3A + dtg1.lblmonthHT2A + dtg1.lblmonthHT1A + dtg1.lblmonthHT + dtg1.lblmonthHT1P + dtg1.lblmonthHT2P + dtg1.lblmonthHT3P + dtg1.lblmonthHT4P + dtg1.lblmonthHT5P + dtg1.lblmonthHT6P;
                    }
                    if (dtg1.ID_Class > 0) data.Add(dtg1);
                }
                return data;
            }
        }

        public List<dgvFee_ViewModel> selectFee1(int id)
        {
            List<dgvFee_ViewModel> data = new List<dgvFee_ViewModel>();

            using (var dataContext = new AccessDB_DAO())
            {
                var dts = dataContext.Students;
                foreach (var dt in dts)
                {
                    Fee_Model cls = id > 0 ? dataContext.Fees.FirstOrDefault(s => s.Delete_Flag == false && s.ID_Class == id && s.RegisterNumber == dt.RegisterNumber) : dataContext.Fees.FirstOrDefault(s => s.Delete_Flag == false && s.RegisterNumber == dt.RegisterNumber);
                    if (cls != null)
                    {
                        var dtc = dataContext.Classes.Where(s => s.ID_Class == cls.ID_Class).First();
                        dgvFee_ViewModel dtg = new dgvFee_ViewModel();
                        dtg.RegisterNumber = dt.RegisterNumber;
                        dtg.ID_Learn = cls.ID_Learn;
                        dtg.lblSKU = dt.SKU;
                        dtg.lblnameHV = dt.FullName;
                        dtg.lblnameClass = dtc.Class_Name;
                        data.Add(dtg);
                    }
                }
            }
            return (data);
        }

        //public List<dgvFee_ViewModel> selectAllFee1()
        //{
        //    List<dgvFee_ViewModel> data = new List<dgvFee_ViewModel>();

        //    using (var dataContext = new AccessDB_DAO())
        //    {
        //        var cls = dataContext.Learns.Where(s => s.Delete_Flag == false);
        //        int r = DateTime.Now.Month;
        //        foreach (var dt in cls)
        //        {
        //            var dts = dataContext.Students.Where(s => s.RegisterNumber == dt.RegisterNumber).First();
        //            var dtc = dataContext.Classes.Where(s => s.ID_Class == dt.ID_Class).First();
        //            dgvFee_ViewModel dtg = new dgvFee_ViewModel();
        //            dtg.RegisterNumber = dt.RegisterNumber;
        //            dtg.ID_Learn = dt.ID_Learn;
        //            dtg.lblSKU = dts.SKU;
        //            dtg.lblnameHV = dts.FullName;
        //            dtg.lblnameClass = dtc.Class_Name;
        //            data.Add(dtg);
        //        }
        //    }
        //    return (data);
        //}

        //public List<dgvFee_ViewModel> selectAll()
        //{
        //    List<dgvFee_ViewModel> data = new List<dgvFee_ViewModel>();

        //    using (var dataContext = new AccessDB_DAO())
        //    {
        //        var cls = dataContext.Learns.Where(s => s.Delete_Flag == false);
        //        int r = DateTime.Now.Month;
        //        foreach (var dt in cls)
        //        {
        //            var dts = dataContext.Students.Where(s => s.RegisterNumber == dt.RegisterNumber).First();
        //            var dtc = dataContext.Classes.Where(s => s.ID_Class == dt.ID_Class).First();
        //            dgvFee_ViewModel dtg = new dgvFee_ViewModel();
        //            dtg.RegisterNumber = dt.RegisterNumber;
        //            dtg.ID_Learn = dt.ID_Learn;
        //            dtg.lblSKU = dts.SKU;
        //            dtg.lblnameHV = dts.FullName;
        //            dtg.lblnameClass = dtc.Class_Name;
        //            dtg.lbltypeFee = "Hội Phí";

        //            switch (r)
        //            {
        //                case 1:
        //                    {
        //                        var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r - 1 && s.Delete_Flag == false).Last();
        //                        dtg.lblmonthHT3A = fee.Fee_October;
        //                        dtg.lblmonthHT2A = fee.Fee_November;
        //                        dtg.lblmonthHT1A = fee.Fee_December;
        //                        dtg.lblmonthHT = dt.Fee_January;
        //                        dtg.lblmonthHT1P = dt.Fee_February;
        //                        dtg.lblmonthHT2P = dt.Fee_March;
        //                        dtg.lblmonthHT3P = dt.Fee_April;
        //                        dtg.lblmonthHT4P = dt.Fee_May;
        //                        dtg.lblmonthHT5P = dt.Fee_June;
        //                        dtg.lblmonthHT6P = dt.Fee_July;
        //                        break;
        //                    }
        //                case 2:
        //                    {
        //                        var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r - 1 && s.Delete_Flag == false).Last();
        //                        dtg.lblmonthHT3A = fee.Fee_November;
        //                        dtg.lblmonthHT2A = fee.Fee_December;
        //                        dtg.lblmonthHT1A = dt.Fee_January;
        //                        dtg.lblmonthHT = dt.Fee_February;
        //                        dtg.lblmonthHT1P = dt.Fee_March;
        //                        dtg.lblmonthHT2P = dt.Fee_April;
        //                        dtg.lblmonthHT3P = dt.Fee_May;
        //                        dtg.lblmonthHT4P = dt.Fee_June;
        //                        dtg.lblmonthHT5P = dt.Fee_July;
        //                        dtg.lblmonthHT6P = dt.Fee_August;
        //                        break;
        //                    }
        //                case 3:
        //                    {
        //                        var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r - 1 && s.Delete_Flag == false).Last();
        //                        dtg.lblmonthHT3A = fee.Fee_December;
        //                        dtg.lblmonthHT2A = dt.Fee_January;
        //                        dtg.lblmonthHT1A = dt.Fee_February;
        //                        dtg.lblmonthHT = dt.Fee_March;
        //                        dtg.lblmonthHT1P = dt.Fee_April;
        //                        dtg.lblmonthHT2P = dt.Fee_May;
        //                        dtg.lblmonthHT3P = dt.Fee_June;
        //                        dtg.lblmonthHT4P = dt.Fee_July;
        //                        dtg.lblmonthHT5P = dt.Fee_August;
        //                        dtg.lblmonthHT6P = dt.Fee_September;
        //                        break;
        //                    }
        //                case 4:
        //                    {
        //                        dtg.lblmonthHT3A = dt.Fee_January;
        //                        dtg.lblmonthHT2A = dt.Fee_February;
        //                        dtg.lblmonthHT1A = dt.Fee_March;
        //                        dtg.lblmonthHT = dt.Fee_April;
        //                        dtg.lblmonthHT1P = dt.Fee_May;
        //                        dtg.lblmonthHT2P = dt.Fee_June;
        //                        dtg.lblmonthHT3P = dt.Fee_July;
        //                        dtg.lblmonthHT4P = dt.Fee_August;
        //                        dtg.lblmonthHT5P = dt.Fee_September;
        //                        dtg.lblmonthHT6P = dt.Fee_October;
        //                        break;
        //                    }
        //                case 5:
        //                    {
        //                        dtg.lblmonthHT3A = dt.Fee_February;
        //                        dtg.lblmonthHT2A = dt.Fee_March;
        //                        dtg.lblmonthHT1A = dt.Fee_April;
        //                        dtg.lblmonthHT = dt.Fee_May;
        //                        dtg.lblmonthHT1P = dt.Fee_June;
        //                        dtg.lblmonthHT2P = dt.Fee_July;
        //                        dtg.lblmonthHT3P = dt.Fee_August;
        //                        dtg.lblmonthHT4P = dt.Fee_September;
        //                        dtg.lblmonthHT5P = dt.Fee_October;
        //                        dtg.lblmonthHT6P = dt.Fee_November;
        //                        break;
        //                    }
        //                case 6:
        //                    {
        //                        dtg.lblmonthHT3A = dt.Fee_March;
        //                        dtg.lblmonthHT2A = dt.Fee_April;
        //                        dtg.lblmonthHT1A = dt.Fee_May;
        //                        dtg.lblmonthHT = dt.Fee_June;
        //                        dtg.lblmonthHT1P = dt.Fee_July;
        //                        dtg.lblmonthHT2P = dt.Fee_August;
        //                        dtg.lblmonthHT3P = dt.Fee_September;
        //                        dtg.lblmonthHT4P = dt.Fee_October;
        //                        dtg.lblmonthHT5P = dt.Fee_November;
        //                        dtg.lblmonthHT6P = dt.Fee_December;
        //                        break;
        //                    }
        //                case 7:
        //                    {
        //                        dtg.lblmonthHT3A = dt.Fee_April;
        //                        dtg.lblmonthHT2A = dt.Fee_May;
        //                        dtg.lblmonthHT1A = dt.Fee_June;
        //                        dtg.lblmonthHT = dt.Fee_July;
        //                        dtg.lblmonthHT1P = dt.Fee_August;
        //                        dtg.lblmonthHT2P = dt.Fee_September;
        //                        dtg.lblmonthHT3P = dt.Fee_October;
        //                        dtg.lblmonthHT4P = dt.Fee_November;
        //                        dtg.lblmonthHT5P = dt.Fee_December;
        //                        dtg.lblmonthHT6P = 0;
        //                        //try
        //                        //{
        //                        //    var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();
        //                        //    dtg.lblmonthHT6P = fee.Fee_January;
        //                        //}
        //                        //catch
        //                        //{
        //                        //    dtg.lblmonthHT6P = 0;
        //                        //}
        //                        break;
        //                    }
        //                case 8:
        //                    {
        //                        dtg.lblmonthHT3A = dt.Fee_May;
        //                        dtg.lblmonthHT2A = dt.Fee_June;
        //                        dtg.lblmonthHT1A = dt.Fee_July;
        //                        dtg.lblmonthHT = dt.Fee_August;
        //                        dtg.lblmonthHT1P = dt.Fee_September;
        //                        dtg.lblmonthHT2P = dt.Fee_October;
        //                        dtg.lblmonthHT3P = dt.Fee_November;
        //                        dtg.lblmonthHT4P = dt.Fee_December;
        //                        dtg.lblmonthHT5P = 0;
        //                        dtg.lblmonthHT6P = 0;
        //                        //try
        //                        //{
        //                        //    var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                        //    dtg.lblmonthHT5P = fee.Fee_January;
        //                        //    dtg.lblmonthHT6P = fee.Fee_February;
        //                        //}
        //                        //catch
        //                        //{
        //                        //    dtg.lblmonthHT5P = 0;
        //                        //    dtg.lblmonthHT6P = 0;
        //                        //}
        //                        break;
        //                    }
        //                case 9:
        //                    {
        //                        dtg.lblmonthHT3A = dt.Fee_June;
        //                        dtg.lblmonthHT2A = dt.Fee_July;
        //                        dtg.lblmonthHT1A = dt.Fee_August;
        //                        dtg.lblmonthHT = dt.Fee_September;
        //                        dtg.lblmonthHT1P = dt.Fee_October;
        //                        dtg.lblmonthHT2P = dt.Fee_November;
        //                        dtg.lblmonthHT3P = dt.Fee_December;
        //                        dtg.lblmonthHT4P = 0;
        //                        dtg.lblmonthHT5P = 0;
        //                        dtg.lblmonthHT6P = 0;
        //                        //try
        //                        //{
        //                        //    var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                        //    dtg.lblmonthHT4P = fee.Fee_January;
        //                        //    dtg.lblmonthHT5P = fee.Fee_February;
        //                        //    dtg.lblmonthHT6P = fee.Fee_March;
        //                        //}
        //                        //catch
        //                        //{
        //                        //    dtg.lblmonthHT4P = 0;
        //                        //    dtg.lblmonthHT5P = 0;
        //                        //    dtg.lblmonthHT6P = 0;
        //                        //}
        //                        break;
        //                    }
        //                case 10:
        //                    {
        //                        dtg.lblmonthHT3A = dt.Fee_July;
        //                        dtg.lblmonthHT2A = dt.Fee_August;
        //                        dtg.lblmonthHT1A = dt.Fee_September;
        //                        dtg.lblmonthHT = dt.Fee_October;
        //                        dtg.lblmonthHT1P = dt.Fee_November;
        //                        dtg.lblmonthHT2P = dt.Fee_December;
        //                        dtg.lblmonthHT3P = 0;
        //                        dtg.lblmonthHT4P = 0;
        //                        dtg.lblmonthHT5P = 0;
        //                        dtg.lblmonthHT6P = 0;
        //                        //try
        //                        //{
        //                        //    var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                        //    dtg.lblmonthHT3P = fee.Fee_January;
        //                        //    dtg.lblmonthHT4P = fee.Fee_February;
        //                        //    dtg.lblmonthHT5P = fee.Fee_March;
        //                        //    dtg.lblmonthHT6P = fee.Fee_April;
        //                        //}
        //                        //catch
        //                        //{
        //                        //    dtg.lblmonthHT3P = 0;
        //                        //    dtg.lblmonthHT4P = 0;
        //                        //    dtg.lblmonthHT5P = 0;
        //                        //    dtg.lblmonthHT6P = 0;
        //                        //}
        //                        break;
        //                    }
        //                case 11:
        //                    {
        //                        dtg.lblmonthHT3A = dt.Fee_August;
        //                        dtg.lblmonthHT2A = dt.Fee_September;
        //                        dtg.lblmonthHT1A = dt.Fee_October;
        //                        dtg.lblmonthHT = dt.Fee_November;
        //                        dtg.lblmonthHT1P = dt.Fee_December;
        //                        dtg.lblmonthHT2P = 0;
        //                        dtg.lblmonthHT3P = 0;
        //                        dtg.lblmonthHT4P = 0;
        //                        dtg.lblmonthHT5P = 0;
        //                        dtg.lblmonthHT6P = 0;
        //                        //try
        //                        //{
        //                        //    var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                        //    dtg.lblmonthHT2P = fee.Fee_January;
        //                        //    dtg.lblmonthHT3P = fee.Fee_February;
        //                        //    dtg.lblmonthHT4P = fee.Fee_March;
        //                        //    dtg.lblmonthHT5P = fee.Fee_April;
        //                        //    dtg.lblmonthHT6P = fee.Fee_May;
        //                        //}
        //                        //catch
        //                        //{
        //                        //    dtg.lblmonthHT2P = 0;
        //                        //    dtg.lblmonthHT3P = 0;
        //                        //    dtg.lblmonthHT4P = 0;
        //                        //    dtg.lblmonthHT5P = 0;
        //                        //    dtg.lblmonthHT6P = 0;
        //                        //}
        //                        break;
        //                    }
        //                case 12:
        //                    {
        //                        dtg.lblmonthHT3A = dt.Fee_September;
        //                        dtg.lblmonthHT2A = dt.Fee_October;
        //                        dtg.lblmonthHT1A = dt.Fee_November;
        //                        dtg.lblmonthHT = dt.Fee_December;
        //                        dtg.lblmonthHT1P = 0;
        //                        dtg.lblmonthHT2P = 0;
        //                        dtg.lblmonthHT3P = 0;
        //                        dtg.lblmonthHT4P = 0;
        //                        dtg.lblmonthHT5P = 0;
        //                        dtg.lblmonthHT6P = 0;
        //                        //try
        //                        //{
        //                        //    var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                        //    dtg.lblmonthHT1P = fee.Fee_January;
        //                        //    dtg.lblmonthHT2P = fee.Fee_February;
        //                        //    dtg.lblmonthHT3P = fee.Fee_March;
        //                        //    dtg.lblmonthHT4P = fee.Fee_April;
        //                        //    dtg.lblmonthHT5P = fee.Fee_May;
        //                        //    dtg.lblmonthHT6P = fee.Fee_June;
        //                        //}
        //                        //catch
        //                        //{
        //                        //    dtg.lblmonthHT1P = 0;
        //                        //    dtg.lblmonthHT2P = 0;
        //                        //    dtg.lblmonthHT3P = 0;
        //                        //    dtg.lblmonthHT4P = 0;
        //                        //    dtg.lblmonthHT5P = 0;
        //                        //    dtg.lblmonthHT6P = 0;
        //                        //}
        //                        break;
        //                    }
        //            }
        //            dtg.lblToTalS = dtg.lblmonthHT3A + dtg.lblmonthHT2A + dtg.lblmonthHT1A + dtg.lblmonthHT + dtg.lblmonthHT1P + dtg.lblmonthHT2P + dtg.lblmonthHT3P + dtg.lblmonthHT4P + dtg.lblmonthHT5P + dtg.lblmonthHT6P;
        //            data.Add(dtg);

        //            dgvFee_ViewModel dtg1 = new dgvFee_ViewModel();
        //            dtg1.RegisterNumber = dt.RegisterNumber;
        //            dtg1.ID_Learn = dt.ID_Learn;
        //            dtg1.lblSKU = dts.SKU;
        //            dtg1.lblnameHV = dts.FullName;
        //            dtg1.lblnameClass = dtc.Class_Name;
        //            dtg1.lbltypeFee = "Phí Khác";

        //            switch (r)
        //            {
        //                case 1:
        //                    {
        //                        dtg1.lblmonthHT = dt.FeeD_January;
        //                        dtg1.lblmonthHT1P = dt.FeeD_February;
        //                        dtg1.lblmonthHT2P = dt.FeeD_March;
        //                        dtg1.lblmonthHT3P = dt.FeeD_April;
        //                        dtg1.lblmonthHT4P = dt.FeeD_May;
        //                        dtg1.lblmonthHT5P = dt.FeeD_June;
        //                        dtg1.lblmonthHT6P = dt.FeeD_July;
        //                        try
        //                        {
        //                            var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r - 1 && s.Delete_Flag == false).Last();
        //                            dtg1.lblmonthHT3A = fee.FeeD_October;
        //                            dtg1.lblmonthHT2A = fee.FeeD_November;
        //                            dtg1.lblmonthHT1A = fee.FeeD_December;
        //                        }
        //                        catch
        //                        {
        //                            dtg1.lblmonthHT3A = 0;
        //                            dtg1.lblmonthHT2A = 0;
        //                            dtg1.lblmonthHT1A = 0;
        //                        }

        //                        break;
        //                    }
        //                case 2:
        //                    {
        //                        dtg1.lblmonthHT1A = dt.FeeD_January;
        //                        dtg1.lblmonthHT = dt.FeeD_February;
        //                        dtg1.lblmonthHT1P = dt.FeeD_March;
        //                        dtg1.lblmonthHT2P = dt.FeeD_April;
        //                        dtg1.lblmonthHT3P = dt.FeeD_May;
        //                        dtg1.lblmonthHT4P = dt.FeeD_June;
        //                        dtg1.lblmonthHT5P = dt.FeeD_July;
        //                        dtg1.lblmonthHT6P = dt.FeeD_August;
        //                        try
        //                        {
        //                            var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r - 1 && s.Delete_Flag == false).Last();
        //                            dtg1.lblmonthHT3A = fee.FeeD_November;
        //                            dtg1.lblmonthHT2A = fee.FeeD_December;
        //                        }
        //                        catch
        //                        {
        //                            dtg1.lblmonthHT3A = 0;
        //                            dtg1.lblmonthHT2A = 0;
        //                        }
        //                        break;
        //                    }
        //                case 3:
        //                    {
        //                        dtg1.lblmonthHT2A = dt.FeeD_January;
        //                        dtg1.lblmonthHT1A = dt.FeeD_February;
        //                        dtg1.lblmonthHT = dt.FeeD_March;
        //                        dtg1.lblmonthHT1P = dt.FeeD_April;
        //                        dtg1.lblmonthHT2P = dt.FeeD_May;
        //                        dtg1.lblmonthHT3P = dt.FeeD_June;
        //                        dtg1.lblmonthHT4P = dt.FeeD_July;
        //                        dtg1.lblmonthHT5P = dt.FeeD_August;
        //                        dtg1.lblmonthHT6P = dt.FeeD_September;
        //                        try
        //                        {
        //                            var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r - 1 && s.Delete_Flag == false).Last();
        //                            dtg1.lblmonthHT3A = fee.FeeD_December;
        //                        }
        //                        catch
        //                        {
        //                            dtg1.lblmonthHT3A = 0;
        //                        }

        //                        break;
        //                    }
        //                case 4:
        //                    {
        //                        dtg1.lblmonthHT3A = dt.FeeD_January;
        //                        dtg1.lblmonthHT2A = dt.FeeD_February;
        //                        dtg1.lblmonthHT1A = dt.FeeD_March;
        //                        dtg1.lblmonthHT = dt.FeeD_April;
        //                        dtg1.lblmonthHT1P = dt.FeeD_May;
        //                        dtg1.lblmonthHT2P = dt.FeeD_June;
        //                        dtg1.lblmonthHT3P = dt.FeeD_July;
        //                        dtg1.lblmonthHT4P = dt.FeeD_August;
        //                        dtg1.lblmonthHT5P = dt.FeeD_September;
        //                        dtg1.lblmonthHT6P = dt.FeeD_October;
        //                        break;
        //                    }
        //                case 5:
        //                    {
        //                        dtg1.lblmonthHT3A = dt.FeeD_February;
        //                        dtg1.lblmonthHT2A = dt.FeeD_March;
        //                        dtg1.lblmonthHT1A = dt.FeeD_April;
        //                        dtg1.lblmonthHT = dt.FeeD_May;
        //                        dtg1.lblmonthHT1P = dt.FeeD_June;
        //                        dtg1.lblmonthHT2P = dt.FeeD_July;
        //                        dtg1.lblmonthHT3P = dt.FeeD_August;
        //                        dtg1.lblmonthHT4P = dt.FeeD_September;
        //                        dtg1.lblmonthHT5P = dt.FeeD_October;
        //                        dtg1.lblmonthHT6P = dt.FeeD_November;
        //                        break;
        //                    }
        //                case 6:
        //                    {
        //                        dtg1.lblmonthHT3A = dt.FeeD_March;
        //                        dtg1.lblmonthHT2A = dt.FeeD_April;
        //                        dtg1.lblmonthHT1A = dt.FeeD_May;
        //                        dtg1.lblmonthHT = dt.FeeD_June;
        //                        dtg1.lblmonthHT1P = dt.FeeD_July;
        //                        dtg1.lblmonthHT2P = dt.FeeD_August;
        //                        dtg1.lblmonthHT3P = dt.FeeD_September;
        //                        dtg1.lblmonthHT4P = dt.FeeD_October;
        //                        dtg1.lblmonthHT5P = dt.FeeD_November;
        //                        dtg1.lblmonthHT6P = dt.FeeD_December;
        //                        break;
        //                    }
        //                case 7:
        //                    {
        //                        dtg1.lblmonthHT3A = dt.FeeD_April;
        //                        dtg1.lblmonthHT2A = dt.FeeD_May;
        //                        dtg1.lblmonthHT1A = dt.FeeD_June;
        //                        dtg1.lblmonthHT = dt.FeeD_July;
        //                        dtg1.lblmonthHT1P = dt.FeeD_August;
        //                        dtg1.lblmonthHT2P = dt.FeeD_September;
        //                        dtg1.lblmonthHT3P = dt.FeeD_October;
        //                        dtg1.lblmonthHT4P = dt.FeeD_November;
        //                        dtg1.lblmonthHT5P = dt.FeeD_December;
        //                        try
        //                        {
        //                            var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();
        //                            dtg1.lblmonthHT6P = fee.FeeD_January;
        //                        }
        //                        catch
        //                        {
        //                            dtg1.lblmonthHT6P = 0;
        //                        }
        //                        break;
        //                    }
        //                case 8:
        //                    {
        //                        dtg1.lblmonthHT3A = dt.FeeD_May;
        //                        dtg1.lblmonthHT2A = dt.FeeD_June;
        //                        dtg1.lblmonthHT1A = dt.FeeD_July;
        //                        dtg1.lblmonthHT = dt.FeeD_August;
        //                        dtg1.lblmonthHT1P = dt.FeeD_September;
        //                        dtg1.lblmonthHT2P = dt.FeeD_October;
        //                        dtg1.lblmonthHT3P = dt.FeeD_November;
        //                        dtg1.lblmonthHT4P = dt.FeeD_December;
        //                        try
        //                        {
        //                            var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                            dtg1.lblmonthHT5P = fee.FeeD_January;
        //                            dtg1.lblmonthHT6P = fee.FeeD_February;
        //                        }
        //                        catch
        //                        {
        //                            dtg1.lblmonthHT5P = 0;
        //                            dtg1.lblmonthHT6P = 0;
        //                        }
        //                        break;
        //                    }
        //                case 9:
        //                    {
        //                        dtg1.lblmonthHT3A = dt.FeeD_June;
        //                        dtg1.lblmonthHT2A = dt.FeeD_July;
        //                        dtg1.lblmonthHT1A = dt.FeeD_August;
        //                        dtg1.lblmonthHT = dt.FeeD_September;
        //                        dtg1.lblmonthHT1P = dt.FeeD_October;
        //                        dtg1.lblmonthHT2P = dt.FeeD_November;
        //                        dtg1.lblmonthHT3P = dt.FeeD_December;
        //                        try
        //                        {
        //                            var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                            dtg1.lblmonthHT4P = fee.FeeD_January;
        //                            dtg1.lblmonthHT5P = fee.FeeD_February;
        //                            dtg1.lblmonthHT6P = fee.FeeD_March;
        //                        }
        //                        catch
        //                        {
        //                            dtg1.lblmonthHT4P = 0;
        //                            dtg1.lblmonthHT5P = 0;
        //                            dtg1.lblmonthHT6P = 0;
        //                        }
        //                        break;
        //                    }
        //                case 10:
        //                    {
        //                        dtg1.lblmonthHT3A = dt.FeeD_July;
        //                        dtg1.lblmonthHT2A = dt.FeeD_August;
        //                        dtg1.lblmonthHT1A = dt.FeeD_September;
        //                        dtg1.lblmonthHT = dt.FeeD_October;
        //                        dtg1.lblmonthHT1P = dt.FeeD_November;
        //                        dtg1.lblmonthHT2P = dt.FeeD_December;
        //                        try
        //                        {
        //                            var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                            dtg1.lblmonthHT3P = fee.FeeD_January;
        //                            dtg1.lblmonthHT4P = fee.FeeD_February;
        //                            dtg1.lblmonthHT5P = fee.FeeD_March;
        //                            dtg1.lblmonthHT6P = fee.FeeD_April;
        //                        }
        //                        catch
        //                        {
        //                            dtg1.lblmonthHT3P = 0;
        //                            dtg1.lblmonthHT4P = 0;
        //                            dtg1.lblmonthHT5P = 0;
        //                            dtg1.lblmonthHT6P = 0;
        //                        }
        //                        break;
        //                    }
        //                case 11:
        //                    {
        //                        dtg1.lblmonthHT3A = dt.FeeD_August;
        //                        dtg1.lblmonthHT2A = dt.FeeD_September;
        //                        dtg1.lblmonthHT1A = dt.FeeD_October;
        //                        dtg1.lblmonthHT = dt.FeeD_November;
        //                        dtg1.lblmonthHT1P = dt.FeeD_December;
        //                        try
        //                        {
        //                            var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                            dtg1.lblmonthHT2P = fee.FeeD_January;
        //                            dtg1.lblmonthHT3P = fee.FeeD_February;
        //                            dtg1.lblmonthHT4P = fee.FeeD_March;
        //                            dtg1.lblmonthHT5P = fee.FeeD_April;
        //                            dtg1.lblmonthHT6P = fee.FeeD_May;
        //                        }
        //                        catch
        //                        {
        //                            dtg1.lblmonthHT2P = 0;
        //                            dtg1.lblmonthHT3P = 0;
        //                            dtg1.lblmonthHT4P = 0;
        //                            dtg1.lblmonthHT5P = 0;
        //                            dtg1.lblmonthHT6P = 0;
        //                        }
        //                        break;
        //                    }
        //                case 12:
        //                    {
        //                        dtg1.lblmonthHT3A = dt.FeeD_September;
        //                        dtg1.lblmonthHT2A = dt.FeeD_October;
        //                        dtg1.lblmonthHT1A = dt.FeeD_November;
        //                        dtg1.lblmonthHT = dt.FeeD_December;
        //                        try
        //                        {
        //                            var fee = dataContext.Learns.Where(s => s.RegisterNumber == dt.RegisterNumber && s.Day_Create.Year == r + 1 && s.Delete_Flag == false).Last();

        //                            dtg1.lblmonthHT1P = fee.FeeD_January;
        //                            dtg1.lblmonthHT2P = fee.FeeD_February;
        //                            dtg1.lblmonthHT3P = fee.FeeD_March;
        //                            dtg1.lblmonthHT4P = fee.FeeD_April;
        //                            dtg1.lblmonthHT5P = fee.FeeD_May;
        //                            dtg1.lblmonthHT6P = fee.FeeD_June;
        //                        }
        //                        catch
        //                        {
        //                            dtg1.lblmonthHT1P = 0;
        //                            dtg1.lblmonthHT2P = 0;
        //                            dtg1.lblmonthHT3P = 0;
        //                            dtg1.lblmonthHT4P = 0;
        //                            dtg1.lblmonthHT5P = 0;
        //                            dtg1.lblmonthHT6P = 0;
        //                        }
        //                        break;
        //                    }
        //            }
        //            dtg1.lblToTalS = dtg1.lblmonthHT3A + dtg1.lblmonthHT2A + dtg1.lblmonthHT1A + dtg1.lblmonthHT + dtg1.lblmonthHT1P + dtg1.lblmonthHT2P + dtg1.lblmonthHT3P + dtg1.lblmonthHT4P + dtg1.lblmonthHT5P + dtg1.lblmonthHT6P;
        //            data.Add(dtg1);
        //        }
        //    }
        //    return data;
        //}

        public List<dgvTotalC_ViewModel> Total(DataGrid dgvFee)
        {
            List<dgvTotalC_ViewModel> total = new List<dgvTotalC_ViewModel>();
            dgvTotalC_ViewModel dgvTotal = new dgvTotalC_ViewModel();
            dgvTotal.lblToal = "Total";
            dgvTotal.lblmonthHT3A = 0;
            dgvTotal.lblmonthHT2A = 0;
            dgvTotal.lblmonthHT1A = 0;
            dgvTotal.lblmonthHT = 0;
            dgvTotal.lblmonthHT1P = 0;
            dgvTotal.lblmonthHT2P = 0;
            dgvTotal.lblmonthHT3P = 0;
            dgvTotal.lblmonthHT4P = 0;
            dgvTotal.lblmonthHT5P = 0;
            dgvTotal.lblmonthHT6P = 0;
            dgvTotal.lblToTalS = dgvTotal.lblmonthHT3A + dgvTotal.lblmonthHT2A + dgvTotal.lblmonthHT1A + dgvTotal.lblmonthHT + dgvTotal.lblmonthHT1P + dgvTotal.lblmonthHT2P + dgvTotal.lblmonthHT3P + dgvTotal.lblmonthHT4P + dgvTotal.lblmonthHT5P + dgvTotal.lblmonthHT6P;
            for (int i = 0; i < dgvFee.Items.Count; i++)
            {
                var gt = dgvFee.Items[i] as dgvFee_ViewModel;
                dgvTotal.lblmonthHT3A += gt.lblmonthHT3A;
                dgvTotal.lblmonthHT2A += gt.lblmonthHT2A;
                dgvTotal.lblmonthHT1A += gt.lblmonthHT1A;
                dgvTotal.lblmonthHT += gt.lblmonthHT;
                dgvTotal.lblmonthHT1P += gt.lblmonthHT1P;
                dgvTotal.lblmonthHT2P += gt.lblmonthHT2P;
                dgvTotal.lblmonthHT3P += gt.lblmonthHT3P;
                dgvTotal.lblmonthHT4P += gt.lblmonthHT4P;
                dgvTotal.lblmonthHT5P += gt.lblmonthHT5P;
                dgvTotal.lblmonthHT6P += gt.lblmonthHT6P;
                dgvTotal.lblToTalS = dgvTotal.lblToTalS = dgvTotal.lblmonthHT3A + dgvTotal.lblmonthHT2A + dgvTotal.lblmonthHT1A + dgvTotal.lblmonthHT + dgvTotal.lblmonthHT1P + dgvTotal.lblmonthHT2P + dgvTotal.lblmonthHT3P + dgvTotal.lblmonthHT4P + dgvTotal.lblmonthHT5P + dgvTotal.lblmonthHT6P;
            }
            total.Add(dgvTotal);
            return total;
        }
    }
}
