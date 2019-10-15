using System;
using System.Collections.Generic;

namespace Zadatak2SistemApoteke
{
    class Program
    {
        public static List<Apotekar> listaApotekara = new List<Apotekar>();
        public static List<Dobavljac> listaDobavljaca = new List<Dobavljac>();
        static void Main(string[] args)
        {
            LoadData();
            Meni opcije;
            do
            {
                MeniTekst();
                Enum.TryParse(Console.ReadLine(), out opcije);


                switch (opcije)
                {
                    case Meni.meniApotekara:
                        Console.Clear();
                        SistemApotekara();
                        break;


                    case Meni.meniDobavljaca:
                        Console.Clear();
                        MeniDobavljaca();
                        break;


                    default:
                        Console.WriteLine("Nepoznat unos!");
                        break;
                }
            } while (opcije != Meni.izlaz);
        }

        public static void MeniTekst()
        {
            Console.WriteLine("1.Meni apotekara");
            Console.WriteLine("2.Meni dobavljaca");
            Console.WriteLine("0.Izlaz");
            Console.Write("Unos:");
        }
        //Metode za apotekara
        public static void IspisiSveApotekare()
        {
            foreach (Apotekar apotekar in listaApotekara)
            {
                Console.WriteLine(apotekar.IdentifikacioniBroj + " " + apotekar.Ime + " " + apotekar.Prezime + " {0:0#########} ", apotekar.BrojTelefona);
            }
        }

        public static void IzmeniApotekara()
        {
            Console.Clear();

            int sifraApotekaraZaIzmenu;

            //Promenljive za izmenu
            int novaSifraApotekara;
            string novoImeApotekara;
            string novoPrezimeApotekara;
            int noviBrojTelefonaApotekara;

            Console.Write("Unesite sifru apotekara za izmenu:");
            sifraApotekaraZaIzmenu = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite novu sifru apotekara:");
            novaSifraApotekara = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite novo ime apotekara:");
            novoImeApotekara = Console.ReadLine();

            Console.Write("Unesite novo prezime apotekara:");
            novoPrezimeApotekara = Console.ReadLine();

            Console.Write("Unesite novi broj telefona apotekara:");
            noviBrojTelefonaApotekara = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < listaApotekara.Count; i++)
            {
                if (listaApotekara[i].IdentifikacioniBroj == sifraApotekaraZaIzmenu)
                {
                    Apotekar apotekarIzmena = new Apotekar { IdentifikacioniBroj = novaSifraApotekara, Ime = novoImeApotekara, Prezime = novoPrezimeApotekara, BrojTelefona = noviBrojTelefonaApotekara };
                    listaApotekara[i] = apotekarIzmena;
                }
            }
        }


