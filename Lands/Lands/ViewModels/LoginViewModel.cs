using System;
using System.Collections.Generic;
using System.Text;

namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;
    
    class LoginViewModel
    {
        #region Properties
        public string Email
        { get; set; }

        public string Password
        { get; set; }

        public bool IsRunning
        { get; set; }

        public bool IsRemembered
        { get; set; }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if(string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Debe ingresar su correo",
                    "Aceptar");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Debe ingresar su contraseña", 
                    "Aceptar");
                return;
            }

            if(this.Email !="nextore28@gmail.com" || this.Password !="1234")
            {
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Usuario o contraseña incorrectos",
                    "Aceptar");
            }

            await Application.Current.MainPage.DisplayAlert("Bienvenido",
            "Login correcto",
            "Ok");
        }
        #endregion
    }
}
