namespace $ext_safeprojectname$;
public partial class TodosModule
{
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