using Payment.Models;
using Payment.ViewModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Payment.Views
{
    /// <summary>
    /// Interaction logic for OrderStatusView.xaml
    /// </summary>
    public partial class OrderStatusView : UserControl
    {
        public OrderStatusView()
        {
            InitializeComponent();
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //show popup PopupSelectTimeView.xaml
        }

        private void btnShowDataRangeView_Click(object sender, RoutedEventArgs e)
        {
            PopupSelectTimeView win = new PopupSelectTimeView();
            win.WindowStyle = WindowStyle.None;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ResizeMode = ResizeMode.NoResize;
            win.ShowDialog();
            //win.Show();
        }

        private void btnQrCodeView_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                OrderStatusViewModel vm = (OrderStatusViewModel)this.DataContext;
                if (vm.SelectedParameter != null && vm.SelectedParameter.OrderType == Utilities.TypeOrder.Waiting)
                {
                    vm.mainViewModel.SelectedViewModel = new QrCodeViewModel(vm.mainViewModel, vm.SelectedParameter);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext != null)
            {
                OrderStatusViewModel vm = (OrderStatusViewModel)this.DataContext;
                if (vm.SelectedParameter != null && vm.SelectedParameter.OrderType == Utilities.TypeOrder.Waiting)
                {
                    //call api remove order
                    bool isSuccessStatusCode = false;
                    ResponseLoginModel result = new ResponseLoginModel();
                    HttpMessageHandler handler = new HttpClientHandler();

                    var httpClient = new HttpClient(handler)
                    {
                        BaseAddress = new Uri(Utilities.Constants.URL_API_CANCEL),
                        Timeout = new TimeSpan(0, 2, 0)
                    };
                    httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", vm.mainViewModel.ResponseLoginModel.access_token);

                    httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");

                    var stringContent = new FormUrlEncodedContent(new[]
                    {
                        new KeyValuePair<string, string>("transaction_id", vm.SelectedParameter.OrderNumber),
                    });
                    HttpResponseMessage response = httpClient.PostAsync(Utilities.Constants.URL_API_CANCEL, stringContent).Result;
                    isSuccessStatusCode = response.IsSuccessStatusCode;

                    if (isSuccessStatusCode)
                    {
                        //var data = response.Content.ReadAsStringAsync().Result;
                        //_viewModel.mainViewModel.ResponseLoginModel = JsonSerializer.Deserialize<ResponseLoginModel>(data);
                        vm.OrderList.Remove(vm.SelectedParameter);
                        vm.mainViewModel.OrderList.Remove(vm.SelectedParameter);
                    }
                    else
                    {
                        MessageBox.Show("Cancel fail Fail");
                    }
                }
            }
        }
    }
}
