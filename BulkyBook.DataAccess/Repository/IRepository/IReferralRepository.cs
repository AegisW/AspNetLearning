using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IReferralRepository : IRepository<Referral>
    {
        void Update(Referral obj);
    }
}
