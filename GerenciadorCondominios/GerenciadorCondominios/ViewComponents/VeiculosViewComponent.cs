using GerenciadorCondominios.DAL.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.ViewComponents
{
    public class VeiculosViewComponent : ViewComponent
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;

        public VeiculosViewComponent(IVeiculoRepositorio veiculoRespositorio)
        {
            _veiculoRepositorio = veiculoRespositorio;
        }

        public async Task<IViewComponentResult> InvokeAsync(string id)
        {
            return View(await _veiculoRepositorio.PegarVeiculosPorUsuario(id));
        }
    }
}
