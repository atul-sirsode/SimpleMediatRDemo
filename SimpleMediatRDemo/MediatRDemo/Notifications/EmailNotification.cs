using MediatR;

namespace MediatRDemo.Notifications
{
    public class EmailNotification : INotificationHandler<Email>
    {
        private readonly ILogger<EmailNotification> _logger;

        public EmailNotification(ILogger<EmailNotification> logger)
        {
            _logger = logger;
        }
        public async Task Handle(Email notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Sending email to {notification.To} from {notification.From} with body {notification.Body}");
            await Task.CompletedTask;
        }
    }
}
