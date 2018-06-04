using System.Linq;
using System.Web.Mvc;
using ERPv1.Models.DbContext;
using ERPv1.Models.ViewModels;

namespace ERPv1.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {

        private readonly ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Dashboard
        public ActionResult Index()
        {
            var vm = new DashboardViewModel
            {
                AuftragListe = _db.Auftrag.ToList(),
                KundenListe = _db.Kunden.ToList(),
                LagerListe = _db.Lager.ToList(),
                WarenListe = _db.Waren.ToList()
            };

            return View(vm);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}