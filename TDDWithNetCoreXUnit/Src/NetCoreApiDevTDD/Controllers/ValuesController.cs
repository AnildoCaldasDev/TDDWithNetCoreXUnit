using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TddNetCoreDev.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            //only for testes
            if (id != 5)
                return NotFound("Valor informado diferente do esperado");

            return Ok("value" + id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return CreatedAtAction("Post", value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

    }
}
