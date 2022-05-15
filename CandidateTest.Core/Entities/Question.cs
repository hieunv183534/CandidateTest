using CandidateTest.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CandidateTest.Core.Entities
{
    public class Question : BaseEntity
    {
        //private string contentJSON;
        //private List<QuestionItem> contentJSON_;

        public Question()
        {

        }

        public Guid QuestionId { get; set; }

        public QuestionTypeEnum Type { get; set; }

        public string ContentText { get; set; }

        //public string ContentJSON
        //{
        //    get { return this.contentJSON; }
        //    set
        //    {
        //        this.contentJSON = value;
        //        if (this.contentJSON_ == null)
        //            this.contentJSON_ = Newtonsoft.Json.JsonConvert.DeserializeObject<List<QuestionItem>>(value);
        //    }
        //}

        //public List<QuestionItem> ContentJSON_
        //{
        //    get { return this.contentJSON_; }
        //    set
        //    {
        //        this.contentJSON_ = value;
        //        if (this.contentJSON == null)
        //            this.contentJSON = Newtonsoft.Json.JsonConvert.SerializeObject(value);
        //    }
        //}

        public string ContentJSON { get; set; }

        public List<QuestionItem> ContentJSON_ { get; set; }

        public QuestionCategoryEnum Category { get; set; }

    }

    public class QuestionItem
    {
        public string Key { get; set; }

        public bool Value { get; set; }
    }
}
