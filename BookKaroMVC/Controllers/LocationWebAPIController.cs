using BookKaroMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookKaroMVC.Controllers
{
    public class LocationWebAPIController : ApiController
    {

        private BookKaroEntities2 db = new BookKaroEntities2();
        // GET: api/LocationWebAPI
        public IEnumerable<tblVendor> Get()
        {
            

            return db.tblVendors.ToList();

        }

        // GET: api/LocationWebAPI/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/LocationWebAPI
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/LocationWebAPI/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/LocationWebAPI/5
        public void Delete(int id)
        {
        }
    }
}
