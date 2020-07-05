using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Http;
using static OauthApp.WebApiConfig;

namespace OauthApp.Controllers
{
    public class ValuesController : ApiController
    {

        // GET api/values
        public IEnumerable Get()
        {
            Global.LogMessage("Data from Controller");
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5  
        public string Get(string id)
        {
            Global.LogMessage("Request param : " + id);
            return "value";
        }


        //This resource is For all types of role
        [Authorize(Roles = "SuperAdmin, Admin, User")]
        [HttpGet]
        [Route("api/values/getvalues")]
        public IHttpActionResult GetValues()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var roles = identity.Claims
                        .Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value);
            var LogTime = identity.Claims
                      .FirstOrDefault(c => c.Type == "LoggedOn").Value;
            return Ok("Hello: " + identity.Name + ", " +
                "Your Role(s) are: " + string.Join(",", roles.ToList()) +
                "Your Login time is :" + LogTime);
        }
    }
}
