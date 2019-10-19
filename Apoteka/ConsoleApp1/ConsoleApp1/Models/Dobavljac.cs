using System.Collections.Generic;

namespace Zadatak2SistemApoteke
{
    /// <summary>
    /// Class used for the model representing the drug distributer.
    /// </summary>
    public class Dobavljac
    {
        /// <summary>
        /// Constructor for the Dobavljac class.
        /// </summary>
        public Dobavljac()
        {
            ListaLekova = new List<Lek>();
        }

        /// <summary>
        /// Property representing an unique id of the distributer.
        /// </summary>
        public int IdentifikacioniBroj;

        /// <summary>
        /// Property representing the name of the distributer.
        /// </summary>
        public string Ime;

        /// <summary>
        /// Property representing the lastname of the distributer.
        /// </summary>
        public string Prezime;

        //UniqueAddress

        /// <summary>
        /// Property representing the address of the distributer.
        /// </summary>
        public string Adresa;

        //UniquePlace

        /// <summary>
        /// Property representing the location of the distributer.
        /// </summary>
        public string Mesto;


        /// <summary>
        /// Property representing the phone number of the distributer.
        /// </summary>
        public int BrojTelefona;

        //ListOfMedicine

        /// <summary>
        /// List containing the medicine.
        /// </summary>
        public List<Lek> ListaLekova;

       

    }
}
