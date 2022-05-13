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

namespace SchoolApp.Views.StudentViews.Pages
{
    /// <summary>
    /// Interaction logic for StudEditSubj.xaml
    /// </summary>
    public partial class StudUpdGroups : Page
    {
        private readonly Upd_Del_Window _updDelWindow;
        private readonly StudentUpdate _studUpd;

        public StudUpdGroups(Upd_Del_Window updDelWindow, StudentUpdate studUpd)
        {
            InitializeComponent();
           _updDelWindow = updDelWindow;
            _studUpd = studUpd;
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
    }
}
