using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Http.Headers;
using WhappFinance.Core.Data.Repository;
using WhappFinance.Core.Data.Repository.IRepository;
using WhappFinance.Models;
using WhappFinance.Models.ViewModels;

namespace WhappFinance.Areas.Client
{
    [ApiController]
    [Route("api/client")]
    public class ClientController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public ClientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

            int newIdPhoneNum = 0;
            int idPhoneNum = _unitOfWork.PhoneNumber.GetFirstOrDefault(p => p.Number == telefono_wa)?.Id ?? 0;

            if (idPhoneNum == 0) {
                PhoneNumber phoneNumber = new PhoneNumber
                {
                    Number = telefono_wa,
                    ContactName = "Desconocido"
                };
                _unitOfWork.PhoneNumber.Add(phoneNumber);
                _unitOfWork.Save();
                newIdPhoneNum = _unitOfWork.PhoneNumber.GetFirstOrDefault(p => p.Number == phoneNumber.Number)?.Id ?? 0;
            }

            

            ClientData dat = new ClientData
            {
                Id_WA = id_wa,
                IdPhoneNumber = idPhoneNum > 0 ? idPhoneNum : newIdPhoneNum,
                Message = mensaje_recibido
            };

            _unitOfWork.ClientData.Add(dat);
            _unitOfWork.Save();

            var response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("text/plain");
            return response;
        }
    }
}
