namespace VeroToursApi.DTOS
{
    public class UsuarioDTO
    {
        public int UsuarioId { get; set; }

        public string Contraseña { get; set; } = null!;

        public string Nombre { get; set; } = null!;

        public string Apellido { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string? Telefono { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}
