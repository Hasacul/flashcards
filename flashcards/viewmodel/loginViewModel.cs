using Flashcards.files;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public bool getLoginStatus()
        {
            return _loggedIn;
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
