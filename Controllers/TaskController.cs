using Microsoft.AspNetCore.Mvc;
using ToDoApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static readonly List<ToDoItem> Tasks = new List<ToDoItem>();
        private static long _nextId = 1;

        [HttpGet]
        public ActionResult<IEnumerable<ToDoItem>> GetTasks()
        {
            return Ok(Tasks);
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoItem> GetTask(long id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpPost]
        public ActionResult<ToDoItem> PostTask([FromBody] ToDoItem task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            task.Title = task.Title?.Trim();
            task.Description = task.Description?.Trim();

            var existingTask = Tasks.FirstOrDefault(t => t.Title == task.Title);
            if (existingTask != null)
            {
                throw new ExistingTitleException("Uma tarefa com o mesmo título já existe.");
            }

            task.Id = _nextId++;
            Tasks.Add(task);

            return CreatedAtAction(nameof(GetTask), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public ActionResult<ToDoItem> PutTask(long id, [FromBody] ToDoItem task)
        {
            var existingTask = Tasks.FirstOrDefault(t => t.Id == id);

            if (existingTask == null)
            {
                return NotFound();
            }

            existingTask.Title = task.Title?.Trim();
            existingTask.Description = task.Description?.Trim();
            existingTask.IsCompleted = task.IsCompleted;

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<ToDoItem> DeleteTask(long id)
        {
            var task = Tasks.FirstOrDefault(t => t.Id == id);

            if (task == null)
            {
                return NotFound();
            }

            Tasks.Remove(task);
            return NoContent();
        }
    }
}
