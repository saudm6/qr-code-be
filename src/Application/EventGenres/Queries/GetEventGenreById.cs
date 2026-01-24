using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qr_code.Application.Common.Interfaces;
using qr_code.Application.EventGenres.DTO;

namespace qr_code.Application.EventGenres.Queries;

public class GetEventGenreById : IRequest<EventGenreDto>
{
    public int Id { get; set; }
}

public class GetEventGenreByIdHandler: IRequestHandler<GetEventGenreById, EventGenreDto>
{
    private readonly IMapper _mapper;
    private readonly IApplicationDbContext _context;

    public GetEventGenreByIdHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<EventGenreDto> Handle(GetEventGenreById request, CancellationToken cancellationToken)
    {
        return await _context.EventGenres
            .AsNoTracking()
            .Where(r => r.Id == request.Id)
            .ProjectTo<EventGenreDto>(_mapper.ConfigurationProvider)
            .SingleAsync(cancellationToken);
    }
}

