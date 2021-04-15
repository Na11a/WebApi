using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
using WebApi.Models;

namespace WebApi.TaskItem
{
    public class TasktoDoContext : DbContext
    {

        public DbSet<TasktoDo> TasktoDos { get; set; }
        public DbSet<TaskList> TaskList { get; set; }
        public TasktoDoContext(DbContextOptions<TasktoDoContext> options) : base(options)
        { }
    }
}

