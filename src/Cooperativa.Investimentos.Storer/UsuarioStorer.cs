using System;
using System.Collections.Generic;
using System.Linq;
using Cooperativa.Investimentos.Usuarios;
using Infraestructure.Core.Data;

namespace Cooperativa.Investimentos.Storer
{
    public sealed class UsuarioStorer : IUsuarioStorer
    {
        private readonly InvestimentoDbContext _investimentoDbContext;

        public UsuarioStorer(ISessionContext investimentoDbContext)
        {
            _investimentoDbContext = (InvestimentoDbContext)investimentoDbContext;
        }

        public IEnumerable<Usuario> ObterTodos() => _investimentoDbContext.Usuarios;

        public Usuario Obter(Guid id) => _investimentoDbContext.Usuarios.First(p => p.Id == id);

        public Usuario ObterPeloLogin(string login) => _investimentoDbContext.Usuarios.FirstOrDefault(p => p.Login == login);

        public Usuario Crar(Usuario usuario)
        {
            _investimentoDbContext.Usuarios.Add(usuario);
            _investimentoDbContext.Commit();
            return usuario;
        }
    }
}