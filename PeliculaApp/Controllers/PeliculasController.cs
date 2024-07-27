using Microsoft.AspNetCore.Mvc;
using PeliculaApp.Models;
using PeliculaApp.Services;

namespace PeliculaApp.Controllers
{
    public class PeliculasController : Controller
    {
        private readonly PeliculaService _peliculaService;
        public PeliculasController(PeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }
        public IActionResult Index()
        {
            var peliculas = _peliculaService.GetPeliculas();
            return View(peliculas);
        }
        public IActionResult Details(int id)
        {
            var pelicula = _peliculaService.GetPeliculaById(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _peliculaService.InsertPelicula(pelicula);
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }
        public IActionResult Edit(int id)
        {
            var pelicula = _peliculaService.GetPeliculaById(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Pelicula pelicula)
        {
            if (ModelState.IsValid)
            {
                _peliculaService.UpdatePelicula(pelicula);
                return RedirectToAction(nameof(Index));
            }
            return View(pelicula);
        }
        public IActionResult Delete(int id)
        {
            var pelicula = _peliculaService.GetPeliculaById(id);
            if (pelicula == null)
            {
                return NotFound();
            }
            return View(pelicula);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _peliculaService.DeletePelicula(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
