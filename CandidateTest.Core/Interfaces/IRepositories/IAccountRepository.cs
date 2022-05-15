using CandidateTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Interfaces.IRepositories
{
    public interface IAccountRepository : IBaseRepository<Account>
    {
        object GetAccounts(int index, int count, string searchTerms, string role);
    }
}
