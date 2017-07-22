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
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).DataContext = new editListViewModel();
                }
            }
        }

        private void saveChangesButton_Click(object sender, RoutedEventArgs e)
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).DataContext = new editListViewModel();
                }
            }
        }

        private void addNewPairButton_Click(object sender, RoutedEventArgs e)
        {
            string userInput1 = newPairWord1.Text;
            string userInput2 = newPairWord2.Text;
            editSelectedListViewModel eslvm =(editSelectedListViewModel)DataContext;
            eslvm.addPair(userInput1, userInput2);
            eslvm.showList(wordList);
            /*string word1 = newPairWord1.Text;
            string word2 = newPairWord2.Text;
            editSelectedListViewModel VM = new editSelectedListViewModel();
            VM.addNewItem(wordList, word1, word2);*/

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (wordList.SelectedItem != null)
            {
                editSelectedListViewModel eslvm = (editSelectedListViewModel)DataContext;
                eslvm.removeItem(wordList, wordList.SelectedIndex);
                eslvm.showList(wordList);
            }
        }
    }
    }
