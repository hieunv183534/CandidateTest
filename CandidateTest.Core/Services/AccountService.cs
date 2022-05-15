using CandidateTest.Core.Entities;
using CandidateTest.Core.Interfaces.IRepositories;
using CandidateTest.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Services
{
    public class AccountService : BaseService<Account>, IAccountService
    {
        IAccountRepository _accountRepository;

        public AccountService(IBaseRepository<Account> baseRepository, IAccountRepository accountRepository) : base(baseRepository)
        {
            _accountRepository = accountRepository;
        }

        public ServiceResult GetAccounts(int index, int count, string searchTerms, string role)
        {
            try
            {
                var result = _accountRepository.GetAccounts(index, count, searchTerms, role); 
                List<Account> data = (List<Account>)result.GetType().GetProperty("data").GetValue(result, null);
                if (data.Count > 0)
                {
                    _serviceResult.Response = new ResponseModel(2000, "Ok", result);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
                else
                {
                    _serviceResult.Response = new ResponseModel(2004, "Không có bản ghi nào!", result);
                    _serviceResult.StatusCode = 200;
                    return _serviceResult;
                }
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }
    }
}
