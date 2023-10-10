using BulkyBook.DataAccess.Repository.IRepository;
using BulkyBook.Models;

namespace BulkyBook.DataAccess.Repository
{
    public class ReferralRepository : Repository<Referral>, IReferralRepository
    {
        private readonly ApplicationDbContext _db;

        public ReferralRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(Referral obj)
        {
            _db.Referrals.Update(obj);
        }
    }
}
