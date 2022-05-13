﻿using SchoolApp.Views.Accounts;
using SchoolApp.Views.Pages;
using SchoolApp.Views.Student;
using SchoolApp.Views.Teacher.Pages;
using SchoolApp.Views.Teacher.Windows;
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

namespace SchoolApp.Views.Teacher
{
    /// <summary>
    /// Interaction logic for TeachMain.xaml
    /// </summary>
    public partial class TeacherMain : Page
    {
        private readonly MainWindow _mainWindow;
        public TeacherMain(MainWindow window)
        {
            InitializeComponent();
            _mainWindow = window;
        }

        private void TeacherList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Home_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new MainMenuPage(_mainWindow);
        }

        private void Students_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new StudentMain(_mainWindow);
        }

        private void Accounts_Nav_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new AccountsMainPage(_mainWindow);
        }

        private void Logout_Button_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Content = new LoginPage();
        }

        private void SortOptions_Button_Click(object sender, RoutedEventArgs e)
        {
            var sortOptionsWindow = new SortOptionsWindow();
            sortOptionsWindow.Content = new TeaSortOptions(sortOptionsWindow, this);
            sortOptionsWindow.Show();
        }

        private void PrevPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextPage_Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TeacherDetails_Button_Click(object sender, RoutedEventArgs e)
        {
            var updDelWindow = new Upd_Del_Window();
            updDelWindow.Content = new TeacherDetails(updDelWindow, this);
            updDelWindow.Show();
        }
    }
}
