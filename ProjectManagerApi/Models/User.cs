using System.Text.Json.Serialization;

namespace ProjectManagerApi.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        [JsonIgnore] // Prevents the password hash from being sent in API responses
        public string PasswordHash { get; set; }

        // Navigation property: A user can have many projects
        public List<Project> Projects { get; set; } = new List<Project>();
    }
}