using Flashcards.files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.viewmodel
{
    public class StartTestViewModel
    {
        public StartTestViewModel(List<pairWords> list)
        {

        }
        public bool checkWords(string ConsoleInput, string UserInput)
        {
            bool correctAnswer=false;
            UserInput.ToLower();
            if(ConsoleInput == UserInput)
            {
                correctAnswer = true;
                return correctAnswer;
            }
            return correctAnswer;
        }

        public string[] newPairTest()
        {
            int index;
            string[] randomWord = new string[2];
            Random random = new Random();

            index = random.Next(0, 10);

            randomWord[0] = "a";
            randomWord[1] = "b";
            return randomWord;

        }
        
       
    }
}
