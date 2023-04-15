using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerPlatform.Models
{
    public class Message
    {
        public string Sender { get; set; }
        public string MessageContent { get; set; }
        public DateTime SendingDate { get; set; }

        public Message(string sender, string messageContent, DateTime sendingDate)
        {
            Sender = sender;
            MessageContent = messageContent;
            SendingDate = sendingDate;
        }
    }
}
