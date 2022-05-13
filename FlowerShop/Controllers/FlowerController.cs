using FlowerShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FlowerShop.Controllers
{
    public class FlowerController : Controller
    {
        private List<FlowersModel> flowers;

        // GET: Flower
        public ActionResult Index()
        {

            FlowerDAO flowerDAO = new FlowerDAO();
            flowers = flowerDAO.FetchAll();
            return View("index", flowers);


        }

        public ActionResult Details(int id)
        {
            FlowerDAO flowerDAO = new FlowerDAO();
            FlowersModel flower = flowerDAO.FetchOne(id);
            return View("Details", flower);
        }

        public ActionResult Create()
        {
            FlowerDAO flowerDAO = new FlowerDAO();
            return View("FlowerForm");
        }
        public ActionResult ProcessCreate(FlowersModel flowersModel)
        {
            FlowerDAO flowerDAO = new FlowerDAO();
            flowerDAO.CreateOrUpdate(flowersModel);
            return View("Details", flowersModel);
        }

        public ActionResult Edit(int id)

        {

            FlowerDAO flowerDAO = new FlowerDAO();

            FlowersModel flower = flowerDAO.FetchOne(id);

            return View("FlowerForm", flower);

        }
    }
}