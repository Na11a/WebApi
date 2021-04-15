using System.Collections;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;

using System.Linq;
using WebApi.Models;

namespace WebApi.TaskItem
{
    public class TaskListService
    {
        TasktoDoContext _context;
        public TaskListService(TasktoDoContext context)
        {
            this._context = context;
        }
        public void TaskListCreate(TaskList model)
        {
            _context.TaskList.Add(model);
            _context.SaveChanges();
        }
        public void TaskListUpdate(TaskList model, int id)
        {
            model.Id = id;
            _context.TaskList.Update(model);
            _context.SaveChanges();
        }
        public void TaskListDelete(int id)
        {
            _context.TaskList.Remove(_context.TaskList.Find(id));
        }
        public List<TaskList> TaskListRead()
        {
            return _context.TaskList.ToList();
        }
        public TaskList TastListReadById(int id)
        {
            return _context.TaskList.Find(id);
        } 
        public List<TaskList> GetTasksByListId(int listid, bool all)
        {
            return _context.TaskList.ToList();
        }
       
    }
}