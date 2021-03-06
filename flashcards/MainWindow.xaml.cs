﻿using Flashcards.viewmodel;
using System.Windows;
using System.Windows.Controls;

namespace Flashcards
{
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

        private void editList_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new editListViewModel();
        }

        public void changeToLoggedInMenu(string login)
        {

            Button btn = (Button)LogicalTreeHelper.FindLogicalNode(StackPanelMain, "loginButton");
            btn.Content = "Log out";
            btn.Click -= new RoutedEventHandler(logIn_Click);
            btn.Click += new RoutedEventHandler(logout_Click);
            DataContext = new editListViewModel();
            TextBlock loggedAsText=(TextBlock)LogicalTreeHelper.FindLogicalNode(StackPanelMain, "loggedLabel");
            loggedAsText.Text = "Logged: " + login;
        }

        public void changeToLoggedOutMenu()
        {

            Button btn = (Button)LogicalTreeHelper.FindLogicalNode(StackPanelMain, "loginButton");
            btn.Content = "Log in";
            btn.Click -= new RoutedEventHandler(logout_Click);
            btn.Click += new RoutedEventHandler(logIn_Click);
            DataContext = new loginViewModel();
            TextBlock loggedAsText = (TextBlock)LogicalTreeHelper.FindLogicalNode(StackPanelMain, "loggedLabel");
            loggedAsText.Text = "";
        }

        private void test_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new testViewModel();
        }
 
        private void practice_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new practiceViewModel();
        }
    }
}
