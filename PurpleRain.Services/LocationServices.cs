using PurpleRain.Data;
using PurpleRain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PurpleRain.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateLocation(LocationCreate model)
        {
            var entity =
                new Location()
                {
                    OwnerID = _userId,
                    LocationName = model.LocationName,
                    ZipCode = model.ZipCode
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Locations.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<LocationListItem> GetLocations()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Locations
                        .Where(e => e.OwnerID == _userId)
                        .Select(
                            e =>
                                new LocationListItem
                                {
                                    LocationID = e.LocationID,
                                    LocationName = e.LocationName,
                                    ZipCode = e.ZipCode
                                }
                        );

                return query.ToArray();
            }
        }
        public LocationDetails GetLocationById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == id && e.OwnerID == _userId);
                return
                    new LocationDetails
                    {
                        LocationID = entity.LocationID,
                        LocationName = entity.LocationName,
                    };
            }
        }
        public bool UpdateLocation(LocationEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == model.LocationID && e.OwnerID == _userId);

                entity.ZipCode = model.ZipCode;
                entity.LocationName=model.LocationName;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteLocation(int locationID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Locations
                        .Single(e => e.LocationID == locationID && e.OwnerID == _userId);
                if (entity.Outfit != null && entity.Action != null)    
                {
                    ctx.Outfit.Remove(entity.Outfit);
                    ctx.Action.Remove(entity.Action);
                    ctx.Locations.Remove(entity);
                    return ctx.SaveChanges() == 3;
                }
                else if (entity.Outfit != null)
                {
                    ctx.Outfit.Remove(entity.Outfit);
                    ctx.Locations.Remove(entity);
                    return ctx.SaveChanges() == 2;
                }
                else if (entity.Action != null)
                {
                    ctx.Action.Remove(entity.Action);
                    ctx.Locations.Remove(entity);
                    return ctx.SaveChanges() == 2;
                }
                else
                {
                    ctx.Locations.Remove(entity);
                    return ctx.SaveChanges() == 1;
                }

            }
        }
    }
}

