using Microsoft.AspNetCore.Mvc;
using CarCollectionBusiness;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace CarCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        CarGetServices _carGetServices;
        CarCUD _carCUD;

        public CarController()
        {
            _carGetServices = new CarGetServices();
            _carCUD = new CarCUD();
        }

        [HttpGet]
        public IEnumerable<CarCollectionAPI.Cars> GetCars()
        {
            var cars = _carGetServices.GetAllCars();

            List<CarCollectionAPI.Cars> cont = new List<CarCollectionAPI.Cars>();

            foreach (var car in cars)
            {
                cont.Add(new CarCollectionAPI.Cars { Brand = car.Brand, Model = car.Model, YearModel = car.YearModel });
            }
            return cont;
        }
        [HttpPost]
        public JsonResult AddCar(Cars request)
        {
            var result = _carCUD.CreateCar(request.Brand, request.Model, request.YearModel);

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateCar(Cars request)
        {
            var result = _carCUD.UpdateCar(request.Brand, request.Model, request.YearModel);
        
            return new JsonResult(result);
        }
    }
        
}