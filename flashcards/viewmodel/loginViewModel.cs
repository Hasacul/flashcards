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
        private string loginUserName;

        public loginViewModel()
        {
            _loggedIn = false;
        }

        private bool tryToLogin(string login)
        {
            if (login == "user")
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

        public void setLoggedStatus(string login)
        {
            _loggedIn = tryToLogin(login.ToString());

            if (_loggedIn)
            {
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.GetType() == typeof(MainWindow))
                    {
                        (window as MainWindow).changeToLoggedInMenu();
                    }
                }
            }
            else
            {
                fileCreator FC = new fileCreator();
                FC.createNewProfile(login);
            }
        }

        public void logout()
        {
            _loggedIn = false;
            foreach (Window window in Application.Current.Windows)
            {
                if (window.GetType() == typeof(MainWindow))
                {
                    (window as MainWindow).changeToLoggedOutMenu();
                }
            }
        }

        public void createNewUser(string userName)
        {

        }

    }
}
