using CandidateTest.Core.Entities;
using CandidateTest.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Interfaces.IRepositories
{
    public interface IQuestionRepository : IBaseRepository<Question>
    {
        object GetQuestions(int index, int count, QuestionTypeEnum type, QuestionCategoryEnum category);
    }
}
