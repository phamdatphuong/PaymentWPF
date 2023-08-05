using Payment.Commands;
using Payment.Models;
using Payment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace Payment.ViewModels
{
    public class OrderStatusViewModel : BaseViewModel
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

        private List<OrderDataModel> _orderList;
        public List<OrderDataModel> OrderList
        {
            get
            {
                return _orderList;
            }
            set
            {
                _orderList = value;
                OnPropertyChanged(nameof(OrderList));
            }
        }
        public ICommand ShowQrCodeCommand { get; set; }
        public OrderStatusViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            ShowQrCodeCommand = new ShowQrCodeCommand(this);

            OrderList = new List<OrderDataModel>();
            OrderList.Add(new OrderDataModel
            {
                OrderType = Utilities.TypeOrder.Paid,
                OrderNumber = "123456",
                OrderTime = "21.03.22 - 13:00",
                Money = 20,
                BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/bi_check-lg.png"))
            });
            OrderList.Add(new OrderDataModel
            {
                OrderType = Utilities.TypeOrder.Remove,
                OrderNumber = "123457",
                OrderTime = "22.03.22 - 13:00",
                Money = 22.22,
                BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/ci_close-small.png"))
            });
            OrderList.Add(new OrderDataModel
            {
                OrderType = Utilities.TypeOrder.Waiting,
                OrderNumber = "123457",
                OrderTime = "22.03.22 - 13:00",
                Money = 22.22,
                BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/bx_time-five.png")),
                ShowCancelIcon = true
            });
        }

    }
}
