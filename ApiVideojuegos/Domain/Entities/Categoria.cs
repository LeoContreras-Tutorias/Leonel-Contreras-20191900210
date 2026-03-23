namespace ApiVideojuegos.Domain.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool Activo { get; set; }

        public List<Videojuego> Videojuegos { get; set; } = new();
    }
}