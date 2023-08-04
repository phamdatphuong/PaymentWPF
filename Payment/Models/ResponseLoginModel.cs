namespace Payment.Models
{
    public class ResponseLoginModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
    }
}
