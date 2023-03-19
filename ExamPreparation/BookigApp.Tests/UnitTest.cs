using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class Tests
    {

        [Test]
        public void Test_RoomConstructor()
        {
            Room room = new Room(2, 25);
            Assert.AreNotEqual(room, null);
        }
        [Test]
        public void Test_RoomCapacityNegativeNumber()
        {
            Room room;
            Assert.Throws<ArgumentException>(() => room = new Room(-5, 25));
            
        }
        [Test]
        public void Test_RoomPriceNegativeNumber()
        {
            Room room;
            Assert.Throws<ArgumentException>(() => room = new Room(2, -5));
        }
        [Test]
        public void Test_BookingConstructor()
        {
            Room room = new Room(2, 25);
            Booking booking = new Booking(1, room, 5);
            Assert.AreNotEqual(booking, null);
        }
        [Test]
        public void Test_HotelConstructor()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Assert.AreNotEqual(hotel, null);
        }
        [Test]
        public void Test_RoomListWorksProperly()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Assert.AreEqual(hotel.Rooms.Count, 0);
        }
        [Test]
        public void Test_BookingListWorksProperly()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Assert.AreEqual(hotel.Bookings.Count, 0);
        }
        [Test]
        public void Test_NullNameHotel()
        {
            Hotel hotel;
            Assert.Throws<ArgumentNullException>(() => hotel = new Hotel("", 4));
        }
        [Test]
        public void Test_CategoryOutOfRangeHotel()
        {
            Hotel hotel;
            Assert.Throws<ArgumentException>(() => hotel = new Hotel("Aqua", 7));
        }
        [Test]
        public void Test_HotelTurnover()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Assert.AreEqual(hotel.Turnover, 0);
        }
        [Test]
        public void Test_AddRoom()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Room room = new Room(2, 25);
            hotel.AddRoom(room);
            Assert.AreEqual(hotel.Rooms.Count, 1);
        }
        [Test]
        public void Test_BookRoomAdultsNegative()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Room room = new Room(2, 25);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(-5, 4, 5, 50));
        }
        [Test]
        public void Test_BookRoomChildrenNegative()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Room room = new Room(2, 25);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(5, -2, 5, 50));
        }
        [Test]
        public void Test_BookRoomDurationSmallerThanOne()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Room room = new Room(2, 25);
            hotel.AddRoom(room);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(5, 4, 0, 50));
        }
        [Test]
        public void Test_BookRoomWorksProperly()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Room room = new Room(2, 25);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 2, 70);
            Assert.AreEqual(hotel.Bookings.Count, 1);
        }
        [Test]
        public void Test_BookRoomWorksProperlyTurnover()
        {
            Hotel hotel = new Hotel("Aqua", 4);
            Room room = new Room(2, 25);
            hotel.AddRoom(room);
            hotel.BookRoom(1, 1, 2, 70);
            Assert.AreEqual(hotel.Turnover, 50);
        }
    }
}