using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoApi.Controllers;
using TodoApi.Models;

namespace TodoApi.Tests;

public class TodoListItemControllerTests
{
    private DbContextOptions<TodoContext> DatabaseContextOptions()
    {
        return new DbContextOptionsBuilder<TodoContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
    }

    private void PopulateDatabaseContext(TodoContext context)
    {
        context.TodoList.Add(new TodoList { Id = 1, Name = "List 1" });
        context.TodoList.Add(new TodoList { Id = 2, Name = "List 2" });

        context.Items.Add(new Item { Id = 1, Body = "Task 1", TodoListId = 1, IsCompleted = false });
        context.Items.Add(new Item { Id = 2, Body = "Task 2", TodoListId = 2, IsCompleted = false });
        context.SaveChanges();
    }

    [Fact]
    public async Task GetTodoListItems_WhenCalled_ReturnsItemsList()
    {
        using (var context = new TodoContext(DatabaseContextOptions()))
        {
            PopulateDatabaseContext(context);

            var controller = new TodoListItemsController(context);

            var result = await controller.GetTodoListItems();

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(2, ((result.Result as OkObjectResult).Value as IList<Item>).Count);
        }
    }

    [Fact]
    public async Task GetTodoListItem_WhenCalled_ReturnsItemById()
    {
        using (var context = new TodoContext(DatabaseContextOptions()))
        {
            PopulateDatabaseContext(context);

            var controller = new TodoListItemsController(context);

            var result = await controller.GetTodoListItem(1);
            var result2 = await controller.GetTodoListItem(2);

            Assert.IsType<OkObjectResult>(result.Result);
            Assert.Equal(1, ((result.Result as OkObjectResult).Value as Item).Id);
        }
    }

    [Fact]
    public async Task PutItem_WhenItemDoesntExist_ReturnsBadRequest()
    {
        using (var context = new TodoContext(DatabaseContextOptions()))
        {
            PopulateDatabaseContext(context);

            var controller = new TodoListItemsController(context);

            var result = await controller.PutTodoListItem(
                new Dtos.UpdateTodoListItem { ItemId = 6, Body = "" }
            );

            Assert.IsType<NotFoundResult>(result);
        }
    }


    [Fact]
    public async Task PutItem_WhenCalled_UpdatesTheItem()
    {
        using (var context = new TodoContext(DatabaseContextOptions()))
        {
            PopulateDatabaseContext(context);

            var controller = new TodoListItemsController(context);

            var item = await context.Items.Where(i => i.Id == 2).FirstAsync();

            var result = await controller.PutTodoListItem(
                new Dtos.UpdateTodoListItem { ItemId = item.Id, Body = "Task 3"}
            );

            Assert.IsType<OkObjectResult>(result);
        }
    }

    [Fact]
    public async Task PostTodoListItem_WhenCalled_CreatesItem()
    {
        using (var context = new TodoContext(DatabaseContextOptions()))
        {
            PopulateDatabaseContext(context);

            var controller = new TodoListItemsController(context);

            var result = controller.PostTodoListItem(new Dtos.CreateTodoListItem { Body = "Task 4", TodoListId = 1 });

            Assert.IsType<CreatedAtActionResult>(result.Result);
            Assert.Equal(3, context.Items.Count());
            
        }
    }

    [Fact]
    public async Task DeleteTodoListItem_WhenCalled_RemovesItem()
    {
        using (var context = new TodoContext(DatabaseContextOptions()))
        {
            PopulateDatabaseContext(context);

            var controller = new TodoListItemsController(context);

            var result = await controller.DeleteTodoListItem(2);

            Assert.IsType<NoContentResult>(result);
            Assert.Equal(1, context.Items.Count());

        }
    }


}
