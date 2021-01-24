using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PortalDeNoticias.Models
{
    public class Autor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} é obrigatório")]
        public string Nome { get; set; }
        public ICollection<Noticia> Noticias { get; set; } = new List<Noticia>();

        public Autor()
        {

        }

        public Autor(int id, string nome)
        {
            Id = id;
            Nome = nome;
        }

        public void AddNoticia(Noticia n)
        {
            Noticias.Add(n);
        }

        public void RemoveNoticia(Noticia n)
        {
            Noticias.Remove(n);
        }
    }
}
