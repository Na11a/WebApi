using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.TaskItem;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskListController : ControllerBase
    {
        private TaskListService service;
        public TaskListController(TaskListService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TaskList>> GetTaskList()
        {
            return service.TaskListRead();
        }


        [HttpPost("")]
        public void PostTaskList(TaskList model)
        {
            service.TaskListCreate(model);
        }

        [HttpPut("{id}")]
        public IActionResult PutTaskList(int id, TaskList model)
        {
            service.TaskListUpdate(model, id);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult<TaskList> DeleteTaskListById(int id)
        {
            service.TaskListDelete(id);
            return null;
        } 
        [HttpGet("lists/{listid}/tasks")]
        public ActionResult<IEnumerable<TaskList>> GetTasksById(int listid){
            return service.GetTasksByListId(listid,true);
        }
    }
}