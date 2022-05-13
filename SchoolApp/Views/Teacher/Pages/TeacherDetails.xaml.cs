using SchoolApp.Views.Teacher.Pages;
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

namespace SchoolApp.Views.Teacher.Windows
{
    /// <summary>
    /// Interaction logic for TeacherDet.xaml
    /// </summary>
    public partial class TeacherDetails : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly TeacherMain _teaMain;

        public TeacherDetails(Upd_Del_Window updDelWindow, TeacherMain teaMain)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _teaMain = teaMain;
            updDelWindow.Content = this;
            _updDelWindow.Show();
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new TeacherUpdate(_updDelWindow, this);
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow?.Close();
        }
    }
}
