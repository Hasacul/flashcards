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
            fileManager fc = new fileManager();
            loginViewModel loginVM = new loginViewModel();
            fc.addToContent(blokDodania);
            fc.saveFile("buba",loginVM.getLoginUserName());
            //showTextContent.Text = fc.getContents();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            fileManager fc = new fileManager();
            loginViewModel loginVM = new loginViewModel();
            //showTextContent.Text = fc.readFromFile("buba", loginVM.getLoginUserName());
        }
    }
}