        public static void ObrisiApotekara()
        {
            Console.Clear();
            int sifraApotekaraZaBrisanje;

            Console.Write("Unesite sifru apotekara kojeg zelite da obrisete:");
            sifraApotekaraZaBrisanje = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < listaApotekara.Count; i++)
            {
                if (listaApotekara[i].IdentifikacioniBroj == sifraApotekaraZaBrisanje)
                {
                    listaApotekara.RemoveAt(i);
                }
            }
        }

        public static void DodajApotekara()
        {

        }


        public static void SistemApotekara()
        {
            int izabir;

            Console.Clear();
            Console.WriteLine("1.Ispisi sve apotekare");
            Console.WriteLine("2.Izmeni odredjenog apotekara");
            Console.WriteLine("3.Obrisi odredjenog apotekara");
            Console.WriteLine("4.Dodaj apotekara");
            Console.Write("Unos:");

            izabir = Convert.ToInt32(Console.ReadLine());

            switch (izabir)
            {
                case 1:
                    IspisiSveApotekare();
                    break;


                case 2:
                    IzmeniApotekara();
                    break;


                case 3:
                    ObrisiApotekara();
                    break;

                case 4:
                    DodajApotekara();
                    break;


                default:
                    Console.WriteLine("Nepoznat unos!");
                    break;
            }
        }
        //Kraj metoda apotekara


        public static void LoadData()
        {
            Apotekar apotekar1 = new Apotekar { IdentifikacioniBroj = 5535, Ime = "Zoran", Prezime = "Nikolic", BrojTelefona = 0643876352 };
            Apotekar apotekar2 = new Apotekar { IdentifikacioniBroj = 8473, Ime = "Stefan", Prezime = "Petrovic", BrojTelefona = 0625358261 };

            //Dodavanje Apotekara u listu
            listaApotekara.Add(apotekar1);
            listaApotekara.Add(apotekar2);

            Dobavljac dobavljac1 = new Dobavljac { IdentifikacioniBroj = 1283, Ime = "Marko", Prezime = "Markovic", Adresa = "Ulica 54", Mesto = "Kragujevac", BrojTelefona = 0602271954 };
            Dobavljac dobavljac2 = new Dobavljac { IdentifikacioniBroj = 7261, Ime = "Darko", Prezime = "Dugic", Adresa = "Ulica 32", Mesto = "Subotica", BrojTelefona = 0648272824 };

            //Dodavanje dobavljaca u listu
            listaDobavljaca.Add(dobavljac1);
            listaDobavljaca.Add(dobavljac2);
        }

        public static void MeniDobavljaca()
        {
            int izabir;

            Console.Clear();
            Console.WriteLine("1.Ispisi sve dobavljace");
            Console.WriteLine("2.Izmeni odredjenog dobavljaca");
            Console.WriteLine("3.Obrisi odredjenog dobavljaca");
            Console.Write("Unos:");

            izabir = Convert.ToInt32(Console.ReadLine());

            switch (izabir)
            {
                case 1:
                    Console.Clear();
                    foreach (Dobavljac dobavljac in listaDobavljaca)
                    {
                        Console.WriteLine(dobavljac.IdentifikacioniBroj + " " + dobavljac.Ime + " " + dobavljac.Prezime + " " + dobavljac.Adresa + " " + dobavljac.Adresa + " {0:0#########}", dobavljac.BrojTelefona);
                    }
                    break;


                case 2:
                    Console.Clear();

                    //Promenjive za izmenu
                    int novaSifraDobavljaca;
                    string novoImeDobavljaca;
                    string novoPrezimeDobavljaca;
                    string novaAdresaDobavljaca;
                    string novoMestoDobavljaca;
                    int noviBrojTelefonDobavljaca;

                    int izabirDobavljacaZaIzmenu;
                    Console.Write("Unesite sifru dobavljaca kojeg zelite da izmenite:");
                    izabirDobavljacaZaIzmenu = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Unesite novu sifru dobavljaca:");
                    novaSifraDobavljaca = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Unesite novo ime dobavljaca");
                    novoImeDobavljaca = Console.ReadLine();

                    Console.Write("Unesite novo prezime dobavljaca");
                    novoPrezimeDobavljaca = Console.ReadLine();

                    Console.Write("Unesite novu adresu dobavljaca");
                    novaAdresaDobavljaca = Console.ReadLine();

                    Console.Write("Unesite novo mesto dobavljaca");
                    novoMestoDobavljaca = Console.ReadLine();

                    Console.Write("Unesite novi broj telefona dobavljaca");
                    noviBrojTelefonDobavljaca = Convert.ToInt32(Console.ReadLine());

                    break;


                case 3:
                    Console.Clear();
                    int izabirDobavljacaZaBrisanje;

                    Console.Write("Unesite sifru dobavljaca kojeg zelite da obrisete:");
                    izabirDobavljacaZaBrisanje = Convert.ToInt32(Console.ReadLine());

                    for (int i = 0; i < listaDobavljaca.Count; i++)
                    {
                        listaDobavljaca.RemoveAt(i);
                    }

                    break;



                default:
                    Console.WriteLine("Nepoznat unos!");
                    break;
            }

        }


        public enum Meni
        {
            meniApotekara = 1,
            meniDobavljaca = 2,
            izlaz = 0
        }


    }
}
