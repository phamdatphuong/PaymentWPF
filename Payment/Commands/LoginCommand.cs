using Payment.Models;
using Payment.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Windows;
using System.Windows.Input;

namespace Payment.Commands
{
    public class LoginCommand : ICommand
    {
        LoginViewModel _viewModel;
        public LoginCommand(LoginViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            bool isSuccessStatusCode = false;
            ResponseLoginModel result = new ResponseLoginModel();
            HttpMessageHandler handler = new HttpClientHandler();

            var httpClient = new HttpClient(handler)
            {
                BaseAddress = new Uri(Utilities.Constants.URL_API_LOGIN),
                Timeout = new TimeSpan(0, 2, 0)
            };

            httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

            var stringContent = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("email", _viewModel.Email),
                new KeyValuePair<string, string>("password", _viewModel.Password),
            });
            HttpResponseMessage response = httpClient.PostAsync(Utilities.Constants.URL_API_LOGIN, stringContent).Result;
            isSuccessStatusCode = response.IsSuccessStatusCode;

            if (isSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                _viewModel.mainViewModel.ResponseLoginModel = JsonSerializer.Deserialize<ResponseLoginModel>(data);
                _viewModel.mainViewModel.SelectedViewModel = new GeneratePaymentViewModel(_viewModel.mainViewModel);
                //_viewModel.mainViewModel.ShowGenerateView = Visibility.Visible;
                //_viewModel.mainViewModel.ShowLoginView = Visibility.Collapsed;
            }
            else
            {
                MessageBox.Show("Login Fail");
            }
        }
    }
}
