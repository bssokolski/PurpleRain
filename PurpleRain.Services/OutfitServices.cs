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
    }
}
