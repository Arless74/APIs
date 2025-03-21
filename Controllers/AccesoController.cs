using APIsRest.Helpers;
using APIsRest.Models;
using APIsRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIsRest.Controllers
{
    [ApiController]
    [Route("api/user/{UsersId}/[controller]")]
    public class AccesoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Accesos>> GetAccesos(int UsersId)
        {
            var usuario = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == UsersId);

            if (usuario == null)
                return NotFound(Mensajes.User.NotFound);

            return Ok(usuario.Accesos);
        }

        [HttpGet("{AccesoId}")]
        public ActionResult<Accesos> GetAcceso(int UsersId, int AccesosId)
        {
            var usuario = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == UsersId);
            if (usuario == null)
                return NotFound(Mensajes.User.NotFound);

            var acceso = usuario.Accesos?.FirstOrDefault(a => a.Id == AccesosId);
            if (acceso == null)
                return NotFound(Mensajes.Acceso.NotFound);

            return Ok(acceso);

        }


        [HttpPost]
        public ActionResult<Accesos> PostAcceso(int UsersId, AccesoInsert accesoinsert)
        {
            var usuario = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == UsersId);
            if (usuario == null)
                return NotFound(Mensajes.User.NotFound);

            var accesoExistente = usuario.Accesos?.FirstOrDefault(a => a.Name == accesoinsert.Name);
            if (accesoExistente != null)
                return BadRequest(Mensajes.Acceso.mismoAcceso);

            var maxAcceso = usuario.Accesos.Max(a => a.Id);

            var nuevoAcceso = new Accesos()
            {
                Id = maxAcceso + 1,
                Name = accesoinsert.Name,
                Rol = accesoinsert.Rol
            };

            usuario.Accesos.Add(nuevoAcceso);

            return CreatedAtAction(nameof(GetAcceso),
                new { UsersId = UsersId, acceso = nuevoAcceso }
                );
        }

        [HttpPut("{AccesoId}")]
        public ActionResult<Accesos> PutAccesso(int UsersId, int AccesoId, AccesoInsert accesoInsert) 
        {
            //Validacion
            var user = UserDataStore.Current.Users.FirstOrDefault(u =>  u.Id == AccesoId);
            if (user == null)
                return NotFound(Mensajes.User.NotFound);

            var accesoExistente = user.Accesos?.FirstOrDefault(a => a.Id == AccesoId);
            if (accesoExistente == null)
                return NotFound(Mensajes.Acceso.NotFound);
            
            var mismoAcceso = user.Accesos?.
                FirstOrDefault(a => a.Id == AccesoId && a.Name == accesoInsert.Name);
            if (mismoAcceso != null)
                return BadRequest(Mensajes.Acceso.mismoAcceso);

            //Asignacion
            accesoExistente.Name = accesoInsert.Name;
            accesoExistente.Rol = accesoInsert.Rol;

            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Accesos> DeleteAccesso(int UsersId, int AccesoId)
        {
            //Validaciones
            var user = UserDataStore.Current.Users.FirstOrDefault(u => u.Id== UsersId);
            if (user == null)
                return NotFound(Mensajes.User.NotFound);

            var AcceesoExistente = user.Accesos?.FirstOrDefault(a => a.Id == AccesoId);
            if (AcceesoExistente == null)
                return NotFound(Mensajes.Acceso.NotFound);

            //Eliminacion

            user.Accesos?.Remove(AcceesoExistente);
            return NoContent();
        }

    }
   }
