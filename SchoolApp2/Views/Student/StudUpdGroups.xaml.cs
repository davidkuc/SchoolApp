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

namespace SchoolApp2.Views.Student
{
    /// <summary>
    /// Interaction logic for StudUpdGroups.xaml
    /// </summary>
    public partial class StudUpdGroups : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly StudentUpdate _studUpd;
        private  EFStudent _stud;
        private readonly RepoPack _repoPack;
        private Group _selectedGroup;

        public StudUpdGroups(Upd_Del_Window updDelWindow, StudentUpdate studUpd, EFStudent stud, RepoPack repoPack)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _stud = stud;
            _repoPack = repoPack;
            _updDelWindow.Content = this;
            _updDelWindow.DataContext = this;
            _studUpd = studUpd;
        }

        public Group SelectedGroup
        {
            get
            { return _selectedGroup; }
        }

        private void UpdGroups_Del_Button_Click(object sender, RoutedEventArgs e)
        {

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
            var item = (Group)listbox.SelectedItem;
            _selectedGroup = item;
        }
    }
}
