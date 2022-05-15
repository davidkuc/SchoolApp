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
using SchoolApp_EFCore.Repositories;
using SchoolApp2.Helpers;

namespace SchoolApp2.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeaUpdGroups.xaml
    /// </summary>
    public partial class TeaUpdGroups : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly TeacherUpdate _teaUpd;
        private EFTeacher _tea;
        private readonly RepoPack _repoPack;
        private GroupModel _selectedGroup;
        private ICollection<GroupModel> _groups;

        public TeaUpdGroups(Upd_Del_Window updDelWindow, TeacherUpdate teaUpd, EFTeacher tea, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _teaUpd = teaUpd;
            _tea = tea;
            _groups = DataProvider.GetTeacherGroupModels(_tea);
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;


        }


        public ICollection<GroupModel> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
            }
        }

        public ICollection<GroupModel> DBGroups => DataProvider.GetDBGroupModels(_repoPack);

        public GroupModel SelectedGroup
        {
            get
            { return _selectedGroup; }
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            var tea = _tea;
            _updDelWindow.DataContext = _teaUpd;
            _teaUpd.Groups = this.Groups;
            _updDelWindow.Content = _teaUpd;
        }

        private void AddGroup_Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = (GroupModel)DBGroups_ComboBox.SelectedItem;

            var relationExists = _repoPack.GruStudRepo.GetByKeys(_tea.ID, selected.ID) != null ? true : false;
            if (relationExists)
            {
                MessageBox.Show("This teacher is already assigned to this group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _repoPack.GruStudRepo.Add(
                new GroupTeacher { GroupId = selected.ID, TeacherId = _tea.ID });
            _repoPack.GruStudRepo.Save();
            _groups.Add(selected);

            TeacherGroups.Items.Refresh();
        }

        private void DeleteGroup_Button_Click(object sender, RoutedEventArgs e)
        {
            var groupStud = _repoPack.GruStudRepo.GetByKeys(_tea.ID, SelectedGroup.ID);
            _repoPack.GruStudRepo.Remove(groupStud);
            _repoPack.GruStudRepo.Save();
            _groups.Remove(SelectedGroup);
            _repoPack.StudRepo.Update(_tea);

            TeacherGroups.Items.Refresh();
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _teaUpd;
        }

        private void TeacherGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var item = (GroupModel)listbox.SelectedItem;
            _selectedGroup = item;
        }
    }
}
