using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Aikido.DAO;
using Aikido.DAO.Model;
namespace Aikido.DAO
{
    public class SaveFee_DAO
    {
        //public void saveFeeD(List<dgvFee_ViewModel> UpdateFeeD)
        //{
        //    using (var dataContext = new AccessDB_DAO())
        //    {
        //        int r = DateTime.Now.Month;
        //        try
        //        {
        //            foreach (var dataFee in UpdateFeeD)
        //            {
        //                switch (r)
        //                {
        //                    case 1:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);

        //                            learn.FeeD_January = dataFee.lblmonthHT;
        //                            learn.FeeD_February = dataFee.lblmonthHT1P;
        //                            learn.FeeD_March = dataFee.lblmonthHT2P;
        //                            learn.FeeD_April = dataFee.lblmonthHT3P;
        //                            learn.FeeD_May = dataFee.lblmonthHT4P;
        //                            learn.FeeD_June = dataFee.lblmonthHT5P;
        //                            learn.FeeD_July = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            //Learn learn1 = dataContext.Learns.Where(s => s.RegisterNumber == dataFee.RegisterNumber && s.Day_Create.Year == r - 1 && s.Delete_Flag == false).Last();

        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.FeeD_January = dataFee.lblmonthHT1A;
        //                            learn.FeeD_February = dataFee.lblmonthHT;
        //                            learn.FeeD_March = dataFee.lblmonthHT1P;
        //                            learn.FeeD_April = dataFee.lblmonthHT2P;
        //                            learn.FeeD_May = dataFee.lblmonthHT3P;
        //                            learn.FeeD_June = dataFee.lblmonthHT4P;
        //                            learn.FeeD_July = dataFee.lblmonthHT5P;
        //                            learn.FeeD_August = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 3:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.FeeD_January = dataFee.lblmonthHT2A;
        //                            learn.FeeD_February = dataFee.lblmonthHT1A;
        //                            learn.FeeD_March = dataFee.lblmonthHT;
        //                            learn.FeeD_April = dataFee.lblmonthHT1P;
        //                            learn.FeeD_May = dataFee.lblmonthHT2P;
        //                            learn.FeeD_June = dataFee.lblmonthHT3P;
        //                            learn.FeeD_July = dataFee.lblmonthHT4P;
        //                            learn.FeeD_August = dataFee.lblmonthHT5P;
        //                            learn.FeeD_September = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 4:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.FeeD_January = dataFee.lblmonthHT3A;
        //                            learn.FeeD_February = dataFee.lblmonthHT2A;
        //                            learn.FeeD_March = dataFee.lblmonthHT1A;
        //                            learn.FeeD_April = dataFee.lblmonthHT;
        //                            learn.FeeD_May = dataFee.lblmonthHT1P;
        //                            learn.FeeD_June = dataFee.lblmonthHT2P;
        //                            learn.FeeD_July = dataFee.lblmonthHT3P;
        //                            learn.FeeD_August = dataFee.lblmonthHT4P;
        //                            learn.FeeD_September = dataFee.lblmonthHT5P;
        //                            learn.FeeD_October = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 5:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.FeeD_February = dataFee.lblmonthHT3A;
        //                            learn.FeeD_March = dataFee.lblmonthHT2A;
        //                            learn.FeeD_April = dataFee.lblmonthHT1A;
        //                            learn.FeeD_May = dataFee.lblmonthHT;
        //                            learn.FeeD_June = dataFee.lblmonthHT1P;
        //                            learn.FeeD_July = dataFee.lblmonthHT2P;
        //                            learn.FeeD_August = dataFee.lblmonthHT3P;
        //                            learn.FeeD_September = dataFee.lblmonthHT4P;
        //                            learn.FeeD_October = dataFee.lblmonthHT5P;
        //                            learn.FeeD_November = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 6:
        //                        {
        //                            Learn learn = dataContext.Learns.Where(s => s.ID_Learn == dataFee.ID_Learn).Last();
        //                            learn.FeeD_March = dataFee.lblmonthHT3A;
        //                            learn.FeeD_April = dataFee.lblmonthHT2A;
        //                            learn.FeeD_May = dataFee.lblmonthHT1A;
        //                            learn.FeeD_June = dataFee.lblmonthHT;
        //                            learn.FeeD_July = dataFee.lblmonthHT1P;
        //                            learn.FeeD_August = dataFee.lblmonthHT2P;
        //                            learn.FeeD_September = dataFee.lblmonthHT3P;
        //                            learn.FeeD_October = dataFee.lblmonthHT4P;
        //                            learn.FeeD_November = dataFee.lblmonthHT5P;
        //                            learn.FeeD_December = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 7:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.FeeD_April = dataFee.lblmonthHT3A;
        //                            learn.FeeD_May = dataFee.lblmonthHT2A;
        //                            learn.FeeD_June = dataFee.lblmonthHT1A;
        //                            learn.FeeD_July = dataFee.lblmonthHT;
        //                            learn.FeeD_August = dataFee.lblmonthHT1P;
        //                            learn.FeeD_September = dataFee.lblmonthHT2P;
        //                            learn.FeeD_October = dataFee.lblmonthHT3P;
        //                            learn.FeeD_November = dataFee.lblmonthHT4P;
        //                            learn.FeeD_December = dataFee.lblmonthHT5P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 8:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);

