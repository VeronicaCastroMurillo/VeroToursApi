using System;
using System.Collections.Generic;

namespace VeroToursApi.Models;

public partial class Aerolinea
{
    public int AerolineaId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public virtual ICollection<Vuelo> Vuelos { get; set; } = new List<Vuelo>();
}
