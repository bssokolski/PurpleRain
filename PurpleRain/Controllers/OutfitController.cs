using Microsoft.AspNet.Identity;
using PurpleRain.Models;
using PurpleRain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PurpleRain.Controllers
{
    public class OutfitController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create(int id)
        {
            ViewBag.LocationID = id;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int locationId, OutfitCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateOutfitService();

            if (service.CreateOutfit(locationId, model))
            {
                TempData["SaveResult"] = "Outfit successfully added.";
                return RedirectToAction("Index", "Case");
            };

            ModelState.AddModelError("", "Outfit could not be added");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateOutfitService();
            var model = svc.GetOutfitByID(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateOutfitService();
            var detail = service.GetOutfitByID(id);
            var model =
                new OutfitEdit
                {
                    OutfitID = detail.OutfitID,
                    OutfitName = detail.OutfitName,
                    Top = detail.Top,
                    Bottom = detail.Bottom
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, OutfitEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.OutfitID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateOutfitService();

            if (service.UpdateOutfit(id, model))
            {
                TempData["SaveResult"] = "The action was updated.";
                return RedirectToAction("Index", "Case");
            }

            ModelState.AddModelError("", "The action could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateOutfitService();
            var model = svc.GetOutfitByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateOutfitService();

            service.DeleteOutfit(id);

            TempData["SaveResult"] = "Action was deleted";


            return RedirectToAction("Index", "Case");
        }
        private OutfitService CreateOutfitService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new OutfitService(userId);
            return service;
        }
    }
}