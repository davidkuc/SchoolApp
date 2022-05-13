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

namespace SchoolApp.Views.Student.Pages
{
    /// <summary>
    /// Interaction logic for StudentDetails.xaml
    /// </summary>
    public partial class StudentDetails : Page
    {
        private readonly Upd_Del_Window _updDelWindow;

        public StudentDetails(Upd_Del_Window updDelWindow)
        {
            InitializeComponent();
            _updDelWindow = updDelWindow;
            updDelWindow.Content = this;
            _updDelWindow.Show();
        }

        private void DeleteStud_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void UpdateStud_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _updDelWindow?.Close();
        }
    }
}
