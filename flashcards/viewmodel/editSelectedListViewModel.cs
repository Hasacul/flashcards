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
    
    class editSelectedListViewModel
    {
        protected string _fileName;
        protected string _profile;
        listManager lm = new listManager();
        public ObservableCollection<pairWords> observableList
        {
            get; set;
        }

        public editSelectedListViewModel(string fileName, string profile)
        {
            fileManager FM = new fileManager();
            _fileName = fileName;
            _profile = profile;
            List<pairWords> pairListFromFile = FM.getWordPairsFromFile(_fileName, _profile);
            lm.SetList(pairListFromFile);
            observableList = lm.getObservablePairWords();
        }

        public void addPair(string userInput1, string userInput2)
        { 
            lm.addItem(new pairWords(userInput1, userInput2));
        }

        public void showList (ListView Wordlist)
        {
            lm.clearList();
            foreach (pairWords opairWords in lm.getList())
            {
                lm.addItem(opairWords);
            }
        }

        public void removeItem(int index)
        {
            lm.getList().RemoveAt(index);
        }

        public void saveList(ListView Wordlist)
        {
            List<pairWords> changedList = new List<pairWords>();
            fileManager FM = new fileManager();
            foreach (pairWords item in Wordlist.Items)
            {
                changedList.Add(item);
            }
            lm.SetList(changedList);
            FM.saveWordPairsFromList(_fileName,_profile,lm);
        }
       
    }
}
