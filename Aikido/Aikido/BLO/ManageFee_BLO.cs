using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aikido.DAO.Model;
using Aikido.DAO;
using System.Windows.Controls;
using System.Windows;
using app = Microsoft.Office.Interop.Excel.Application;
using Microsoft.Office.Interop.Excel;
using System.Globalization;

namespace Aikido.BLO
{
    public class ManageFee_BLO
    {
        //ExportExcel
        public void XuatExcel(DataGrid dgvFee1, DataGrid dgvFee2, DataGrid dgvTotal, string sheetName)
        {
            CultureInfo ci = new CultureInfo("en-US");
            app oExcel = new app();
            Workbooks oBooks;
            Sheets oSheets;
            Workbook oBook;
            Worksheet oSheet;
            //Tạo các đối tượng Excel
            try
            {
                //export2Excel(dgvSearchQ, "E:/", "abc");
                if (dgvFee1.Items.Count == 0)
                {
                    MessageBox.Show("Không có nội dung để xuất file");
                }
                else
                {
                    oExcel.Application.SheetsInNewWorkbook = 1;
                    oBooks = oExcel.Workbooks;
                    oBook = (Workbook)(oExcel.Workbooks.Add(Type.Missing));
                    oSheets = oBook.Worksheets;
                    oSheet = (Worksheet)oSheets.get_Item(1);
                    oSheet.Name = sheetName;
                    //Header

                    Range head = oSheet.get_Range("A1", "Q1");
                    head.Font.Bold = true;
                    head.Font.Name = "Tahoma";
                    head.Font.Size = "10";
                    head.Interior.ColorIndex = 8;
                    head.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                    head.Borders.LineStyle = Constants.xlSolid;

                    // Tạo tiêu đề cột
                    List<Range> cl = new List<Range>();
                    List<string> rg = new List<string>();
                    List<string> rg1 = new List<string>();
                    List<string> rg2 = new List<string>();

                    rg.Add("A1"); rg.Add("B1"); rg.Add("C1"); rg.Add("D1"); rg.Add("E1"); rg.Add("F1");
                    rg.Add("G1"); rg.Add("H1"); rg.Add("I1"); rg.Add("J1"); rg.Add("K1"); rg.Add("L1");
                    rg.Add("M1"); rg.Add("N1"); rg.Add("O1"); rg.Add("P1"); rg.Add("Q1"); rg.Add("R1");

                    rg1.Add("A"); rg1.Add("B"); rg1.Add("C"); rg1.Add("D"); rg1.Add("E");
                    rg2.Add("F"); rg2.Add("G"); rg2.Add("H"); rg2.Add("I"); rg2.Add("J"); rg2.Add("K");
                    rg2.Add("L"); rg2.Add("M"); rg2.Add("N"); rg2.Add("O"); rg2.Add("P"); rg2.Add("Q"); rg2.Add("R");
                    int crg = 0;
                    Range rang;
                    rang = oSheet.get_Range(rg[crg], rg[crg]);
                    rang.Value2 = "STT";
                    rang.ColumnWidth = 10.0;
                    rang.Borders.LineStyle = Constants.xlSolid;
                    cl.Add(rang);
                    crg++;
                    Range clii;
                    clii = oSheet.get_Range(rg[crg], rg[crg]);
                    clii.Value2 = "RegisterNumber";
                    clii.ColumnWidth = 18.0;
                    clii.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                    clii.Borders.LineStyle = Constants.xlSolid;
                    cl.Add(clii);
                    crg++;
                    foreach (var i in dgvFee1.Columns)
                    {
                        Range cli;
                        cli = oSheet.get_Range(rg[crg], rg[crg]);
                        cli.Value2 = i.Header;
                        cli.ColumnWidth = 18.0;
                        cli.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                        cli.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli);
                        crg++;
                    }
                    foreach (var i in dgvFee2.Columns)
                    {
                        if (i.Header.Equals("RegisterNumber") == false && i.Header.Equals("IDLearn") == false)
                        {
                            Range cli;
                            cli = oSheet.get_Range(rg[crg], rg[crg]);
                            cli.Value2 = i.Header;
                            cli.ColumnWidth = 18.0;
                            cli.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                            cli.Borders.LineStyle = Constants.xlSolid;
                            cl.Add(cli);
                            crg++;
                        }
                    }

                    //Điền dữ liệu lên
                    int stt = 1;
                    int d = 2;
                    for (int i = 0; i < dgvFee1.Items.Count; i++)
                    {
                        var j = dgvFee1.Items[i] as DAO.Model.dgvFee_ViewModel;
                        crg = 0;
                        Range cli;
                        cli = oSheet.get_Range(rg1[crg] + d, rg1[crg] + (d + 1));
                        cli.MergeCells = true;
                        cli.Value2 = stt++;
                        cli.ColumnWidth = 18.0;
                        cli.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli);
                        //d += 2;
                        crg++;

                        Range cli1;
                        cli1 = oSheet.get_Range(rg1[crg] + d, rg1[crg] + (d + 1));
                        cli1.MergeCells = true;
                        cli1.Value2 = j.RegisterNumber;
                        cli1.ColumnWidth = 18.0;
                        cli1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli1.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli1.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli1);
                        //d += 2;
                        crg++;

                        Range cli2;
                        cli2 = oSheet.get_Range(rg1[crg] + d, rg1[crg] + (d + 1));
                        cli2.MergeCells = true;
                        cli2.Value2 = j.lblSKU;
                        cli2.ColumnWidth = 18.0;
                        cli2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli2.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli2.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli2);
                        //d += 2;
                        crg++;

