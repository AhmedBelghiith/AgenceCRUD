using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using Infrastructure.Configurations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Web.Controllers
{
    public class ClientController : Controller
    {
        IServiceClient serviceClient;
        IServiceConseiller serviceConseiller;
        public ClientController(IServiceClient serviceClient, IServiceConseiller serviceConseiller)
        {
            this.serviceClient = serviceClient;
            this.serviceConseiller = serviceConseiller;
        }
        // GET: ClientController
        public ActionResult Index(string login)
        {
            if (login == null)
            {
                return View(serviceClient.GetAll());
            }
            else
            {
                return View(serviceClient.GetMany(c=>c.Login.ToLower().Equals(login.ToLower())));
            }
            
        }

        // GET: ClientController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClientController/Create
        public ActionResult Create()
        {
            ViewBag.ConseillerFK = new SelectList(serviceConseiller.GetAll(), "ConseillerId", "Prenom");
            return View();
        }

        // POST: ClientController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Client c, IFormFile Photo)
        {
            try
            {
                //sauvegarder l'image sous uploads
                if (Photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", Photo.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    Photo.CopyTo(stream);
                    c.Photo = Photo.FileName;
                }
                serviceClient.Add(c);
                serviceClient.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.ConseillerFK = new SelectList(serviceConseiller.GetAll(), "ConseillerId", "Prenom");
            return View(serviceClient.GetById(id));
        }

        // POST: ClientController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Client c,IFormFile Photo)
        {
            try
            {
                //sauvegarder l'image sous uploads
                if (Photo != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", Photo.FileName);
                    Stream stream = new FileStream(path, FileMode.Create);
                    Photo.CopyTo(stream);
                    c.Photo = Photo.FileName;
                }
                serviceClient.Update(c);
                serviceClient.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(serviceClient.GetById(id));
        }

        // POST: ClientController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Client c)
        {
            try
            {
                serviceClient.Delete(c);
                serviceClient.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
