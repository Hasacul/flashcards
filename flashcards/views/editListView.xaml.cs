using Flashcards.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Flashcards.views
{
    /// <summary>
    /// Interaction logic for editListView.xaml
    /// </summary>
    public partial class editListView : UserControl
    {
        public editListView()
        {
            InitializeComponent();
        }


        private void editListButton_Click(object sender, RoutedEventArgs e)
        {
            editListViewModel ELV = (editListViewModel)DataContext;
            if (editList.SelectedItem != null)
            {
                ELV.getSelectedFile(editList.SelectedItem.ToString());
            }
        }

        private void addNewListButton_Click(object sender, RoutedEventArgs e)
        {
            editListViewModel ELV = (editListViewModel)DataContext;
            ELV.addNewList(addNewListName.Text);

        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            editListViewModel ELV = (editListViewModel)DataContext;
            if (editList.SelectedItem != null)
            {
                ELV.removeList(editList.SelectedItem.ToString());
            }
        }
    }
}
