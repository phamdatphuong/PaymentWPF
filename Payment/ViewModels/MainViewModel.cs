using Payment.Models;
using System.Collections.Generic;
using System.Windows;

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

        public List<OrderDataModel> OrderList;

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
            OrderList = new List<OrderDataModel>();
        }
    }
}
