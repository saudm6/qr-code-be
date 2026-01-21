using Microsoft.Extensions.Logging;
using qr_code.Domain.Events;

namespace qr_code.Application.TodoItems.EventHandlers;

public class TodoItemCompletedEventHandler : INotificationHandler<TodoItemCompletedEvent>
{
    private readonly ILogger<TodoItemCompletedEventHandler> _logger;

    public TodoItemCompletedEventHandler(ILogger<TodoItemCompletedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCompletedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("qr_code Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
