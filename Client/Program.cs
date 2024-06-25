using CarCollectionData;
using CarCollectionModel;
using CarCollectionBusiness;

namespace Client
{
    internal class Program
    {
        static void Main (string[] args)
        {
            CarGetServices services = new CarGetServices();

            var cars = services.GetAllCars();

            foreach (var item in cars)
            {
                Console.WriteLine (item.Brand);
                Console.WriteLine(item.Model);
                Console.WriteLine(item.YearModel);

            }
        }
    }
}