namespace TodoApi.Dtos
{
    public class CreateTodoListItem
    {
        public required string Body { get; set; }
        public required long TodoListId { get; set; }

    }
}
