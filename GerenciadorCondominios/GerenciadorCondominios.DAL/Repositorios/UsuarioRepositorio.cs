using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interface;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Repositorios
{
    public class UsuarioRepositorio : RepositorioGenerico<Usuario>, IUsuarioRepositorio
    {
        private readonly Contexto _contexto;
        private readonly UserManager<Usuario> _gerenciadorUsuarios;
        private readonly SignInManager<Usuario> _gerenciadorLogin;

        public UsuarioRepositorio(Contexto contexto, UserManager<Usuario> gerenciadorUsuarios, SignInManager<Usuario> gerenciadorLogin) : base(contexto)
        {
            _contexto = contexto;
            _gerenciadorLogin = gerenciadorLogin;
            _gerenciadorUsuarios = gerenciadorUsuarios;
        }

        public async Task<IdentityResult> CriarUsuario(Usuario usuario, string senha)
        {
            try
            {
                return await _gerenciadorUsuarios.CreateAsync(usuario, senha);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task IncluirUsuarioEmFuncao(Usuario usuario, string funcao)
        {
            try
            {
                await _gerenciadorUsuarios.AddToRoleAsync(usuario, funcao);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task LogarUsuario(Usuario usuario, bool lembrar)
        {
            try
            {
                await _gerenciadorLogin.SignInAsync(usuario, lembrar);
            }
            catch (Exception e)
            {
                throw e;
                //throw new Exception("An error ocurred: " + e.Message); 
            }
        }

        public async Task DeslogarUsuario()
        {
            try
            {
                await _gerenciadorLogin.SignOutAsync();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<Usuario> PegarUsuarioPeloEmail(string email)
        {
            try
            {
                return await _gerenciadorUsuarios.FindByEmailAsync(email);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task AtualizarUsuario(Usuario usuario)
        {
            try
            {
                await _gerenciadorUsuarios.UpdateAsync(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public int VerificarSeExisteRegistro()
        {
            try
            {
                return _contexto.Usuarios.Count();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<bool> VerificarSeUsuarioEstaEmFuncao(Usuario usuario, string funcao)
        {
            //throw new NotImplementedException();
            try
            {
                return await _gerenciadorUsuarios.IsInRoleAsync(usuario, funcao);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<IEnumerable<string>> PegarFuncoesUsuario(Usuario usuario)
        {
            //throw new NotImplementedException();
            try
            {
                return await _gerenciadorUsuarios.GetRolesAsync(usuario);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IdentityResult> RemoverFuncoesUsuario(Usuario usuario, IEnumerable<string> funcoes)
        {
            //throw new NotImplementedException();
            try
            {
                return await _gerenciadorUsuarios.RemoveFromRolesAsync(usuario, funcoes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<IdentityResult> IncluirUsuarioEmFuncoes(Usuario usuario, IEnumerable<string> funcoes)
        {
            //throw new NotImplementedException();
            try
            {
                return await _gerenciadorUsuarios.AddToRolesAsync(usuario, funcoes);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Usuario> PegarUsuarioPeloNome(ClaimsPrincipal usuario)
        {
            //throw new NotImplementedException();
            try
            {
                return await _gerenciadorUsuarios.FindByNameAsync(usuario.Identity.Name);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public async Task<Usuario> PegarUsuarioPeloId(string usuarioId)
        {
            //throw new NotImplementedException();
            try
            {
                return await _gerenciadorUsuarios.FindByIdAsync(usuarioId);
            }
            catch (Exception e)
            {
                throw e;
            }
            
        }

        public string CodificarSenha(Usuario usuario, string senha)
        {
            //throw new NotImplementedException();
            try
            {
                return _gerenciadorUsuarios.PasswordHasher.HashPassword(usuario, senha);
            }
            catch (Exception e)
            {
                throw e;
            }
            

            
        }
    }
}