        //                            learn.FeeD_May = dataFee.lblmonthHT3A;
        //                            learn.FeeD_June = dataFee.lblmonthHT2A;
        //                            learn.FeeD_July = dataFee.lblmonthHT1A;
        //                            learn.FeeD_August = dataFee.lblmonthHT;
        //                            learn.FeeD_September = dataFee.lblmonthHT1P;
        //                            learn.FeeD_October = dataFee.lblmonthHT2P;
        //                            learn.FeeD_November = dataFee.lblmonthHT3P;
        //                            learn.FeeD_December = dataFee.lblmonthHT4P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 9:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.FeeD_June = dataFee.lblmonthHT3A;
        //                            learn.FeeD_July = dataFee.lblmonthHT2A;
        //                            learn.FeeD_August = dataFee.lblmonthHT1A;
        //                            learn.FeeD_September = dataFee.lblmonthHT;
        //                            learn.FeeD_October = dataFee.lblmonthHT1P;
        //                            learn.FeeD_November = dataFee.lblmonthHT2P;
        //                            learn.FeeD_December = dataFee.lblmonthHT3P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 10:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.FeeD_July = dataFee.lblmonthHT3A;
        //                            learn.FeeD_August = dataFee.lblmonthHT2A;
        //                            learn.FeeD_September = dataFee.lblmonthHT1A;
        //                            learn.FeeD_October = dataFee.lblmonthHT;
        //                            learn.FeeD_November = dataFee.lblmonthHT1P;
        //                            learn.FeeD_December = dataFee.lblmonthHT2P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 11:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.FeeD_August = dataFee.lblmonthHT3A;
        //                            learn.FeeD_September = dataFee.lblmonthHT2A;
        //                            learn.FeeD_October = dataFee.lblmonthHT1A;
        //                            learn.FeeD_November = dataFee.lblmonthHT;
        //                            learn.FeeD_December = dataFee.lblmonthHT1P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 12:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.FeeD_September = dataFee.lblmonthHT3A;
        //                            learn.FeeD_October = dataFee.lblmonthHT2A;
        //                            learn.FeeD_November = dataFee.lblmonthHT1A;
        //                            learn.FeeD_December = dataFee.lblmonthHT;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                }
        //            }
        //        }
        //        catch(Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }

        //    }
        //}
        //public void saveFee(List<dgvFee_ViewModel> UpdateFee)
        //{
        //    using (var dataContext = new AccessDB_DAO())
        //    {
        //        int r = DateTime.Now.Month;
        //        try
        //        {
        //            foreach (var dataFee in UpdateFee)
        //            {
        //                switch (r)
        //                {
        //                    case 1:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);

        //                            learn.Fee_January = dataFee.lblmonthHT;
        //                            learn.Fee_February = dataFee.lblmonthHT1P;
        //                            learn.Fee_March = dataFee.lblmonthHT2P;
        //                            learn.Fee_April = dataFee.lblmonthHT3P;
        //                            learn.Fee_May = dataFee.lblmonthHT4P;
        //                            learn.Fee_June = dataFee.lblmonthHT5P;
        //                            learn.Fee_July = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            //Learn learn1 = dataContext.Learns.Where(s => s.RegisterNumber == dataFee.RegisterNumber && s.Day_Create.Year == r - 1 && s.Delete_Flag == false).Last();

