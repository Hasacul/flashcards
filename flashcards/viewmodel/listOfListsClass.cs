using Flashcards.files;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Flashcards.viewmodel
{
    public class listOfListsClass
    {
        protected string _profile;
        protected fileManager _FM;

        public ObservableCollection<string> ListViewItems
        {
            get; set;
        }

        public listOfListsClass()
        {
            ListViewItems = new ObservableCollection<string>();
            _FM = new fileManager();
            loginViewModel loginVM = new loginViewModel();
            _profile = loginVM.getLoginUserName();
            addFilesToList(_FM.getFiles(_profile));
        }

        public void addFilesToList(List<string> files)
        {
            foreach (string str in files)
            {
                ListViewItems.Add(str);
            }
        }

        public string getActiveProfile()
        {
            return _profile;
        }
    }
}
