using Churras.Models;
using Churras.Services;
using Churras.Web.Models.Churrascos;
using System.Web.Mvc;

namespace Churras.Web.Controllers
{
    public class ChurrascosController : Controller
    {
        IChurrasAppService ChurrascoService;

        public ChurrascosController(IChurrasAppService churrascoService)
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
            ChurrascoService.SaveChurrasco(model.Churrasco);

            return RedirectToAction("Index");
        }

        public PartialViewResult CriarParticipante(int churrascoKey, double valorSemBebida, double valorComBebida)
        {
            var model = new CriarParticipanteViewModel();

            model.ChurrascoKey = churrascoKey;
            model.ValorSemBebida = valorSemBebida;
            model.ValorComBebida = valorComBebida;

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

        public ActionResult PagarParticipante(int key, int churrascoKey)
        {
            ChurrascoService.UpdateParticipantePagamento(key, churrascoKey);
            return RedirectToAction("Detalhes", new { key = churrascoKey });
        }
    }
}
