using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace TutorMeNow.Controllers
{
    public class ChatWebAPIControllerController : ApiController
    {
        // GET: api/ChatWebAPIController
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        //[HttpGet]
        //public void SendMessage(string message, string connectionId)
        //{
        //    //return message;
        //    ChatHub.SendMessageToClient(message, connectionId);
        //}

        public static void SendMessageToClient(string endPoint, string connectionId, string message)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://" + endPoint);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            string url = "http://" + endPoint + "/api/ChatWebApi/SendMessage/?Message=" + HttpUtility.UrlEncode(message) + "&ConnectionId=" + connectionId;

            client.GetAsync(url);
        }

        // GET: api/ChatWebAPIController/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ChatWebAPIController
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ChatWebAPIController/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ChatWebAPIController/5
        public void Delete(int id)
        {
        }
    }
}
