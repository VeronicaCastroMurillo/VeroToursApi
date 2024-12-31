using Microsoft.EntityFrameworkCore;
using VeroToursApi.Context;
using VeroToursApi.DTOS;
using VeroToursApi.Interfaces;
using VeroToursApi.Models;

namespace VeroToursApi.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly VeroToursContext _context;

        // Constructor para inicializar
        public UsuarioService(VeroToursContext context)
        {
            _context = context;
        }

        public async Task<bool> BorrarUsuario(int id)
        {
            try
            {
                //Se consulta el usuario a actualizar
                var usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == id);

                if (usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }

                //Query para realizar consulta
                _context.Usuarios.Remove(usuarioEncontrado);

                // Se guardan cambios en la base de datos
                await _context.SaveChangesAsync();

                return true;
            }

            catch
            {
                throw;
            }
        }

        public async Task<bool> CrearUsuario(UsuarioDTO usuario)
        {
            try
            {
                // Se crea un objeto del tipo Usuario
                Usuario nuevoUsuario = new Usuario() 
                {
                    UsuarioId = usuario.UsuarioId,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    Contraseña = usuario.Contraseña,
                    Email = usuario.Email,
                    Telefono = usuario.Telefono,
                    FechaRegistro = usuario.FechaRegistro,
                    Reservas = null
                };

                //Query para realizar consulta
                _context.Usuarios.Add(nuevoUsuario);

                // Se guardan cambios en la base de datos
                await _context.SaveChangesAsync();

                return true;
            }

            catch
            {
                throw;
            }
        }

        public async Task<bool> EditarUsuario(UsuarioDTO usuario)
        {
            try
            {
                //Se consulta el usuario a actualizar
                var usuarioEncontrado = await _context.Usuarios.FirstOrDefaultAsync(u => u.UsuarioId == usuario.UsuarioId);

                if (usuarioEncontrado == null)
                {
                    throw new TaskCanceledException("El usuario no existe");
                }
                
                //Se asignan los nuevos datos
                usuarioEncontrado.Nombre = usuario.Nombre;
                usuarioEncontrado.Apellido = usuario.Apellido;
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Contraseña = usuario.Contraseña;
                usuarioEncontrado.Telefono = usuario.Telefono;

                //Query para realizar consulta
                _context.Usuarios.Update(usuarioEncontrado);

                // Se guardan cambios en la base de datos
                await _context.SaveChangesAsync();

                return true;
            }

            catch
            {
                throw;
            }
        }

        public async Task<List<Usuario>> ListarUsuarios()
        {
            try
            {
                //Query para hacer la consulta
                var listaUsuario = await _context.Usuarios.ToListAsync();
                return listaUsuario;
            }
            catch
            {
                throw;
            }
        }
    }
}
