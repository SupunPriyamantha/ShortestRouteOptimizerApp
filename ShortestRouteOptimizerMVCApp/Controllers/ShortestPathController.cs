using ShortestPathCalculatorApplication;
using ShortestPathCalculatorApplication.IServices;
using ShortestRouteOptimizerMVCApp.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace ShortestRouteOptimizerMVCApp.Controllers
{
    public class ShortestPathController : Controller
    {
        private readonly IShortestPathCalculator _shortestPathCalculator;
        private readonly INodeDataService _nodeDataService;


        public ShortestPathController(
            IShortestPathCalculator shortestPathCalculator,
            INodeDataService nodeDataService)
        {
            _shortestPathCalculator = shortestPathCalculator;
            _nodeDataService = nodeDataService;

        }

        // GET: ShortestPath
        public ActionResult Calculate()
        {
            var shortestPathData = (ShortestPathData)TempData["shortest_path"];
            if (shortestPathData == null)
            {
                return RedirectToAction("Index");
            }
            return View(shortestPathData);
        }

        // GET
        public ActionResult Index()
        {
            string[] initialNodeNames = _nodeDataService.ProvideInitialNodes();
            ShortestPathData shortestPathData = new ShortestPathData();
            shortestPathData.InitialNodeNames = initialNodeNames;

            return View(shortestPathData);
        }

        // POST
        [HttpPost]
        public ActionResult Index(ShortestPathData shortestPathData)
        {
            if (shortestPathData?.StartNode != null &&
                shortestPathData?.FinishNode != null &&
                shortestPathData.StartNode.ToUpper().Equals(shortestPathData.FinishNode.ToUpper()))
            {
                ModelState.AddModelError("FinishNode", "Finish node should be different from start node");
            }

            if (ModelState.IsValid)
            {
                ShortestPathDto shortestPathDto = _shortestPathCalculator.CalculateShortestPath(shortestPathData.StartNode, shortestPathData.FinishNode);

                ShortestPathData shortestPath = new ShortestPathData()
                {
                    StartNode = shortestPathData.StartNode,
                    FinishNode = shortestPathData.FinishNode,
                    ShortestDistance = shortestPathDto.Distance,
                    NodeNames = shortestPathDto.NodeNames.Select(n => n).ToList(),
                };
                TempData["shortest_path"] = shortestPath;
                return RedirectToAction("Calculate");
            }

            string[] initialNodeNames = _nodeDataService.ProvideInitialNodes();
            shortestPathData.InitialNodeNames = initialNodeNames;
            return View(shortestPathData);
        }
    }
}