using Payment.Commands;
using Payment.Models;
using Payment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
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
        public ICommand ShowGenerateViewCommand { get; set; }
        public OrderStatusViewModel(MainViewModel mainViewModel, string requestNumber, string amount)
        {
            this.mainViewModel = mainViewModel;
            ShowGenerateViewCommand = new ShowGenerateViewCommand(this);

            //code get data API - UnComment when API work
            //if (!string.IsNullOrEmpty(requestNumber))
            //{
            //    var data = GetStatusPayment(this.mainViewModel.ResponseLoginModel.access_token, requestNumber, amount);
            //    if (data != null)
            //    {
            //        this.mainViewModel.OrderList.Add(data);
            //    }
            //    OrderList = new List<OrderDataModel>();
            //    OrderList = this.mainViewModel.OrderList;
            //}

            //Mock Data
            this.mainViewModel.OrderList.Add(new OrderDataModel
            {
                OrderType = Utilities.TypeOrder.Paid,
                OrderNumber = "Pedido #123456",
                OrderTime = "21.03.22 - 13:00",
                Money = "R$20",
                BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/bi_check-lg.png")),
                ShowCancelIcon = false,
                Qr_code = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/wpf_qr-code.png")),
                Paid = "R$20",
                Pix_id = "00020126920014BR.GOV.BCB.PIX01"
            });
            this.mainViewModel.OrderList.Add(new OrderDataModel
            {
                OrderType = Utilities.TypeOrder.Remove,
                OrderNumber = "Pedido #123457",
                OrderTime = "22.03.22 - 13:00",
                Money = "R$21",
                BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/ci_close-small.png")),
                ShowCancelIcon = false,
                Qr_code = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/wpf_qr-code.png")),
                Paid = "R$21",
                Pix_id = "00020126920014BR.GOV.BCB.PIX01"
            });
            this.mainViewModel.OrderList.Add(new OrderDataModel
            {
                OrderType = Utilities.TypeOrder.Waiting,
                OrderNumber = "Pedido #123457",
                OrderTime = "22.03.22 - 13:00",
                Money = "R$22",
                BitmapImage = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/bx_time-five.png")),
                ShowCancelIcon = true,
                Qr_code = new BitmapImage(new Uri("pack://application:,,,/Payment;component/Image/wpf_qr-code.png")),
                Paid = "R$22",
                Pix_id = "00020126920014BR.GOV.BCB.PIX01"
            });
            OrderList = this.mainViewModel.OrderList;
        }

        private OrderDataModel GetStatusPayment(string token, string requestNumber, string amount)
        {
            OrderDataModel param;
            bool isSuccessStatusCode = false;
            ResponseLoginModel result = new ResponseLoginModel();
            HttpMessageHandler handler = new HttpClientHandler();

            var httpClient = new HttpClient(handler);
            httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = httpClient.GetAsync(string.Concat(Utilities.Constants.URL_API_STATUS_PAYMENT, requestNumber)).Result;
            isSuccessStatusCode = response.IsSuccessStatusCode;

            if (isSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                ResponseOrderStatus responseOrder = JsonSerializer.Deserialize<ResponseOrderStatus>(data);
                param = new OrderDataModel
                {
                    OrderType = Utilities.TypeOrder.Waiting,
                    OrderNumber = responseOrder.transaction_id,
                    OrderTime = responseOrder.datetime,
                    Money = responseOrder.transaction_amount,
                    BitmapImage = new BitmapImage(new Uri(responseOrder.image)),
                    ShowCancelIcon = true,
                    Qr_code = new BitmapImage(new Uri(responseOrder.qr_code)),
                    Paid = responseOrder.paid,
                    Pix_id = responseOrder.pix_id
                };
                if (Regex.IsMatch(responseOrder.status, "^PAID"))
                {
                    param.OrderType = TypeOrder.Paid;
                }
                else if (Regex.IsMatch(responseOrder.status, "^AWAITING"))
                {
                    param.OrderType = TypeOrder.Waiting;
                }
                else
                {
                    param.OrderType = TypeOrder.Remove;
                }
            }
            else
            {
                MessageBox.Show("Something Wrong");
            }

            return null;
        }
    }
}
