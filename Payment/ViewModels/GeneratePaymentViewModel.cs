using Payment.Commands;
using System.Windows.Input;

namespace Payment.ViewModels
{
    public class GeneratePaymentViewModel : BaseViewModel
    {
        private string _requestNumber;
        public string RequestNumber
        {
            get
            {
                return _requestNumber;
            }
            set
            {
                _requestNumber = value;
                OnPropertyChanged(nameof(RequestNumber));
            }
        }

        private string _amount;
        public string Amount
        {
            get
            {
                return _amount;
            }
            set
            {
                _amount = value;
                OnPropertyChanged(nameof(Amount));
            }
        }

        public MainViewModel mainViewModel;
        public ICommand GeneratePaymentCommand { get; set; }
        public ICommand ShowLoginViewCommand { get; set; }

        public GeneratePaymentViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            GeneratePaymentCommand = new GeneratePaymentCommand(this);
            ShowLoginViewCommand = new ShowLoginViewCommand(this.mainViewModel);
        }
    }
}
