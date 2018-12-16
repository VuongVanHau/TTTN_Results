using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using System.Windows.Shapes;
using Aikido.BLO;
using Aikido.DAO.Model;
namespace Aikido.VIEW
{
    /// <summary>
    /// Interaction logic for ClassScreen.xaml
    /// </summary>
    public partial class ClassScreen : Window
    {
        ManageClass_BLO manageClass = new ManageClass_BLO();
        private Dictionary<int, dgvClass_ViewModel> dataEdit = new Dictionary<int, dgvClass_ViewModel>();
        private Dictionary<int, dgvClass_ViewModel> dataAdd = new Dictionary<int, dgvClass_ViewModel>();
        private List<int> IDdataEdit = new List<int>();
        private List<int> IDdataAdd = new List<int>();
        private bool kt = true;

        public ClassScreen()
        {
            InitializeComponent();

            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortTimePattern = "HH:mm";
            Thread.CurrentThread.CurrentCulture = ci;
            DataSet data = new DataSet();

            
            dgvClass.ItemsSource = manageClass.LoadClass();

            dgvClass.CanUserAddRows = true;

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
            //btnQLLb.Background = Brushes.DarkBlue;
            //btnQLL.Background = Brushes.LightGray;
        }

        private void btnQLL_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnQLLb.Background = Brushes.White;
            //btnQLL.Background = Brushes.White;
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
            //ClassScreen classScreen = new ClassScreen();
            //classScreen.Show();
            //this.Close();
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
        private void dgvClass_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var desc = e.PropertyDescriptor as PropertyDescriptor;
            var att = desc.Attributes[typeof(DAO.Model.ColumnNameAttribute)] as DAO.Model.ColumnNameAttribute;
            if (att != null)
            {
                e.Column.Header = att.Name;
            }
        }

        private void btnSaveC_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (var i in IDdataAdd)
                {
                    dataAdd.Add(i,dgvClass.Items[i] as DAO.Model.dgvClass_ViewModel);                    
                 }
                foreach (var i in IDdataEdit)
                {
                    dataEdit.Add(i,dgvClass.Items[i] as DAO.Model.dgvClass_ViewModel);
                }
                string message = null;
                if (dataAdd.Count > 0 || dataEdit.Count > 0)
                {
                    if (checkData(ref message) == true)
                    {
                        if (dataAdd.Count() > 0 || dataEdit.Count > 0) manageClass.SaveClass(dataAdd, dataEdit);
                        IDdataAdd.Clear(); dataAdd.Clear();
                         IDdataEdit.Clear(); dataEdit.Clear();

                        dgvClass.ItemsSource = manageClass.LoadClass();
                        dgvClass.Columns[3].Width = 235;
                        dgvClass.Columns[0].Visibility = Visibility.Hidden; 
                        dgvClass.Columns[2].Visibility = Visibility.Hidden;
                        MessageBox.Show("Lưu thành công");
                        IDdataAdd.Clear(); dataAdd.Clear();       //--Minh mođified 4/8/2018 (line 213 - 219)
                        IDdataEdit.Clear(); dataEdit.Clear();
                    }
                    else
                    {
                       dataAdd.Clear();      
                       dataEdit.Clear();
                        MessageBox.Show(message, "Lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                       
                    }
                }
                else
                {
                    MessageBox.Show("Dữ liệu không có gì thay đổi");
                }
            }
            catch 
            {
               
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var currentItem = dgvClass.SelectedItem as DAO.Model.dgvClass_ViewModel;
                if (MessageBox.Show($"Chắc xóa lớp {currentItem.txtName} không?", "Cảnh báo", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    //var id = dgvClass.Items[dgvClass.SelectedIndex] as DAO.Model.dgvClass_ViewModel;    //-Minh Modified 5/8/2018
                    if (dgvClass.SelectedIndex < dgvClass.Items.Count - 1 && currentItem.ID!=0|| (dgvClass.SelectedIndex == dgvClass.Items.Count - 1 && dgvClass.CanUserAddRows == false)&&currentItem.ID!=0)
                    {
                        manageClass.DeleteClass(currentItem.ID);
                        dgvClass.ItemsSource = manageClass.LoadClass();
                        dgvClass.Columns[3].Width = 235;
                        dgvClass.Columns[0].Visibility = Visibility.Hidden;
                        dgvClass.Columns[2].Visibility = Visibility.Hidden;
                    }
                    else 
                    {
                        // List<dgvClass_ViewModel>deleteEmpltyRow = new List<dgvClass_ViewModel>();
                        
                        //var selectedItem = dgvClass.SelectedItem;
                        //if (selectedItem != null)
                        //{
                        //    dgvClass.Items.Remove(selectedItem);
                        //}
                    }
                }
            }
            catch(Exception es)
            {
                MessageBox.Show("Chọn dòng muốn xóa"+es);
            }
            
        }

