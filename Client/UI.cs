using CarCollectionData;
using CarCollectionModel;
using CarCollectionBusiness;

namespace Client
{
    internal class UI
    {
        static void Main (string[] args)
        {
            Console.WriteLine("Obscure Car Management");
            Console.WriteLine("");
            CarGetServices services = new CarGetServices();

            var cars = services.GetAllCars();

            foreach (var item in cars)
            {
                Console.WriteLine(item.Brand);
                Console.WriteLine(item.Model);
                Console.WriteLine(item.YearModel);
                Console.WriteLine("");

            }
        }
    }
}