using Flashcards.files;
using System.Text.RegularExpressions;
using System.Windows;

namespace Flashcards.viewmodel
{
    public class loginViewModel
    {
        private bool _loggedIn;
        static private string loginUserName;

        public loginViewModel()
        {
            _loggedIn = false;
        }

        private bool tryToLogin(string login,fileManager FC)
        {

            if (FC.doesProfileExists(login, FC.getProfiles()))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string getLoginUserName()
        {
            return loginUserName;
        }

        public void setLoggedStatus(string login)
        {
            fileManager FC = new fileManager();
            _loggedIn = tryToLogin(login.ToString(),FC);

            if (_loggedIn)
            {
                loginUserName = login;
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).changeToLoggedInMenu(login);
                    }
                }
            }
            else
            {
                if (Regex.IsMatch(login, "^[a-zA-Z0-9_]+$"))
                {
                    FC.createNewProfile(login);
                    loginUserName = login;
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.GetType() == typeof(MainWindow))
                        {
                            (window as MainWindow).changeToLoggedInMenu(login);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Invalid profile name, profile name should contain only alphanymerical characters and underscore.");
                }
            }
        }

        public void logout()
        {
            _loggedIn = false;
            loginUserName = "";
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).changeToLoggedOutMenu();
                }
            }
        }
    }
}
