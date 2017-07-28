using Flashcards.files;
using Flashcards.viewmodel;
using System.Windows;
using System.Windows.Controls;

namespace Flashcards.views
{
    public partial class PracticeView : UserControl
    {
        public PracticeView()
        {
            InitializeComponent();
        }

        private void startPractice_Click(object sender, RoutedEventArgs e)
        {
            practiceViewModel PVM = (practiceViewModel)DataContext;
            fileManager FM = new fileManager();
            string fileName;
            if (listView.SelectedItem != null)
            {
                fileName = listView.SelectedItem.ToString();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).DataContext = new startPracticeViewModel(FM.getWordPairsFromFile(fileName, PVM.getActiveProfile()));
                    }
                }
            }
        }
    }
}
