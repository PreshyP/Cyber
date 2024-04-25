
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using MyLoginApp.Models;
using MyLoginApp.Services;
using MyLoginApp.UserControl;
using MyLoginApp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MyLoginApp.ViewModels
{
    public partial class LoginPageViewModel: BaseViewModel
    {
        [ObservableProperty]
        private string _userName;
        // private string _email;
        [ObservableProperty]
        private string _password;

        readonly ILoginRepository _loginRepository = new LoginService();


        [ICommand]

        public  async  void Login()
        {
        if (!string.IsNullOrWhiteSpace(UserName)&& !string.IsNullOrWhiteSpace(Password))
            {
                UserInfo userInfo = await _loginRepository.Login(UserName, Password);
                 if (Preferences.ContainsKey(nameof(App.UserInfo)))
                {
                    Preferences.Remove (nameof(App.UserInfo));
                }
                string userDetails = JsonSerializer.Serialize(userInfo);

                Preferences.Set (nameof(App.UserInfo), userDetails); 
                App.UserInfo = userInfo;

                AppShell.Current.FlyoutHeader = new FlyoutHeaderControl();

                await Shell.Current.GoToAsync($"//{nameof(HomePage)}");
            }
        }

        


        }
    }

