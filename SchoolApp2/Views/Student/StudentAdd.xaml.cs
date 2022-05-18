using SchoolApp2.Models;
using System;
using EFStudent = SchoolApp_EFCore.Models.Student;
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
using SchoolApp2.Views.Shared;
using SchoolApp_EFCore.Models;

namespace SchoolApp2.Views.Student
{
    /// <summary>
    /// Interaction logic for StudentAdd.xaml
    /// </summary>
    public partial class StudentAdd : Page
    {
        private ICollection<Group> _groups;
        private readonly StudentMain _studMain;
        private Upd_Del_Window _updDelWindow;
        private RepoPack _repoPack;

        public StudentAdd(StudentMain studMain, Upd_Del_Window updDelWindow, RepoPack repoPack)
        {
            InitializeComponent();
            _groups = new List<Group>();
            _studMain = studMain;
            _updDelWindow = updDelWindow;
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;

        }

        public string SName { get; set; }

        public string Surname { get; set; }

        public string DateOfBirth { get; set; }

        public string Course { get; set; }

        public int Year { get; set; }

        public ICollection<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }


        private void AddGroups_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new StudAddGroups(_updDelWindow, this, _repoPack, _groups);
        }

        private void ConfirmUpd_Button_Click(object sender, RoutedEventArgs e)
        {
            var newStud = new EFStudent
            {
                Name = this.SName,
                Surname = this.Surname,
                DateOfBirth = this.DateOfBirth,
                Course = this.Course,
                Year = this.Year
            };


            if (Name == null || Surname == null || DateOfBirth == null || Course == null)
            {
                MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            _repoPack.StudRepo.Add(newStud);
            _repoPack.StudRepo.Save();
            var addedStud = _repoPack.StudRepo.GetLast();
            foreach (var item in Groups)
            {
                _repoPack.GruStudRepo.Add(new GroupStudent { GroupId = item.ID, StudentId = addedStud.ID });
            }
            _repoPack.GruStudRepo.Save();
            _studMain.Students.Add(newStud);
            _studMain.StudentListBox.Items.Refresh();
            
            _updDelWindow?.Close();
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow?.Close();
        }

    }


}