                        Range cli3;
                        cli3 = oSheet.get_Range(rg1[crg] + d, rg1[crg] + (d + 1));
                        cli3.MergeCells = true;
                        cli3.Value2 = j.lblnameHV;
                        cli3.ColumnWidth = 18.0;
                        cli3.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli3.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli3.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli3);
                        //d += 2;
                        crg++;

                        Range cli4;
                        cli4 = oSheet.get_Range(rg1[crg] + d, rg1[crg] + (d + 1));
                        cli4.MergeCells = true;
                        cli4.Value2 = j.lblnameClass;
                        cli4.ColumnWidth = 18.0;
                        cli4.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli4.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli4);
                        d += 2;
                        crg++;

                    }
                    d = 2;
                    for (int i = 0; i < dgvFee2.Items.Count; i++)
                    {
                        crg = 0;
                        var j = dgvFee2.Items[i] as DAO.Model.dgvFee_ViewModel;
                        Range cli;
                        cli = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli.Value2 = j.lbltypeFee;
                        cli.ColumnWidth = 18.0;
                        cli.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli);
                        //d++;
                        crg++;

                        Range cli1;
                        cli1 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli1.Value2 = j.lblmonthHT3A.ToString("#,##0");
                        cli1.ColumnWidth = 18.0;
                        cli1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli1.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli1.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli1);
                        //d++;
                        crg++;

                        Range cli2;
                        cli2 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli2.Value2 = j.lblmonthHT2A.ToString("#,##0");
                        cli2.ColumnWidth = 18.0;
                        cli2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli2.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli2.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli2);
                        //d++;
                        crg++;
                        Range cli3;
                        cli3 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli3.Value2 = j.lblmonthHT1A.ToString("#,##0");
                        cli3.ColumnWidth = 18.0;
                        cli3.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli3.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli3.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli3);
                        //d++;
                        crg++;
                        Range cli4;
                        cli4 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli4.Value2 = j.lblmonthHT.ToString("#,##0");
                        cli4.ColumnWidth = 18.0;
                        cli4.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli4.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli4);
                        //d++;
                        crg++;

                        Range cli5;
                        cli5 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli5.Value2 = j.lblmonthHT1P.ToString("#,##0");
                        cli5.ColumnWidth = 18.0;
                        cli5.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli5.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli5.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli5);
                        //d++;
                        crg++;

                        Range cli6;
                        cli6 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli6.Value2 = j.lblmonthHT2P.ToString("#,##0");
                        cli6.ColumnWidth = 18.0;
                        cli6.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli6.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli6.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli6);
                        //d++;
                        crg++;

                        Range cli7;
                        cli7 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli7.Value2 = j.lblmonthHT3P.ToString("#,##0");
                        cli7.ColumnWidth = 18.0;
                        cli7.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli7.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli7.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli7);
                        //d++;
                        crg++;

                        Range cli8;
                        cli8 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli8.Value2 = j.lblmonthHT4P.ToString("#,##0");
                        cli8.ColumnWidth = 18.0;
                        cli8.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli8.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli8.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli8);
                        //d++;
                        crg++;

                        Range cli9;
                        cli9 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli9.Value2 = j.lblmonthHT5P.ToString("#,##0");
                        cli9.ColumnWidth = 18.0;
                        cli9.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli9.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli9.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli9);
                        //d++;
                        crg++;

                        Range cli10;
                        cli10 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli10.Value2 = j.lblmonthHT6P.ToString("#,##0");
                        cli10.ColumnWidth = 18.0;
                        cli10.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli10.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli10.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli10);
                        //d++;
                        crg++;

                        Range cli11;
                        cli11 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli11.Value2 = j.lblToTalS.ToString("#,##0");
                        cli11.ColumnWidth = 18.0;
                        cli11.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli11.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli11.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli11);
                        d++;
                        crg++;
                    }


                    for (int i = 0; i < dgvTotal.Items.Count; i++)
                    {
                        crg = 0;
                        var j = dgvTotal.Items[i] as DAO.Model.dgvTotalC_ViewModel;
                        Range cli;
                        cli = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        
                        cli.Value2 = j.lblToal;
                        cli.ColumnWidth = 18.0;
                        cli.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli);
                        //d++;
                        crg++;

                        Range cli1;
                        cli1 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli1.Value2 = j.lblmonthHT3A.ToString("#,##0");
                        cli1.ColumnWidth = 18.0;
                        cli1.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli1.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli1.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli1);
                        //d++;
                        crg++;

                        Range cli2;
                        cli2 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli2.Value2 = j.lblmonthHT2A.ToString("#,##0");
                        cli2.ColumnWidth = 18.0;
                        cli2.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli2.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli2.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli2);
                        //d++;
                        crg++;
                        Range cli3;
                        cli3 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli3.Value2 = j.lblmonthHT1A.ToString("#,##0");
                        cli3.ColumnWidth = 18.0;
                        cli3.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli3.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli3.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli3);
                        //d++;
                        crg++;
                        Range cli4;
                        cli4 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli4.Value2 = j.lblmonthHT.ToString("#,##0");
                        cli4.ColumnWidth = 18.0;
                        cli4.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli4.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli4.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli4);
                        //d++;
                        crg++;

                        Range cli5;
                        cli5 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli5.Value2 = j.lblmonthHT1P.ToString("#,##0");
                        cli5.ColumnWidth = 18.0;
                        cli5.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli5.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli5.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli5);
                        //d++;
                        crg++;

                        Range cli6;
                        cli6 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli6.Value2 = j.lblmonthHT2P.ToString("#,##0");
                        cli6.ColumnWidth = 18.0;
                        cli6.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli6.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli6.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli6);
                        //d++;
                        crg++;

                        Range cli7;
                        cli7 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli7.Value2 = j.lblmonthHT3P.ToString("#,##0");
                        cli7.ColumnWidth = 18.0;
                        cli7.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli7.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli7.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli7);
                        //d++;
                        crg++;

                        Range cli8;
                        cli8 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli8.Value2 = j.lblmonthHT4P.ToString("#,##0");
                        cli8.ColumnWidth = 18.0;
                        cli8.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli8.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli8.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli8);
                        //d++;
                        crg++;

                        Range cli9;
                        cli9 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli9.Value2 = j.lblmonthHT5P.ToString("#,##0");
                        cli9.ColumnWidth = 18.0;
                        cli9.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli9.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli9.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli9);
                        //d++;
                        crg++;

                        Range cli10;
                        cli10 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli10.Value2 = j.lblmonthHT6P.ToString("#,##0");
                        cli10.ColumnWidth = 18.0;
                        cli10.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli10.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli10.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli10);
                        //d++;
                        crg++;

                        Range cli11;
                        cli11 = oSheet.get_Range(rg2[crg] + d, rg2[crg] + d);
                        cli11.Value2 = j.lblToTalS.ToString("#,##0");
                        cli11.ColumnWidth = 18.0;
                        cli11.HorizontalAlignment = XlHAlign.xlHAlignCenter;
                        cli11.VerticalAlignment = XlHAlign.xlHAlignCenter;
                        cli11.Borders.LineStyle = Constants.xlSolid;
                        cl.Add(cli11);
                        d++;
                        crg++;
                    }
                    oExcel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //Load Fee

        //public List<dgvFee_ViewModel> LoadAllFee()
        //{
        //    LoadFee_DAO fee = new LoadFee_DAO();
        //    return fee.selectAll();
        //}
        public List<dgvFee_ViewModel> LoadFee(int id)
        {
            LoadFee_DAO fee = new LoadFee_DAO();
            return fee.selectFee(id);
        }

        public List<dgvFee_ViewModel> LoadFee1(int id)
        {
            LoadFee_DAO fee = new LoadFee_DAO();
            return fee.selectFee1(id);
        }

        //public List<dgvFee_ViewModel> LoadAllFee1()
        //{
        //    //LoadFee_DAO fee = new LoadFee_DAO();
        //    //return fee.selectAllFee1();
        //}
        public List<dgvTotalC_ViewModel> LoadTotal(DataGrid dgv)
        {
            LoadFee_DAO fee = new LoadFee_DAO();
            return fee.Total(dgv);
        }
        //Save Fee Infos
        public void SaveFee(Fee_Model dataEdit)
        {
            SaveFee_DAO save = new SaveFee_DAO();
            save.saveFee(dataEdit);
        }

        //Filter
        //public List<dgvFee_ViewModel> LoadFilter(int id)
        //{
        //    FilterFee_DAO fee = new FilterFee_DAO();
        //    return fee.selectCondition(id);
        //}
        //public List<dgvFee_ViewModel> LoadFilter1(int id)
        //{
        //    FilterFee_DAO fee = new FilterFee_DAO();
        //    return fee.selectCondition1(id);
        //}

    }
}
