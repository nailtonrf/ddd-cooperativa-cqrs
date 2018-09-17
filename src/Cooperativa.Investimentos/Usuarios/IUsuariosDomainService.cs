using System;
using System.Collections.Generic;

namespace Cooperativa.Investimentos.Usuarios
{
    public interface IUsuariosDomainService
    {
        Usuario Autenticar(string login, string senha);
        IEnumerable<Usuario> ObterTodos();
        Usuario Obter(Guid id);
        Usuario Crar(Usuario user, string password);
    }
}