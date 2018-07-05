using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;

namespace RestApi.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/movies")]
    public class MoviesController : Controller
    {
       static List<MoviesV1> movies = new List<MoviesV1>()
        {
            new MoviesV1 {id = 0, MovieName="shrek"},
            new MoviesV1 {id = 1, MovieName="Beauty and the Beast"}
        };
        // GET: api/Movies
        [HttpGet]
        public IEnumerable<MoviesV1> Get()
        {
            return movies;
        }

        // GET: api/Movies/5
        [HttpGet("{id}", Name = "GetMovieV1")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/Movies
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/Movies/5
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
