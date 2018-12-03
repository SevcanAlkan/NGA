using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NGA.Data;
using NGA.Domain;

namespace NGA.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/University")]
    public class UniversityController : Controller
    {
        private readonly NGADbContext _context;

        public UniversityController(NGADbContext context)
        {
            _context = context;
        }

        // GET: api/University
        [HttpGet]
        public Task<List<Student>> Get()
        {
            return _context.Students.ToListAsync();
        }

        // GET: api/University/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/University
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/University/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
