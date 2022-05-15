using SchoolApp2.Views.Shared;
using EFStudent = SchoolApp_EFCore.Models.Student;
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
using SchoolApp_EFCore.Models;
using SchoolApp_EFCore.Repositories;
using SchoolApp2.Models;
using SchoolApp2.Helpers;

namespace SchoolApp2.Views.Student
{
    /// <summary>
    /// Interaction logic for StudentDetails.xaml
    /// </summary>
    public partial class StudentDetails : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly StudentMain _studMain;
        private readonly EFStudent _stud;
        private readonly RepoPack _repoPack;
        private ICollection<GroupModel> _groups;

        public string SName => _stud.Name;

        public string Surname => _stud.Surname;

        public string DateOfBirth => _stud.DateOfBirth;

        public int Year => _stud.Year;

        public string Course => _stud.CourseName;

        public ICollection<GroupModel> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
            }
        }

        public StudentDetails(Upd_Del_Window updDelWindow, StudentMain studMain, EFStudent stud, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _studMain = studMain;
            _stud = stud;
            _groups = DataProvider.GetStudentGroupModels(_stud);
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
            _updDelWindow.Show();
        }

        private void DeleteStud_Button_Click(object sender, RoutedEventArgs e)
        {  
           var removedStud =  _studMain.Students.Remove(_stud);
            _studMain.StudentListBox.Items.Refresh();
            _repoPack.StudRepo.Remove(_stud);
            _repoPack.StudRepo.Save();        
            _updDelWindow.Close();

        }

        private void UpdateStud_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new StudentUpdate(_updDelWindow, this,  _stud, _repoPack);
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
           var updatedStud = _studMain.Students.Find(x => x.ID == _stud.ID);
            updatedStud = _stud;
            _studMain.StudentListBox.Items.Refresh();
            _updDelWindow?.Close();
        }
    }
}
