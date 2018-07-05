using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApi.Models
{
    public class MoviesV2
    {
        public int id { get; set; }
        public string MovieName { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
    }
}
