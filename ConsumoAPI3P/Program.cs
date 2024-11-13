using System;
using ConsumoAPI3P.Controller;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumoAPI3P.Model;

namespace ConsumoAPI3P
{
    internal class Program
    {
        public enum Menu 
        { 
            ObtenerPeliculas = 1, ObtenerPeliculasID, CrearPelicula, ActualizarPelicula, EliminarPelicula, Salir
        }
        static void Main(string[] args)
        {
            ControllerPeliculas controller = new ControllerPeliculas();
            Pelicula p = new Pelicula();
            while (true) 
            {
                switch (Seleccion())
                {
                    case Menu.ObtenerPeliculas:
                        controller.ObtenerPeliculas().Wait();
                        break;
                    case Menu.ObtenerPeliculasID:
                        Console.WriteLine("Ingresa el id de la pelicula que buscas");
                        int pelicula = Convert.ToInt32(Console.ReadLine());
                        controller.ObtenerPeliculasPorId(pelicula).Wait();
                        break;
                    case Menu.CrearPelicula:
                        Console.WriteLine("Ingresa el titulo de la pelicula");
                        p.Titulo=Console.ReadLine();
                        Console.WriteLine("Ingresa el director de la pelicula");
                        p.Director=Console.ReadLine();
                        Console.WriteLine("Ingresa el geero");
                        p.Genero=Console.ReadLine();
                        Console.WriteLine("Ingresa el año");
                        p.Anio=Convert.ToInt32(Console.ReadLine());
                        Pelicula peli = new Pelicula(p.Titulo,p.Director,p.Genero,p.Anio);
                        controller.CrearPeliculas(peli).Wait();
                        break;
                    case Menu.ActualizarPelicula:
                        Console.WriteLine("Ingresa el id de la pelicula que deseas editar");
                        p.Id = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Ingresa el titulo de la pelicula");
                        p.Titulo = Console.ReadLine();
                        Console.WriteLine("Ingresa el director de la pelicula");
                        p.Director = Console.ReadLine();
                        Console.WriteLine("Ingresa el geero");
                        p.Genero = Console.ReadLine();
                        Console.WriteLine("Ingresa el año");
                        p.Anio = Convert.ToInt32(Console.ReadLine());
                        Pelicula pelis = new Pelicula(p.Id, p.Titulo, p.Director, p.Genero, p.Anio);
                        controller.ActualizarPeliculas(pelis, p.Id).Wait();
                        break;
                    case Menu.EliminarPelicula:
                        Console.WriteLine("Ingresa el id de la pelicula que deseas editar");
                        p.Id = Convert.ToInt32(Console.ReadLine());
                        controller.EliminarPeliculas(p.Id).Wait();
                        break;
                    case Menu.Salir:
                        Environment.Exit(1);
                        break;
                    default:
                        break;
                }
            }
        }

        static Menu Seleccion() 
        {
            Console.WriteLine("Selecciona la opcion que deseas hacer");
            Console.WriteLine("1)Mostrar peliculas");
            Console.WriteLine("2)Mostrar pelicula por id");
            Console.WriteLine("3)Ingresar pelicula");
            Console.WriteLine("4)Actualizar pelicula");
            Console.WriteLine("5)Eliminar pelicula");
            Console.WriteLine("6)Salir");

            Menu opc = (Menu)Convert.ToInt32(Console.ReadLine());
            return opc;
        }
    }
}
