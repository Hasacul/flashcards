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
using Flashcards.viewmodel;
using Flashcards.files;

namespace Flashcards.views
{
    /// <summary>
    /// Logika interakcji dla klasy testView.xaml
    /// </summary>
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
