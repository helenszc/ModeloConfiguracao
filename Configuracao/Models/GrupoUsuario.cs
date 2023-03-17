using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class GrupoUsuario
    {
        public int Id { get; set; }
        public string NomeGrupo { get; set; }
        public List<Permissao> Permissoes { get; set; }
    }
}
