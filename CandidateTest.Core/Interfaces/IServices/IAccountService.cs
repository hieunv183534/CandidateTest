using CandidateTest.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Interfaces.IServices
{
    public interface IAccountService : IBaseService<Account>
    {
        ServiceResult GetAccounts(int index, int count, string searchTerms, string role);
    }
}
