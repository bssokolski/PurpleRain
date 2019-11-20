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
    public class ActionController : Controller
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
        public ActionResult Create(int locationId, ActionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateActionService();

            if (service.CreateAction(locationId, model))
            {
                TempData["SaveResult"] = "Activity successfully added.";
                return RedirectToAction("Index", "Case");
            };

            ModelState.AddModelError("", "Activity could not be added");

            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateActionService();
            var model = svc.GetActionByID(id);

            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var service = CreateActionService();
            var detail = service.GetActionByID(id);
            var model =
                new ActionEdit
                {
                    ActivityID = detail.ActivityID,
                    Activity = detail.Activity,
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ActionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.ActivityID != id)
            {
                ModelState.AddModelError("", "ID Mismatch");
                return View(model);
            }

            var service = CreateActionService();

            if (service.UpdateAction(id, model))
            {
                TempData["SaveResult"] = "The action was updated.";
                return RedirectToAction("Index", "Case");
            }

            ModelState.AddModelError("", "The action could not be updated.");
            return View(model);
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateActionService();
            var model = svc.GetActionByID(id);

            return View(model);
        }
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateActionService();

            service.DeleteAction(id);

            TempData["SaveResult"] = "Action was deleted";


            return RedirectToAction("Index", "Case");
        }
        private ActionService CreateActionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new ActionService(userId);
            return service;
        }
    }
}