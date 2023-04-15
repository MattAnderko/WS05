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
        public MessengerLogic()
        {
            repo = new List<Message>();
            if (File.Exists("messages.json"))
            {
                var tmp = JsonConvert.DeserializeObject<Message[]>(File.ReadAllText("messages.json"));
                tmp.ToList().ForEach(x => repo.Add(x));
                ;
            }
        }
        ~MessengerLogic()
        {
            List<Message> messages = new List<Message>();
            foreach (var item in repo)
                messages.Add(item as Message);
            string jsonData = JsonConvert.SerializeObject(messages);
            File.WriteAllText("messages.json", jsonData);

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
    }
}
