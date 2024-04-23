namespace PFE_API.Model
{
    public class Message
    {
        public string Text { get; set; }
        public string IDsender { get; set; }
        public string IDreceiver { get; set; }
        public DateTime Date { get; set; }

        public Message(string text, string iDsender, string iDreceiver, DateTime date)
        {
            Text = text;
            IDsender = iDsender;
            IDreceiver = iDreceiver;
            Date = date;
        }

        public Message()
        {
        }
    }
}
