using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Blog.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : Controller
    {


        #region Success

        public static JsonResult Success()
        {
            return new JsonResult(new { status = "success" });
        }

        public static JsonResult Success(object resultData)
        {
            return new JsonResult(new { status = "success", data = resultData });
        }


        #endregion


        #region Error
        public static JsonResult Error()
        {
            return new JsonResult(new { status = "error" });
        }

        public static JsonResult Error(object resultData)
        {
            return new JsonResult(new { status = "error", data = resultData });
        }
        #endregion


        //#region NotFound
        //public static JsonResult NotFound()
        //{
        //    return new JsonResult(new { status = "notfound" });
        //}

        //public static JsonResult NotFound(object resultData)
        //{
        //    return new JsonResult(new { status = "notfound", data = resultData });
        //}

        //#endregion




    }
}
