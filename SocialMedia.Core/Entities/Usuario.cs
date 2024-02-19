using System;
using System.Collections.Generic;

namespace SocialMedia.Core.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public string? Telefono { get; set; }

    public bool Activo { get; set; }

    public virtual ICollection<Comment> Comentarios { get; } = new List<Comment>();

    public virtual ICollection<Post> Publicacions { get; } = new List<Post>();
}
