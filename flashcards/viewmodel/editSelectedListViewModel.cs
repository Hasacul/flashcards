using Flashcards.files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flashcards.viewmodel
{
    class editSelectedListViewModel
    {
        listManager lm = new listManager();

        public void addShowPair(string userInput1, string userInput2, ListView list)
        {

            lm.addItem(new pairWords(userInput1, userInput2));
            list.Items.Add(lm.getList());
        }
    }
}
