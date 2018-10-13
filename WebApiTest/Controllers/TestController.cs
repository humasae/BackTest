using System.Collections.Generic;
using System.Web.Http;
using WebApiTest.Filters;

namespace WebApiTest.Controllers
{
    /// <summary>
    /// customer controller class for testing api
    /// </summary>
    [BasicAuthentication]
    public class TestController : ApiController
    {
        // GET api/test 
        public IEnumerable<string> Get()
        {
            return new[] { "value1", "value2" };
        }

        // GET api/test/5  
        public string Get(int id)
        {
            return "value";
        }
    }
}
