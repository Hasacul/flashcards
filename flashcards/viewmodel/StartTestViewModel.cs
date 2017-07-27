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
        List<pairWords> testList = new List<pairWords>();
        int index;
        public int COWA=0, COCA=0;
        public bool StartTest = false;
        public bool EndTest = false;
        public bool checkedWord = true;
        public bool nextWord = false;
        public StartTestViewModel(List<pairWords> list)
        {
            testList = list;
        }
        public bool checkWords(string ConsoleInput, string UserInput)
        {
            bool correctAnswer = false;
            if (nextWord)
            {

                UserInput.ToLower();
                testList.RemoveAt(index);
                checkedWord = true;


                if (ConsoleInput == UserInput)
                {
                    correctAnswer = true;
                    COCA++;
                    return correctAnswer;
                }
                COWA++;
            }
            nextWord = false;
            return correctAnswer;

        }


        public string[] newPairTest()
        {
            string[] randomWord = new string[2];
            randomWord[0] = null;
            randomWord[1] = null;
            checkedWord = false;
            nextWord = true;
            if (testList.Count != 0)
            {
                StartTest = true;

                Random random = new Random();
                index = random.Next(0, testList.Count);
                randomWord[0] = testList[index].word1;
                randomWord[1] = testList[index].word2;
            }
            return randomWord;
        } 
        
        
       
    }
}
