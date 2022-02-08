using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalDataOwner.Dto
{
    public class LogArquivoMateria
    {
        public int Codigo { get; set; }
        public string Cliente { get; set; }
        public string ChaveImportacao { get; set; }
        public string  Usuario { get; set; }
        public string NomeArquivo { get; set; }
        public int Registros { get; set; }
        public DateTime DataEnvio { get; set; }
        public bool? Estorno { get; set; }
        public DateTime? DataEstorno { get; set; }
        public string UsuarioEstorno { get; set; }
    }
}
