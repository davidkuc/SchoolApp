using SchoolApp_EFCore.Repositories;
using SchoolApp_EFCore.Models;
using EFStudent = SchoolApp_EFCore.Models.Student;
using SchoolApp2.Models;
using SchoolApp2.Views.Account;
using SchoolApp2.Views.Shared;
using SchoolApp2.Views.Shared.Pages;
using SchoolApp2.Views.Teacher;
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

namespace SchoolApp2.Views.Student
{
    /// <summary>
    /// Interaction logic for StudentMain.xaml
    /// </summary>
    public partial class StudentMain : Page
    {
        private readonly MainWindow _mainWindow;
        private readonly RepoPack _repoPack;
        private List<EFStudent> _students;
        private EFStudent _selectedStud;

        public List<EFStudent> Students => _students;

        public EFStudent SelectedStudent
        {
            get
            { return _selectedStud; }
            set
            {
                _selectedStud = value;
            }
        }

        public StudentMain(MainWindow mainWindow, RepoPack repoPack)
        {
            InitializeComponent();
            _mainWindow = mainWindow;
            _mainWindow.DataContext = this;
            _repoPack = repoPack;
            _students = (List<EFStudent>?)_repoPack.StudRepo.GetAll();

        }

        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var item = (EFStudent)listbox.SelectedItem;
            _selectedStud = item;
        }

        private void Home_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new MainMenuPage(_mainWindow, _repoPack);
        }

        private void Teacher_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new TeacherMain(_mainWindow, _repoPack);
        }

        private void Accounts_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new AccountsMainPage(_mainWindow, _repoPack);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new LoginPage(_mainWindow, _repoPack);
        }

        private void StudDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            var updDelWindow = new Upd_Del_Window();
            updDelWindow.Content = new StudentDetails(updDelWindow, this, _selectedStud, _repoPack);
            updDelWindow.Show();
        }

        private void StudSortOptions_Button_Click(object sender, RoutedEventArgs e)
        {
            var sortOptionsWindow = new SortOptionsWindow();
            sortOptionsWindow.Content = new StudSortOptions(sortOptionsWindow, this);
            sortOptionsWindow.Show();
        }

        private void PrevPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
