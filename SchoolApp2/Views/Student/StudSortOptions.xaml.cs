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
    /// Interaction logic for StudSortOptions.xaml
    /// </summary>
    public partial class StudSortOptions : Page
    {
        private readonly SortOptionsWindow _sortOptionsWindow;
        private readonly StudentMain _studMain;

        public StudSortOptions(SortOptionsWindow sortOptionsWindow, StudentMain studMain)
        {
            InitializeComponent();
            _sortOptionsWindow = sortOptionsWindow;
            _studMain = studMain;
        }

        private void GoBack_Button_Click(object sender, RoutedEventArgs e)
        {
            _sortOptionsWindow.Close();
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            //
            _sortOptionsWindow.Close();
        }
    }
}
