using System;
using System.Collections.Generic;
using Zadatak2SistemApoteke;

namespace ConsoleApp1.Services
{
    class PharmacyService
    {
        public static List<Apotekar> listaApotekara = new List<Apotekar>();
        public static List<Dobavljac> listaDobavljaca = new List<Dobavljac>();
        public void Initialize()
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

        public void MeniTekst()
        {
            Console.WriteLine("1.Meni apotekara");
            Console.WriteLine("2.Meni dobavljaca");
            Console.WriteLine("0.Izlaz");
            Console.Write("Unos:");
        }


        //Metode za apotekara
        public void IspisiSveApotekare()
        {
            Console.Clear();
            foreach (Apotekar apotekar in listaApotekara)
            {
                Console.WriteLine(apotekar.IdentifikacioniBroj + " " + apotekar.Ime + " " + apotekar.Prezime + " {0:0#########} ", apotekar.BrojTelefona);
            }
        }

        public void IzmeniApotekara()
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


        public void ObrisiApotekara()
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

        public void DodajApotekara()
        {
            Console.Clear();
            int noviIdApotekara;
            string novoImeApotekara;
            string novoPrezimeApotekara;
            int noviBrojTelefonaApotekara;

            Console.Write("Unesite id apotekara:");
            noviIdApotekara = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite ime apotekara:");
            novoImeApotekara = Console.ReadLine();

            Console.Write("Unesite prezime apotekara:");
            novoPrezimeApotekara = Console.ReadLine();

            Console.Write("Unesite broj telefona apotekara:");
            noviBrojTelefonaApotekara = Convert.ToInt32(Console.ReadLine());

            Apotekar apotekarKreiranje = new Apotekar { IdentifikacioniBroj = noviIdApotekara, Ime = novoImeApotekara, Prezime = novoPrezimeApotekara, BrojTelefona = noviBrojTelefonaApotekara };

            listaApotekara.Add(apotekarKreiranje);
        }


        public void LoadData()
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



        public void SistemApotekara()
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


        //Metode dobavljaca
        public void IspisiSveDobavljace()
        {
            Console.Clear();
            foreach (Dobavljac dobavljac in listaDobavljaca)
            {
                Console.WriteLine(dobavljac.IdentifikacioniBroj + " " + dobavljac.Ime + " " + dobavljac.Prezime + " " + dobavljac.Adresa + " " + dobavljac.Adresa + " {0:0#########}", dobavljac.BrojTelefona);
            }
        }

        public void IzmeniOdredjenogDobavljaca()
        {
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
        }

        public void ObrisiDobavljaca()
        {
            Console.Clear();
            int izabirDobavljacaZaBrisanje;

            Console.Write("Unesite sifru dobavljaca kojeg zelite da obrisete:");
            izabirDobavljacaZaBrisanje = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < listaDobavljaca.Count; i++)
            {
                listaDobavljaca.RemoveAt(i);
            }
        }

        public void DodajDobavljaca()
        {
            int addIdDobavljaca;
            string addIme;
            string addPrezime;
            string addAdresa;
            string addMesto;
            int addBrojTelefona;

            Console.Write("Unesite ID dobavljaca:");
            addIdDobavljaca = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite ime dobavljaca:");
            addIme = Console.ReadLine();

            Console.Write("Unesite prezime dobavljaca:");
            addPrezime = Console.ReadLine();

            Console.Write("Unesite adresu dobavljaca:");
            addAdresa = Console.ReadLine();

            Console.Write("Unesite mesto dobavljaca:");
            addMesto = Console.ReadLine();

            Console.Write("Unesite broj telefona dobavljaca:");
            addBrojTelefona = Convert.ToInt32(Console.ReadLine());

            Dobavljac dobavljacAdd = new Dobavljac { IdentifikacioniBroj = addIdDobavljaca,Ime = addIme,Prezime = addPrezime,Adresa = addAdresa,Mesto = addMesto,BrojTelefona = addBrojTelefona};

            listaDobavljaca.Add(dobavljacAdd);
        }

        public void MeniDobavljaca()
        {
            int izabir;

            Console.Clear();
            Console.WriteLine("1.Ispisi sve dobavljace");
            Console.WriteLine("2.Izmeni odredjenog dobavljaca");
            Console.WriteLine("3.Obrisi odredjenog dobavljaca");
            Console.WriteLine("4.Dodaj dobavljaca");
            Console.Write("Unos:");

            izabir = Convert.ToInt32(Console.ReadLine());

            switch (izabir)
            {
                case 1:
                    IspisiSveDobavljace();
                    break;

                case 2:
                    IzmeniOdredjenogDobavljaca();
                    break;

                case 3:
                    ObrisiDobavljaca();
                    break;

                case 4:
                    DodajDobavljaca();
                    break;

                default:
                    Console.WriteLine("Nepoznat unos!");
                    break;
            }
        }
        //Kraj metoda dobavljaca

        public enum Meni
        {
            meniApotekara = 1,
            meniDobavljaca = 2,
            izlaz = 0
        }

    }
}
