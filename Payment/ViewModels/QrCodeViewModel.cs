using Payment.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Payment.ViewModels
{
    public class QrCodeViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel;

        public QrCodeViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            DetailOrderCommand = new DetailOrderCommand(this);
        }
        public ICommand DetailOrderCommand { get; set; }
    }
}
