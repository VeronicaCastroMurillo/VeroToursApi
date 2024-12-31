using System;
using System.Collections.Generic;

namespace VeroToursApi.Models;

public partial class Reserva
{
    public int ReservaId { get; set; }

    public int UsuarioId { get; set; }

    public int VueloId { get; set; }

    public DateTime? FechaReserva { get; set; }

    public int CantidadPasajeros { get; set; }

    public decimal Total { get; set; }

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual Vuelo Vuelo { get; set; } = null!;
}
