using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private IRoom room;
        private int residenceDuration;
        private int adultsCount;
        private int childrenCount;
        private int bookingNumber;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            this.Room = room;
            this.ResidenceDuration = residenceDuration;
            this.AdultsCount = adultsCount;
            this.ChildrenCount = childrenCount;
            this.bookingNumber = bookingNumber;
        }

        public IRoom Room { get { return this.room; } private set { this.room = value; } }

        public int ResidenceDuration
        {
            get { return this.residenceDuration; }
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.DurationZeroOrLess);
                }
                this.residenceDuration = value;
            }
        }

        public int AdultsCount
        {
            get { return this.adultsCount; }
            private set
            {
                if(value<1)
                {
                    throw new ArgumentException(ExceptionMessages.AdultsZeroOrLess);
                }
                this.adultsCount = value;
            }
        }

        public int ChildrenCount
        {
            get { return this.childrenCount; }
            private set
            {
                if(value<0)
                {
                    throw new ArgumentException(ExceptionMessages.ChildrenNegative);
                }
                this.childrenCount = value;
            }
        }

        public int BookingNumber => this.bookingNumber;

        public string BookingSummary()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booking number: {this.BookingNumber}");
            sb.AppendLine($"Room type: {room.GetType().Name}");
            sb.AppendLine($"Adults: {this.AdultsCount} Children: {this.ChildrenCount}");
            sb.AppendLine($"Total amount paid: {TotalPaid():F2} $");
            return sb.ToString().Trim();
        }
        private double TotalPaid()
        {
            double totalPaid = Math.Round(this.residenceDuration * this.room.PricePerNight, 2);
            return totalPaid;
        }
    }
}
