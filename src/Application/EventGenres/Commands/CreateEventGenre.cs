using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qr_code.Application.Common.Interfaces;
using qr_code.Domain.Entities;

namespace qr_code.Application.EventGenres.Commands;

public class CreateEventGenre : IRequest<int>
{
    public required string GenreName { get; set; }
    public required string Description { get; set; }
}

public class CreateEventGenreHandler : IRequestHandler<CreateEventGenre, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEventGenreHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEventGenre request, CancellationToken cancellationToken)
    {

        var eventGenreEntity = new EventGenre
        {
            GenreName = request.GenreName,
            GenreDescription = request.Description
        };

        _context.EventGenres.Add(eventGenreEntity);

        await _context.SaveChangesAsync(cancellationToken);

        return eventGenreEntity.Id;

    }
}

