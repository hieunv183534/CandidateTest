using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Entities
{
    public class Test : BaseEntity
    {
        public Test()
        {

        }

        public Guid TestId { get; set; }

        public string TestCode { get; set; }

        public string TestName { get; set; }

        public string Questions { get; set; }

    }
}