        public bool CheckTimeInput(string timein)
        {
            Regex objAlphaNumericPattern = new Regex("^(?:[0-9][0-9]):[0-9][0-9]$");
            return objAlphaNumericPattern.IsMatch(timein);
        }
        private Boolean checkData(ref string mess)
        {
            bool error = true;
            string err = null;
            bool markerror = true;
            int countnull=0;
            List<int> rejectAddlist = new List<int>();
            List<int> rejectEditlist = new List<int>();
            try
            {
                int line1 = 0;
                int line2 = 0;
                foreach (var currentItem in dataAdd)
                {
                    error = true; countnull = 0;
                    //-----Minh- fix bug  4/8/2018   (line 277 - 451 )
                    //if (currentItem.Value.txtName.Equals(null) == true || currentItem.Value.txtName.Equals("") == true || currentItem.Value.txtName.Equals(" ") )
                    if (String.IsNullOrWhiteSpace(currentItem.Value.txtName) == true) { err += " - Tên Lớp chưa được nhập\n"; error = false; countnull++; }
                    else if (CheckName(currentItem.Key, currentItem.Value.txtName) == false) { err += " - Tên Lớp Đã Tồn Tại\n"; error = false; }

                    if ( String.IsNullOrWhiteSpace(currentItem.Value.txtFinishTime) != true && String.IsNullOrWhiteSpace(currentItem.Value.txtStartTime) != true)
                    {
                        if (CheckTimeInput(currentItem.Value.txtFinishTime) == true && CheckTimeInput(currentItem.Value.txtStartTime) == true)
                        {
                            if (DateTime.Parse(currentItem.Value.txtStartTime).Hour > DateTime.Parse(currentItem.Value.txtFinishTime).Hour)
                            {
                                err += " - Giờ Bắt Đầu Phải Bé Hơn Giờ Kết Thúc\n"; error = false;
                            }
                            else if (DateTime.Parse(currentItem.Value.txtStartTime).Hour == DateTime.Parse(currentItem.Value.txtFinishTime).Hour)
                            {
                                if (DateTime.Parse(currentItem.Value.txtStartTime).Minute >= DateTime.Parse(currentItem.Value.txtFinishTime).Minute)
                                {
                                    err += " - Giờ Bắt Đầu Phải Bé Hơn Giờ Kết Thúc\n"; error = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(currentItem.Value.txtFinishTime) == true) { err += " - Giờ Kết Thúc chưa được nhập\n"; error = false; countnull++; }
                        else { 
                            if (CheckTimeInput(currentItem.Value.txtFinishTime) == false) { err += " - Giờ Kết Thúc Dạng HH:MM (HH >= 24 MM >=59)\n"; error = false; }
                            else 
                            {
                                try
                                {
                                    char[] ch = currentItem.Value.txtFinishTime.ToArray();
                                    string hh = null;
                                    string mm = null;
                                    for (int j = 0; j < 2; j++) { hh += ch[j]; }
                                    for (int j = 3; j < 5; j++) { mm += ch[j]; }
                                    int h = Int32.Parse(hh);
                                    int m = Int32.Parse(mm);
                                    if (h > 23) { err += " - Giờ thời gian kết thúc phải bé hơn 24\n"; error = false; }
                                    if (h > 59) { err += " = Phút thời gian kết thúc phải bé hơn 59\n"; error = false; }
                                }
                                catch
                                {

                                }
                            }
                        }
                        //----
                        if (String.IsNullOrWhiteSpace(currentItem.Value.txtStartTime) == true) { err += " - Giờ Bắt Đầu chưa được nhập\n"; error = false; countnull++; }
                        else
                        {
                            if (CheckTimeInput(currentItem.Value.txtStartTime) == false) { err += " - Giờ Bắt Đầu Dạng HH:MM (HH <= 24 MM <=59)\n"; error = false; }
                            else
                            {
                                try
                                {
                                    char[] ch = currentItem.Value.txtStartTime.ToArray();
                                    string hh = null;
                                    string mm = null;
                                    for (int j = 0; j < 2; j++) { hh += ch[j]; }
                                    for (int j = 3; j < 5; j++) { mm += mm[j]; }
                                    int h = Int32.Parse(hh);
                                    int m = Int32.Parse(mm);
                                    if (h > 23) { err += " - Giờ thời gian bắt đầu phải bé hơn 24\n"; error = false; }
                                    if (m > 59) { err += " - Phút thời gian bắt đầu phải bé hơn 59\n"; error = false; }
                                }
                                catch
                                {

                                }
                            }
                        }
                    }

                    if (currentItem.Value.cbMonday == false && currentItem.Value.cbTuesday == false
                            && currentItem.Value.cbWednesday == false && currentItem.Value.cbThursday == false
                            && currentItem.Value.cbFriday == false && currentItem.Value.cbSarturday == false
                            && currentItem.Value.cbSunday == false
                      )
                    {
                        err += " - Chọn ít nhất một ngày học trong tuần\n";
                        error = false;
                        countnull++;
                    }
                    line1++;
                    if (error == false)
                    {
                        var rowerr = dgvClass.ItemContainerGenerator.ContainerFromItem(currentItem.Value) as DataGridRow;
                        rowerr.BorderBrush = Brushes.Red;
                        rowerr.BorderThickness = new Thickness(0, 0, 6, 0);
                        markerror = false;
                        error = true;
                       if(countnull==4) IDdataAdd.Remove(currentItem.Key);
                    }
                }
                foreach (var currentItem in dataEdit)
                {
                    error = true;countnull = 0; 
                    if (currentItem.Value.txtName.Equals(null) == true || currentItem.Value.txtName.Equals("") == true) { err += " - Tên Lớp chưa được nhập\n"; error = false; countnull++; }
                    else if (kt == false) { err += " - Tên Lớp Đã Tồn Tại\n"; error = false; }
                    if (String.IsNullOrWhiteSpace(currentItem.Value.txtFinishTime) != true && String.IsNullOrWhiteSpace(currentItem.Value.txtStartTime) != true)
                    {
                        if (CheckTimeInput(currentItem.Value.txtFinishTime) == true && CheckTimeInput(currentItem.Value.txtStartTime) == true)
                        {
                            if (DateTime.Parse(currentItem.Value.txtStartTime).Hour > DateTime.Parse(currentItem.Value.txtFinishTime).Hour)
                            {
                                err += " - Giờ Bắt Đầu Phải Bé Hơn Giờ Kết Thúc\n"; error = false;
                            }
                            else if (DateTime.Parse(currentItem.Value.txtStartTime).Hour == DateTime.Parse(currentItem.Value.txtFinishTime).Hour)
                            {
                                if (DateTime.Parse(currentItem.Value.txtStartTime).Minute >= DateTime.Parse(currentItem.Value.txtFinishTime).Minute)
                                {
                                    err += " - Giờ Bắt Đầu Phải Bé Hơn Giờ Kết Thúc\n"; error = false;
                                }
                            }
                        }
                    }
                    else
                    {
                        if (String.IsNullOrWhiteSpace(currentItem.Value.txtFinishTime) == true) { err += " - Giờ Kết Thúc chưa được nhập\n"; error = false; countnull++; }
                        else
                        {
                            if (CheckTimeInput(currentItem.Value.txtFinishTime) == false) { err += " - Giờ Kết Thúc Dạng HH:MM (HH >= 24 MM >=59)\n"; error = false; }
                            else
                            {
                                try
                                {
                                    char[] ch = currentItem.Value.txtFinishTime.ToArray();
                                    string hh = null;
                                    string mm = null;
                                    for (int j = 0; j < 2; j++) { hh += ch[j]; }
                                    for (int j = 3; j < 5; j++) { mm += ch[j]; }
                                    int h = Int32.Parse(hh);
                                    int m = Int32.Parse(mm);
                                    if (h > 23) { err += " - Giờ thời gian kết thúc phải bé hơn 24\n"; error = false; }
                                    if (h > 59) { err += " = Phút thời gian kết thúc phải bé hơn 59\n"; error = false; }
                                }
                                catch
                                {

                                }
                            }
                        }
                        //----
                        if (String.IsNullOrWhiteSpace(currentItem.Value.txtStartTime) == true) { err += " - Giờ Bắt Đầu chưa được nhập\n"; error = false; countnull++; }
                        else
                        {
                            if (CheckTimeInput(currentItem.Value.txtStartTime) == false) { err += " - Giờ Bắt Đầu Dạng HH:MM (HH <= 24 MM <=59)\n"; error = false; }
                            else
                            {
                                try
                                {
                                    char[] ch = currentItem.Value.txtStartTime.ToArray();
                                    string hh = null;
                                    string mm = null;
                                    for (int j = 0; j < 2; j++) { hh += ch[j]; }
                                    for (int j = 3; j < 5; j++) { mm += mm[j]; }
                                    int h = Int32.Parse(hh);
                                    int m = Int32.Parse(mm);
                                    if (h > 23) { err += " - Giờ thời gian bắt đầu phải bé hơn 24\n"; error = false; }
                                    if (m > 59) { err += " - Phút thời gian bắt đầu phải bé hơn 59\n"; error = false; }
                                }
                                catch
                                {

                                }
                            }
                        }
                    }
                    if (currentItem.Value.cbMonday == false && currentItem.Value.cbTuesday == false
                            && currentItem.Value.cbWednesday == false && currentItem.Value.cbThursday == false
                            && currentItem.Value.cbFriday == false && currentItem.Value.cbSarturday == false
                            && currentItem.Value.cbSunday == false
                      )
                    {
                        err += " - Chọn ít nhất một ngày học trong tuần\n";countnull++;
                        error = false;
                    }
                    line2++;
                    if (error == false)     //   Modified - Minh 4/8/20118
                    {
                        var rowerr = dgvClass.ItemContainerGenerator.ContainerFromItem(currentItem.Value) as DataGridRow;
                        rowerr.BorderBrush = Brushes.Red;
                        rowerr.BorderThickness = new Thickness(0, 0, 6, 0);
                        markerror = false;
                        error = true;
                        if(countnull==4) IDdataEdit.Remove(currentItem.Key);             //--Note !!! Minh 4/8/2018
                    }
                    
                }
            }
            catch 
            {
                markerror = false;
               
            }
            mess = "Lỗi: \n" + err;
            return markerror;
        }

        private void dgvClass_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            try
            {
                var id = dgvClass.Items[dgvClass.SelectedIndex] as DAO.Model.dgvClass_ViewModel;
                //dgvClass.Items.Count - 2 == dgvClass.SelectedIndex &&
                if ( id.ID == 0)                                                        //Minh modified 4/8/2018 line 459
                {
                    int kt = 0;
                    foreach (var i in IDdataAdd)  //thêm bị trung
                    {
                        if (dgvClass.SelectedIndex == i)
                        {
                            kt = 1;
                            break;
                        }
                    }
                    if (kt == 0) IDdataAdd.Add(dgvClass.SelectedIndex);
                }
                else
                {
                    int kt = 0;
                    foreach (var i in IDdataAdd)
                    {
                        if (dgvClass.SelectedIndex == i)
                        {
                            kt = 1;
                            break;
                        }
                    }
                    if (kt == 0)
                    {
                        int kte = 0;
                        foreach (var i in IDdataEdit)
                        {
                            if (dgvClass.SelectedIndex == i)
                            {
                                kte = 1;
                                break;
                            }
                        }
                        if (kte == 0) IDdataEdit.Add(dgvClass.SelectedIndex);
                    }
                }
            }
            catch
            {

            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //dgvClass.CanUserAddRows = true;
            }
            catch
            {

            }

        }

        private void dgvClass_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                dgvClass.Columns[3].Width = 235;
                dgvClass.Columns[0].Visibility = Visibility.Hidden;
                dgvClass.Columns[2].Visibility = Visibility.Hidden;
            }
            catch
            {

            }
        }

        private void dgvClass_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Chuyển button delete theo đúng row đang chọn
            //btnDelete.Margin = new Thickness(735, 0, 0, 475 - 20 * dgvClass.SelectedIndex);
            //Chuyển button add khi chọn dòng cuối cùng

        }
        private bool CheckName(int id, string currentIndex)
        {
            try
            {
                for (int i = 0; i < dgvClass.Items.Count - 1; i++)
                {
                    var k = dgvClass.Items[i] as dgvClass_ViewModel;
                    if (k.txtName.Equals(currentIndex) == true && id != i) return false;
                }
                return true;
            }
            catch
            {
                return true;
            }
        }
        private void dgvClass_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            string err = "Lỗi: \n";
            var val = e.EditingElement as TextBox;
            var val1 = e.Column;
            var i = dgvClass.Items[dgvClass.SelectedIndex] as dgvClass_ViewModel;
            int col = val1.DisplayIndex;
            switch (col)
            {                     //Modified Minh 4/8/2018
                case 3:
                    {
                        kt = true;
                        if (val.Text.ToString().Equals(null) == true || val.Text.ToString().Equals("") == true || val.Text.ToString().Equals(" "))
                        {
                            err += " - Tên Lớp chưa được nhập\n"; kt = false;
                            e.Row.BorderBrush = Brushes.Red;
                            e.Row.BorderThickness = new Thickness(0, 0, 6, 0);
                            MessageBox.Show(err, "Lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        }
                        else if (CheckName(dgvClass.SelectedIndex,val.Text.ToString()) == false)
                        {
                                    err += " - Tên Lớp Đã Tồn Tại\n"; kt = false;
                            val.Text = ""; 
                            e.Row.BorderBrush = Brushes.Red;
                            e.Row.BorderThickness = new Thickness(0, 0, 6, 0);
                             MessageBox.Show(err, "Lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                   
                            kt = true;
                        }

                        break;
                    }
                case 4:
                    {
                        if (val.Text.ToString().Equals(null) == true || val.Text.ToString().Equals("") == true || val.Text.ToString().Equals(" "))
                        {
                            err += " - Giờ Bắt Đầu chưa được nhập\n";
                            e.Row.BorderBrush = Brushes.Red;
                            e.Row.BorderThickness = new Thickness(0, 0, 6, 0);
                            MessageBox.Show(err, "Lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        }
                        else if (CheckTimeInput(val.Text.ToString()) == true)
                        {
                            bool b = true;
                            try
                            {
                                char[] ch = val.Text.ToArray();
                                string hh = null;
                                string mm = null;
                                for (int j = 0; j < 2; j++)
                                {
                                    hh += ch[j];
                                }
                                for (int j = 3; j < 5; j++)
                                {
                                    mm += ch[j];
                                }
                                int h = Int32.Parse(hh);
                                int m = Int32.Parse(mm);
                                if (h > 23)
                                {
                                    err += " - Giờ thời gian bắt đầu phải bé hơn 24\n";
                                    b = false;
                                }
                                if (m > 59)
                                {
                                    err += " - Phút thời gian bắt đầuphải bé hơn 59\n";
                                    b = false;
                                }

                                if (b == false) { MessageBox.Show(err, "Lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error); e.Row.BorderBrush = Brushes.Red;
                                    e.Row.BorderThickness = new Thickness(0, 0, 6, 0);
                                }
                             }
                            catch
                            {

                            }
                        }
                        else
                        {
                            err += " - Giờ Bắt Đầu Dạng HH:MM\n";
                            e.Row.BorderBrush = Brushes.Red;
                            e.Row.BorderThickness = new Thickness(0, 0, 6, 0);
                            MessageBox.Show(err, "Lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        }
                        break;
                    }
                case 5:
                    {
                        if (val.Text.ToString().Equals(null) == true || val.Text.ToString().Equals("") == true || val.Text.ToString().Equals(" "))
                        {
                            err += " - Giờ Kết Thúc chưa được nhập\n";
                            e.Row.BorderBrush = Brushes.Red;
                            e.Row.BorderThickness = new Thickness(0, 0, 6, 0);
                            MessageBox.Show(err, "Lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        }
                        else if (CheckTimeInput(val.Text.ToString()) == true)
                        {
                            bool b = true;
                            try
                            {
                                char[] ch = val.Text.ToArray();
                                string hh = null;
                                string mm = null;
                                for (int j = 0; j < 2; j++)
                                {
                                    hh += ch[j];
                                }
                                for (int j = 3; j < 5; j++)
                                {
                                    mm += ch[j];
                                }
                                int h = Int32.Parse(hh);
                                int m = Int32.Parse(mm);
                                if (h > 23)
                                {
                                    err += " - Giờ thời gian kết thúc phải bé hơn 24\n";
                                    b = false;
                                }
                                if (m > 59)
                                {
                                    err += " - Phút thời gian kết thúc phải bé hơn 59\n";
                                    b = false;
                                }

                                if (b == false) {
                                    MessageBox.Show(err, "Lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error);     e.Row.BorderBrush = Brushes.Red;
                                    e.Row.BorderThickness = new Thickness(0, 0, 6, 0);
                                };
                               

                            }
                            catch
                            {

                            }
                        }
                        else
                        {
                            err += " - Giờ Kết Thúc Dạng HH:MM\n";
                            e.Row.BorderBrush = Brushes.Red;
                            e.Row.BorderThickness = new Thickness(0, 0, 6, 0);
                            MessageBox.Show(err, "Lỗi", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                        }
                        break;
                    }
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
