using System.Collections.Generic;

namespace Zadatak2SistemApoteke
{
    public class Dobavljac
    {
        public int IdentifikacioniBroj;
        public string Ime;
        public string Prezime;
        public string Adresa;
        public string Mesto;
        public int BrojTelefona;
        public List<Lek> ListaLekova;
        public Dobavljac()
        {
            ListaLekova = new List<Lek>();
        }

    }
}
