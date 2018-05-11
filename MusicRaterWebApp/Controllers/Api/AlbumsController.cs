using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MusicRaterWebApp.Controllers.Api
{
    public class AlbumsController : ApiController
    {
        private MusicRaterContext _context;

        public AlbumsController()
        {
            _context = new MusicRaterContext();
        }
    }
}
