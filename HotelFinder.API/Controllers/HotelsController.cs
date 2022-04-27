using HotelFinder.Business.Abstract;
using HotelFinder.Business.Concrete;
using HotelFinder.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelFinder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private IHotelService _hotelService;
        public HotelsController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        /// <summary>
        /// Get All Hotels
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var hotels = _hotelService.GetAllHotels();
            return Ok(hotels);
        }
        /// <summary>
        /// Id ye gore otel getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]/{id}")]
        public IActionResult GetHotelById(int id)
        {
            var hotel = _hotelService.GetHotelById(id);
            if(hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("[action]/{name}")]
        public IActionResult GetHotelByName(string name)
        {
            var hotel = _hotelService.GetHotelByName(name);
            if (hotel != null)
            {
                return Ok(hotel);
            }
            return NotFound();
          
        }
        /// <summary>
        /// Yeni otel ekleme
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("[action]")]
        public IActionResult CreateHotel ([FromBody]Hotel hotel)
        {
            var createdHotel= _hotelService.CreateHotel(hotel);
            return CreatedAtAction("Get", new { id = createdHotel.Id }, createdHotel);
        }
        /// <summary>
        /// Otel bilgisi guncelleme
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("[action]")]
        public IActionResult UpdateHotel([FromBody] Hotel hotel)
        {
            if(_hotelService.GetHotelById(hotel.Id)!=null)
            {
                return Ok(_hotelService.UpdateHotel(hotel));
            }
            return NotFound();
        }
        /// <summary>
        /// Otel Silme 
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete]
        [Route("[action]/{id}")]
        public IActionResult DeleteHotel(int id)
        {
            if(_hotelService.GetHotelById(id) != null)
            {
                _hotelService.DeleteHotel(id);
                return Ok();
            }
            return NotFound();
        }


    }
}
