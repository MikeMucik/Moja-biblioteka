namespace MojaBiblioteka
{
    public class Ksiazka : NastepneId
    {
        //public int Id { get; set; }
        public string Tytul { get; set; }
        public string Autor { get; set; }
        public int DataPublikacja { get; set; }
        public bool CzyPrzeczytana { get; set; }
        public Ksiazka(int id, string tytul, string autor, int dataPublikacji, bool czyPrzeczytana)
        {
            Id = id;
            Tytul = tytul;
            Autor = autor;
            DataPublikacja = dataPublikacji;
            CzyPrzeczytana = czyPrzeczytana;
        }
        public void WyswietlInformacjeOKsizce()
        {
            string przeczytana = CzyPrzeczytana ? "Przeczytana" : "Nieprzeczytana";
            Console.WriteLine($"Id: {Id} Tytuł: {Tytul}, Autor: {Autor}, Data publikacji: {DataPublikacja}, Status: {przeczytana}");
        }
    }
    public class NastepneId
    {
        public int Id { get; set; }
    }
}