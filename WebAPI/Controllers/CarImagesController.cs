using Business.Abstract;
using Entites.Concerete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {
        private IFileProcess _fileProcess;
        private ICarImageService _carImageService;

        public CarImagesController(IFileProcess fileProcess, ICarImageService carImageService)
        {
            _fileProcess = fileProcess;
            _carImageService = carImageService;
        }

        [HttpPost]
        
        [Route("add")]
        public IActionResult UploadImage([FromForm (Name ="Image")] IFormFile files, [FromForm(Name ="id")]int id)
        {
            var result = _carImageService.Add(id, files);
            if (result.Success)
            {
                return Ok(result);
            }
                
            return BadRequest(result.Message);
        }
       
        [HttpPost("delete")]
        public IActionResult Delete(int Id)
        {
            var carImage = _carImageService.GetById(Id);
            var result = _carImageService.Delete(carImage.Data.Id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAll();
            if (result.Success==true)
            {
                return Ok(result);
            }

            return BadRequest();
        }

        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _carImageService.GetByCarId(carId);
            if (result.Success == true)
            {
                return Ok(result);
            }

            return BadRequest();
        }
    }
}
