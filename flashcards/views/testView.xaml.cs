using System.Windows;
using System.Windows.Controls;
using Flashcards.viewmodel;
using Flashcards.files;

namespace Flashcards.views
{
    public partial class testView : UserControl
    {
        public testView()
        {
            InitializeComponent();

        }

        private void StartTestClick(object sender, RoutedEventArgs e)
        {
            testViewModel TV = (testViewModel)DataContext;
            fileManager FM = new fileManager();
            string fileName;
            if (listView.SelectedItem != null)
            {
                fileName=listView.SelectedItem.ToString();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).DataContext = new StartTestViewModel(FM.getWordPairsFromFile(fileName,TV.getActiveProfile()));
                    }
                }
            }
        }
    }
}
