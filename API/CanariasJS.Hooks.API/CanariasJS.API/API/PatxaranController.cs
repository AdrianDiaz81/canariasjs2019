namespace CanariasJS.Hooks.API.Controllers
{
    using System.Collections.Generic;
    using CanariasJS.API.Model;
    using CanariasJS.Hooks.API.Model;
    using CanariasJS.Hooks.API.Service;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class PatxaranController : ControllerBase
    {
        private readonly IPatxaranService service;
        public PatxaranController(IPatxaranService service)
        {
            this.service = service;
        }

        [HttpGet]
        public  ActionResult<IEnumerable<Patxaran>> Get()
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
        public void Post([FromBody] Patxaran value)
        {
            value.Id = null;
            this.service.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Patxaran value)
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
