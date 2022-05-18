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

        public StudAddGroups(Upd_Del_Window updDelWindow, StudentAdd studAdd, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _studAdd = studAdd;
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
        }

        public ICollection<Group> DBGroups => (ICollection<Group>)_repoPack.GruRepo.GetAll();

        public ICollection<Group> Groups { get; set; }

        public Group SelectedGroup { get; set; }
  

        private void AddGroups_Del_Button_Click(object sender, RoutedEventArgs e)
        {
            Groups.Remove(SelectedGroup);
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _studAdd;
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            _studAdd.Groups = this.Groups;
            StudentGroups.Items.Refresh();
            _updDelWindow.Content = _studAdd;
        }

        private void AddGroups_Add_Button_Click(object sender, RoutedEventArgs e)
        {
            var selected = (Group)DBGroups_ComboBox.SelectedItem;

            var relationExists = _repoPack.GruStudRepo.GetByKeys(_stud.ID, selected.ID) != null ? true : false;
            if (relationExists)
            {
                MessageBox.Show("This student is already assigned to this group", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            _repoPack.GruStudRepo.Add(
                new GroupStudent { GroupId = selected.ID, StudentId = _stud.ID });
            _repoPack.GruStudRepo.Save();
            Groups.Add(selected);


            StudentGroups.Items.Refresh();
        }

        private void StudentGroups_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
