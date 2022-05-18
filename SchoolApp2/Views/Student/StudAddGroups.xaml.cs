using SchoolApp_EFCore.Models;
using SchoolApp_EFCore.Repositories;
using SchoolApp2.Helpers;
using SchoolApp2.Models;
using SchoolApp2.Views.Shared;
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

namespace SchoolApp2.Views.Student
{
    /// <summary>
    /// Interaction logic for StudAddGroups.xaml
    /// </summary>
    public partial class StudAddGroups : Page
    {

        private readonly Upd_Del_Window _updDelWindow;
        private readonly StudentAdd _studAdd;
        private readonly RepoPack _repoPack;
        private ICollection<Group> _groups;

        public StudAddGroups(Upd_Del_Window updDelWindow, StudentAdd studAdd, RepoPack repoPack, ICollection<Group> groups)
        {
            InitializeComponent();
            _groups = groups;
            _updDelWindow = updDelWindow;
            _studAdd = studAdd;
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
            StudentGroups.Items.Refresh();
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.DataContext = _studAdd;
            _updDelWindow.Content = _studAdd;

        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            _studAdd.Groups = this.Groups;
            StudentGroups.Items.Refresh();
            _updDelWindow.DataContext = _studAdd;
            _updDelWindow.Content = _studAdd;
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


            StudentGroups.Items.Refresh();
        }

        private void StudentGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listbox = (ListBox)sender;
            var item = (Group)listbox.SelectedItem;
            SelectedGroup = item;
        }
    }
}
