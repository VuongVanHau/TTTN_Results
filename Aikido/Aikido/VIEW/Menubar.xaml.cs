using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AidikoMemberManagement.View
{
    
    // Setting layout for Foundation 
    public partial class Menubar : Window
    {
        private List<bool> btnSelect = new List<bool>();

        public Menubar()
        {
            InitializeComponent();
            for (int i = 0; i < 5; i++)
            {
                btnSelect.Add(true);
            }
            btnSearchQ.Visibility = Visibility.Hidden;
            btnSearchC.Visibility = Visibility.Hidden;
            setScreen(0);
        }

        private void setScreen(int scr)
        {
            switch(scr)
            {
                case 0:
                    {
                        ScreenRegisterMember.Visibility = Visibility.Hidden;
                        ScreenSearchNhanh.Visibility = Visibility.Hidden;
                        ScreenSeachCondition.Visibility = Visibility.Hidden;
                        ScreenFee.Visibility = Visibility.Hidden;
                        ScreenClass.Visibility = Visibility.Hidden;
                        ScreenSetting.Visibility = Visibility.Hidden;
                        break;
                    }
                case 1:
                    {
                        ScreenRegisterMember.Visibility = Visibility.Visible;
                        ScreenSearchNhanh.Visibility = Visibility.Hidden;
                        ScreenSeachCondition.Visibility = Visibility.Hidden;
                        ScreenFee.Visibility = Visibility.Hidden;
                        ScreenClass.Visibility = Visibility.Hidden;
                        ScreenSetting.Visibility = Visibility.Hidden;
                        break;
                    }
                case 2:
                    {
                        ScreenRegisterMember.Visibility = Visibility.Hidden;
                        ScreenSearchNhanh.Visibility = Visibility.Visible;
                        ScreenSeachCondition.Visibility = Visibility.Hidden;
                        ScreenFee.Visibility = Visibility.Hidden;
                        ScreenClass.Visibility = Visibility.Hidden;
                        ScreenSetting.Visibility = Visibility.Hidden;
                        break;
                    }
                case 3:
                    {
                        ScreenRegisterMember.Visibility = Visibility.Hidden;
                        ScreenSearchNhanh.Visibility = Visibility.Hidden;
                        ScreenSeachCondition.Visibility = Visibility.Visible;
                        ScreenFee.Visibility = Visibility.Hidden;
                        ScreenClass.Visibility = Visibility.Hidden;
                        ScreenSetting.Visibility = Visibility.Hidden;
                        break;
                    }
                case 4:
                    {
                        ScreenRegisterMember.Visibility = Visibility.Hidden;
                        ScreenSearchNhanh.Visibility = Visibility.Hidden;
                        ScreenSeachCondition.Visibility = Visibility.Hidden;
                        ScreenFee.Visibility = Visibility.Visible;
                        ScreenClass.Visibility = Visibility.Hidden;
                        ScreenSetting.Visibility = Visibility.Hidden;
                        break;
                    }
                case 5:
                    {
                        ScreenRegisterMember.Visibility = Visibility.Hidden;
                        ScreenSearchNhanh.Visibility = Visibility.Hidden;
                        ScreenSeachCondition.Visibility = Visibility.Hidden;
                        ScreenFee.Visibility = Visibility.Hidden;
                        ScreenClass.Visibility = Visibility.Visible;
                        ScreenSetting.Visibility = Visibility.Hidden;
                        break;
                    }
                case 6:
                    {
                        ScreenRegisterMember.Visibility = Visibility.Hidden;
                        ScreenSearchNhanh.Visibility = Visibility.Hidden;
                        ScreenSeachCondition.Visibility = Visibility.Hidden;
                        ScreenFee.Visibility = Visibility.Hidden;
                        ScreenClass.Visibility = Visibility.Hidden;
                        ScreenSetting.Visibility = Visibility.Visible;
                        break;
                    }
            }
        }

        private void btnDKHV_MouseEnter(object sender, MouseEventArgs e)
        {
            btnDKHVb.Background = Brushes.DarkBlue;
            btnDKHV.Background = Brushes.LightGray;
        }

        private void btnDKHV_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[0] == true)
            {
                btnDKHVb.Background = Brushes.White;
                btnDKHV.Background = Brushes.White;
            }
        }

        private void btnSearch_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSearchb.Background = Brushes.DarkBlue;
            btnSearch.Background = Brushes.LightGray;
            btnSearchC.Visibility = Visibility.Visible;
            btnSearchQ.Visibility = Visibility.Visible;
        }

        private void btnSearch_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[1] == true)
            {
                btnSearch.Background = Brushes.White;
            }
        }

        private void btnQLHP_MouseEnter(object sender, MouseEventArgs e)
        {
            btnQLHPb.Background = Brushes.DarkBlue;
            btnQLHP.Background = Brushes.LightGray;
        }

        private void btnQLHP_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[2] == true)
            {
                btnQLHPb.Background = Brushes.White;
                btnQLHP.Background = Brushes.White;
            }
        }

        private void btnQLL_MouseEnter(object sender, MouseEventArgs e)
        {
            btnQLLb.Background = Brushes.DarkBlue;
            btnQLL.Background = Brushes.LightGray;
        }

        private void btnQLL_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[3] == true)
            {
                btnQLLb.Background = Brushes.White;
                btnQLL.Background = Brushes.White;
            }
        }

        private void btnTL_MouseEnter(object sender, MouseEventArgs e)
        {
            btnTLb.Background = Brushes.DarkBlue;
            btnTL.Background = Brushes.LightGray;
        }

        private void btnTL_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[4] == true)
            {
                btnTLb.Background = Brushes.White;
                btnTL.Background = Brushes.White;
            }
        }

        private void btnDKHV_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnSelect[0] = false;
            btnSelect[1] = true;
            btnSelect[2] = true;
            btnSelect[3] = true;
            btnSelect[4] = true;
            setScreen(1);
            btnDKHV.Background = Brushes.LightGray;
            btnDKHVb.Background = Brushes.DarkBlue;
            btnSearch.Background = Brushes.White;
            btnSearchb.Background = Brushes.White;
            btnQLHP.Background = Brushes.White;
            btnQLHPb.Background = Brushes.White;
            btnQLL.Background = Brushes.White;
            btnQLLb.Background = Brushes.White;
            btnTL.Background = Brushes.White;
            btnTLb.Background = Brushes.White;
        }

        private void btnSearch_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnSelect[0] = true;
            btnSelect[1] = false;
            btnSelect[2] = true;
            btnSelect[3] = true;
            btnSelect[4] = true;
            btnDKHV.Background = Brushes.White;
            btnDKHVb.Background = Brushes.White;
            btnSearch.Background = Brushes.LightGray;
            btnSearchb.Background = Brushes.DarkBlue;
            btnQLHP.Background = Brushes.White;
            btnQLHPb.Background = Brushes.White;
            btnQLL.Background = Brushes.White;
            btnQLLb.Background = Brushes.White;
            btnTL.Background = Brushes.White;
            btnTLb.Background = Brushes.White;
        }

        private void btnQLHP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnSelect[0] = true;
            btnSelect[1] = true;
            btnSelect[2] = false;
            btnSelect[3] = true;
            btnSelect[4] = true;
            setScreen(4);
            btnDKHV.Background = Brushes.White;
            btnDKHVb.Background = Brushes.White;
            btnSearch.Background = Brushes.White;
            btnSearchb.Background = Brushes.White;
            btnQLHP.Background = Brushes.LightGray;
            btnQLHPb.Background = Brushes.DarkBlue;
            btnQLL.Background = Brushes.White;
            btnQLLb.Background = Brushes.White;
            btnTL.Background = Brushes.White;
            btnTLb.Background = Brushes.White; 
        }

        private void btnQLL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnSelect[0] = true;
            btnSelect[1] = true;
            btnSelect[2] = true;
            btnSelect[3] = false;
            btnSelect[4] = true;
            setScreen(5);
            btnDKHV.Background = Brushes.White;
            btnDKHVb.Background = Brushes.White;
            btnSearch.Background = Brushes.White;
            btnSearchb.Background = Brushes.White;
            btnQLHP.Background = Brushes.White;
            btnQLHPb.Background = Brushes.White;
            btnQLL.Background = Brushes.LightGray;
            btnQLLb.Background = Brushes.DarkBlue;
            btnTL.Background = Brushes.White;
            btnTLb.Background = Brushes.White;
        }

        private void btnTL_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnSelect[0] = true;
            btnSelect[1] = true;
            btnSelect[2] = true;
            btnSelect[3] = true;
            btnSelect[4] = false;
            setScreen(6);
            btnDKHV.Background = Brushes.White;
            btnDKHVb.Background = Brushes.White;
            btnSearch.Background = Brushes.White;
            btnSearchb.Background = Brushes.White;
            btnQLHP.Background = Brushes.White;
            btnQLHPb.Background = Brushes.White;
            btnQLL.Background = Brushes.White;
            btnQLLb.Background = Brushes.White;
            btnTL.Background = Brushes.LightGray;
            btnTLb.Background = Brushes.DarkBlue;
        }

        private void btnSearchQ_MouseEnter(object sender, MouseEventArgs e)
        {
            btnSearchb.Background = Brushes.DarkBlue;
            if (btnSelect[1] == false)
            {
                btnSearchQ.Background = Brushes.LightGray;
                btnSearchC.Background = Brushes.White;
            }
            else btnSearchQ.Background = Brushes.LightGray;
        }

        private void btnSearchQ_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[1] == true)
            {
                btnSearchQ.Background = Brushes.White;
                btnSearchb.Background = Brushes.White;
            }
            btnSearchQ.Visibility = Visibility.Hidden;
            btnSearchC.Visibility = Visibility.Hidden;
        }

        private void btnSearchQ_MouseDown(object sender, MouseButtonEventArgs e)
        {
            btnSearch.Content = "Tìm Nhanh";
            btnSearchC.Visibility = Visibility.Hidden;
            btnSearchQ.Visibility = Visibility.Hidden;
            btnSelect[0] = true;
            btnSelect[1] = false;
            btnSelect[2] = true;
            btnSelect[3] = true;
            btnSelect[4] = true;
            setScreen(2);
            btnDKHV.Background = Brushes.White;
            btnDKHVb.Background = Brushes.White;
            btnSearch.Background = Brushes.LightGray;
            btnSearchb.Background = Brushes.DarkBlue;
            btnQLHP.Background = Brushes.White;
            btnQLHPb.Background = Brushes.White;
            btnQLL.Background = Brushes.White;
            btnQLLb.Background = Brushes.White;
            btnTL.Background = Brushes.White;
            btnTLb.Background = Brushes.White;
        }

        private void btnSearchC_MouseEnter(object sender, MouseEventArgs e)
        {
            if(btnSelect[1]==false)
            {
                btnSearchC.Background = Brushes.LightGray;
                btnSearchQ.Background = Brushes.White;
            }
            else btnSearchC.Background = Brushes.LightGray;
            btnSearchb.Background = Brushes.DarkBlue;
            
        }

        private void btnSearchC_MouseLeave(object sender, MouseEventArgs e)
        {
            if (btnSelect[1] == true)
            {
                btnSearchC.Background = Brushes.White;
                btnSearchb.Background = Brushes.White;
            }
            btnSearchQ.Visibility = Visibility.Hidden;
            btnSearchC.Visibility = Visibility.Hidden;
            
        }

        private void btnSearchC_MouseDown(object sender, MouseButtonEventArgs e)
        {
            setScreen(3);
            btnSearch.Content = "Tìm theo Điều Kiện";
            btnSearchC.Visibility = Visibility.Hidden;
            btnSearchQ.Visibility = Visibility.Hidden;
            btnSelect[0] = true;
            btnSelect[1] = false;
            btnSelect[2] = true;
            btnSelect[3] = true;
            btnSelect[4] = true;
            btnDKHV.Background = Brushes.White;
            btnDKHVb.Background = Brushes.White;
            btnSearch.Background = Brushes.LightGray;
            btnSearchb.Background = Brushes.DarkBlue;
            btnQLHP.Background = Brushes.White;
            btnQLHPb.Background = Brushes.White;
            btnQLL.Background = Brushes.White;
            btnQLLb.Background = Brushes.White;
            btnTL.Background = Brushes.White;
            btnTLb.Background = Brushes.White;
        }

        private void dgvFee_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            //var desc = e.PropertyDescriptor as PropertyDescriptor;
            //var att = desc.Attributes[typeof(ColumnNameAttribute)] as ColumnNameAttribute;
            //if (att != null)
            //{
            //    e.Column.Header = att.Name;
            //}
        }

        
    }
    //


}
