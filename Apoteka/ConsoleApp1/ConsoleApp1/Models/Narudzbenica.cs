using System;
using System.Collections.Generic;
using Zadatak2SistemApoteke;

namespace ConsoleApp1.Models
{
    /// <summary>
    /// Class used for the model representing the order.
    /// </summary>
    public class Narudzbenica
    {
        /// <summary>
        /// Constructor of class order
        /// </summary>
        public Narudzbenica()
        {
            Apotekar = new Apotekar();
            ListaNabavke = new List<NabavkaLeka>();
        }

        /// <summary>
        /// Property representing the Unique ID of the order.
        /// </summary>
        public int SifraNarudzbine;

        /// <summary>
        /// Property representing the time of the order.
        /// </summary>
        public DateTime Vreme;

        /// <summary>
        /// Property representing the apotechary of the order.
        /// </summary>
        public Apotekar Apotekar;

        /// <summary>
        /// Property representing the order list of the order.
        /// </summary>
        public List<NabavkaLeka> ListaNabavke;
    }
}
