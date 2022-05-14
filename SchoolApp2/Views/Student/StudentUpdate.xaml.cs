using SchoolApp2.Views.Shared;
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
using SchoolApp_EFCore.Models;

namespace SchoolApp2.Views.Student
{
    /// <summary>
    /// Interaction logic for StudentUpdate.xaml
    /// </summary>
    public partial class StudentUpdate : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly StudentDetails _studDet;
        private readonly EFStudent _stud;
        private readonly RepoPack _repoPack;

        private string _name;
        private string _surname;
        private int _year;
        private string _dateOfBirth;
        private string _course;
        private ICollection<Group> _groups;

        public string SName
        {
            get {  return _name;}
            set { _name = value; }
        }
       
        public string Surname
        {
            get { return _surname; }
            set { _surname = value; }
        }

        public string DateOfBirth
        {
            get { return _dateOfBirth; }
            set { _dateOfBirth = value; }
        }

        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public string Course
        {
            get { return _course; }
            set { _course = value; }
        }

        public ICollection<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        public StudentUpdate(Upd_Del_Window updDelWindow, StudentDetails studDet, EFStudent stud, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _stud = stud;
            FillFields();
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
            _studDet = studDet;
        }

        private void FillFields()
        {
            Name = _stud.Name;
            Surname = _stud.Surname;
            DateOfBirth = _stud.DateOfBirth;
            Course = _stud.CourseName;
            Year = _stud.Year;
            Groups = _stud.Groups;
        }

        private void ConfirmUpd_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            _updDelWindow.Content = _studDet;
        }

        private void EditGroups_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new StudUpdGroups(_updDelWindow, this); ;
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _studDet;
        }
    }
}
