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
    public class EventosController : Controller
    {

        private readonly IEventoRepositorio _eventoRepositorio;
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public EventosController(IEventoRepositorio eventoRepositorio, IUsuarioRepositorio usuarioRepositorio)
        {
            _eventoRepositorio = eventoRepositorio;
            _usuarioRepositorio = usuarioRepositorio;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloNome(User); // User => informações do usuário logado

            if (await _usuarioRepositorio.VerificarSeUsuarioEstaEmFuncao(usuario, "Morador"))
            {
                return View(await _eventoRepositorio.PegarEventosPeloId(usuario.Id));
            }
            
            return View(await _eventoRepositorio.PegarTodos());
        }

      
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            Usuario usuario = await _usuarioRepositorio.PegarUsuarioPeloNome(User); // User => informações do usuário logado
            Evento evento = new Evento
            {
                UsuarioId = usuario.Id
            };
            return View(evento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Evento evento)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _eventoRepositorio.Inserir(evento);
                    TempData["NovoRegistro"] = $"Evento {evento.Nome} foi cadastrado com sucesso";
                    return RedirectToAction(nameof(Index));
                }

                return View(evento);
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
                Evento evento = await _eventoRepositorio.PegarPeloId(id);
                if (evento == null)
                {
                    return NotFound();
                }
                return View(evento);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Evento evento)
        {
            try
            {
                if (id != evento.EventoId)
                {
                    return NotFound();
                }
                
                if (ModelState.IsValid)
                {
                    await _eventoRepositorio.Atualizar(evento);
                    TempData["Atualizacao"] = $"O evento {evento.Nome} foi atualizado";
                    return RedirectToAction(nameof(Index));
                }

                return View(evento);                
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int id)
        {
            await _eventoRepositorio.Excluir(id);
            TempData["Exclusão"] = "Evento excluído";
            return Json("Evento excluído");
        }

        
    }
}
