using Flashcards.viewmodel;
using System.Windows;
using System.Windows.Controls;

namespace Flashcards.views
{
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
            editSelectedListViewModel eslvm = (editSelectedListViewModel)DataContext;
            eslvm.saveList(wordList);


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
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (wordList.SelectedItem != null)
            {
                editSelectedListViewModel eslvm = (editSelectedListViewModel)DataContext;
                eslvm.removeItem(wordList.SelectedIndex);
                eslvm.showList(wordList);
            }
        }
    }
    }
