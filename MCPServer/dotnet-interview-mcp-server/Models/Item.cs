using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_interview_mcp_server.Models
{
    public class Item
    {
        public long ItemId { get; set; }
        public string Body { get; set; }
        public long TodoListId { get; set; }
        public Boolean IsCompleted { get; set; }


        public override string ToString()
        {
            return "ItemId: " + ItemId +
                " Body: " + Body +
                " ListId: " + TodoListId +
                " Is Completed: " + IsCompleted;
        }
    }
}
