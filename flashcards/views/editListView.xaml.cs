using Flashcards.viewmodel;
using System.Windows;
using System.Windows.Controls;

namespace Flashcards.views
{
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
