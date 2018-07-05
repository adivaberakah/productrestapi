using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Models;

namespace RestApi.Controllers
{
   [ApiVersion("2.0")]
    [Produces("application/json")]
    [Route("api/v{version:apiVersion}/movies")]
    public class MoviesV2Controller : Controller
    {
        List<MoviesV2> movies = new List<MoviesV2>()
        {
            new MoviesV2 {id = 0, MovieName="shrek", Description="Action", Title= "Shrek"},
            new MoviesV2 {id = 1, MovieName="Beauty and the Beast", Description="Romance", Title="Beauty"}
        };
        // GET: api/MoviesV2
        [HttpGet]
        public IEnumerable<MoviesV2> Get()
        {
            return movies;
        }

        // GET: api/MoviesV2/5
        [HttpGet("{id}", Name = "GetMovieV2")]
        public string Get(int id)
        {
            return "value";
        }
        
        // POST: api/MoviesV2
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }
        
        // PUT: api/MoviesV2/5
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
