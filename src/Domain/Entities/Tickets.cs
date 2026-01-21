using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qr_code.Domain.Entities;

public class Tickets : BaseAuditableEntity
{
    public required Guid EventId { get; set; }
    public Guid? UserId { get; set; }
    public DateTime? PurchaseDate { get; set; }
    public required string SeatNumber { get; set; }
    public required string TicketName { get; set; }
    public required string TicketDescription { get; set; }
    public required decimal Price { get; set; }
    public required string TicketType { get; set; }
    public required Int16 TotalTicketsAvailable { get; set; }
    public required Int16 TicketsSold { get; set; }
}
