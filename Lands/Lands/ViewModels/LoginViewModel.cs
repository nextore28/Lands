namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class LoginViewModel : BaseViewModel
    {

        #region Attributes
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        { get; set; }

        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        { get; set; }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.IsRemembered = true;
            this.isEnabled = true;
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

            this.IsRunning = true;
            this.IsEnabled = false;

            if(this.Email !="nextore28@gmail.com" || this.Password !="1234")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert("Error",
                    "Usuario o contraseña incorrectos",
                    "Aceptar");
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = false;
            this.IsEnabled = true;

            await Application.Current.MainPage.DisplayAlert("Bienvenido",
            "Login correcto",
            "Ok");
        }
        #endregion
    }
}
