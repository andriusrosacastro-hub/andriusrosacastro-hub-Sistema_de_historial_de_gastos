using Microsoft.AspNetCore.Mvc;
using Sistemade_de_hsitorial_de_gastos.Data;
using Sistemade_de_hsitorial_de_gastos.Models;

namespace Sistemade_de_hsitorial_de_gastos.Controllers
{
    public class GastosController : Controller
    {
        private readonly GastoData _gastoData;

        public GastosController(GastoData gastoData)
        {
            _gastoData = gastoData;
        }

        // GET: Gastos
        public IActionResult Index()
        {
            var lista = _gastoData.ObtenerGastos();
            return View(lista);
        }

        // GET: Gastos/Details/5
        public IActionResult Details(int id)
        {
            var gasto = _gastoData.ObtenerGastoPorId(id);

            if (gasto == null)
            {
                return NotFound();
            }

            return View(gasto);
        }

        // GET: Gastos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gastos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Gasto gasto)
        {
            if (ModelState.IsValid)
            {
                _gastoData.InsertarGasto(gasto);
                return RedirectToAction(nameof(Index));
            }

            return View(gasto);
        }

        // GET: Gastos/Edit/5
        public IActionResult Edit(int id)
        {
            var gasto = _gastoData.ObtenerGastoPorId(id);

            if (gasto == null)
            {
                return NotFound();
            }

            return View(gasto);
        }

        // POST: Gastos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Gasto gasto)
        {
            if (id != gasto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _gastoData.ActualizarGasto(gasto);
                return RedirectToAction(nameof(Index));
            }

            return View(gasto);
        }

        // GET: Gastos/Delete/5
        public IActionResult Delete(int id)
        {
            var gasto = _gastoData.ObtenerGastoPorId(id);

            if (gasto == null)
            {
                return NotFound();
            }

            return View(gasto);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _gastoData.EliminarGasto(id);
            return RedirectToAction(nameof(Index));
        }
    }
}