namespace MasterDatabaseFirst.Models
{
    public class DisplayTables
    {
        public List<User> users {  get; set; }
        public List<ExpertProfile> experts { get; set; }
        public List<JobSeekerProfile> seekers { get; set; }
        public List<Notification> notifications { get; set; }
        public List<UserSetting> settings { get; set; }

    }
}
