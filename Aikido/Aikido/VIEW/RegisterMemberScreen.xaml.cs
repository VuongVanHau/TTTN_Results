using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Aikido.DAO;
using Aikido.BLO;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Threading;
using Aikido.DAO.Model;

namespace Aikido.VIEW
{
    ///
    public partial class RegisterMemberScreen : Window
    {
        RegisterMember_BLO db = new RegisterMember_BLO();
        ManageClass_BLO ClassDB = new ManageClass_BLO();
        private Brush brush;
        private byte[] arrImage = null;
        int i = 0;
        bool changevalue = false , changevalueRegisterNumber=false;
 
        //Constructor
        public RegisterMemberScreen()
        {
            InitializeComponent();

            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = ci;

            BrushConverter bc = new BrushConverter();
            brush = (Brush)bc.ConvertFrom("#E5E1E1");
            brush.Freeze();

            //txtRegisterNumber.Text = ("0000"+NewRegisterNumber).ToString();
            txtRegisterNumber.Background = Brushes.WhiteSmoke;

            //Load Class in Combobox
            List<Class> showCombobox = ClassDB.ComboxClass1();
            cboRegisterClass.ItemsSource = showCombobox;
            cboRegisterClass.DisplayMemberPath = "Class_Name";
            cboRegisterClass.SelectedValuePath = "ID_Class";

            //Load Register Day
            dtpRegisterDay.SelectedDate = DateTime.Now;
            changevalue = false;

        }
        public RegisterMemberScreen(Search_Model search_Model)
        {
            InitializeComponent();
            CultureInfo ci = CultureInfo.CreateSpecificCulture(CultureInfo.CurrentCulture.Name);
            ci.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            Thread.CurrentThread.CurrentCulture = ci;

            
            List<Class> showCombobox = ClassDB.ComboxClass2(true);
            cboRegisterClass.ItemsSource = showCombobox;
            cboRegisterClass.DisplayMemberPath = "Class_Name";
            cboRegisterClass.SelectedValuePath = "ID_Class";

            Set_DBVIew(search_Model);
            changevalue = false;
        }

        // Handle register member
        private void Save_Click(object sender, RoutedEventArgs e)
        {

            if (Check_DataBase() == true)
            {
                save_Method();
                SetEmplty();
            }
            else return;

        }
        private void save_Method()
        {
            DateTime Day_Create = DateTime.Now;
            MemberInfo_ViewModel info = new MemberInfo_ViewModel();
            Fee_Model fee = new Fee_Model();
            info = getDB_FromForm();

            fee.RegisterNumber = info.RegisterNumber;
            fee.Day_Create = DateTime.Now;
            fee.Delete_Flag = false;
            fee.Fee_Type = "Hội Phí";
            fee.Fee_Value = 0;
            fee.ID_Class = info.ID_Class;
            fee.Month = DateTime.Now.Month;
            fee.Year = DateTime.Now.Year;

            if (txtRegisterNumber.Text.Equals(""))
            {
                try
                {
                    db.RegisterNewMember(info,fee, Day_Create);
                }
                catch (Exception r)
                {
                    MessageBox.Show("Lưu không thành công" + r, "Lỗi"); return;
                }
                
            }
            else
            {
                try
                {
                    db.EditMember_Info(info, Day_Create);
                }
                catch (Exception r)
                {
                    MessageBox.Show("Lưu không thành công" + r, "Lỗi"); return;
                }
            }
            MessageBox.Show("Lưu Thành Công");
        }

        //Print

