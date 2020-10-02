using System;
using System.Collections.Generic;


namespace JobUa.Data.Models
{
    public class Employee : User
    {
        public Guid EmployeeID { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Education { get; set; }
        public Gender Gender { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> PreviousJobs { get; set; }
        public List<string> Objectives { get; set; }
        public List<string> Skills { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;

        }
        public int Age()
        {
            var today = DateTime.Today;
            int age = today.Year - Birthday.Year;
            return age;
        }
        public void AddSkill(string Skill)
        {
            Skills.Add(Skill);
        }
        public void AddObjective(string Objective)
        {
            Objectives.Add(Objective);
        }
        public void AddPreviousJob(string PreviousJob)
        {
            PreviousJobs.Add(PreviousJob);
        }
    }
    public enum Gender {Male, Female, Custom }
}