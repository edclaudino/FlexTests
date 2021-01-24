using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PortalDeNoticias.Data;
using PortalDeNoticias.Models;
using PortalDeNoticias.Models.ViewModels;
using PortalDeNoticias.Services;
using PortalDeNoticias.Services.Exceptions;

namespace PortalDeNoticias.Controllers
{
    public class NoticiasController : Controller
    {
        private readonly NoticiaService _noticiaService;
        private readonly AutorService _autorService;

        public NoticiasController(NoticiaService noticiaService, AutorService autorService)
        {
            _noticiaService = noticiaService;
            _autorService = autorService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _noticiaService.FindAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Create()
        {
            var autors = await _autorService.FindAllAsync();
            var viewModel = new NoticiaFormViewModel { Autors = autors };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                var autors = await _autorService.FindAllAsync();
                var viewModel = new NoticiaFormViewModel { Noticia = noticia, Autors = autors };
                return View(viewModel);
            }
            await _noticiaService.InsertAsync(noticia);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido"});
            }

            var obj = await _noticiaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Notícia não encontrada" }); ;
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _noticiaService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _noticiaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Notícia não encontrada" });
            }

            return View(obj);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var obj = await _noticiaService.FindByIdAsync(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Notícia não encontrada" });
            }

            List<Autor> autors = await _autorService.FindAllAsync();
            NoticiaFormViewModel viewModel = new NoticiaFormViewModel { Noticia = obj, Autors = autors };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Noticia noticia)
        {
            if (!ModelState.IsValid)
            {
                var autors = await _autorService.FindAllAsync();
                var viewModel = new NoticiaFormViewModel { Noticia = noticia, Autors = autors };
                return View(viewModel);
            }
            if (id != noticia.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não correspondem" });
            }

            try
            {
                await _noticiaService.UpdateAsync(noticia);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }
    }
}
