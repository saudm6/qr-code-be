using Microsoft.EntityFrameworkCore;
using qr_code_be.Domain.Entities;

namespace qr_code_be.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    DbSet<EventOrganizer> EventOrganizers { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
