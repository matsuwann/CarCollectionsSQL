using System;


namespace CarCollectionBusiness
{
    public class CarValidationServices
    {
        CarGetServices getServices = new CarGetServices();

        public bool CheckIfBrandExist(string Brand)
        {
            bool result = getServices.GetBrand(Brand) != null;
            return result;

        }

        public bool CheckIfCarExist(string Brand, string Model, string YearModel)
        {
            bool result = getServices.GetCars(Brand, Model, YearModel) != null;
            return result;
        }

    }
}
