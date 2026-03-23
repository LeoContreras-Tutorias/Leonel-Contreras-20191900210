namespace ApiVideojuegos.Domain.Entities
{
    public class Videojuego
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public int CategoriaId { get; set; }
        public bool Activo { get; set; }

        public Categoria? Categoria { get; set; }
    }
}