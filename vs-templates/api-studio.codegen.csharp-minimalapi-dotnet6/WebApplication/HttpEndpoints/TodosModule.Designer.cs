namespace $ext_safeprojectname$;
public partial class TodosModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/todos", GetTodos);
        app.MapGet("/api/todos/{id}", GetTodo);
        app.MapPost("/api/todos", CreateTodo);
        app.MapPut("/api/todos/{id}/mark-complete", MarkComplete);
        app.MapDelete("/api/todos/{id}", DeleteTodo);
    }
}

public class Todo
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
}