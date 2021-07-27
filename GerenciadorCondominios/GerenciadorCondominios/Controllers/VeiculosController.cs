using GerenciadorCondominios.BLL.Models;
using GerenciadorCondominios.DAL.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorCondominios.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly IVeiculoRepositorio _veiculoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public VeiculosController(IVeiculoRepositorio veiculoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _veiculoRepositorio = veiculoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }



        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VeiculoID,Nome, Marca,Cor,Placa,UsuarioId")] Veiculo veiculo)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloNome(User);
                    veiculo.UsuarioId = usuario.Id;
                    await _veiculoRepositorio.Inserir(veiculo);
                    return RedirectToAction("MinhasInformacoes", "Usuarios");
                }

                return View(veiculo);
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var veiculo = await _veiculoRepositorio.PegarPeloId(id);

                if (veiculo == null)
                {
                    return NotFound();
                }

                return View(veiculo);
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VeiculoId,Nome,Marca,Cor,Placa,UsuarioId")] Veiculo veiculo)
        {
            try
            {
                if (id != veiculo.VeiculoId)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    await _veiculoRepositorio.Atualizar(veiculo);
                    return RedirectToAction("MinhasInformacoes", "Usuarios");
                }

                return View(veiculo);
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> Delete(int id)
        {
            try
            {
                await _veiculoRepositorio.Excluir(id);
                return Json("veículo excluído com sucesso");
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
