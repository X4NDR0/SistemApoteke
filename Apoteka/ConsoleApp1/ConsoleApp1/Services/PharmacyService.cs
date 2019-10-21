using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Zadatak2SistemApoteke;

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
            int brisanjeSelect;

            Console.Write("Unesite sifru narudzbine koju zelite da obrisete:");
            Int32.TryParse(Console.ReadLine(), out brisanjeSelect);

            Narudzbenica pronadjenaNarudzbenica = FindOrderByID(brisanjeSelect);

            if (pronadjenaNarudzbenica != null)
            {
                listaNarudzbenica.Remove(pronadjenaNarudzbenica);
            }
            else
            {
                Console.WriteLine("Narudzbenica sa tim ID-om ne postoji!");
            }
        }

        private Narudzbenica FindOrderByID(int orderID)
        {
            foreach (Narudzbenica narudzbenica in listaNarudzbenica)
            {
                if (narudzbenica.SifraNarudzbine == orderID)
                {
                    return narudzbenica;
                }
            }
            return null;
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

        //private void IspisiSveNarudzbine()
        //{
        //    for (int i = 0; i < listaNarudzbenica.Count; i++)
        //    {
        //        Console.WriteLine("Sifra:" + listaNarudzbenica[i].SifraNarudzbine + "\n" + "Apotekar:" + listaNarudzbenica[i].Apotekar.Ime + " " + listaNarudzbenica[i].Apotekar.Prezime + "\n" + "Vreme:" + listaNarudzbenica[i].Vreme);
        //        for (int j = 0; j < listaNarudzbenica[i].ListaNabavke.Count; j++)
        //        {
        //            Console.WriteLine(listaNarudzbenica[i].ListaNabavke[j].Naziv + " " + listaNarudzbenica[i].ListaNabavke[j].Kolicina);
        //        }
        //    }
        //}

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
            int sifraLeka;

            Console.Write("Unesite sifru leka koji zelite da ispisete:");
            Int32.TryParse(Console.ReadLine(), out sifraLeka);

            Lek pronadjenLek = FindMedicineByID(sifraLeka);

            if (pronadjenLek != null)
            {
                //foreach (Lek lek in listaLekova)
                //{
                //    if (lek.SifraLeka == sifraLeka)
                //    {
                //        Console.WriteLine(lek.SifraLeka + " " + lek.NazivLeka + " " + lek.Cena);
                //    }
                //}



                //Console.WriteLine(pronadjenLek.SifraLeka + " " + pronadjenLek.NazivLeka + " " + pronadjenLek.Cena);

                //umesto ovog nachina pisanja, koristi ovo 

                Console.WriteLine($"{pronadjenLek.SifraLeka} {pronadjenLek.NazivLeka} {pronadjenLek.Cena}");
            }
            else
            {
                Console.WriteLine("Sifra leka ne postoji!");
            }
        }

        private void ObrisiLek()
        {
            int sifraLekaBrisanje;

            Console.Write("Unesite sifru leka kojeg zelite da obrisete:");
            Int32.TryParse(Console.ReadLine(), out sifraLekaBrisanje);

            Lek pronadjenLek = FindMedicineByID(sifraLekaBrisanje);

            if (pronadjenLek != null)
            {
                //for (int i = 0; i < listaLekova.Count; i++)
                //{
                //    if (listaLekova[i].SifraLeka == sifraLekaBrisanje)
                //    {
                //        listaLekova.RemoveAt(i);
                //    }
                //}

                listaLekova.Remove(pronadjenLek);

                Console.WriteLine("Uspesno ste obrisali lek!");
            }
            else
            {
                Console.WriteLine("Sifra leka koju ste hteli da obrisete ne postoji!");
            }

        }

        private Lek FindMedicineByID(int lekID)
        {
            foreach (Lek lek in listaLekova)
            {
                if (lek.SifraLeka == lekID)
                {
                    return lek;
                }
            }
            return null;
        }

        private void IzmeniLek()
        {
            int novaSifraLeka;
            string noviNazivLeka;
            int sifraLekaIzmena;

            Console.Write("Unesite sifru leka kojeg zelite da izmenite:");
            Int32.TryParse(Console.ReadLine(), out sifraLekaIzmena);

            Lek pronadjenLek = FindMedicineByID(sifraLekaIzmena);

            if (pronadjenLek != null)
            {
                Console.Write("Unesite novu sifru leka:");
                Int32.TryParse(Console.ReadLine(), out novaSifraLeka);

                Console.Write("Unesite novi naziv leka:");
                noviNazivLeka = Console.ReadLine();

                Lek lekEdit = new Lek { SifraLeka = novaSifraLeka, NazivLeka = noviNazivLeka };

                //foreach (Lek lek in listaLekova)
                //{
                //    if (lek.SifraLeka == sifraLekaIzmena)
                //    {
                //        lekEdit = lek;
                //    }
                //}

                //Ovde gore, em si opet uradio bespotrebno foreach, em si sa starim lekom pregazio novi koji si upravo kreirao.
                //To znachi da nisi ni proverio da li je izmenio lek....

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
            int addSifraLeka;
            string addNazivLeka;

            Console.Write("Unesite sifru leka:");
            Int32.TryParse(Console.ReadLine(), out addSifraLeka);

            Lek pronadjenLek = FindMedicineByID(addSifraLeka);

            if (pronadjenLek != null)
            {
                Console.WriteLine("Nemozete koristiti taj ID jer neki drugi lek koristi isti!");
            }
            else
            {
                Console.Write("Unesite naziv leka:");
                addNazivLeka = Console.ReadLine();

                Lek lekAdd = new Lek { SifraLeka = addSifraLeka, NazivLeka = addNazivLeka };

                listaLekova.Add(lekAdd);
            }
        }

        private void IzmeniApotekara()
        {
            Console.Clear();

            int sifraApotekaraZaIzmenu;

            //Promenljive za izmenu
            int novaSifraApotekara;
            string novoImeApotekara;
            string novoPrezimeApotekara;
            int noviBrojTelefonaApotekara;

            Console.Write("Unesite sifru apotekara za izmenu:");
            Int32.TryParse(Console.ReadLine(), out sifraApotekaraZaIzmenu);

            Apotekar pronadjenApotekar = FindPharmacystByID(sifraApotekaraZaIzmenu);

            if (pronadjenApotekar != null)
            {
                Console.Write("Unesite novu sifru apotekara:");
                Int32.TryParse(Console.ReadLine(), out novaSifraApotekara);

                Console.Write("Unesite novo ime apotekara:");
                novoImeApotekara = Console.ReadLine();

                Console.Write("Unesite novo prezime apotekara:");
                novoPrezimeApotekara = Console.ReadLine();

                Console.Write("Unesite novi broj telefona apotekara:");
                noviBrojTelefonaApotekara = Convert.ToInt32(Console.ReadLine());

                //for (int i = 0; i < listaApotekara.Count; i++)
                //{
                //    if (listaApotekara[i].IdentifikacioniBroj == sifraApotekaraZaIzmenu)
                //    {
                //        Apotekar apotekarIzmena = new Apotekar { IdentifikacioniBroj = novaSifraApotekara, Ime = novoImeApotekara, Prezime = novoPrezimeApotekara, BrojTelefona = noviBrojTelefonaApotekara };
                //        listaApotekara[i] = apotekarIzmena;
                //    }
                //}
                Apotekar apotekarIzmena = new Apotekar { IdentifikacioniBroj = novaSifraApotekara, Ime = novoImeApotekara, Prezime = novoPrezimeApotekara, BrojTelefona = noviBrojTelefonaApotekara };

                listaApotekara[listaApotekara.IndexOf(pronadjenApotekar)] = apotekarIzmena;

                //mozesh i odvojeno

                //int indexObjekta = listaApotekara.IndexOf(pronadjenApotekar);
                //listaApotekara[indexObjekta] = apotekarIzmena;
            }
            else
            {
                Console.WriteLine("Apotekar pod tim ID-om ne postoji!");
            }
        }

        private Apotekar FindPharmacystByID(int pharmacystID)
        {
            foreach (Apotekar apotekar in listaApotekara)
            {
                if (apotekar.IdentifikacioniBroj == pharmacystID)
                {
                    return apotekar;
                }
            }
            return null;
        }

        private void ObrisiApotekara()
        {
            Console.Clear();
            int sifraApotekaraZaBrisanje;

            Console.Write("Unesite sifru apotekara kojeg zelite da obrisete:");
            Int32.TryParse(Console.ReadLine(), out sifraApotekaraZaBrisanje);

            Apotekar pronadjenApotekar = FindPharmacystByID(sifraApotekaraZaBrisanje);

            if (pronadjenApotekar != null)
            {
                //for (int i = 0; i < listaApotekara.Count; i++)
                //{
                //    if (listaApotekara[i].IdentifikacioniBroj == sifraApotekaraZaBrisanje)
                //    {
                //        listaApotekara.RemoveAt(i);
                //    }
                //}

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
            Int32.TryParse(Console.ReadLine(), out noviIdApotekara);

            Apotekar pronadjenApotekar = FindPharmacystByID(noviIdApotekara);
            if (pronadjenApotekar != null)
            {
                Console.WriteLine("Apotekar sa tim ID-om vec postoji!");
            }
            else
            {
                Console.Write("Unesite ime apotekara:");
                novoImeApotekara = Console.ReadLine();

                Console.Write("Unesite prezime apotekara:");
                novoPrezimeApotekara = Console.ReadLine();

                Console.Write("Unesite broj telefona apotekara:");
                noviBrojTelefonaApotekara = Convert.ToInt32(Console.ReadLine());

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

        private void KreirajNarudzbenicu()
        {
            // Dobavljac dobavljacKreiranje = new Dobavljac();
            //  Apotekar apotekarKreiraj = new Apotekar();

            //Promenljive
            int sifraDobavljaca;
            int sifraLeka;
            int sifraApotekara;
            double ukupnaCena = 0;
            int kolicinaLeka;
            int sifraNarudzbine;

            Console.Write("Unesite sifru narudzbine:");
            Int32.TryParse(Console.ReadLine(), out sifraNarudzbine);

            IspisiSveApotekare();
            Console.Write("Unesite sifru apotekara koji vrsi narudzbenicu:");
            Int32.TryParse(Console.ReadLine(), out sifraApotekara);

            //foreach (Apotekar apotekar in listaApotekara)
            //{
            //    if (apotekar.IdentifikacioniBroj == sifraApotekara)
            //    {
            //        apotekarKreiraj = apotekar;
            //    }
            //}

            Apotekar pronadjeniApotekar = FindPharmacystByID(sifraApotekara);

            IspisiSveDobavljace();

            Console.Write("Unesite sifru dobavljaca:");
            Int32.TryParse(Console.ReadLine(), out sifraDobavljaca);

            //foreach (Dobavljac dobavljac in listaDobavljaca)
            //{
            //    if (dobavljac.IdentifikacioniBroj == sifraDobavljaca)
            //    {
            //        dobavljacKreiranje = dobavljac;
            //    }
            //}

            Dobavljac pronadjeniDobavljac = FindDobavljacByID(sifraDobavljaca);    //   <-----Ovo nisi nigde iskoristio, zato sto nisi dodao dobavljacha u klasu NabavkaLeka;

            IspisiSveLekove();
            Console.Write("Unesite sifru leka:");
            Int32.TryParse(Console.ReadLine(), out sifraLeka);

            //Ova ne valja. Na narudzbenicu moze da se doda samo 1 lek. Napravi tako da moze korisnik, odnosno apotekar da doda koliko hoce lekova, i da moze da prekine kada zeli

            foreach (Lek lek in listaLekova)
            {
                if (lek.SifraLeka == sifraLeka)
                {
                    Console.Write("Unesite kolicinu leka:");
                    Int32.TryParse(Console.ReadLine(), out kolicinaLeka);
                    ukupnaCena += lek.Cena * kolicinaLeka;
                    NabavkaLeka nabavkaLekaKreiranje = new NabavkaLeka { Naziv = lek.NazivLeka, Cena = lek.Cena, Kolicina = kolicinaLeka, UkupnaCena = ukupnaCena };
                    Narudzbenica narudzbenicaKreiraj = new Narudzbenica { Apotekar = pronadjeniApotekar, ListaNabavke = listaNabavkeLeka, Vreme = DateTime.Now, SifraNarudzbine = sifraNarudzbine };
                    listaNabavkeLeka.Add(nabavkaLekaKreiranje);
                    listaNarudzbenica.Add(narudzbenicaKreiraj);
                }
            }
        }

        //Metode dobavljaca
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

            int izabirDobavljacaZaIzmenu;
            Console.Write("Unesite sifru dobavljaca kojeg zelite da izmenite:");
            Int32.TryParse(Console.ReadLine(), out izabirDobavljacaZaIzmenu);

            //bool success = FindDobavljacByID(izabirDobavljacaZaIzmenu);

            Dobavljac pronadjeniDobavljac = FindDobavljacByID(izabirDobavljacaZaIzmenu);

            if (pronadjeniDobavljac != null)
            {
                Console.Write("Unesite novu sifru dobavljaca:");
                Int32.TryParse(Console.ReadLine(), out novaSifraDobavljaca);

                Console.Write("Unesite novo ime dobavljaca:");
                novoImeDobavljaca = Console.ReadLine();

                Console.Write("Unesite novo prezime dobavljaca:");
                novoPrezimeDobavljaca = Console.ReadLine();

                Console.Write("Unesite novu adresu dobavljaca:");
                novaAdresaDobavljaca = Console.ReadLine();

                Console.Write("Unesite novo mesto dobavljaca:");
                novoMestoDobavljaca = Console.ReadLine();

                Console.Write("Unesite novi broj telefona dobavljaca");
                Int32.TryParse(Console.ReadLine(), out noviBrojTelefonDobavljaca);

                //!!!!! Ova metoda ne radi nista, zavrshi je!.
            }
            else
            {
                Console.WriteLine("Dobavljac sa tim ID-om vec postoji!");
            }
        }

        //private bool FindDobavljacByID(int dobavljacID)
        //{
        //    foreach (Dobavljac dobavljac in listaDobavljaca)
        //    {
        //        if (dobavljac.IdentifikacioniBroj == dobavljacID)
        //        {
        //            return true;
        //        }
        //    }
        //    return false;
        //}

        private Dobavljac FindDobavljacByID(int dobavljacID)
        {
            foreach (Dobavljac dobavljac in listaDobavljaca)
            {
                if (dobavljac.IdentifikacioniBroj == dobavljacID)
                {
                    return dobavljac;
                }
            }
            return null;
        }

        private void ObrisiDobavljaca()
        {
            Console.Clear();
            int izabirDobavljacaZaBrisanje;

            Console.Write("Unesite sifru dobavljaca kojeg zelite da obrisete:");
            Int32.TryParse(Console.ReadLine(), out izabirDobavljacaZaBrisanje);

            //bool success = FindDobavljacByID(izabirDobavljacaZaBrisanje);

            Dobavljac pronadjeniDobavljac = FindDobavljacByID(izabirDobavljacaZaBrisanje);

            if (pronadjeniDobavljac != null)
            {
                //foreach (Dobavljac dobavljac in listaDobavljaca)
                //{
                //    if (dobavljac.IdentifikacioniBroj == izabirDobavljacaZaBrisanje)
                //    {
                //        listaDobavljaca.Remove(dobavljac);
                //    }
                //}

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
            Int32.TryParse(Console.ReadLine(), out addIdDobavljaca);

            //bool success = FindDobavljacByID(addIdDobavljaca);

            Dobavljac pronadjeniDobavljac = FindDobavljacByID(addIdDobavljaca);

            if (pronadjeniDobavljac != null)
            {
                Console.WriteLine("Nemozete uneti taj id jer neki drugi dobavljac koristi taj!");
            }
            else
            {
                Console.Write("Unesite ime dobavljaca:");
                addIme = Console.ReadLine();

                Console.Write("Unesite prezime dobavljaca:");
                addPrezime = Console.ReadLine();

                Console.Write("Unesite adresu dobavljaca:");
                addAdresa = Console.ReadLine();

                Console.Write("Unesite mesto dobavljaca:");
                addMesto = Console.ReadLine();

                Console.Write("Unesite broj telefona dobavljaca:");
                Int32.TryParse(Console.ReadLine(), out addBrojTelefona); ;

                Dobavljac dobavljacAdd = new Dobavljac { IdentifikacioniBroj = addIdDobavljaca, Ime = addIme, Prezime = addPrezime, Adresa = addAdresa, Mesto = addMesto, BrojTelefona = addBrojTelefona };

                listaDobavljaca.Add(dobavljacAdd);
            }
        }

        private void MeniLekova()
        {
            int izabir;

            Console.Clear();
            Console.WriteLine("1.Ispisi sve lekove");
            Console.WriteLine("2.Ispisi lek po sifri");
            Console.WriteLine("3.Obrisi odredjeni lek");
            Console.WriteLine("4.Izmeni lek");
            Console.WriteLine("5.Dodaj lek");
            Console.Write("Unos:");

            Int32.TryParse(Console.ReadLine(), out izabir);

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
            int izabir;

            Console.Clear();
            Console.WriteLine("1.Ispisi sve dobavljace");
            Console.WriteLine("2.Izmeni odredjenog dobavljaca");
            Console.WriteLine("3.Obrisi odredjenog dobavljaca");
            Console.WriteLine("4.Dodaj dobavljaca");
            Console.Write("Unos:");

            Int32.TryParse(Console.ReadLine(), out izabir);

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
