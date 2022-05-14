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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolApp2.Views.Account
{
    /// <summary>
    /// Interaction logic for AccountDetails.xaml
    /// </summary>
    public partial class AccountDetails : Page
    {
        private Upd_Del_Window _updDelWindow;
        private readonly AccountsMainPage _accMain;

        public AccountDetails(Upd_Del_Window updDelWindow, AccountsMainPage accMain)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _accMain = accMain;
            updDelWindow.Content = this;
            _updDelWindow.Show();
        }

        private void Password_Show_Checkbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void Username_Show_Checkbox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow?.Close();
        }

        private void UpdateAcc_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new AccountUpdate(_updDelWindow, this);
        }

        private void DeleteAcc_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
