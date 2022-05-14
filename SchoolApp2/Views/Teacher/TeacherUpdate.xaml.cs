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

namespace SchoolApp2.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeacherUpdate.xaml
    /// </summary>
    public partial class TeacherUpdate : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly TeacherDetails _teaDet;

        public TeacherUpdate(Upd_Del_Window updDelWindow, TeacherDetails teaDet)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _teaDet = teaDet;
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            _updDelWindow.Content = _teaDet;
        }

        private void Update_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            _updDelWindow.Content = _teaDet;
        }

        private void EditGroups_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new TeaUpdGroups(_updDelWindow, this);
        }

        private void EditSubjects_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = new TeaUpdateSubjects(_updDelWindow, this);
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _teaDet;
        }
    }
}
