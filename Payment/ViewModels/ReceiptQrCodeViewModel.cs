using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace Payment.ViewModels
{
    public class ReceiptQrCodeViewModel : BaseViewModel
    {
        public string Amount { get; set; }
        public string OrderNumber { get; set; }
        public BitmapImage QrCode { get; set; }
        public string Time { get; set; }

        public ReceiptQrCodeViewModel() { }
        public ReceiptQrCodeViewModel(Models.OrderDataModel paidOrderData)
        {
            Amount = paidOrderData.Paid;
            OrderNumber = paidOrderData.OrderNumber;
            QrCode = paidOrderData.Qr_code;
            Time = paidOrderData.OrderTime;
        }
    }
}
