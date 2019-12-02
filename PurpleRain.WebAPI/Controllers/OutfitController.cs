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
    [Authorize]
    public class OutfitController : ApiController
    {
        //public IHttpActionResult GetAll()
        //{
        //    OutfitService outfitService = CreateOutfitService();
        //    var outfits = outfitService.GetOutfits();
        //    return Ok(outfits);
        //}
        public IHttpActionResult GetEnum(decimal temp, int locationID)
        {
            var outfitService = CreateOutfitService();
            var outfit = outfitService.GetOutfitByTemp(temp, locationID);
            return Ok(outfit);
        }

        public IHttpActionResult Get(int id)
        {
            var outfitService = CreateOutfitService();
            var outfit = outfitService.GetOutfitByID(id);
            return Ok(outfit);
        }

        public IHttpActionResult Post(int locationid, OutfitCreate model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOutfitService();

            if (!service.CreateOutfit(locationid ,model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(int outfitid, OutfitEdit model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOutfitService();

            if (!service.UpdateOutfit(outfitid, model))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateOutfitService();

            if (!service.DeleteOutfit(id))
                return InternalServerError();

            return Ok();
        }

        private OutfitService CreateOutfitService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var outfitService = new OutfitService(userId);
            return outfitService;
        }
    }
}