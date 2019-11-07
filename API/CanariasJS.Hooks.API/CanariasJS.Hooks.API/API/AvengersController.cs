namespace CanariasJS.Hooks.API.Controllers
{
    using System.Collections.Generic;
    using CanariasJS.Hooks.API.Model;
    using CanariasJS.Hooks.API.Service;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AvengersController : ControllerBase
    {
        private readonly IAvengersService service;
        public AvengersController(IAvengersService service)
        {
            this.service = service;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<Avengers>> Get()
        {
            //var result = ;
            return Ok(this.service.GetAllAsync().Result);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(string id)
        {
            return Ok(this.service.GetByIdAsync(id).Result);
        }

        [HttpPost]
        public void Post([FromBody] Avengers value)
        {
            this.service.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Avengers value)
        {
            this.service.UpdateAsync(value);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            this.service.DeleteAsync(id);
        }
    }
}
