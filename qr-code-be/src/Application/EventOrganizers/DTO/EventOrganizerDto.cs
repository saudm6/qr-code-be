using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using qr_code_be.Domain.Entities;

namespace qr_code_be.Application.EventOrganizers.DTO;

public class EventOrganizerDto
{
    public int Id { get; set; }
    public string? EventOrganizerName { get; set; }
    public string? EventOrganizerEmail { get; set; }
    public string? EventOrganizerPhoneNumber { get; set; }
    public int EventOrganizerCivilId { get; set; }
    public DateOnly DateofBirth { get; set; }

    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<EventOrganizer, EventOrganizerDto>();
        }
    }

}
