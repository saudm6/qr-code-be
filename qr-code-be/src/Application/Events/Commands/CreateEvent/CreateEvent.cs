using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using qr_code_be.Application.Common.Interfaces;
using qr_code_be.Domain.Entities;
//using qr_code_be.Domain.Entities.Events;


namespace qr_code_be.Application.Events.Commands.CreateEvent;

public class CreateEvent : IRequest<int>
{
    public required string EventTitle { get; set; }
    public required string Description { get; set; }
    public required string Genre { get; set; }
    public required DateTime EventDate { get; set; }
}

//public class  CreateEventHandler : IRequestHandler<CreateEvent, int>
//{
//    private readonly IApplicationDbContext _context;

//    public CreateEventHandler(IApplicationDbContext context)
//    {
//        _context = context;
//    }

//    public async Task<int> Handle(CreateEvent request, CancellationToken cancellationToken)
//    {
//        var eventEntity = new Events
//        {
//            Title = request.EventTitle,
//            Description = request.Description,
//            Genre = request.Genre,
//            EventDate = request.EventDate,
//            EventOrganizerId = Guid.NewGuid()
//        };

//        _context.Events.Add(eventEntity);
//        await _context.SaveChangesAsync(cancellationToken);

//        return eventEntity.Id;

//    }
    
//}



//public async Task<int> Handle(CreateEvent createEvent, CancellationToken cancellationToken)
//    {

//    }
