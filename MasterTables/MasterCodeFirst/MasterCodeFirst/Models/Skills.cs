namespace MasterCodeFirst.Models
{
    public class Skills
    {
        public int SkillsId { get; set; }
        public string Name { get; set; }
        public ICollection<JobSkills> jobSkills { get; set; }
        public ICollection<UserSkills> userSkills { get; set; }

    }
}
