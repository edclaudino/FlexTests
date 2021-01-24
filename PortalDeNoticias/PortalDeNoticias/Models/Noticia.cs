using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeNoticias.Models
{
    public class Noticia
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public Autor Autor { get; set; }

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
