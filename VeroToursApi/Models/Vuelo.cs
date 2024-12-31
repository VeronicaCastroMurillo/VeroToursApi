using System;
using System.Collections.Generic;

namespace VeroToursApi.Models;

public partial class Vuelo
{
    public int VueloId { get; set; }

    public int AerolineaId { get; set; }

    public int OrigenId { get; set; }

    public int DestinoId { get; set; }

    public DateTime FechaHoraSalida { get; set; }

    public DateTime FechaHoraLlegada { get; set; }

    public decimal Precio { get; set; }

    public virtual Aerolinea Aerolinea { get; set; } = null!;

    public virtual Aeropuerto Destino { get; set; } = null!;

    public virtual Aeropuerto Origen { get; set; } = null!;

    public virtual ICollection<Reserva> Reservas { get; set; } = new List<Reserva>();
}
