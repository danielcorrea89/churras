using Churras.Services;
using Churras.Web.Models.Churrascos;
using System.Web.Mvc;

namespace Churras.Web.Controllers
{
    public class ChurrascosController : Controller
    {
        IChurrascoService ChurrascoService;

        public ChurrascosController(IChurrascoService churrascoService)
        {
            ChurrascoService = churrascoService;
        }

        // GET: Churrascos
        public ActionResult Index()
        {
            var model = new IndexViewModel();

            model.ChurrascoDashboard = ChurrascoService.GetChurrascoDashboard();
            
            return View(model);
        }

        // GET: Churrascos/Details/5
        public ActionResult Detalhes(int key)
        {
            var model = new DetalhesViewModel();

            model.ChurrascoDetalhes = ChurrascoService.GetChurrascoDetails(key);

            return View(model);
        }

        // GET: Churrascos/Create
        public ActionResult Criar()
        {
            return View();
        }

        // POST: Churrascos/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Churrascos/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Churrascos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Churrascos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Churrascos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
