using System;
using System.Collections.Generic;
using Zadatak2SistemApoteke;

namespace ConsoleApp1.Models
{
    class Narudzbenica
    {
        public DateTime Vreme;
        public Apotekar Apotekar;
        public List<NabavkaLeka> ListaLekova;

        public Narudzbenica()
        {
            Apotekar = new Apotekar();
            ListaLekova = new List<NabavkaLeka>();
        }
    }
}
