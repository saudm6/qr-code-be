using Microsoft.AspNetCore.Http.HttpResults;
using qr_code.Application.EventOrganizers.Commands;
using qr_code.Application.EventOrganizers.DTO;
using qr_code.Application.EventOrganizers.Queries;

namespace qr_code.Web.Endpoints;

public class EventOrganizer: EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/", CreateEventOrganizer)
            .WithName("CreateEventOrganizer")
            .WithOpenApi();

        groupBuilder.MapGet("/", GetAllEventOrganizer)
            .WithName("GetAllEventOrganizers")
            .WithOpenApi();

        groupBuilder.MapGet("/{id}", GetEventOrganizersById)
            .WithName("GetEventOrganizersById")
            .WithOpenApi();

        groupBuilder.MapDelete("/{id}", DeleteEventOrganizerById)
           .WithName("DeleteEventOrganizerById")
           .WithOpenApi();
    }

    public async Task<Created<int>> CreateEventOrganizer(ISender sender, CreateEventOrganizer createEventOrganizer)
    {
        var id = await sender.Send(createEventOrganizer);

        return TypedResults.Created($"/{nameof(EventOrganizer)}/{id}", id);
    }

    public async Task<List<EventOrganizerDto>> GetAllEventOrganizer(ISender sender)
    {
        return await sender.Send(new GetAllEventOrganizer());
    }

    public async Task<EventOrganizerDto> GetEventOrganizersById(ISender sender, int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetEventOrganizerById() { Id = id }, cancellationToken);
    }

    public async Task<NoContent> DeleteEventOrganizerById(ISender sender, int id, CancellationToken cancellationToken)
    {
        await sender.Send(new DeleteEventOrganizerById(id));
        return TypedResults.NoContent();
    }
}
