using CandidateTest.Core.Entities;
using CandidateTest.Core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity>
    {
        public ServiceResult Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Delete(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult DeleteByProp(string propName, object propValue)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetById(Guid entityId)
        {
            throw new NotImplementedException();
        }

        public ServiceResult GetByProp(string propName, object propValue)
        {
            throw new NotImplementedException();
        }

        public ServiceResult Update(TEntity entity, Guid entityId)
        {
            throw new NotImplementedException();
        }
    }
}
