namespace FoodShopBilling.Utilities.Requests.Mail
{
    public class MailRequest
    {
        public List<string> To { get; set; } = new();
        public List<string> CC { get; set; } = new();
        public List<string> BCC { get; set; } = new();
        public string Subject { get; set; }
        public string Body { get; set; }
        public string From { get; set; }
        public string Attachment { get; set; } = null;
        public string FileName { get; set; }
        public bool IsRelayServer { get; set; }
    }
}
