using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flashcards.files
{
    public class listManager
    {
        List<pairWords> listWords = new List<pairWords>();

        public List<pairWords> getList()
        {
            return listWords;
        }
        public void SetList(List<pairWords> l)
        {
            listWords = l;
        }

        public void addItem(pairWords pair)
        {
            pair.word1.ToLower();
            pair.word2.ToLower();
            listWords.Add(pair);
        }

        public void clearList()
        {
            listWords.Clear();
        }

        public void deleteItem(string searchWord1, string searchWord2)
        {
            searchWord1.ToLower();
            searchWord2.ToLower();

            int index = 0;
            foreach (pairWords opairWords in listWords)
            {

                if (opairWords.word1 == searchWord1 || opairWords.word2 == searchWord1)
                {
                    if (opairWords.word1 == searchWord2 || opairWords.word2 == searchWord2)
                    {
                        listWords.RemoveAt(index);
                        break;
                    }
                }
                index++;
            }
        }

        public ObservableCollection<pairWords> getObservablePairWords()
        {
            return new ObservableCollection<pairWords>(listWords);
        }
        
    }
}
