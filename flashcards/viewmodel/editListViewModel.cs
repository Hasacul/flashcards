using Flashcards.files;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace Flashcards.viewmodel
{
    class editListViewModel:listOfListsClass
    {
        public editListViewModel()
        {

        }

        public void getSelectedFile(string v)
        {
            List<string> fileContent = _FM.readFromFile(v, _profile);
            if (_profile != null && _profile.Length > 0)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).DataContext=new editSelectedListViewModel(v,_profile);
                    }
                }
            }
            else
            {
                MessageBox.Show("You need to be logged in to edit files.");
            }
        }

        public void refreshList()
        {
            ListViewItems.Clear();
            addFilesToList(_FM.getFiles(_profile));
        }

        public void addNewList(string listName)
        {
            if (_profile != null)
            {
                if (Regex.IsMatch(listName, "^[a-zA-Z0-9_]+$"))
                {
                    _FM.saveTextFile(listName, _profile);
                    refreshList();
                }
                else
                {
                    MessageBox.Show("Invalid file name, it should contain only alphanymerical characters and underscore.");
                }
            }
            else
            {
                MessageBox.Show("You need to be logged in to edit files.");
            }
        }

        public void removeList(string fileName)
        {
            if (_profile != null && _profile.Length > 0)
            {
                _FM.deleteFile(_profile, fileName);
                refreshList();
            }
            else
            {
                MessageBox.Show("You need to be logged in to edit files.");
            }
        }
    }
}
