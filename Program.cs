
namespace MojaBiblioteka

{
    public class Program
    {
        static void Main(string[] args)
        {
            ZapisDoPliku pliki = new ZapisDoPliku();
            Biblioteka biblioteka = new Biblioteka(pliki);            
            bool wyjscie = true;
            Console.WriteLine("Witaj w aplikacji biblioteka.");
            while (wyjscie)
            {

                Console.WriteLine("\r\nWybierz numer operacji którą chcesz wykonać.");
                Console.WriteLine("1 Dodaj książkę.");
                Console.WriteLine("2 Wyświetl książki.");
                Console.WriteLine("3 Wyjdź z programu.");
                Console.WriteLine("4 Edycja czy książka przeczytana.");
                Console.WriteLine("5 Usuń książkę.");
                Console.WriteLine("Wpisz i liczbę i zatwierdź enterem");
                var operacja = Console.ReadLine();
                switch (operacja)
                {
                    case "1":
                        Console.WriteLine("Wpisz tytuł książki: ");
                        string tytul = Console.ReadLine();
                        Console.WriteLine("Wpisz autora książki: ");
                        string autor = Console.ReadLine();
                        Console.WriteLine("Wpisz rok publikacji książki: ");
                        var rokPS = Console.ReadLine();
                        if (!int.TryParse(rokPS, out int rokPublikacji))
                        {
                            Console.WriteLine("Wpisano błędny rok");
                        };
                        Console.WriteLine("Wpisz książka była przeczytana: ");
                        Console.WriteLine("1 - tak");
                        Console.WriteLine("2 - nie");
                        var czyPS = Console.ReadLine();
                        bool czyPrzeczytana = false;
                        switch (czyPS)
                        {
                            case "1":
                                czyPrzeczytana = true;
                                break;
                            case "2":
                                czyPrzeczytana = false;
                                break;
                            default:
                                Console.WriteLine("Błędny status");
                                break;
                        }
                        int id;
                        id = biblioteka.WezNastepneId();
                        Ksiazka ksiazka = new Ksiazka(id, tytul, autor, rokPublikacji, czyPrzeczytana);
                        biblioteka.Dodajksiazka(ksiazka);
                        break;
                    case "2":
                        biblioteka.PokazKsiazki();
                        break;
                    case "3":
                        Console.WriteLine("Wychodzisz z programu");
                        wyjscie = false;
                        break;
                    case "4":
                        //
                        Console.WriteLine("Zmień status czy książka przeczytana po id. Wpisz Id: ");
                        string idToChangeString = Console.ReadLine();
                        if (int.TryParse(idToChangeString, out int idToChange))
                        {
                            Console.WriteLine($"Twoja książka to:");
                            Ksiazka ksiazkaDoZmiany =
                                  biblioteka.PokazJednaKsiazke(idToChange);
                            Console.WriteLine("Czy książka była przeczytana: ");
                            Console.WriteLine("1 - tak");
                            Console.WriteLine("2 - nie");
                            var czyPS1 = Console.ReadKey();
                            int.TryParse(czyPS1.KeyChar.ToString(), out int czyPub1);
                            bool czyPrzeczytanaEdycja = false;
                            switch (czyPub1)
                            {
                                case 1:
                                    czyPrzeczytanaEdycja = true;
                                    break;
                                case 2:
                                    czyPrzeczytanaEdycja = false;
                                    break;
                                default:
                                    Console.WriteLine("Wpisano błędną odpowiedź");
                                    break;
                            }
                            ksiazkaDoZmiany.CzyPrzeczytana = czyPrzeczytanaEdycja;
                            biblioteka.EdytujStatus(ksiazkaDoZmiany);
                        }
                        else
                        {
                            Console.WriteLine("Podano nieprawidłowe id.");
                        }
                        break;
                    case "5":
                        Console.WriteLine("Wybierz ksiązkę po numerze id");
                        string idUsunString = Console.ReadLine();
                        if (int.TryParse(idUsunString, out int idUsun))
                        {
                            Ksiazka ksiazkaDoUusniecia = biblioteka.PokazJednaKsiazke(idUsun);
                            Console.WriteLine("Czy masz pewność że chcesz usunąć tę książke.");
                            Console.WriteLine("1 tak\r\n2 nie");
                            var czyUsunacK = Console.ReadKey();
                            if (int.TryParse(czyUsunacK.KeyChar.ToString(), out int czyUsunac))
                            {
                                if (czyUsunac == 1)
                                {
                                    biblioteka.UsunKsiazke(ksiazkaDoUusniecia);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Powrót do menu głównego.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Podano nieprawidłowe id.");
                        }
                        break;
                    default:
                        Console.WriteLine("Błędny numer operacji");
                        break;
                }
            }
        }
    }
}


//Ksiazka panTadeusz = new Ksiazka(id: 1, tytul: "Pan Tadeusz", autor: "Adam Mickiewicz", dataPublikacji: 1834, czyPrzeczytana: false);
//biblioteka.Dodajksiazka(panTadeusz);
//Ksiazka kodDaVinci = new Ksiazka(id: 2, tytul: "Kod daVinci", autor: "Dan Brown", dataPublikacji: 2003, czyPrzeczytana: true);
//biblioteka.Dodajksiazka(kodDaVinci);
// Ksiazka ksiazka = new Ksiazka();

