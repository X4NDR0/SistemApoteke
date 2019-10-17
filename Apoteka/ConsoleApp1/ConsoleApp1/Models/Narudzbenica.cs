using System;
using System.Collections.Generic;
using Zadatak2SistemApoteke;

namespace ConsoleApp1.Models
{
    class Narudzbenica
    {
        public int SifraNarudzbine;
        public DateTime Vreme;
        public Apotekar Apotekar;
        public List<NabavkaLeka> ListaNabavke;

        public Narudzbenica()
        {
            Apotekar = new Apotekar();
            ListaNabavke = new List<NabavkaLeka>();
        }
    }
}
