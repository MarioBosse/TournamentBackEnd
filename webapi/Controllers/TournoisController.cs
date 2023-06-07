using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    public class TournoisController : Controller
    {
        // GET: TournoisController
        public ActionResult Index()
        {
            return View();
        }

        // GET: TournoisController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TournoisController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TournoisController/Create
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

        // GET: TournoisController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TournoisController/Edit/5
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

        // GET: TournoisController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TournoisController/Delete/5
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
