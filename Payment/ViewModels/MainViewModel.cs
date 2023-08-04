using Payment.Commands;
using Payment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Payment.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;
        public BaseViewModel SelectedViewModel
        {
            get { return _selectedViewModel; }
            set
            {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        //private BaseViewModel _selectedViewModelLogin;
        //public BaseViewModel SelectedViewModelLogin
        //{
        //    get { return _selectedViewModelLogin; }
        //    set
        //    {
        //        _selectedViewModelLogin = value;
        //        OnPropertyChanged(nameof(SelectedViewModelLogin));
        //    }
        //}

        //private BaseViewModel _selectedViewModelGenerate;
        //public BaseViewModel SelectedViewModelGenerate
        //{
        //    get { return _selectedViewModelGenerate; }
        //    set
        //    {
        //        _selectedViewModelGenerate = value;
        //        OnPropertyChanged(nameof(SelectedViewModelGenerate));
        //    }
        //}

        private Visibility _showLoginView;
        public Visibility ShowLoginView
        {
            get
            {
                return _showLoginView;
            }
            set
            {
                _showLoginView = value;

                OnPropertyChanged(nameof(ShowLoginView));
            }
        }
        private Visibility _showGenerateView;
        public Visibility ShowGenerateView
        {
            get
            {
                return _showGenerateView;
            }
            set
            {
                _showGenerateView = value;

                OnPropertyChanged(nameof(ShowGenerateView));
            }
        }

        public ResponseLoginModel ResponseLoginModel = new ResponseLoginModel();

        public MainViewModel()
        {
            this.SelectedViewModel = new LoginViewModel(this);
            //this.SelectedViewModelGenerate = new GeneratePaymentViewModel(this);
            //this.ShowLoginView = Visibility.Visible;
            //this.ShowGenerateView = Visibility.Collapsed;
        }
    }
}
