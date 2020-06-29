using System;

namespace ImportProject.DAL
{
    class HotelDAL
    {
        private readonly TestHotelsDataEntities _db = Dc.StaticData;
        public bool Add(Hotel hotels, out string message)
        {
            try
            {
                if (hotels != null)
                {
                    _db.Hotels.Add(hotels);
                    _db.SaveChanges();
                    message = "Added Successfully";
                    return true;
                }
                message = "Hotels object is null";
                return false;
            }
            catch (Exception e)
            {
                message = e.Message;
                return false;
            }
        }
    }

}
