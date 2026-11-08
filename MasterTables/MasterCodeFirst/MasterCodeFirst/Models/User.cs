namespace MasterCodeFirst.Models
{
    public class User
    {
        public int UserId { get; set; }

        public string Email { get; set; } 

        public string PasswordHash { get; set; }

        public string FirstName { get; set; } 

        public string LastName { get; set; } 

        public string Role { get; set; }

        public string Phone { get; set; }

        public string AvatarUrl { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public ICollection<UserSkills> userSkills { get; set; }
        public ICollection<Job> job { get; set; }

    }
}
