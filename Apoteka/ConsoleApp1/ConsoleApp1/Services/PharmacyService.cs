﻿using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using Zadatak2SistemApoteke;

namespace ConsoleApp1.Services
{
    class PharmacyService
    {
        public static List<Apotekar> listaApotekara = new List<Apotekar>();
        public static List<Dobavljac> listaDobavljaca = new List<Dobavljac>();
        public static List<Lek> listaLekova = new List<Lek>();
        public static List<NabavkaLeka> listaNabavkeLeka = new List<NabavkaLeka>();
        public static List<Narudzbenica> listaNarudzbenica = new List<Narudzbenica>();
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

                    case Meni.meniLekova:
                        Console.Clear();
                        MeniLekova();
                        break;

                    case Meni.meniNarudzbina:
                        Console.Clear();
                        MeniNarudzbina();
                        break;

                    default:
                        break;
                }
            } while (opcije != Meni.izlaz);
        }

        public void MeniNarudzbina()
        {
            int izabirMeni;
            Console.WriteLine("1.Ispisi sve narudzbine");
            Console.WriteLine("2.Obrisi narudzbinu");
            Console.WriteLine("3.4.Kreiraj narudzbinu");
            Console.Write("Unos:");

            izabirMeni = Convert.ToInt32(Console.ReadLine());

            switch (izabirMeni)
            {
                case 1:
                    Console.Clear();
                    IspisiSveNarudzbine();
                    break;

                case 2:
                    Console.Clear();
                    ObrisiNarudzbenicu();
                    break;

                case 3:
                    Console.Clear();
                    KreirajNarudzbenicu();
                    break;


                default:
                    Console.WriteLine("Nepoznat unos!");
                    break;
            }
        }

        public void ObrisiNarudzbenicu()
        {
            int brisanjeSelect;

            Console.Write("Unesite sifru narudzbine koju zelite da obrisete!");
            brisanjeSelect = Convert.ToInt32(Console.ReadLine());

            foreach (Narudzbenica narudzbenica in listaNarudzbenica)
            {
                if (narudzbenica.SifraNarudzbine == brisanjeSelect)
                {
                    listaNarudzbenica.Remove(narudzbenica);
                }
            }
        }


        public void MeniTekst()
        {
            Console.WriteLine("1.Meni apotekara");
            Console.WriteLine("2.Meni dobavljaca");
            Console.WriteLine("3.Meni lekova");
            Console.WriteLine("4.Meni narudzbenica");
            Console.WriteLine("0.Izlaz");
            Console.Write("Unos:");
        }


        public void IspisiSveNarudzbine()
        {
            for (int i = 0; i < listaNarudzbenica.Count; i++)
            {
                Console.WriteLine("Apotekar:" + listaNarudzbenica[i].Apotekar.Ime + " " + listaNarudzbenica[i].Apotekar.Prezime + "\n" + "Vreme:" + listaNarudzbenica[i].Vreme);
                for (int j = 0; j < listaNarudzbenica[i].ListaNabavke.Count; j++)
                {
                    Console.WriteLine(listaNarudzbenica[i].ListaNabavke[j].Naziv + " " + listaNarudzbenica[i].ListaNabavke[j].Kolicina);
                }
            }
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

        public void IspisiSveLekove()
        {
            foreach (Lek lek in listaLekova)
            {
                Console.WriteLine(lek.SifraLeka + " " + lek.NazivLeka + " Cena:" + lek.Cena);
            }
        }

        public void IspisiLekPoSifri()
        {
            int sifraLeka;

            Console.Write("Unesite sifru leka koji zelite da ispisete:");
            sifraLeka = Convert.ToInt32(Console.ReadLine());

            foreach (Lek lek in listaLekova)
            {
                if (lek.SifraLeka == sifraLeka)
                {
                    Console.WriteLine(lek.SifraLeka + " " + lek.NazivLeka);
                }
            }
        }


        public void ObrisiLek()
        {
            int sifraLekaBrisanje;

            Console.Write("Unesite sifru leka kojeg zelite da obrisete:");
            sifraLekaBrisanje = Convert.ToInt32(Console.ReadLine());

            foreach (Lek lek in listaLekova)
            {
                if (lek.SifraLeka == sifraLekaBrisanje)
                {
                    listaLekova.Remove(lek);
                }
            }
        }

        public void IzmeniLek()
        {
            int novaSifraLeka;
            string noviNazivLeka;
            int sifraLekaIzmena;

            Console.Write("Unesite sifru leka kojeg zelite da izmenite:");
            sifraLekaIzmena = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite novu sifru leka:");
            novaSifraLeka = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite novi naziv leka:");
            noviNazivLeka = Console.ReadLine();

            Lek lekEdit = new Lek { SifraLeka = novaSifraLeka, NazivLeka = noviNazivLeka };

            for (int i = 0; i < listaLekova.Count; i++)
            {
                if (listaLekova[i].SifraLeka == sifraLekaIzmena)
                {
                    listaLekova[i] = lekEdit;
                }
            }

        }

        public void DodajLek()
        {
            int addSifraLeka;
            string addNazivLeka;

            Console.Write("Unesite sifru leka:");
            addSifraLeka = Convert.ToInt32(Console.ReadLine());

            Console.Write("Unesite naziv leka:");
            addNazivLeka = Console.ReadLine();

            Lek lekAdd = new Lek { SifraLeka = addSifraLeka, NazivLeka = addNazivLeka };

            listaLekova.Add(lekAdd);
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

            Lek lek1 = new Lek { SifraLeka = 7282, NazivLeka = "Brufen 500mg", Cena = 235 };
            Lek lek2 = new Lek { SifraLeka = 2362, NazivLeka = "Hemoglobin", Cena = 250 };
            Lek lek3 = new Lek { SifraLeka = 8919, NazivLeka = "Limex", Cena = 500 };

            //Dodavanje leka u listu
            listaLekova.Add(lek1);
            listaLekova.Add(lek2);
            listaLekova.Add(lek3);
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

        public void KreirajNarudzbenicu()
        {
            Dobavljac dobavljacKreiranje = new Dobavljac();
            Apotekar apotekarKreiraj = new Apotekar();

            //Promenljive
            int sifraDobavljaca;
            int sifraLeka;
            int sifraApotekara;
            double ukupnaCena = 0;
            int kolicinaLeka;
            int sifraNarudzbine;

            Console.Write("Unesite sifru narudzbine:");
            sifraNarudzbine = Convert.ToInt32(Console.ReadLine());

            IspisiSveApotekare();
            Console.Write("Unesite sifru apotekara koji vrsi narudzbenicu:");
            sifraApotekara = Convert.ToInt32(Console.ReadLine());

            foreach (Apotekar apotekar in listaApotekara)
            {
                if (apotekar.IdentifikacioniBroj == sifraApotekara)
                {
                    apotekarKreiraj = apotekar;
                }
            }

            IspisiSveDobavljace();

            Console.Write("Unesite sifru dobavljaca:");
            sifraDobavljaca = Convert.ToInt32(Console.ReadLine());

            foreach (Dobavljac dobavljac in listaDobavljaca)
            {
                if (dobavljac.IdentifikacioniBroj == sifraDobavljaca)
                {
                    dobavljacKreiranje = dobavljac;
                }
            }

            IspisiSveLekove();
            Console.Write("Unesite sifru leka:");
            sifraLeka = Convert.ToInt32(Console.ReadLine());

            foreach (Lek lek in listaLekova)
            {
                if (lek.SifraLeka == sifraLeka)
                {
                    Console.Write("Unesite kolicinu leka:");
                    kolicinaLeka = Convert.ToInt32(Console.ReadLine());
                    ukupnaCena += lek.Cena * kolicinaLeka;
                    NabavkaLeka nabavkaLekaKreiranje = new NabavkaLeka { Naziv = lek.NazivLeka, Cena = lek.Cena, Kolicina = kolicinaLeka, UkupnaCena = ukupnaCena };
                    Narudzbenica narudzbenicaKreiraj = new Narudzbenica { Apotekar = apotekarKreiraj, ListaNabavke = listaNabavkeLeka, Vreme = DateTime.Now, SifraNarudzbine = sifraNarudzbine };
                    listaNabavkeLeka.Add(nabavkaLekaKreiranje);
                    listaNarudzbenica.Add(narudzbenicaKreiraj);
                }
            }


        }


        //Metode dobavljaca
        public void IspisiSveDobavljace()
        {
            Console.Clear();
            foreach (Dobavljac dobavljac in listaDobavljaca)
            {
                Console.WriteLine(dobavljac.IdentifikacioniBroj + " " + dobavljac.Ime + " " + dobavljac.Prezime + " " + dobavljac.Adresa + " " + dobavljac.Mesto + " {0:0#########}", dobavljac.BrojTelefona);
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

            Dobavljac dobavljacAdd = new Dobavljac { IdentifikacioniBroj = addIdDobavljaca, Ime = addIme, Prezime = addPrezime, Adresa = addAdresa, Mesto = addMesto, BrojTelefona = addBrojTelefona };

            listaDobavljaca.Add(dobavljacAdd);
        }

        public void MeniLekova()
        {
            int izabir;

            Console.Clear();
            Console.WriteLine("1.Ispisi sve lekove");
            Console.WriteLine("2.Ispisi lek po sifri");
            Console.WriteLine("3.Obrisi odredjeni lek");
            Console.WriteLine("4.Izmeni lek");
            Console.WriteLine("5.Dodaj lek");
            Console.Write("Unos:");

            izabir = Convert.ToInt32(Console.ReadLine());

            switch (izabir)
            {
                case 1:
                    IspisiSveLekove();
                    break;

                case 2:
                    IspisiLekPoSifri();
                    break;

                case 3:
                    ObrisiLek();
                    break;

                case 4:
                    IzmeniLek();
                    break;

                case 5:
                    DodajLek();
                    break;

                default:
                    Console.WriteLine("Nepoznat unos!");
                    break;
            }
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
                    Console.Clear();
                    IspisiSveDobavljace();
                    break;

                case 2:
                    Console.Clear();
                    IzmeniOdredjenogDobavljaca();
                    break;

                case 3:
                    Console.Clear();
                    ObrisiDobavljaca();
                    break;

                case 4:
                    Console.Clear();
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
            meniLekova = 3,
            meniNarudzbina = 4,
            izlaz = 0
        }
    }
}
