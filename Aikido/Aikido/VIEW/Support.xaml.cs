using System;
using System.Collections.Generic;
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

namespace Aikido.VIEW
{
    /// <summary>
    /// Interaction logic for Support.xaml
    /// </summary>
    public partial class Support : Window
    {
        public Support()
        {
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
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            SettingScreen setting = new SettingScreen();
            setting.Show();
            this.Close();
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
            //btnHelp.Background = Brushes.LightGray;
            //btnHelpb.Background = Brushes.DarkBlue;
            //btnHelpI.Background = Brushes.LightGray;
        }

        private void btnHelpI_MouseLeave(object sender, MouseEventArgs e)
        {
            //btnHelp.Background = Brushes.White;
            //btnHelpb.Background = Brushes.White;
            //btnHelpI.Background = Brushes.White;
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
            FeeScreen fees = new FeeScreen();
            fees.Show();
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

        private void btnHelpI_Click(object sender, RoutedEventArgs e)
        {
            Support sp = new Support();
            sp.Show();
            this.Close();
        }
    }
}
