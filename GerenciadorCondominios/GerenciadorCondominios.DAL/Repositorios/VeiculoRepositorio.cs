﻿using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorCondominios.DAL.Repositorios
{
    public class VeiculoRepositorio : RepositorioGenerico<Veiculo>, IVeiculoRepositorio
    {
        private readonly Contexto _contexto;
        public VeiculoRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<Veiculo>> PegarVeiculosPorUsuario(string usuarioId)
        {
            //throw new NotImplementedException();
            try
            {
                return await _contexto.Veiculos.Where(v => v.UsuarioId == usuarioId).ToListAsync();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
