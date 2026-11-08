namespace Urhajok_VB_Lib;

public class CrewMember
{
    public string Name { get; set; }
    public string Nationality { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public List<Skill> Skills { get; set; }
    public Spaceship? Spaceship { get; set; }

    public CrewMember(string name, string nationality, DateTime birthDate, string gender, List<Skill>? skills = null)
    {
        Name = name;
        Nationality = nationality;
        BirthDate = birthDate;
        Gender = gender;
        Skills = skills ?? new List<Skill>();
    }
}