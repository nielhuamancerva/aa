using FinalADS.Domain.Accounts.Contracts;
using FinalADS.Domain.Accounts.Entities;
using FinalADS.Infrastructure.NHibernate;
using NHibernate;
using NHibernate.Criterion;
using System.Linq;

namespace FinalADS.Infrastructure.Accounts.Persistence.NHibernate.Repository
{
    public class AccountNHibernateRepository : NHibernateRepository<Account>, IAccountRepository
    {
        public AccountNHibernateRepository(UnitOfWorkNHibernate unitOfWork) : base(unitOfWork)
        {
        }

        public Account GetByNumber(string accountNumber)
        {
            return _unitOfWork.GetSession()
                .Query<Account>()
                .SingleOrDefault(x => x.Number == accountNumber);
        }

        public Account GetByNumberWithUpgradeLock(string accountNumber)
        {            
            ICriteria criteria = _unitOfWork.GetSession().CreateCriteria<Account>();
            criteria.SetLockMode(LockMode.Upgrade);
            criteria.Add(Restrictions.Eq("Number", accountNumber));
            Account account = (Account) criteria.UniqueResult();
            return account;
        }
    }
}
