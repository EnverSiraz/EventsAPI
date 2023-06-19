using EventsAPI.Models.DTOs.PlaceDtos.RequestDtos;
using EventsAPI.Models.DTOs.PlaceDtos.ResponseDtos;
using EventsAPI.Models.ORMs;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Metrics;

namespace EventsAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlaceController : ControllerBase
    {
        EventsDb context = new EventsDb();


        [HttpGet]
        public IActionResult GetAll()
        {
            List<GetAllPlacesResponseDto> result = context.Places.Select(x => new GetAllPlacesResponseDto()
            {
                Id = x.Id,
                PlaceName = x.PlaceName,
                PlaceDescription = x.PlaceDescription,
                PlaceCity = x.PlaceCity,
                PlaceAdress = x.PlaceAdress,
                PlaceMapUrl = x.PlaceMapUrl

            }).ToList();

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No Place in the database!");
            }

        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Place place = context.Places.FirstOrDefault(x => x.Id == id);
            if (place == null)
            {
                return BadRequest("There is no Place in database with id:" + id);
            }
            else
            {
                return Ok(new GetPlaceByIdResponseDto()
                {
                    Id = place.Id,
                    PlaceName = place.PlaceName,
                    PlaceDescription = place.PlaceDescription,
                    PlaceCity = place.PlaceCity,
                    PlaceAdress = place.PlaceAdress,
                    PlaceMapUrl = place.PlaceMapUrl

                });
            }
        }
        [HttpPost("create")]
        public IActionResult Create(CreatePlaceRequestDto request)
        {
            Place place = context.Places.FirstOrDefault(p => p.PlaceName.ToLower() == request.PlaceName.ToLower().Trim());

            if (place == null)
            {
                Place place1 = new Place()
                {
                    PlaceName = request.PlaceName,
                    PlaceDescription = request.PlaceDescription,
                    PlaceCity = request.PlaceCity,
                    PlaceAdress = request.PlaceAdress,
                    PlaceMapUrl = request.PlaceMapUrl
                };
                context.Places.Add(place1);
                context.SaveChanges();
                return Ok(request);

            }

            else
            {
                return BadRequest(request.PlaceName + " already exists!");
            }

        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            Place place = context.Places.FirstOrDefault(x => x.Id == id);
            if (place == null)
            {
                return BadRequest("There is no place with id = " + id);
            }

            else
            {
                context.Remove(place);
                context.SaveChanges();
                return Ok("Place with id= " + id + " is deleted!");
            }


        }

        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdatePlaceRequestDto request)
        {
            Place place = context.Places.FirstOrDefault(x => x.Id == id);
            if (place == null)
            {
                return BadRequest("There is no place with id = " + id);
            }
            else
            {
                if (context.Places.FirstOrDefault(x => x.PlaceName.ToLower() == request.PlaceName.ToLower()) != null)
                {
                    return BadRequest(request.PlaceName + "already exists!");
                }

                else
                {
                    place.PlaceName = request.PlaceName;
                    place.PlaceDescription = request.PlaceDescription;
                    place.PlaceCity = request.PlaceCity;
                    place.PlaceAdress = request.PlaceAdress;
                    place.PlaceMapUrl = request.PlaceMapUrl;

                    context.SaveChanges();
                    return Ok(new UpdatePlaceResponseDto
                    {
                        PlaceName = request.PlaceName,
                        PlaceDescription = request.PlaceDescription,
                        PlaceCity = request.PlaceCity,
                        PlaceAdress = request.PlaceAdress,
                        PlaceMapUrl = request.PlaceMapUrl
                    });
                }
            }
        }


    }
}
