using SchoolApp_EFCore.Repositories;
using SchoolApp2.Views.Account;
using EFTeacher = SchoolApp_EFCore.Models.Teacher;
using SchoolApp2.Views.Shared;
using SchoolApp2.Views.Shared.Pages;
using SchoolApp2.Views.Student;
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

namespace SchoolApp2.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherMain.xaml
    /// </summary>
    public partial class TeacherMain : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly RepoPack _repoPack;
        private List<EFTeacher> _teachers;
        private EFTeacher _selectedTeacher;

        public TeacherMain(MainWindow mainWindow, RepoPack repoPack)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _mainWindow.DataContext = this;
            _repoPack = repoPack;
            _teachers = (List<EFTeacher>?)_repoPack.TeaRepo.GetAll();
            if (!LoginPage.AccountHolder.HasAdminPrivileges)
            {
                Accounts_Nav_Button.Visibility = Visibility.Hidden;
            }
        }

        public EFTeacher SelectedTeacher
        {
            get
            { return _selectedTeacher; }
            set
            {
                _selectedTeacher = value;
            }
        }

        public List<EFTeacher> Teachers
        {
            get { return _teachers; }
            set
            {
                _teachers = value;
            }
        }

        private void TeacherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var item = (EFTeacher)listbox.SelectedItem;
            _selectedTeacher = item;
        }

        private void Home_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new MainMenuPage(_mainWindow, _repoPack);
        }

        private void Students_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new StudentMain(_mainWindow, _repoPack);
        }

        private void Accounts_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new AccountsMainPage(_mainWindow, _repoPack);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new LoginPage(_mainWindow, _repoPack);
        }


        private void TeacherDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            if (SelectedTeacher == null)
            {
                MessageBox.Show("Select a teacher", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            var updDelWindow = new Upd_Del_Window();
            updDelWindow.Content = new TeacherDetails(updDelWindow, this, _selectedTeacher, _repoPack);
            updDelWindow.Show();
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var addWindow = new Upd_Del_Window();
            addWindow.Content = new TeacherAdd(this, addWindow, _repoPack);
            addWindow.Show();
        }
    }
}
