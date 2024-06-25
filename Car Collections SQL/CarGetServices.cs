using CarCollectionModel;
using CarCollectionData;
using System.Reflection.Metadata;

namespace CarCollectionBusiness
{
    public class CarGetServices
    {
        public List<Cars> GetAllCars()
        {
            CarData carData = new CarData();

            return carData.GetCars();
        }

        public List<Cars> GetBrand(string Brand)
        {
            List<Cars> carBrand = new List<Cars>();

            foreach (var car in GetAllCars())
            {
                if (car.Brand == Brand)
                {
                    carBrand.Add(car);
                }
            }

            return carBrand;
        }

        public Cars GetCars(string Brand, string Model, string YearModel)
        {
            Cars foundCar = new Cars();

            foreach (var car in GetAllCars())
            {
                if (car.Brand == Brand && car.Model == Model && car.YearModel == YearModel)
                {
                    foundCar = car;
                }
            }

            return foundCar;
        }

    }
}
