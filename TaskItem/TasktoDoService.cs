using System.Threading.Tasks;
using System.Data.Common;
using System.Net;
using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using WebApi.Models;
using Microsoft.EntityFrameworkCore;
namespace WebApi.TaskItem

{
    public class TasktoDoService
    {
        TasktoDoContext _context;
        public TasktoDoService(TasktoDoContext context) => this._context = context;

        public void CreateTasktoDo(TasktoDo item)
        {

            _context.TasktoDos.Add(item);
            _context.SaveChanges();
        }
        public void UpdateTasktoDo(TasktoDo item)
        {
            using (_context)
            {
                _context.TasktoDos.Update(item);
                _context.SaveChanges();
            }
        }
        public void DeleteTasktoDo(int id)
        {
            TasktoDo item = _context.TasktoDos.Find(id);
            _context.Remove(item);
            _context.SaveChanges();
        }
        public List<TasktoDo> ReadTasktoDo()
        {

            List<TasktoDo> tasks = _context.TasktoDos.ToList();
            return tasks;

        }
        public TasktoDo GetTasktoDoById(int id)
        {
            return _context.TasktoDos.Find(id);
        }
        public Dashboard GetDashboard()
        {
            List<TaskListDTO> taskLists = new List<TaskListDTO>();
            Dashboard dashboard = new Dashboard();
            dashboard.TaskListDTOs = taskLists;

            int tasksToday = _context.TasktoDos.
            Where(task => task.DueDate.Value.Date == DateTime.Today).
            Count();
            dashboard.TasksForToday = tasksToday.Equals(null) ? 0 : tasksToday;

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                _context.Database.OpenConnection();
                command.CommandText = "select t.task_list_id,Count(t.done),l.title from taskto_dos t right join task_list l on  t.task_list_id=l.id where t.done=false group by l.id,t.task_list_id;";
                using (var result = command.ExecuteReader())
                {
                    while (result.Read())
                    {
                        taskLists.Add(new TaskListDTO()
                        {
                            Id = result.GetInt32(0),
                            NoneTask = result.GetInt32(1),
                            Title = result.GetString(2)
                        });
                    }
                }
            }
            return dashboard;
        }
        // public List<TasktoDo> GetTodayTasks()
        // {
        //     return _context.TasktoDos.
        //     Where(t => t.DueDate.Date == DateTime.Today).
        //     Include(t => t.TaskList).
        //     ToList();
        // }
        public List<TasktoDo> GetTasksByListId(int listid, bool all = false)
        {
            if (all)
            {
                return _context.TasktoDos.Where(t => t.TaskListId == listid)
                .ToList();
            }
            return _context.TasktoDos.Where(t => t.TaskListId == listid)
                .Where(t => t.Done == false).ToList();
        }
    }
}