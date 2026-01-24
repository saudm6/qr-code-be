using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qr_code.Domain.Entities;

public class EventGenre : BaseAuditableEntity
{
    public required string GenreName { get; set; }
    public required string GenreDescription { get; set; }
}
