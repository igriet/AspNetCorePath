using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanysPieShop.Data;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _repo;
        public HomeViewModel _viewModel;

        public HomeController(IPieRepository repo)
        {
            _repo = repo;
            _viewModel = new HomeViewModel();
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            _viewModel.Title = "Pie overview";
            var pies = _repo.GetAllPies().OrderBy(p => p.Name);
            _viewModel.Pies = pies;
            return View(_viewModel);
        }

        public IActionResult Detail(int id)
        {
            var pie = _repo.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }
    }
}
