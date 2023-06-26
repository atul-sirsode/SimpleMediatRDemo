using MediatR;

namespace MediatRDemo.Notifications
{
    public class Email : INotification
    {
        public string To { get; set; }
        public string Body { get; set; }
        public string From { get; set; }

    }
}