        //                            break;
        //                        }
        //                    case 2:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_January = dataFee.lblmonthHT1A;
        //                            learn.Fee_February = dataFee.lblmonthHT;
        //                            learn.Fee_March = dataFee.lblmonthHT1P;
        //                            learn.Fee_April = dataFee.lblmonthHT2P;
        //                            learn.Fee_May = dataFee.lblmonthHT3P;
        //                            learn.Fee_June = dataFee.lblmonthHT4P;
        //                            learn.Fee_July = dataFee.lblmonthHT5P;
        //                            learn.Fee_August = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 3:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_January = dataFee.lblmonthHT2A;
        //                            learn.Fee_February = dataFee.lblmonthHT1A;
        //                            learn.Fee_March = dataFee.lblmonthHT;
        //                            learn.Fee_April = dataFee.lblmonthHT1P;
        //                            learn.Fee_May = dataFee.lblmonthHT2P;
        //                            learn.Fee_June = dataFee.lblmonthHT3P;
        //                            learn.Fee_July = dataFee.lblmonthHT4P;
        //                            learn.Fee_August = dataFee.lblmonthHT5P;
        //                            learn.Fee_September = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 4:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_January = dataFee.lblmonthHT3A;
        //                            learn.Fee_February = dataFee.lblmonthHT2A;
        //                            learn.Fee_March = dataFee.lblmonthHT1A;
        //                            learn.Fee_April = dataFee.lblmonthHT;
        //                            learn.Fee_May = dataFee.lblmonthHT1P;
        //                            learn.Fee_June = dataFee.lblmonthHT2P;
        //                            learn.Fee_July = dataFee.lblmonthHT3P;
        //                            learn.Fee_August = dataFee.lblmonthHT4P;
        //                            learn.Fee_September = dataFee.lblmonthHT5P;
        //                            learn.Fee_October = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 5:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_February = dataFee.lblmonthHT3A;
        //                            learn.Fee_March = dataFee.lblmonthHT2A;
        //                            learn.Fee_April = dataFee.lblmonthHT1A;
        //                            learn.Fee_May = dataFee.lblmonthHT;
        //                            learn.Fee_June = dataFee.lblmonthHT1P;
        //                            learn.Fee_July = dataFee.lblmonthHT2P;
        //                            learn.Fee_August = dataFee.lblmonthHT3P;
        //                            learn.Fee_September = dataFee.lblmonthHT4P;
        //                            learn.Fee_October = dataFee.lblmonthHT5P;
        //                            learn.Fee_November = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 6:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_March = dataFee.lblmonthHT3A;
        //                            learn.Fee_April = dataFee.lblmonthHT2A;
        //                            learn.Fee_May = dataFee.lblmonthHT1A;
        //                            learn.Fee_June = dataFee.lblmonthHT;
        //                            learn.Fee_July = dataFee.lblmonthHT1P;
        //                            learn.Fee_August = dataFee.lblmonthHT2P;
        //                            learn.Fee_September = dataFee.lblmonthHT3P;
        //                            learn.Fee_October = dataFee.lblmonthHT4P;
        //                            learn.Fee_November = dataFee.lblmonthHT5P;
        //                            learn.Fee_December = dataFee.lblmonthHT6P;
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 7:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_April = dataFee.lblmonthHT3A;
        //                            learn.Fee_May = dataFee.lblmonthHT2A;
        //                            learn.Fee_June = dataFee.lblmonthHT1A;
        //                            learn.Fee_July = dataFee.lblmonthHT;
        //                            learn.Fee_August = dataFee.lblmonthHT1P;
        //                            learn.Fee_September = dataFee.lblmonthHT2P;
        //                            learn.Fee_October = dataFee.lblmonthHT3P;
        //                            learn.Fee_November = dataFee.lblmonthHT4P;
        //                            learn.Fee_December = dataFee.lblmonthHT5P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 8:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);

        //                            learn.Fee_May = dataFee.lblmonthHT3A;
        //                            learn.Fee_June = dataFee.lblmonthHT2A;
        //                            learn.Fee_July = dataFee.lblmonthHT1A;
        //                            learn.Fee_August = dataFee.lblmonthHT;
        //                            learn.Fee_September = dataFee.lblmonthHT1P;
        //                            learn.Fee_October = dataFee.lblmonthHT2P;
        //                            learn.Fee_November = dataFee.lblmonthHT3P;
        //                            learn.Fee_December = dataFee.lblmonthHT4P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 9:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_June = dataFee.lblmonthHT3A;
        //                            learn.Fee_July = dataFee.lblmonthHT2A;
        //                            learn.Fee_August = dataFee.lblmonthHT1A;
        //                            learn.Fee_September = dataFee.lblmonthHT;
        //                            learn.Fee_October = dataFee.lblmonthHT1P;
        //                            learn.Fee_November = dataFee.lblmonthHT2P;
        //                            learn.Fee_December = dataFee.lblmonthHT3P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 10:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_July = dataFee.lblmonthHT3A;
        //                            learn.Fee_August = dataFee.lblmonthHT2A;
        //                            learn.Fee_September = dataFee.lblmonthHT1A;
        //                            learn.Fee_October = dataFee.lblmonthHT;
        //                            learn.Fee_November = dataFee.lblmonthHT1P;
        //                            learn.Fee_December = dataFee.lblmonthHT2P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 11:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_August = dataFee.lblmonthHT3A;
        //                            learn.Fee_September = dataFee.lblmonthHT2A;
        //                            learn.Fee_October = dataFee.lblmonthHT1A;
        //                            learn.Fee_November = dataFee.lblmonthHT;
        //                            learn.Fee_December = dataFee.lblmonthHT1P;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                    case 12:
        //                        {
        //                            Learn learn = dataContext.Learns.FirstOrDefault(s => s.ID_Learn == dataFee.ID_Learn);
        //                            learn.Fee_September = dataFee.lblmonthHT3A;
        //                            learn.Fee_October = dataFee.lblmonthHT2A;
        //                            learn.Fee_November = dataFee.lblmonthHT1A;
        //                            learn.Fee_December = dataFee.lblmonthHT;
        //                            //
        //                            learn.Day_Update = DateTime.Now;
        //                            dataContext.Learns.Update(learn);
        //                            dataContext.SaveChanges();
        //                            break;
        //                        }
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}

