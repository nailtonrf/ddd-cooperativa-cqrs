using Infraestructure.Core.DomainModel;

namespace Cooperativa.Investimentos.Usuarios
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }
        public string Login { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}