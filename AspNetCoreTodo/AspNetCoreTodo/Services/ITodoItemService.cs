using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspnetCoreTodo.Models;

namespace AspNetCoreTodo.Services
{
    public interface ITodoItemService
    {
        Task<TodoItem[]> GetIncompleteItemsAsync();
    }
}