using Flashcards.files;
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
    /// Interaction logic for addWordsView.xaml
    /// </summary>
    public partial class addWordsView : UserControl
    {
        public addWordsView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string blokDodania = textAddInput.Text;
            //showTextContent.Text = blokDodania;
            fileCreator fc = new fileCreator();
            fc.addToContent(blokDodania);
            fc.saveFile("buba");
            //showTextContent.Text = fc.getContents();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fileCreator fc = new fileCreator();
            showTextContent.Text = fc.readFromFile("buba");
        }
    }
}
