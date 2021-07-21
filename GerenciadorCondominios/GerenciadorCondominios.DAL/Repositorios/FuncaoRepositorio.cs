using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace GerenciadorCondominios.DAL.Repositorios
{
    public class FuncaoRepositorio : RepositorioGenerico<Funcao>, IFuncaoRepositorio
    {
        public FuncaoRepositorio(Contexto contexto) : base(contexto)
        {
        }
    }
}
