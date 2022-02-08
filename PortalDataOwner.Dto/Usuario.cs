using System;

namespace PortalDataOwner.Dto
{
    public class Usuario
    {
        public int Codigo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public bool Ativo { get; set; }
    }
}
