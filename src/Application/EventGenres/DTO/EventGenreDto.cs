using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qr_code.Domain.Entities;

namespace qr_code.Application.EventGenres.DTO;

public class EventGenreDto
{
    public int Id { get; set; }
    public string? GenreName { get; set; }
    public string? GenreDescription { get; set; }


    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EventGenre, EventGenreDto>();
        }
    }
}
