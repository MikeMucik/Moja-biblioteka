
namespace MojaBiblioteka
{
    public class Biblioteka
    {
        public List<Ksiazka> ksiazki = new List<Ksiazka>();
        private IZapis _zapis;
        public Biblioteka(IZapis zapis)
        {
            _zapis = zapis;
            ksiazki = _zapis.ZaladujKsiazki();
        }

        public void Dodajksiazka(Ksiazka ksiazka)
        {
            ksiazki.Add(ksiazka);
            _zapis.ZapiszKsiazki(ksiazki);
            Console.WriteLine($"Dodano książkę: {ksiazka.Tytul}");
        }
        public void UsunKsiazke(Ksiazka ksiazka)
        {
            ksiazki.Remove(ksiazka);
            _zapis.ZapiszKsiazki(ksiazki);
        }

        public void PokazKsiazki()
        {
            if (ksiazki.Count != 0)
            {
                Console.WriteLine("W bibliotece znajdują się książki :");
                foreach (var item in ksiazki)
                {
                    item.WyswietlInformacjeOKsizce();
                }
            }
            else
            {
                Console.WriteLine("Nie posiadasz jeszcze książek w swojej bibliotece");
            }
        }

        public int WezNastepneId()
        {
            int nastepneId = 0;
            if (ksiazki.Any())
            {
                nastepneId = ksiazki.Max(x => x.Id);
            }
            return nastepneId + 1;
        }

        public Ksiazka PokazJednaKsiazke(int id)
        {
            Ksiazka ToShow = ksiazki.FirstOrDefault(k => k.Id == id);
            ToShow.WyswietlInformacjeOKsizce();
            return ToShow;
        }

        public void EdytujStatus(Ksiazka ksiazka)
        {
            var entity = ksiazki.FirstOrDefault(k => k.Id == ksiazka.Id);
            if (entity != null)
            {
                entity = ksiazka;
                Console.WriteLine("\r\nZauktualizowano dane czy przeczytano książkę.");
            }
        }
    }
}


