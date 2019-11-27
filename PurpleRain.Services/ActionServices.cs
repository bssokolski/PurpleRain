using PurpleRain.Data;
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
                new Data.Actionz() //"Data". resolves error that states ambiguous reference between PurpleRain.Data.Action and System.Action
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

        public Actionz GetActionByTemp(int temp)
        {


            if (temp >= 0 && temp < 11)
            {
                Atemperature range = (Atemperature)0;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity
                        };
                }
            }
            else if (temp >= 11 && temp < 21)
            {
                Atemperature range = (Atemperature)1;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity
                        };
                }
            }
            else if (temp >= 21 && temp < 31)
            {
                Atemperature range = (Atemperature)2;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity
                        };
                }
            }
            else if (temp >= 31 && temp < 41)
            {
                Atemperature range = (Atemperature)3;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity
                        };
                }
            }
            else if (temp >= 41 && temp < 51)
            {
                Atemperature range = (Atemperature)4;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity
                        };
                }
            }
            else if (temp >= 51 && temp < 61)
            {
                Atemperature range = (Atemperature)5;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity
                        };
                }
            }
            else if (temp >= 61 && temp < 71)
            {
                Atemperature range = (Atemperature)6;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity
                        };
                }
            }
            else if (temp >= 71 && temp < 81)
            {
                Atemperature range = (Atemperature)7;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity
                        };
                }
            }
            else if (temp >= 81 && temp < 91)
            {
                Atemperature range = (Atemperature)8;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity
                        };
                }
            }
            else if (temp >= 91 && temp < 101)
            {
                Atemperature range = (Atemperature)9;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity,
                        };
                }
            }
            else
            {
                Atemperature range = (Atemperature)10;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Action
                            .Single(e => e.AtempRange == range);
                    return
                        new Actionz
                        {
                            ActivityID = entity.ActivityID,
                            Activity = entity.Activity,
                        };
                }
            };
        }
    }
}

