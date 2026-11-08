namespace MasterCodeFirst.Models
{
    public class UserSkills
    {
        public int UserSkillsId { get; set; }
        public int userId { get; set; }
        public int skillsId { get; set; }
        public User user { get; set; }
        public Skills skills { get; set; }
        public string Proficiency { get; set; }
        public int YearsExperience { get; set; }
    }
}
