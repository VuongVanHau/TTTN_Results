using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Aikido.BLO;
using Aikido.DAO;
using Aikido.DAO.Model;


namespace Aikido.VIEW
{
    /// <summary>674
    /// 
    /// </summary>
    public partial class FeeScreen : Window
    {
        ManageClass_BLO classDB = new ManageClass_BLO();
        ManageFee_BLO feeBLO = new ManageFee_BLO();
        private int i = 0;
        private int val = -3;
        //ScrollViewer scrollView = null;
        //ScrollViewer scrollView2 = null;

        public FeeScreen()
        {
            InitializeComponent();
            List<Class> showCombobox = classDB.ComboxClass2(false);
            cmbClassName.ItemsSource = showCombobox;
            cmbClassName.DisplayMemberPath = "Class_Name";
            cmbClassName.SelectedValuePath = "ID_Class";
            cmbClassName.Background = Brushes.White;
            cmbClassName.Foreground = Brushes.DarkBlue;
            cmbClassName.SelectedIndex=0;                               // --Minh modified 5/8/2018
            //dgvTotalC.ItemsSource = feeBLO.LoadTotal(dgvFee2);
            //scrollView = getScrollbar(dgvFee1);
            //scrollView2 = getScrollbar(dgvFee2);
            //if (null != scrollView2)
            //{
            //    scrollView2.ScrollChanged += new ScrollChangedEventHandler(dgvFee2_ScrollChanged);
            //}

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
            btnSearchb.Background = Brushes.DarkBlue;
            btnSearch.Background = Brushes.LightGray;
            btnSearchI.Background = Brushes.LightGray;

        }

        private void btnSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            btnSearch.Background = Brushes.White;
            btnSearchb.Background = Brushes.White;
            btnSearchI.Background = Brushes.White;
        }

