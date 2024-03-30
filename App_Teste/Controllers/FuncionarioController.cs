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
    public class FuncionarioController : Controller
    {
        private readonly TestePraticoContext _context;
        public FuncionarioController(TestePraticoContext context)
        {
            _context = context;
        }

        public ActionResult Index()
        {
            var func = _context.Vfuncionarios;
            return View(func);
        }

        public async Task<ActionResult> DetailsAsync(int id)
        {
            if (id != 0)
                return View(await _context.Procedures.BuscaIDFuncionarioTBAsync(id));

            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind("Nome", "DataNascimento", "Salario", "GeneroID")] BuscaIDFuncionarioTBResult funcionario)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _context.Procedures.AddFuncionarioTBAsync(funcionario.Nome, funcionario.DataNascimento, funcionario.Salario, funcionario.GeneroID);
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
                    if (await _context.Procedures.BuscaIDFuncionarioTBAsync(id) is List<BuscaIDFuncionarioTBResult> listFunc)
                    {
                        var func = listFunc.First();
                        ViewBag.Genero = new List<SelectListItem>{
                                                    new SelectListItem {Text = "Feminino", Value = "1", Selected = 1 == func.GeneroID},
                                                    new SelectListItem {Text = "Masculino", Value = "2", Selected = 2 == func.GeneroID}
                                                };

                        return PartialView("_Edit", func);
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
        public async Task<ActionResult> Atualiza([Bind("ID","Nome", "DataNascimento", "Salario", "GeneroID")] BuscaIDFuncionarioTBResult funcionario)
        {
            try
            {
                if (funcionario.ID != 0 && ModelState.IsValid)
                {
                    await _context.Procedures.AtualizaFuncionarioTBAsync(funcionario.ID, 
                                                                    funcionario.Nome, 
                                                                    funcionario.DataNascimento, 
                                                                    funcionario.Salario, 
                                                                    funcionario.GeneroID);
                    return RedirectToAction(nameof(Index));
                }
                return View(funcionario);
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
                await _context.Procedures.DeleteFuncionarioTBAsync(id);
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
                var funcFilter = await _context.Procedures.BuscaFuncionarioTBAsync(Nome);
                if(funcFilter.Count() > 0)
                {
                    var vFunc = new List<Vfuncionario>();
                    funcFilter.ForEach(x =>
                    {
                        vFunc.Add(new Vfuncionario() { 
                            Id = x.ID,
                            DataNascimento = x.DataNascimento,
                            GeneroId = x.GeneroID,
                            Nome = x.Nome,
                            NomeGenero = x.NomeGenero,
                            Salario = x.Salario,
                        });
                    });
                    ViewBag.Nome = Nome;
                    return View("Index", vFunc);
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
