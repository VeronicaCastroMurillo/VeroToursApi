using VeroToursApi.DTOS;
using VeroToursApi.Models;

namespace VeroToursApi.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<Usuario>> ListarUsuarios();
        Task<bool> CrearUsuario(UsuarioDTO usuario);
        Task<bool> EditarUsuario(UsuarioDTO usuario);
        Task<bool> BorrarUsuario(int id);
    }
}
