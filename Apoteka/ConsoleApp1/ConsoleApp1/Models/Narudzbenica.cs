using System;
using System.Collections.Generic;
using Zadatak2SistemApoteke;

namespace ConsoleApp1.Models
{
    /// <summary>
    /// Class used for the model representing
    /// </summary>
    public class Narudzbenica
    {
        /// <summary>
        /// Constructor of class
        /// </summary>
        public Narudzbenica()
        {
            Apotekar = new Apotekar();
            ListaNabavke = new List<NabavkaLeka>();
        }

        /// <summary>
        /// OrderID
        /// </summary>
        public int SifraNarudzbine;

        /// <summary>
        /// OrderTime
        /// </summary>
        public DateTime Vreme;

        /// <summary>
        /// UniqueApothecary
        /// </summary>
        public Apotekar Apotekar;

        /// <summary>
        /// OrderList
        /// </summary>
        public List<NabavkaLeka> ListaNabavke;
    }
}
