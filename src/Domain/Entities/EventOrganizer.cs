using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qr_code.Domain.Entities;

public class EventOrganizer : BaseAuditableEntity
{
    public required string EventOrganizerName { get; set; }
    public required string EventOrganizerEmail { get; set; }
    public required string EventOrganizerPhoneNumber { get; set; }
    public required DateOnly EventOrganizerDateofBirth { get; set; }
    public required int EventOrganizerCivilId { get; set; }
}
