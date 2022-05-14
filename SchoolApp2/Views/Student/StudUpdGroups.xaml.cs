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

namespace SchoolApp2.Views.Student
{
    /// <summary>
    /// Interaction logic for StudUpdGroups.xaml
    /// </summary>
    public partial class StudUpdGroups : Page, INotifyPropertyChanged
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly StudentUpdate _studUpd;
        private EFStudent _stud;
        private readonly RepoPack _repoPack;
        private GroupModel _selectedGroup;
        private ICollection<GroupModel> _groups;

        public event PropertyChangedEventHandler? PropertyChanged;

        public ICollection<GroupModel> Groups
        {
            get { return _groups; }
            set
            {
                _groups = value;
       
            }
        }

        public ICollection<GroupModel> DBGroups => GetDBGroupModels();
 
        public GroupModel SelectedGroup
        {
            get
            { return _selectedGroup; }
        }

        public IEnumerable<string> ActivityForms => EnumHelper.GetActivityForms();

        public IEnumerable<string> Codes => EnumHelper.GetCodes();


        public StudUpdGroups(Upd_Del_Window updDelWindow, StudentUpdate studUpd, EFStudent stud, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _stud = stud;
            _groups = GetGroupModels();
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
            _studUpd = studUpd;
        }

        private List<GroupModel> GetDBGroupModels()
        {
            var groups = new List<GroupModel>();
            foreach (var item in _repoPack.GruRepo.GetAll())
            {
                groups.Add(new GroupModel()
                {
                    SCode = item.SCode,
                    ActivityForm = item.ActivityForm,
                    ID = item.ID
                });
            }
            return groups;
        }

        private List<GroupModel> GetGroupModels()
        {
            var groups = new List<GroupModel>();
            foreach (var item in _stud.Groups)
            {
                groups.Add(new GroupModel()
                {
                    SCode = item.SCode,
                    ActivityForm = item.ActivityForm,
                    ID = item.ID
                });
            }
            return groups;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
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
            //
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

            _repoPack.GruStudRepo.Add(
                new GroupStudent { GroupId = selected.ID, StudentId = _stud.ID });
            _repoPack.GruStudRepo.Save();
        }
    }
}
