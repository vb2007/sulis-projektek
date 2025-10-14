using DiakokTantargyak_VB_Lib;

namespace DiakokTantargyak_VB;

class Program
{
    static void Main(string[] args)
    {
        School school = new();
        
        //adatok hozzáadása
        school.AddStudent("Kovács János", 1);
        school.AddStudent("Nagy Anna", 2);
        school.AddStudent("Szabó Péter", 3);
        school.AddStudent("Kiss Mária", 4);
        school.AddStudent("Tóth Gábor", 5);
        
        school.AddSubject("Matematika", 1);
        school.AddSubject("Fizika", 2);
        school.AddSubject("Kémia", 3);
        school.AddSubject("Biológia", 4);
        school.AddSubject("Informatika", 5);
        
        //jegyeket nem kért a feladat, de ha már egyszer van rá lehetőség a class miatt...
        Student student1 = school[1]!;
        student1?.AddGrade("Matematika", 5);
        student1?.AddGrade("Matematika", 4);
        student1?.AddGrade("Fizika", 3);
        
        Student student2 = school[2]!;
        student2?.AddGrade("Kémia", 5);
        student2?.AddGrade("Biológia", 4);
        
        //indexerek tesztelése
        Console.WriteLine("Diák indexerek tesztelése:");
        for (int i = 1; i <= 5; i++)
        {
            Student student = school[i]!;
            Console.WriteLine($"Diák neve {i}: {student.Name}");
            
            Console.WriteLine("\tJegyek:");
            foreach (var subject in student.Grades)
            {
                Console.WriteLine($"\t\t{subject.Key}: {string.Join(", ", subject.Value)}");
            }
        }
        
        Console.WriteLine("Tantárgy indexerek tesztelése:");
        string[] subjectNames = { "Matematika", "Fizika", "Kémia", "Biológia", "Informatika" };
        foreach (string subjectName in subjectNames)
        {
            Subject subject = school[subjectName]!;
            Console.WriteLine($"Subject: {subject.Name}, ID: {subject.Id}");
        }
        
        //negatív tesztek
        Console.WriteLine("Nem létező diák Id:");
        Student? nonExistentStudent = school[999];
        Console.WriteLine($"999 Id-val rendelkező diák: {(nonExistentStudent == null ? "null (helyes)" : nonExistentStudent.Name)}");

        Console.WriteLine("Nem létező tantárgy név:");
        Subject? nonExistentSubject = school["románia"];
        Console.WriteLine($"Nem létező tantárgy név: {(nonExistentSubject == null ? "null (helyes)" : nonExistentSubject.Name)}");
    }
}