using System;
using System.ComponentModel.DataAnnotations;

namespace TaskManager.Models
{
    public class TaskItems
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public string? Priority { get; set; }
        public bool IsCompleted { get; set; } = false;
    }
}