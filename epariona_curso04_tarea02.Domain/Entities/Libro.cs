namespace epariona_curso04_tarea02.Domain.Entities;

public class Libro
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Autor { get; set; } = string.Empty;
    public string Isbn { get; set; } = string.Empty;
    public DateTime FechaPublicacion { get; set; }
    public decimal Precio { get; set; }
}
