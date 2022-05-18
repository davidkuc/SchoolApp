using System;
using System.Collections.Generic;
using EFTeacher = SchoolApp_EFCore.Models.Teacher;
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
    /// Interaction logic for TeaAddGroups.xaml
    /// </summary>
    public partial class TeaAddGroups : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly TeacherAdd _teaAdd;
        private readonly RepoPack _repoPack;
        private ICollection<Group> _groups;

        public TeaAddGroups(Upd_Del_Window updDelWindow, TeacherAdd teaAdd, RepoPack repoPack, ICollection<Group> groups)
        {
            InitializeComponent();
            _groups = groups;
            _updDelWindow = updDelWindow;
            _teaAdd = teaAdd;
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
        }

        public ICollection<Group> DBGroups => (ICollection<Group>)_repoPack.GruRepo.GetAll();

        public ICollection<Group> Groups
        {
            get
            { return _groups; }
            set
            {
                _groups = value;
            }
        }

        public Group SelectedGroup { get; set; }


        private void AddGroups_Del_Button_Click(object sender, RoutedEventArgs e)
        {
            Groups.Remove(SelectedGroup);
            TeacherGroups.Items.Refresh();
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.DataContext = _teaAdd;
            _updDelWindow.Content = _teaAdd;

        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            _teaAdd.Groups = this.Groups;
            TeacherGroups.Items.Refresh();
            _updDelWindow.DataContext = _teaAdd;
            _updDelWindow.Content = _teaAdd;
        }

        private void AddGroups_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Group)DBGroups_ComboBox.SelectedItem;

            var relationExists = Groups.SingleOrDefault(p => p.ID == selected.ID, null) != null ? true : false;
            if (relationExists)
            {
                MessageBox.Show("This student is already assigned to this group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }


            Groups.Add(selected);


            TeacherGroups.Items.Refresh();
        }

        private void TeacherGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var item = (Group)listbox.SelectedItem;
            SelectedGroup = item;
        }
    }
}
