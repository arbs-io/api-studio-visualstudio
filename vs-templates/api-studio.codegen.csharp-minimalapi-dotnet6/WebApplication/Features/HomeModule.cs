namespace $ext_safeprojectname$;

using System.Net.Mime;
using Swashbuckle.AspNetCore.Annotations;

public class HomeModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/home", (HttpResponse res) =>
            {
                return Results.Text("Minimal API + Carter = ❤");
            })
            .WithTags("Movies")
            .WithMetadata(new SwaggerOperationAttribute("Lookup a Movie by its Id",
                "\n    GET /Movies/00000000-0000-0000-0000-000000000000"))
            .Produces<ErrorModel>(StatusCodes.Status200OK, contentType: MediaTypeNames.Application.Json)
            .Produces<ErrorModel>(StatusCodes.Status400BadRequest, contentType: MediaTypeNames.Application.Json)
            .Produces<ErrorModel>(StatusCodes.Status404NotFound, contentType: MediaTypeNames.Application.Json)
            .Produces<ErrorModel>(StatusCodes.Status500InternalServerError,
                contentType: MediaTypeNames.Application.Json)
            .AllowAnonymous();

        app.MapPost("/internal/migrate", async (HttpResponse res) =>
        {
            return Results.NotFound();
        });
    }
}
