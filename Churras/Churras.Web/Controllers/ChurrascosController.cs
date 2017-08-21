using Churras.Models;
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
        public ActionResult Criar(CriarViewModel model)
        {
            try
            {
                ChurrascoService.SaveChurrasco(model.Churrasco);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public PartialViewResult CriarParticipante(int churrascoKey)
        {
            var model = new CriarParticipanteViewModel();
            model.ChurrascoKey = churrascoKey;
            return PartialView("_CriarParticipante", model);
        }

        [HttpPost]
        public ActionResult CriarParticipante(CriarParticipanteViewModel model)
        {
            ChurrascoService.SaveParticipante(model.Participante, model.ChurrascoKey);
            return RedirectToAction("Detalhes", new { key = model.ChurrascoKey });
        }

        public PartialViewResult ListaParticipantes(ChurrascoDetalhes churrasco)
        {
            var model = new ListaParticipantesViewModel();

            model.ChurrascoKey = churrasco.Key;
            model.ChurrascoNome = churrasco.Descricao;

            model.Participantes = ChurrascoService.GetParticipanteList(churrasco.Key);

            return PartialView("_ListaParticipantes", model);
        }

        public ActionResult RemoverParticipante(int key, int churrascoKey)
        {
            ChurrascoService.DeleteParticipante(key, churrascoKey);
            return RedirectToAction("Detalhes", new { key = churrascoKey });
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