        public void saveFee(Fee_Model dataFee)
        {
            using (var dataContext = new AccessDB_DAO())
            {
                try
                {
                    Fee_Model fee1 = dataContext.Fees.FirstOrDefault(s => s.ID_Class == dataFee.ID_Class && s.RegisterNumber == dataFee.RegisterNumber && s.Month == dataFee.Month && s.Year == dataFee.Year && s.Fee_Type.Equals("Hội Phí") == true);
                    Fee_Model fee2 = dataContext.Fees.FirstOrDefault(s => s.ID_Class == dataFee.ID_Class && s.RegisterNumber == dataFee.RegisterNumber && s.Month == dataFee.Month && s.Year == dataFee.Year && s.Fee_Type.Equals("Phí Khác") == true);
                    if (fee1 == null)
                    {
                        Fee_Model feeadd1 = new Fee_Model();
                        //int Id = dataContext.Fees.Max(s => s.ID_Learn);
                        //feeadd1.ID_Learn = ++Id;
                        feeadd1.ID_Class = dataFee.ID_Class;
                        feeadd1.RegisterNumber = dataFee.RegisterNumber;
                        feeadd1.Fee_Type = "Hội Phí";
                        feeadd1.Month = dataFee.Month;
                        feeadd1.Year = dataFee.Year;
                        feeadd1.Fee_Value = dataFee.Fee_Value;
                        feeadd1.Day_Create = DateTime.Now;
                        //feeadd1.Day_Update = DateTime.MinValue;
                        feeadd1.Delete_Flag = false;
                        dataContext.Fees.Add(feeadd1);

                        Fee_Model feeadd2 = new Fee_Model();
                        feeadd2.ID_Class = dataFee.ID_Class;
                        feeadd2.RegisterNumber = dataFee.RegisterNumber;
                        feeadd2.Fee_Type = "Phí Khác";
                        feeadd2.Month = dataFee.Month;
                        feeadd2.Year = dataFee.Year;
                        feeadd2.Fee_Value = 0;
                        feeadd2.Day_Create = DateTime.Now;
                       // feeadd2.Day_Update = DateTime.MinValue;
                        feeadd2.Delete_Flag = false;
                        dataContext.Fees.Add(feeadd2);
                        dataContext.SaveChanges();
                    }
                    else if (fee2 == null)
                    {
                        Fee_Model feeadd1 = new Fee_Model();
                      //  int Id = dataContext.Fees.Max(s => s.ID_Learn);
                       // feeadd1.ID_Learn = ++Id;
                        feeadd1.ID_Class = dataFee.ID_Class;
                        feeadd1.RegisterNumber = dataFee.RegisterNumber;
                        feeadd1.Fee_Type = "Phí Khác";
                        feeadd1.Month = dataFee.Month;
                        feeadd1.Year = dataFee.Year;
                        feeadd1.Fee_Value = dataFee.Fee_Value;
                        feeadd1.Day_Create = DateTime.Now;
                       // feeadd1.Day_Update = DateTime.MinValue;
                        feeadd1.Delete_Flag = false;
                        dataContext.Fees.Add(feeadd1);
                        dataContext.SaveChanges();
                    }
                    else if (fee1 != null && fee2 != null)
                    {
                        if (dataFee.Fee_Type.Equals("Hội Phí") == true)
                        {
                            fee1.Fee_Value = dataFee.Fee_Value;
                            fee1.Day_Update = DateTime.Now;
                            dataContext.Fees.Update(fee1);
                            dataContext.SaveChanges();
                        }
                        else
                        {
                            fee2.Fee_Value = dataFee.Fee_Value;
                            fee2.Day_Update = DateTime.Now;
                            dataContext.Fees.Update(fee2);
                            dataContext.SaveChanges();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
