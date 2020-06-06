using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domains.Subjects.DTOs
{
   public class AllSubjectDTO
    {
        #region Properties

        public long SubjectsId { get; set; }
        public DateTime SubjectsCreateDate { get; set; }
        public DateTime SubjectsUpdateDate { get; set; }
        public string SubjectsTitle { get; set; }
        public long PostsId { get; set; }
        public DateTime PostsCreateDate { get; set; }
        public DateTime PostsUpdateDate { get; set; }
        public string PostsTitle { get; set; }
        public string PostsText { get; set; }
        public int CntPostSubject { get; set; }
        public int PostsAuthorId { get; set; }

        #endregion

    }
}
