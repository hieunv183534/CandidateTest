using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Entities
{
    public class TestResult : BaseEntity
    {
        public TestResult()
        {

        }

        public Guid TestResultId { get; set; }

        public Guid TestId { get; set; }

        public Guid CandidateId { get; set; }

        public string Answer { get; set; }

        public int TotalScore { get; set; }

        public bool Status { get; set; }
    }
}
