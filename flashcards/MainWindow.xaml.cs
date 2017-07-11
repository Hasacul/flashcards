using Flashcards.files;
using Flashcards.viewmodel;
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

namespace Flashcards
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void logIn_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new loginViewModel();
        }
        private void logout_Click(object sender, RoutedEventArgs e)
        {
            new loginViewModel().logout();
        }

        private void addList_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new addListViewModel();
        }

        private void editList_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new editListViewModel();
        }

        private void addWords_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new addWordsViewModel();
        }

        public void changeToLoggedInMenu()
        {

            Button btn = (Button)LogicalTreeHelper.FindLogicalNode(StackPanelMain, "loginButton");
            btn.Content = "Log out";
            btn.Click -= new RoutedEventHandler(logIn_Click);
            btn.Click += new RoutedEventHandler(logout_Click);
            DataContext = new addListViewModel();

        }

        public void changeToLoggedOutMenu()
        {

            Button btn = (Button)LogicalTreeHelper.FindLogicalNode(StackPanelMain, "loginButton");
            btn.Content = "Log in";
            btn.Click -= new RoutedEventHandler(logout_Click);
            btn.Click += new RoutedEventHandler(logIn_Click);
            DataContext = new loginViewModel();

        }
    }
}
