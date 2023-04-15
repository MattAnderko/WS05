using MessengerPlatform.Logic.Classes;
using MessengerPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using MovieDbApp.Endpoint.Services;
using System.Collections.Generic;


namespace MessengerPlatform.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessengerController : ControllerBase
    {
        MessengerLogic logic;
        IHubContext<SignalRHub> hub;

        public MessengerController(MessengerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Message> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Message Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Message value)
        {
            this.logic.Create(value);
            this.hub.Clients.All.SendAsync("MessageCreated", value);
        }
    }

}
