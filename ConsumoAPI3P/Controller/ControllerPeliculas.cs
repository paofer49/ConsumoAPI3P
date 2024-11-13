using ConsumoAPI3P.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConsumoAPI3P.Controller
{
    internal class ControllerPeliculas : IPelicula
    {
        static readonly HttpClient client = new HttpClient()
        {
            BaseAddress = new Uri("https://localhost:7075/"),
        };
        public async Task ActualizarPeliculas(Pelicula peliculita, int id)
        {
            var json = JsonConvert.SerializeObject(peliculita);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PutAsync($"api/Pelicula/{id}", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Pelicula actualizado con éxito.");
            }
        }

        public async Task CrearPeliculas(Pelicula peliculita)
        {
            var json = JsonConvert.SerializeObject(peliculita);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync("api/Pelicula", content);
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Pelicula creado con éxito.");
            }
        }

        public async  Task EliminarPeliculas(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"api/Pelicula/{id}");
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Pelicula eliminada con éxito.");
            }
        }

        public async Task ObtenerPeliculas()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Pelicula");
            if (response.IsSuccessStatusCode)
            {
                var alumnos = JsonConvert.DeserializeObject<List<Pelicula>>(await response.Content.ReadAsStringAsync());
                foreach (var pel in alumnos)
                {
                    Console.WriteLine($"ID: {pel.Id}, Titulo: {pel.Titulo}, Director: {pel.Director}, Genero: {pel.Genero}, Anio: {pel.Anio} ");
                }
            }
        }

        public async Task ObtenerPeliculasPorId(int id)
        {
            HttpResponseMessage response = await client.GetAsync($"api/Pelicula/{id}");
            if (response.IsSuccessStatusCode)
            {
                var pel = JsonConvert.DeserializeObject<Pelicula>(await response.Content.ReadAsStringAsync());
                Console.WriteLine($"ID: {pel.Id}, Titulo: {pel.Titulo}, Director: {pel.Director}, Genero: {pel.Genero}, Anio: {pel.Anio} ");
            }
        }
    }
}
