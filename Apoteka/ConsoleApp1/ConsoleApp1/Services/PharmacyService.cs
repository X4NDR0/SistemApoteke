using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Zadatak2SistemApoteke;
using ConsoleApp1.Utilies;

namespace ConsoleApp1.Services
{
    /// <summary>
    /// Service used to manipulate the pharmacy data.
    /// </summary>
    public class PharmacyService
    {
        private static List<Apotekar> listaApotekara = new List<Apotekar>();
        private static List<Dobavljac> listaDobavljaca = new List<Dobavljac>();
        private static List<Lek> listaLekova = new List<Lek>();
        private static List<NabavkaLeka> listaNabavkeLeka = new List<NabavkaLeka>();
        private static List<Narudzbenica> listaNarudzbenica = new List<Narudzbenica>();

        /// <summary>
        /// Used to run the main service method.
        /// </summary>

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

        private void MeniNarudzbina()
        {
            int izabirMeni;
            Console.WriteLine("1.Ispisi sve narudzbine");
            Console.WriteLine("2.Obrisi narudzbinu");
            Console.WriteLine("3.Kreiraj narudzbinu");
            Console.Write("Unos:");
            Int32.TryParse(Console.ReadLine(), out izabirMeni);

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

        private void ObrisiNarudzbenicu()
        {
            Console.Write("Unesite sifru narudzbine koju zelite da obrisete:");
            int brisanjeSelect = Helper.ProveriIntBroj();

            Narudzbenica pronadjenaNarudzbenica = listaNarudzbenica.Where(x => x.SifraNarudzbine == brisanjeSelect).First();

            if (pronadjenaNarudzbenica != null)
            {
                listaNarudzbenica.Remove(pronadjenaNarudzbenica);
            }
            else
            {
                Console.WriteLine("Narudzbenica sa tim ID-om ne postoji!");
            }
        }

        private void MeniTekst()
        {
            Console.WriteLine("1.Meni apotekara");
            Console.WriteLine("2.Meni dobavljaca");
            Console.WriteLine("3.Meni lekova");
            Console.WriteLine("4.Meni narudzbenica");
            Console.WriteLine("0.Izlaz");
            Console.Write("Unos:");
        }

        private void IspisiSveNarudzbine()
        {
            foreach (Narudzbenica narudzbenica in listaNarudzbenica)
            {
                Console.WriteLine("Sifra:" + narudzbenica.SifraNarudzbine + "\n" + "Apotekar:" + narudzbenica.Apotekar.Ime + " " + narudzbenica.Apotekar.Prezime + "\n" + "Vreme:" + narudzbenica.Vreme);
                foreach (NabavkaLeka nabavkaLeka in narudzbenica.ListaNabavke)
                {
                    Console.WriteLine(nabavkaLeka.Naziv + " " + nabavkaLeka.Kolicina);
                }
            }
        }

        private void IspisiSveApotekare()
        {
            Console.Clear();
            foreach (Apotekar apotekar in listaApotekara)
            {
                Console.WriteLine(apotekar.IdentifikacioniBroj + " " + apotekar.Ime + " " + apotekar.Prezime + " {0:0#########} ", apotekar.BrojTelefona);
            }
        }

        private void IspisiSveLekove()
        {
            foreach (Lek lek in listaLekova)
            {
                Console.WriteLine(lek.SifraLeka + " " + lek.NazivLeka + " Cena:" + lek.Cena);
            }
        }

        private void IspisiLekPoSifri()
        {
            Console.Write("Unesite sifru leka kojeg zelite ispisati:");
            int sifraLeka = Helper.ProveriIntBroj();

            Lek pronadjenLek = listaLekova.Where(x => x.SifraLeka == sifraLeka).First();

            if (pronadjenLek != null)
            {
                Console.WriteLine($"{pronadjenLek.SifraLeka} {pronadjenLek.NazivLeka} {pronadjenLek.Cena}");
            }
            else
            {
                Console.WriteLine("Sifra leka ne postoji!");
            }
        }

        private void ObrisiLek()
        {
            Console.Write("Unesite sifru leka kojeg zelite da obrisete:");
            int sifraLekaBrisanje = Helper.ProveriIntBroj();

            Lek pronadjenLek = listaLekova.Where(x => x.SifraLeka == sifraLekaBrisanje).First();

            if (pronadjenLek != null)
            {
                listaLekova.Remove(pronadjenLek);

                Console.WriteLine("Uspesno ste obrisali lek!");
            }
            else
            {
                Console.WriteLine("Sifra leka koju ste hteli da obrisete ne postoji!");
            }

        }

        private void IzmeniLek()
        {
            int novaSifraLeka;
            string noviNazivLeka;
            double novaCenaLeka;

            Console.Write("Unesite sifru leka kojeg zelite da izmenite:");
            int sifraLekaIzmena = Helper.ProveriIntBroj();

            Lek pronadjenLek = listaLekova.Where(x => x.SifraLeka == sifraLekaIzmena).First();

            if (pronadjenLek != null)
            {
                Console.Write("Unesite novu sifru leka:");
                Int32.TryParse(Console.ReadLine(), out novaSifraLeka);

                Console.Write("Unesite novi naziv leka:");
                noviNazivLeka = Console.ReadLine();

                Console.Write("Unesite novu cenu leka:");
                Double.TryParse(Console.ReadLine(), out novaCenaLeka);

                Lek lekEdit = new Lek { SifraLeka = novaSifraLeka, NazivLeka = noviNazivLeka, Cena = novaCenaLeka };

                var indexPronadjenogLeka = listaLekova.IndexOf(pronadjenLek);

                listaLekova[indexPronadjenogLeka] = lekEdit;
            }
            else
            {
                Console.WriteLine("Sifra leka ne postoji!");
            }
        }

        private void DodajLek()
        {
            string addNazivLeka;
            double addCenaLeka;

            Console.Write("Unesite sifru leka:");
            int addSifraLeka = Helper.ProveriIntBroj();

            Lek pronadjenLek = listaLekova.Where(x => x.SifraLeka == addSifraLeka).First();

            if (pronadjenLek != null)
            {
                Console.WriteLine("Nemozete koristiti taj ID jer neki drugi lek koristi isti!");
            }
            else
            {
                Console.Write("Unesite naziv leka:");
                addNazivLeka = Helper.ProveriString();

                Console.Write("Unesite cenu leka:");
                addCenaLeka = Helper.ProveriDoubleBroj();

                Lek lekAdd = new Lek { SifraLeka = addSifraLeka, NazivLeka = addNazivLeka, Cena = addCenaLeka };

                listaLekova.Add(lekAdd);
            }
        }

        private void IzmeniApotekara()
        {
            Console.Clear();
            //Promenljive za izmenu
            int novaSifraApotekara;
            string novoImeApotekara;
            string novoPrezimeApotekara;
            int noviBrojTelefonaApotekara;

            Console.Write("Unesite sifru apotekara za izmenu:");
            int sifraApotekaraZaIzmenu = Helper.ProveriIntBroj();

            Apotekar pronadjenApotekar = listaApotekara.Where(x => x.IdentifikacioniBroj == sifraApotekaraZaIzmenu).First();

            if (pronadjenApotekar != null)
            {
                Console.Write("Unesite novu sifru apotekara:");
                novaSifraApotekara = Helper.ProveriIntBroj();

                Console.Write("Unesite novo ime apotekara:");
                novoImeApotekara = Helper.ProveriString();

                Console.Write("Unesite novo prezime apotekara:");
                novoPrezimeApotekara = Helper.ProveriString();

                Console.Write("Unesite novi broj telefona apotekara:");
                noviBrojTelefonaApotekara = Helper.ProveriIntBroj();

                Apotekar apotekarIzmena = new Apotekar { IdentifikacioniBroj = novaSifraApotekara, Ime = novoImeApotekara, Prezime = novoPrezimeApotekara, BrojTelefona = noviBrojTelefonaApotekara };

                listaApotekara[listaApotekara.IndexOf(pronadjenApotekar)] = apotekarIzmena;

            }
            else
            {
                Console.WriteLine("Apotekar pod tim ID-om ne postoji!");
            }
        }

        private void ObrisiApotekara()
        {
            Console.Clear();
            int sifraApotekaraZaBrisanje;

            Console.Write("Unesite sifru apotekara kojeg zelite da obrisete:");
            sifraApotekaraZaBrisanje = Helper.ProveriIntBroj();

            Apotekar pronadjenApotekar = listaApotekara.Where(x => x.IdentifikacioniBroj == sifraApotekaraZaBrisanje).First();

            if (pronadjenApotekar != null)
            {
                listaApotekara.Remove(pronadjenApotekar);

                Console.WriteLine("Uspesno ste obrisali apotekara!");
            }
            else
            {
                Console.WriteLine("Apotekar pod tim ID-om ne postoji!");
            }

        }

        private void DodajApotekara()
        {
            Console.Clear();
            int noviIdApotekara;
            string novoImeApotekara;
            string novoPrezimeApotekara;
            int noviBrojTelefonaApotekara;

            Console.Write("Unesite id apotekara:");
            noviIdApotekara = Helper.ProveriIntBroj();

            Apotekar pronadjenApotekar = listaApotekara.Where(x => x.IdentifikacioniBroj == noviIdApotekara).First();
            if (pronadjenApotekar != null)
            {
                Console.WriteLine("Apotekar sa tim ID-om vec postoji!");
            }
            else
            {
                Console.Write("Unesite ime apotekara:");
                novoImeApotekara = Helper.ProveriString();

                Console.Write("Unesite prezime apotekara:");
                novoPrezimeApotekara = Helper.ProveriString();

                Console.Write("Unesite broj telefona apotekara:");
                noviBrojTelefonaApotekara = Helper.ProveriIntBroj();

                Apotekar apotekarKreiranje = new Apotekar { IdentifikacioniBroj = noviIdApotekara, Ime = novoImeApotekara, Prezime = novoPrezimeApotekara, BrojTelefona = noviBrojTelefonaApotekara };

                listaApotekara.Add(apotekarKreiranje);
            }
        }

        private void LoadData()
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

        private void SistemApotekara()
        {
            Console.Clear();
            Console.WriteLine("1.Ispisi sve apotekare");
            Console.WriteLine("2.Izmeni odredjenog apotekara");
            Console.WriteLine("3.Obrisi odredjenog apotekara");
            Console.WriteLine("4.Dodaj apotekara");
            Console.Write("Unos:");

            int izabir = Helper.ProveriIntBroj();

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


        private void KreirajNarudzbenicu()
        {
            int sifraDobavljaca;
            int sifraLeka;
            int sifraApotekara;
            double ukupnaCena = 0;
            int kolicinaLeka;
            int sifraNarudzbine;

            Console.Write("Unesite sifru narudzbine:");
            sifraNarudzbine = Helper.ProveriIntBroj();

            IspisiSveApotekare();
            Console.Write("Unesite sifru apotekara koji vrsi narudzbenicu:");
            sifraApotekara = Helper.ProveriIntBroj();

            Apotekar pronadjeniApotekar = listaApotekara.Where(x => x.IdentifikacioniBroj == sifraNarudzbine).First();

            IspisiSveDobavljace();

            Console.Write("Unesite sifru dobavljaca:");
            sifraDobavljaca = Helper.ProveriIntBroj();


            Dobavljac pronadjeniDobavljac = listaDobavljaca.Where(x => x.IdentifikacioniBroj == sifraDobavljaca).First();

            IspisiSveLekove();
            Console.Write("Unesite sifru leka:");
            sifraLeka = Helper.ProveriIntBroj();

            foreach (Lek lek in listaLekova)
            {
                if (lek.SifraLeka == sifraLeka)
                {
                    Console.Write("Unesite kolicinu leka:");
                    kolicinaLeka = Helper.ProveriIntBroj();
                    ukupnaCena += lek.Cena * kolicinaLeka;
                    NabavkaLeka nabavkaLekaKreiranje = new NabavkaLeka { Naziv = lek.NazivLeka, Cena = lek.Cena, Kolicina = kolicinaLeka, UkupnaCena = ukupnaCena };
                    Narudzbenica narudzbenicaKreiraj = new Narudzbenica { Apotekar = pronadjeniApotekar, ListaNabavke = listaNabavkeLeka, Vreme = DateTime.Now, SifraNarudzbine = sifraNarudzbine };
                    listaNabavkeLeka.Add(nabavkaLekaKreiranje);
                    listaNarudzbenica.Add(narudzbenicaKreiraj);
                }
            }
        }

        private void IspisiSveDobavljace()
        {
            Console.Clear();
            foreach (Dobavljac dobavljac in listaDobavljaca)
            {
                Console.WriteLine(dobavljac.IdentifikacioniBroj + " " + dobavljac.Ime + " " + dobavljac.Prezime + " " + dobavljac.Adresa + " " + dobavljac.Mesto + " {0:0#########}", dobavljac.BrojTelefona);
            }
        }

        private void IzmeniOdredjenogDobavljaca()
        {
            Console.Clear();
            //Promenjive za izmenu
            int novaSifraDobavljaca;
            string novoImeDobavljaca;
            string novoPrezimeDobavljaca;
            string novaAdresaDobavljaca;
            string novoMestoDobavljaca;
            int noviBrojTelefonDobavljaca;

            Console.Write("Unesite sifru dobavljaca kojeg zelite da izmenite:");
            int izabirDobavljacaZaIzmenu = Helper.ProveriIntBroj();

            Dobavljac pronadjeniDobavljac = listaDobavljaca.Where(x => x.IdentifikacioniBroj == izabirDobavljacaZaIzmenu).First();

            if (pronadjeniDobavljac != null)
            {
                Console.Write("Unesite novu sifru dobavljaca:");
                novaSifraDobavljaca = Helper.ProveriIntBroj();

                Console.Write("Unesite novo ime dobavljaca:");
                novoImeDobavljaca = Helper.ProveriString();

                Console.Write("Unesite novo prezime dobavljaca:");
                novoPrezimeDobavljaca = Helper.ProveriString();

                Console.Write("Unesite novu adresu dobavljaca:");
                novaAdresaDobavljaca = Helper.ProveriString();

                Console.Write("Unesite novo mesto dobavljaca:");
                novoMestoDobavljaca = Helper.ProveriString();

                Console.Write("Unesite novi broj telefona dobavljaca");
                noviBrojTelefonDobavljaca = Helper.ProveriIntBroj();

                Dobavljac dobavljacEdit = new Dobavljac { IdentifikacioniBroj = novaSifraDobavljaca, Ime = novoImeDobavljaca, Prezime = novoPrezimeDobavljaca, Mesto = novoMestoDobavljaca, Adresa = novaAdresaDobavljaca, BrojTelefona = noviBrojTelefonDobavljaca };

                listaDobavljaca[listaDobavljaca.IndexOf(pronadjeniDobavljac)] = dobavljacEdit;
            }
            else
            {
                Console.WriteLine("Dobavljac sa tim ID-om vec postoji!");
            }
        }

        private void ObrisiDobavljaca()
        {
            Console.Clear();
            Console.Write("Unesite sifru dobavljaca kojeg zelite da obrisete:");
            int izabirDobavljacaZaBrisanje = Helper.ProveriIntBroj();

            Dobavljac pronadjeniDobavljac = listaDobavljaca.Where(x => x.IdentifikacioniBroj == izabirDobavljacaZaBrisanje).First();

            if (pronadjeniDobavljac != null)
            {

                listaDobavljaca.Remove(pronadjeniDobavljac);

                Console.WriteLine("Uspesno ste obrisali dobavljaca!");
            }
            else
            {
                Console.WriteLine("Dobavljac pod tim ID-om ne postoji!");
            }
        }

        private void DodajDobavljaca()
        {
            int addIdDobavljaca;
            string addIme;
            string addPrezime;
            string addAdresa;
            string addMesto;
            int addBrojTelefona;

            Console.Write("Unesite ID dobavljaca:");
            addIdDobavljaca = Helper.ProveriIntBroj();

            Dobavljac pronadjeniDobavljac = listaDobavljaca.Where(x => x.IdentifikacioniBroj == addIdDobavljaca).First();

            if (pronadjeniDobavljac != null)
            {
                Console.WriteLine("Nemozete uneti taj id jer neki drugi dobavljac koristi taj!");
            }
            else
            {
                Console.Write("Unesite ime dobavljaca:");
                addIme = Helper.ProveriString();

                Console.Write("Unesite prezime dobavljaca:");
                addPrezime = Helper.ProveriString();

                Console.Write("Unesite adresu dobavljaca:");
                addAdresa = Helper.ProveriString();

                Console.Write("Unesite mesto dobavljaca:");
                addMesto = Helper.ProveriString();

                Console.Write("Unesite broj telefona dobavljaca:");
                addBrojTelefona = Helper.ProveriIntBroj();

                Dobavljac dobavljacAdd = new Dobavljac { IdentifikacioniBroj = addIdDobavljaca, Ime = addIme, Prezime = addPrezime, Adresa = addAdresa, Mesto = addMesto, BrojTelefona = addBrojTelefona };

                listaDobavljaca.Add(dobavljacAdd);
            }
        }

        private void MeniLekova()
        {
            Console.Clear();
            Console.WriteLine("1.Ispisi sve lekove");
            Console.WriteLine("2.Ispisi lek po sifri");
            Console.WriteLine("3.Obrisi odredjeni lek");
            Console.WriteLine("4.Izmeni lek");
            Console.WriteLine("5.Dodaj lek");
            Console.Write("Unos:");

            int izabir = Helper.ProveriIntBroj();

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

        private void MeniDobavljaca()
        {
            Console.Clear();
            Console.WriteLine("1.Ispisi sve dobavljace");
            Console.WriteLine("2.Izmeni odredjenog dobavljaca");
            Console.WriteLine("3.Obrisi odredjenog dobavljaca");
            Console.WriteLine("4.Dodaj dobavljaca");
            Console.Write("Unos:");

            int izabir = Helper.ProveriIntBroj();

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

        private enum Meni
        {
            meniApotekara = 1,
            meniDobavljaca = 2,
            meniLekova = 3,
            meniNarudzbina = 4,
            izlaz = 0
        }
    }
}