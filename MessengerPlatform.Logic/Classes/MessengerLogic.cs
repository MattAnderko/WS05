using MessengerPlatform.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerPlatform.Logic.Classes
{
    public class MessengerLogic : IMessengerLogic
    {
        List<Message> repo;
        private static readonly JsonSerializerSettings _options = new() { NullValueHandling = NullValueHandling.Ignore };
        public MessengerLogic(List<Message> repo)
        {
            var pizzas = JsonConvert.DeserializeObject<Message[]>(File.ReadAllText("messages.json"));
            pizzas.ToList().ForEach(x => repo.Add(x));
        }

        public void Create(Message item)
        {
            this.repo.Add(item);
        }

        public Message Read(int id)
        {
            return this.repo[id];
        }

        public IQueryable<Message> ReadAll()
        {
            return this.repo.AsQueryable();
        }
        ~MessengerLogic()
        {
            List<Message> pizzas = new List<Message>();
            foreach (var item in repo) pizzas.Add(item);
            string jsonData = JsonConvert.SerializeObject(pizzas);
            File.WriteAllText("messages.json", jsonData);
        }
    }
}
