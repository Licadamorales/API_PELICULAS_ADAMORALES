using System;
using System.Collections.Generic;

#nullable disable

namespace peliculas.Models.Request
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
