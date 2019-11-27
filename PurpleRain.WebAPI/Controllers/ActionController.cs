using Microsoft.AspNet.Identity;
using PurpleRain.Models;
using PurpleRain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PurpleRain.WebAPI.Controllers
{
    public class ActionController : ApiController
    {
        //public IHttpActionResult Get()
        //{
        //    ActionService actionService = CreateActionService();
        //    var actions = actionService.GetActions();
        //    return Ok(actions);
        //}
        public IHttpActionResult GetEnum(int temp)
        {
            var actionService = CreateActionService();
            var action = actionService.GetActionByTemp(temp);
            return Ok(action);
        }

        public IHttpActionResult Get(int id)
        {
            var actionService = CreateActionService();
            var action = actionService.GetActionByID(id);
            return Ok(action);
        }

        public IHttpActionResult Post(int locationid, ActionCreate action)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActionService();

            if (!service.CreateAction(locationid, action))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(int actionID, ActionEdit action)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateActionService();

            if (!service.UpdateAction(actionID, action))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateActionService();

            if (!service.DeleteAction(id))
                return InternalServerError();
            return Ok();
        }
        private ActionService CreateActionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var actionService = new ActionService(userId);
            return actionService;
        }
    }
}
