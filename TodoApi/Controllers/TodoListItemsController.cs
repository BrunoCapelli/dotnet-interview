using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi.Dtos;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/todolistitems")]
    [ApiController]
    public class TodoListItemsController : Controller
    {

        private readonly TodoContext _context;

        public TodoListItemsController(TodoContext context)
        {
            _context = context;
        }

        // GET: api/todolistitems
        [HttpGet]
        public async Task<ActionResult<IList<Item>>> GetTodoListItems()
        {
            return Ok(await _context.Items.ToListAsync());
        }

        // GET: api/todolistitems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetTodoListItem(long id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        // PUT: api/todolistitems
        [HttpPut]
        public async Task<ActionResult> PutTodoListItem(UpdateTodoListItem payload)
        {
            var item = await _context.Items.FindAsync(payload.ItemId);

            if (item == null)
            {
                return NotFound();
            }


            item.Body = payload.Body;
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        // PUT: api/todolistitems
        [HttpPut("{id}")]
        public async Task<ActionResult> PutTodoListItemCompleted(long id)
        {
            var item = await _context.Items.FindAsync(id);

            if (item == null)
            {
                return NotFound();
            }

            item.IsCompleted = true;
            await _context.SaveChangesAsync();

            return Ok(item);
        }

        // POST: api/todolistitems
        [HttpPost]
        public async Task<ActionResult<TodoList>> PostTodoListItem(CreateTodoListItem payload)
        {

            var item = new Item { TodoListId = payload.TodoListId, Body = payload.Body };

            _context.Items.Add(item);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTodoListItem", new { id = item.Id }, item);
        }

        // DELETE: api/todolistitems/5
        [HttpDelete]
        public async Task<ActionResult> DeleteTodoListItem(DeleteTodoListItem payload)
        {

            var item = await _context.Items.FindAsync(payload.ItemId);

            if (item == null)
            {
                return NotFound();
            }

            _context.Items.Remove(item);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
        
    }
