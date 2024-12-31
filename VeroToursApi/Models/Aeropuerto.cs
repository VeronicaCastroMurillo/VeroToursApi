using System;
using System.Collections.Generic;

namespace VeroToursApi.Models;

public partial class Aeropuerto
{
    public int AeropuertoId { get; set; }

    public string Nombre { get; set; } = null!;

    public string Codigo { get; set; } = null!;

    public string Ciudad { get; set; } = null!;

    public string Pais { get; set; } = null!;

    public virtual ICollection<Vuelo> VueloDestinos { get; set; } = new List<Vuelo>();

    public virtual ICollection<Vuelo> VueloOrigens { get; set; } = new List<Vuelo>();
}
