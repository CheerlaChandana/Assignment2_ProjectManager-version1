using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization; // ADD THIS

namespace ProjectManagerApi.Models
{
    public class ProjectTask
    {
        public Guid Id { get; set; }

        [Required]
        public string Title { get; set; }
        
     
        [JsonIgnore] 
        public string DependenciesJson { get; set; } = "[]"; 
        // ----------------------------------------

        public DateTime? DueDate { get; set; }
        public bool IsCompleted { get; set; } = false;

      
        public Guid ProjectId { get; set; }
        
        [JsonIgnore] 
        public Project ParentProject { get; set; } 
    }
}