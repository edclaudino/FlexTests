using System.ComponentModel.DataAnnotations;

namespace PortalDeNoticias.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Título")]
        public string Titulo { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Texto { get; set; }
        public Autor Autor { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        [Display(Name = "Autor")]
        public int AutorId { get; set; }

        public Noticia()
        {

        }

        public Noticia(int id, string titulo, string texto, Autor autor)
        {
            Id = id;
            Titulo = titulo;
            Texto = texto;
            Autor = autor;
        }
    }
}
