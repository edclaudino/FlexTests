using PortalDeNoticias.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalDeNoticias.Data
{
    public class SeedingService
    {
        private PortalDeNoticiasContext _context;

        public SeedingService(PortalDeNoticiasContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Autor.Any() ||
                _context.Noticia.Any())
            {
                return; // DB já populado
            }

            Autor a1 = new Autor(1, "Gary Chapman");
            Autor a2 = new Autor(2, "Nassim Nicholas Taleb");
            Autor a3 = new Autor(3, "Eckhart Tolle");
            Autor a4 = new Autor(4, "James C. Hunter");

            Noticia n1 = new Noticia(1, "Antifrágil", "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.", a2);
            Noticia n2 = new Noticia(2, "As 5 linguagens do Amor", "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo voluptas nulla pariatur?", a1);
            Noticia n3 = new Noticia(3, "O poder do Agora", "Morbi quis pretium odio. Suspendisse imperdiet et dolor ac varius. Donec tortor risus, imperdiet sit amet sapien sed, scelerisque mattis urna. Fusce sed mauris sollicitudin, ultrices nulla ut, hendrerit enim. Nam gravida consequat efficitur. Curabitur ac orci a neque tincidunt iaculis. Maecenas velit nisl, maximus a vestibulum a, lobortis euismod ante. Suspendisse vel semper tortor.", a3);
            Noticia n4 = new Noticia(4, "A Lógica do Cisne Negro", "At vero eos et accusamus et iusto odio dignissimos ducimus qui blanditiis praesentium voluptatum deleniti atque corrupti quos dolores et quas molestias excepturi sint occaecati cupiditate non provident, similique sunt in culpa qui officia deserunt mollitia animi, id est laborum et dolorum fuga. Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae. Itaque earum rerum hic tenetur a sapiente delectus, ut aut reiciendis voluptatibus maiores alias consequatur aut perferendis doloribus asperiores repellat.", a2);
            Noticia n5 = new Noticia(5, "Zero a zero", "Cras dolor mi, faucibus at scelerisque nec, bibendum et lacus. Ut dui ligula, auctor non sollicitudin a, imperdiet eu velit. Aliquam sed mi at diam commodo interdum vel ut lorem. Aenean dolor libero, maximus vitae mauris nec, hendrerit malesuada odio. Ut eu auctor sapien, id convallis sem. Donec id est diam. Cras pulvinar lacinia justo, vel ullamcorper dui feugiat sed. Vivamus egestas leo justo, dignissim consequat ligula iaculis ut. In tincidunt tristique lorem, in iaculis enim dapibus egestas. Curabitur nec bibendum libero. Etiam dapibus dictum lorem non imperdiet. Nam gravida nisl sit amet ligula tempor accumsan. Quisque bibendum velit sit amet malesuada elementum. Duis laoreet ex a dolor faucibus suscipit. Nulla sed sem eleifend, ultrices mi a, placerat diam. Pellentesque facilisis, neque id pharetra dignissim, risus lorem viverra diam, non consequat felis dui a purus.", a1);
            Noticia n6 = new Noticia(6, "O monge e o executivo", "Suspendisse vel risus id enim ultrices imperdiet. Maecenas lobortis interdum mi ut maximus. Etiam commodo justo a felis pellentesque ultricies. Duis sed condimentum dolor. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Quisque sollicitudin, arcu tristique volutpat accumsan, massa turpis fringilla dolor, vitae gravida turpis quam id mauris. Nullam non tempor odio. Nam eget eleifend velit, ut iaculis enim.", a4);

            _context.Autor.AddRange(a1, a2, a3, a4);

            _context.Noticia.AddRange(n1, n2, n3, n4, n5, n6);

            _context.SaveChanges();
        }
    }
}
