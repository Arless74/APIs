using APIsRest.Helpers;
using APIsRest.Models;
using APIsRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIsRest.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Users>> GetUsuarios()
    {
        return Ok(UserDataStore.Current.Users);
    }

    [HttpGet("{UsersId}")]
    public ActionResult<Users> GetUser(int UsersId) 
    {
        var usuario = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == UsersId);

        if (usuario == null)
            return NotFound(Mensajes.User.NotFound);

        return Ok(usuario);
    }

    [HttpPost]
    public ActionResult<Users> PostUser(UserInsert userInsert)
    {
        var maxUserId = UserDataStore.Current.Users.Max(u => u.Id);

        var UsuarioNuevo = new Users()
        {
            Id = maxUserId + 1,
            Name = userInsert.Name,
            Email = userInsert.Email,
        };
        UserDataStore.Current.Users.Add(UsuarioNuevo);

        return CreatedAtAction(nameof(GetUser),
            new { UsersId = UsuarioNuevo.Id},
            UsuarioNuevo
        );
    }

    [HttpPut("{UsersId}")]
    public ActionResult<Users> PutUsers([FromRoute]int UsersId,[FromBody] UserInsert userInsert)
    {
        var usuario = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == UsersId);

        if (usuario == null)
            return NotFound(Mensajes.User.NotFound);

        usuario.Name = userInsert.Name;
        usuario.Email = userInsert.Email;


        return NoContent();
    }

    [HttpDelete("{UsersId}")]
    public ActionResult<Users> DeleteUser(int UsersId)
    {
        var usuario = UserDataStore.Current.Users.FirstOrDefault(u => u.Id == UsersId);

        if (usuario == null)
            return NotFound(Mensajes.User.NotFound);

        UserDataStore.Current.Users.Remove(usuario);

        return NoContent();

    }
}
