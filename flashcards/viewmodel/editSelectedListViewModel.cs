using Flashcards.files;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
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
            observableList = new ObservableCollection<pairWords>(pairListFromFile);
        }

        public void addPair(string userInput1, string userInput2)
        {
            if (Regex.IsMatch(userInput1, "^[^!@#$%&*()~{}:;\"\\/\\\\><+=']+$") && Regex.IsMatch(userInput2, "^[^!@#$%&*()~{}:;\"\\/\\\\><+=']+$"))
            {
                lm.addItem(new pairWords(userInput1, userInput2));
            }
            else
            {
                MessageBox.Show("Invalid characters in add new words.");
            }
        }

        public void showList (ListView Wordlist)
        {
            observableList.Clear();
            foreach (pairWords opairWords in lm.getList())
            {
                observableList.Add(opairWords);
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
