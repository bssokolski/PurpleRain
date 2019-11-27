using PurpleRain.Data;
using PurpleRain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Services
{
    public class OutfitService
    {
        private readonly Guid _userId;

        public OutfitService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateOutfit(int locationid, OutfitCreate model)
        {
            var entity =
                new Outfit()
                {

                    OutfitName = model.OutfitName,
                    Top = model.Top,
                    Bottom = model.Bottom,
                    OtempRange = model.OtempRange

                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Outfit.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    var locations =
                        ctx
                         .Locations
                        .Single(e => e.LocationID == locationid && e.OwnerID == _userId);

                    locations.OutfitID = entity.OutfitID;
                    return ctx.SaveChanges() == 1;
                }
                return false;
            }
        }
        public OutfitDetails GetOutfitByID(int outfitid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Outfit
                        .Single(e => e.OutfitID == outfitid);
                return
                    new OutfitDetails
                    {
                        OutfitID = entity.OutfitID,
                        OutfitName = entity.OutfitName,
                        Top = entity.Top,
                        Bottom = entity.Bottom,
                    };
            }
        }
        public bool UpdateOutfit(int outfitid, OutfitEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Outfit
                        .Single(e => e.OutfitID == outfitid);
                entity.OutfitName = model.OutfitName;
                entity.Top = model.Top;
                entity.Bottom = model.Bottom;
                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteOutfit(int outfitid)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Outfit
                        .Single(e => e.OutfitID == outfitid);
                var entity2 =
                   ctx
                   .Locations
                   .Single(e => e.OutfitID == outfitid);
                entity2.OutfitID = null;
                ctx.Outfit.Remove(entity);
                return ctx.SaveChanges() == 2;
            }
        }

        public Outfit GetOutfitByTemp(decimal temp, int locationID)
        {

            if (temp >= 0 && temp < 11)
            {
                Temperature range = (Temperature)0;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else if (temp >= 11 && temp < 21)
            {
                Temperature range = (Temperature)1;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else if (temp >= 21 && temp < 31)
            {
                Temperature range = (Temperature)2;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else if (temp >= 31 && temp < 41)
            {
                Temperature range = (Temperature)3;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else if (temp >= 41 && temp < 51)
            {
                Temperature range = (Temperature)4;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else if (temp >= 51 && temp < 61)
            {
                Temperature range = (Temperature)5;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else if (temp >= 61 && temp < 71)
            {
                Temperature range = (Temperature)6;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else if (temp >= 71 && temp < 81)
            {
                Temperature range = (Temperature)7;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else if (temp >= 81 && temp < 91)
            {
                Temperature range = (Temperature)8;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else if (temp >= 91 && temp < 101)
            {
                Temperature range = (Temperature)9;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            }
            else 
            {
                Temperature range = (Temperature)10;

                using (var ctx = new ApplicationDbContext())
                {
                    var entity =
                        ctx
                            .Outfit
                            .Single(e => e.OtempRange == range && e.locationID == locationID);
                    return
                        new Outfit
                        {
                            OutfitID = entity.OutfitID,
                            OutfitName = entity.OutfitName,
                            Top = entity.Top,
                            Bottom = entity.Bottom,
                        };
                }
            };



        }
    }
}