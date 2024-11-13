using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAPI3P.Model
{
    internal class Pelicula
    {
        public Pelicula() { }
        public Pelicula(string titulo, string director, string genero, int anio)
        {
            Titulo = titulo;
            Director = director;
            Genero = genero;
            Anio = anio;
        }

        public Pelicula(int id, string titulo, string director, string genero, int anio)
        {
            Id = id;
            Titulo = titulo;
            Director = director;
            Genero = genero;
            Anio = anio;
        }

        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public int Anio { get; set; }

    }
}
