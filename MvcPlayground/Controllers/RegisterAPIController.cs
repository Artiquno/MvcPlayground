using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Dynamic;

namespace MvcPlayground.Controllers
{
    public class RegisterAPIController : ApiController
    {
        [Route("api/register")]
        [HttpPost]
        public IHttpActionResult RegisterUser()
        {
            const string path = "~/Uploads/Images/";
            var request = HttpContext.Current.Request;
            var file = request.Files["profileImage"];
            string savePath = HttpContext.Current.Server.MapPath(path + file.FileName);
            try
            {
                file.SaveAs(savePath);
            }
            catch (HttpException)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }

            var responsePath = Url.Content(path + file.FileName);

            var data = request.Form;
            var result = new
            {
                profileImage = responsePath,
                username = data["username"],
                name = data["name"],
                lastName = data["lastName"],
                email = data["email"],
                arr = new object[]
                {
                    "Hello",
                    "How are you?",
                    "I hope you haven't been wasting your time doing useless shit!",
                    new
                    {
                        weird = "Very",
                        fun = "Yap",
                        wrong = "Completely",
                        doWeCare = new
                        {
                            nope = "Nope",
                            no = "Definitely not!",
                            nah = "Not even a little bit!"
                        }
                    }
                },
                randomFinish = new Random().Next()
            };

            var response = Request.CreateResponse(HttpStatusCode.Created, result);

            return ResponseMessage(response);
        }
    }
}
