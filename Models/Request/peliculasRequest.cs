using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace peliculas.Models.Request
{
    public class peliculasRequest
    {
        public partial class Pelicula
        {
            public int Id { get; set; }
            public string Titulo { get; set; }
            public string Director { get; set; }
            public string Género { get; set; }
            public int? Puntuación { get; set; }
            public int? Rating { get; set; }
            public string AñoDePublicación { get; set; }
        }
    }
}



