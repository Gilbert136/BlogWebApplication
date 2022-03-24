using BlogWebApplication.Data.Models;
using BlogWebApplication.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogWebApplication.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IIndexService _indexService;

        public ContactController(IIndexService indexService)
        {
            _indexService = indexService;
        }

        // POST api/<Contact>
        [HttpPost]
        public async Task<object> Post([FromBody] Contact contact)
        {
            try
            {
                return new { state = true, data = await _indexService.AddContact(contact) };
            }
            catch (Exception e)
            {
                return new { state = false, message = e.Message };
            }
        }

        // GET: api/<Contact>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Contact>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // PUT api/<Contact>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Contact>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
