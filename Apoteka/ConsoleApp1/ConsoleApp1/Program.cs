using ConsoleApp1.Services;

namespace Zadatak2SistemApoteke
{
    class Program  
    {
        static void Main(string[] args)
        {
            PharmacyService pharmacyService = new PharmacyService();
            pharmacyService.Initialize();
        }
    }
}
