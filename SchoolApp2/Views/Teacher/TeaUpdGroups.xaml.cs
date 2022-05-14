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
    /// Interaction logic for TeaUpdGroups.xaml
    /// </summary>
    public partial class TeaUpdGroups : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly TeacherUpdate _teaUpd;

        public TeaUpdGroups(Upd_Del_Window updDelWindow, TeacherUpdate teaUpd)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            _teaUpd = teaUpd;
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            _updDelWindow.Content = _teaUpd;
        }

        private void AddGroup_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void DeleteGroup_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow.Content = _teaUpd;
        }
    }
}
