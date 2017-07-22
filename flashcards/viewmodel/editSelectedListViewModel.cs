using Flashcards.files;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Flashcards.viewmodel
{
    class testerTextBox
    {
        public string Text { get; set; }
        public string Text2 { get; set; }
        public testerTextBox(string str,string str2)
        {
            Text = str;
            Text2 = str2;
        }
    }
    
    class editSelectedListViewModel
    {
        listManager lm = new listManager();

        public void addPair(string userInput1, string userInput2)
        {

            lm.addItem(new pairWords(userInput1, userInput2));
            
        }
        public void showList (ListView Wordlist)
        {
            Wordlist.Items.Clear();
            foreach (pairWords opairWords in lm.getList())
            {               
                Wordlist.Items.Add(opairWords);
            }
        }
        public void removeItem(int index)
        {
            lm.getList().RemoveAt(index);
            
        }
        public void saveList(ListView Wordlist)
        {
            List<pairWords> changedList = new List<pairWords>();
            foreach (pairWords item in Wordlist.Items)
            {
                
                changedList.Add(item);
            }
            lm.SetList(changedList);
        }
       
    }
}
