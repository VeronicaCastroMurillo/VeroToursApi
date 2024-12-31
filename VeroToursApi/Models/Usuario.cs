using System;
using System.Collections.Generic;

namespace VeroToursApi.Models;

public partial class Usuario
{
    public int UsuarioId { get; set; }

    public string Contraseña { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Telefono { get; set; }

    public DateTime? FechaRegistro { get; set; }

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
