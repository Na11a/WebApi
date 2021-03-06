using System.Security.Cryptography.X509Certificates;
using System.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.TaskItem;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasktoDoController : ControllerBase
    {
        private TasktoDoService service;
        public TasktoDoController(TasktoDoService service)
        {
            this.service = service;
        }

        [HttpGet("")]
        public ActionResult<IEnumerable<TasktoDo>> GetTasktoDos()
        {
            return service.ReadTasktoDo();
        }

        [HttpGet("{id}")]
        public ActionResult<TasktoDo> GetTasktoDoById(int id) => service.GetTasktoDoById(id);

        [HttpPost("")]
        public TasktoDo PostTasktoDo(TasktoDo model)
        {
            service.CreateTasktoDo(model);
            return model;
        }

        [HttpPut("{id}")]
        public IActionResult PutTasktoDo(int id, TasktoDo model)
        {
            service.UpdateTasktoDo(model);
            return Ok(model);
        }

        [HttpDelete("{id}")]
        public ActionResult<TasktoDo> DeleteTasktoDoById(int id)
        {
            service.DeleteTasktoDo(id);
            return NoContent();         
        }

        [HttpGet("dashboard/")]
        public ActionResult<Dashboard> GetDashboard()
        {
            return service.GetDashboard();
        }

        // [HttpGet("colections/today")]
        // public ActionResult<IEnumerable<TasktoDo>> GetTodayTask()
        // {
        //     return service.GetTodayTasks();
        // }

        [HttpGet("lists/{listid}/tasks")]
        public ActionResult<IEnumerable<TasktoDo>> GetTasksById(int listid, bool all)
        {
            return service.GetTasksByListId(listid, all);
        }
    }
}
