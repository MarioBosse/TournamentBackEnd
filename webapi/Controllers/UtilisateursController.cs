using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class UtilisateursController : Controller
    {
        // GET: UtilisateursController
        public ActionResult Index()
        {
            return View();
        }

        // GET: UtilisateursController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UtilisateursController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UtilisateursController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilisateursController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UtilisateursController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UtilisateursController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UtilisateursController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
