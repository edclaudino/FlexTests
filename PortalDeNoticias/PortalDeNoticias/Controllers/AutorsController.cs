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
    public class AutorsController : Controller
    {
        private readonly AutorService _autorService;

        public AutorsController(AutorService autorService)
        {
            _autorService = autorService;
        }

        // GET: Autors
        public async Task<IActionResult> Index()
        {
            var list = await _autorService.FindAllAsync();
            return View(list);
        }

        // GET: Autors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var autor = await _autorService.FindByIdAsync(id.Value); ;
            if (autor == null)
            {
                RedirectToAction(nameof(Error), new { message = "Autor não encontrado" });
            }

            return View(autor);
        }

        private IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
        }

        // GET: Autors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Autors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome")] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }
            await _autorService.InsertAsync(autor);
            return RedirectToAction(nameof(Index));            
        }

        // GET: Autors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var autor = await _autorService.FindByIdAsync(id.Value);
            if (autor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Autor não encontrado" });
            }
            return View(autor);
        }

        // POST: Autors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome")] Autor autor)
        {
            if (!ModelState.IsValid)
            {
                return View(autor);
            }
            if (id != autor.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não correspondem" });
            }

            try
            {
                await _autorService.UpdateAsync(autor);
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

        // GET: Autors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id não fornecido" });
            }

            var autor = await _autorService.FindByIdAsync(id.Value);
            if (autor == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Autor não encontrado" });
            }

            return View(autor);
        }

        // POST: Autors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await _autorService.RemoveAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (IntegrityException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }
    }
}
