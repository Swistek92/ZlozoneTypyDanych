using System;

enum Gender
{
    M,
    F
}
struct Student
{
    public string Nazwisko;
    public int NrAlbumu;
    public double Ocena;
    public Gender Plec;
}
class Program



{
    static void Main()
    {
        Console.WriteLine($"Stworzymy 5 studnetow podaj ich Nazwiska, nr albumu oraz ocene");

        Student[] grupa = new Student[5];
        for (int i = 0; i < grupa.Length; i++)
        {
            Console.WriteLine($"Student {i + 1}:");
            WypelnijStudenta(ref grupa[i]);
        }
        Console.WriteLine("Informacje o studentach:");
        foreach (Student student in grupa)
        {
            WyswietlStudenta(student);
        }
        double srednia = ObliczSrednia(grupa);
        Console.WriteLine($"średnia ocen: {srednia}");
        Console.ReadKey();
    }



    static void WypelnijStudenta(ref Student student)
    {
        Console.WriteLine("Podaj nazwisko studenta:");
        student.Nazwisko = Console.ReadLine();

        Console.WriteLine("Podaj numer albumu:");
        student.NrAlbumu = int.Parse(Console.ReadLine());



        double ocena = PobierzOcene();
        student.Ocena= ocena;   






        string plec = PobierzPlec();
        
        if (plec == "M")
        {
            student.Plec = Gender.M;
        }
        else if (plec == "F")
        {
            student.Plec = Gender.F;
        }
        
        Console.Clear();
    }

   



    static double PobierzOcene()
    {
        Console.WriteLine("Podaj ocenę:");

        double ocena = double.Parse(Console.ReadLine());

        if (ocena >= 2.0 && ocena <= 5.0)
        {
            return ocena;
        }
        else
        {
            Console.WriteLine("niestety ocena musi zawierac sie w przedziale 2.0 a 5.0 prosze podac prawidlowa.");
            return PobierzOcene();
            Console.ReadKey();
        }
    }
    static string PobierzPlec()
    {
        Console.WriteLine("Podaj plec:");
        string plec = Console.ReadLine().ToUpper();

        if (plec == "M" || plec == "F")
        {
            return plec;
        }
        else
        {
            Console.WriteLine("Niepoprawny format płci.");
            return PobierzPlec();
        }

        }


        static double ObliczSrednia(Student[] grupa)
    {
        double sumaOcen = 0.0;

        foreach (Student student in grupa)
        {
            sumaOcen += student.Ocena;
        }

        return sumaOcen / grupa.Length;
    }





    static void WyswietlStudenta(Student student)
    {
        Console.WriteLine($"Nazwisko: {student.Nazwisko}, Nr albumu: {student.NrAlbumu}, Ocena: {student.Ocena}, Płeć: {student.Plec}");
    }

}