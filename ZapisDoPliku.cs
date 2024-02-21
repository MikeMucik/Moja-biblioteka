
namespace MojaBiblioteka
{
    public class ZapisDoPliku : IZapis
    {
        private string scizkaDoPliku = "dane_biblioteki.txt";
        public List<Ksiazka> ZaladujKsiazki()
        {
            List<Ksiazka> ksiazki = new List<Ksiazka>();
            if (File.Exists(scizkaDoPliku))
            {
                using (StreamReader reader = new StreamReader(scizkaDoPliku))
                {
                    string line;
                    while((line = reader.ReadLine()) != null)
                    {
                        string[] elementy = line.Split('|');
                        if (elementy.Length == 5) 
                        {
                            int.TryParse(elementy[0], out int id);
                            int.TryParse(elementy[3], out int dataWczytan);
                            
                            int.TryParse(elementy[4], out int status);
                            bool czyPrzeczytana = status == 1; // ? true : false;
                            Ksiazka ksiazka = new Ksiazka(id, elementy[1], elementy[2], dataWczytan, czyPrzeczytana);
                            ksiazki.Add(ksiazka);
                        }
                    }
                }
            } return ksiazki;
        }

        public void ZapiszKsiazki(List<Ksiazka> ksiazki)
        {
            using (StreamWriter writer = new StreamWriter(scizkaDoPliku))
            {
                foreach (Ksiazka ksiazka in ksiazki)
                {
                    int status = ksiazka.CzyPrzeczytana ? 1 : 0;
                    writer.WriteLine($"{ksiazka.Id}|{ksiazka.Autor}|{ksiazka.Tytul}|{ksiazka.DataPublikacja}|{status}");
                }
            }
        }
    }
}
