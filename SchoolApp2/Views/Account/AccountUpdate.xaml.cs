using SchoolApp2.Views.Shared;
using System;
using EFAccount = SchoolApp_EFCore.Models.Account;
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
using SchoolApp_EFCore.Repositories;

namespace SchoolApp2.Views.Account
{
    /// <summary>
    /// Interaction logic for AccountUpdate.xaml
    /// </summary>
    public partial class AccountUpdate : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly AccountDetails _accDet;
        private readonly EFAccount _acc;
        private readonly RepoPack _repoPack;

        private string _name;
        private string _surname;
        private bool _hasAdminPrivileges;
        private string _username;
        private string _password;

        public AccountUpdate(Upd_Del_Window updDelWindow, AccountDetails accDet, EFAccount acc, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _accDet = accDet;
            _acc = acc;
            FillFields();
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
        }

        private void FillFields()
        {
            Name = _acc.Name;
            Surname = _acc.Surname;
            HasAdminPrivileges = _acc.HasAdminPrivileges;
            Username = _acc.Username;
            Password = _acc.Password;
        }

        public string SName
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public bool HasAdminPrivileges
        {
            get { return _hasAdminPrivileges; }
            set { _hasAdminPrivileges = value; }
        }

        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            _acc.Name = SName;
            _acc.Surname = Surname;
            _acc.HasAdminPrivileges = HasAdminPrivileges;
            _acc.Username = Username;
            _acc.Password = Password;
            _repoPack.AccRepo.Update(_acc);
            _updDelWindow.Content = _accDet;
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _accDet;
        }
    }
}
