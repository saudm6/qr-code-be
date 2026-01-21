using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qr_code.Application.Common.Interfaces;
using qr_code.Application.EventOrganizers.DTO;

namespace qr_code.Application.EventOrganizers.Queries;

public class GetEventOrganizerById : IRequest<EventOrganizerDto>
{
    public int Id { get; set; }
}

public class GetEventOrganizerByIdHandler : IRequestHandler<GetEventOrganizerById, EventOrganizerDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetEventOrganizerByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    // Returns ByID
    public async Task<EventOrganizerDto> Handle(GetEventOrganizerById request, CancellationToken cancellationToken)
    {
        return await _context.EventOrganizers
            .AsNoTracking()
            .Where(r => r.Id == request.Id)
            .ProjectTo<EventOrganizerDto>(_mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken);
    }
}
