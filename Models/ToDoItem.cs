using System.ComponentModel.DataAnnotations;

namespace ToDoApi.Models
{
    public class ToDoItem
    {
        public long Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "O título não pode conter mais de 50 caracteres.")]
        public string Title { get; set; }

        [StringLength(50, ErrorMessage = "O título não pode conter mais de 50 caracteres.")]
        public string? Description { get; set; }
        
        [Required]
        public bool IsCompleted { get; set; } = false;
    }
}
