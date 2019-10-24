using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Utilies
{
    public static class Helper
    {
        public static int ProveriIntBroj()
        {
            int broj;
            while (Int32.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.Write("Greska pri unosu pokusajte ponovo:");
            }

            return broj;
        }


        public static double ProveriDoubleBroj()
        {
            double broj;
            while (Double.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.Write("Greska pri unosu pokusajte ponovo:");
            }
            return broj;
        }


        public static string ProveriString()
        {
            string text = "";
            while (text == null || text.Equals(""))
            {
                text = Console.ReadLine();
            }
            return text;
        }
    }
}
