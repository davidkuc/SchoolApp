using SchoolApp_EFCore.Repositories;
using SchoolApp2.Views.Shared;
using EFAccount = SchoolApp_EFCore.Models.Account;
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
    /// Interaction logic for AccountAdd.xaml
    /// </summary>
    public partial class AccountAdd : Page
    {
        private Upd_Del_Window _updDelWindow;
        private readonly AccountsMainPage _accMain;
        private readonly RepoPack _repoPack;

        public AccountAdd(Upd_Del_Window updDelWindow, AccountsMainPage accMain, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _accMain = accMain;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
            _repoPack = repoPack;

        }

        public string SName { get; set; }

        public string Surname { get; set; }

        public bool HasAdminPrivileges { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {

            _updDelWindow?.Close();
        }

        private void AddAcc_Button_Click(object sender, RoutedEventArgs e)
        {

            var newAcc = new EFAccount
            {
                Name = this.SName,
                Surname = this.Surname,
                Username = this.Username,
                Password = this.Password,
                HasAdminPrivileges = this.HasAdminPrivileges
            };

            if (Name == null || Surname == null || Username == null || Password == null)
            {
                MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _repoPack.AccRepo.Add(newAcc);
            _repoPack.AccRepo.Save();
            _accMain.Accounts.Add(newAcc);
            _accMain.AccountsListBox.Items.Refresh();
            _updDelWindow?.Close();
        }
    }
}
