using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qr_code.Application.Common.Interfaces;
using qr_code.Domain.Entities;

namespace qr_code.Application.EventOrganizers.Commands;

public class CreateEventOrganizer : IRequest<int>
{
    public required string EventOrganizerName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }
    public required int EventOrganizerCivilId { get; set; }
    public required DateOnly DateofBirth { get; set; }
}

public class CreateEventOrganizerHandler : IRequestHandler<CreateEventOrganizer, int>
{
    private readonly IApplicationDbContext _context;

    public CreateEventOrganizerHandler(IApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<int> Handle(CreateEventOrganizer request, CancellationToken cancellationToken)
    {

        var eventOrganizerEntity = new EventOrganizer
        {
            EventOrganizerName = request.EventOrganizerName,
            EventOrganizerEmail = request.Email,
            EventOrganizerPhoneNumber = request.PhoneNumber,
            EventOrganizerCivilId = request.EventOrganizerCivilId,
            EventOrganizerDateofBirth = request.DateofBirth
        };

        _context.EventOrganizers.Add(eventOrganizerEntity);

        await _context.SaveChangesAsync(cancellationToken);

        return eventOrganizerEntity.Id;

    }
}
