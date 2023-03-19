using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels;
        public HotelRepository()
        {
            this.hotels = new List<IHotel>();
        }
        public IReadOnlyCollection<IHotel> Hotels => this.hotels;
        public void AddNew(IHotel model)
        {
            this.hotels.Add(model);
        }

        public IReadOnlyCollection<IHotel> All()
        {
            return this.Hotels;
        }

        public IHotel Select(string criteria)
        {
            return this.hotels.FirstOrDefault(x => x.GetType().Name == criteria);
        }
    }
}
