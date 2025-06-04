namespace TodoApi.Models
{
    public class Item
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public long TodoListId { get; set; }
        public Boolean IsCompleted { get; set; }

    }
}
