using Microsoft.Extensions.Logging;
using qr_code.Domain.Events;

namespace qr_code.Application.TodoItems.EventHandlers;

public class TodoItemCreatedEventHandler : INotificationHandler<TodoItemCreatedEvent>
{
    private readonly ILogger<TodoItemCreatedEventHandler> _logger;

    public TodoItemCreatedEventHandler(ILogger<TodoItemCreatedEventHandler> logger)
    {
        _logger = logger;
    }

    public Task Handle(TodoItemCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("qr_code Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}
