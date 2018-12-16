using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Aikido.BLO;
using System.ComponentModel;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
using System.Threading;
using System.Globalization;

namespace Aikido.VIEW
{
    public partial class SearchCondition : System.Windows.Window
    {
        public SearchCondition()
        {
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = ci;
            //var lst = new SearchMember_BLO();
            //var a = lst.GetStudents();
            //dgvSearchC.ItemsSource = a;

            InitializeComponent();
        }

        private void btnDKHV_MouseEnter(object sender, MouseEventArgs e)
        {
            btnDKHVb.Background = Brushes.DarkBlue;
            btnDKHV.Background = Brushes.LightGray;
        }

        private void btnDKHV_MouseLeave(object sender, MouseEventArgs e)
        {
            btnDKHVb.Background = Brushes.White;
            btnDKHV.Background = Brushes.White;
        }

        private void btnSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnSearchb.Background = Brushes.DarkBlue;
            //btnSearch.Background = Brushes.LightGray;
            //btnSearchI.Background = Brushes.LightGray;

        }

        private void btnSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnSearch.Background = Brushes.White;
            //btnSearchb.Background = Brushes.White;
            //btnSearchI.Background = Brushes.White;
        }

        private void btnQLHP_MouseEnter(object sender, MouseEventArgs e)
        {
            btnQLHPb.Background = Brushes.DarkBlue;
            btnQLHP.Background = Brushes.LightGray;
        }

        private void btnQLHP_MouseLeave(object sender, MouseEventArgs e)
        {
            btnQLHPb.Background = Brushes.White;
            btnQLHP.Background = Brushes.White;
        }

        private void btnQLL_MouseEnter(object sender, MouseEventArgs e)
        {
            btnQLLb.Background = Brushes.DarkBlue;
            btnQLL.Background = Brushes.LightGray;
        }

        private void btnQLL_MouseLeave(object sender, MouseEventArgs e)
        {
            btnQLLb.Background = Brushes.White;
            btnQLL.Background = Brushes.White;
        }

        private void btnTL_MouseEnter(object sender, MouseEventArgs e)
        {
            btnTLb.Background = Brushes.DarkBlue;
            btnTL.Background = Brushes.LightGray;
        }

        private void btnTL_MouseLeave(object sender, MouseEventArgs e)
        {
            btnTLb.Background = Brushes.White;
            btnTL.Background = Brushes.White;
        }

        private void btnHelpI_MouseEnter(object sender, MouseEventArgs e)
        {
            btnHelp.Background = Brushes.LightGray;
            btnHelpb.Background = Brushes.DarkBlue;
            btnHelpI.Background = Brushes.LightGray;
        }

        private void btnHelpI_MouseLeave(object sender, MouseEventArgs e)
        {
            btnHelp.Background = Brushes.White;
            btnHelpb.Background = Brushes.White;
            btnHelpI.Background = Brushes.White;
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterMemberScreen rgm = new RegisterMemberScreen();
            rgm.Show();
            this.Close();
        }
        private void Quick_Click(object sender, RoutedEventArgs e)
        {
            QuickSearch quick = new QuickSearch();
            quick.Show();
            this.Close();
        }
        private void Condition_Click(object sender, RoutedEventArgs e)
        {
            //SearchCondition scon = new SearchCondition();
            //scon.Show();
            //this.Close();
        }
        private void ClassManagement_Click(object sender, RoutedEventArgs e)
        {
            ClassScreen classScreen = new ClassScreen();
            classScreen.Show();
            this.Close();
        }
        private void FeeManagement_Click(object sender, RoutedEventArgs e)
        {
            FeeScreen fees = new FeeScreen();
            fees.Show();
            this.Close();
        }
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SettingScreen setting = new SettingScreen();
            setting.Show();
            this.Close();
        }
        //private void TTNPT_Click(object sender, RoutedEventArgs e)
        //{
        //    Support scon = new Support();
        //    scon.Show();
        //    this.Close();
        //}
        //private void HDSD_Click(object sender, RoutedEventArgs e)
        //{
        //    //SearchCondition scon = new SearchCondition();
        //    //scon.Show();
        //    //this.Close();
        //}
        //
        private void btnTimKiem_Click(object sender, RoutedEventArgs e)
        {
            String error = null;
            int err = 0;
            if (dtpNgaySinh.SelectedDate > DateTime.Now)
            {
                error += "Ngày sinh phải nhỏ hơn ngày hiện tại";
                err = 1;
            }
            if (dtpNgayDangKy.SelectedDate > DateTime.Now)
            {
                error += " Ngày đăng ký phải nhỏ hơn hoặc bằng ngày hiện tại";
                err = 1;
            }
            if (err == 0)
            {
                dgvSearchC.Visibility = Visibility.Visible;
                var lst = new SearchMember_BLO();
                var a = lst.SearchCon(txtSKU.Text, txtHoTen.Text, dtpNgayDangKy.Text, dtpNgaySinh.Text);
                if (a.Count == 0)
                {
                    dgvSearchC.ItemsSource = null;
                    MessageBox.Show("Không tìm thấy");
                }
                else
                {
                    dgvSearchC.CanUserResizeColumns = false;
                    dgvSearchC.CanUserResizeRows = false;
                    dgvSearchC.ItemsSource = a;
                    dgvSearchC.Columns[0].Width = 70;
                    dgvSearchC.Columns[1].Width = 250;
                    dgvSearchC.Columns[2].Width = 100;
                    dgvSearchC.Columns[3].Width = 100;
                    dgvSearchC.Columns[4].Width = 150;
                    dgvSearchC.Columns[5].Width = 350;
                    dgvSearchC.Columns[6].Width = 150;
                  
                    // dgvSearchC.Columns[5].Width = 300;
                    //dgvSearchC.Columns[1].Visibility = Visibility.Hidden;
                    for (int i = 7; i < 41; i++)
                    {
                        dgvSearchC.Columns[i].Visibility = Visibility.Hidden;
                    }
                    //dgvSearchC.Columns[15].Visibility = Visibility.Visible;
                }

            }
            else
            {
                MessageBox.Show(error);
            }
        }


        private void dgvSearchC_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {

            var desc = e.PropertyDescriptor as PropertyDescriptor;
            var att = desc.Attributes[typeof(DAO.Model.ColumnNameAttribute)] as DAO.Model.ColumnNameAttribute;
            if (att != null)
            {
                e.Column.Header = att.Name;
            }
        }

        private void btnXuatFile_Click(object sender, RoutedEventArgs e)
        {
            if (dgvSearchC.Items.Count == 0)
            {
                MessageBox.Show("Không thể xuất file excel");
            }
            else
            {
                XuatExcel("Search");
            }
        }
        private void XuatExcel(String sheetname)
        {
            //Tạo các đối tượng Excel
            try
            {
                //export2Excel(dgvSearchC, "E:/", "abc");
                if (dgvSearchC.Items.Count == 0)
                {
                    MessageBox.Show("Không có nội dung để xuất file");
                }
                else
                {
                    app oExcel = new app();
                    Workbooks oBooks;
                    Sheets oSheets;
                    Workbook oBook;
                    Worksheet oSheet;


                    oExcel.Application.SheetsInNewWorkbook = 1;
                    oBooks = oExcel.Workbooks;
                    oBook = (Workbook)(oExcel.Workbooks.Add(Type.Missing));
                    oSheets = oBook.Worksheets;
                    oSheet = (Worksheet)oSheets.get_Item(1);
                    oSheet.Name = sheetname;
                    //Header

                    Range head = oSheet.get_Range("A1", "AG1");
                    head.Font.Bold = true;
                    head.Font.Name = "Tahoma";
                    head.Font.Size = "10";
                    head.Interior.ColorIndex = 8;
                    head.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                    head.Borders.LineStyle = Constants.xlSolid;
                    int r = 0;

                    // Tạo tiêu đề cột
                    List<Range> cl = new List<Range>();
                    List<string> rg = new List<string>();
                    rg.Add("A1"); rg.Add("B1"); rg.Add("C1"); rg.Add("D1"); rg.Add("E1"); rg.Add("F1");
                    rg.Add("G1"); rg.Add("H1"); rg.Add("I1"); rg.Add("J1"); rg.Add("K1"); rg.Add("L1");
                    rg.Add("M1"); rg.Add("N1"); rg.Add("O1"); rg.Add("P1"); rg.Add("Q1"); rg.Add("R1");
                    rg.Add("S1"); rg.Add("T1"); rg.Add("U1"); rg.Add("V1"); rg.Add("W1"); rg.Add("X1"); rg.Add("Y1");
                    rg.Add("Z1"); rg.Add("AA1"); rg.Add("AB1"); rg.Add("AC1"); rg.Add("AD1"); rg.Add("AE1");
                    rg.Add("AF1"); rg.Add("AG1");
                    int crg = 0;
                    Range rang;
                    rang = oSheet.get_Range(rg[crg], rg[crg]);
                    rang.Value2 = "STT";
                    rang.ColumnWidth = 10.0;
                    cl.Add(rang);
                    crg++;
                    foreach (var i in dgvSearchC.Columns)
                    {
                        if (!i.Header.Equals("SKU ") && !i.Header.Equals("Họ Tên ") && !i.Header.Equals("Ngày Sinh ") && !i.Header.Equals("Số Điện Thoại ") && !i.Header.Equals("Địa Chỉ ") && !i.Header.Equals("Quốc Tịch ") && !i.Header.Equals("Ngày Đăng Ký "))
                        {
                            Range cli;
                            cli = oSheet.get_Range(rg[crg], rg[crg]);
                            cli.Value2 = i.Header;
                            cli.ColumnWidth = 18.0;
                            cli.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;
                            cl.Add(cli);
                            crg++;
                            if (crg == 33) break;
                        }
                    }

                    //Nội dung điền lên excel
                    object[,] arr = new object[dgvSearchC.Items.Count, dgvSearchC.Columns.Count];

                    for (int i = 0; i < dgvSearchC.Items.Count; i++)
                    {
                        var dt = dgvSearchC.Items[i] as DAO.Model.Search_Model;
                        arr[r, 0] = r + 1;
                        arr[r, 1] = dt.RegisterNumber;
                        arr[r, 2] = dt.SKU;
                        arr[r, 3] = dt.FullName;
                        arr[r, 4] = dt.Nation;
                        arr[r, 5] = dt.Address;
                        arr[r, 6] = "'" + dt.PhoneNumber.ToString();
                        arr[r, 7] = dt.Day_of_Birth.ToShortDateString();
                        arr[r, 8] = dt.Day_Create.ToShortDateString();

                        arr[r, 9] = dt.Place_of_birth.ToString();
                        arr[r, 10] = dt.Class_Name.ToString();
                        arr[r, 11] = dt.DAI_Cap_6.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp" : dt.DAI_Cap_6.ToShortDateString();
                        arr[r, 12] = dt.DAI_Cap_5.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp" : dt.DAI_Cap_5.ToShortDateString();
                        arr[r, 13] = dt.DAI_Cap_4.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp" : dt.DAI_Cap_4.ToShortDateString();
                        arr[r, 14] = dt.DAI_Cap_3.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp" : dt.DAI_Cap_3.ToShortDateString();
                        arr[r, 15] = dt.DAI_Cap_2.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp" : dt.DAI_Cap_2.ToShortDateString();
                        arr[r, 16] = dt.DAI_Cap_1.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp" : dt.DAI_Cap_1.ToShortDateString();
                        arr[r, 17] = dt.DAN_VN_1.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp" : dt.DAN_VN_1.ToShortDateString();
                        arr[r, 18] = dt.DAN_VN_2.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp" : dt.DAN_VN_2.ToShortDateString();
                        arr[r, 19] = dt.DAN_VN_3.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_VN_3.ToShortDateString();
                        arr[r, 20] = dt.DAN_VN_4.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_VN_4.ToShortDateString();
                        arr[r, 21] = dt.DAN_VN_5.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_VN_5.ToShortDateString();
                        arr[r, 22] = dt.DAN_VN_6.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_VN_6.ToShortDateString();
                        arr[r, 23] = dt.DAN_VN_7.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_VN_7.ToShortDateString();
                        arr[r, 24] = dt.DAN_VN_8.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_VN_8.ToShortDateString();
                        arr[r, 25] = dt.DAN_AIKIKAI_1.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_AIKIKAI_1.ToShortDateString();
                        arr[r, 26] = dt.DAN_AIKIKAI_2.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_AIKIKAI_2.ToShortDateString();
                        arr[r, 27] = dt.DAN_AIKIKAI_3.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_AIKIKAI_3.ToShortDateString();
                        arr[r, 28] = dt.DAN_AIKIKAI_4.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_AIKIKAI_4.ToShortDateString();
                        arr[r, 29] = dt.DAN_AIKIKAI_5.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_AIKIKAI_5.ToShortDateString();
                        arr[r, 30] = dt.DAN_AIKIKAI_6.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_AIKIKAI_6.ToShortDateString();
                        arr[r, 31] = dt.DAN_AIKIKAI_7.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_AIKIKAI_7.ToShortDateString();
                        arr[r, 32] = dt.DAN_AIKIKAI_8.ToShortDateString().Contains(DateTime.MinValue.ToShortDateString()) == true ? "Chưa cấp " : dt.DAN_AIKIKAI_8.ToShortDateString();

                        r++;
                    }

                    //Thiết lập vùng điền dữ liệu
                    int rowStart = 2;
                    int columnStart = 1;
                    int rowEnd = rowStart + dgvSearchC.Items.Count - 1;
                    int columnEnd = dgvSearchC.Columns.Count - 8;

                    // Ô bắt đầu điền dữ liệu

                    Range c1 = (Range)oSheet.Cells[rowStart, columnStart];

                    // Ô kết thúc điền dữ liệu

                    Range c2 = (Range)oSheet.Cells[rowEnd, columnEnd];

                    // Lấy về vùng điền dữ liệu

                    Range range = oSheet.get_Range(c1, c2);

                    //Điền dữ liệu vào vùng đã thiết lập

                    range.Value2 = arr;

                    // Kẻ viền

                    range.Borders.LineStyle = Constants.xlSolid;
                    range.HorizontalAlignment = XlHAlign.xlHAlignCenterAcrossSelection;


                    // Căn giữa cột

                    Range c3 = (Range)oSheet.Cells[rowEnd, columnStart];

                    Range c4 = oSheet.get_Range(c1, c3);

                    oSheet.get_Range(c3, c4).HorizontalAlignment = XlHAlign.xlHAlignCenter;
                    //oExcel.ActiveWorkbook.SaveCopyAs("E:/Export.xlsx");
                    //oExcel.ActiveWorkbook.Saved = true;
                    //System.Diagnostics.Process.Start("E:/Export.xlsx");
                    oExcel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

            private void dgvSearchC_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            int r = dgvSearchC.SelectedIndex;

            var datasearch = dgvSearchC.Items[r] as DAO.Model.Search_Model;

            RegisterMemberScreen register = new RegisterMemberScreen(datasearch);
            register.Show();
            this.Close();
        }

        private void btnHelpI_Click(object sender, RoutedEventArgs e)
        {
            Support sp = new Support();
            sp.Show();
            this.Close();
        }
    }
}