        private void btnQLHP_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnQLHPb.Background = Brushes.DarkBlue;
            //btnQLHP.Background = Brushes.LightGray;
        }

        private void btnQLHP_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnQLHPb.Background = Brushes.White;
            //btnQLHP.Background = Brushes.White;
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
            SearchCondition scon = new SearchCondition();
            scon.Show();
            this.Close();
        }
        private void ClassManagement_Click(object sender, RoutedEventArgs e)
        {
            ClassScreen classScreen = new ClassScreen();
            classScreen.Show();
            this.Close();
        }
        private void FeeManagement_Click(object sender, RoutedEventArgs e)
        {
            //FeeScreen fees = new FeeScreen();
            //fees.Show();
            //this.Close();
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

        private void btnExport_Click(object sender, RoutedEventArgs e)
        {
            feeBLO.XuatExcel(dgvFee1, dgvFee2, dgvTotalC, "Student Fee");
        }

        private void dgvFee_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var desc = e.PropertyDescriptor as PropertyDescriptor;
            var att = desc.Attributes[typeof(DAO.Model.ColumnNameAttribute)] as DAO.Model.ColumnNameAttribute;

            if (att != null)
            {
                if (i <= 3)
                {
                    e.Column.Header = att.Name;
                    i++;
                }
                else if (i <= 13 && i > 3)
                {
                    int nl = 0;
                    switch (DateTime.Now.Month + val)
                    {
                        case 0:
                            {
                                e.Column.Header = "Tháng 12";
                                nl = 1;
                                break;
                            }
                        case -1:
                            {
                                e.Column.Header = "Tháng 11";
                                nl = 1;
                                break;
                            }
                        case -2:
                            {
                                e.Column.Header = "Tháng 10";
                                nl = 1;
                                break;
                            }
                        case 13:
                            {
                                e.Column.Header = "Tháng 1";
                                nl = 1;
                                break;
                            }
                        case 14:
                            {
                                e.Column.Header = "Tháng 2";
                                nl = 1;
                                break;
                            }
                        case 15:
                            {
                                e.Column.Header = "Tháng 3";
                                nl = 1;
                                break;
                            }
                        case 16:
                            {
                                e.Column.Header = "Tháng 4";
                                nl = 1;
                                break;
                            }
                        case 17:
                            {
                                e.Column.Header = "Tháng 5";
                                nl = 1;
                                break;
                            }
                        case 18:
                            {
                                e.Column.Header = "Tháng 6";
                                nl = 1;
                                break;
                            }
                    }
                    if (nl == 0) e.Column.Header = "Tháng " + (DateTime.Now.Month + val).ToString();
                    val++;
                    i++;
                }
                else
                {
                    e.Column.Header = att.Name;
                    i++;
                }
            }

        }

        private void dgvFee_Loaded(object sender, RoutedEventArgs e)
        {
            CultureInfo ci = new CultureInfo("en-US");

            Dictionary<int, string> thang = new Dictionary<int, string>();
            thang.Add(1, "Tháng 1"); thang.Add(2, "Tháng 2"); thang.Add(3, "Tháng 3"); thang.Add(4, "Tháng 4"); thang.Add(5, "Tháng 5"); thang.Add(6, "Tháng 6");
            thang.Add(7, "Tháng 7"); thang.Add(8, "Tháng 8"); thang.Add(9, "Tháng 9"); thang.Add(10, "Tháng 10"); thang.Add(11, "Tháng 11"); thang.Add(12, "Tháng 12");
            int r = DateTime.Now.Month;
            switch (r)
            {
                case 1:
                    {
                        int j = 2;
                        int k = 1;
                        for (int i = 4; i < 14; i++)
                        {
                            if (j >= 0)
                            {
                                dgvFee2.Columns[i].Header = thang[12 - j];
                                j--;
                            }
                            else dgvFee2.Columns[i].Header = thang[k++];
                        }
                        break;
                    }
                case 2:
                    {
                        int j = 1;
                        int k = 1;
                        for (int i = 4; i < 14; i++)
                        {
                            if (j >= 0)
                            {
                                dgvFee2.Columns[i].Header = thang[12 - j];
                                j--;
                            }
                            else dgvFee2.Columns[i].Header = thang[k++];
                        }
                        break;
                    }
                case 3:
                    {
                        int j = 0;
                        int k = 1;
                        for (int i = 4; i < 14; i++)
                        {
                            if (j >= 0)
                            {
                                dgvFee2.Columns[i].Header = thang[12 - j];
                                j--;
                            }
                            else dgvFee2.Columns[i].Header = thang[k++];
                        }
                        break;
                    }
                case 4:
                    {
                        for (int i = 4; i < 14; i++)
                        {
                            dgvFee2.Columns[i].Header = thang[i];
                        }
                        break;
                    }
                case 5:
                    {
                        int k = 2;
                        for (int i = 4; i < 14; i++)
                        {
                            dgvFee2.Columns[i].Header = thang[k++];
                        }
                        break;
                    }
                case 6:
                    {
                        int k = 3;
                        for (int i = 4; i < 14; i++)
                        {
                            dgvFee2.Columns[i].Header = thang[k++];
                        }
                        break;
                    }
                case 7:
                    {
                        int k = 4;
                        for (int i = 4; i < 14; i++)
                        {
                            if (k <= 12) dgvFee2.Columns[i].Header = thang[k++];
                            else
                            {
                                dgvFee2.Columns[i].Header = thang[k - 12];
                                k++;
                            }
                        }
                        break;
                    }
                case 8:
                    {
                        int k = 5;
                        for (int i = 4; i < 14; i++)
                        {
                            if (k <= 12) dgvFee2.Columns[i].Header = thang[k++];
                            else
                            {
                                dgvFee2.Columns[i].Header = thang[k - 12];
                                k++;
                            }
                        }
                        break;
                    }
                case 9:
                    {
                        int k = 6;
                        for (int i = 4; i < 14; i++)
                        {
                            if (k <= 12) dgvFee2.Columns[i].Header = thang[k++];
                            else
                            {
                                dgvFee2.Columns[i].Header = thang[k - 12];
                                k++;
                            }
                        }
                        break;
                    }
                case 10:
                    {
                        int k = 7;
                        for (int i = 4; i < 14; i++)
                        {
                            if (k <= 12) dgvFee2.Columns[i].Header = thang[k++];
                            else
                            {
                                dgvFee2.Columns[i].Header = thang[k - 12];
                                k++;
                            }
                        }
                        break;
                    }
                case 11:
                    {
                        int k = 8;
                        for (int i = 4; i < 14; i++)
                        {
                            if (k <= 12) dgvFee2.Columns[i].Header = thang[k++];
                            else
                            {
                                dgvFee2.Columns[i].Header = thang[k - 12];
                                k++;
                            }
                        }
                        break;
                    }
                case 12:
                    {
                        int k = 9;
                        for (int i = 4; i < 14; i++)
                        {
                            if (k <= 12) dgvFee2.Columns[i].Header = thang[k++];
                            else
                            {
                                dgvFee2.Columns[i].Header = thang[k - 12];
                                k++;
                            }
                        }
                        break;
                    }
            }

            dgvFee2.Columns[14].Width = 112;
            dgvTotalC.Columns[11].Width = 150;
        }

        private void cmbClassName_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if ((int)cmbClassName.SelectedValue == 0)           //--Minh modified 5/8/2018
            {
                dgvFee2.ItemsSource = feeBLO.LoadFee(0);
                dgvFee1.ItemsSource = feeBLO.LoadFee1(0);
                dgvFee.ItemsSource = feeBLO.LoadFee(0);
            }
            dgvFee2.ItemsSource = feeBLO.LoadFee((int)cmbClassName.SelectedValue);
            dgvFee1.ItemsSource = feeBLO.LoadFee1((int)cmbClassName.SelectedValue);
            dgvTotalC.ItemsSource = feeBLO.LoadTotal(dgvFee2);
            dgvFee.ItemsSource = feeBLO.LoadFee((int)cmbClassName.SelectedValue);
            if (dgvFee1.Items.Count < 1) MessageBox.Show("Không có dữ liệu");
        }

        //private void dgvFee2_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        //{
        //    int index = dgvFee2.SelectedIndex;
        //    if (index % 2 == 0)
        //    {
        //        int kte = 0;
        //        foreach (var i in IDEdit)
        //        {
        //            if (index == i)
        //            {
        //                kte = 1;
        //                break;
        //            }
        //        }
        //        if (kte == 0) IDEdit.Add(index);

        //    }
        //    else
        //    {
        //        int kte = 0;
        //        foreach (var i in IDEditD)
        //        {
        //            if (index == i)
        //            {
        //                kte = 1;
        //                break;
        //            }
        //        }
        //        if (kte == 0) IDEditD.Add(index);
        //    }
        //}

        //private void dgvFee2_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        //{
        //    string err = "Lỗi: \n";
        //    try
        //    {
        //        if (IDEdit > -1)
        //        {
        //            var val = dgvFee2.Items[i] as dgvFee_ViewModel;

        //            editFee.ID_Learn = val.ID_Learn;
        //            //editFee.Month = 
        //            //editFee = dgvFee2.Items[i] as Fee;

        //            if (checkData(ref err) == true)
        //            {
        //                feeBLO.SaveFee(editFee);
        //                editFee = null;
        //                IDEdit = -1;
        //                try
        //                {
        //                    dgvFee2.ItemsSource = feeBLO.LoadFee((int)cmbClassName.SelectedValue);
        //                }
        //                catch
        //                {
        //                    dgvFee2.ItemsSource = feeBLO.LoadAllFee();
        //                }
        //                dgvTotalC.ItemsSource = feeBLO.LoadTotal(dgvFee2);
        //            }
        //            else MessageBox.Show(err);

        //        }
        //    }
        //    catch
        //    {

        //    }
        //}

        //private Boolean checkData(ref string mess)
        //{
        //    try
        //    {
        //        foreach (var item in editFee)
        //        {
        //            try
        //            {
        //                Double i = Double.Parse(item.lblmonthHT3A.ToString());
        //                if (i < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i1 = Double.Parse(item.lblmonthHT2A.ToString());
        //                if (i1 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i2 = Double.Parse(item.lblmonthHT1A.ToString());
        //                if (i2 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i3 = Double.Parse(item.lblmonthHT.ToString());
        //                if (i3 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i4 = Double.Parse(item.lblmonthHT1P.ToString());
        //                if (i4 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i5 = Double.Parse(item.lblmonthHT2P.ToString());
        //                if (i5 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i6 = Double.Parse(item.lblmonthHT3P.ToString());
        //                if (i6 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i7 = Double.Parse(item.lblmonthHT4P.ToString());
        //                if (i7 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i8 = Double.Parse(item.lblmonthHT5P.ToString());
        //                if (i8 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i9 = Double.Parse(item.lblmonthHT6P.ToString());
        //                if (i9 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                return true;
        //            }
        //            catch
        //            {
        //                mess = "- Phí phải nhập hoàn toàn số";
        //                return false;
        //            }

        //        }
        //        foreach (var item in editFeeD)
        //        {
        //            try
        //            {
        //                Double i = Double.Parse(item.lblmonthHT3A.ToString());
        //                if (i < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i1 = Double.Parse(item.lblmonthHT2A.ToString());
        //                if (i1 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i2 = Double.Parse(item.lblmonthHT1A.ToString());
        //                if (i2 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i3 = Double.Parse(item.lblmonthHT.ToString());
        //                if (i3 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i4 = Double.Parse(item.lblmonthHT1P.ToString());
        //                if (i4 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i5 = Double.Parse(item.lblmonthHT2P.ToString());
        //                if (i5 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i6 = Double.Parse(item.lblmonthHT3P.ToString());
        //                if (i6 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i7 = Double.Parse(item.lblmonthHT4P.ToString());
        //                if (i7 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i8 = Double.Parse(item.lblmonthHT5P.ToString());
        //                if (i8 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }
        //                Double i9 = Double.Parse(item.lblmonthHT6P.ToString());
        //                if (i9 < 0)
        //                {
        //                    mess = "- Phí phải lớn hơn 0";
        //                    return false;
        //                }                        
        //                return true;
        //            }
        //            catch
        //            {
        //                mess = "- Phí phải nhập hoàn toàn số";
        //                return false;
        //            }

        //        }
        //        return true;
        //    }
        //    catch
        //    {
        //        mess = "Lỗi";
        //        return false;
        //    }
        //}

        private void dgvFee2_LoadingRow(object sender, DataGridRowEventArgs e)
        {

        }

        private void dgvFee2_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            try
            {
                Fee_Model fee = new Fee_Model();
                var val = e.EditingElement as TextBox;
                var val1 = e.Column;
                var i = dgvFee2.Items[dgvFee2.SelectedIndex] as dgvFee_ViewModel;
                decimal phi = Decimal.Parse(val.Text.ToString());
                if (phi % 10000 != 0)
                {
                    MessageBox.Show("Phí phải là bội của 10,000.");
                }
                else
                {
                    int id = val1.DisplayIndex;
                    int r = DateTime.Now.Month;
                    fee.RegisterNumber = i.RegisterNumber;
                    fee.ID_Class = i.ID_Class;
                    fee.Fee_Value = Decimal.Parse(val.Text.ToString());
                    if (dgvFee2.SelectedIndex % 2 == 0) fee.Fee_Type = "Hội Phí";
                    else fee.Fee_Type = "Phí Khác";
                    switch (id)
                    {
                        case 4:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year - 1;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year - 1;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year - 1;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 5:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year - 1;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year - 1;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 6:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year - 1;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 7:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 8:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 9:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 10:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 11:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 12:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                }
                                break;
                            }
                        case 13:
                            {
                                switch (r)
                                {
                                    case 1:
                                        {
                                            fee.Month = 7;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 2:
                                        {
                                            fee.Month = 8;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 3:
                                        {
                                            fee.Month = 9;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 4:
                                        {
                                            fee.Month = 10;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 5:
                                        {
                                            fee.Month = 11;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 6:
                                        {
                                            fee.Month = 12;
                                            fee.Year = DateTime.Now.Year;
                                            break;
                                        }
                                    case 7:
                                        {
                                            fee.Month = 1;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 8:
                                        {
                                            fee.Month = 2;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 9:
                                        {
                                            fee.Month = 3;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 10:
                                        {
                                            fee.Month = 4;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 11:
                                        {
                                            fee.Month = 5;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                    case 12:
                                        {
                                            fee.Month = 6;
                                            fee.Year = DateTime.Now.Year + 1;
                                            break;
                                        }
                                }
                                break;
                            }
                    }
                    feeBLO.SaveFee(fee);
                    try
                    {
                        dgvFee2.ItemsSource = feeBLO.LoadFee((int)cmbClassName.SelectedValue);
                        dgvTotalC.ItemsSource= feeBLO.LoadTotal(dgvFee2);
                    }
                    catch
                    {
                        dgvFee2.ItemsSource = feeBLO.LoadFee(0);
                        dgvTotalC.ItemsSource = feeBLO.LoadTotal(dgvFee2);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Phí phải nhập hoàn toàn là số");
            }

        }


        private void dgvFee_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            for (int i = 0; i < dgvFee.Items.Count - 1; i++)
            {

            }
        }

        private void dgvFee2_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            try
            {
                ScrollViewer sv = null;
                Type t = dgvFee2.GetType();
                try
                {
                    sv = t.InvokeMember("InternalScrollHost", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty, null, dgvFee1, null) as ScrollViewer;
                    sv.ScrollToVerticalOffset(e.VerticalOffset / 2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch
            {

            }

        }

        private void dgvFee1_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            try
            {
                ScrollViewer sv = null;
                Type t = dgvFee1.GetType();
                try
                {
                    sv = t.InvokeMember("InternalScrollHost", BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.GetProperty, null, dgvFee2, null) as ScrollViewer;
                    sv.ScrollToVerticalOffset(e.VerticalOffset * 2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            catch
            {

            }

        }

        private void btnHelpI_Click(object sender, RoutedEventArgs e)
        {
            Support sp = new Support();
            sp.Show();
            this.Close();
        }
    }
}
