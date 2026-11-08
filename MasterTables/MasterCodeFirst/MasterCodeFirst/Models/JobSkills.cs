namespace MasterCodeFirst.Models
{
    public class JobSkills
    {
        public bool IsRequired { get; set; }
        public int JobSkillsId { get; set; }

        public int jobId { get; set; }
        public int skillsId { get; set; }
        public Job job { get; set; }
        public Skills skills { get; set; }
    }
}
