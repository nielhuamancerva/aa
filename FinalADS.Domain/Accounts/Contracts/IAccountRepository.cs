using FinalADS.Domain.Accounts.Entities;
using Common;

namespace FinalADS.Domain.Accounts.Contracts
{
    public interface IAccountRepository : IRepository<Account>
    {
        Account GetByNumber(string accountNumber);
        Account GetByNumberWithUpgradeLock(string accountNumber);
    }
}
