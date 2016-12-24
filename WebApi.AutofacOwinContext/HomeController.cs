using Microsoft.Owin;
using System.Web.Http;

namespace WebApi.AutofacOwinContext
{
    [RoutePrefix("home")]
    public class HomeController : ApiController
    {
        private readonly IOwinContext _context;

        public HomeController(IOwinContext context)
        {
            _context = context;
        }

        [Route("")]
        public string Get()
        {
            return _context.Request.Uri.ToString();
        }
    }
}