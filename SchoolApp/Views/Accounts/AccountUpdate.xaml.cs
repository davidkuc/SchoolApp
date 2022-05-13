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

namespace SchoolApp.Views.Accounts
{
    /// <summary>
    /// Interaction logic for AccountUpdate.xaml
    /// </summary>
    public partial class AccountUpdate : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly AccountDetails _accDet;

        public AccountUpdate(Upd_Del_Window updDelWindow, AccountDetails accDet)
        {
            InitializeComponent();

            _updDelWindow = updDelWindow;
            _accDet = accDet;
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            _updDelWindow.Content = _accDet;
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _accDet;
        }
    }
}
