using Payment.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Payment.Models
{
    public class OrderDataModel
    {
        public TypeOrder OrderType { get; set; }
        public string OrderNumber { get; set; }
        public string OrderTime { get; set; }  
        public double Money { get; set; }
        public BitmapImage BitmapImage { get; set; }
        public bool ShowCancelIcon { get; set; }
    }
}
