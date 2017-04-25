using HealthAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace HealthAPI.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HealthController : ApiController
    {
        public JToken Get(string id = null)
        {
            if (id == null)
                return GetAllJsonHealthAsArray();
            return GetHealthbyID(id);

        }

        private static JToken GetHealthbyID(string id)
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("/");
            JArray v = JArray.Parse(System.IO.File.ReadAllText
                (path + "app/data/" + "1" + ".json"));
            for (int i = 0; i <= 4; i++)
            {
                if (v[i]["ProductId"].ToString() == id)
                {
                    return v[i];
                }
            }
            return null;

        }
     
        private static JToken GetAllJsonHealthAsArray()
        {
            var path = System.Web.Hosting.HostingEnvironment.MapPath("/");
            return JArray.Parse(System.IO.File.ReadAllText(path + "app/data/" + "health" + ".json"));
        }

     [HttpPost]
        public void Save(string name)
        {
            Health healths = new Health();
            var path = System.Web.Hosting.HostingEnvironment.MapPath("/");
            var dd = JArray.Parse(System.IO.File.ReadAllText(path + "app/data/" + "health" + ".json"));
            dd.Add(healths);
        }
    }
}
