﻿using Payment.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Payment.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel() { }
        public MainViewModel mainViewModel;

        public LoginViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            this.mainViewModel.OrderList = new List<Models.OrderDataModel>();

            LoginCommand = new LoginCommand(this);
        }

        public ICommand LoginCommand { get; set; }
        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public SecureString SecurePassword { private get; set; }
    }
}
