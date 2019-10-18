using System.Collections.Generic;

namespace Zadatak2SistemApoteke
{
    /// <summary>
    /// Class used for the model representing
    /// </summary>
    public class Dobavljac
    {
        /// <summary>
        /// UniqueID
        /// </summary>
        public int IdentifikacioniBroj;

        /// <summary>
        /// UniqueName
        /// </summary>
        public string Ime;

        /// <summary>
        /// UniqueLastname
        /// </summary>
        public string Prezime;

        /// <summary>
        /// UniqueAddress
        /// </summary>
        public string Adresa;

        /// <summary>
        /// UniquePlace
        /// </summary>
        public string Mesto;

        /// <summary>
        /// UniquePhoneNumber
        /// </summary>
        public int BrojTelefona;

        /// <summary>
        /// ListOfMedicine
        /// </summary>
        public List<Lek> ListaLekova;

        /// <summary>
        /// Constructor of class
        /// </summary>
        public Dobavljac()
        {
            ListaLekova = new List<Lek>();
        }

    }
}
