using Payment.Commands;
using Payment.Models;
using Payment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Payment.ViewModels
{
    public class PaidOrderViewModel : BaseViewModel
    {
        public MainViewModel mainViewModel;

        private OrderDataModel _selectedParameter;
        public OrderDataModel SelectedParameter
        {
            get
            {
                return _selectedParameter;
            }
            set
            {
                _selectedParameter = value;
                OnPropertyChanged(nameof(SelectedParameter));
            }
        }

        private string _transactionID;
        public string TransactionID
        {
            get
            {
                return _transactionID;
            }
            set
            {
                _transactionID = value;
                OnPropertyChanged(nameof(TransactionID));
            }
        }

        private string _orderStatus;
        public string OrderStatus
        {
            get
            {
                return _orderStatus;
            }
            set
            {
                _orderStatus = value;
                OnPropertyChanged(nameof(OrderStatus));
            }
        }

        public PaidOrderViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            //DetailOrderCommand = new DetailOrderCommand(this);
            SelectedParameter = new OrderDataModel
            {
                OrderType = Utilities.TypeOrder.Paid,
                OrderNumber = "123456",
                OrderTime = "21.03.22 - 13:00",
                Money = 20,
                BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/bi_check-lg.png"))
            };
            TransactionID = "FP62FF82EE72974";
            OrderStatus = TypeOrder.Paid.ToString();
        }
    }
}
