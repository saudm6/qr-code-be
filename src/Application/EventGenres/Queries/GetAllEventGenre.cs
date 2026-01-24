using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qr_code.Application.Common.Interfaces;
using qr_code.Application.EventGenres.DTO;

namespace qr_code.Application.EventGenres.Queries;

public record GetAllEventGenre : IRequest<List<EventGenreDto>>;

public class GetAllEventGenreHandler : IRequestHandler<GetAllEventGenre, List<EventGenreDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetAllEventGenreHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }


    public async Task<List<EventGenreDto>> Handle(GetAllEventGenre request, CancellationToken cancellationToken)
    {
        return await _context.EventGenres
            .AsNoTracking()
            .ProjectTo<EventGenreDto>(_mapper.ConfigurationProvider)
            .OrderBy(r => r.Id)
            .ToListAsync(cancellationToken);
    }
}
