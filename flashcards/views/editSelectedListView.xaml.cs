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

namespace Flashcards.views
{
    /// <summary>
    /// Logika interakcji dla klasy editSelectedListView.xaml
    /// </summary>
    public partial class editSelectedListView : UserControl
    {
        public editSelectedListView()
        {
            InitializeComponent();
        }

        private void cancelChangesButton_Click(object sender, RoutedEventArgs e)
        {
            editSelectedListViewModel VM = new editSelectedListViewModel();

            VM.readItems(wordList);
            /*foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).DataContext = new editListViewModel();
                }
            }*/
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            editSelectedListViewModel VM = new editSelectedListViewModel();
            VM.tryIt(wordList);

            /*foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).DataContext = new editListViewModel();
                }
            }*/
        }
        class testerTextBox
        {
            public string Text { get; set; }
            public string Text2 { get; set; }
            public testerTextBox(string str, string str2)
            {
                Text = str;
                Text2 = str2;
            }
        }
        private void addNewPairButton_Click(object sender, RoutedEventArgs e)
        {
            string word1 = newPairWord1.Text;
            string word2 = newPairWord2.Text;
            editSelectedListViewModel VM = new editSelectedListViewModel();
            VM.addNewItem(wordList, word1, word2);

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (wordList.SelectedItem != null)
            {
                editSelectedListViewModel VM = new editSelectedListViewModel();
                VM.removeItem(wordList, wordList.SelectedIndex);
            }
        }
    }
}
