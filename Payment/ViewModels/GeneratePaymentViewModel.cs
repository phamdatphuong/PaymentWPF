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
        private MainViewModel mainViewModel;

        public GeneratePaymentViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

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
    }
}
