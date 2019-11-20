﻿using Microsoft.AspNet.Identity;
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
        //public IHttpActionResult Get()
        //{
        //    OutfitService outfitService = CreateOutfitService();
        //    var outfits = outfitService.GetOutfits();
        //    return Ok(outfits);
        //}
        public IHttpActionResult Get(int id)
        {
            OutfitService outfitService = CreateOutfitService();
            var outfit = outfitService.GetOutfitByID(id);
            return Ok(outfit);
        }

        public IHttpActionResult Post(int locationID,OutfitCreate outfit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOutfitService();

            if (!service.CreateOutfit(locationID,outfit))
                return InternalServerError();
            return Ok();
        }

        public IHttpActionResult Put(int outfitid, OutfitEdit outfit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateOutfitService();

            if (!service.UpdateOutfit(outfitid, outfit))
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
