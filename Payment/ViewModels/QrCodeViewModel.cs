using Payment.Commands;
using Payment.Models;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Payment.ViewModels
{
    public class QrCodeViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel;
        public OrderDataModel DataOrder;
        public string OrderNumber { get; set; }
        public string Pix { get; set; }
        public string Paid { get; set; }
        public BitmapImage QrCode { get; set; }

        public QrCodeViewModel(MainViewModel mainViewModel, Models.OrderDataModel selectedParameter)
        {
            this.mainViewModel = mainViewModel;
            this.DataOrder = selectedParameter;
            DetailOrderCommand = new DetailOrderCommand(this);
            GeneratePaymentCommand = new GeneratePaymentCommand(this);

            QrCode = selectedParameter.Qr_code;
            Pix = selectedParameter.Pix_id;
            Paid = selectedParameter.Paid;
            OrderNumber = selectedParameter.OrderNumber;
        }
        public ICommand DetailOrderCommand { get; set; }
        public ICommand GeneratePaymentCommand { get; set; }
    }
}
