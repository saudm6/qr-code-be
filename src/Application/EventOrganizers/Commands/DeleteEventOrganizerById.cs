using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qr_code.Application.Common.Interfaces;

namespace qr_code.Application.EventOrganizers.Commands;

public record DeleteEventOrganizerById(int Id) : IRequest;

public class DeleteEventOrganizerByIdHandler : IRequestHandler<DeleteEventOrganizerById>
{
    private readonly IApplicationDbContext _context;

    public DeleteEventOrganizerByIdHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task Handle(DeleteEventOrganizerById request, CancellationToken cancellationToken)
    {
        var entity = await _context.EventOrganizers
            .FindAsync(new object[] { request.Id }, cancellationToken);

        Guard.Against.NotFound(request.Id, entity);

        _context.EventOrganizers.Remove(entity);

        await _context.SaveChangesAsync(cancellationToken);

    }
}

