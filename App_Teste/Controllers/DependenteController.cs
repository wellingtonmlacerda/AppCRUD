using App_Teste.Data;
using App_Teste.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;

namespace App_Teste.Controllers
{
    public class DependenteController : Controller
    {
        private readonly TestePraticoContext _context;
        public DependenteController(TestePraticoContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var depen = _context.VdependentesEfuncionarios;
            return View(depen);
        }

        public async Task<ActionResult> DetailsAsync(int id)
        {
            if (id != 0)
                return View(await _context.Procedures.BuscaIDDependentesTBAsync(id));

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome", "DataNascimento", "FuncionarioId", "GeneroID")] BuscaIDDependentesTBResult dependente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.Procedures.AddDependentesTBAsync(dependente.Nome, dependente.DataNascimento, dependente.FuncionarioId, dependente.GeneroID);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {

                if (id != 0)
                {
                    if (await _context.Procedures.BuscaIDDependentesTBAsync(id) is List<BuscaIDDependentesTBResult> listDepen)
                    {
                        var depen = listDepen.First();
                        ViewBag.Genero = new List<SelectListItem>{
                                                    new SelectListItem {Text = "Feminino", Value = "1", Selected = 1 == depen.GeneroID},
                                                    new SelectListItem {Text = "Masculino", Value = "2", Selected = 2 == depen.GeneroID}
                                                };

                        return PartialView("_Edit", depen);
                    }
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Atualiza([Bind("ID","Nome", "DataNascimento", "FuncionarioId", "GeneroID")] BuscaIDDependentesTBResult dependente)
        {
            try
            {
                if (dependente.ID != 0 && ModelState.IsValid)
                {
                    await _context.Procedures.AtualizaDependentesTBAsync(dependente.ID, 
                                                                    dependente.Nome, 
                                                                    dependente.DataNascimento, 
                                                                    dependente.GeneroID);
                    return RedirectToAction(nameof(Index));
                }
                return View(dependente);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirme(int id)
        {
            try
            {
                await _context.Procedures.DeleteDependentesTBAsync(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Pesquisa")]
        public async Task<ActionResult> Pesquisa(string Nome)
        {
            try
            {
                var depenFilter = await _context.Procedures.BuscaDependentesTBAsync(Nome);
                if(depenFilter.Count() > 0)
                {
                    var vDepen = new List<VdependentesEfuncionario>();
                    depenFilter.ForEach(x =>
                    {
                        vDepen.Add(new VdependentesEfuncionario() { 
                            Id = x.ID,
                            DataNascimento = x.DataNascimento,
                            GeneroId = x.GeneroID,
                            Nome = x.Nome,
                            NomeGenero = x.NomeGenero,
                        });
                    });
                    ViewBag.Nome = Nome;
                    return View("Index", vDepen);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
