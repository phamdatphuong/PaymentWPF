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

        private OrderDataModel _paidOrderData;
        public OrderDataModel PaidOrderData
        {
            get
            {
                return _paidOrderData;
            }
            set
            {
                _paidOrderData = value;
                OnPropertyChanged(nameof(PaidOrderData));
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

        public ICommand ShowGenerateViewCommand;
        public PaidOrderViewModel(MainViewModel mainViewModel, OrderDataModel dataOrder)
        {
            this.mainViewModel = mainViewModel;
            PaidOrderData = dataOrder;
            TransactionID = dataOrder.OrderNumber;
            OrderStatus = TypeOrder.Paid.ToString();
            ShowGenerateViewCommand = new ShowGenerateViewCommand(this);
        }
    }
}
