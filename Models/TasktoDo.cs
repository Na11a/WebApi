using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System;

namespace WebApi.Models
{
    public class TasktoDo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public bool Done { get; set; }
        public DateTime DueDate { get; set; }
        public TaskList TaskList {get;set;}
        public int TaskListId {get;set;}
    }
    public class Dashboard{
        public int NotToday {get;set;}
        public List<TaskListDTO> TaskListDTOs {get;set;}
    }
    public class TaskListDTO{
        public int Id {get;set;}
        public string Title {get;set;}
        public int NoneTask {get;set;}
    }
}