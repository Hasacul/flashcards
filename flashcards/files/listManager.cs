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
    }
}
