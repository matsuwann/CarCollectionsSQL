using Microsoft.AspNetCore.Mvc;
using CarCollectionBusiness;
using CarCollectionModel;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace CarCollectionAPI.Controllers
{
    [ApiController]
    [Route("api/car")]
    public class CarController : ControllerBase
    {
        CarGetServices _carGetServices;
        CarCUD _carCUD;
        S3Services _s3Service;

        public CarController(S3Services s3Service)
        {
            _carGetServices = new CarGetServices();
            _carCUD = new CarCUD();
            _s3Service = s3Service;
        }

        [HttpGet]
        public IEnumerable<Cars> GetCars()
        {
            var cars = _carGetServices.GetAllCars();

            List<Cars> cont = new List<Cars>();

            foreach (var car in cars)
            {
                cont.Add(new Cars { Brand = car.Brand, Model = car.Model, YearModel = car.YearModel });
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
            var result = _carCUD.UpdateCar(request.Brand, request.Model);

            return new JsonResult(result);
        }

        [HttpDelete]
        public JsonResult DeleteCar(Cars request)
        {
            var carToDelete = new CarCollectionModel.Cars
            {
                Brand = request.Brand
            };

            var result = _carCUD.DeleteCar(carToDelete);

            return new JsonResult(result);
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file provided.");
            }

            try
            {
                var result = await _s3Service.UploadFileAsync(file);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }

}