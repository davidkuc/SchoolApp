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
using SchoolApp_EFCore.Repositories;
using SchoolApp_EFCore.Models;
using System.ComponentModel;
using SchoolApp2.Models;
using SchoolApp2.Enums;
using SchoolApp2.Helpers;

namespace SchoolApp2.Views.Student
{
    /// <summary>
    /// Interaction logic for StudUpdGroups.xaml
    /// </summary>
    public partial class StudUpdGroups : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly StudentUpdate _studUpd;
        private EFStudent _stud;
        private readonly RepoPack _repoPack;
        private GroupModel _selectedGroup;
        private ICollection<GroupModel> _groups;

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

        public StudUpdGroups(Upd_Del_Window updDelWindow, StudentUpdate studUpd, EFStudent stud, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _stud = stud;
            _groups = DataProvider.GetStudentGroupModels(_stud);
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
            _studUpd = studUpd;
        }

        private void UpdGroups_Del_Button_Click(object sender, RoutedEventArgs e)
        {
            var groupStud = _repoPack.GruStudRepo.GetByKeys(_stud.ID, SelectedGroup.ID);
            _repoPack.GruStudRepo.Remove(groupStud);
            _repoPack.GruStudRepo.Save();
            _groups.Remove(SelectedGroup);
            _repoPack.StudRepo.Update(_stud);

            StudentGroups.Items.Refresh();
        }

        private void ConfirmUpd_Button_Click(object sender, RoutedEventArgs e)
        {
            var stud = _stud;
            _updDelWindow.DataContext = _studUpd;
            _studUpd.Groups = this.Groups;
            _updDelWindow.Content = _studUpd;

        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _studUpd;
        }

        private void StudentGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var item = (GroupModel)listbox.SelectedItem;
            _selectedGroup = item;
        }

        private void UpdGroups_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = (GroupModel)DBGroups_ComboBox.SelectedItem;

            var relationExists = _repoPack.GruStudRepo.GetByKeys(_stud.ID, selected.ID) != null ? true : false;
            if (relationExists)
            {
                MessageBox.Show("This student is already assigned to this group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _repoPack.GruStudRepo.Add(
                new GroupStudent { GroupId = selected.ID, StudentId = _stud.ID });
            _repoPack.GruStudRepo.Save();
            _groups.Add(selected);

            StudentGroups.Items.Refresh();
        }
    }
}
