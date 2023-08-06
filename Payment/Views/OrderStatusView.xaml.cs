using Payment.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
                if(vm.SelectedParameter!=null && vm.SelectedParameter.OrderType==Utilities.TypeOrder.Waiting)
                {
                    vm.mainViewModel.SelectedViewModel = new QrCodeViewModel(vm.mainViewModel, vm.SelectedParameter);
                }
            }
        }
    }
}
