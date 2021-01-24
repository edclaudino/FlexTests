using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeNoticias.Models
{
    public class Autor
    {
        public int Id { get; set; }
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
