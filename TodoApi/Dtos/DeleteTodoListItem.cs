namespace TodoApi.Dtos
{
    public class DeleteTodoListItem
    {
        public required long ItemId { get; set; }
        public required long TodoListId { get; set; }
    }
}
