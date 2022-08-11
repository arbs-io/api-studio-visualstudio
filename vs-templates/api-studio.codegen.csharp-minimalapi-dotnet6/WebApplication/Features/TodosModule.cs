namespace $ext_safeprojectname$;
public class TodosModule : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapGet("/api/todos", GetTodos);
        app.MapGet("/api/todos/{id}", GetTodo);
        app.MapPost("/api/todos", CreateTodo);
        app.MapPut("/api/todos/{id}/mark-complete", MarkComplete);
        app.MapDelete("/api/todos/{id}", DeleteTodo);
    }

    private static async Task<IResult> GetTodo(int id) => Results.NotFound();

    private async Task<IEnumerable<Todo>> GetTodos() => new List<Todo>();

    private static async Task<IResult> CreateTodo(Todo todo)
    {
        return Results.NotFound();
    }
    private static async Task<IResult> DeleteTodo(int id)
    {
        return Results.NotFound();
    }

    private static async Task<IResult> MarkComplete(int id) => Results.NotFound();
}

public class Todo
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public bool IsComplete { get; set; }
}