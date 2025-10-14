namespace DiakokTantargyak_VB_Lib;

public class Student
{
    public string Name { get; }
    public int Id { get; }
    public Dictionary<string, List<int>> Grades { get; }

    public Student(string name, int id)
    {
        Name = name;
        Id = id;
        Grades = new Dictionary<string, List<int>>();
    }
    
    public void AddGrade(string subjectName, int grade)
    {
        if (!Grades.ContainsKey(subjectName))
        {
            Grades[subjectName] = new List<int>();
        }
        
        Grades[subjectName].Add(grade);
    }
}