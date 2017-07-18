using Flashcards.files;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Flashcards.viewmodel
{
    class editListViewModel
    {
        private string _profile;
        private fileManager _FM;
        public editListViewModel()
        {
            ListViewItems = new ObservableCollection<string>();
            _FM = new fileManager();
            loginViewModel loginVM = new loginViewModel();
            _profile = loginVM.getLoginUserName();
            addFilesToList(_FM.getFiles(_profile));
        }

        public ObservableCollection<string> ListViewItems
        {
            get;set;
        }

        public void addFilesToList(List<string> files)
        {
            foreach(string str in files)
            {
                ListViewItems.Add(str);
            }

        }

        public void getSelectedFile(string v)
        {
            List<string> fileContent = _FM.readFromFile(v, _profile);
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).DataContext=new editSelectedListViewModel();
                }
            }
        }

        public void refreshList()
        {
            ListViewItems.Clear();
            addFilesToList(_FM.getFiles(_profile));
        }

        public void addNewList(string listName)
        {
            _FM.saveFile(listName, _profile);
            refreshList();
        }

        public void removeList(string fileName)
        {
            _FM.deleteFile(_profile, fileName);
            refreshList();
        }
    }
}
