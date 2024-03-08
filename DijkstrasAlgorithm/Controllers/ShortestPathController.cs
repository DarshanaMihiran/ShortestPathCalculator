using DijkstrasAlgorithm.Models;
using DijkstrasAlgorithm.Repositories.Interfaces;
using DijkstrasAlgorithm.Services.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace DijkstrasAlgorithm.Controllers
{
    public class ShortestPathController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public ShortestPathController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CalculateShortestPath(string fromNodeName, string toNodeName)
        {
            ShortestPathData shortestPathData = _calculatorService.FindShortestPath(fromNodeName.ToUpper(), toNodeName.ToUpper());
            return Json(shortestPathData);
        }
    }
}
