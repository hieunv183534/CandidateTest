using CandidateTest.Core.Entities;
using CandidateTest.Core.Enums;
using CandidateTest.Core.Interfaces.IRepositories;
using CandidateTest.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;

namespace CandidateTest.Core.Services
{
    public class QuestionService : BaseService<Question>, IQuestionService
    {

        IQuestionRepository _questionRepository;
        public QuestionService(IBaseRepository<Question> baseRepository, IQuestionRepository questionRepository) : base(baseRepository)
        {
            _questionRepository = questionRepository;
        }

        public override ServiceResult Add(Question question)
        {
            try
            {
                if(question.Type == QuestionTypeEnum.AnOption)
                {
                    int soDapAnDung = 0;
                    question.ContentJSON_.ForEach(x =>
                    {
                        if (x.Value) soDapAnDung++;
                    });
                    if(soDapAnDung != 1)
                    {
                        _serviceResult.Response = new ResponseModel(4000, "Câu trắc nghiệm 1 đáp án đúng có duy nhất 1 kết quả đúng!");
                        _serviceResult.StatusCode = 400;
                        return _serviceResult;
                    }
                }

                if (question.Type == QuestionTypeEnum.MultiOption)
                {
                    int soDapAnDung = 0;
                    question.ContentJSON_.ForEach(x =>
                    {
                        if (x.Value) soDapAnDung++;
                    });
                    if (soDapAnDung == 0 )
                    {
                        _serviceResult.Response = new ResponseModel(4000, "Câu trắc nghiệm phải có ít nhất 1 đáp án đúng!");
                        _serviceResult.StatusCode = 400;
                        return _serviceResult;
                    }
                }

                question.ContentJSON = Newtonsoft.Json.JsonConvert.SerializeObject(question.ContentJSON_);
                return base.Add(question);
            }
            catch(Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }


        public override ServiceResult Update(Question question, Guid questionId)
        {
            try
            {
                if (question.Type == QuestionTypeEnum.AnOption)
                {
                    int soDapAnDung = 0;
                    question.ContentJSON_.ForEach(x =>
                    {
                        if (x.Value) soDapAnDung++;
                    });
                    if (soDapAnDung != 1)
                    {
                        _serviceResult.Response = new ResponseModel(4000, "Câu trắc nghiệm 1 đáp án đúng có duy nhất 1 kết quả đúng!");
                        _serviceResult.StatusCode = 400;
                        return _serviceResult;
                    }
                }

                if (question.Type == QuestionTypeEnum.MultiOption)
                {
                    int soDapAnDung = 0;
                    question.ContentJSON_.ForEach(x =>
                    {
                        if (x.Value) soDapAnDung++;
                    });
                    if (soDapAnDung == 0)
                    {
                        _serviceResult.Response = new ResponseModel(4000, "Câu trắc nghiệm phải có ít nhất 1 đáp án đúng!");
                        _serviceResult.StatusCode = 400;
                        return _serviceResult;
                    }
                }

                question.ContentJSON = Newtonsoft.Json.JsonConvert.SerializeObject(question.ContentJSON_);
                return base.Update(question, questionId);
            }
            catch (Exception ex)
            {
                _serviceResult.Response = new ResponseModel(9999, "Exception Error", new { msg = ex.Message });
                _serviceResult.StatusCode = 500;
                return _serviceResult;
            }
        }

        public ServiceResult GetQuestions(int index, int count, QuestionTypeEnum type, QuestionCategoryEnum category)
        {
            try
            {
                var result = _questionRepository.GetQuestions(index, count, type, category);
                List<Question> data = (List<Question>)result.GetType().GetProperty("data").GetValue(result, null);
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
