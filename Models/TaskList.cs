using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System;
namespace WebApi.Models
{
    public class TaskList
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<TasktoDo> TasktoDo { get; set; }
    }
   
}