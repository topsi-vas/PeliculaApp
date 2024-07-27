namespace PeliculaApp.Models
{
    public class Pelicula
    {
        public int Id { get; set; }
        public string ?Nombre_Pelicula { get; set; }
        public string ?Genero { get; set; }
        public decimal Precio { get; set; }
    }
}
