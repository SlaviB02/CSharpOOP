﻿using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private List<IBooking> bookings;
        public IReadOnlyCollection<IBooking> Bookings => this.bookings;
        public BookingRepository()
        {
            this.bookings = new List<IBooking>();
        }
        public void AddNew(IBooking model)
        {
            this.bookings.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
        {
            return Bookings;
        }

        public IBooking Select(string criteria)
        {
            return this.bookings.FirstOrDefault(x => x.GetType().Name == criteria);
        }
    }
}
