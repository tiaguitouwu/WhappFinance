using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using WhappFinanceApi.Context;
using WhappFinanceApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WhappFinanceApi.Controllers
{
    public class ClientController : ControllerBase
    {
        private readonly AppDbContext _context;
        public ClientController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("webhook")]
        public string Webhook(
            [FromQuery(Name = "hub.mode")] string mode,
            [FromQuery(Name = "hub.challenge")] string challenge,
            [FromQuery(Name = "hub.verify_token")] string verify_token
        )
        {
            if (verify_token.Equals("hola"))
            {
                return challenge;
            }
            else
            {
                return "";
            }
        }
        [HttpPost]
        [Route("webhook")]
        public dynamic datos([FromBody] WebHookResponseModel entry)
        {
            string mensaje_recibido = entry.entry[0].changes[0].value.messages[0].text.body;   
            string id_wa = entry.entry[0].changes[0].value.messages[0].id;
            string telefono_wa = entry.entry[0].changes[0].value.messages[0].from;

            ClientData dat = new ClientData {
                Id_WA = id_wa,
                PhoneNumber = telefono_wa,
                Message = mensaje_recibido
            };

            _context.ClientData.Add(dat);
            _context.SaveChanges();

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            return response;
        }
    }
}
