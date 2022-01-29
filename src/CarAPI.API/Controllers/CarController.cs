using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarAPI.API.Entities;
using CarAPI.API.Models;
using CarAPI.API.Models.Errors;
using CarAPI.API.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;

namespace CarAPI.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ILogger<CarController> _logger;
        private readonly CarContext _context;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="logger"></param>
        public CarController(ILogger<CarController> logger, CarContext context)
        {
            _logger = logger;
            _context = context;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost("/cars")]
        [SwaggerResponse(200, Type = typeof(CarEntity))]
        [SwaggerResponse(400, Type = typeof(ValidationErrorModel))]
        public async Task<ActionResult<CarEntity>> CreateCar([FromBody] CarCreateDto carCreateModel)
        {
            var createNewCar = new CarEntity()
            {
                Name = carCreateModel.Name,
                Model = carCreateModel.Model,
                Owner = carCreateModel.Owner
            };


            var carExists = await _context.Cars.FirstOrDefaultAsync(x => x.Model == createNewCar.Model && x.Name == createNewCar.Name &&
            x.Owner == createNewCar.Owner);

            if (carExists == null)
            {
                var result = await _context.Cars.AddAsync(createNewCar);
                await _context.SaveChangesAsync();
                return Ok(result?.Entity);
            }
            else
            {
                return BadRequest(new ValidationErrorModel()
                {
                    ErrorMessage = "CAR with given details already exists",
                    StatusCode = 400
                });

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/cars")]
        [SwaggerResponse(200, Type = typeof(List<CarEntity>))]
        public async Task<ActionResult<List<CarEntity>>> GetAllCars()
        {
            var cars = await _context.Cars.ToListAsync();
            return Ok(cars);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("/cars/{id}")]
        [SwaggerResponse(200, Type = typeof(CarEntity))]
        [SwaggerResponse(404, Type = typeof(ValidationErrorModel))]
        public async Task<ActionResult<string>> GetCarById(int id)
        {

            _logger.LogInformation("Search CAR by " + id);

            var car = await _context.Cars.FindAsync(id);
            if(car== null)
            {
                return NotFound(new ValidationErrorModel()
                {
                    ErrorMessage="Car not found for given Id",
                    StatusCode = 404

                });
            }
            return Ok(car);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut("/cars/{id}")]
        [SwaggerResponse(200, Type = typeof(CarEntity))]
        [SwaggerResponse(404, Type = typeof(ValidationErrorModel))]
        public async Task<ActionResult<CarEntity>> UpdateCar(int id, CarCreateDto carToUpdate)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound(new ValidationErrorModel()
                {
                    ErrorMessage = "Car not found for given Id",
                    StatusCode = 404

                });
            }
            if (carToUpdate.Model != null)
            {
                car.Model = carToUpdate.Model;
            }

            car.Owner = carToUpdate.Owner;
            car.Name = carToUpdate.Name;
            await _context.SaveChangesAsync();
            return car;

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpDelete("/cars/{id}")]
        [SwaggerResponse(200, Type = typeof(bool))]
        [SwaggerResponse(404, Type = typeof(ValidationErrorModel))]
        public async Task<ActionResult<string>> DeleteCar(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car == null)
            {
                return NotFound(new ValidationErrorModel()
                {
                    ErrorMessage = "Car not found for given Id",
                    StatusCode = 404

                });
            }

            _context.Cars.Remove(car);
            await _context.SaveChangesAsync();
            return Ok(true);
        }
    }
}
