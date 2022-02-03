using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using peliculas.Models.Response;
using peliculas.Models;
using peliculas.Models.Request;

namespace Peliculas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            Respuesta oRespuesta = new Respuesta();

            try
            {
                using (blazorcrudContext db = new blazorcrudContext())
                {
                    var lst = db.Peliculas.ToList();
                    oRespuesta.Exito = 1;
                    oRespuesta.Data = lst;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;

            }
            return Ok(oRespuesta);
        }

        [HttpPost]
        public IActionResult Add(peliculasRequest Models)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (blazorcrudContext db = new blazorcrudContext())
                {
                    Pelicula Opeli = new Pelicula();
                    Opeli.Id = Models.Id;
                    Opeli.Titulo = Models.Titulo;
                    Opeli.Director = Models.Director;
                    Opeli.Género = Models.Género;
                    Opeli.Puntuación = Models.Puntuación;
                    Opeli.Rating = Models.Rating;
                    Opeli.AñoDePublicación = Models.AñoDePublicación;
                    db.Peliculas.Add(Opeli);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        
        [HttpPut]
        public IActionResult Editar(peliculasRequest Models)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (blazorcrudContext db = new blazorcrudContext())
                {

                    //ID para modificar los datos
                    Pelicula Opeli = db.Peliculas.Find(Models.Id);
                    Opeli.Id = Models.Id;
                    Opeli.Titulo = Models.Titulo;
                    Opeli.Director = Models.Director;
                    Opeli.Género = Models.Género;
                    Opeli.Puntuación = Models.Puntuación;
                    Opeli.Rating = Models.Rating;
                    Opeli.AñoDePublicación = Models.AñoDePublicación;
                    //Indica que se modifico
                    db.Entry(Opeli).State = Microsoft.EntityFrameworkCore.EntityState.Modified; ;
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }

        
        [HttpDelete("{id}")]
        public IActionResult Eliminar(int Id)
        {
            Respuesta oRespuesta = new Respuesta();
            try
            {
                using (blazorcrudContext db = new blazorcrudContext())
                {

                    //para eliminar una pelicula con el ID
                    Pelicula Opeli = db.Peliculas.Find(Id);

                    
                    //elimina los datos en el Registro
                    db.Remove(Opeli);
                    db.SaveChanges();
                    oRespuesta.Exito = 1;
                }
            }
            catch (Exception ex)
            {
                oRespuesta.Mensaje = ex.Message;
            }
            return Ok(oRespuesta);
        }
    }
}









