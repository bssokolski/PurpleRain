﻿using PurpleRain.Data;
using PurpleRain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Services
{
    public class ActionService
    {
        private readonly Guid _userId;

        public ActionService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateAction(int locationid, ActionCreate model)
        {
            var entity =
                new Data.Action() //"Data". resolves error that states ambiguous reference between PurpleRain.Data.Action and System.Action
                {
                    Activity = model.Activity,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Action.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    var locations =
                        ctx
                         .Locations
                        .Single(e => e.LocationID == locationid && e.OwnerID == _userId);

                    locations.ActivityID = entity.ActivityID;
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
        public ActionDetails GetActionByID(int actionid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Action
                        .Single(e => e.ActivityID == actionid);
                return
                    new ActionDetails
                    {
                        ActivityID = entity.ActivityID,
                        Activity = entity.Activity
                    };
            }
        }
        public bool UpdateAction(int actionid, ActionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Action
                        .Single(e => e.ActivityID == actionid);
                entity.Activity = model.Activity;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteAction(int actionid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Action
                        .Single(e => e.ActivityID == actionid);
                var entity2 =
                   ctx
                   .Locations
                   .Single(e => e.ActivityID == actionid);
                entity2.ActivityID = null;
                ctx.Action.Remove(entity);
                return ctx.SaveChanges() == 2;
            }
        }
    }
}