        private void Print_MouseEnter(object sender, RoutedEventArgs e)
        {
            if (changevalue == true) //Case: change db
            {
                if (MessageBox.Show("Lưu thông tin để in ?", "Xác Nhận", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    if (Check_DataBase() == true)
                    {
                        save_Method();
                        DoPrint();
                        changevalue = false;
                    }
                }
                else
                {
                    return;
                }

            }
            else   //Case: View -> print
            {
                if (Check_DataBase() == true)
                {
                    DoPrint();

                }
            }
        }
        private void DoPrint()
        {
            ExportWord exportWord = new ExportWord();

            MemberInfo_ViewModel info = getDB_FromForm();
            SettingImage_BLO settingImage_BLO = new SettingImage_BLO();
            try
            {
                exportWord.CreateDocument(info, settingImage_BLO.getBackGround(), ref i);
            }
            catch { MessageBox.Show("Đóng các file word không sử dụng trước khi in file mới"); return; }
            if (changevalueRegisterNumber == true) { SetEmplty(); changevalueRegisterNumber = false; }
        }

        //Check validation
        private Boolean Check_DataBase()
        {
             
            try
            {
                RegisterMember_BLO member_BLO = new RegisterMember_BLO();
                string err = null;
                int error = 0;
                Set_BoderError();
                if (String.IsNullOrWhiteSpace(txtSKU.Text)==true ) { err += "SKU chưa được nhập " + "\n"; error = 1; txtSKU.BorderBrush = Brushes.Red; }
                if (String.IsNullOrWhiteSpace(txtName.Text)==true) { err += "Họ Tên chưa được nhập" + "\n"; error = 1; txtName.BorderBrush = Brushes.Red; }
                if (String.IsNullOrWhiteSpace(txtAddress.Text)==true) { err += "Địa chỉ chưa được nhập" + "\n"; error = 1; txtAddress.BorderBrush = Brushes.Red; }
                if (String.IsNullOrWhiteSpace(txtPhone.Text)==true) { err += "Số Điện Thoại chưa được nhập" + "\n"; error = 1; txtPhone.BorderBrush = Brushes.Red; }
                if (String.IsNullOrWhiteSpace(txtNation.Text) == true) { err += "Quốc tịch chưa được nhập" + "\n"; error = 1; txtNation.BorderBrush = Brushes.Red; }
                if (dtpRegisterDay.SelectedDate == null) { err += "Ngày Đăng Ký chưa được nhập" + "\n"; error = 1; dtpRegisterDay.BorderBrush = Brushes.Red; }
                if (dtpBirthday.SelectedDate == null) { err += "Ngày Sinh chưa được nhập" + "\n"; error = 1; dtpBirthday.BorderBrush = Brushes.Red; }
                if (dtpRegisterDay.SelectedDate != null && dtpBirthday.SelectedDate != null && dtpRegisterDay.SelectedDate<= dtpBirthday.SelectedDate) { err += "Ngày Sinh phải trước ngày đăng ký" + "\n"; error = 1; dtpBirthday.BorderBrush = Brushes.Red; dtpRegisterDay.BorderBrush = Brushes.Red; }
                if (String.IsNullOrWhiteSpace(txtBirthplace.Text)==true) { err += "Nơi sinh chưa được nhập" + "\n"; error = 1; txtBirthplace.BorderBrush = Brushes.Red; }
                if (cboRegisterClass.SelectedValue == null) { err += "Lớp Đăng Ký chưa được nhập" + "\n"; error = 1;  cboRegisterClass.BorderBrush = Brushes.Red; }
                if (txtSKU.Text.Length > 20) { err += "SKU nhỏ hơn 20 ký tự\n"; error = 1; txtSKU.BorderBrush = Brushes.Red; }
                if (txtRegisterNumber.Text.Equals("")) 
                {
                    if (member_BLO.Check_UniqueSKU(txtSKU.Text,-1)==false)// TH check sku when adding
                    {
                        err += "SKU đã tồn tại\n"; error = 1;
                        txtSKU.BorderBrush = Brushes.Red;
                    }
                }
                else
                {
                    if (member_BLO.Check_UniqueSKU(txtSKU.Text, int.Parse(txtRegisterNumber.Text)) == false) // TH check sku when editing 
                    {
                        err += "SKU đã tồn tại\n"; error = 1;
                        txtSKU.BorderBrush = Brushes.Red;
                    }
                }
                if (txtName.Text.Length > 50) { err += "Họ Tên quá dài\n"; error = 1; txtName.BorderBrush = Brushes.Red; }
                if (txtNation.Text.Length > 50) { err += "Quốc Tịch quá dài\n"; error = 1; txtNation.BorderBrush = Brushes.Red; }
                if (txtAddress.Text.Length > 100) { err += "Địa chỉ quá dài\n"; error = 1; txtAddress.BorderBrush = Brushes.Red; }
                if (txtBirthplace.Text.Length > 50) { err += "Nơi sinh quá dài\n"; error = 1; txtBirthplace.BorderBrush = Brushes.Red; }
                if (dtpBirthday.SelectedDate > DateTime.Now) { err += "Ngày sinh phải nhỏ hơn hiện tại\n"; error = 1; dtpBirthday.BorderBrush = Brushes.Red; }

                if (dtpLevel6.SelectedDate > dtpLevel5.SelectedDate || ((dtpLevel5.SelectedDate != null) && dtpLevel6.SelectedDate == null)) { err += messageCheckDateCap(6, 5); error = 1; dtpLevel6.BorderBrush = Brushes.Red; dtpLevel5.BorderBrush = Brushes.Red; }
                if (dtpLevel5.SelectedDate > dtpLevel4.SelectedDate || ((dtpLevel4.SelectedDate != null) && dtpLevel5.SelectedDate == null)) { err += messageCheckDateCap(5, 4); error = 1; dtpLevel5.BorderBrush = Brushes.Red; dtpLevel4.BorderBrush = Brushes.Red; }
                if (dtpLevel4.SelectedDate > dtpLevel3.SelectedDate || ((dtpLevel3.SelectedDate != null) && dtpLevel4.SelectedDate == null)) { err += messageCheckDateCap(4, 3); error = 1; dtpLevel4.BorderBrush = Brushes.Red; dtpLevel3.BorderBrush = Brushes.Red; }
                if (dtpLevel3.SelectedDate > dtpLevel2.SelectedDate || ((dtpLevel2.SelectedDate != null) && dtpLevel3.SelectedDate == null)) { err += messageCheckDateCap(3, 2); error = 1; dtpLevel3.BorderBrush = Brushes.Red; dtpLevel2.BorderBrush = Brushes.Red; }
                if (dtpLevel2.SelectedDate > dtpLevel1.SelectedDate || ((dtpLevel1.SelectedDate != null) && dtpLevel2.SelectedDate == null)) { err += messageCheckDateCap(2, 1); error = 1; dtpLevel2.BorderBrush = Brushes.Red; dtpLevel1.BorderBrush = Brushes.Red; }
                if (dtpDanVN1.SelectedDate < dtpLevel1.SelectedDate || ((dtpDanVN1.SelectedDate != null) && dtpLevel1.SelectedDate == null)) { err += "Ngày cấp Cấp 1 phải trước ngày cấp DAIVNI\n"; error = 1; dtpDanVN1.BorderBrush = Brushes.Red; dtpLevel1.BorderBrush = Brushes.Red;}
                if (dtpDanAIKIKAI1.SelectedDate < dtpLevel1.SelectedDate || ((dtpDanAIKIKAI1.SelectedDate != null) && dtpLevel1.SelectedDate == null)) { err += "Ngày cấp Cấp 1 phải trước ngày cấp DAIAIKIKAI\n"; error = 1; dtpDanAIKIKAI1.BorderBrush = Brushes.Red; dtpLevel1.BorderBrush = Brushes.Red; }
                if (dtpDanVN1.SelectedDate > dtpDanVN2.SelectedDate || ((dtpDanVN2.SelectedDate != null) && dtpDanVN1.SelectedDate == null)) { err += messageCheckDateDANVN(1, 2); error = 1; dtpDanVN1.BorderBrush = Brushes.Red; dtpDanVN2.BorderBrush = Brushes.Red; }
                if (dtpDanVN2.SelectedDate > dtpDanVN3.SelectedDate || ((dtpDanVN3.SelectedDate != null) && dtpDanVN2.SelectedDate == null)) { err += messageCheckDateDANVN(2, 3); error = 1; dtpDanVN2.BorderBrush = Brushes.Red; dtpDanVN3.BorderBrush = Brushes.Red; }
                if (dtpDanVN3.SelectedDate > dtpDanVN4.SelectedDate || ((dtpDanVN4.SelectedDate != null) && dtpDanVN3.SelectedDate == null)) { err += messageCheckDateDANVN(3, 4); error = 1; dtpDanVN3.BorderBrush = Brushes.Red; dtpDanVN4.BorderBrush = Brushes.Red; }
                if (dtpDanVN4.SelectedDate > dtpDanVN5.SelectedDate || ((dtpDanVN5.SelectedDate != null) && dtpDanVN4.SelectedDate == null)) { err += messageCheckDateDANVN(4, 5); error = 1; dtpDanVN4.BorderBrush = Brushes.Red; dtpDanVN5.BorderBrush = Brushes.Red; }
                if (dtpDanVN5.SelectedDate > dtpDanVN6.SelectedDate || ((dtpDanVN6.SelectedDate != null) && dtpDanVN5.SelectedDate == null)) { err += messageCheckDateDANVN(5, 6); error = 1; dtpDanVN5.BorderBrush = Brushes.Red; dtpDanVN6.BorderBrush = Brushes.Red; }
                if (dtpDanVN6.SelectedDate > dtpDanVN7.SelectedDate || ((dtpDanVN7.SelectedDate != null) && dtpDanVN6.SelectedDate == null)) { err += messageCheckDateDANVN(5, 6); error = 1; dtpDanVN6.BorderBrush = Brushes.Red; dtpDanVN7.BorderBrush = Brushes.Red; }
                if (dtpDanVN7.SelectedDate > dtpDanVN8.SelectedDate || ((dtpDanVN8.SelectedDate != null) && dtpDanVN7.SelectedDate == null)) { err += messageCheckDateDANVN(5, 6); error = 1; dtpDanVN7.BorderBrush = Brushes.Red; dtpDanVN8.BorderBrush = Brushes.Red; }

                if (dtpDanAIKIKAI1.SelectedDate > dtpDanAIKIKAI2.SelectedDate || ((dtpDanAIKIKAI2.SelectedDate != null) && dtpDanAIKIKAI1.SelectedDate == null)) { err += messageCheckDateDANAIKIKAI(1, 2); error = 1; dtpDanAIKIKAI1.BorderBrush = Brushes.Red; dtpDanAIKIKAI2.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI2.SelectedDate > dtpDanAIKIKAI3.SelectedDate || ((dtpDanAIKIKAI3.SelectedDate != null) && dtpDanAIKIKAI2.SelectedDate == null)) { err += messageCheckDateDANAIKIKAI(2, 3); error = 1; dtpDanAIKIKAI2.BorderBrush = Brushes.Red; dtpDanAIKIKAI3.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI3.SelectedDate > dtpDanAIKIKAI4.SelectedDate || ((dtpDanAIKIKAI4.SelectedDate != null) && dtpDanAIKIKAI3.SelectedDate == null)) { err += messageCheckDateDANAIKIKAI(3, 4); error = 1; dtpDanAIKIKAI3.BorderBrush = Brushes.Red; dtpDanAIKIKAI4.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI4.SelectedDate > dtpDanAIKIKAI5.SelectedDate || ((dtpDanAIKIKAI5.SelectedDate != null) && dtpDanAIKIKAI4.SelectedDate == null)) { err += messageCheckDateDANAIKIKAI(4, 5); error = 1; dtpDanAIKIKAI4.BorderBrush = Brushes.Red; dtpDanAIKIKAI5.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI5.SelectedDate > dtpDanAIKIKAI6.SelectedDate || ((dtpDanAIKIKAI6.SelectedDate != null) && dtpDanAIKIKAI5.SelectedDate == null)) { err += messageCheckDateDANAIKIKAI(5, 6); error = 1; dtpDanAIKIKAI5.BorderBrush = Brushes.Red; dtpDanAIKIKAI6.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI6.SelectedDate > dtpDanAIKIKAI7.SelectedDate || ((dtpDanAIKIKAI7.SelectedDate != null) && dtpDanAIKIKAI6.SelectedDate == null)) { err += messageCheckDateDANAIKIKAI(6, 7); error = 1; dtpDanAIKIKAI6.BorderBrush = Brushes.Red; dtpDanAIKIKAI7.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI7.SelectedDate > dtpDanAIKIKAI8.SelectedDate || ((dtpDanAIKIKAI8.SelectedDate != null) && dtpDanAIKIKAI7.SelectedDate == null)) { err += messageCheckDateDANAIKIKAI(7, 8); error = 1; dtpDanAIKIKAI7.BorderBrush = Brushes.Red; dtpDanAIKIKAI8.BorderBrush = Brushes.Red; }

                //--
                if (dtpLevel6.SelectedDate > DateTime.Now) { err += "Ngày cấp Cấp 6 không thể lớn hơn thời điểm hiện tại\n"; error = 1;    dtpLevel6.BorderBrush = Brushes.Red;   }
                if (dtpLevel5.SelectedDate > DateTime.Now) { err += "Ngày cấp Cấp 5 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpLevel5.BorderBrush = Brushes.Red; }
                if (dtpLevel4.SelectedDate > DateTime.Now) { err += "Ngày cấp Cấp 4 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpLevel4.BorderBrush = Brushes.Red; }
                if (dtpLevel3.SelectedDate > DateTime.Now) { err += "Ngày cấp Cấp 3 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpLevel3.BorderBrush = Brushes.Red; }
                if (dtpLevel2.SelectedDate > DateTime.Now) { err += "Ngày cấp Cấp 2 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpLevel2.BorderBrush = Brushes.Red; }
                if (dtpLevel1.SelectedDate > DateTime.Now) { err += "Ngày cấp Cấp 1 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpLevel1.BorderBrush = Brushes.Red; }

                if (dtpDanVN1.SelectedDate > DateTime.Now) { err += "Ngày cấp DanVN1 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanVN1.BorderBrush = Brushes.Red; }
                if (dtpDanVN2.SelectedDate > DateTime.Now) { err += "Ngày cấp DanVN2 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanVN2.BorderBrush = Brushes.Red; }
                if (dtpDanVN3.SelectedDate > DateTime.Now) { err += "Ngày cấp DanVN3 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanVN3.BorderBrush = Brushes.Red; }
                if (dtpDanVN4.SelectedDate > DateTime.Now) { err += "Ngày cấp DanVN4 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanVN4.BorderBrush = Brushes.Red; }
                if (dtpDanVN5.SelectedDate > DateTime.Now) { err += "Ngày cấp DanVN5 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanVN5.BorderBrush = Brushes.Red; }
                if (dtpDanVN6.SelectedDate > DateTime.Now) { err += "Ngày cấp DanVN6 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanVN6.BorderBrush = Brushes.Red; }
                if (dtpDanVN7.SelectedDate > DateTime.Now) { err += "Ngày cấp DanVN7 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanVN7.BorderBrush = Brushes.Red; }
                if (dtpDanVN8.SelectedDate > DateTime.Now) { err += "Ngày cấp DanVN8 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanVN8.BorderBrush = Brushes.Red; }

                if (dtpDanAIKIKAI1.SelectedDate > DateTime.Now) { err += "Ngày cấp DanAIKIKAI1 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanAIKIKAI1.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI2.SelectedDate > DateTime.Now) { err += "Ngày cấp DanAIKIKAI2 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanAIKIKAI2.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI3.SelectedDate > DateTime.Now) { err += "Ngày cấp DanAIKIKAI3 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanAIKIKAI3.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI4.SelectedDate > DateTime.Now) { err += "Ngày cấp DanAIKIKAI4 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanAIKIKAI4.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI5.SelectedDate > DateTime.Now) { err += "Ngày cấp DanAIKIKAI5 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanAIKIKAI5.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI6.SelectedDate > DateTime.Now) { err += "Ngày cấp DanAIKIKAI6 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanAIKIKAI6.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI7.SelectedDate > DateTime.Now) { err += "Ngày cấp DanAIKIKAI7 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanAIKIKAI7.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI8.SelectedDate > DateTime.Now) { err += "Ngày cấp DanAIKIKAI8 không thể lớn hơn thời điểm hiện tại\n"; error = 1; dtpDanAIKIKAI8.BorderBrush = Brushes.Red; }
                if (!Regex.IsMatch(txtPhone.Text, @"^\+?\d{9,13}\s?$")) { err += "Số Điện Thoại không hợp lệ\n"; error = 1; txtPhone.BorderBrush = Brushes.Red; }

                if (dtpLevel6.SelectedDate <= dtpBirthday.SelectedDate) { err += "Ngày cấp Cấp 6 phải sau ngày sinh\n"; error = 1; dtpLevel6.BorderBrush = Brushes.Red; }
                if (dtpLevel5.SelectedDate <= dtpBirthday.SelectedDate) { err += "Ngày cấp Cấp 5 phải sau ngày sinh\n"; error = 1; dtpLevel5.BorderBrush = Brushes.Red; }
                if (dtpLevel4.SelectedDate <= dtpBirthday.SelectedDate ) { err += "Ngày cấp Cấp 4 phải sau ngày sinh\n"; error = 1; dtpLevel4.BorderBrush = Brushes.Red; }
                if (dtpLevel3.SelectedDate <= dtpBirthday.SelectedDate ) { err += "Ngày cấp Cấp 3 phải sau ngày sinh\n"; error = 1; dtpLevel3.BorderBrush = Brushes.Red; }
                if (dtpLevel2.SelectedDate <= dtpBirthday.SelectedDate ) { err += "Ngày cấp Cấp 2 phải sau ngày sinh\n"; error = 1; dtpLevel2.BorderBrush = Brushes.Red; }
                if (dtpLevel1.SelectedDate <= dtpBirthday.SelectedDate ) { err += "Ngày cấp Cấp 1 phải sau ngày sinh\n"; error = 1; dtpLevel1.BorderBrush = Brushes.Red; }

                if (dtpDanVN1.SelectedDate <= dtpBirthday.SelectedDate ) { err += "Ngày cấp DanVN1 phải sau ngày sinh\n"; error = 1; dtpDanVN1.BorderBrush = Brushes.Red; }
                if (dtpDanVN2.SelectedDate <= dtpBirthday.SelectedDate ) { err += "Ngày cấp DanVN2 phải sau ngày sinh\n"; error = 1; dtpDanVN2.BorderBrush = Brushes.Red; }
                if (dtpDanVN3.SelectedDate <= dtpBirthday.SelectedDate ) { err += "Ngày cấp DanVN3 phải sau ngày sinh\n"; error = 1; dtpDanVN3.BorderBrush = Brushes.Red; }
                if (dtpDanVN4.SelectedDate <= dtpBirthday.SelectedDate ) { err += "Ngày cấp DanVN4 phải sau ngày sinh\n"; error = 1; dtpDanVN4.BorderBrush = Brushes.Red; }
                if (dtpDanVN5.SelectedDate <= dtpBirthday.SelectedDate ) { err += "Ngày cấp DanVN5 phải sau ngày sinh\n"; error = 1; dtpDanVN5.BorderBrush = Brushes.Red; }
                if (dtpDanVN6.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanVN6 phải sau ngày sinh\n"; error = 1; dtpDanVN6.BorderBrush = Brushes.Red; }
                if (dtpDanVN7.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanVN7 phải sau ngày sinh\n"; error = 1; dtpDanVN7.BorderBrush = Brushes.Red; }
                if (dtpDanVN8.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanVN8 phải sau ngày sinh\n"; error = 1; dtpDanVN8.BorderBrush = Brushes.Red; }

                if (dtpDanAIKIKAI1.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanAIKIKAI1 phải sau ngày sinh\n"; error = 1; dtpDanAIKIKAI1.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI2.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanAIKIKAI2 phải sau ngày sinh\n"; error = 1; dtpDanAIKIKAI2.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI3.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanAIKIKAI3 phải sau ngày sinh\n"; error = 1; dtpDanAIKIKAI3.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI4.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanAIKIKAI4 phải sau ngày sinh\n"; error = 1; dtpDanAIKIKAI4.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI5.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanAIKIKAI5 phải sau ngày sinh\n"; error = 1; dtpDanAIKIKAI5.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI6.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanAIKIKAI6 phải sau ngày sinh\n"; error = 1; dtpDanAIKIKAI6.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI7.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanAIKIKAI7 phải sau ngày sinh\n"; error = 1; dtpDanAIKIKAI7.BorderBrush = Brushes.Red; }
                if (dtpDanAIKIKAI8.SelectedDate <= DateTime.Now) { err += "Ngày cấp DanAIKIKAI8 phải sau ngày sinh\n"; error = 1; dtpDanAIKIKAI8.BorderBrush = Brushes.Red; }
               
                if (error==1)
                {
                    MessageBox.Show(err, "Lỗi");
                    return false;
                }
               
                
                return true;
            }
            catch(Exception e)
            {
                MessageBox.Show(" Lỗi nhập thông tin "+e);
                return false;
            }
        }

        private void Set_DBVIew(Search_Model search_Model)
        {
     
            txtSKU.Text = search_Model.SKU.ToString();
            txtRegisterNumber.Text = search_Model.RegisterNumber.ToString();
            txtName.Text = search_Model.FullName.ToString();
            txtNation.Text = search_Model.Nation.ToString();
            txtAddress.Text = search_Model.Address.ToString();
            txtPhone.Text = search_Model.PhoneNumber.ToString();
            dtpBirthday.Text = search_Model.Day_of_Birth.ToString();
            dtpRegisterDay.Text = search_Model.Day_Create.ToString();
            txtBirthplace.Text = search_Model.Place_of_birth.ToString();
            cboRegisterClass.Text = search_Model.Class_Name.ToString();
            cboRegisterClass.SelectedValue = search_Model.class_ID;

            arrImage = search_Model.Image;
            SettingImage_BLO settingImage_BLO = new SettingImage_BLO();
            try
            {
                ImageBrush image  = new ImageBrush();
                image.ImageSource =settingImage_BLO.ConvertByte_ToImage(arrImage);
                if (image == null) return;  // Case: Open Dialog but not choose image
                ImageButton.Background = image;
            }
            catch { MessageBox.Show("Ảnh không hợp lệ", "Lỗi"); }

            dtpLevel6.Text = search_Model.DAI_Cap_6.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAI_Cap_6.ToString();
            dtpLevel5.Text = search_Model.DAI_Cap_5.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAI_Cap_5.ToString();
            dtpLevel4.Text = search_Model.DAI_Cap_4.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAI_Cap_4.ToString();
            dtpLevel3.Text = search_Model.DAI_Cap_3.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAI_Cap_3.ToString();
            dtpLevel2.Text = search_Model.DAI_Cap_2.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAI_Cap_2.ToString();
            dtpLevel1.Text = search_Model.DAI_Cap_1.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAI_Cap_1.ToString();

            dtpDanVN1.Text = search_Model.DAN_VN_1.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_VN_1.ToString();
            dtpDanVN2.Text = search_Model.DAN_VN_2.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_VN_2.ToString();
            dtpDanVN3.Text = search_Model.DAN_VN_3.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_VN_3.ToString();
            dtpDanVN4.Text = search_Model.DAN_VN_4.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_VN_4.ToString();
            dtpDanVN5.Text = search_Model.DAN_VN_5.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_VN_5.ToString();
            dtpDanVN6.Text = search_Model.DAN_VN_6.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_VN_6.ToString();
            dtpDanVN7.Text = search_Model.DAN_VN_7.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_VN_7.ToString();
            dtpDanVN8.Text = search_Model.DAN_VN_8.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_VN_8.ToString();


            dtpDanAIKIKAI1.Text = search_Model.DAN_AIKIKAI_1.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_AIKIKAI_1.ToString();
            dtpDanAIKIKAI2.Text = search_Model.DAN_AIKIKAI_2.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_AIKIKAI_2.ToString();
            dtpDanAIKIKAI3.Text = search_Model.DAN_AIKIKAI_3.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_AIKIKAI_3.ToString();
            dtpDanAIKIKAI4.Text = search_Model.DAN_AIKIKAI_4.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_AIKIKAI_4.ToString();
            dtpDanAIKIKAI5.Text = search_Model.DAN_AIKIKAI_5.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_AIKIKAI_5.ToString();
            dtpDanAIKIKAI6.Text = search_Model.DAN_AIKIKAI_6.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_AIKIKAI_6.ToString();
            dtpDanAIKIKAI7.Text = search_Model.DAN_AIKIKAI_7.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_AIKIKAI_7.ToString();
            dtpDanAIKIKAI8.Text = search_Model.DAN_AIKIKAI_8.ToString().Contains(DateTime.MinValue.ToString()) == true ? " " : search_Model.DAN_AIKIKAI_8.ToString();
            changevalue = false;
        }

        private String messageCheckDateCap(int a, int b)
        {
            return $"Ngày cấp DAI {a} phải trước ngày cấp DAI {b}\n";
        }

        private String messageCheckDateDANVN(int a, int b)
        {
            return $"Ngày cấp DAN VN {a} phải trước ngày cấp DAN VN {b}\n";
        }

        private String messageCheckDateDANAIKIKAI(int a, int b)
        {
            return $"Ngày cấp DAN AIKIKAI {a} phải trước ngày cấp DAN AIKIKAI {b}\n";
        }
        
        private void ImageButton_Click(object sender, RoutedEventArgs e)
        {
            SettingImage_BLO settingImage_BLO = new SettingImage_BLO();
            try
            {
                ImageBrush image = settingImage_BLO.LoadImage_Button();
                if (image == null) return;  // Case: Open Dialog but not choose image
                ImageButton.Background = image;
                arrImage = settingImage_BLO.ConvertImage_ToBytes(image.ImageSource);
                changevalue = true;
            }
            catch { MessageBox.Show("Ảnh không hợp lệ", "Lỗi"); }
        }
        private MemberInfo_ViewModel getDB_FromForm()
        {
            MemberInfo_ViewModel info = new MemberInfo_ViewModel();
            if (!txtRegisterNumber.Text.Equals("")) info.RegisterNumber = int.Parse(txtRegisterNumber.Text); //TH edit
            else if (changevalueRegisterNumber == false && txtRegisterNumber.Text.Equals("")) { info.RegisterNumber = db.NewRegisterNumber() + 1; changevalueRegisterNumber = true; }  //TH  New
            else info.RegisterNumber = db.NewRegisterNumber();             //TH đã có mã mới rồi -> h thì in 
            info.SKU = txtSKU.Text;
            info.FullName = txtName.Text;
            info.Nation = txtNation.Text;
            info.Address = txtAddress.Text;
            info.PhoneNumber = txtPhone.Text;
            info.Register_day = dtpRegisterDay.SelectedDate.Value;
            info.Day_of_Birth = (dtpBirthday.SelectedDate == null) ? DateTime.MinValue : dtpBirthday.SelectedDate.Value.Date;
            info.Place_of_Birth = txtBirthplace.Text;
            info.ID_Class = int.Parse(cboRegisterClass.SelectedValue.ToString());
            info.Class_Name = cboRegisterClass.Text;
            info.Image = arrImage;
            info.listLevel = new Dictionary<string, DateTime>();
            info.listLevel.Add("Cap6", (dtpLevel6.SelectedDate == null) ? DateTime.MinValue : dtpLevel6.SelectedDate.Value);
            info.listLevel.Add("Cap5", (dtpLevel5.SelectedDate == null) ? DateTime.MinValue : dtpLevel5.SelectedDate.Value);
            info.listLevel.Add("Cap4", (dtpLevel4.SelectedDate == null) ? DateTime.MinValue : dtpLevel4.SelectedDate.Value);
            info.listLevel.Add("Cap3", (dtpLevel3.SelectedDate == null) ? DateTime.MinValue : dtpLevel3.SelectedDate.Value);
            info.listLevel.Add("Cap2", (dtpLevel2.SelectedDate == null) ? DateTime.MinValue : dtpLevel2.SelectedDate.Value);
            info.listLevel.Add("Cap1", (dtpLevel1.SelectedDate == null) ? DateTime.MinValue : dtpLevel1.SelectedDate.Value);
            info.listLevel.Add("DANVN1", (dtpDanVN1.SelectedDate == null) ? DateTime.MinValue : dtpDanVN1.SelectedDate.Value);
            info.listLevel.Add("DANVN2", (dtpDanVN2.SelectedDate == null) ? DateTime.MinValue : dtpDanVN2.SelectedDate.Value);
            info.listLevel.Add("DANVN3", (dtpDanVN3.SelectedDate == null) ? DateTime.MinValue : dtpDanVN3.SelectedDate.Value);
            info.listLevel.Add("DANVN4", (dtpDanVN4.SelectedDate == null) ? DateTime.MinValue : dtpDanVN4.SelectedDate.Value);
            info.listLevel.Add("DANVN5", (dtpDanVN5.SelectedDate == null) ? DateTime.MinValue : dtpDanVN5.SelectedDate.Value);
            info.listLevel.Add("DANVN6", (dtpDanVN6.SelectedDate == null) ? DateTime.MinValue : dtpDanVN6.SelectedDate.Value);
            info.listLevel.Add("DANVN7", (dtpDanVN7.SelectedDate == null) ? DateTime.MinValue : dtpDanVN7.SelectedDate.Value);
            info.listLevel.Add("DANVN8", (dtpDanVN8.SelectedDate == null) ? DateTime.MinValue : dtpDanVN8.SelectedDate.Value);
            info.listLevel.Add("DANAIKIKAI1", (dtpDanAIKIKAI1.SelectedDate == null) ? DateTime.MinValue : dtpDanAIKIKAI1.SelectedDate.Value);
            info.listLevel.Add("DANAIKIKAI2", (dtpDanAIKIKAI2.SelectedDate == null) ? DateTime.MinValue : dtpDanAIKIKAI2.SelectedDate.Value);
            info.listLevel.Add("DANAIKIKAI3", (dtpDanAIKIKAI3.SelectedDate == null) ? DateTime.MinValue : dtpDanAIKIKAI3.SelectedDate.Value);
            info.listLevel.Add("DANAIKIKAI4", (dtpDanAIKIKAI4.SelectedDate == null) ? DateTime.MinValue : dtpDanAIKIKAI4.SelectedDate.Value);
            info.listLevel.Add("DANAIKIKAI5", (dtpDanAIKIKAI5.SelectedDate == null) ? DateTime.MinValue : dtpDanAIKIKAI5.SelectedDate.Value);
            info.listLevel.Add("DANAIKIKAI6", (dtpDanAIKIKAI6.SelectedDate == null) ? DateTime.MinValue : dtpDanAIKIKAI6.SelectedDate.Value);
            info.listLevel.Add("DANAIKIKAI7", (dtpDanAIKIKAI7.SelectedDate == null) ? DateTime.MinValue : dtpDanAIKIKAI7.SelectedDate.Value);
            info.listLevel.Add("DANAIKIKAI8", (dtpDanAIKIKAI8.SelectedDate == null) ? DateTime.MinValue : dtpDanAIKIKAI8.SelectedDate.Value);


            return info;

        }
        private void SetEmplty()
        {

            txtSKU.Text = "";
            txtRegisterNumber.Text = "";
            txtName.Text = "";
            txtNation.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
            dtpBirthday.Text = "";
            dtpRegisterDay.Text = "";
            txtBirthplace.Text = "";
            cboRegisterClass.Text = "";
            cboRegisterClass.SelectedValue = null;
            cboRegisterClass.Text = "";

            dtpRegisterDay.SelectedDate = DateTime.Now;
            arrImage = null;
            ImageButton.Background = Brushes.WhiteSmoke;

            dtpLevel6.Text = "";
            dtpLevel5.Text = "";
            dtpLevel4.Text = "";
            dtpLevel3.Text = "";
            dtpLevel2.Text = "";
            dtpLevel1.Text = "";
            dtpDanVN1.Text = "";
            dtpDanVN2.Text = "";
            dtpDanVN3.Text = "";
            dtpDanVN4.Text = "";
            dtpDanVN5.Text = "";
            dtpDanVN6.Text = "";
            dtpDanVN7.Text = "";
            dtpDanVN8.Text = "";


            dtpDanAIKIKAI1.Text = "";
            dtpDanAIKIKAI2.Text = "";
            dtpDanAIKIKAI3.Text = "";
            dtpDanAIKIKAI4.Text = "";
            dtpDanAIKIKAI5.Text = "";
            dtpDanAIKIKAI6.Text = "";
            dtpDanAIKIKAI7.Text = "";
            dtpDanAIKIKAI8.Text = "";
        }
        public void Set_BoderError()
        {
            var converter = new BrushConverter();
            var brush = (Brush)converter.ConvertFromString("#FFABADB3");
            txtSKU.BorderBrush = brush;
            txtName.BorderBrush = brush;
            txtNation.BorderBrush = brush;
            txtAddress.BorderBrush = brush;
            txtPhone.BorderBrush = brush;
            dtpBirthday.BorderBrush = brush;
            dtpRegisterDay.BorderBrush = brush;
            txtBirthplace.BorderBrush = brush;
            cboRegisterClass.BorderBrush = brush;

            dtpLevel6.BorderBrush = brush;
            dtpLevel5.BorderBrush = brush;
            dtpLevel4.BorderBrush = brush;
            dtpLevel3.BorderBrush = brush;
            dtpLevel2.BorderBrush = brush;
            dtpLevel1.BorderBrush = brush;

            dtpDanVN1.BorderBrush = brush;
            dtpDanVN2.BorderBrush = brush;
            dtpDanVN3.BorderBrush = brush;
            dtpDanVN4.BorderBrush = brush;
            dtpDanVN5.BorderBrush = brush;
            dtpDanVN6.BorderBrush = brush;
            dtpDanVN7.BorderBrush = brush;
            dtpDanVN8.BorderBrush = brush;


            dtpDanAIKIKAI1.BorderBrush = brush;
            dtpDanAIKIKAI2.BorderBrush = brush;
            dtpDanAIKIKAI3.BorderBrush = brush;
            dtpDanAIKIKAI4.BorderBrush = brush;
            dtpDanAIKIKAI5.BorderBrush = brush;
            dtpDanAIKIKAI6.BorderBrush = brush;
            dtpDanAIKIKAI7.BorderBrush = brush;
            dtpDanAIKIKAI8.BorderBrush = brush;

        }
        //------------------------------------------------------Menu bar     
        private void btnDKHV_MouseEnter(object sender, MouseEventArgs e)
        {
            //btnDKHVb.Background = Brushes.DarkBlue;
            //btnDKHV.Background = Brushes.LightGray;
        }

        private void btnDKHV_MouseLeave(object sender, MouseEventArgs e)
        {
            //if (btnSelect[0] == true)
            //{
            //    btnDKHVb.Background = Brushes.White;
            //    btnDKHV.Background = Brushes.White;
            //}
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
            //RegisterMemberScreen rgm = new RegisterMemberScreen();
            //rgm.Show();
            //this.Close();
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


        private void txtSKU_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            changevalue = true;
         }

        private void dtpRegisterDay_SelectedDateChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            changevalue = true;
        }

        private void btnHelpI_Click(object sender, RoutedEventArgs e)
        {
            Support sp = new Support();
            sp.Show();
            this.Close();
        }

        private void cboRegisterClass_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            changevalue = true;
        }
    }
}
