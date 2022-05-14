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
    /// Interaction logic for AccountSortOptions.xaml
    /// </summary>
    public partial class AccountSortOptions : Page
    {
        private readonly SortOptionsWindow _sortOptWind;
        private readonly AccountsMainPage _accMain;

        public AccountSortOptions(SortOptionsWindow sortOptWind, AccountsMainPage accMain)
        {
            InitializeComponent();
            _sortOptWind = sortOptWind;
            _accMain = accMain;
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _sortOptWind.Close();
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            _sortOptWind.Close();
        }
    }
}
