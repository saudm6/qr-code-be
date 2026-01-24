using qr_code.Domain.Entities;

namespace qr_code.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<EventOrganizer> EventOrganizers { get; }
    DbSet<EventGenre> EventGenres { get; }

    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
