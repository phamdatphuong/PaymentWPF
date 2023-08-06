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
    /// Interaction logic for PaidOrderView.xaml
    /// </summary>
    public partial class PaidOrderView : UserControl
    {
        public PaidOrderView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ReceiptQrCodeView win = new ReceiptQrCodeView();
            win.WindowStyle = WindowStyle.None;
            win.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            win.ResizeMode = ResizeMode.NoResize;
            win.DataContext = new ReceiptQrCodeViewModel(((PaidOrderViewModel)this.DataContext).PaidOrderData);
            win.ShowDialog();
        }
    }
}
