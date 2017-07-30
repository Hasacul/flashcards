using Flashcards.viewmodel;
using System.Windows;
using System.Windows.Controls;

namespace Flashcards.views
{
    public partial class loginView : UserControl
    {
        public loginView()
        {
            InitializeComponent();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            string userLogin = loginBox.Text;
            loginViewModel loginVM = new loginViewModel();
            loginVM.setLoggedStatus(userLogin);
        }
    }
}
