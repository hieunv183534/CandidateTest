using CandidateTest.Core.Entities;
using CandidateTest.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Interfaces.IServices
{
    public interface IQuestionService : IBaseService<Question>
    {
        ServiceResult GetQuestions(int index, int count, QuestionTypeEnum type, QuestionCategoryEnum category);
    }
}
