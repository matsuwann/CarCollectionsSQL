using CarCollectionData;
using CarCollectionModel;
using System;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace CarCollectionBusiness
{
    public class CarCUD
    {
        CarValidationServices ValidationServices = new CarValidationServices();
        CarData carData = new CarData();

        public bool CreateCar(Cars cars)
        {
            bool result = false;

            if (ValidationServices.CheckIfBrandExist(cars.Brand))
            {
                result = carData.AddCars(cars) > 0;
            }

            return result;
        }

        public bool CreateCar(string Brand, string Model, string YearModel)
        {
            Cars cars = new Cars {Brand = Brand, Model = Model, YearModel = YearModel };

            return CreateCar(cars);
        }

        public bool UpdateCar(Cars cars)
        {
            bool result = false;

            if (ValidationServices.CheckIfCarExist(cars.Brand, cars.Model, cars.YearModel))
            {
                result = carData.UpdateCars(cars) > 0;
            }

            return result;
        }

        public bool UpdateCar(string Brand, string Model, string YearModel)
        {
            Cars cars = new Cars { Brand = Brand, Model = Model, YearModel = YearModel };

            return UpdateCar(cars);
        }

        public bool DeleteCar(Cars cars)
        {
            bool result = false;

            if (ValidationServices.CheckIfBrandExist(cars.Brand))
            {
                result = carData.DeleteCars(cars) > 0;
            }

            return result;
        }
    }
}
