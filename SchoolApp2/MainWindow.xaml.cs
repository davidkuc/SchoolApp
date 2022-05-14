using SchoolApp_EFCore.Repositories;
using SchoolApp2.Views.Shared.Pages;
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

namespace SchoolApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly RepoPack _repoPack;

        public MainWindow(RepoPack repoPack)
        {
            InitializeComponent();
            _repoPack = repoPack;
            this.Content = new LoginPage(this, _repoPack);
        }
    }
}
