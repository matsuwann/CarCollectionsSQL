using CarCollectionModel;

namespace CarCollectionData
{
    public class CarData
    {
        List<Cars> cars;
        SqlDbData sqlData;

        public CarData()
        {
            cars = new List<Cars>();
            sqlData = new SqlDbData();
        }

        public List<Cars> GetCars() 
        {
            cars = sqlData.GetCars();
            return cars;
        }
        public int AddCars(Cars car)
        {
            return sqlData.AddCars(car.Brand, car.Model, car.YearModel);
        }
        public int UpdateCars(Cars car)
        {
            return sqlData.UpdateCars(car.Brand, car.Model, car.YearModel);
        }
        public int DeleteCars(Cars car)
        {
      
            return sqlData.DeleteCars(car.Brand, car.Model);
        }


    }
}
