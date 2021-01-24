using System.Collections.Generic;

namespace PortalDeNoticias.Models.ViewModels
{
    public class NoticiaFormViewModel
    {
        public Noticia Noticia { get; set; }
        public ICollection<Autor> Autors { get; set; }
    }
}
