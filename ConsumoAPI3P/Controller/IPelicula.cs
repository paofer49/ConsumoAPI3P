using ConsumoAPI3P.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAPI3P.Controller
{
    internal interface IPelicula
    {
        Task ObtenerPeliculas();
        Task ObtenerPeliculasPorId(int id);
        Task CrearPeliculas(Pelicula peliculita);
        Task ActualizarPeliculas(Pelicula peliculita, int id);
        Task EliminarPeliculas(int id);

    }
}
