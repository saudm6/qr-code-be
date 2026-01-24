using Microsoft.AspNetCore.Http.HttpResults;
using qr_code.Application.EventGenres.Commands;
using qr_code.Application.EventGenres.DTO;
using qr_code.Application.EventGenres.Queries;
//using qr_code.Application.EventGenres.Queries;



namespace qr_code.Web.Endpoints;

public class EventGenre : EndpointGroupBase
{
    public override void Map(RouteGroupBuilder groupBuilder)
    {
        groupBuilder.MapPost("/", CreateEventGenre)
            .WithName(" ")
            .WithOpenApi();

        groupBuilder.MapGet("/{id}", GetEventGenreById)
            .WithName("GetEventGenreById")
            .WithOpenApi();

        groupBuilder.MapGet("/", GetAllEventGenre)
            .WithName("GetAllEventGenre")
            .WithOpenApi();
    }



    public async Task<Created<int>> CreateEventGenre(ISender sender, CreateEventGenre createEventGenre)
    {
        var id = await sender.Send(createEventGenre);

        return TypedResults.Created($"/{nameof(EventGenre)}/{id}", id);
    }

    public async Task<EventGenreDto> GetEventGenreById(ISender sender, int id, CancellationToken cancellationToken)
    {
        return await sender.Send(new GetEventGenreById() { Id = id }, cancellationToken);
    }

    public async Task<List<EventGenreDto>> GetAllEventGenre(ISender sender)
    {
        return await sender.Send(new GetAllEventGenre());
    }


}
