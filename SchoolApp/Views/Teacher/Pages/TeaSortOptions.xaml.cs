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

namespace SchoolApp.Views.Teacher.Pages
{
    /// <summary>
    /// Interaction logic for TeaSortOptions.xaml
    /// </summary>
    public partial class TeaSortOptions : Page
    {
        private readonly SortOptionsWindow _sortOptionsWindow;
        private readonly TeacherMain _teaMain;

        public TeaSortOptions(SortOptionsWindow sortOptionsWindow, TeacherMain teaMain)
        {
            InitializeComponent();
            _sortOptionsWindow = sortOptionsWindow;
            _teaMain = teaMain;
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            _sortOptionsWindow.Close();
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _sortOptionsWindow.Close();
        }
    }
}
