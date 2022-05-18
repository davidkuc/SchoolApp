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
using SchoolApp2.Views.Shared;
using SchoolApp_EFCore.Repositories;
using SchoolApp_EFCore.Models;

namespace SchoolApp2.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherAdd.xaml
    /// </summary>
    public partial class TeacherAdd : Page
    {
        private ICollection<Group> _groups;
        private readonly TeacherMain _teaMain;
        private Upd_Del_Window _updDelWindow;
        private RepoPack _repoPack;

        public TeacherAdd(TeacherMain teaMain, Upd_Del_Window updDelWindow, RepoPack repoPack)
        {
            InitializeComponent();
            _groups = new List<Group>();
            _teaMain = teaMain;
            _updDelWindow = updDelWindow;
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;

        }

        public string SName { get; set; }

        public string Surname { get; set; }

        public ICollection<Group> Groups
        {
            get { return _groups; }
            set { _groups = value; }
        }

        private void AddGroups_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new TeaAddGroups(_updDelWindow, this, _repoPack, _groups);
        }

        private void ConfirmUpd_Button_Click(object sender, RoutedEventArgs e)
        {
            var newTea = new EFTeacher
            {
                Name = this.SName,
                Surname = this.Surname
            };


            if (Name == null || Surname == null)
            {
                MessageBox.Show("Fields cannot be empty", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            _repoPack.TeaRepo.Add(newTea);
            _repoPack.TeaRepo.Save();
            var addedTea = _repoPack.TeaRepo.GetLast();
            foreach (var item in Groups)
            {
                _repoPack.GruTeaRepo.Add(new GroupTeacher { GroupId = item.ID, TeacherId = addedTea.ID });
            }
            _repoPack.GruTeaRepo.Save();
            _teaMain.Teachers.Add(newTea);
            _teaMain.TeacherListBox.Items.Refresh();

            _updDelWindow?.Close();
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow?.Close();
        }
    }
}
