using System;
using System.Collections.Generic;

namespace Cooperativa.Investimentos.Usuarios
{
    public sealed class UsuariosDomainService : IUsuariosDomainService
    {
        private readonly IUsuarioStorer _usuarioStorer;

        public UsuariosDomainService(IUsuarioStorer usuarioStorer)
        {
            _usuarioStorer = usuarioStorer;
        }

        public Usuario Autenticar(string login, string senha)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
                return null;

            var user = _usuarioStorer.ObterPeloLogin(login);

            // check if login exists
            if (user == null)
                return null;

            // check if senha is correct
            if (!VerifyPasswordHash(senha, user.PasswordHash, user.PasswordSalt))
                return null;

            // authentication successful
            return user;
        }

        public IEnumerable<Usuario> ObterTodos()
        {
            return _usuarioStorer.ObterTodos();
        }

        public Usuario Obter(Guid id)
        {
            return _usuarioStorer.Obter(id);
        }

        public Usuario Crar(Usuario usuario, string senha)
        {
            // validation
            if (string.IsNullOrWhiteSpace(senha))
                throw new ArgumentNullException("Password is required");

            if (_usuarioStorer.ObterPeloLogin(usuario.Login) == null)
                throw new ArgumentNullException("Username \"" + usuario.Login + "\" is already taken");

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(senha, out passwordHash, out passwordSalt);

            usuario.PasswordHash = passwordHash;
            usuario.PasswordSalt = passwordSalt;

            _usuarioStorer.Crar(usuario);

            return usuario;
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private static bool VerifyPasswordHash(string password, byte[] storedHash, byte[] storedSalt)
        {
            if (password == null) throw new ArgumentNullException("password");
            if (string.IsNullOrWhiteSpace(password)) throw new ArgumentException("Value cannot be empty or whitespace only string.", "password");
            if (storedHash.Length != 64) throw new ArgumentException("Invalid length of senha hash (64 bytes expected).", "passwordHash");
            if (storedSalt.Length != 128) throw new ArgumentException("Invalid length of senha salt (128 bytes expected).", "passwordHash");

            using (var hmac = new System.Security.Cryptography.HMACSHA512(storedSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHash[i]) return false;
                }
            }

            return true;
        }
    }
}
