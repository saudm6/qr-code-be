using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qr_code.Domain.Entities;

public class Events: BaseAuditableEntity
{
    public required Guid EventOrganizerId { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime EventDate { get; set; }
    public required string Location { get; set; }
    public required string Genre { get; set; }
}
