namespace Payment.Models
{
    public class ResponseOrderStatus
    {
        public string transaction_id {  get; set; }
        public string qr_code { get; set; }
        public string image { get; set; }
        public string transaction_amount { get; set; }
        public string status { get; set; }
        public string paid { get; set; }
        public string pix_id { get; set; }
        public string datetime { get; set; }
    }
}
