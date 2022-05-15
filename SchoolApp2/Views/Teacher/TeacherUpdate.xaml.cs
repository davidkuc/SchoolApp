using SchoolApp_EFCore.Repositories;
using SchoolApp2.Views.Shared;
using EFTeacher = SchoolApp_EFCore.Models.Teacher;
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
using SchoolApp2.Models;
using SchoolApp2.Helpers;

namespace SchoolApp2.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherUpdate.xaml
    /// </summary>
    public partial class TeacherUpdate : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly TeacherDetails _teaDet;
        private readonly EFTeacher _tea;
        private readonly RepoPack _repoPack;

        private string _name;
        private string _surname;
        private int _year;
        private string _dateOfBirth;
        private string _course;
        private ICollection<GroupModel> _groups;

        public TeacherUpdate(Upd_Del_Window updDelWindow, TeacherDetails teaDet, EFTeacher tea, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
            _teaDet = teaDet;
            _tea = tea;
            _repoPack = repoPack;
            FillFields();
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


        public int Year
        {
            get { return _year; }
            set { _year = value; }
        }

        public ICollection<GroupModel> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        private void FillFields()
        {
            SName = _tea.Name;
            Surname = _tea.Surname;
            Groups = DataProvider.GetTeacherGroupModels(_tea);
        }

        private void EditGroups_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new TeaUpdGroups(_updDelWindow, this, _tea, _repoPack);
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _teaDet;
        }

        private void ConfirmUpd_Button_Click(object sender, RoutedEventArgs e)
        {
            _tea.Name = SName;
            _tea.Surname = Surname;
            _repoPack.TeaRepo.Update(_tea);
            _updDelWindow.Content = _teaDet;
        }
    }
}
