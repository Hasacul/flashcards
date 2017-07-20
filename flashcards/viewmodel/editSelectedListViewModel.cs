using System;
using System.Collections.Generic;
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
        public List<testerTextBox> ListOfElements;

        public void tryIt(ListView LV)
        {
            List<testerTextBox> items = new List<testerTextBox>();
            items.Add(new testerTextBox("item 1","abc"));
            items.Add(new testerTextBox("item 2", "def"));
            items.Add(new testerTextBox("item 3", "ghi"));
            ListOfElements = items;
            LV.ItemsSource = ListOfElements;
        }

        public void readItems(ListView LV)
        {
            foreach(var item in LV.Items)
            {
                
            }
        }

    }
}
