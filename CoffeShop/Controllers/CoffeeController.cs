using CoffeeShop.Models;
using CoffeeShop.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeRepository _coffeeRepository;
        private readonly IBeanVarietyRepository _beanVarietyRepository;
        public CoffeeController(ICoffeeRepository coffeeRepository, IBeanVarietyRepository beanVarietyRepository)
        {
            _coffeeRepository = coffeeRepository;
            _beanVarietyRepository = beanVarietyRepository;
        }
        //https://localhost:5001/api/coffee/
        [HttpGet]
        public IActionResult Get()
        {
            var CoffeeList = _coffeeRepository.GetAll();
            foreach (Coffee coffee in CoffeeList)
            {
                coffee.BeanVariety = _beanVarietyRepository.Get(coffee.BeanVarietyId);
            }
            return Ok(CoffeeList);
        }
        //https://localhost:3000/api/coffee/4
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var coffee = _coffeeRepository.Get(id);
            if (coffee == null) { return NotFound(); }
            coffee.BeanVariety = _beanVarietyRepository.Get(coffee.BeanVarietyId);
            return Ok(coffee);
        }
        //https://localhost:3000/api/coffee
        [HttpPost]
        public IActionResult Post(Coffee coffee)
        {
            _coffeeRepository.Add(coffee);
            return CreatedAtAction("Get", new { id = coffee.Id }, coffee);
        }
        //https://localhost:3000/api/coffee/4
        [HttpPut("{id}")]
        public IActionResult Put(int id, Coffee coffee)
        {
            if (id != coffee.Id) { return BadRequest(); }
            _coffeeRepository.Update(coffee);
            return NoContent();
        }
        //https://localhost:3000/api/coffee/4
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _coffeeRepository.Delete(id);
            return NoContent();
        }


    }
}
