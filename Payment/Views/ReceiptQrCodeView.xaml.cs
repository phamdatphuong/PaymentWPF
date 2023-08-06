using Payment.ViewModels;
using System.Windows;
using System.Windows.Input;

namespace Payment.Views
{
    /// <summary>
    /// Interaction logic for ReceiptQrCodeView.xaml
    /// </summary>
    public partial class ReceiptQrCodeView : Window
    {
        public ReceiptQrCodeView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
