using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1.Helper
{
    public static class helper
    {
        public static int proveriIntBroj()
        {
            int broj;
            while (Int32.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.Write("Greska pri unosu pokusajte ponovo:");
            }

            return broj;
        }


        public static double proveriDoubleBroj()
        {
            double broj;
            while (Double.TryParse(Console.ReadLine(), out broj) == false)
            {
                Console.Write("Greska pri unosu pokusajte ponovo:");
            }
            return broj;
        }


        public static string proveriString()
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
