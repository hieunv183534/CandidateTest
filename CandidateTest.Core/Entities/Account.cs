using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Entities
{
    public class Account : BaseEntity
    {
        public Account()
        {

        }

        public Guid AccountId { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public string Role { get; set; }

        public string Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Tests { get; set; }

    }
}
