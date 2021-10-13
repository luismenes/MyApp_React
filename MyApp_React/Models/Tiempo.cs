using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp_React.Models
{
    public class Tiempo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Codigo { get; set; }
        public string Temp { get; set; }
        public string Pressure { get; set; }
        public string Humidity { get; set; }
        public string Temp_min { get; set; }
        public string Temp_max { get; set; }
        public string Description { get; set; }

    }
}
