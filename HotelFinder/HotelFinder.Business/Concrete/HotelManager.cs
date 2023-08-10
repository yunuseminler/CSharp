using HotelFinder.Business.Abstract;
using HotelFinder.DataAccess.Abstract;
using HotelFinder.DataAccess.Concrete;
using HotelFinder.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.Business.Concrete
{
    public class HotelManager : IHotelService
    {
        private readonly IHotelRepo _HotelRepo;
        public HotelManager(IHotelRepo HotelRepo) {
            _HotelRepo = HotelRepo;
        }
        public Hotel CreateHotel(Hotel hotel)
        {
            return _HotelRepo.CreateHotel(hotel);
        }

        public void DeleteHotel(int id)
        {
           _HotelRepo.DeleteHotel(id);
        }

        public List<Hotel> GetAllHotel()
        {
            return _HotelRepo.GetAllHotel();
        }

        public Hotel GetHotelById(int id)
        {
            if (id > 0) { 
                return _HotelRepo.GetHotelById(id);
            }
            throw new Exception("Id 0 dan buyuk olmali");
        }

        public Hotel UpdateHotel(Hotel hotel)
        {

           return _HotelRepo.UpdateHotel(hotel);
        }
    }
}
