namespace TodoApi.Dtos
{
    public class UpdateTodoListItem
    {
        public required long ItemId { get; set; }
        public required string Body { get; set; }
    }
}
