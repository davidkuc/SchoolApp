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
    /// Interaction logic for StudentUpdate.xaml
    /// </summary>
    public partial class StudentUpdate : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly StudentDetails _studDet;

        public StudentUpdate(Upd_Del_Window updDelWindow, StudentDetails studDet)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _studDet = studDet;
        }

        private void ConfirmUpd_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            _updDelWindow.Content = _studDet;
        }

        private void EditGroups_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new StudUpdGroups(_updDelWindow, this); ;
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _studDet;
        }
    }
}
