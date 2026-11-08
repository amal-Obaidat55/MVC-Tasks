namespace MasterCodeFirst.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostedAt { get; set; }
        public string Status { get; set; }
        public int userId { get; set; }
        public User user { get; set; }
        public ICollection<JobSkills> jobSkills { get; set; }


    }
}
