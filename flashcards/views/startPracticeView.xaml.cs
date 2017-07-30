using Flashcards.viewmodel;
using System;
using System.Windows;
using System.Windows.Controls;

namespace Flashcards.views
{
    public partial class startPracticeView : UserControl
    {
        public startPracticeView()
        {
            InitializeComponent();
        }
        string[] Pair = new string[2];

        private void check_Click_1(object sender, RoutedEventArgs e)
        {
            startPracticeViewModel SPVM = (startPracticeViewModel)DataContext;
            if (BoxWord2.Text != null && SPVM.endPractice!=true)
            {
                               
                bool correct;
                correct = SPVM.checkWords(Pair[1], BoxWord2.Text);
                countOfCorrectAnswer.Content = "Total correct:" + Convert.ToString(SPVM.COCA);
                countOfWrongAnswer.Content = "Total wrong:" + Convert.ToString(SPVM.COWA);
                if (correct == true)
                {
                    CorrectAnswer.Visibility = Visibility.Visible;
                }
                else
                {
                    if (correct == false && SPVM.StartPractice)
                    {
                        answer.Content = "Correct answer is " + Pair[1];
                        WrongAnswer.Visibility = Visibility.Visible;
                        answer.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        answer.Content = "To start click next!";
                        answer.Visibility = Visibility.Visible;
                    }
                }
            }
        }

    

    private void next_Click(object sender, RoutedEventArgs e)
    {
        startPracticeViewModel SPVM = (startPracticeViewModel)DataContext;
        BoxWord2.IsEnabled = true;
        
        if (SPVM.checkedWord)
        {
            Pair = SPVM.newPairTest();
            if (Pair[0] != null && Pair[1] != null)
            {
                BoxWord1.Text = Pair[0];
                WrongAnswer.Visibility = Visibility.Hidden;
                answer.Visibility = Visibility.Hidden;
                CorrectAnswer.Visibility = Visibility.Hidden;
                BoxWord2.Text = null;
            }
            else
            {
                    SPVM.endPractice = true;
                
            }
        }
            if (SPVM.endPractice)
            {
                MessageBox.Show("You've finished the practice :) try the test!");
            }
        }
    }
}

