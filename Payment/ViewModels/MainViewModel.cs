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

        public ResponseLoginModel ResponseLoginModel = new ResponseLoginModel();

        public MainViewModel()
        {
            this.SelectedViewModel = new LoginViewModel(this);
            OrderList = new List<OrderDataModel>();
        }
    }
}
