using CandidateTest.Core.Entities;
using CandidateTest.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;

namespace CandidateTest.Api.Authentication
{
    public class ValidateTokenClass
    {
        private IConfiguration _configuration;

        public ValidateTokenClass(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public bool ValidateToken(string token)
        {
            if (token.StartsWith("Bearer"))
            {
                token = token.Replace("Bearer", "bearer");
            }
            BaseRepository<TokenAccount> tokenAccountRepo = new BaseRepository<TokenAccount>(_configuration);
            var tokenAccount = tokenAccountRepo.GetByProp("Token", token);
            if (tokenAccount != null)
            {
                return true;
            }
            return false;
        }
    }
}
