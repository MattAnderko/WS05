using MessengerPlatform.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerPlatform.Logic.Classes
{
    public class MessengerLogic : IMessengerLogic
    {
        List<Message> repo;
        public MessengerLogic(List<Message> repo)
        {
            this.repo = repo;
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
