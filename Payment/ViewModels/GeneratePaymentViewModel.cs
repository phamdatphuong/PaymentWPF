using Payment.Commands;
using System.Windows.Input;

namespace Payment.ViewModels
{
    public class GeneratePaymentViewModel : BaseViewModel
    {
        private string _address;
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }

        private string _value;
        public string Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public MainViewModel mainViewModel;
        public ICommand GeneratePaymentCommand { get; set; }

        public GeneratePaymentViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            GeneratePaymentCommand = new GeneratePaymentCommand(this);
        }
    }
}
