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
using System.Windows.Shapes;
using SchoolApp.Models;

namespace SchoolApp.Views
{
    /// <summary>
    /// Interaction logic for StudentsMain.xaml
    /// </summary>
    public partial class StudentsMain : Window
    {
        public StudentsMain()
        {
            InitializeComponent();
            List<Student> students = new List<Student>();
            students.Add(new Student() { ID = 1, Name = "Brian", Course = "Data"});
            students.Add(new Student() { ID = 2, Name = "Gib", Course = "Data" });
            students.Add(new Student() { ID = 3, Name = "Meg", Course = "Data" });
            studentList.ItemsSource = students;
        }

        private void StudentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
