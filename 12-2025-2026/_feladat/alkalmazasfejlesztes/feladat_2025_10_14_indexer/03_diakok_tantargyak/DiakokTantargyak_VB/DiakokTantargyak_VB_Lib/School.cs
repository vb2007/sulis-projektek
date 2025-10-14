namespace DiakokTantargyak_VB_Lib;

public class School
{
    private List<Student> _students = new();
    private List<Subject> _subjects = new();

    public void AddStudent(string name, int id)
    {
        _students.Add(new Student(name, id));
    }

    public void AddSubject(string name, int id)
    {
        _subjects.Add(new Subject(name, id));
    }

    public Student? this[int id]
    {
        get
        {
            if (_students.Any(x => x.Id == id))
                return _students.First(x => x.Id == id);
            return null;
        }
    }

    public Subject? this[string name]
    {
        get
        {
            if (_subjects.Any(x => x.Name == name))
                return _subjects.First(x => x.Name == name);
            return null;
        }
    } 
}