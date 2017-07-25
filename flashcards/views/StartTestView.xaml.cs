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
    /// Logika interakcji dla klasy StartTestView.xaml
    /// </summary>
    public partial class StartTestView : UserControl
    {
        public StartTestView()
        {
            InitializeComponent();
        }
       
        string[] Pair = new string[2];

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            StartTestViewModel STVM = (StartTestViewModel)DataContext;
            Pair =STVM.newPairTest();
            BoxWord1.Text =Pair[0];
            WrongAnswer.Visibility = Visibility.Hidden;
            answer.Visibility = Visibility.Hidden;
            CorrectAnswer.Visibility = Visibility.Hidden;

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (BoxWord2.Text != null)
            {
                StartTestViewModel STVM = (StartTestViewModel)DataContext;
                bool correct;
                correct = STVM.checkWords(Pair[1], BoxWord2.Text);

                if (correct == true)
                {
                    CorrectAnswer.Visibility = Visibility.Visible;

                }
                else
                {
                    answer.Content = "Correct answer is " + Pair[1];
                    WrongAnswer.Visibility = Visibility.Visible;
                    answer.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
