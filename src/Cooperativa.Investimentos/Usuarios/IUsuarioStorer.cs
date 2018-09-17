using System;
using System.Collections.Generic;

namespace Cooperativa.Investimentos.Usuarios
{
    public interface IUsuarioStorer
    {
        IEnumerable<Usuario> ObterTodos();
        Usuario Obter(Guid id);
        Usuario ObterPeloLogin(string login);
        Usuario Crar(Usuario user);
    }
}