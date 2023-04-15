using MessengerPlatform.Models;
using System.Linq;

namespace MessengerPlatform.Logic.Classes
{
    public interface IMessengerLogic
    {
        void Create(Message item);
        Message Read(int id);
        IQueryable<Message> ReadAll();
    }
}