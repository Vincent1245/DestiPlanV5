using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DestiPlanv5.ViewModel
{
    internal class MyTripViewModel
    {
        public List<Models.Trip> Trips { get; set; }


        public MyTripViewModel()
        {
            Trips = new List<Models.Trip>();

            var task = Task.Run(() => GetTripsFromDb());
            task.Wait();
            Trips.AddRange(task.Result);
        }
        private async Task<List<Models.Trip>> GetTripsFromDb()
        {
            List<Models.Trip> tripsFromDb = await Data.Db.TripCollection().AsQueryable().ToListAsync();
            return tripsFromDb;
        }
    }
}
