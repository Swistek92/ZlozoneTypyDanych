
    struct Student
    {
        public int NumerAlbumu;
        public string Imie;
        public string Nazwisko;
        public Plec Plec;
         public string email;    
    }

    enum Plec
    {
        NieChcePodawac,
        Kobieta,
        Mezczyzna,
    }

    struct PrzedmiotDydaktyczny
    {
        public string Nazwa;
        public string Wykladowca;
        public int IloscGodzin;
    }

    struct Nauczyciel
    {
       
        public string Imie;
        public string Nazwisko;
        public string Tytul;
        public string PrzedmiotyDostepneDoNauczania;
        public Plec Plec;
    }
