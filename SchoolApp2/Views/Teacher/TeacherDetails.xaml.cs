using SchoolApp2.Views.Shared;
using System;
using EFTeacher = SchoolApp_EFCore.Models.Teacher;
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
using SchoolApp2.Models;
using SchoolApp2.Helpers;

namespace SchoolApp2.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherDetails.xaml
    /// </summary>
    public partial class TeacherDetails : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly TeacherMain _teaMain;
        private readonly EFTeacher _tea;
        private readonly RepoPack _repoPack;
        private ICollection<GroupModel> _groups;

        public string SName
        {
            get { return _tea.Name; }
            set { _tea.Name = value; }
        }
        public string Surname
        {
            get { return _tea.Surname; }
            set { _tea.Surname = value; }
        }

        public TeacherDetails(Upd_Del_Window updDelWindow, TeacherMain teaMain, EFTeacher tea, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _teaMain = teaMain;
            _tea = tea;
            _groups = DataProvider.GetTeacherGroupModels(_tea);
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
            _updDelWindow.Show();
        }

        public ICollection<GroupModel> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
            }
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            var removedTea = _teaMain.Teachers.Remove(_tea);
            _teaMain.TeacherListBox.Items.Refresh();
            _repoPack.TeaRepo.Remove(_tea);
            _repoPack.TeaRepo.Save();
            _updDelWindow.Close();
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new TeacherUpdate(_updDelWindow, this, _tea, _repoPack);
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            var updatedTea = _teaMain.Teachers.Find(x => x.ID == _tea.ID);
            updatedTea = _tea;
            _teaMain.TeacherListBox.Items.Refresh();
            _updDelWindow?.Close();
        }
    }
}
