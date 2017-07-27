using Flashcards.files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.viewmodel
{
    class startPracticeViewModel
    {
        List<pairWords> practiceList = new List<pairWords>();
        int index;
        public int COWA = 0, COCA = 0;
        public bool StartPractice = false;
        public bool endPractice = false;
        public bool checkedWord = true;
        public bool nextWord = false;
        public startPracticeViewModel(List<pairWords> list)
        {
            practiceList = list;
        }
        public bool checkWords(string ConsoleInput, string UserInput)
        {

            bool correctAnswer = false;
            if (nextWord)
            {
                UserInput.ToLower();
                checkedWord = true;
                if (ConsoleInput == UserInput)
                {
                    correctAnswer = true;
                    practiceList.RemoveAt(index);
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
            if (practiceList.Count != 0)
            {
                StartPractice = true;

                Random random = new Random();
                index = random.Next(0, practiceList.Count);
                randomWord[0] = practiceList[index].word1;
                randomWord[1] = practiceList[index].word2;
            }
            return randomWord;
        }
    }
}
