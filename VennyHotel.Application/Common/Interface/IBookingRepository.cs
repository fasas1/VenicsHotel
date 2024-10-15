using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VennyHotel.Domain.Entities;

namespace VennyHotel.Application.Common.Interface
{
    public interface IBookingRepository : IRepository<Booking>
    {
      void Update(Booking entity);
      void UpdateStatus(int bookingId, string bookingStatus);
        //void UpdateStatus(int id, string statusApproved);
        void UpdateStripePaymentId(int bookingId,string sessionId,string paymentIntentId);
        //void UpdateStripePaymentId(Booking bookingFromDb, string id, string paymentIntentId);
    }
}
