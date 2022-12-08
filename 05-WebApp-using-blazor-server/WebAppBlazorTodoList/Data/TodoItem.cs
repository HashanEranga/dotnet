using System;
namespace WebAppBlazorTodoList.Data
{
    public class TodoItem
    {
        public string? Title { get; set; }
        public bool IsItDone { get; set; } = false;
    }
}

