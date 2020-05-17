using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Blog.DataAccessWrite.Utilites.Result
{
   public static class JsonStatus
    {


        public static JsonResult Success()
        {
            return new JsonResult(new {status="success" });
        }

        public static JsonResult Success(object resultData)
        {
            return new JsonResult(new{status="success",data=resultData});
        }

        public static JsonResult NotFound()
        {
            return new JsonResult(new{status="notfound"});
        }

        public static JsonResult NotFound(object resultData)
        {
            return new JsonResult(new { status = "notfound", data = resultData});
        }

        public static JsonResult Error()
        {
            return new JsonResult(new { status = "error" });
        }

        public static JsonResult Error(object resultData)
        {
            return new JsonResult(new { status = "error", data = resultData });
        }
    }
}
