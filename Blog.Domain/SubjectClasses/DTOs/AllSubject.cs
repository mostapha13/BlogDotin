using System;
using System.Collections.Generic;
using System.Text;

namespace Blog.Domain.SubjectClasses.DTOs
{
   public class AllSubject
    {

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
        public int PostsAuthoId { get; set; }


    }
}
