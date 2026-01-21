using qr_code.Application.TodoLists.Commands.CreateTodoList;
using qr_code.Application.TodoLists.Commands.DeleteTodoList;
using qr_code.Domain.Entities;

using static Testing;

namespace qr_code.Application.FunctionalTests.TodoLists.Commands;

public class DeleteTodoListTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoListId()
    {
        var command = new DeleteTodoListCommand(99);
        await Should.ThrowAsync<NotFoundException>(() => SendAsync(command));
    }

    [Test]
    public async Task ShouldDeleteTodoList()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        await SendAsync(new DeleteTodoListCommand(listId));

        var list = await FindAsync<TodoList>(listId);

        list.ShouldBeNull();
    }
}
