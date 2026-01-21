using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qr_code.Application.Common.Interfaces;
using qr_code.Application.EventOrganizers.DTO;

namespace qr_code.Application.EventOrganizers.Queries;

public record GetAllEventOrganizer : IRequest<List<EventOrganizerDto>>;


public class GetAllEventOrganizerHandler : IRequestHandler<GetAllEventOrganizer, List<EventOrganizerDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetAllEventOrganizerHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<EventOrganizerDto>> Handle(GetAllEventOrganizer getAllEventOrganizer, CancellationToken cancellationToken)
    {
        return await _context.EventOrganizers
            .AsNoTracking()
            .ProjectTo<EventOrganizerDto>(_mapper.ConfigurationProvider)
            .OrderBy(r => r.EventOrganizerName)
            .ToListAsync(cancellationToken);
    }
}
