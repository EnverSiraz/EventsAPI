using EventsAPI.Models.DTOs.CustomerDtos.RequestDtos;
using EventsAPI.Models.DTOs.CustomerDtos.ResponseDtos;
using EventsAPI.Models.DTOs.EventDtos.RequestDtos;
using EventsAPI.Models.DTOs.EventDtos.ResponseDtos;
using EventsAPI.Models.ORMs;
using Microsoft.AspNetCore.Mvc;

namespace EventsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class CustomerController : ControllerBase
    {
        EventsDb context = new EventsDb();

        [HttpGet]
        public ActionResult GetAll()
        {
            List<GetAllCustomersResponseDto> result = context.Customers.Select(x => new GetAllCustomersResponseDto
            {
                Id = x.Id,
                CustomerEmail = x.CustomerEmail,
                CustomerName = x.CustomerName,
                CustomerPhone = x.CustomerPhone,
                CustomerSurname = x.CustomerSurname
            }).ToList();

            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("No Customer in the database!");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            Customer customer = context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return BadRequest("There is no Customer in database with id:" + id);
            }
            else
            {
                return Ok(new GetCustomerByIdResponseDto()
                {
                    Id = id,
                    CustomerEmail = customer.CustomerEmail,
                    CustomerName = customer.CustomerName,
                    CustomerSurname = customer.CustomerSurname,
                    CustomerPhone = customer.CustomerPhone

                });
            }
        }
        [HttpPost("create")]
        public IActionResult Create(CreateCustomerRequestDto request)
        {
            Customer customer = new Customer()
            {
                CustomerName = request.CustomerName,
                CustomerSurname = request.CustomerSurname,
                CustomerEmail = request.CustomerEmail,
                CustomerPassword = request.CustomerPassword,
                CustomerPhone = request.CustomerPhone

            };
            context.Customers.Add(customer);
            context.SaveChanges();
            return Ok(request);
        }
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteById(int id)
        {
            Customer customer = context.Customers.FirstOrDefault(x => x.Id == id);
            if (customer == null)
            {
                return BadRequest("There is no Customer with id = " + id);
            }

            else
            {
                context.Remove(customer);
                context.SaveChanges();
                return Ok("Customer with id= " + id + " is deleted!");
            }
        }
        [HttpPut("update/{id}")]
        public IActionResult Update(int id, UpdateCustomerRequestDto request)
        {
            Customer customer= context.Customers.FirstOrDefault(x => x.Id==id);
            if (customer==null)
            {
                return BadRequest("There is no Customer with id = " + id);
            }
            else
            {
                customer.CustomerName = request.CustomerName;
                customer.CustomerSurname = request.CustomerSurname; 
                customer.CustomerEmail = request.CustomerEmail;
                customer.CustomerPassword = request.CustomerPassword;
                customer.CustomerPhone = request.CustomerPhone;
                context.SaveChanges();
                return Ok(new UpdateCustomerResponseDto
                {
                    CustomerName = request.CustomerName,
                    CustomerSurname = request.CustomerSurname,
                    CustomerEmail = request.CustomerEmail,
                    CustomerPhone = request.CustomerPhone
                });
            }
        }

    }




}

