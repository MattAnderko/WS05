using MessengerPlatform.Logic.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;


namespace MessengerPlatform.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MessengerController : ControllerBase
    {
        MessengerLogic mLogic;
        IHubContext<SignalRHub> hub;
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }

}
