namespace MessagingService.Model
{
    public class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Body { get; set; }
        public DateTime CreatedDate { get; private set; }

        public Message()
        {
            CreatedDate = DateTime.Now;
        }

    }
}
